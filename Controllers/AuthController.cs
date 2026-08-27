using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTO;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;

namespace VigilyAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly VigilyAPICon _vigily;

    public AuthController(VigilyAPICon vigily)
    {
        _vigily = vigily;
    }

    [HttpPost("vigilante/login")]
    public async Task<ActionResult<TokenModelDTO>> LoginVigilanteAsync(
        IVigilanteService vigilanteService,
        ITokenService tokenService,
        [FromBody] LoginDTO login,
        IConfiguration config
    )
    {
        Vigilante vigilante = await vigilanteService.LoginAsync(login.Login, login.Senha);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, vigilante.Nome),
            new Claim(ClaimTypes.NameIdentifier, vigilante.VigilanteId.ToString()),
            new Claim(ClaimTypes.Role, "Vigilante"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var accessToken = tokenService.GenerateAccessToken(claims, config);
        var refreshToken = tokenService.GenerateRefreshToken();

        vigilante.RefreshToken = refreshToken;

        _ = int.TryParse(
            config["JWT:RefreshTokenValidityInMinutes"],
            out var refreshTokenValidityInMinutes
        );

        vigilante.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

        await _vigily.SaveChangesAsync();

        return Ok(new TokenModelDTO { AccessToken = accessToken, RefreshToken = refreshToken });
    }

    [HttpPost("empresa/login")]
    public async Task<ActionResult<TokenModelDTO>> LoginEmpresaAsync(
        IEmpresaService empresaService,
        ITokenService tokenService,
        [FromBody] LoginDTO login,
        IConfiguration config
    )
    {
        Empresa empresa = await empresaService.LoginAsync(login.Login, login.Senha);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, empresa.Nome),
            new Claim(ClaimTypes.NameIdentifier, empresa.EmpresaId.ToString()),
            new Claim(ClaimTypes.Role, "Empresa"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var accessToken = tokenService.GenerateAccessToken(claims, config);
        var refreshToken = tokenService.GenerateRefreshToken();

        empresa.RefreshToken = refreshToken;

        _ = int.TryParse(
            config["JWT:RefreshTokenValidityInMinutes"],
            out var refreshTokenValidityInMinutes
        );

        empresa.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

        await _vigily.SaveChangesAsync();

        return Ok(new TokenModelDTO { AccessToken = accessToken, RefreshToken = refreshToken });
    }

    [HttpPost("refresh")]
    public async Task<ActionResult> RefreshAsync(
        TokenModelDTO tokenApiModel,
        ITokenService tokenService,
        IConfiguration config
    )
    {
        if (
            tokenApiModel is null
            || string.IsNullOrEmpty(tokenApiModel.AccessToken)
            || string.IsNullOrEmpty(tokenApiModel.RefreshToken)
        )
        {
            throw new ArgumentException(
                "TokenApiModel, AccessToken e RefreshToken sao obrigatorios"
            );
        }

        ClaimsPrincipal principal = tokenService.GetPrincipalFromExpiredToken(
            tokenApiModel.AccessToken,
            config
        );

        var tipoClaim = principal.FindFirst(ClaimTypes.Role);
        if (tipoClaim == null)
        {
            throw new Exception("Claim de Role nao encontrada no access token");
        }

        var newRefreshToken = tokenService.GenerateRefreshToken();
        string newAccessToken;

        switch (tipoClaim.Value)
        {
            case "Vigilante":
                var vigilante = await VigilanteRefreshValidatorAsync(principal, tokenApiModel.RefreshToken);
                newAccessToken = tokenService.GenerateAccessToken(principal.Claims, config);
                vigilante.RefreshToken = newRefreshToken;
                await _vigily.SaveChangesAsync();
                break;

            case "Empresa":
                var empresa = await EmpresaRefreshValidatorAsync(principal, tokenApiModel.RefreshToken);
                newAccessToken = tokenService.GenerateAccessToken(principal.Claims, config);
                empresa.RefreshToken = newRefreshToken;
                await _vigily.SaveChangesAsync();
                break;

            default:
                throw new Exception($"Role '{tipoClaim.Value}' nao suportada para refresh");
        }

        return Ok(
            new TokenModelDTO { AccessToken = newAccessToken, RefreshToken = newRefreshToken }
        );
    }

    private async Task<Vigilante> VigilanteRefreshValidatorAsync(ClaimsPrincipal principal, string refreshToken)
    {
        var idClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        if (idClaim == null || !int.TryParse(idClaim.Value, out int claimID))
        {
            throw new Exception("Claims do token invalidas");
        }

        Vigilante vigilante = await _vigily.Vigilante.FirstOrDefaultAsync(x => x.VigilanteId == claimID);
        if (vigilante == null)
        {
            throw new Exception("Vigilante nao encontrado");
        }
        else if (vigilante.RefreshToken != refreshToken)
        {
            throw new Exception("RefreshToken invalido");
        }
        else if (vigilante.RefreshTokenExpiryTime <= DateTime.Now)
        {
            throw new Exception("Refresh Token expirado");
        }

        return vigilante;
    }

    private async Task<Empresa> EmpresaRefreshValidatorAsync(ClaimsPrincipal principal, string refreshToken)
    {
        var idClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        if (idClaim == null || !int.TryParse(idClaim.Value, out int claimID))
        {
            throw new Exception("Claims do token invalidas");
        }

        Empresa empresa = await _vigily.Empresa.FirstOrDefaultAsync(x => x.EmpresaId == claimID);
        if (empresa == null)
        {
            throw new Exception("Empresa nao encontrada");
        }
        else if (empresa.RefreshToken != refreshToken)
        {
            throw new Exception("RefreshToken invalido");
        }
        else if (empresa.RefreshTokenExpiryTime <= DateTime.Now)
        {
            throw new Exception("Refresh Token expirado");
        }

        return empresa;
    }

    [HttpPost("revoke/vigilante/{vigilanteId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RevokeVigilanteAsync(int vigilanteId)
    {
        var vigilante = await _vigily.Vigilante.FirstOrDefaultAsync(x => x.VigilanteId == vigilanteId);
        if (vigilante == null)
        {
            return NotFound($"Vigilante com id {vigilanteId} nao encontrado");
        }

        vigilante.RefreshToken = null;
        await _vigily.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("revoke/empresa/{empresaId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RevokeEmpresaAsync(int empresaId)
    {
        var empresa = await _vigily.Empresa.FirstOrDefaultAsync(x => x.EmpresaId == empresaId);
        if (empresa == null)
        {
            return NotFound($"Empresa com id {empresaId} nao encontrada");
        }

        empresa.RefreshToken = null;
        await _vigily.SaveChangesAsync();

        return NoContent();
    }
}

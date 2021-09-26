using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ApiAUT.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiAUT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        //private readonly AppSettings _appSettings;//do video

        //public UsuariosController(UserManager<ApplicationUser> userManager,
        //    SignInManager<ApplicationUser> signInManager,
        //    IOptions <AppSettings> appSettings)
        //{
        //    _userManager = userManager; //cria o usuário
        //    _signInManager = signInManager;
        //    _appSettings = appSettings;
        //}

        private readonly AppSettings _appSettings;//do video

        public UsuariosController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager; //cria o usuário
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return " << Controlador UsuariosController :: APIAUT >> ";
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            //verificar se houve erros
            if (ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return BuildToken(model);
                //return Ok(await GerarJwt(registerUser.Email)); //video
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            //verificar se houve erros
            if (ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(userInfo);
                //return Ok(await GerarJwt(registerUser.Email)); //video
            }
            else
            {
                ModelState.AddModelError(string.Empty, "login inválido.");
                return BadRequest(ModelState);
            }
        }
        private UserToken BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuValor", "o que voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
        //video
        //private async Task<string> GerarJWT(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    var tokenHandle = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescription = new SecurityTokenDescriptor
        //    {
        //        Issuer = _appSettings.Emissor,
        //        Audience = _appSettings.ValidadoEm,
        //        Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    return tokenHandle.WriteToken(tokenHandle.CreateToken(tokenDescription));
        //}
    }
}

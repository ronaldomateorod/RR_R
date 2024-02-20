using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using RESCO_RRPAYROLL.Models;
using RESCO_RRPAYROLL.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RESCO_RRPAYROLL.Controllers
{
    public class AccessController : Controller
    {
        private readonly RrpayrollDbContext _context;

        public AccessController(RrpayrollDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre && u.Contrasena == usuario.Contrasena); 
            if (usuarioEncontrado != null)

            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Nombre),
                    new Claim("OtherProperties", "Example role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = false
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }
    }
}

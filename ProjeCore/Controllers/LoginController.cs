using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.DAL;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            context = _context;
        }
        
        
        
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanıcı == p.Kullanıcı && x.Şifre == p.Şifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanıcı)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                RedirectToAction("Index", "Personel");
            }
            return View();
        }
    }
}

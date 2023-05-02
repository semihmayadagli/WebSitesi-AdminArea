using HaftalikGorev.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public LoginController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var kullanici = await _databasecontext.Users.FirstOrDefaultAsync(u=>u.Email==email && u.Password==password && u.IsActive);
                if (kullanici==null) 
                {
                    TempData["Mesaj"] = "<div class='alert alert-danger'> Giriş Başarısız </div>";
                }
                else
                {
                    var haklar = new List<Claim>() 
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email)
                    };
                    var kullaniciKimligi= new ClaimsIdentity(haklar,"Login");
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin)
                    {
                        return Redirect("/Admin");
                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }

            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu";
                throw;
            }
            return View();
        }
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}

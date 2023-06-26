using F23L034_GestContact_Cqs.WebApp.Models.Entities;
using F23L034_GestContact_Cqs.WebApp.Models.Repositories;
using F23L034_GestContact_Cqs.WebApp.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using F23L034_GestContact_Cqs.WebApp.Models.Queries;
using F23L034_GestContact_Cqs.WebApp.Models.Commands;
using Tools.Cqs.Commands;
using F23L034_GestContact_Cqs.WebApp.Infrastructure;

namespace F23L034_GestContact_Cqs.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            Utilisateur? utilisateur = _authRepository.Execute(new LoginQuery(form.Email, form.Passwd));

            if(utilisateur is null)
            {
                ModelState.AddModelError("", "Erreur email ou mot de passe...");
                return View(form);
            }

            _sessionManager.UserInfo = new UserInfo { Id = utilisateur.Id, Nom = utilisateur.Nom, Prenom = utilisateur.Prenom };

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }

            Result result = _authRepository.Execute(new RegisterCommand(form.Nom, form.Prenom, form.Email, form.Passwd));

            if(result.IsFailure)
            {
                ModelState.AddModelError("", result.Message!);
                return View(form);
            }
                
            return RedirectToAction(nameof(Login));           
        }

        public IActionResult Disconnect()
        {
            _sessionManager.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

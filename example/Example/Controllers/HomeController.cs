namespace Example.Controllers
{
    using System.Web.Mvc;
    using DomainModel;
    using Infrostructure;
    using ViewModel;

    public class HomeController : ExampleController
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [ExampleAuthintificationAtribute]
        public ActionResult AllIndex()
        {
            return View(CurrentUser);
        }

        [ExampleAuthintificationAtribute(Role.User)]
        public ActionResult UserIndex()
        {
            return View(CurrentUser);
        }

        [ExampleAuthintificationAtribute(Role.Admin)]
        public ActionResult AdminIndex()
        {
            return View(CurrentUser);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (login.Name == "Admin" && login.Password == "Admin")
            {
                var account = new Account()
                {
                    Email = "admin@admin.admin", 
                    Login = "Admin", 
                    Password = "Admin", 
                    Role = Role.Admin
                };
                var authorize = new ExampleAuthorizeService();
                authorize.SignIn(account, false);
            }
            else if (login.Name == "User" && login.Password == "User")
            {
                var account = new Account()
                {
                    Email = "user@user.user",
                    Login = "User",
                    Password = "User",
                    Role = Role.User
                };
                var authorize = new ExampleAuthorizeService();
                authorize.SignIn(account, false);
            }
            else
            {
                return View(); 
            }

            return RedirectToAction("AllIndex");
        }

        public ActionResult Logout()
        {
            var authorize = new ExampleAuthorizeService();
            authorize.SignOut();
            return RedirectToAction("Index");
        }

    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Portfolio.ViewModels;
using System.Linq;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var projectList = Projects.GetProjects();
            return View(projectList);
        }
    }
}

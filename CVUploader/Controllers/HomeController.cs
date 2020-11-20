using CVUploader.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CVUploader.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;

        public HomeController(IApplicantRepository applicantRepository)
        {
            this._applicantRepository = applicantRepository;
        }

        // GET: Home
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _applicantRepository.GetApplicants());
        }
    }
}
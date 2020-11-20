using CVUploader.Models;
using CVUploader.Repository;
using CVUploader.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CVUploader.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IDocumentsRepository _documentsRepository;

        public ApplicantController(
            IApplicantRepository applicantRepository,
            IDocumentsRepository documentsRepository)
        {
            this._applicantRepository = applicantRepository;
            this._documentsRepository = documentsRepository;
        }

        // GET: Applicant
        [HttpGet]
        public ActionResult Index(ApplicantViewModel model)
        {
            if(model.Applicant != null)
                return View(model);
            return View(model: null);
        }

        // POST: Applicant
        [HttpPost]
        public async Task<ActionResult> Create(ApplicantViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return View("Index", model);
            
            try
            {
                var img = Image.FromStream(model.Image.InputStream);
                if (img.Width > 256 && img.Height > 256)
                {
                    ModelState.AddModelError("Image", "Image Cannot exceed 256x256");
                    return View("Index", model);
                }
                
                if ( (Path.GetExtension(model.Image.FileName) == ".png" ||
                    Path.GetExtension(model.Image.FileName) == ".jpg") && 
                    (Path.GetExtension(model.CVFile.FileName) == ".pdf" || 
                    Path.GetExtension(model.CVFile.FileName) == ".docx" ) )
                {
                    // saving the image
                    string imgInternalPath = SaveImgFile(model.Image);

                    // saving the file
                    string cvInternalPath = SaveFile(model.CVFile);

                    var createdApplicant = await _applicantRepository.AddAplicant(model.Applicant);

                    await _documentsRepository.AddDocument(new Document
                    {
                        Type = DocumentType.Image,
                        URI = imgInternalPath,
                        ApplicantId = createdApplicant.Id
                    }, createdApplicant.Id);

                    await _documentsRepository.AddDocument(new Document
                    {
                        Type = DocumentType.CV,
                        URI = cvInternalPath,
                        ApplicantId = createdApplicant.Id
                    }, createdApplicant.Id);

                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("Image", "Image can only be png or jpg");
                    ModelState.AddModelError("CVFile", "Cv File can only be pdf or docx");
                    return View("Index", model);
                }
            }
            catch(Exception)
            {
                return View("Index", model);
            }
        }

        #region Methods

        private string SaveImgFile(HttpPostedFileBase img)
        {
            string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
            string fullPath = Path.Combine(HttpContext.Server.MapPath("~/Content/Uploads/imgs"), randomFileName);
            img.SaveAs(fullPath);
            return randomFileName;
        }

        private string SaveFile(HttpPostedFileBase file)
        {
            string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(HttpContext.Server.MapPath("~/Content/Uploads/documents"), randomFileName);
            file.SaveAs(fullPath);
            return randomFileName;
        }

        #endregion
    }
}
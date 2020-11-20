using CVUploader.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVUploader.ViewModels
{
    public class ApplicantViewModel
    {
        [Required]
        public Applicant Applicant { get; set; }
        [Required]
        public HttpPostedFileBase Image { get; set; }
        [Required]
        [Display(Name = "C.V")]
        public HttpPostedFileBase CVFile { get; set; }
    }
}
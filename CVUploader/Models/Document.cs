using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVUploader.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string URI { get; set; }
        public DocumentType Type { get; set; }
        [ForeignKey(nameof(Applicant))]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
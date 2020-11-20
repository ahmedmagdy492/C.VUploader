using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVUploader.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public IList<Document> Documents { get; set; }
    }
}
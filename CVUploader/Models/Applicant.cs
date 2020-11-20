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
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public IList<Document> Documents { get; set; }
    }
}
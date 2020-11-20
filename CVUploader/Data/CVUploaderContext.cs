using CVUploader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CVUploader.Data
{
    public class CVUploaderContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Document> Documents { get; set; }

        public CVUploaderContext() : base("name=DefaultConnection")
        {
        }
    }
}
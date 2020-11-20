using CVUploader.Data;
using CVUploader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CVUploader.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly CVUploaderContext _context;

        public ApplicantRepository(CVUploaderContext context)
        {
            this._context = context;
        }

        public async Task<Applicant> AddAplicant(Applicant applicant)
        {
            var createdApplicant = _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return createdApplicant;
        }

        public async Task<IEnumerable<Applicant>> GetApplicants()
        {
            return await _context.Applicants.Include("Documents").ToListAsync();
        }
    }
}
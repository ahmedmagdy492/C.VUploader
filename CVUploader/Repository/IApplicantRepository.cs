using CVUploader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVUploader.Repository
{
    public interface IApplicantRepository
    {
        Task<IEnumerable<Applicant>> GetApplicants();
        Task<Applicant> AddAplicant(Applicant applicant);
    }
}

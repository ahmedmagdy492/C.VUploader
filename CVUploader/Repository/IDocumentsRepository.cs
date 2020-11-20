using CVUploader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVUploader.Repository
{
    public interface IDocumentsRepository
    {
        Task<IEnumerable<Document>> GetDocuments(int applicantId);
        Task<Document> AddDocument(Document document, int applicantId);
    }
}

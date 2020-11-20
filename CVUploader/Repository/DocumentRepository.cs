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
    public class DocumentRepository : IDocumentsRepository
    {
        private readonly CVUploaderContext _context;

        public DocumentRepository(CVUploaderContext context)
        {
            this._context = context;
        }

        public async Task<Document> AddDocument(Document document, int applicantId)
        {
            document.ApplicantId = applicantId;
            var createdDoc = _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return createdDoc;
        }

        public async Task<IEnumerable<Document>> GetDocuments(int applicantId)
        {
            return await _context.Documents.Where(a => a.ApplicantId == applicantId).ToListAsync();
        }
    }
}
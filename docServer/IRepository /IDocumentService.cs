using System;
using docServer.DTOs;
using docServer.Models;

namespace docServer.IRepository
{
	public interface IDocumentService
	{
        Task<List<Document>> GetAllDocuments();

        Task<Document> GetSingleDocument(int id);

        Task<Document> CreateDocument(CreateDocumentDTO DocumentDTO);

        Task<Document> DeleteDocument(int id);

        Task<Document> EditDocument(int id, UpdateDocumentDTO DocumentDTO);
    }
}


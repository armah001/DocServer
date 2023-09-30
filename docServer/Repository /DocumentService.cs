using System;
using AutoMapper;
using docServer.Data;
using docServer.DTOs;
using docServer.IRepository;
using docServer.Models;
using docServer.Repository;
using Microsoft.AspNetCore.Mvc;


namespace docServer.Repository
{
	public class DocumentService:IDocumentService
	{
        private readonly docServerContext context;
        private readonly iUnitOfWorks _unitOfWork;
        private readonly ILogger<DocumentService> _logger;
        private readonly IMapper _mapper;

        public DocumentService(iUnitOfWorks unitOfWork, ILogger<DocumentService> logger,
            docServerContext context, IMapper mapper)
		{
            _unitOfWork = unitOfWork;
            _logger = logger;
            this.context = context;
            _mapper = mapper;
        }

        public async Task<List<Document>> GetAllDocuments()
        {

            var products = await _unitOfWork.Documents.GetAll();

            return products.ToList();
        }

        public async Task<Document> GetSingleProduct(int id)
        {
            var product = await _unitOfWork.Documents.Get(q => q.DocId == id);
            return product;
        }

        public async Task<Document> CreateDocument(DocumentDTO ProductDTO)
        {
            var document = _mapper.Map<Document>(ProductDTO);
            await _unitOfWork.Documents.Insert(document);
            await _unitOfWork.Save();
            return document;
        }

        public async Task<Document> DeleteDocument(int id)
        {
            var document = await _unitOfWork.Documents.Get(q => q.DocId == id);
            if (document == null)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteDocument)}");
                //return BadRequest("Inavlid Data Submitted");
            }
            await _unitOfWork.Documents.Delete(id);
            await _unitOfWork.Save();
            return document;
        }

        public async Task<Document> EditDocument(int id, [FromBody] UpdateDocumentDTO DocumentDTO)
        {
            var document = await _unitOfWork.Documents.Get(q => q.DocId == id);

            if (document == null)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(EditDocument)}");
                //return BadRequest("Cannot process submitted data");
            }
            _mapper.Map(DocumentDTO, document);
            _unitOfWork.Documents.Update(document);
            await _unitOfWork.Save();
            return document;
        }
    }
}


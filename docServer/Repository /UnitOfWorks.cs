using System;
using docServer.IRepository;
using docServer.Data;

using docServer.Models;

namespace docServer.Repository
{
	public class UnitOfWorks:iUnitOfWorks

	{
        private readonly docServerContext _context;
        private IGenericRepository<Document> _documents;
        private readonly ILogger<UnitOfWorks> _logger;

        public UnitOfWorks(docServerContext context, ILogger<UnitOfWorks> logger)
        {

            _context = context;
            _logger = logger;
        }

        public IGenericRepository<Document> Documents => _documents ??= new GenericRepository<Document>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            
        }

    }
}


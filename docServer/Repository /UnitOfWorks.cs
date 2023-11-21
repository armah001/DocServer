using System;
using docServer.IRepository;
using docServer.Data;

using docServer.Models;

namespace docServer.Repository
{
	public class UnitOfWorks:iUnitOfWorks

	{
        private readonly docServerContext _context;
        private readonly ILogger<UnitOfWorks> _logger;

        public UnitOfWorks(docServerContext context, ILogger<UnitOfWorks> logger)
        {

            _context = context;
            _logger = logger;
        }


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


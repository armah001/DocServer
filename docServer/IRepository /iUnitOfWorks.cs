using System;
using docServer.Models;

namespace docServer.IRepository
{
	public interface iUnitOfWorks : IDisposable
    {
        IGenericRepository<Document> Documents { get; }

        Task Save();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using docServer.Models;
using Serilog.Core;
using System.Diagnostics.CodeAnalysis;

namespace docServer.Data
{
	public class docServerContext:DbContext
	{
        public DbSet<User> User { get; set; }
        public DbSet<Document> Document { get; set; }

    }
}


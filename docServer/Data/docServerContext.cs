using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using docServer.Models;
using Serilog.Core;
using System.Reflection.Emit;


namespace docServer.Data
{
	public class docServerContext:DbContext
	{
        public DbSet<User> User { get; set; }
        //public DbSet<Document> Document { get; set; }


        public docServerContext(DbContextOptions<docServerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Map entities to tables
            //Users
            builder.Entity<User>().ToTable("docServerUser");

            // Configure Primary Key
            builder.Entity<User>().HasKey(ug => ug.Id).HasName("UserId");

            // Configure columns  
            builder.Entity<User>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            builder.Entity<User>().Property(ug => ug.FullName).HasColumnType("nvarchar(100)").IsRequired();

            builder.Entity<User>().Property(ug => ug.Email).HasColumnType("nvarchar(100)").IsRequired();

            builder.Entity<User>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();

            //Documents
            //builder.Entity<Document>().ToTable("docServerDocuments");

            ////Confifure primary key  
            //builder.Entity<Document>().HasKey(doc => doc.DocId).HasName("DocID");

            //// Configure columns

            //builder.Entity<Document>().Property(doc => doc.DocId).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            //builder.Entity<Document>().Property(doc => doc.DocName).HasColumnType("nvarchar(255)")
            //    .IsRequired();

            //builder.Entity<Document>().Property(doc => doc.DocType).HasColumnType("nvarchar(50)")
            //    .IsRequired();

            //builder.Entity<Document>().Property(d => d.DocDescription).HasColumnType("nvarchar(max)");

        }

        public virtual DbSet<User> Usrers { get; set; }
        //public virtual DbSet<Document> Documents { get; set; }
    }
}


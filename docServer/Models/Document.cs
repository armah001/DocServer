using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace docServer.Models
{
  
    public class Document
    {
        public Document()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocId { get; set; }

        [Required]
        public String DocName { get; set; }

        [Required]
        public String DocDescription { get; set; }
      
        public String DocType { get; set; }

        public Document(int DocId, string DocName, string DocDescription, string DocType)
        {
            DocId = docId;
            DocName = docName;
            DocDescription = docDescription;
            DocType = docType;

        }
    }
}

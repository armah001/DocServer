using System;
using System.ComponentModel.DataAnnotations;
using static docServer.DTOs.DocumentDTO;

namespace docServer.DTOs
{
    public class DocumentDTO : CreateDocumentDTO
    {
        public long DocId { get; set; }
        //public string DocName { get; set; }
        //public string DocType { get; set; }
        //public string DocDescription { get; set; }
    }

        public class CreateDocumentDTO
        {
            [Required]
            //[StringLength(maximumLength:)]
            public string DocName { get; set; }
            [Required]
            public string DocType { get; set; }
            [Required]
            public string DocDescription { get; set; }
        }

        public class UpdateDocumentDTO
        {
            [Required]
            //[StringLength(maximumLength:)]
            public string DocName { get; set; }
            
            [Required]
            public string DocDescription { get; set; }
        }
    
}


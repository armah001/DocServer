using System;
namespace docServer.DTOs
{
	public class DocumentDTO
	{
        public long DocId { get; set; }
        public string DocName { get; set; }
        public string DocType { get; set; }
        public string DocDescription { get; set; }
        // You can include other properties if needed, but not DocData
    }
}


using System;
namespace docServer.Models
{
	public class Document
	{
        public long DocId { get; set; }
        public string DocName { get; set; }
        public string DocType { get; set; }
        public byte[] DocData { get; set; } // Assuming binary data, you can change the type accordingly
        public string DocDescription { get; set; }

        public Document(long docId, string docName, string docType, byte[] docData, string docDescription)
        {
            DocId = docId;
            DocName = docName;
            DocType = docType;
            DocData = docData;
            DocDescription = docDescription;
        }
    }
}


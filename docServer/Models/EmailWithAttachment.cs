using System;
namespace docServer.Models
{
	public class EmailWithAttachment
	{
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte[] AttachmentData { get; set; }
        public string AttachmentFileName { get; set; }

        public EmailWithAttachment()
		{
		}
	}
}


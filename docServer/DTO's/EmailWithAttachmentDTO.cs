using System;
using System.ComponentModel.DataAnnotations;
namespace docServer.DTOs
{
    public class EmailWithAttachmentDTO
    {
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte[] AttachmentData { get; set; }
        public string AttachmentFileName { get; set; }
    }
}
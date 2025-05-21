namespace SecureDocStorage.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public int Revision { get; set; }
        public byte[] Content { get; set; }
        public DateTime UploadedAt { get; set; }
        public int UserId { get; set; }
        public User ? User { get; set; }
    }
}

namespace SecureDocStorage.DTOs
{
    public class UploadDocumentDto
    {
        public string FileName { get; set; } = "";
        public IFormFile File { get; set; } = null!;
    }
}

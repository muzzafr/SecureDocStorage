using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureDocStorage.Data;
using SecureDocStorage.DTOs;
using SecureDocStorage.Models;
using System.Security.Claims;

namespace SecureDocStorage.Controllers
{
    [ApiController]
    [Route("files")]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadDocumentDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var existingVersions = await _context.Documents
                .Where(d => d.FileName == dto.FileName && d.UserId == userId)
                .ToListAsync();

            using var ms = new MemoryStream();
            await dto.File.CopyToAsync(ms);
            var content = ms.ToArray();

            var document = new Document
            {
                FileName = dto.FileName,
                Revision = existingVersions.Count,
                Content = content,
                UploadedAt = DateTime.UtcNow,
                UserId = userId
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Uploaded successfully", revision = document.Revision });
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> Download(string filename, [FromQuery] int? revision = null)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var query = _context.Documents
                .Where(d => d.FileName == filename && d.UserId == userId)
                .OrderBy(d => d.Revision);

            var doc = revision.HasValue
                ? await query.Skip(revision.Value).Take(1).FirstOrDefaultAsync()
                : await query.OrderByDescending(d => d.Revision).FirstOrDefaultAsync();

            if (doc == null) return NotFound("Document not found");

            return File(doc.Content, "application/octet-stream", filename);
        }
    }
}

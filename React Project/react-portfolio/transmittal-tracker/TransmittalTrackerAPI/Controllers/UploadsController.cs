using Microsoft.AspNetCore.Mvc;

namespace TransmittalTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadsController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    public UploadsController(IWebHostEnvironment env) => _env = env;

    // 20 MB; ubah sesuai kebutuhan
    [HttpPost]
    [RequestSizeLimit(20_000_000)]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string? folder)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        // validasi tipe file
        var allowed = new[] { "image/png", "image/jpeg", "image/jpg", "application/pdf" };
        if (!allowed.Contains(file.ContentType))
            return BadRequest("Unsupported file type.");

        // root static files
        var webRoot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
        var sub = string.IsNullOrWhiteSpace(folder) ? "" : folder.Trim();
        var saveDir = Path.Combine(webRoot, "uploads", sub);
        Directory.CreateDirectory(saveDir);

        var ext = Path.GetExtension(file.FileName);
        var fileName = $"{DateTime.UtcNow:yyyyMMddHHmmssfff}-{Guid.NewGuid():N}{ext}";
        var fullPath = Path.Combine(saveDir, fileName);

        await using (var stream = System.IO.File.Create(fullPath))
            await file.CopyToAsync(stream);

        // URL publik
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var urlPath = $"/uploads/{(string.IsNullOrEmpty(sub) ? "" : sub + "/")}{fileName}";
        var url = baseUrl + urlPath;

        return Ok(new { url });
    }
}
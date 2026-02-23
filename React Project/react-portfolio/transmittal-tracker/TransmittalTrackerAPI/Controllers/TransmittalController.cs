using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransmittalTrackerAPI.Data;
using TransmittalTrackerAPI.Models;

namespace TransmittalTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransmittalController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TransmittalController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // 📘 GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Transmittals.ToListAsync();
            return Ok(data);
        }

        // 📘 GET BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trans = await _context.Transmittals.FindAsync(id);
            if (trans == null) return NotFound();
            return Ok(trans);
        }

        // CREATE
[HttpPost]
[RequestSizeLimit(100_000_000)]
public async Task<IActionResult> Create([FromForm] Transmittal dto, IFormFile? file) // <-- [FromForm] penting
{
    if (string.IsNullOrWhiteSpace(dto.TransNo))
        return BadRequest("TransNo is required.");

    var t = new Transmittal
    {
        TransNo   = dto.TransNo,          // <-- set TransNo
        JobNumber = dto.JobNumber,
        Title     = dto.Title,
        Date      = dto.Date,
        Sender    = dto.Sender,
        Recipient = dto.Recipient
    };

    if (file is { Length: > 0 })
    {
        var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
        Directory.CreateDirectory(uploads);
        var ext = Path.GetExtension(file.FileName);
        var unique = $"{Guid.NewGuid():N}{ext}";
        using var fs = System.IO.File.Create(Path.Combine(uploads, unique));
        await file.CopyToAsync(fs);
        t.Attachment = $"uploads/{unique}";
    }

    _context.Transmittals.Add(t);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetById), new { id = t.Id }, t);
}

// UPDATE
[HttpPut("{id:int}")]
[RequestSizeLimit(100_000_000)]
public async Task<IActionResult> Update(int id, [FromForm] Transmittal dto, IFormFile? file) // <-- [FromForm]
{
    if (id != dto.Id) return BadRequest("ID mismatch");
    var t = await _context.Transmittals.FindAsync(id);
    if (t == null) return NotFound();

    if (string.IsNullOrWhiteSpace(dto.TransNo))
        return BadRequest("TransNo is required.");

    t.TransNo   = dto.TransNo;           // <-- set TransNo
    t.JobNumber = dto.JobNumber;
    t.Title     = dto.Title;
    t.Date      = dto.Date;
    t.Sender    = dto.Sender;
    t.Recipient = dto.Recipient;

    if (file is { Length: > 0 })
    {
        var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
        Directory.CreateDirectory(uploads);

        if (!string.IsNullOrWhiteSpace(t.Attachment))
        {
            var old = Path.Combine(uploads, Path.GetFileName(t.Attachment));
            if (System.IO.File.Exists(old)) System.IO.File.Delete(old);
        }

        var ext = Path.GetExtension(file.FileName);
        var newName = $"{id}_{DateTimeOffset.UtcNow.Ticks}{ext}";
        using var fs = System.IO.File.Create(Path.Combine(uploads, newName));
        await file.CopyToAsync(fs);
        t.Attachment = $"uploads/{newName}";
    }

    await _context.SaveChangesAsync();
    return Ok(t);
}

        // 🔴 DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _context.Transmittals.FindAsync(id);
            if (t == null) return NotFound();

            // optional: bersihkan file di disk
            if (!string.IsNullOrWhiteSpace(t.Attachment))
            {
                var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
                var oldPath = Path.Combine(uploads, Path.GetFileName(t.Attachment));
                if (System.IO.File.Exists(oldPath))
                    System.IO.File.Delete(oldPath);
            }

            _context.Transmittals.Remove(t);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted successfully" });
        }
    }
}

namespace TransmittalTrackerAPI.Models
{
    public class Transmittal
    {
        public int Id { get; set; }
        public string TransNo { get; set; } = default!;
        public string JobNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Sender { get; set; } = default!;
        public string Recipient { get; set; } = default!;
        public string? Attachment { get; set; }   // ⬅️ kolom baru
    }
}
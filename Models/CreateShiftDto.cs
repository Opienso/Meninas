namespace Meninas.Models
{
    public class CreateShiftDto
    {
        public DateTime? Date { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int SitterId { get; set; }
    }
}

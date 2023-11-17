using System.ComponentModel.DataAnnotations.Schema;

namespace Meninas.Entities
{
    public class Shift
    {
        public DateTime? Date { get; set; }
        public string Place { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("ClientId")]  //Esta llave es la llave que indica la relacion que hicimos
        public Client Client { get; set; } // Es un client de tipo client jeje
        public int ClientId { get; set; }

        [ForeignKey("SitterId")]
        public int SitterId { get; set; }
    }
}

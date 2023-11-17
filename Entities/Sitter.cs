namespace Meninas.Entities
{
    public class Sitter : User
    {
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }
}

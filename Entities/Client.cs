namespace Meninas.Entities
{
    public class Client : User
    {
        public List<Cat> Cats { get; set; }
        public DateTime? AssignedShift { get; set; }
    }
}

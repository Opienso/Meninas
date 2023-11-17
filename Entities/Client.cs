namespace Meninas.Entities
{
    public class Client : User
    {
       // public ICollection<Cat> Cats { get; set; } = new List<Cat>();   //Un obj cliente tiene varios gatos
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>(); //
    }
}

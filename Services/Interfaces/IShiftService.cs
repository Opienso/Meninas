using Meninas.Entities;

namespace Meninas.Services.Interfaces
{
    public interface IShiftService
    {
        public int CreateShift(Shift shift);
        bool AssignShiftToClient(int shiftId, int clientId);
    }
}

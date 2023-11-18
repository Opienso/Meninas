using Meninas.Context;
using Meninas.Entities;
using Meninas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meninas.Services.Implementations
{
    public class ShiftService : IShiftService {

        private readonly MeninasContext _context;
        public ShiftService(MeninasContext context) { 
         _context = context;
        }

        public int CreateShift(Shift shift) {
            _context.Add(shift);
            _context.SaveChanges();
            return shift.Id;
        }

    }
}

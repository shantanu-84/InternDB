using InternDB.Data;
using Microsoft.EntityFrameworkCore;

namespace InternDB.Services
{
    public class AttendanceService
    {
        private readonly InternDbContext _context;

        public AttendanceService(InternDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAllAttendanceAsync()
        {
            return await _context.Attendances
                .Include(a => a.Intern)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendanceByInternIdAsync(int internId)
        {
            return await _context.Attendances
                .Include(a => a.Intern)
                .Where(a => a.InternId == internId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Intern)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Attendance?> GetAttendanceByDateAsync(int internId, DateTime date)
        {
            return await _context.Attendances
                .Include(a => a.Intern)
                .FirstOrDefaultAsync(a => a.InternId == internId && a.Date.Date == date.Date);
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            attendance.CreatedAt = DateTime.UtcNow;
            attendance.UpdatedAt = DateTime.UtcNow;
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            attendance.UpdatedAt = DateTime.UtcNow;
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Attendance>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Attendances
                .Include(a => a.Intern)
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetAttendanceSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var attendances = await _context.Attendances
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .ToListAsync();

            return new Dictionary<string, int>
            {
                ["Present"] = attendances.Count(a => a.Status == AttendanceStatus.Present),
                ["Absent"] = attendances.Count(a => a.Status == AttendanceStatus.Absent),
                ["Late"] = attendances.Count(a => a.Status == AttendanceStatus.Late),
                ["HalfDay"] = attendances.Count(a => a.Status == AttendanceStatus.HalfDay)
            };
        }
    }
}

using InternDB.Data;
using Microsoft.EntityFrameworkCore;

namespace InternDB.Services;

public class InternService
{
    private readonly InternDbContext _context;
    
    public InternService(InternDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Intern>> GetAllInternsAsync()
    {
        return await _context.Interns
            .OrderBy(i => i.LastName)
            .ThenBy(i => i.FirstName)
            .ToListAsync();
    }
    
    public async Task<Intern?> GetInternByIdAsync(int id)
    {
        return await _context.Interns.FindAsync(id);
    }
    
    public async Task<Intern> CreateInternAsync(Intern intern)
    {
        intern.CreatedAt = DateTime.UtcNow;
        intern.UpdatedAt = DateTime.UtcNow;
        
        _context.Interns.Add(intern);
        await _context.SaveChangesAsync();
        
        return intern;
    }
    
    public async Task<Intern?> UpdateInternAsync(Intern intern)
    {
        var existingIntern = await _context.Interns.FindAsync(intern.Id);
        if (existingIntern == null)
            return null;
            
        existingIntern.FirstName = intern.FirstName;
        existingIntern.LastName = intern.LastName;
        existingIntern.Email = intern.Email;
        existingIntern.PhoneNumber = intern.PhoneNumber;
        existingIntern.Department = intern.Department;
        existingIntern.Position = intern.Position;
        existingIntern.StartDate = intern.StartDate;
        existingIntern.EndDate = intern.EndDate;
        existingIntern.Notes = intern.Notes;
        existingIntern.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        
        return existingIntern;
    }
    
    public async Task<bool> DeleteInternAsync(int id)
    {
        var intern = await _context.Interns.FindAsync(id);
        if (intern == null)
            return false;
            
        _context.Interns.Remove(intern);
        await _context.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<List<Intern>> SearchInternsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllInternsAsync();
            
        return await _context.Interns
            .Where(i => i.FirstName.Contains(searchTerm) || 
                       i.LastName.Contains(searchTerm) || 
                       i.Email.Contains(searchTerm) ||
                       i.Department.Contains(searchTerm) ||
                       i.Position.Contains(searchTerm))
            .OrderBy(i => i.LastName)
            .ThenBy(i => i.FirstName)
            .ToListAsync();
    }
}

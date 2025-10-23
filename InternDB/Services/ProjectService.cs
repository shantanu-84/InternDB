using InternDB.Data;
using Microsoft.EntityFrameworkCore;

namespace InternDB.Services
{
    public class ProjectService
    {
        private readonly InternDbContext _context;

        public ProjectService(InternDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(t => t.Intern)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Project>> GetProjectsByInternIdAsync(int internId)
        {
            return await _context.Projects
                .Include(t => t.Intern)
                .Where(t => t.InternId == internId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .Include(t => t.Intern)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            project.CreatedAt = DateTime.UtcNow;
            project.UpdatedAt = DateTime.UtcNow;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            project.UpdatedAt = DateTime.UtcNow;
            if (project.Status == ProjectStatus.Completed && project.CompletedAt == null)
            {
                project.CompletedAt = DateTime.UtcNow;
            }
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetProjectsByStatusAsync(ProjectStatus status)
        {
            return await _context.Projects
                .Include(t => t.Intern)
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}

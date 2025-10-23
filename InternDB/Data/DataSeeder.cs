using InternDB.Data;
using Microsoft.EntityFrameworkCore;

namespace InternDB.Data;

public static class DataSeeder
{
    public static async Task SeedDataAsync(InternDbContext context)
    {
        // Check if data already exists
        if (await context.Interns.AnyAsync())
            return;

        var sampleInterns = new List<Intern>
        {
            new Intern
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890",
                Department = "IT",
                Position = "Software Developer Intern",
                StartDate = DateTime.Now.AddDays(-30),
                Notes = "Excellent performance in web development",
                CreatedAt = DateTime.Now.AddDays(-30),
                UpdatedAt = DateTime.Now.AddDays(-30)
            },
            new Intern
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "123-456-7891",
                Department = "CRC",
                Position = "Research Intern",
                StartDate = DateTime.Now.AddDays(-25),
                Notes = "Strong analytical skills",
                CreatedAt = DateTime.Now.AddDays(-25),
                UpdatedAt = DateTime.Now.AddDays(-25)
            },
            new Intern
            {
                FirstName = "Mike",
                LastName = "Johnson",
                Email = "mike.johnson@example.com",
                PhoneNumber = "123-456-7892",
                Department = "Biomedical",
                Position = "Lab Assistant Intern",
                StartDate = DateTime.Now.AddDays(-20),
                Notes = "Interested in medical research",
                CreatedAt = DateTime.Now.AddDays(-20),
                UpdatedAt = DateTime.Now.AddDays(-20)
            },
            new Intern
            {
                FirstName = "Sarah",
                LastName = "Wilson",
                Email = "sarah.wilson@example.com",
                PhoneNumber = "123-456-7893",
                Department = "HR",
                Position = "HR Assistant Intern",
                StartDate = DateTime.Now.AddDays(-15),
                Notes = "Great communication skills",
                CreatedAt = DateTime.Now.AddDays(-15),
                UpdatedAt = DateTime.Now.AddDays(-15)
            },
            new Intern
            {
                FirstName = "David",
                LastName = "Brown",
                Email = "david.brown@example.com",
                PhoneNumber = "123-456-7894",
                Department = "Quality",
                Position = "Quality Assurance Intern",
                StartDate = DateTime.Now.AddDays(-10),
                Notes = "Detail-oriented and thorough",
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-10)
            },
            new Intern
            {
                FirstName = "Emily",
                LastName = "Davis",
                Email = "emily.davis@example.com",
                PhoneNumber = "123-456-7895",
                Department = "IT",
                Position = "Data Analyst Intern",
                StartDate = DateTime.Now.AddDays(-5),
                Notes = "Strong in data visualization",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            }
        };

        context.Interns.AddRange(sampleInterns);
        await context.SaveChangesAsync();
    }
}

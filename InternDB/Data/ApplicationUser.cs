using Microsoft.AspNetCore.Identity;

namespace InternDB.Data;

public class ApplicationUser : IdentityUser
{
    public string? DisplayName { get; set; }
}



using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioDT191G.Models;

namespace PortfolioDT191G.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<SkillModel> Skills { get; set; }
    public DbSet<FrameworkModel> Frameworks { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
}

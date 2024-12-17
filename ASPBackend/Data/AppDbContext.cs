using Microsoft.EntityFrameworkCore;
using ASPBackend.Entities;

namespace ASPBackend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<UserEntity> Users { get; set; } // Users table
}
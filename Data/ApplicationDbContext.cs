using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ManagementApp.Models;


namespace ManagementApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkOrder>()
                .HasMany(t => t.Images)
                .WithOne(i => i.WorkOrder)
                .HasForeignKey(i => i.WorkOrderId);

            builder.Entity<WorkOrder>()
                .HasMany(t => t.Documents)
                .WithOne(d => d.WorkOrder)
                .HasForeignKey(d => d.WorkOrderId);
        }
    }
}
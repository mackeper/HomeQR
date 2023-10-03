using HomeQR.Data.Targets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeQR.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<QrCode>? QrCodes { get; set; }

    public DbSet<QrCodeTarget>? QrCodeTargets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QrCodeTarget>()
            .HasDiscriminator<string>("Type")
            .HasValue<PdfTarget>(TargetType.Pdf.ToString())
            .HasValue<UrlTarget>(TargetType.Url.ToString());

        modelBuilder.Entity<QrCode>()
            .HasMany(q => q.Targets)
            .WithOne(qt => qt.QrCode)
            .HasForeignKey(qt => qt.QrCodeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Api.Models;

namespace VehicleQuotes.Api.Data;

public class VehicleQuotesContext : DbContext
{
    public VehicleQuotesContext(DbContextOptions<VehicleQuotesContext> options): base(options){}
    
    public DbSet<Make> Makes { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<ModelStyle> ModelStyles { get; set; }
    public DbSet<ModelStyleYear> ModelStyleYears { get; set; }
    public DbSet<QuoteRule> QuoteRules { get; set; }
    public DbSet<QuoteOverride> QuoteOverrides { get; set; }
    
    public DbSet<Quote> Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Our vehicle size and body type data isn’t meant to really
        // change much. In fact, we could even preload that data when
        // our application starts.
        modelBuilder.Entity<Size>().HasData(
            new Size { ID = 1, Name = "Subcompact" },
            new Size { ID = 2, Name = "Compact" },
            new Size { ID = 3, Name = "Mid Size" },
            new Size { ID = 5, Name = "Full Size" }
        );

        modelBuilder.Entity<BodyType>().HasData(
            new BodyType { ID = 1, Name = "Coupe" },
            new BodyType { ID = 2, Name = "Sedan" },
            new BodyType { ID = 3, Name = "Hatchback" },
            new BodyType { ID = 4, Name = "Wagon" },
            new BodyType { ID = 5, Name = "Convertible" },
            new BodyType { ID = 6, Name = "SUV" },
            new BodyType { ID = 7, Name = "Truck" },
            new BodyType { ID = 8, Name = "Mini Van" },
            new BodyType { ID = 9, Name = "Roadster" }
        );
    }
}
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
}
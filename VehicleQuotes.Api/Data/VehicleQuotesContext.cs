using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Api.Data;

public class VehicleQuotesContext : DbContext
{
    public VehicleQuotesContext(DbContextOptions<VehicleQuotesContext> options): base(options){}
}
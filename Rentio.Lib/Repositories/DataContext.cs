using Rentio.Models;
using Microsoft.EntityFrameworkCore;
    
namespace Rentio.Lib.Repositories;

public class DataContext :  DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {} 
    public DbSet<Car> Cars { get; set; }
}
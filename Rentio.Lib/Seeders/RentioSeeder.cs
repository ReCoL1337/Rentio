using Microsoft.EntityFrameworkCore;
using Rentio.Lib.Repositories;
using Rentio.Models;

namespace Rentio.Lib.Seeders;

public class RentioSeeder(DataContext context) : IRentioSeeder {
    public async Task Seed() {
        if (!context.Cars.Any()) {
            var cars = new List<Car> {
                new Car { Brand = "Toyota", Name = "Corolla"},
                new Car { Brand = "Toyota", Name = "Yaris"},
                new Car { Brand = "Mercedes", Name = "Benz"},
            };
            
            context.Cars.AddRange(cars);
            await context.SaveChangesAsync();
        }
    }
}
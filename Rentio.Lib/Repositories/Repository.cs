using Rentio.Models;
using Microsoft.EntityFrameworkCore;
    
namespace Rentio.Lib.Repositories;

public class Repository : IRepository {
    private readonly DataContext _context;

    public Repository(DataContext context) {
        _context = context;
    }

    public async Task<Car> GetCarAsync(int id) {
        return await _context.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Car>> GetAllCarsAsync() {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> AddCarAsync(Car car) {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task<Car> UpdateCarAsync(Car car) {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
        return car;
    }
}
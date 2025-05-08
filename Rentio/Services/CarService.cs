using Rentio.Lib.Repositories;
using Rentio.Models;

namespace Rentio.Services;

public class CarService {
    private IRepository _repository;

    public CarService(IRepository repository) {
        _repository = repository;
    }

    public async Task<List<Car>> GetAllAsync() {
        var result = await _repository.GetAllCarsAsync();
        return result;
    }

    public async Task<Car> GetAsync(int id) {
        var result = await _repository.GetCarAsync(id);
        return result;
    }

    public async Task<Car> Update(Car car) {
        var result = await _repository.UpdateCarAsync(car);
        return result;
    }

    public async Task<Car> Add(Car car) {
        var result = await _repository.AddCarAsync(car);
        return result;
    }
}
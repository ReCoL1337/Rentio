using Rentio.Models;
namespace Rentio.Lib.Repositories;

public interface IRepository {
    #region Car
    Task<Car> GetCarAsync(int id);
    Task<Car> AddCarAsync(Car car);
    Task<Car> UpdateCarAsync(Car user);
    Task<List<Car>> GetAllCarsAsync();
    #endregion
}
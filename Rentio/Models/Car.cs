namespace Rentio.Models;

public class Car {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal PricePerHour { get; set; }
    public int Stock { get; set; } = 0;
    public Category Category { get; set; } = default!;
}
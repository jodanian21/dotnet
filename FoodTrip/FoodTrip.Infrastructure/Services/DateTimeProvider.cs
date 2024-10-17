using FoodTrip.Application.Common.Interfaces.Services;

namespace FoodTrip.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
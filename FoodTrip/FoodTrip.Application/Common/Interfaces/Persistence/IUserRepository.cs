using FoodTrip.Domain.Entities;

namespace FoodTrip.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}
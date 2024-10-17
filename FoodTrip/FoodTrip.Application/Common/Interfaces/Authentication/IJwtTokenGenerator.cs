using FoodTrip.Domain.Entities;

namespace FoodTrip.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
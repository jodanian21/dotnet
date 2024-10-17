using FoodTrip.Domain.Entities;

namespace FoodTrip.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
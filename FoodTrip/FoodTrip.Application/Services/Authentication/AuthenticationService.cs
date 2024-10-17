using FoodTrip.Application.Common.Interfaces.Authentication;
using FoodTrip.Application.Common.Interfaces.Persistence;
using FoodTrip.Domain.Entities;

namespace FoodTrip.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Check user if exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid email password!");
        }

        // Validate password
        if (user.Password != password)
        {
            throw new Exception("Invalid email password!");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check user if exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User email already exists!");
        }

        // Create new user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
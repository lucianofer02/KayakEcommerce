using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using KayaksEcommerce.Application.Models.Requests;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KayaksEcommerce.Infrastructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;
        
        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        private User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _userRepository.GetUserByUserName(authenticationRequest.UserName);

            if (user == null) return null;

            // CREAR TIPO DE USUARIO ADMIN Y CLIENTE if (authenticationRequest.UserType == typeof(User).Name || authenticationRequest == typeof()

            return user;
        }

        public string Authenticate(AuthenticationRequest authenticationRequest)
        {
            var user = ValidateUser(authenticationRequest);

            if (user == null)
            {
                throw new NotAllowedException("User Authentication Failed");
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("name", user.Name)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            claimsForToken.Add(new Claim("password", user.Password)); //quiere usar la API por lo general lo que espera es que se estén usando estas keys.
            claimsForToken.Add(new Claim("role", authenticationRequest.UserType)); //Debería venir del usuario

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

        public class AuthenticationServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";

            public required string Issuer { get; set; }
            public required string Audience { get; set; }
            public required string SecretForKey { get; set; }
        }
    }
}

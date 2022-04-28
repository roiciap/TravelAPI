using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IAccountService
    {
        public bool RegisterUser(RegisterKlientDto newUser);
        string LoginUser(LoginDto user);
    }
    public class AccountService : IAccountService
    {
        private readonly DataBase _db;
        private readonly IPasswordHasher<Klient> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(DataBase db,IPasswordHasher<Klient> passwordHasher,AuthenticationSettings authenticationSettings)
        {
            _db = db;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }


        public string LoginUser(LoginDto dto)
        {
            var user=_db.Klienci.Include(k=>k.Role).FirstOrDefault(u=>u.username == dto.username);
            if (user == null)
            {
                return null;
            }
            var result=_passwordHasher.VerifyHashedPassword(user,user.passwordHash,dto.password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.username}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires=DateTime.Now.AddDays(_authenticationSettings.JwtExpiteDays);
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public bool RegisterUser(RegisterKlientDto newUser)
        {
            var user = new Klient()
            {
                username = newUser.username,
                RoleId = newUser.roleId
            };
            var hashedPassword = _passwordHasher.HashPassword(user, newUser.password);
            user.passwordHash = hashedPassword;
            _db.Klienci.Add(user);
            _db.SaveChanges();
            return true;
        }
    }
}

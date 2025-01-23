using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Application.Interfaces;
using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> CreateUserAsync(UserDto createUserDto)
        {
            _logger.LogInformation("Creating new User: {@UserDto}", createUserDto);

            var user = _mapper.Map<User>(createUserDto);

            // Set CreatedAt and UpdatedAt to UTC
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            // Ensure BirthDate is in UTC
            if (user.BirthDate != DateTime.MinValue)
            {
                user.BirthDate = DateTime.SpecifyKind(user.BirthDate, DateTimeKind.Utc);
            }

            // Create password hash and salt
            var (hashedPassword, passwordSalt) = CreatePasswordHash(createUserDto.Password);
            user.Password = hashedPassword;
            user.PasswordSalt = passwordSalt;

            await _unitOfWork.Users.AddAsync(user);

            // Use a try-catch block to handle potential exceptions
            try
            {
                await _unitOfWork.CompleteAsync(user.Id.ToString(), "CreateUserAsync");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user");
                throw; // Re-throw the exception to be handled by the global exception handler
            }

            _logger.LogInformation("User created successfully: {@UserDto}", user);

            return _mapper.Map<UserDto>(user);
        }

        private (string hashedPassword, string passwordSalt) CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = Convert.ToBase64String(hmac.Key);
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashedPassword = Convert.ToBase64String(passwordHash);
                return (hashedPassword, passwordSalt);
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}

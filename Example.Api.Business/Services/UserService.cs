using Example.Api.Business.DTO;
using Example.Api.Business.Services.Interfaces;
using Example.Api.Common;
using Example.Api.Data.Models;
using Example.Api.Data.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Example.Api.Business.Services
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        private IConfiguration Config;
        private IUserRepository UserRepository;

        public UserService(IConfiguration config, IUserRepository userRepository)
            : base(userRepository)
        {
            this.Config = config;
            this.UserRepository = userRepository;
        }

        /// <summary>
        /// Authentifie l'utilisateur
        /// </summary>
        /// <param name="user">Utilisateur</param>
        public UserDto Login(LoginDto user)
        {
            string cryptedPassword = UserHelper.EncodeMD5(user.Password);
            User userEntity = this.UserRepository.GetByLoginAndPassword(user.Login, cryptedPassword);

            return this.EntityToDto(userEntity);
        }

        /// <summary>  
        /// Génère un token JWT
        /// </summary>  
        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this.Config["Jwt:Issuer"],
              this.Config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public override UserDto Add(UserDto user)
        {
            user.Password = UserHelper.EncodeMD5(user.Password);
            return base.Add(user);
        }

        public override UserDto Update(UserDto user)
        {
            user.Password = UserHelper.EncodeMD5(user.Password);
            return base.Update(user);
        }

        protected override User DtoToEntity(UserDto dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                Id = dto.Id,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
                Login = dto.Login,
                Mail = dto.Mail,
                Password = dto.Password,
                Role = dto.Role,
                LastConnection = dto.LastConnection
            };
        }

        protected override UserDto EntityToDto(User entity)
        {
            if (entity == null)
                return null;

            return new UserDto
            {
                Id = entity.Id,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                Login = entity.Login,
                Mail = entity.Mail,
                Password = entity.Password,
                Role = entity.Role,
                LastConnection = entity.LastConnection
            };
        }
    }
}

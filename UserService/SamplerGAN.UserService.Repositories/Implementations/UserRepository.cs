using System;
using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Repositories.Interfaces;

namespace SamplerGAN.UserService.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        // Endurhugsa þetta vinnsla á að vera í Service, hrá gögn úr data
        // DI
        private UserContext _db;
        public UserRepository(UserContext db)
        {
            _db = db;
        }
        
        public List<UserDto> GetAllUsers()
        {
            var entity = _db.user.Select(item => new UserDto {
                UserName = item.UserName,
                FirstName = item.FirstName,
                LastName = item.LastName
            }).ToList();

            return entity;
        }

        public UserDetailDto GetUserById(int id)
        {
            var entity = _db.user.FirstOrDefault(u => u.id == id);
            if (entity == null)
            {
                throw new ContentNotFoundException(string.Format("Unable to find user by id:" + id));
                //return null;
            }
            
            return new UserDetailDto
            {
                Id = entity.id,
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                UserCreated = entity.UserCreated
            };
        }
        public int CreateUser(UserInputModel body)
        {
            var nextId = _db.user.Count() + 1;
            _db.user.Add(new User
            {
                id = nextId,
                UserName = body.UserName,
                FirstName = body.FirstName,
                LastName = body.LastName,
                Email = body.Email
            });
            _db.SaveChanges();
            return nextId;
        }
        public void UpdateUserById(int id, UserInputModel body)
        {
            var entity = _db.user.FirstOrDefault(u => u.id == id);

            //Update prop of the user if provided
            if (!string.IsNullOrEmpty(body.UserName)) { entity.UserName = body.UserName; }
            if (!string.IsNullOrEmpty(body.FirstName)) { entity.FirstName = body.FirstName; }
            if (!string.IsNullOrEmpty(body.LastName)) { entity.LastName = body.LastName; }
            if (!string.IsNullOrEmpty(body.Email)) { entity.Email = body.Email; }
            if (!string.IsNullOrEmpty(body.Password)) { entity.password = body.Password; }
            
            _db.user.Update(entity);
            _db.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var entity = _db.user.First(u => u.id == id);
            _db.user.Remove(entity);
            _db.SaveChanges();
        }
        
        
    }
}
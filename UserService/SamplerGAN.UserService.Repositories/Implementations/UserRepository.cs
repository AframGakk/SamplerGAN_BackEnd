using System;
using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Repositories.Interfaces;

namespace SamplerGAN.UserService.Repositories.Implementations {
  public class UserRepository : IUserRepository {
    // DI
    private UserContext _db;
    public UserRepository (UserContext db) {
      _db = db;
    }

    public int GetIdByUsername (string username) {
      var entity = _db.user.FirstOrDefault (u => u.UserName == username);
      if (entity == null) {
        throw new ResourceNotFoundException ("No user with this username: " + username);
      }
      return entity.id;
    }

    public List<UserDto> GetAllUsers () {
      var entity = _db.user.Select (item => new UserDto {
        UserName = item.UserName,
          FirstName = item.FirstName,
          LastName = item.LastName
      }).ToList ();

      return entity;
    }

    public UserDetailDto GetUserById (int id) {
      var entity = _db.user.FirstOrDefault (u => u.id == id);
      if (entity == null) {
        throw new ResourceNotFoundException ("No user with this id: " + id);
      }

      return new UserDetailDto {
        Id = entity.id,
          UserName = entity.UserName,
          FirstName = entity.FirstName,
          LastName = entity.LastName,
          Email = entity.Email,
          UserCreated = entity.UserCreated
      };
    }
    public int CreateUser (UserInputModel body) {
      var newUser = new User {
        UserName = body.UserName,
        FirstName = body.FirstName,
        LastName = body.LastName,
        Email = body.Email,
        password = body.Password
      };
      _db.user.Add (newUser);
      _db.SaveChanges ();
      return newUser.id;
    }
    public void UpdateUserById (int id, UserInputModel body) {
      var entity = _db.user.FirstOrDefault (u => u.id == id);
      if (entity == null) {
        throw new ResourceNotFoundException ("No user with this id: " + id);
      }

      //Update prop of the user if provided
      if (!string.IsNullOrEmpty (body.UserName)) { entity.UserName = body.UserName; }
      if (!string.IsNullOrEmpty (body.FirstName)) { entity.FirstName = body.FirstName; }
      if (!string.IsNullOrEmpty (body.LastName)) { entity.LastName = body.LastName; }
      if (!string.IsNullOrEmpty (body.Email)) { entity.Email = body.Email; }
      if (!string.IsNullOrEmpty (body.Password)) { entity.password = body.Password; }

      _db.user.Update (entity);
      _db.SaveChanges ();
    }

    public void DeleteUserById (int id) {
      var entity = _db.user.FirstOrDefault (u => u.id == id);
      if (entity == null) {
        throw new ResourceNotFoundException ("No user with this id: " + id);
      }
      _db.user.Remove (entity);
      _db.SaveChanges ();
    }

  }
}
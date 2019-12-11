using System.Linq;
using SamplerGAN.AuthenticationService.WebApi.Models.Entities;

namespace SamplerGAN.AuthenticationService.WebApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        // DI
        private UserContext _db;
        public AuthRepository(UserContext db)
        {
            _db = db;
        }
        public int GetUserId(string username)
        {
            var entity = (from item in _db.user
                            // UserName is unquie
                            where(item.UserName == username)
                            select item.id).FirstOrDefault();
            return entity;
        }
        public string GetUserByNameAndPassword(User body)
        {
            var entity = (from item in _db.user
                            where(item.UserName == body.UserName && item.password == body.password)
                            select item.UserName).FirstOrDefault();
            return entity;
            
        }
    }
}
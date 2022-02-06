using MovieAppCore.DAL.Data;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Token based authentication
//1.JWT(JSON WEB TOKEN) token   2. OAUTH token
namespace MovieAppCore.DAL.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private MovieDbContext _movieDbContext;
        public UserInfoRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public UserInfo Login(UserInfo user)
        {
            UserInfo userInfo = null;
            var result = _movieDbContext.userInfo.Where(obj => obj.Email == user.Email && obj.Password == user.Password).ToList();
            if (result.Count > 0)
            {
                userInfo = result[0];
            }
            return userInfo;
        }

        public void Register(UserInfo userInfo)
        {
            _movieDbContext.userInfo.Add(userInfo);
            _movieDbContext.SaveChanges();
        }
    }
}

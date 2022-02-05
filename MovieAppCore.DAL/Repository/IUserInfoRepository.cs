using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAppCore.DAL.Repository
{
   public interface IUserInfoRepository
    {
        void Register(UserInfo userInfo);
        UserInfo Login(UserInfo user);
    }
}

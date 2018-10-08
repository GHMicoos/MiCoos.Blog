using AutoMapper;
using MiBlog.Abstraction.ViewModel;
using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.AutoMapper
{
    public class BlogProfile: Profile
    {
        public BlogProfile()
        {
            CreateMap<TUserInfo, RespQueryUserInfo>();
        }
    }
}

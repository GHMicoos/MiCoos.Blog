using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.AutoMapper
{
    public class BlogProfile: Profile
    {
        /// <summary>
        /// 以下都是自定绑定的
        /// string->Guid
        /// int->Enum
        /// int型->bool
        /// 不能自动绑定的
        /// long->Datetime
        /// </summary>
        public BlogProfile()
        {
            
            var map_TUserInfo_RespQueryUserInfoBase
                =CreateMap<TUserInfo, RespUserInfo>();
            map_TUserInfo_RespQueryUserInfoBase
                .ForMember(d => d.Birthday, opt => opt.MapFrom(s => s.Birthday.ConvertToDateTime()))
                .ForMember(d => d.RegistTime, opt => opt.MapFrom(s => s.RegistTime.ConvertToDateTime()));

            var map_Article_RestArticleInfo 
                = CreateMap<TArticle, RespArticleInfo>();
            map_Article_RestArticleInfo
                .ForMember(d => d.CreateTime, opt => opt.MapFrom(s => s.CreateTime.ConvertToDateTime()))
                .ForMember(d => d.PublistTime, opt => opt.MapFrom(s => s.PublistTime.HasValue?s.PublistTime.ConvertToDateTime():null));

            var map_Label_RespLabel 
                = CreateMap<TLabel, RespLabel>();
            map_Label_RespLabel
                .ForMember(d => d.CreateTime, opt => opt.MapFrom(s => s.CreateTime.ConvertToDateTime()));

            var map_Comment_RespComment
                = CreateMap<TComment, RespComment>();
            map_Comment_RespComment
                .ForMember(d => d.CreateTime, opt => opt.MapFrom(s => s.CreateTime.ConvertToDateTime()));


        }

        
    }
}

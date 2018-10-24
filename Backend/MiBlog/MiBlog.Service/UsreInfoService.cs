using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.User;
using MiBlog.EF.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Service
{
    public class UsreInfoService: BaseService,IUsreInfoService
    {
        private readonly IConfiguration _config;
        private readonly IUserInfoStore _store;
        private readonly IMapper _mapper;

        public UsreInfoService(IConfiguration config, IMapper mapper, IUserInfoStore store)
        {
            _config = config;
            _mapper = mapper;
            _store = store;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<RespUserInfo> QueryUserInfo(ReqQueryUserInfo param,out int count)
        {
            var result = default(IList<RespUserInfo>);
            count = 0;

            var query = _store.QueryUserInfo();
            if (param.UserId.IsNotEmptyGuid()) query = query.Where(x=>x.UserId==param.UserId.GuidToLowerString());
            if (!param.Name.IsNullOrWhiteSpace()) query = query.Where(x=>x.Name==param.Name);
            if (param.RegistTimeStart.HasValue) query = query.Where(x=>x.RegistTime>=param.RegistTimeStart.Value.ConvertToTimeStamp());
            if (param.RegistTimeEnd.HasValue) query = query.Where(x => x.RegistTime <= param.RegistTimeEnd.Value.ConvertToTimeStamp());

            count = query.Count();
            if (param.IsPage)query=query.Skip((param.PageIndex - 1) * param.PageSize).Take(param.PageSize);

            var data = query.ToList();
            result = new List<RespUserInfo>();
            for (int i = 0, ilen = data?.Count ?? 0; i < ilen; i++)
                result.Add(_mapper.Map<TUserInfo,RespUserInfo>(data[i]));

            return result;
        }

        /// <summary>
        /// 快速注册用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool RegistUser(ReqAddLoginInfo param)
        {

            var hasSameUserName=_store.QueryLoginInfo()
                .Any(x => x.UserName == param.UserName);
            if (hasSameUserName) throw new Exception($"用户名已经存在。{param.UserName}");


            var now = DateTime.Now;
            var addUserInfo = new TUserInfo()
            {
                UserId= Guid.NewGuid().ToString().ToLower(),
                Name=param.UserName,
                RegistTime= now.ConvertToTimeStamp(),
            };
            var addLoginInfo = new TLoginInfo()
            {
                LoginId = Guid.NewGuid().ToString().ToLower(),
                UserId=addUserInfo.UserId,
                UserName=param.UserName,
                Password=param.Password,
                State=0,
            };
            if (addUserInfo.TLoginInfo == null) addUserInfo.TLoginInfo=new List<TLoginInfo>();
            addUserInfo.TLoginInfo.Add(addLoginInfo);

            return _store.AddUserInfo(addUserInfo);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserInfo(ReqUpdateUserInfo param)
        {
            var old=_store.QueryUserInfo().FirstOrDefault(x => x.UserId == param.UserId.ToString().ToLower());
            if (old.IsNull()) throw new Exception($"没有找到指定的用户。{param.UserId}");

            if (!param.Name.IsNullOrWhiteSpace()) old.Name = param.Name;
            if (!param.ProfilePicture.IsNullOrWhiteSpace()) old.ProfilePicture = param.ProfilePicture;
            if (!param.Address.IsNullOrWhiteSpace()) old.Address = param.Address;
            if (param.Mobile.IsMobileNumber()) old.Name = param.Name;
            if (!param.Email.IsMail()) old.Email = param.Email;
            if (!param.Birthday.HasValue) old.Birthday = param.Birthday.Value.ConvertToTimeStamp();

            return _store.UpdateUserInfo(old);
        }
    }
}

using AutoMapper;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public IList<RespQueryUserInfo> QueryUserInfo(ReqQueryUserInfo param)
        {
            throw new NotImplementedException();
        }
    }
}

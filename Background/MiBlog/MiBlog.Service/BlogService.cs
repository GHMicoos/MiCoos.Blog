using AutoMapper;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel;
using MiBlog.EF.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Service
{
    public class BlogService : BaseService, IBlogService
    {
        private readonly IConfiguration _config;
        private readonly IBlogStore _store;
        private readonly IMapper _mapper;

        public BlogService(IConfiguration config, IMapper mapper,IBlogStore store)
        {
            _config = config;
            _mapper = mapper;
            _store = store;
        }

        public IList<RespQueryUserInfo> QueryUserInfo()
        {
            var data = _store.QueryUserInfo().ToList();
            var result = new List<RespQueryUserInfo>();
            for(int i=0,ilen=data.Count();i<ilen;i++)
            {
                var item = data[i];
                var add = _mapper.Map<TUserInfo, RespQueryUserInfo>(item);
                result.Add(add);
            }
            return result;
        }
        
    }
}

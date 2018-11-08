using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel.Category;
using MiBlog.EF.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly IConfiguration _config;
        private readonly ICategoryStore _store;
        private readonly IMapper _mapper;

        public CategoryService(IConfiguration config, IMapper mapper, ICategoryStore store)
        {
            _config = config;
            _mapper = mapper;
            _store = store;
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        public bool AddCategory(ReqAddCategory param)
        {
            if (param == null || param.Name.IsNullOrWhiteSpace())
                throw new Exception($"传入参数有误。");
            if (_store.QueryCategory().Any(x => x.Name == param.Name.Trim() && x.Creator == CommonTool.Lieling))
                throw new Exception($"{param.Name},该分类已经存在。");

            var now = DateTime.Now;

            var newCategory = new TCategory()
            {
                CategoryId = Guid.NewGuid().GuidToLowerString(),
                Name = param.Name.Trim(),
                IsDelete = 0,
                Creator = CommonTool.Lieling,
                CreateTime = now.ConvertToTimeStamp(),
            };

            return _store.AddCategory(newCategory);
        }
    }
}

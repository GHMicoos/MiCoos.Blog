using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel.Category;
using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// 删除分类 当分类没有文章关联
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool DeleteCategoryIfNoArticle(ReqAddCategory param)
        {
            if (param == null || param.Name.IsNullOrWhiteSpace())
                throw new Exception($"传入参数有误。");

            var category=_store.QueryCategory()
                .Include(x => x.TCategoryArticle)
                .FirstOrDefault(x => x.Name == param.Name);

            if (category == null) return true;
            if (category.TCategoryArticle?.Count() > 0)
                throw new Exception($"属于该分类下的文章有{category.TCategoryArticle?.Count()}篇，故无法删除该分类。");

            return _store.DeleteCategory(category);
        }

        /// <summary>
        /// 查询标签名称列表
        /// </summary>
        /// <returns></returns>
        public List<string> QueryCategory()
            => _store.QueryCategory()
                .Include(x => x.TCategoryArticle)
                .Where(x => x.Creator == CommonTool.Lieling)
                .OrderByDescending(x => x.TCategoryArticle == null ? 0 : x.TCategoryArticle.Count())
                .Select(x => x.Name)
                .ToList() ?? new List<string>();
    }
}

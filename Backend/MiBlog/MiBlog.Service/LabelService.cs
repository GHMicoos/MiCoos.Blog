using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel.Label;
using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Service
{
    public class LabelService:BaseService, ILabelService
    {
        private readonly IConfiguration _config;
        private readonly ILabelStore _store;
        private readonly IMapper _mapper;

        public LabelService(IConfiguration config, IMapper mapper, ILabelStore store)
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
        public bool AddLabel(ReqAddLabel param)
        {
            if (param == null || param.Name.IsNullOrWhiteSpace())
                throw new Exception($"传入参数有误。");
            if (_store.QueryLabel().Any(x => x.Name == param.Name.Trim() && x.Creator== CommonTool.Lieling))
                throw new Exception($"{param.Name},该标签已经存在。");

            var now = DateTime.Now;

            var newLabel = new TLabel()
            {
                LabelId=Guid.NewGuid().GuidToLowerString(),
                Name=param.Name.Trim(),
                IsDelete=0,
                Creator= CommonTool.Lieling,
                CreateTime= now.ConvertToTimeStamp(),
            };

            return _store.AddLabel(newLabel);
        }

        /// <summary>
        /// 删除标签，如果该标签无文章关联
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool DeleteLabelIfNoArticle(ReqAddLabel param)
        {
            if (param == null || param.Name.IsNullOrWhiteSpace())
                throw new Exception($"传入参数有误。");

            var category = _store.QueryLabel()
                .Include(x => x.TLabelArticle)
                .FirstOrDefault(x => x.Name == param.Name);

            if (category == null) return true;
            if (category.TLabelArticle?.Count() > 0)
                throw new Exception($"属于该标签下的文章有{category.TLabelArticle?.Count()}篇，故无法删除该标签。");

            return _store.DeleteLabel(category);
        }

        /// <summary>
        /// 查询标签名称列表
        /// </summary>
        /// <returns></returns>
        public List<string> QueryLabel()
            => _store.QueryLabel()
                .Include(x => x.TLabelArticle)
                .Where(x=>x.Creator==CommonTool.Lieling)
                .OrderByDescending(x => x.TLabelArticle == null ? 0 : x.TLabelArticle.Count())
                .Select(x => x.Name)
                .ToList() ?? new List<string>();
    }
}

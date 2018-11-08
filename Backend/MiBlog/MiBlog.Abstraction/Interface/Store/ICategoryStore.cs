﻿using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Abstraction.Interface.Store
{
    public interface ICategoryStore
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AddCategory(TCategory data);

        /// <summary>
        /// 查询分类
        /// </summary>
        /// <returns></returns>
        IQueryable<TCategory> QueryCategory();
    }
}
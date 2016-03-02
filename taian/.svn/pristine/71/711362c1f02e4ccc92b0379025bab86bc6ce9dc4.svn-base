using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFrameWork.Extensions
{
    public static class ProjectionsExtension
    {
        /// <summary>
        /// 项目的类型，使用DTO
        /// </summary>
        /// <typeparam name="TTarget">DTO映射</typeparam>
        /// <param name="source">实体源</param>
        /// <returns>>DTO映射</returns>
        public static TTarget ProjectedAs<TTarget>(this object source)
            where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }
        /// <summary>
        /// 项目转化集合
        /// </summary>
        /// <typeparam name="TSource">实体源</typeparam>
        /// <typeparam name="TTarget">DTO映射</typeparam>
        /// <param name="source">实体源集合</param>
        /// <returns>返回项目的集合</returns>
        public static IEnumerable<TTarget> ProjectedAs<TSource, TTarget>(this object source) where TTarget : class, new()
        {
            return Mapper.Map<IEnumerable<TTarget>>(source);
        }
        /// <summary>
        /// 转化分页对象
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget ProjectedAsDynamic<TTarget>(this object source) where TTarget : class, new()
        {
            return Mapper.DynamicMap<TTarget>(source);
        }
    }
}

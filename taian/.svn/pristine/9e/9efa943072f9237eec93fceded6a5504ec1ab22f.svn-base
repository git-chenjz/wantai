using DataAccess.Domain;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// 定位服务接口
    /// </summary>
    public interface ILBSService
    {
        #region 疫苗类型
        /// <summary>
        /// 编辑疫苗
        /// </summary>
        /// <param name="type"></param>
        void EditVaccineType(VaccineType type);
        /// <summary>
        /// 删除疫苗
        /// </summary>
        /// <param name="type"></param>
        void DeleteVaccineType(int id);
        /// <summary>
        /// 取出所有疫苗
        /// </summary>
        /// <param name="type"></param>
        IEnumerable<VaccineType> GetVaccineTypes();
        /// <summary>
        /// 取出单个疫苗数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VaccineType GetVaccineType(int id);
        #endregion

        #region LBS
        IEnumerable<LBS> GetAllLBS();
        PagedResult<LBS> GetPagedLBS(int page = 1);
        LBS GetLBS(int id);
        void EditLBS(LBS lbs, List<int> typeids);
        void DeleteLBS(int id);

        IEnumerable<string> GetProvinces(int? typeid);
        IEnumerable<string> GetCities(int? typeid,string province);
        IEnumerable<string> GetDistricts(int? typeid, string province, string city);

        IEnumerable<LBS> GetLBSByArea(int? typeid, string province, string city, string districts);
        #endregion
    }
}

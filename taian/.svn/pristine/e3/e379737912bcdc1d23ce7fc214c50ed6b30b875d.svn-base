using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Common;
using MyFrameWork.Data;
using MyFrameWork.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class LBSService : BaseService, ILBSService
    {
        #region 缓存
        private static IEnumerable<LBS> _lbs { get; set; }
        public static IEnumerable<LBS> LBS
        {
            get
            {
                if (_lbs == null)
                {
                    ReloadLBS();
                }

                return _lbs;
            }
        }
        public static void ReloadLBS()
        {
            var sv = ServiceLocator.Instance.Resolve<ILBSService>();

            _lbs = sv.GetAllLBS();
        }
        #endregion

        #region 字段
        private IVaccineTypeRepository _vaccineTypeRepository;
        private ILBSVaccineTypeRepository _lvRepository;
        private ILBSRepository _lbsRepository;
        #endregion

        #region 构造
        public LBSService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IVaccineTypeRepository vaccineTypeRepository,
            ILBSRepository lbsRepository,
            ILBSVaccineTypeRepository lvRepository
            )
            : base(mySqlUnitOfWork)
        {
            _vaccineTypeRepository = vaccineTypeRepository;
            _lbsRepository = lbsRepository;
            _lvRepository = lvRepository;
        }
        #endregion

        #region 疫苗类型
        /// <summary>
        /// 编辑疫苗
        /// </summary>
        /// <param name="type"></param>
        public void EditVaccineType(VaccineType type)
        {
            if (type.Id == 0)
            {
                type.CreateTime = DateTime.Now;
                _vaccineTypeRepository.Create(type);
            }
            else
            {
                var temp = _vaccineTypeRepository.Find(type.Id);
                if (temp != null)
                {
                    temp.Name = type.Name;
                    temp.ImgUrl = type.ImgUrl;
                }
            }

            _vaccineTypeRepository.Save();
        }
        /// <summary>
        /// 删除疫苗
        /// </summary>
        /// <param name="type"></param>
        public void DeleteVaccineType(int id)
        {
            var type = _vaccineTypeRepository.Find(id);
            if (type != null)
            {
                _vaccineTypeRepository.Delete(type);
                _vaccineTypeRepository.Save();
            }
        }
        /// <summary>
        /// 取出所有疫苗
        /// </summary>
        /// <param name="type"></param>
        public IEnumerable<VaccineType> GetVaccineTypes()
        {
            var types = _vaccineTypeRepository.Get();

            return types;
        }
        /// <summary>
        /// 取出单个疫苗数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VaccineType GetVaccineType(int id)
        {
            var type = _vaccineTypeRepository.Find(id);

            return type;
        }
        #endregion

        #region LBS
        public IEnumerable<LBS> GetAllLBS()
        {
            return _lbsRepository.Get("LBSVaccineTypes");
        }
        public PagedResult<LBS> GetPagedLBS(int page = 1)
        {
            return _lbsRepository.GetPaged(null, a => a.OrderBy(b => b.Province).ThenBy(b => b.City).ThenBy(b => b.District), "LBSVaccineTypes", page);
        }
        public LBS GetLBS(int id)
        {
            var lbs = _lbsRepository.Find(a=>a.Id.Equals(id));
            return lbs;
        }
        public void EditLBS(LBS lbs, List<int> typeids)
        {
            var types = _vaccineTypeRepository.Get(a => typeids.Contains(a.Id));
            if (lbs.Id == 0)
            {
                lbs.CreateTime = DateTime.Now;
                _lbsRepository.Create(lbs);

                _lbsRepository.Save();
                foreach (var x in types)
                {
                    _lvRepository.Create(new LBSVaccineType { LBSId = lbs.Id, VaccineTypeId = x.Id });
                }
                _lvRepository.Save();
            }
            else
            {
                var temp = _lbsRepository.Find(a => a.Id.Equals(lbs.Id));
                if (temp != null)
                {
                    lbs.CreateTime = temp.CreateTime;
                    _lbsRepository.Update(lbs);
                }
                _lbsRepository.Save();

                _lvRepository.Delete(a => a.LBSId.Equals(lbs.Id));
                _lvRepository.Save();

                foreach (var x in types)
                {
                    _lvRepository.Create(new LBSVaccineType { LBSId = lbs.Id, VaccineTypeId = x.Id });
                }
                _lvRepository.Save();
            }

            ReloadLBS();
        }
        public void DeleteLBS(int id)
        {
            var temp = _lbsRepository.Find(id);
            if (temp != null)
            {
                _lbsRepository.Delete(temp);
                _lbsRepository.Save();
            }
            ReloadLBS();
        }

        public IEnumerable<string> GetProvinces(int? typeid)
        {
            return LBS.Where(a=>typeid==null||a.LBSVaccineTypes.Any(b=>b.VaccineTypeId.Equals(typeid))).Select(a => a.Province).Distinct();
        }
        public IEnumerable<string> GetCities(int? typeid, string province)
        {
            return LBS.Where(a => typeid == null || a.LBSVaccineTypes.Any(b => b.VaccineTypeId.Equals(typeid)))
                .Where(a => a.Province.Equals(province))
                .Select(a => a.City).Distinct();
        }
        public IEnumerable<string> GetDistricts(int? typeid, string province, string city)
        {

            return LBS.Where(a => typeid == null || a.LBSVaccineTypes.Any(b => b.VaccineTypeId.Equals(typeid)))
                .Where(a => a.Province.Equals(province) && a.City.Equals(city))
                .Select(a => a.District).Distinct();
        }

        public IEnumerable<LBS> GetLBSByArea(int? typeid, string province, string city, string districts)
        {
            return LBS.Where(a => typeid == null || a.LBSVaccineTypes.Any(b => b.VaccineTypeId.Equals(typeid)))
                .Where(a => a.Province.Equals(province) && a.City.Equals(city) && a.District.Equals(districts));
        }
        #endregion
    }
}

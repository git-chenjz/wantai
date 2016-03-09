using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Common;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class InoculationService : BaseService, IInoculationService
    {
        #region 字段
        private IInoculationConfigRepository _configRepository;
        private IInoculationRecordRepository _recordRepository;
        #endregion

        #region 构造
        public InoculationService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IInoculationConfigRepository configRepository,
            IInoculationRecordRepository recordRepository
            )
            : base(mySqlUnitOfWork)
        {
            _configRepository = configRepository;
            _recordRepository = recordRepository;
        }
        #endregion

        #region 接种配置
        public IEnumerable<InoculationConfig> GetUserConfigs(string wechatUserID)
        {
            var configs = GetInoculationConfigs();
            var records = GetMyInoculationRecords(wechatUserID).Where(a => a.InoculationConfigID != null);

            return configs.Where(a => records.Any(b => (b.InoculationConfigID == a.ID && b.PhaseCode >= a.PhaseCode) || (b.InoculationConfig.VaccineTypeID == a.VaccineTypeID && b.Status == InoculationStatus.未接种)) == false);
        }
        public IEnumerable<InoculationConfig> GetInoculationConfigs()
        {
            return _configRepository.Get("VaccineType");
        }
        public InoculationConfig GetInoculationConfig(int id)
        {
            return _configRepository.Find(id);
        }
        public void EditInoculationConfig(InoculationConfig config)
        {
            if (config.ID == 0)
            {
                _configRepository.Create(config);
                _configRepository.Save();
            }
            else
            {
                _configRepository.Update(config);
                _configRepository.Save();
            }
        }
        public void DeleteInoculationConfig(int id)
        {
            _configRepository.Delete(a => a.ID == id);
            _configRepository.Save();
        }
        #endregion

        #region 接种记录
        public IEnumerable<InoculationRecord> GetMyInoculationRecords(string wechatUserID)
        {
            return _recordRepository.Get(a => a.WechatUserID == wechatUserID, "InoculationConfig");
        }
        public PagedResult<InoculationRecord> GetInoculationRecords(int page = 0, InoculationStatus? status = null)
        {
            return _recordRepository.GetPaged(a => status == null || a.Status == status, a => a.OrderByDescending(b => b.InoculabilityTime), page);
        }
        public void CreateInoculationRecord(InoculationRecord record, string wechatUserID)
        {
            var temp = new InoculationRecord
            {
                WechatUserID = wechatUserID,
                Status = record.Status,
                MyDescription = record.MyDescription,
                InoculabilityTime = record.InoculabilityTime
            };

            if (record.Status == InoculationStatus.已接种)
            {
                temp.ActualInoculabilityTime = (record.ActualInoculabilityTime ?? record.InoculabilityTime);
            }

            _recordRepository.Create(temp);

            if (record.InoculationConfigID == null)
            {
                if (string.IsNullOrWhiteSpace(record.PhaseName) == false)
                {
                    temp.PhaseName = record.PhaseName;
                    _recordRepository.Save();
                }
            }
            else
            {
                var config = _configRepository.Find(record.InoculationConfigID);
                //如果有配置过,且最近一个为未接种,那么就不能创建 
                var tempRecords = _recordRepository.Get(a => a.WechatUserID == wechatUserID && a.InoculationConfigID == record.InoculationConfigID);
                if (tempRecords.Any(a => a.PhaseCode >= config.PhaseCode || a.Status == InoculationStatus.未接种))
                    return;

                if (config != null)
                {
                    temp.CycleDay = config.CycleDay;
                    temp.InoculationConfigID = config.ID;
                    temp.InoculationDescription = config.Description;
                    temp.PhaseCode = config.PhaseCode;
                    temp.PhaseName = config.PhaseName;

                    CreateNextInoculationRecord(temp);

                    _recordRepository.Save();
                }
            }
        }
        public void EditInoculationRecord(InoculationRecord record, string wechatUserID)
        {
            var temp = _recordRepository.Find(a => a.ID == record.ID&& a.WechatUserID == wechatUserID);
            if (temp != null)
            {
                if ((temp.InoculationConfigID != null && temp.Status == InoculationStatus.未接种) || temp.InoculationConfigID == null)
                {
                    temp.InoculabilityTime = record.InoculabilityTime;
                    temp.ActualInoculabilityTime = null;
                    if (record.Status == InoculationStatus.已接种)
                    {
                        if (record.ActualInoculabilityTime == null)
                            temp.ActualInoculabilityTime = temp.InoculabilityTime;
                        else
                            temp.ActualInoculabilityTime = record.ActualInoculabilityTime;
                    }
                    temp.Status = record.Status;
                    temp.MyDescription = record.MyDescription;

                    CreateNextInoculationRecord(temp);

                    _recordRepository.Update(temp);
                    _recordRepository.Save();
                }
            }
        }
        public void DeleteInoculationRecord(int id, string wechatUserID)
        {
            _recordRepository.Delete(a => a.ID == id && a.WechatUserID == wechatUserID);
            _recordRepository.Save();
        }
        public void CreateNextInoculationRecord(InoculationRecord record)
        {
            if(record.Status==InoculationStatus.已接种)
            {
                var config = _configRepository.Get(a => a.VaccineTypeID == record.InoculationConfig.VaccineTypeID && a.PhaseCode > record.PhaseCode).OrderBy(a => a.PhaseCode).FirstOrDefault();
                if(config!=null)
                {
                    var temp = new InoculationRecord
                    {
                        WechatUserID = record.WechatUserID,
                        Status = InoculationStatus.未接种,
                        InoculabilityTime = record.InoculabilityTime.AddDays(config.CycleDay),
                        CycleDay = config.CycleDay,
                        InoculationConfigID = config.ID,
                        InoculationDescription = config.Description,
                        PhaseCode = config.PhaseCode,
                        PhaseName = config.PhaseName
                    };

                    _recordRepository.Create(temp);
                }
            }
        }
        #endregion
    }
}

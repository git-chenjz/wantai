using DataAccess.Domain;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IInoculationService
    {
        IEnumerable<InoculationConfig> GetUserConfigs(string wechatUserID);
        IEnumerable<InoculationConfig> GetInoculationConfigs();
        InoculationConfig GetInoculationConfig(int id);
        void EditInoculationConfig(InoculationConfig config);
        void DeleteInoculationConfig(int id);

        IEnumerable<InoculationRecord> GetMyInoculationRecords(string wechatUserID);
        PagedResult<InoculationRecord> GetInoculationRecords(int page = 0, InoculationStatus? status=null);
        void CreateInoculationRecord(InoculationRecord record, string wechatUserID);
        void EditInoculationRecord(InoculationRecord record, string wechatUserID);
        void DeleteInoculationRecord(int id, string wechatUserID);
    }
}

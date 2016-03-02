using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IADService : IBaseService
    {
        IEnumerable<AD> GetADs();
        IEnumerable<AD> GetValidADs();
        AD GetAD(int id);
        void SaveAD(AD ad);
        void DeleteAD(int id);
    }
}

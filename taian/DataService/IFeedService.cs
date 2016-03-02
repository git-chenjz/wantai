using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IFeedService
    {
        IEnumerable<InnovateFeed> GetInnovateFeeds(InnovateFeedType? type = null, ActiveStatus? status = null);
        InnovateFeed GetInnovateFeed(int id,bool isView=false);
        void EditInnovateFeed(InnovateFeed feed);
        void DeleteInnovateFeed(int id);
    }
}

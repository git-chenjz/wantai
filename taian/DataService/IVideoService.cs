using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IVideoService
    {
        IEnumerable<Video> GetVideos();
        Video GetVideo(int id);
        Video GetTopVideo();
        void DeleteVideo(int id);
        void SaveVideo(Video video);
    }
}

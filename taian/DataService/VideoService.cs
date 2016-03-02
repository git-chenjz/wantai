using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class VideoService : BaseService, IVideoService
    {
        #region 字段
        private IVideoRepository _videoRepository;
        #endregion

        #region 构造
        public VideoService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IVideoRepository videoRepository
            )
            : base(mySqlUnitOfWork)
        {
            _videoRepository = videoRepository;
        }
        #endregion

        #region 视频
        public IEnumerable<Video> GetVideos()
        {
            var videos = _videoRepository.Get();

            return videos;
        }
        public Video GetVideo(int id)
        {
            var video = _videoRepository.Find(id);

            return video;
        }

        public Video GetTopVideo()
        {
            var video = _videoRepository.Get(c=>c.IsTop == 0).FirstOrDefault();
            return video;
        }

        public void DeleteVideo(int id)
        {
            _videoRepository.Delete(a=>a.Id.Equals(id));

            _videoRepository.Save();
        }
        public void SaveVideo(Video video)
        {
            if (video.Id == 0)
            {
                video.ViewNum = 0;
                video.CreateTime = DateTime.Now;
                _videoRepository.Create(video);
            }
            else
            {
                var temp = _videoRepository.Find(video.Id);
                if(temp!=null)
                {
                    temp.Content = video.Content;
                    temp.Des = video.Des;
                    temp.IsTop = video.IsTop;
                    temp.VideoPath = video.VideoPath;
                }
            }

            _videoRepository.Save();
        }
        #endregion
    }
}

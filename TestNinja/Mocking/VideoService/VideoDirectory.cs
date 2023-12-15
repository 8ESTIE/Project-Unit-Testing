using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoDirectory
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoDirectory : IVideoDirectory
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            IEnumerable<Video> videos;
            using (var context = new VideoContext())
            {
                videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }
        }
    }
}
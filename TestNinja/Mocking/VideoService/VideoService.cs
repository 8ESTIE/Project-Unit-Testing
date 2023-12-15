using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        IFileReader FileReader { get; set; }
        IVideoDirectory VideoDirectory { get; set; }

        public VideoService(IFileReader fileReader = null, IVideoDirectory videoDirectory = null)
        {
            FileReader = fileReader ?? new FileReader();
            VideoDirectory = videoDirectory ?? new VideoDirectory();
        }

        public string ReadVideoTitle()
        {
            var str = FileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            IEnumerable<Video> videos = VideoDirectory.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
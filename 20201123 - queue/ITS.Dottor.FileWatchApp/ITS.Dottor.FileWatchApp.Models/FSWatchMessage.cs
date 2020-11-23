namespace ITS.Dottor.FileWatchApp.Models
{
    using System.IO;

    public class FSWatchMessage
    {

        public string Name { get; set; }
        public WatcherChangeTypes ChangeType { get; set; }
        public string FullPath { get; set; }


        public string OldFullPath { get; set; }
        public string OldName { get; set; }

    }
}

namespace ITS.Dottor.FileWatchApp.Web.Models
{
    using Microsoft.Azure.Cosmos.Table;

    public class FileSystemEntity : TableEntity
    {
        public FileSystemEntity()
        {
            PartitionKey = "ITS";
        }

        public FileSystemEntity(string name)
        {
            PartitionKey = "ITS";
            RowKey = name;
        }

        public string FullPath { get; set; }

        public string Name
        {
            get { return RowKey; }
            set { RowKey = value; }
        }


    }
}

using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Story : TableEntity
    {
        public Story() { }
        public Story(string id, string partition)
        {
            RowKey = id;
            PartitionKey = partition;
        }

        public string Title { get; set; }
        public string Body { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }


    }
}

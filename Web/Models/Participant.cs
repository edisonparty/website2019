using System;

using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using Newtonsoft.Json;

namespace Web.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Participant : TableEntity
    {

        public Participant() { }
        public Participant(string id, string partition)
        {
            RowKey = id;
            PartitionKey = partition;
        }
        [JsonProperty]
        public string Email { get; set; }
        [JsonProperty]
        public string Handle { get; set; }

        [JsonProperty]
        public string Group { get; set; }
        [JsonProperty]
        public bool IsOrga { get; set; }
        [JsonProperty]
        public DateTime Registered { get; set; }
        [JsonProperty]
        public DateTime? ReservationCanceled { get; set; }
    }
}
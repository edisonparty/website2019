using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
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
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty]
        [Required]
        public string Handle { get; set; }

        [JsonProperty]
        public string Group { get; set; }

        [JsonProperty]
        public string Country { get; set; }

        // [JsonProperty]
        public bool IsOrga { get; set; }

        // [JsonProperty]
        public DateTime Registered { get; set; }

        // [JsonProperty]
        public DateTime? ReservationCanceled { get; set; }
    }
}
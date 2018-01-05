using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {

        CloudStorageAccount account { get; set; }
        CloudTableClient tableClient { get; set; }
        CloudTable participantTable { get; set; }

        public ParticipantRepository(CloudStorageAccount storageAccount)
        {
            account = storageAccount;
            tableClient = account.CreateCloudTableClient();

            participantTable = tableClient.GetTableReference("Participants");
            participantTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        }


        public void AddParticipant(Participant participant) {
            participantTable.ExecuteAsync(TableOperation.Insert(participant)).GetAwaiter().GetResult();
        }

        public IEnumerable<Participant> GetParticipants(string partitionKey)
        {
            var query = new TableQuery<Participant>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));            
            var participants = ExecuteQueryAsync(participantTable, query).GetAwaiter().GetResult();
            return participants;
        }

        public static async Task<IList<T>> ExecuteQueryAsync<T>(CloudTable table, TableQuery<T> query, CancellationToken ct = default(CancellationToken), Action<IList<T>> onProgress = null) where T : ITableEntity, new()
        {
            var items = new List<T>();
            TableContinuationToken token = null;

            do
            {

                TableQuerySegment<T> seg = await table.ExecuteQuerySegmentedAsync<T>(query, token);
                token = seg.ContinuationToken;
                items.AddRange(seg);
                if (onProgress != null) onProgress(items);

            } while (token != null && !ct.IsCancellationRequested);

            return items;
        }

    }
}

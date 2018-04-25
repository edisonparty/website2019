using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {

        private CloudStorageAccount Account { get; set; }
        private CloudTableClient TableClient { get; set; }
        private CloudTable ParticipantTable { get; set; }

        public ParticipantRepository(CloudStorageAccount storageAccount)
        {
            Account = storageAccount;
            TableClient = Account.CreateCloudTableClient();

            ParticipantTable = TableClient.GetTableReference("Participants");
            ParticipantTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        }

        public void AddParticipant(Participant participant) {
            ParticipantTable.ExecuteAsync(TableOperation.Insert(participant)).GetAwaiter().GetResult();
        }

        public IEnumerable<Participant> GetParticipants(string partitionKey)
        {
            var query = new TableQuery<Participant>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));            
            var participants = ExecuteQueryAsync(ParticipantTable, query).GetAwaiter().GetResult();

            return participants;
        }

        private static async Task<IList<T>> ExecuteQueryAsync<T>(CloudTable table, TableQuery<T> query, CancellationToken ct = default(CancellationToken), Action<IList<T>> onProgress = null) where T : ITableEntity, new()
        {
            var items = new List<T>();
            TableContinuationToken token = null;

            do
            {
                TableQuerySegment<T> seg = await table.ExecuteQuerySegmentedAsync<T>(query, token);
                token = seg.ContinuationToken;
                items.AddRange(seg);
                onProgress?.Invoke(items);

            } while (token != null && !ct.IsCancellationRequested);

            return items;
        }
    }
}
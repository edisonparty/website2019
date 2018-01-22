using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repositories
{
    public class TalesFromTheSceneRepository : IStoryRepository
    {

        CloudStorageAccount account { get; set; }
        CloudTableClient tableClient { get; set; }
        CloudTable storyTable { get; set; }
        public TalesFromTheSceneRepository(CloudStorageAccount storageAccount)
        {
            account = storageAccount;
            tableClient = account.CreateCloudTableClient();

            storyTable = tableClient.GetTableReference("Stories");
            storyTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();

            var now = DateTime.UtcNow;
            var story = new Story("sample", "talesfromthescene")
            {
                Title = "Slipsum showdown",
                Body = @"
Your bones don't break, mine do. </br>
That's clear. </br>
Your cells react to bacteria and viruses differently than mine. </br>
*You don't get sick, I do.*</br>
That's also clear.</br>
But for some reason, you and I react the exact same way to water. </br>
We swallow it too fast, we choke. We get some in our lungs, we drown. </br>
However unreal it may seem, we are connected, you and I. </br>
We're on the same curve, just on opposite ends. ",
                CreateDate = now,
                ModifyDate = now
            };



            // Create the TableOperation object that inserts the entity.
            TableOperation insertOperation = TableOperation.InsertOrReplace(story);

            // Execute the operation.
            var executionResult = storyTable.ExecuteAsync(insertOperation).GetAwaiter().GetResult();

        }

        public async Task<List<Story>> GetStories()
        {
            // Initialize a default TableQuery to retrieve all the entities in the table.
            TableQuery<Story> tableQuery = new TableQuery<Story>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "talesfromthescene"));

            // Initialize the continuation token to null to start from the beginning of the table.
            TableContinuationToken continuationToken = null;

            List<Story> stories = new List<Story>();

            do
            {
                // Retrieve a segment (up to 1,000 entities).
                TableQuerySegment<Story> tableQueryResult = await storyTable.ExecuteQuerySegmentedAsync(tableQuery, continuationToken);

                // Assign the new continuation token to tell the service where to
                // continue on the next iteration (or null if it has reached the end).
                continuationToken = tableQueryResult.ContinuationToken;

                stories.AddRange(tableQueryResult.Results);
                // Loop until a null continuation token is received, indicating the end of the table.
            } while (continuationToken != null);


            return stories.OrderByDescending(s => s.CreateDate).ToList();
        }

        public async Task<Story> AddStory(Story story)
        {
            // Create the TableOperation object that inserts the entity.
            TableOperation insertOperation = TableOperation.Insert(story, true);

            // Execute the operation.
            var executionResult = await storyTable.ExecuteAsync(insertOperation);

            if (executionResult.Result is Story)
            {
                return executionResult.Result as Story;
            }

            //Todo, probably check return code and explode?
            return null;
        }
    }
}

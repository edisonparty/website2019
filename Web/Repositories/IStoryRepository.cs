using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repositories
{
    public interface IStoryRepository
    {
        Task<Story> AddStory(Story story);
        Task<List<Story>> GetStories();
    }
}
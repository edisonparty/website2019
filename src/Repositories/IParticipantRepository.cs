using System.Collections.Generic;
using Web.Models;

namespace Web.Repositories
{
    public interface IParticipantRepository
    {
        void AddParticipant(Participant participant);
        IEnumerable<Participant> GetParticipants(string partitionKey);
    }
}

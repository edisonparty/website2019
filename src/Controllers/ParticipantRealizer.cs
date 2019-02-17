using System;
using System.Collections.Generic;
using System.Linq;

using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
	public class ParticipantRealizer : IParticipantRealizer
	{
        private const string partitionKey = "edisonparty2019";
		private const string emailExists = "Email address already registered";

		public ParticipantRealizer()
		{
		}

		public Participant RealizeParticipant(Participant unreal, IParticipantRepository participantRepository)
		{
            if (participantRepository.GetParticipants(partitionKey).Any(p => p.Email == unreal.Email))
            {
				throw new System.InvalidOperationException(emailExists);
            }

            unreal.RowKey = Guid.NewGuid().ToString();
            unreal.PartitionKey = partitionKey;
            unreal.Registered = DateTime.UtcNow;

            participantRepository.AddParticipant(unreal);

			return unreal;
		}
	}
}


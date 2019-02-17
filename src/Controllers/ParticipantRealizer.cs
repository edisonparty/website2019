using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
	public class ParticipantRealizer : IParticipantRealizer
	{
        private const string partitionKey = "edisonparty2019";
		private const string invalidModelState = "Invalid model state";
		private const string emailExists = "Email address already registered";

		private IParticipantRepository participantRepository { get; }

		public ParticipantRealizer(IParticipantRepository participantRepository)
		{
			this.participantRepository = participantRepository;
		}

		public Participant RealizeParticipant(Participant unreal, ModelStateDictionary modelState)
		{
            if (!modelState.IsValid)
            {
				throw new System.InvalidOperationException(invalidModelState);
            }

            if (participantRepository.GetParticipants(partitionKey).Any(p => p.Email == unreal.Email))
            {
				modelState.AddModelError("Email", "This e-mail address already exists");
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


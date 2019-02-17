using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Models;

namespace Web.Controllers
{
	public interface IParticipantRealizer
	{
		Participant RealizeParticipant(Participant unreal, ModelStateDictionary modelState);
	}
}


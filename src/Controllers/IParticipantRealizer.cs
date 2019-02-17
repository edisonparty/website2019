using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
	public interface IParticipantRealizer
	{
		Participant RealizeParticipant(Participant unreal, IParticipantRepository participantRepository);
	}
}


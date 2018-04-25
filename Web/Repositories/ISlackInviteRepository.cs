using Web.Models;

namespace Web.Repositories
{
    public interface ISlackInviteRepository
    {
        ExternalSlackResponse Invite(SlackInviteRequest slackinviteRequest);
    }
}
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Web.Models;

namespace Web.Repositories
{
    public class SlackInviteRepository : ISlackInviteRepository
    {
        string SlackToken { get; set; }
        HttpClient Client { get; set; }

        public SlackInviteRepository(string slackToken)
        {
            SlackToken = slackToken;
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SlackToken);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

        }
        //https://github.com/ErikKalkoken/slackApiDoc/blob/master/users.admin.invite.md
        public ExternalSlackResponse Invite(SlackInviteRequest slackinviteRequest)
        {
            var inviteUri = new Uri($"https://edisonparty.slack.com/api/users.admin.invite?token={SlackToken}&email={slackinviteRequest.Email}");


            var inviteResult = Client.GetStringAsync(inviteUri).GetAwaiter().GetResult();

            try
            {
                var slackResponse = JsonConvert.DeserializeObject<ExternalSlackResponse>(inviteResult);
                return slackResponse;
            }
            catch (Exception)
            {
                return new ExternalSlackResponse()
                {
                    Ok = false,
                    Error = "Slack server side error."
                };
            }
        }
    }
}

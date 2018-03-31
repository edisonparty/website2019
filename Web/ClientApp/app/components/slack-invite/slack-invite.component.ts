import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';
import { SlackInviteResponse } from '../../../models/slackInviteResponse';

@Component({
    selector: 'slack-invite',
    templateUrl: './slack-invite.component.html',
    styleUrls: ['./slack-invite.component.css']
})
export class SlackInviteComponent {
    public response: SlackInviteResponse;
    public inviteSent: boolean = false;
    public participantEmail: string;
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    sendInvite() {

        this.inviteSent = true;
        if (this.participantEmail)
            this.http.post(this.baseUrl + 'api/slack/invite', { email: this.participantEmail }).subscribe(
                result => {
                    this.response = result.json() as SlackInviteResponse;
                }
                , error => {
                    this.inviteSent = false;

                    this.response = JSON.parse(error._body) as SlackInviteResponse;
                    console.warn(error)
                }
            );
    }
}

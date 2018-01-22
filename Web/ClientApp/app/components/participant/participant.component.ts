import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';
import { Participant } from '../../../models/participant';

@Component({
    selector: 'participant',
    templateUrl: './participant.component.html',
    styleUrls: ['./participant.component.css']
})
export class ParticipantComponent {

    private participants: Array<Participant> = [];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        http.get(baseUrl + 'api/participant').subscribe(result => { 
            this.participants = result.json() as Array<Participant>;
        }, error => console.error(error)); 
    }
   
}

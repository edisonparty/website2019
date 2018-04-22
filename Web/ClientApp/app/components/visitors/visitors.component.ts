import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';
import { Participant } from '../../../models/participant';

@Component({
    selector: 'visitors',
    templateUrl: './visitors.component.html',
    styleUrls: ['./visitors.component.css']
})
export class VisitorsComponent {

    public participants: Array<Participant> = [];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.updateParticipantList()
    }

    updateParticipantList() {
        this.http.get(this.baseUrl + 'api/participant').subscribe(result => {
            this.participants = result.json() as Array<Participant>;
        }, error => console.error(error)); 
    }
   
}

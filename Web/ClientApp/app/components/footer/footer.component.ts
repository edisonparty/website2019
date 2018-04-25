import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.css']
})
export class FooterComponent {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
      
    }
   
}

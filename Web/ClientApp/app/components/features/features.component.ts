import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'features',
    templateUrl: './features.component.html',
    styleUrls: ['./features.component.css']
})
export class FeaturesComponent {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
      
    }
   
}

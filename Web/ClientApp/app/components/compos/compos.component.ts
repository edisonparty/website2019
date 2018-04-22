import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'compos',
    templateUrl: './compos.component.html',
    styleUrls: ['./compos.component.css']
})
export class ComposComponent {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
      
    }
   
}

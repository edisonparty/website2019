import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'carousel',
    templateUrl: './carousel.component.html',
    styleUrls: ['./carousel.component.css']
})
export class CarouselComponent {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
      
    }
   
}

import { Component, AfterViewInit } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']

})
export class HomeComponent implements AfterViewInit {
    ngAfterViewInit(): void {
        window.dispatchEvent(new Event('ngRouteChange'));
    }

    constructor() {


    }
}

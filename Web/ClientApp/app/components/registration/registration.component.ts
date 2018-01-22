import { Component, Inject, } from '@angular/core';
import { Http } from '@angular/http';
import { Registration } from '../../../models/registration';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

    private registrant: Registration = { email: "", handle: "", group: "", country: "Sweden" }

    private submitted: boolean = false;
    private countries: Array<string> = [
        "Argentina", "Australia", "Austria", "Belarus", "Belgium", "Bosnia and Herzegovina", "Brazil", "Bulgaria", "Canada", "China",
        "Croatia", "Cyprus", "Czech Republic", "Denmark", "Egypt", "Estonia", "European Union (EU)", "Finland", "France", "Georgia", "Germany", "Greece", "Hungary", "Iceland",
        "India", "Ireland", "Israel", "Italy", "Japan", "Korea, Republic of", "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta", "Mexico", "Monaco",
        "Netherlands", "New Zealand", "Norway", "Poland", "Portugal", "Romania", "Russian Federation", "Slovakia", "Slovenia", "Spain", "Sweden", "Switzerland",
        "Turkey", "Ukraine", "United Kingdom", "United States"
    ];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    submit() {
        console.log(this.registrant);
        this.submitted = true;
        this.http.post(this.baseUrl + 'api/participant/register', this.registrant).subscribe(
            result => { console.log("registerd successfully") }
            , error => console.error(error)
        );
    }
}

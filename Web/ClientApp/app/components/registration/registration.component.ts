import { Component, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { Http } from '@angular/http';
import { Registration } from '../../../models/registration';
import { Participant } from '../../../models/participant';

@Component({
    selector: "registration",
    templateUrl: "./registration.component.html",
    styleUrls: ["./registration.component.css"]
})
export class RegistrationComponent {

    @Output()
    public RegistrationSuccess = new EventEmitter();

    public registrant: Registration = { email: "", handle: "", group: "", country: "Sweden" };
    public errors: string[] = [];
    public submitButtonDisabled: boolean = false;
    public registrationSuccessful: boolean = false;
    public countries: Array<string> = [
        "Argentina", "Australia", "Austria", "Belarus", "Belgium", "Bosnia and Herzegovina", "Brazil", "Bulgaria", "Canada", "China",
        "Croatia", "Cyprus", "Czech Republic", "Denmark", "Egypt", "Estonia", "European Union (EU)", "Finland", "France", "Georgia", "Germany", "Greece", "Hungary", "Iceland",
        "India", "Ireland", "Israel", "Italy", "Japan", "Korea, Republic of", "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta", "Mexico", "Monaco",
        "Netherlands", "New Zealand", "Norway", "Poland", "Portugal", "Romania", "Russian Federation", "Slovakia", "Slovenia", "Spain", "Sweden", "Switzerland",
        "Turkey", "Ukraine", "United Kingdom", "United States"
    ];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    submit() {
        this.errors = [];
        this.submitButtonDisabled = true;
        this.http.post(this.baseUrl + "api/participant/register", this.registrant).subscribe(
            // After receiving any result, enable the submit button again
            result => {
                this.submitButtonDisabled = false;
                this.registrationSuccessful = true;
                this.RegistrationSuccess.emit()
            },
            error => {
                this.submitButtonDisabled = false;

                if (error.status === 400) {
                    const dictionary = JSON.parse(error.text());
                    for (let fieldName in dictionary) {
                        if (dictionary.hasOwnProperty(fieldName)) {
                            this.errors.push(dictionary[fieldName]);
                        }
                    }
                } else {
                    this.errors.push("Something went wrong :(");
                }
            }
        );
    }
    
}

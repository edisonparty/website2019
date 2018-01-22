import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

import { Registration } from '../../../models/registration';
import { Story } from '../../../models/story';

@Component({
    selector: 'story-editor',
    templateUrl: './story-editor.component.html',
    styleUrls: ['./story-editor.component.css']
})
export class StoryEditorComponent implements OnInit {
    story: Story;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.story = { title: "", body: "", createdDate: new Date(), modifiedDate: new Date() };
    }

    publish() {
        // this.http.post(this.baseUrl + 'api/story', this.story).subscribe(
        //     result => {
        //         console.log("successfully posted story");
        //     }, error => console.error(error)
        // )
    }
}

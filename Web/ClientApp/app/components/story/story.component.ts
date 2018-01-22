import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

import { Registration } from '../../../models/registration';
import { Story } from '../../../models/story';

@Component({
    selector: 'story',
    templateUrl: './story.component.html',
    styleUrls: ['./story.component.css']
})
export class StoryComponent implements OnInit, OnDestroy {
    private sub: any;
    id: string;
    story: Story;
    stories: Array<Story>;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    }
    ngOnInit() {
        this.http.get(this.baseUrl + 'api/story').subscribe(
            result => {
                this.stories = result.json() as Array<Story>;
                if (this.id) {
                    this.story = this.stories.filter((s) => {
                        return s.title == this.id;
                    })[0];
                }
            }
            , error => console.error(error));
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

}

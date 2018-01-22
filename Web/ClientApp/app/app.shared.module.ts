import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ShowdownModule } from 'ngx-showdown';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { ParticipantComponent } from './components/participant/participant.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { StoryComponent } from './components/story/story.component';
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ParticipantComponent,
        RegistrationComponent,
        StoryComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ShowdownModule,
        RouterModule.forRoot([
            // { path: '', redirectTo: 'home', pathMatch: 'full' },

            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'participant', component: ParticipantComponent },
            { path: 'registration', component: RegistrationComponent },
            { path: 'stories', component: StoryComponent },
            { path: 'stories/:id', component: StoryComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

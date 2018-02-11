import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ShowdownModule } from 'ngx-showdown';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { VisitorsComponent } from './components/visitors/visitors.component';
import { FeaturesComponent } from './components/features/features.component';
import { FooterComponent } from './components/footer/footer.component';
import { SlackInviteComponent } from './components/slack-invite/slack-invite.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { StoryComponent } from './components/story/story.component';
import { StoryEditorComponent } from './components/story-editor/story-editor.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        VisitorsComponent,
        RegistrationComponent,
        StoryComponent,
        StoryEditorComponent,
        FeaturesComponent,
        FooterComponent,
        SlackInviteComponent
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
            { path: 'participant', component: VisitorsComponent },
            { path: 'registration', component: RegistrationComponent },
            { path: 'stories', component: StoryComponent },
            { path: 'stories/editor', component: StoryEditorComponent },
            
            { path: 'stories/:id', component: StoryComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

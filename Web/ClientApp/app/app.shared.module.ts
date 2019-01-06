import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { VisitorsComponent } from './components/visitors/visitors.component';
import { FooterComponent } from './components/footer/footer.component';
import { SlackInviteComponent } from './components/slack-invite/slack-invite.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { CarouselComponent } from './components/carousel/carousel.component';

import { TimetableComponent } from './components/timetable/timetable.component'
import { ComposComponent } from './components/compos/compos.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        VisitorsComponent,
        RegistrationComponent,
        FooterComponent,
        SlackInviteComponent,
        CarouselComponent,
        TimetableComponent,
        ComposComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'about#about', pathMatch: 'full' },
            { path: 'about', component: HomeComponent },
            { path: 'participants', component: VisitorsComponent },
            { path: 'compos', component: ComposComponent },
            { path: 'timetable', component: TimetableComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

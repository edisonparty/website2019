import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { VisitorsComponent } from './components/visitors/visitors.component';
import { FeaturesComponent } from './components/features/features.component';
import { FooterComponent } from './components/footer/footer.component';
import { SlackInviteComponent } from './components/slack-invite/slack-invite.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { CarouselComponent } from './components/carousel/carousel.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        VisitorsComponent,
        RegistrationComponent,
        FeaturesComponent,
        FooterComponent,
        SlackInviteComponent,
        CarouselComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'about', pathMatch: 'full' },
            { path: 'about', component: HomeComponent },
            { path: 'participants', component: VisitorsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { gamesComponent } from './games/games.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { skillsComponent } from './skills/skills.component';
import { userComponent } from './user/user.component';
import { LeaderboardComponent } from './user/leaderboard/leaderboard.component';
import { SettingComponent } from './user/setting/setting.component';
import { FocusComponent } from './skills/focus/focus.component';
import { MemoryComponent } from './skills/memory/memory.component';
import { ReflexComponent } from './skills/reflex/reflex.component';
import { StrategyComponent } from './skills/strategy/strategy.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    gamesComponent,
    skillsComponent,
    userComponent,
    LeaderboardComponent,
    SettingComponent,
    FocusComponent,
    MemoryComponent,
    ReflexComponent,
    StrategyComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'games', component: gamesComponent },
      { path: 'skills', component: skillsComponent },
      { path: 'user', component: userComponent, canActivate: [AuthorizeGuard] },
      { path: 'focus', component: FocusComponent},
      { path: 'memory', component: MemoryComponent },
      { path: 'reflex', component: ReflexComponent },
      { path: 'strategy', component: StrategyComponent },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

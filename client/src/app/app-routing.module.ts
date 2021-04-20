import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FindCaptainComponent } from './components/find-captain/find-captain.component';
import { FindCrewComponent } from './components/find-crew/find-crew.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { SettingsComponent } from './components/settings/settings.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'find-crew', component: FindCrewComponent, canActivate: [AuthGuard] },
      { path: 'find-captain', component: FindCaptainComponent, canActivate: [AuthGuard] },
      { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] }
    ]
  },
  { path: '**', component: HomeComponent, pathMatch: 'full'},
  { path: 'register', component: RegisterComponent }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SyncComponent } from './components/sync/sync.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './security/auth.guard';

const routes: Routes = [
  {path:'', redirectTo:'/home', pathMatch:'full'},
 // {path:'home', component: HomeComponent,  canActivate:[AuthGuard]},
  {path:'home', component: HomeComponent},
  {path:'login', component: LoginComponent},
 // {path:'sync',  component:  SyncComponent,  canActivate:[AuthGuard]}
  {path:'sync',  component:  SyncComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

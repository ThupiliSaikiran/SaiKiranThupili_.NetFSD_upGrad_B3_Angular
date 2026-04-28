import { Routes } from '@angular/router';
import { NContactListComponent } from './ncontact-list-component/ncontact-list-component';
import { NContactDetailsComponent } from './ncontact-details-component/ncontact-details-component';
import { NAddContactComponent } from './nadd-contact-component/nadd-contact-component';

export const routes: Routes = [
  {path:"contacts", component : NContactListComponent},
  {path: "contact/:id",component:NContactDetailsComponent},
  {path: "add-contact",component:NAddContactComponent}
];

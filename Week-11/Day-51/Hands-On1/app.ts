import { Component, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ContactListComponent } from './contact-list-component/contact-list-component';
import { ContactDetailComponent } from './contact-detail-component/contact-detail-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ContactListComponent,ContactDetailComponent,RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Contact');
}

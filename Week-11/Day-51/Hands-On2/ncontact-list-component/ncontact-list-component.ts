import { Component } from '@angular/core';
import { Contact } from '../Model/Contact';
import { ContactService } from '../contact-service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-ncontact-list-component',
  imports: [RouterLink],
  templateUrl: './ncontact-list-component.html',
  styleUrl: './ncontact-list-component.css',
})
export class NContactListComponent {
    public contactList:Contact[];
   
  
    constructor(private contactService:ContactService){
      this.contactList = this.contactService.getContacts();
    }
}

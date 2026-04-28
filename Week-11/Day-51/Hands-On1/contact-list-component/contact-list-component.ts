import { Component } from '@angular/core';
import { Contact } from '../Model/Contact';
import { ContactService } from '../contact-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list-component',
  imports: [FormsModule,CommonModule],
  templateUrl: './contact-list-component.html',
  styleUrl: './contact-list-component.css',
})
export class ContactListComponent {
  public contactList:Contact[];
 

  constructor(private contactService:ContactService){
    this.contactList = this.contactService.getContacts();
  }

   newContact:Contact = {
    id:0,
    name:'',
    email:'',
    phone:''
  }

  public addContact(){
    this.newContact.id = this.contactList.length +1

    this.contactService.addContact(this.newContact)
  }

 





}

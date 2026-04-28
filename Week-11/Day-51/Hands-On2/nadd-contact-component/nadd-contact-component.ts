import { Component } from '@angular/core';
import { ContactService } from '../contact-service';
import { Contact } from '../Model/Contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nadd-contact-component',
  imports: [FormsModule,CommonModule],
  templateUrl: './nadd-contact-component.html',
  styleUrl: './nadd-contact-component.css',
})
export class NAddContactComponent {
   public contactList:Contact[];
   
  
    constructor(private contactService:ContactService,private router:Router){
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

       this.goToContact();

      this.newContact = {
      id:0,
      name:'',
      email:'',
      phone:''
    }
    }

    goToContact() {
      this.router.navigate(['/contacts']);
    }

}

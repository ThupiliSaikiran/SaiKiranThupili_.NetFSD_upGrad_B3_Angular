import { Component } from '@angular/core';
import { Contact } from '../Model/Contact';
import { ContactService } from '../contact-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-detail-component',
  imports: [CommonModule,FormsModule],
  templateUrl: './contact-detail-component.html',
  styleUrl: './contact-detail-component.css',
})
export class ContactDetailComponent {
   public contactList:Contact[];

   public searchId:number=0;
 
   public searchedContact:Contact | undefined;

    constructor(private contactService:ContactService){
       this.contactList = this.contactService.getContacts();
     }

    public getContactById():void{

    this.searchedContact = this.contactService.getContactById(this.searchId)

  }
}

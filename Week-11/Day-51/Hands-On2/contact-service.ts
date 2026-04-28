import { Injectable } from '@angular/core';
import { Contact } from './Model/Contact';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  public contacts:Contact[] = [
      { id: 1, name: "Rahul Sharma", email: "rahul.sharma@gmail.com", phone: "9876543210" },
      { id: 2, name: "Priya Reddy", email: "priya.reddy@gmail.com", phone: "9123456780" },
      { id: 3, name: "Arjun Kumar", email: "arjun.kumar@gmail.com", phone: "9988776655" },
      { id: 4, name: "Sneha Patel", email: "sneha.patel@gmail.com", phone: "9090909090" },
      { id: 5, name: "Vikram Singh", email: "vikram.singh@gmail.com", phone: "9012345678" }
  ]


  public getContacts(): Contact[]{
    return this.contacts;
  }

  public addContact(contact: Contact): void{
    this.contacts.push(contact)
  }

  public getContactById(id:number):Contact| undefined{
    return this.contacts.find(contact => contact.id == id)
  }
}

import { Component } from '@angular/core';
import { Contact } from '../Model/Contact';
import { ContactService } from '../contact-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ncontact-details-component',
  imports: [],
  templateUrl: './ncontact-details-component.html',
  styleUrl: './ncontact-details-component.css',
})
export class NContactDetailsComponent {

  
    public searchId:number =0;
   
     public searchedContact:Contact | undefined;
  
      constructor(private contactService:ContactService, private activateRoute:ActivatedRoute){
         
        this.searchId = Number( this.activateRoute.snapshot.params["id"]);

         this.getContactById();
       }


      // ngOnInit() {
      //   this.getContactById();
      // }
      
      public getContactById():void{
  
      this.searchedContact = this.contactService.getContactById(this.searchId)
  
    }
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-petition',
  templateUrl: './new-petition.component.html',
  styleUrls: ['./new-petition.component.css']
})
export class NewPetitionComponent implements OnInit {
  singleModel: string = '1';

  constructor() { }

  ngOnInit() {
  }

}

import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Petition } from '../../models/petition/petition';
import { PetitionStatus } from '../../models/petition/petition-status';

@Component({
  selector: 'app-all-petitions',
  templateUrl: './all-petitions.component.html',
  styleUrls: ['./all-petitions.component.css']
})
export class AllPetitionsComponent implements OnInit {
    petitions: Petition[] = [];
    statusName: string[];
    statusColor: string[];

    constructor(private http: HttpClient,
                @Inject('API_URL') private apiUrl: string) {
        this.statusName = PetitionStatus.NAME;
        this.statusColor = PetitionStatus.COLOR;
    }

    ngOnInit() {
        this.getPetitions()
            .subscribe(result => {
                this.petitions = result;
                console.log(this.petitions);
            }, error => console.log(error));
    }

    private getPetitions(): Observable<Petition[]> {
        return this.http.get<any>(this.apiUrl + 'petition');
    }

}

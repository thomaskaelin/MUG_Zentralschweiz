import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from './../model/member';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class MemberRepositoryService {

  constructor(private http: HttpClient) { }

  public getAll(): Observable<Member[]> {
    return new Observable<Member[]>(obs => {
      this.http.get('assets/members.json').subscribe((membersDTO: any) => {
        const members = new Array<Member>();

        for (const memberDTO of membersDTO.results) {
          const member = new Member(
            memberDTO.name,
            memberDTO.city,
            memberDTO.link,
            memberDTO.photo.photo_link);

          members.push(member);
        }

        obs.next(members);
        obs.complete();
      });
    });
  }
}

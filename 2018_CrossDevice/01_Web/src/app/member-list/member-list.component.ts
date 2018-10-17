import { Member } from '../model/member';
import { MemberRepositoryService } from '../service/member-repository.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'mug-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  public members: Member[];

  constructor(private membersRepository: MemberRepositoryService) {
  }

  ngOnInit() {
    this.membersRepository.getAll().subscribe(
      loadedMembers => this.members = loadedMembers
    );
  }
}

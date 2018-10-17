import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MemberRepositoryService } from './service/member-repository.service';
import { MemberListComponent } from './member-list/member-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MemberListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    MemberRepositoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

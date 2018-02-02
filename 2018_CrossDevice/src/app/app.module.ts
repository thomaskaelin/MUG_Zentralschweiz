import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatCardModule, MatCheckboxModule, MatButtonModule, MatInputModule, MatListModule, MatToolbarModule, MatExpansionModule } from '@angular/material';


import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    MatCheckboxModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatListModule,
    MatToolbarModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

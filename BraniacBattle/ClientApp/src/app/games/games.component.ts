import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html'
})
export class gamesComponent {
  

  constructor(http: HttpClient) {
  }
}
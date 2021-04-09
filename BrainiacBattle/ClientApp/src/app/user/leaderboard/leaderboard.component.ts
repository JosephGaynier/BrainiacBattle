import { Component, OnInit } from '@angular/core';
import { Users } from '../user.model';
@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {

  users: Users[] = [
    new Users("Phisa", 22),
    new Users("Jack", 41),
    new Users("Chris", 44),
    new Users("Emily", 56),
    new Users("Emma", 54),
    new Users("Kali", 76),
    new Users("Felix", 53),
    new Users("Adrien", 35),
    new Users("Newton", 54),
    new Users("Kai", 43)
  ];
  constructor() { }

  ngOnInit() {
  }

  

}

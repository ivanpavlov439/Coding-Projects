import { Component, OnInit, Input } from '@angular/core';
import { Systems } from '../assignInterface';
import { Languages } from '../assignInterface';

@Component({
  selector: 'app-pavlovi',
  templateUrl: './pavlovi.component.html',
  styleUrls: ['./pavlovi.component.css']
})
export class PavloviComponent implements OnInit {
  @Input() languages: Languages[];
  @Input() systems: Systems[];
  name: String;
  outAreaSystems: String;
  outAreaLanguages: String;

  constructor() { }

  ngOnInit() {
  }

  displaySystem(index) {
    switch (index) {
      case 0:
        this.name = "Windows";
        break;
      case 1:
        this.name = "Mac";
        break;
      case 2:
        this.name = "Linux";
        break;
      case 3:
        this.name = "Android";
        break;
    }

    this.outAreaSystems = `
    <table>
      <tr>
        <th>Fun Fact</th>
        <th>Programming Languages</th>
        <th>Developer</th>
        <th>Release Date</th>
        <th>Logo</th>
      </tr>`;
    this.outAreaSystems += `<tr>
                        <td>${this.systems[index].funFact}</td> 
                        <td>${this.systems[index].progLanguage}</td> 
                        <td>${this.systems[index].developer}</td>
                        <td>${this.systems[index].releaseDate}</td>
                        <td> <img width = "85%" 
                        src="assets/images/systems/${this.systems[index].picture}"></td>  
                      </tr>`;
  }

  displayLanguage(index) {
    switch (index) {
      case 0:
        this.name = "Angular";
        break;
      case 1:
        this.name = "Java";
        break;
      case 2:
        this.name = "C";
        break;
      case 3:
        this.name = "Python";
        break;
    }

    this.outAreaLanguages = `
    <table>
      <tr>
        <th>Fun Fact</th>
        <th>Description</th>
        <th>Developer</th>
        <th>Release Date</th>
        <th>Logo</th>
      </tr>`;
    this.outAreaLanguages += `<tr>
                        <td>${this.languages[index].funFact}</td> 
                        <td>${this.languages[index].description}</td> 
                        <td>${this.languages[index].developer}</td>
                        <td>${this.languages[index].releaseDate}</td>
                        <td> <img width = "85%" 
                        src="assets/images/languages/${this.languages[index].picture}"></td>  
                      </tr>`;
  }
}

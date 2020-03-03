import { Component } from '@angular/core';
import { pavlovi } from './pavlovi';
import {Systems} from './assignInterface';
import {Languages} from './assignInterface';
import system from '../assets/data/systems.json';
import language from '../assets/data/languages.json';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'pavlovi-A4';

  bio: pavlovi = {
    name: "Ivan Pavlov",
    num: "991540069",
    logName: "pavlovi",
    campus: "Trafalgar",
    title: "Assignment #4"
  }

  systems: Systems[] = [system.windows, system.mac, system.linux, system.android];
  languages: Languages[] = [language.angular, language.java, language.C, language.python];
}
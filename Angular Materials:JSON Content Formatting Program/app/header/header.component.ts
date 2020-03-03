import { Component, OnInit, Input } from '@angular/core';
import { pavlovi } from '../pavlovi';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() headerInfo: pavlovi;

  constructor() { }

  ngOnInit() {
  }

}

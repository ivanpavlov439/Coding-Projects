import { Component, OnInit, Input } from '@angular/core';
import { pavlovi } from '../pavlovi';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  @Input() footerInfo: pavlovi;

  constructor() { }

  ngOnInit() {
  }

}

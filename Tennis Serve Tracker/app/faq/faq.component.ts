import { Component, OnInit, Inject } from "@angular/core";
import { Title, Meta } from "@angular/platform-browser";
import { DOCUMENT } from "@angular/common";

@Component({
  selector: "app-faq",
  templateUrl: "./faq.component.html",
  styleUrls: ["./faq.component.css"]
})
export class FaqComponent implements OnInit {
  constructor(
    private titleService: Title,
    @Inject(DOCUMENT) private document,
    private metaService: Meta
  ) {}

  ngOnInit() {
    this.titleService.setTitle("Tennis Serve Tracker: Help & FAQ");

    //Removing meta tags on default URL's
    if (
      this.document.location.hostname === "tennis-serve-tracker.web.app" ||
      this.document.location.hostname === "tennis-serve-tracker.firebaseapp.com"
    ) {
      this.metaService.removeTag("property='og:title'");
      this.metaService.removeTag("name='description'");
      this.metaService.removeTag("property='og:type'");
      this.metaService.removeTag("property='og:site_name'");
      this.metaService.removeTag("property='og:description'");
      this.metaService.removeTag("property='og:locale'");
    }
  }
}

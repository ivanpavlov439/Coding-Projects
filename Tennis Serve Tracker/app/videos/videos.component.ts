import { Component, OnInit, Inject } from "@angular/core";
import { Title, Meta } from "@angular/platform-browser";
import { DOCUMENT } from "@angular/common";

@Component({
  selector: "app-videos",
  templateUrl: "./videos.component.html",
  styleUrls: ["./videos.component.css"]
})
export class VideosComponent implements OnInit {
  videoSources: String[] = [
    "https://www.youtube.com/embed/dvx6uVAHp2o",
    "https://www.youtube.com/embed/-4d1U9ueg6Y",
    "https://www.youtube.com/embed/GW4iFJwBEAQ",
    "https://www.youtube.com/embed/8TSobs8UpD4",
    "https://www.youtube.com/embed/v7VtZcFKPlQ"
  ];

  constructor(
    private titleService: Title,
    @Inject(DOCUMENT) private document,
    private metaService: Meta
  ) {}

  ngOnInit() {
    this.titleService.setTitle("Tennis Serve Tracker: Demo Videos");

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

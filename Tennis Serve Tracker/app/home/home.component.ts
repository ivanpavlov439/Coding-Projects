import { Component, OnInit, Inject } from "@angular/core";
import { Title, Meta } from "@angular/platform-browser";
import { DOCUMENT } from "@angular/common";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  imageSources: String[] = [
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel1.png?alt=media&token=c0c94151-58df-406a-af41-fd7d681b7019",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel2.png?alt=media&token=e54dfe14-7eea-48cf-a42d-9969423fdc2d",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel3.png?alt=media&token=0491cfe2-438a-4741-a93f-a0e39909d318",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel4.png?alt=media&token=8f300b4c-c19c-47b9-b920-d576cac1eb41",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel5.png?alt=media&token=930e341b-bd0e-40ab-9442-812e34a973f5",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel6.png?alt=media&token=48426752-aaf5-4313-a289-c6a39ac2249e",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel7.png?alt=media&token=d6faf0ac-8fee-4959-bf59-19820f2c7680",
    "https://firebasestorage.googleapis.com/v0/b/tennis-serve-tracker.appspot.com/o/carousel8.png?alt=media&token=15b1e452-dcb6-432f-a8a9-6e710dc226ba"
  ];
  constructor(
    private titleService: Title,
    @Inject(DOCUMENT) private document,
    private metaService: Meta
  ) {}

  ngOnInit() {
    this.titleService.setTitle(
      "Tennis Serve Tracker: Tennis Serve Speed in Seconds!"
    );

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

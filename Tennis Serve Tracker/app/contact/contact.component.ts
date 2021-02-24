import { Component, OnInit, ViewChild, Inject } from "@angular/core";
import emailjs, { EmailJSResponseStatus } from "emailjs-com";
import { NgForm } from "@angular/forms";
import { Title, Meta } from "@angular/platform-browser";
import { DOCUMENT } from "@angular/common";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.css"]
})
export class ContactComponent implements OnInit {

  //Getting form object from html
  @ViewChild("f") contactForm: NgForm;

  constructor(private titleService: Title,  @Inject(DOCUMENT) private document,
  private metaService: Meta) {}

  ngOnInit() {
    this.titleService.setTitle("Tennis Serve Tracker: Contact Us");

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

  /**
   * This method will take all form values and send it to the owners email.
   * @param e Event triggered from form
   */
  public sendEmail(e: Event) {
    e.preventDefault();
    console.log(e.target);
    emailjs
      .sendForm(
        "zoho_admin_from",
        "template_e8itUjMq",
        e.target as HTMLFormElement,
        "user_uloCNupXI7brVEIegGgoU"
      )
      .then(
        (result: EmailJSResponseStatus) => {
          console.log(result.text);
        },
        error => {
          console.log(error.text);
        }
      );

    this.contactForm.reset();
  }
}

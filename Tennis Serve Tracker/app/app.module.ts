import { BrowserModule, Title } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from "./app-routing.module";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";

import { AppComponent } from "./app.component";
import { HeaderComponent } from "./header/header.component";
import { HomeComponent } from "./home/home.component";
import { VideosComponent } from "./videos/videos.component";
import { FaqComponent } from "./faq/faq.component";
import { ContactComponent } from "./contact/contact.component";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    VideosComponent,
    FaqComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    NgbModule,
    CommonModule
  ],
  providers: [Title],
  bootstrap: [AppComponent]
})
export class AppModule {}

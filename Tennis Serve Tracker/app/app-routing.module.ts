import { NgModule } from "@angular/core";
import { RouterModule, Routes, ExtraOptions } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { VideosComponent } from "./videos/videos.component";
import { FaqComponent } from "./faq/faq.component";
import { ContactComponent } from "./contact/contact.component";

//Implementing all routes
const appRoutes: Routes = [
  { path: "", redirectTo: "/home.html", pathMatch: "full" },
  { path: "home.html", component: HomeComponent},
  { path: "videos.html", component: VideosComponent },
  { path: "help---faq.html", component: FaqComponent },
  { path: "contact-us.html", component: ContactComponent},
  { path: "**", redirectTo: "home.html"}
];

//Extra routing options for using fragments
const routerOptions: ExtraOptions = {
  useHash: false,
  anchorScrolling: 'enabled',
};

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, routerOptions)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}

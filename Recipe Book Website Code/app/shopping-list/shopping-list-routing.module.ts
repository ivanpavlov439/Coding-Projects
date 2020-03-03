import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AuthGuard } from "../auth/auth.guard";
import { ShoppingListComponent } from "./shopping-list.component";

//All routes related to the shopping list components
const routes: Routes = [
  {
    path: "",
    canActivate: [AuthGuard],
    component: ShoppingListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShoppingListRoutesModule {}

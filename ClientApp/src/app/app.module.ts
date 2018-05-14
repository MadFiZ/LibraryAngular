import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookService } from '../app/book-list/book.service';
import { windowProvider } from './window';
import { MagazineListComponent } from './magazine-list/magazine-list.component';
import { MagazineService } from '../app/magazine-list/magazine.service';
import { PublicationService } from '../app/publication-list/publication.service';
import { PublicationListComponent } from './publication-list/publication-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BookListComponent,
    MagazineListComponent,
    PublicationListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: BookListComponent, pathMatch: 'full' },
      { path: 'magazine-list', component: MagazineListComponent},
    ])
  ],
  providers: [BookService, windowProvider, MagazineService, PublicationService],
  bootstrap: [AppComponent]
})
export class AppModule { }

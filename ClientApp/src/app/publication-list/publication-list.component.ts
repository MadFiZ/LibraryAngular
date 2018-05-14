import { Component, OnInit, Inject } from '@angular/core';

import { PublicationService } from '../publication-list/publication.service';
import { Publication } from "../publication-list/publication";
import { windowProvider } from '../window';


@Component({
  selector: 'app-publication-list',
  templateUrl: './publication-list.component.html',
  styleUrls: ['./publication-list.component.css']
})
export class PublicationListComponent implements OnInit {

 publication: Publication = new Publication();
  public publications: Publication[];
  tableMode: boolean = true;

  constructor(private publicationService: PublicationService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadPublications();    // загрузка данных при старте компонента  
  }

  loadPublications() {
    this.publicationService.getPublications()
      .subscribe((data: Publication[]) => this.publications = data);
  }
}

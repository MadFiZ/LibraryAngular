import { Component, OnInit, Inject } from '@angular/core';

import { MagazineService } from '../magazine-list/magazine.service';
import { Magazine } from "../magazine-list/magazine";
import { windowProvider } from '../window';

@Component({
  selector: 'app-magazine-list',
  templateUrl: './magazine-list.component.html',
  styleUrls: ['./magazine-list.component.css']
})
export class MagazineListComponent implements OnInit {

  magazine: Magazine = new Magazine();
  public magazines: Magazine[];
  tableMode: boolean = true;

  constructor(private magazineService: MagazineService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadMagazines();    // загрузка данных при старте компонента  
  }

  loadMagazines() {
    this.magazineService.getMagazines()
      .subscribe((data: Magazine[]) => this.magazines = data);
  }
  // сохранение данных
  save() {
    if (this.magazine.id == null) {
      this.magazineService.createMagazine(this.magazine)
        .subscribe((data: Magazine) => this.magazines.push(data));
    } else {
      this.magazineService.updateMagazine(this.magazine)
        .subscribe(data => this.loadMagazines());
    }
    this.cancel();
  }
  editMagazine(p: Magazine) {
    this.magazine = p;
  }
  cancel() {
    this.magazine = new Magazine();
    this.tableMode = true;
  }
  delete(b: Magazine) {
    this.magazineService.deleteMagazine(b.id)
      .subscribe(data => this.loadMagazines());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}

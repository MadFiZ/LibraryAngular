import { Component, OnInit, Inject } from '@angular/core';

import { BookService } from '../book-list/book.service';
import { Book } from "../book-list/book";
import { windowProvider } from '../window';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  book: Book = new Book();
  public books: Book[];
  tableMode: boolean = true;

  constructor(private bookService: BookService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadBooks();    // загрузка данных при старте компонента  
  }

  loadBooks() {
    this.bookService.getBooks()
      .subscribe((data: Book[]) => this.books = data);
  }
  // сохранение данных
  save() {
    if (this.book.id == null) {
      this.bookService.createBook(this.book)
        .subscribe((data: Book) => this.books.push(data));
    } else {
      this.bookService.updateBook(this.book)
        .subscribe(data => this.loadBooks());
    }
    this.cancel();
  }
  editBook(p: Book) {
    this.book = p;
  }
  cancel() {
    this.book = new Book();
    this.tableMode = true;
  }
  delete(b: Book) {
    this.bookService.deleteBook(b.id)
      .subscribe(data => this.loadBooks());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}

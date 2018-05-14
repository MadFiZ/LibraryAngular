import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Book } from './book';

@Injectable()
export class BookService {

  private url = "/api/books";

  constructor(private http: HttpClient) {
  }

  getBooks(): Observable <Book[]> {
    return this.http.get<Book[]>(this.url);
  }

  createBook(book: Book) {
    return this.http.post(this.url, book);
  }
  updateBook(book: Book) {

    return this.http.put(this.url + '/' + book.id, book);
  }
  deleteBook(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}

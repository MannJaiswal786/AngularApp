import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { quote } from './quote';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html'
})
export class QuotesComponent implements OnInit {

  constructor(private http: HttpClient) { }
  apiBaseURL: string = "http://localhost:3887/api/";

  quoteList: quote[] = [];
  quote: quote = new quote();

  ngOnInit(): void {

    this.getAllQuotes();
  }

  getAllQuotes() {

    this.http.get<quote[]>(this.apiBaseURL + "Quote/getAll")
      .subscribe(res =>
      {
        this.quoteList = res;
      }, err =>
      {
        console.log(err);
        alert(err);
      });

  }

  postQuote() {

    this.http.post<quote>(this.apiBaseURL + "Quote", this.quote)
      .subscribe(res =>
      {
        this.quote = new quote();
        this.getAllQuotes();
      }, err =>
      {
        alert(err);
      });
  }

  putQuote() {

    this.http.put<quote>(this.apiBaseURL + "Quote", this.quote)
      .subscribe(res => {
        this.quote = new quote();
        this.getAllQuotes();
      }, err => {
        alert(err);
      });
  }


  getQuoteById(id: number) {
    debugger;
    this.http.get<quote>(this.apiBaseURL + "Quote/getById/" + id)
      .subscribe(res =>
      {
        this.quote = res;
      }, err => {
        alert(err);
      });
  }
  delete(id: number) {
    this.http.delete<any>(this.apiBaseURL + "Quote/" + id)
      .subscribe(res => {
        this.getAllQuotes();
      }, err => {
        alert(err);
      });
      
  }
}

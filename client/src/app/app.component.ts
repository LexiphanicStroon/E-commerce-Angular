import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'E-commerce';
  products: IProduct[];

constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('http://localhost:5255/api/products?pageSize=50').subscribe((response: IPagination) => {
      this.products = response.data;
    });
  }
}

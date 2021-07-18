import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { IBrand } from "../shared/models/IBrand";
import { IProductType } from "../shared/models/IProductType";
import { IProduct } from "../shared/models/Product";
import { ShopParams } from "../shared/models/ShopParams";
import { ShopService } from "./shop.service";

@Component({
  selector: "app-shop",
  templateUrl: "./shop.component.html",
  styleUrls: ["./shop.component.scss"],
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  Brands: IBrand[];
  Types: IProductType[];
  @ViewChild('search') searchterm:ElementRef;

  shopparams = new ShopParams();
  totalCount: number;
  Sortoptions = [
    { name: "Alphabetical", value: "name" },
    { name: "Price low to High", value: "priceAsc" },
    { name: "Price High to Low", value: "priceDesc" },
  ];

  constructor(private shopservice: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  getProducts() {
    this.shopservice.getProducts(this.shopparams).subscribe(
      (response) => {
        this.products = response.data;
        this.shopparams.PageNumber=response.pageIndex;
        this.shopparams.PageSize=response.pageSize;
        this.totalCount=response.count;

      },
      (error) => {
        console.log(error);
      }
    );
  }
  getBrands() {
    this.shopservice.getBrands().subscribe(
      (response) => {
        this.Brands = [{ id: 0, name: "All" }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getTypes() {
    this.shopservice.getTypes().subscribe(
      (response) => {
        this.Types = [{ id: 0, name: "All" }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  OnBrandSelected(brandid: number) {
    this.shopparams.brandid = brandid;
    this.shopparams.PageNumber=1;
    this.getProducts();
  }
  OnTypeSelected(typeid: number) {
    this.shopparams.typeid = typeid;
    this.shopparams.PageNumber=1;
    this.getProducts();
  }
  OnSortedSelected(sort: string) {
    this.shopparams.sort = sort;
    this.getProducts();
  }
  OnPageChanged(event:any){
    if(this.shopparams.PageNumber!==event)
    this.shopparams.PageNumber=event;
    this.getProducts();
  }
  OnSearch(){
    this.shopparams.search=this.searchterm.nativeElement.value;
    this.shopparams.PageNumber=1;
    this.getProducts();
  }
  OnReset(){
    this.searchterm.nativeElement.value='';
    this.shopparams=new ShopParams();
    this.getProducts();

  }
}

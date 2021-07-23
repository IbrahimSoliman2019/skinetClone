import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { IProduct } from "src/app/shared/models/Product";
import { ShopService } from "../shop.service";

@Component({
  selector: "app-product-details",
  templateUrl: "./product-details.component.html",
  styleUrls: ["./product-details.component.scss"],
})
export class ProductDetailsComponent implements OnInit {
  Product: IProduct;

  constructor(private shopservice: ShopService,private route:ActivatedRoute) {}

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct() {
    this.shopservice.getProduct(+this.route.snapshot.paramMap.get('id')).subscribe(
      (product) => {
        this.Product = product;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { IPagination } from "../shared/models/Pagination";
import { IBrand } from "../shared/models/IBrand";
import { IProductType } from "../shared/models/IProductType";
import {map} from 'rxjs/operators';
import { ShopParams } from "../shared/models/ShopParams";
import { IProduct } from "../shared/models/Product";

@Injectable({
  providedIn: "root",
})
export class ShopService {
  BaseUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) {}

  getProducts(shopParams:ShopParams) {
    let params = new HttpParams();
   

    if(shopParams.brandid!=0){
     params= params.append("BrandId",shopParams.brandid.toString());
     // this.BaseUrl+=`BrandId=${brandid.toString()}&&`;
    }
    if(shopParams.typeid!=0){
     params= params.append("TypeId",shopParams.typeid.toString());
     // this.BaseUrl+=`TypeId=${typeid.toString()}&&`;

    }
  
    params=  params.append("sort",shopParams.sort);
      //this.BaseUrl+=`sort=${sort}`;
    params=params.append('pageIndex',shopParams.PageNumber.toString());

    if(shopParams.search){
    params=params.append('search',shopParams.search);
      
    }

    
    // + `products?BrandId=${brandid==undefined?null:brandid.toString()}&&TypeId=${typeid==undefined?null:typeid.toString()}&&sort=${sort}`
    console.log(params);
   return this.http.get<IPagination>(this.BaseUrl+'products',{observe:'response',params} )
   .pipe(map(response=>{
     return  response.body;
    }));
  }
  getProduct(id:number){
    return this.http.get<IProduct>(`${this.BaseUrl}/products/${id}`);
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.BaseUrl + "products/brands");
   }
   getTypes() {
    return this.http.get<IProductType[]>(this.BaseUrl + "products/types");
   }
}

import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-test-error",
  templateUrl: "./test-error.component.html",
  styleUrls: ["./test-error.component.scss"],
})
export class TestErrorComponent implements OnInit {
  BaseUrl = environment.ApiUrl;
  ValidationErrors: any;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  get404NotFound() {
    this.http.get(this.BaseUrl + "products/42").subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  get400Error() {
    this.http.get(this.BaseUrl + "buggy/badrequest").subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getserverError() {
    this.http.get(this.BaseUrl + "buggy/servererror").subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  get400ValidationError() {
    this.http.get(this.BaseUrl + "products/fortytwo").subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        this.ValidationErrors=error.errors;
      }
    );
  }
}

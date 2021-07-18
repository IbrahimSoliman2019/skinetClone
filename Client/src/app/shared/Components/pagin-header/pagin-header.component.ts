import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagin-header',
  templateUrl: './pagin-header.component.html',
  styleUrls: ['./pagin-header.component.scss']
})
export class PaginHeaderComponent implements OnInit {
@Input() totalCount:number;
@Input() PageNumber:number;
@Input() PageSize:number;

  constructor() { }

  ngOnInit(): void {
  }

}

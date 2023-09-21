import { Component, EventEmitter, Output, Input, OnInit} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {TooltipPosition} from '@angular/material/tooltip';
import { DepartmentModel } from 'src/app/domain/models/employeemanager/department/department-model';
import { TableColumnsModel } from 'src/app/domain/models/shared/table/table-columns-model';

@Component({
  selector: 'app-basic-common-table',
  templateUrl: './basic-common-table.component.html',
  styleUrls: ['./basic-common-table.component.scss']
})
export class BasicCommonTableComponent implements OnInit {
  displayedColumns: string[] = [];
  tableColumns: TableColumnsModel[] = [];
  dataSource = new MatTableDataSource<DepartmentModel>();
  positionOptions: TooltipPosition[] = ['after', 'before', 'above', 'below', 'left', 'right'];

  @Output() rowClick = new EventEmitter<any>();
  
  @Input() set data(datamodel:any){
    this.dataSource=datamodel;
  }

  @Input() set columnsArray(columnsModel: TableColumnsModel[]){
    this.tableColumns = columnsModel;
    this.displayedColumns = columnsModel.map(col => col.def);
  }

  constructor(){}

  ngOnInit():void{

  }
}

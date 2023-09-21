import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasicCommonTableComponent } from './basic-common-table/basic-common-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTooltipModule} from '@angular/material/tooltip';


@NgModule({
  declarations: [
    BasicCommonTableComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTooltipModule
  ],
  exports:[BasicCommonTableComponent]
})
export class CommonsTablesModule { }

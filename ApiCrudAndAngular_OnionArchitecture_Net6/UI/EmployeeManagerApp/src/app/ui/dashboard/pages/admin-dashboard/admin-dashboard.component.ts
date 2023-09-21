import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatSidenav} from '@angular/material/sidenav';
import { BreakpointObserver} from '@angular/cdk/layout';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent {
  //Decorators
  @ViewChild(MatSidenav)
  sidenav!:MatSidenav;
  closeMenuFlag:boolean;
  flag1: boolean;
  flag2:boolean;

  constructor(private observer: BreakpointObserver, private cd: ChangeDetectorRef){
    this.closeMenuFlag=false;
    this.flag1=false;
    this.flag2=false;
  }

  ngAfterViewInit(){
    this.observer.observe(['(max-width: 800px)']).subscribe((resp) =>{
      if(resp.matches){
        this.flag2=false;
        if(this.closeMenuFlag === false && this.flag1 === false){
          this.sidenav.mode = 'over';
          this.closedMenu();
        }

        if(this.closeMenuFlag === true && this.flag1 === false){
          this.flag1 = false;
        }

        if(this.closeMenuFlag === true && this.flag1 === true){
          this.flag1 = false;
        }
        
      }else{
        console.log('Initial2');
        this.flag2=false;
        if(this.closeMenuFlag === false && this.flag1 === false){
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }

        if(this.closeMenuFlag === true && this.flag1 === true){
          this.closeMenuFlag = false;
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }

        if(this.closeMenuFlag === true && this.flag1 === false){
          this.closeMenuFlag = false;
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }

      }
    })

    this.cd.detectChanges();
  }

  closedMenu(){
    this.closeMenuFlag=true;
    this.flag2 = false;
    this.observer.observe(['(max-width: 800px)']).subscribe((resp) =>{
      this.flag2 = false;
      if(resp.matches){
        if(this.closeMenuFlag === true && this.flag1 === true){
            this.sidenav.mode = 'side';
            this.sidenav.open();
        }

        this.sidenav.mode = 'over';
        this.sidenav.close();
      }else{
        if(this.closeMenuFlag === true && this.flag1 === false){
          this.flag1 = true;
          this.sidenav.mode = 'over';
          this.sidenav.close();
        }

        if(this.closeMenuFlag === true && this.flag1 === true){
          this.flag1 = true;
          this.sidenav.mode = 'over';
          this.sidenav.close();
        }
        
      }
    })
    
  }

  openedMenu(){
      this.closeMenuFlag=false;
      this.observer.observe(['(max-width: 800px)']).subscribe((resp) =>{
        if(resp.matches){
          if(this.closeMenuFlag === false && this.flag1 === true){
            this.flag1 = false;
            this.sidenav.mode = 'side';
            this.sidenav.open();
          }

          if(this.closeMenuFlag === false && this.flag1 === false){
            this.closeMenuFlag = true;
            this.flag2 = true;
            this.sidenav.toggle();
          }

        }else{
          if(this.closeMenuFlag === false && this.flag1 === true){
            this.flag1 = false
            this.sidenav.mode = 'side';
            this.sidenav.open();
          }

          if(this.closeMenuFlag === true && this.flag1 === true){
            this.sidenav.mode = 'side';
            this.sidenav.open();
          }
          
        }
      });

  }

}

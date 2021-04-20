import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};  
  constructor(public accountService: AccountService, private toastr: ToastrService, private router: Router) { 
  }

  ngOnInit(): void {    
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {      
      this.router.navigateByUrl('/find-crew');  
    }, error => {
      console.log(error);
    });
  }

  logout() {
    this.accountService.logout();    
  }
}

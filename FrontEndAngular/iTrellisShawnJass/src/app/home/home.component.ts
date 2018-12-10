import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CarService } from '../car.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public carData: Array<any>;
  // Make: any;

  public returnCar: Array<any>;

  constructor(private carservice: CarService) {
    carservice.get().subscribe((data: any) => this.carData = data);
    console.log(this.carData);
   }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    {
      const getCar = form.value;
      const searchCarObject = {
        Id: getCar.Id,
        Make: getCar.Make,
        Year: getCar.Year,
        Color: getCar.Color,
        Price: getCar.Price,
        HasSunRoof: getCar.HasSunRoof,
        IsFourWheelDrive: getCar.IsFourWheelDrive,
        HaslowMiles: getCar.HaslowMiles,
        HasPowerWindows: getCar.HasPowerWindows,
        HasNavigation: getCar.HasNavigation,
        HasHeatedSeats: getCar.HasHeatedSeats
      // tslint:disable-next-line:semicolon
      }
      this.carservice.getFromSearch(searchCarObject).subscribe
      ((searchFilter: any) => this.returnCar = searchFilter);
      // tslint:disable-next-line:semicolon
      console.log('object ' + searchCarObject);
      console.log('searched ' + this.returnCar);
    }
  }

}

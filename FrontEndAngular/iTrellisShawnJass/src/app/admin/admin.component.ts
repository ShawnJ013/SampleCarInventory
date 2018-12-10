import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CarService } from '../car.service';
// import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private carservice: CarService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    const addCar = form.value;
    const newCarObject = {
      Id: addCar.Id,
      Make: addCar.Make,
      Year: addCar.Year,
      Color: addCar.Color,
      Price: addCar.Price,
      HasSunRoof: addCar.HasSunRoof,
      IsFourWheelDrive: addCar.IsFourWheelDrive,
      HaslowMiles: addCar.HaslowMiles,
      HasPowerWindows: addCar.HasPowerWindows,
      HasNavigation: addCar.HasNavigation,
      HasHeatedSeats: addCar.HasHeatedSeats
    // tslint:disable-next-line:semicolon
    }
    this.carservice.add(newCarObject).subscribe
    // tslint:disable-next-line:semicolon
    (data => {console.log('sent ' + form.value)});
  }

}

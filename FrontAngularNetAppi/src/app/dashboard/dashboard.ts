import { Component } from '@angular/core';
import { RouterModule } from '@angular/router'; // <-- agrega esto

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterModule], // <-- y esto también
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.scss']
})
export class Dashboard {}

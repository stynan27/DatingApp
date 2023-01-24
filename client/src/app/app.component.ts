import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

// Component decorator for a UI Component
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
// Use of implements here is to define a definition for a lifecycle "interface".
// interfaces are a "contract" that a class/component MUST provide implementation details for.
// interfaces in JavaScript are a TypeScript construct.
export class AppComponent implements OnInit { // OnInit -> Allows us to define ngOnInit() method to handle initialization after component construction/
  // class properties here
  title = 'Dating app'; // infered type of string (usually you want to specify type here)
  users: any; // DANGEROUS! - removes type safety/typescript off

  // Provided a constructor for this app component, which "injects" the HttpClient property
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Http GET request which returns an "Observable" (stream of API data)
    // subscribe forces get to be "Observed"
    this.http.get("https://localhost:5001/api/users").subscribe({
      next: response => this.users = response,
      error: (error) => console.error(error),
      complete: () => console.log('Request completed.'), 
    });
  }

  // component methods here
}

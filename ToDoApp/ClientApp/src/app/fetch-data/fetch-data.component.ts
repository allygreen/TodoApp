import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todo: ToDoList[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ToDoList[]>(baseUrl + 'todo').subscribe(result => {
      this.todo = result;
    }, error => console.error(error));
  }
}

interface ToDoList {
  createdDate: string;
  completed: boolean;
  title: string;
  summary: string;
  description: string;
  dateCompleted: string;
}

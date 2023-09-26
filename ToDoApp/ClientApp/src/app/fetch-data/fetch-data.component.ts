import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todo: ToDoList[] = [];
  public newTodo: Partial<ToDoList> = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.fetchTodos();
  }

  fetchTodos(): void {
    this.http.get<ToDoList[]>(this.baseUrl + 'todo').subscribe(result => {
      this.todo = result;
    }, error => console.error(error));
  }

  addTodo(): void {
    if (!this.newTodo.title || !this.newTodo.summary) {
      console.error('Title and Summary are required.');
      return;
    }
    this.http.post<ToDoList>(this.baseUrl + 'todo', this.newTodo).subscribe(
      result => {
        this.todo.push(result);
        this.newTodo = {};  // Reset the newTodo object
      },
      error => console.error(error)
    );
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

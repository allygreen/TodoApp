import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public showForm = false;
  public todo: ToDoList[] = [];
  public newTodo: Partial<ToDoList> = {};
  public editingField: string | null = null; // Track which field is being edited

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

  // Function to handle inline editing
  editCell(field: string, todoItem: ToDoList): void {
    this.editingField = field;
  }

  // Function to save changes made to a cell
  saveCell(todoItem: ToDoList): void {
    // Send a PUT request to update the backend with the changes
    this.http.put<ToDoList>(this.baseUrl + 'todo/' + todoItem.id, todoItem).subscribe(
      updatedTodo => {
        // Update the item in the todo list with the updated data from the server
        const index = this.todo.findIndex(item => item.id === updatedTodo.id);
        if (index !== -1) {
          this.todo[index] = updatedTodo;
        }
        this.editingField = null; // Exit edit mode
      },
      error => console.error(error)
    );
  }

  // Function to cancel editing and exit edit mode
  cancelEdit(): void {
    this.editingField = null; // Exit edit mode
  }
}

export interface ToDoList {
  id: number;
  createdDate: string;
  completed: boolean;
  title: string;
  summary: string;
  description: string;
  dateCompleted: string;
  editingField?: string;
}

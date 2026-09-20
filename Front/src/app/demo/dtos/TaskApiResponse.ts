import { Task } from "./Task";

export class TaskApiResponse {
  data: Task[];
  status: boolean | null;
  message: string | null;
  
}
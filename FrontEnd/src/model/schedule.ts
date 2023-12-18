import { Student } from "./student";
import { Tutor } from "./tutor";

export interface Schedule {
    id?: number;
    tutorId?: number;
    tutor: Tutor;
    name?: string;
    subjects?: Subject[];
    hourlyPrice?: number;
    isPaid?:boolean;
    startTime: Date;
    endTime: Date;
    studentId?: number;
    student: Student;
  }

  export enum Subject {
    Economics = "Economics",
    Maths = "Maths",
    Programming = "Programming",
    Startup = "Startup",
    PE = "PE",
    DiscMaths = "DiscMaths",
  }

  export interface State {
    Schedules: Schedule[];
  }
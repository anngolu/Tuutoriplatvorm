import { Tutor } from "./tutor";

export interface Schedule {
    id?: number;
    tutorId?: number;
    tutor: Tutor;
    name?: string;
    subjects?: Subject[];
    hourlyPrice?: number;
    startTime: Date;
    endTime: Date;
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
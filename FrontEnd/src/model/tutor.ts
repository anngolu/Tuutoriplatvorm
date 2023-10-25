export interface Tutor {
  id?: number;
  name: string;
  town: string;
  university: string;
  speciality: string;
  mail:string;
  subject: string;
  hourlyPrice?: number;
  grade?: number;
}

export interface State {
  Tutors: Tutor[];
}

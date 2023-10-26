export interface Student {
  id?: number;
  stName: string;
  stTown?: string;
  stUniversity?: string;
  stSpeciality?: string;
  stMail?: string;
  stSubject?: string;
}
export interface State {
  Students: Student[];
}
export interface Student {
  id?: number;
  stname: string;
  sttown: string;
  stuniversity: string;
  stspeciality: string;
  stmail: string;
  stsubject: string;
}
export interface State {
  Students: Student[];
}
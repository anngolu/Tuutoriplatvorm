export interface Tutor {
  id?: number;
  name: string;
  town?: string;
  university?: string;
  speciality?: string;
  mail?: string;
  subject?: string;
  hourlyPrice?: number;
  averageRate?: number;
  rateCount?: number;
}

export interface State {
  Tutors: Tutor[];
}

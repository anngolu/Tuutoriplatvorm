export interface Tutor {
  code: string;
  name: string;
  surname: string;
  university: string;
  faculty: string;

  status?: TutorStatus;
  gender?: TutorGender;
  /*  description: String; */
  hourlyPrice?: number;
  grade?: number;
}

export interface State {
  Tutors: Tutor[];
}

export enum TutorStatus {
  Active = 'aktiivne',
  NonActive = 'mitteaktiivne',
}

export enum TutorGender {
  Male = 'M',
  Female = 'N',
}

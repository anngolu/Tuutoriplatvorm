export interface Student {
  code: string;
  name: string;
  surname: string;
  university: string;
  subject: string;

  status?: StudentStatus;
  gender?: StudentGender;
  /*  description: String; */
}

export interface State {
  students: Student[];
}

export enum StudentStatus {
  Active = 'aktiivne',
  NonActive = 'mitteaktiivne',
}

export enum StudentGender {
  Male = 'M',
  Female = 'N',
}

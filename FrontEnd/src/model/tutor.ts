export interface Tutor {
  id?: number;
  name?: string;
  town?: Town;
  university?: University;
  speciality?: Speciality;
  mail?: string;
  subjects?: Subject[];
  hourlyPrice?: number;
  averageRate?: number;
  rateCount?: number;
}

export enum Town {
  Tartu = "Tartu",
  Tallinn = "Tallinn",
  Narva = "Narva",
  KohtlaJarve = "Kohtla-Järve",
}

export enum University {
  UniversityOfTartu = "University of Tartu",
  TallinnTechnicalUniversity = "Tallinn Technical University",
  TallinnUniversity = "Tallinn University",
  TallinnCollegeOfHealth = "Tallinn College Of Health",
  TartuHigherArtSchool = "Tartu Higher Art School",
}

export enum Speciality {
  BusinessIt = "Business It",
  Economics = "Economics",
  Informatics = "Informatics",
  Science = "Science",
  CyberSecurity = "Cyber Security",
  Psychologist = "Psychologist",
}

export enum Subject {
  Economics = "Economics",
  Maths = "Maths",
  Programming = "Programming",
  Startup = "Start up",
  PE = "PE",
  DiscMaths = "Discrete Maths",
}

export interface State {
  Tutors: Tutor[];
}

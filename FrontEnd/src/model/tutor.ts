import { Account } from "./auth";


export interface Tutor extends Account {
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
  photoUrlId?: number;
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
  Startup = "Startup",
  PE = "PE",
  DiscMaths = "DiscMaths",
}

export interface State {
  Tutors: Tutor[];
}





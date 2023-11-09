export interface Student {
  id?: number;
  stName?: string;
  stTown?: StTown;
  stUniversity?: StUniversity;
  stSpeciality?: StSpeciality;
  stMail?: string;
  stSubject?: StSubject;
}

export enum StTown {
  Tartu = "Tartu",
  Tallinn = "Tallinn",
  Narva = "Narva",
  KohtlaJarve = "Kohtla-Järve",
}

export enum StUniversity {
  UniversityOfTartu = "University of Tartu",
  TallinnTechnicalUniversity = "Tallinn Technical University",
  TallinnUniversity = "Tallinn University",
  TallinnCollegeOfHealth = "Tallinn College Of Health",
  TartuHigherArtSchool = "Tartu Higher Art School",
}

export enum StSpeciality {
  BusinessIt = "Business It",
  Economics = "Economics",
  Informatics = "Informatics",
  Science = "Science",
  CyberSecurity = "Cyber Security",
  Psychologist = "Psychologist",
}

export enum StSubject {
  Economics = "Economics",
  Maths = "Maths",
  Programming = "Programming",
  Startup = "Start up",
  PE = "PE",
  DiscMaths = "Discrete Maths",
}

export interface State {
  Students: Student[];
}
import { Student, StudentGender, StudentStatus } from '@/model/student';
import { ref } from 'vue';
import { defineStore } from 'pinia';

export const useStudentStore = defineStore('studentsStore', () => {
  const students = ref<Student[]>([
    {
      name: 'Eesnimi1',
      surname: 'Tudeng1',
      code: '001',
      gender: StudentGender.Male,
      university: 'TalTech',
      subject: 'ISA2',
      status: StudentStatus.NonActive,
    },
    {
      name: 'Eesnimi2',
      surname: 'Tudeng2',
      code: '002',
      university: 'Tartu Ülikool',
      subject: 'Loodusteaduste alused',
      gender: StudentGender.Female,
      status: StudentStatus.Active,
    },
  ]);

  const addStudent = (student: Student) => {
    students.value.push(student);
  };

  return { students, addStudent };
});

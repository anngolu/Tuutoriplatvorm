import { Student, StudentRateTotor as StudentRateTutor } from '@/model/student';
import { ref } from 'vue';
import { defineStore } from 'pinia';
import useApi from '@/model/api'; //{ useApiRawRequest }

export const useStudentsStore = defineStore('studentsStore', () => {
  const apiGetStudents = useApi<Student[]>('students');
  const students = ref<Student[]>([]);
  let allStudents: Student[] = [];

  const loadStudents = async () => {
    await apiGetStudents.request();

    if (apiGetStudents.response.value) {
      return apiGetStudents.response.value!;
    }

    return [];
  };

  const load = async () => {
    allStudents = await loadStudents();
    students.value = allStudents;
  };

  const getStudentById = (id: number) => {
    return allStudents.find((student) => student.id === id);
  };

  const addStudent = async (student: Student) => {
    const apiAddSudent = useApi<Student>('students', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(student),
    });

    await apiAddSudent.request();
    if (apiAddSudent.response.value) {
      allStudents.push(apiAddSudent.response.value!);
      students.value = allStudents;
    }
  };

  const updateStudent = async (student: Student) => {
    const apiAddStudent = useApi<Student>('students/' + student.id, {
      method: 'PUT',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(student),
    });

    await apiAddStudent.request();
    if (apiAddStudent.response.value) {
      load();
    }
  };

  const rateTutor = async (tutorId: number, rate: number) => {
    const apiRateTutor = useApi<Student>(
      'students/tutors/' + tutorId + '/rates',
      {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ rate }),
      },
    );

    await apiRateTutor.request();
  };

  const getTutorRates = async () => {
    const apiGetTutorRates = useApi<StudentRateTutor[]>(
      'students/tutors/rates',
      {
        method: 'GET',
        headers: {
          Accept: 'application/json'
        },
      },
    );

    await apiGetTutorRates.request();

    if (apiGetTutorRates.response.value) {
      return apiGetTutorRates.response.value!;
    }

    return [];
  };

  return {
    students,
    load,
    getStudentById,
    addStudent,
    updateStudent,
    rateTutor,
    getTutorRates
  };
});

import {  Student } from '@/model/student';
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

  // const deleteStudent = async (student: Student) => {
  //   const deleteStudentRequest = useApiRawRequest(`students/${student.id}`, {
  //     method: 'DELETE',
  //   });

  //   const res = await deleteStudentRequest();

  //   if (res.status === 204) {
  //     let id = allStudents.indexOf(student);

  //     if (id !== -1) {
  //       allStudents.splice(id, 1);
  //     }

  //     id = students.value.indexOf(student);

  //     if (id !== -1) {
  //       students.value.splice(id, 1);
  //     }
  //   }
  // };


  return {
    students,
  load,
    getStudentById,
  addStudent,
   updateStudent,
 //deleteStudent,
  };
});
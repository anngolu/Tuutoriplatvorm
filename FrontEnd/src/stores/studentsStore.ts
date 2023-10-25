import {  Student } from '@/model/student';
import { ref } from 'vue';
import { defineStore } from 'pinia';
import useApi, { useApiRawRequest } from '@/model/api';

export const useStudentsStore = defineStore('exercisesStore', () => {
  const apiGetStudents = useApi<Student[]>('exercises');
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

  const addExercise = async (exercise: Student) => {
    const apiAddExercise = useApi<Student>('exercises', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(exercise),
    });

    await apiAddExercise.request();
    if (apiAddExercise.response.value) {
      allStudents.push(apiAddExercise.response.value!);
      students.value = allStudents;
    }
  };

  const updateExercise = async (exercise: Student) => {
    const apiAddExercise = useApi<Student>('exercises/' + exercise.id, {
      method: 'PUT',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(exercise),
    });

    await apiAddExercise.request();
    if (apiAddExercise.response.value) {
      load();
    }
  };

  const deleteExercise = async (exercise: Student) => {
    const deleteExerciseRequest = useApiRawRequest(`exercises/${exercise.id}`, {
      method: 'DELETE',
    });

    const res = await deleteExerciseRequest();

    if (res.status === 204) {
      let id = allStudents.indexOf(exercise);

      if (id !== -1) {
        allStudents.splice(id, 1);
      }

      id = students.value.indexOf(exercise);

      if (id !== -1) {
        students.value.splice(id, 1);
      }
    }
  };

  const filterExercisesByTitle = (exerciseTitleFilter: string) => {
    students.value = allStudents.filter((x) =>
      x.title.startsWith(exerciseTitleFilter),
    );
  };

  return {
    exercises: students,
    load,
    getExerciseById: getStudentById,
    addExercise,
    updateExercise,
    deleteExercise,
    filterExercisesByTitle,
  };
});
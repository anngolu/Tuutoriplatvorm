import { Tutor } from '@/model/tutor';
import { ref } from 'vue';
import { defineStore } from 'pinia';
import { useApiRawRequest } from '@/model/api'; 
import useApi from '@/model/api'; //{ useApiRawRequest }

export const useTutorsStore = defineStore('tutorsStore', () => {
  const apiGetTutors = useApi<Tutor[]>('tutors');
  const tutors = ref<Tutor[]>([]);
  let allTutors: Tutor[] = [];

  const loadTutors = async () => {
    await apiGetTutors.request();

    if (apiGetTutors.response.value) {
      return apiGetTutors.response.value!;
    }

    return [];
  };

  const load = async () => {
    allTutors = await loadTutors();
    tutors.value = allTutors;
  };

  const searchTutorByName = (name: string) => {
    return tutors.value.filter((tutor) => tutor.name?.toLocaleLowerCase().includes(name?.toLocaleLowerCase()));
  };

  const getTutorById = (id: number) => {
    return allTutors.find((tutor) => tutor.id === id);
  };

  const addTutor = async (tutor: Tutor) => {
    const apiAddTutor = useApi<Tutor>('tutors', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(tutor),
    });

    await apiAddTutor.request();
    if (apiAddTutor.response.value) {
      allTutors.push(apiAddTutor.response.value!);
      tutors.value = allTutors;
    }
  };

  const updateTutors = async (tutor: Tutor) => {
    const apiAddTutor = useApi<Tutor>('tutors/' + tutor.id, {
      method: 'PUT',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(tutor),
    });

    await apiAddTutor.request();
    if (apiAddTutor.response.value) {
      load();
    }
  };

  const calculateRating = async (id: number, rate: number) => {
    const apiAddTutorRating = useApi<Tutor>(
      'tutors/' + id + '/rate',
      {
        method: 'PUT',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({rate: rate}),
      },
    );

    await apiAddTutorRating.request();
    if (apiAddTutorRating.response.value) {
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

  // const filterTutorByTitle = (tutorUniFilter: string) => {
  //   students.value = allStudents.filter((x) =>
  //     x.title.startsWith(exerciseTitleFilter),
  //   );
  // };
  // const deleteTutor = async (tutorId: number) => {
  //   // Создание запроса на удаление тьютора через API
  //   const deleteTutorRequest = useApiRawRequest(`tutors/${tutorId}`, {
  //     method: 'DELETE',
  //   });
  
  //   // Выполнение запроса на удаление
  //   const res = await deleteTutorRequest();
  
  //   // Если статус ответа 200 (OK), что обозначает успешное удаление
  //   if (res.status === 200) {
  //     // Нахождение индекса удаляемого тьютора в массиве allTutors
  //     const index = allTutors.findIndex(tutor => tutor.id === tutorId);
  
  //     // Если тьютор найден в массиве, удаление его из массива
  //     if (index !== -1) {
  //       allTutors.splice(index, 1);
  //     }
  
  //     // Нахождение индекса удаляемого тьютора в массиве tutors.value
  //     const valueIndex = tutors.value.findIndex(tutor => tutor.id === tutorId);
  
  //     // Если тьютор найден в массиве, удаление его из массива
  //     if (valueIndex !== -1) {
  //       tutors.value.splice(valueIndex, 1);
  //     }
  //   }
  // };
   const deleteTutor = async (tutorId: number) => {
     const apiDeleteTutor = useApi<Tutor>('tutors/' + tutorId, {
       method: 'DELETE',
       headers: {
         Accept: 'application/json',
         'Content-Type': 'application/json',
       },
     });
  
     await apiDeleteTutor.request();
     if (apiDeleteTutor.response.value) {
      // Обновление списка тьюторов после удаления
      allTutors = allTutors.filter((tutor) => tutor.id !== tutorId);
      tutors.value = allTutors;
    }
  };

  return {
    tutors,
    load,
    searchTutorByName,
    getTutorById,
    addTutor,
    updateTutors,
    calculateRating,
    //deleteStudent,
    //filterTutorByTitle,
    deleteTutor,
    
  };


});




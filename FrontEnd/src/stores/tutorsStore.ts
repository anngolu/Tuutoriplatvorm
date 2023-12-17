import { Tutor } from '@/model/tutor';
import { ref } from 'vue';
import { defineStore } from 'pinia';
import { useApiRawRequest } from '@/model/api';
import useApi from '@/model/api';

export const useTutorsStore = defineStore('tutorsStore', () => {
  const apiGetTutors = useApi<Tutor[]>('tutors');
  const tutors = ref<Tutor[]>([]);
  let allTutors: Tutor[] = [];

  const loadTutors = async () => {
    await apiGetTutors.request();

    if (apiGetTutors.response.value) {
      return apiGetTutors.response.value!.sort((tutor1, tutor2) => {
        if (tutor1.name! > tutor2.name!) {
          return 1;
        }
        if (tutor1.name! < tutor2.name!) {
          return -1;
        }
        return 0;
      });
    }

    return [];
  };

  const load = async () => {
    allTutors = await loadTutors();
    tutors.value = allTutors;
  };

  const searchTutorByName = (name: string) => {
    return tutors.value.filter(
      (tutor) =>
        tutor.name?.toLocaleLowerCase().includes(name?.toLocaleLowerCase()),
    );
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

  const updateTutor = async (tutor: Tutor) => {
    const apiAddTutor = useApi<Tutor>('tutors/' + tutor.id, {
      method: 'PUT',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(tutor),
    });

    await apiAddTutor.request();
    load();
  };

  const deleteTutor = async (tutor: Tutor) => {
    const deleteTutorRequest = useApiRawRequest(`tutors/${tutor.id}`, {
      method: 'DELETE',
    });

    const res = await deleteTutorRequest();

    if (res.status === 204) {
      let id = tutors.value.indexOf(tutor);

      if (id !== -1) {
        tutors.value.splice(id, 1);
      }

      id = tutors.value.indexOf(tutor);

      if (id !== -1) {
        tutors.value.splice(id, 1);
      }
    }
  };

  return {
    tutors,
    load,
    searchTutorByName,
    getTutorById,
    addTutor,
    updateTutor,
    deleteTutor,
  };
});

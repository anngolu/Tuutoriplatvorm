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

  const getTutorById = async (id: number) => {
    const getTutorById = useApi<Tutor>('tutors/' + id);

    await getTutorById.request();

    if (getTutorById.response.value) {
      return getTutorById.response.value;
    }

    return null;
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

  const deleteTutor = async (tutorId: number) => {
    const deleteTutorRequest = useApiRawRequest(`tutors/${tutorId}`, {
      method: 'DELETE',
    });

    await deleteTutorRequest();
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

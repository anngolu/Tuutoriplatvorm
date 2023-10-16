import { Tutor, TutorGender, TutorStatus } from '@/model/tutor';
import { ref } from 'vue';
import { defineStore } from 'pinia';

export const useTutorsStore = defineStore('tutorsStore', () => {
  const tutors = ref<Tutor[]>([
    {
      name: 'Eesnimi1',
      surname: 'Tuutor1',
      code: '101',
      gender: TutorGender.Male,
      university: 'TalTech',
      faculty: 'IT',
      status: TutorStatus.NonActive,
      hourlyPrice: 10,
    },
    {
      name: 'Eesnimi2',
      surname: 'Tuutor2',
      code: '102',
      university: 'Tartu Ülikool',
      faculty: 'Loodusteadused',
      gender: TutorGender.Female,
      status: TutorStatus.Active,
      hourlyPrice: 20,
    },
  ]);

  const addTutor = (tutor: Tutor) => {
    tutors.value.push(tutor);
  };

  return { tutors, addTutor };
});

import { Schedule } from '@/model/schedule';
import { ref } from 'vue';
import { defineStore } from 'pinia';
import useApi from '@/model/api';

export const useScheduleStore = defineStore('scheduleStore', () => {
  const apiGetSchedule = useApi<Schedule[]>('schedule');
  const schedules = ref<Schedule[]>([]);
  let allSchedules: Schedule[] = [];

  const loadSchedule = async () => {
    await apiGetSchedule.request();

    if (apiGetSchedule.response.value) {
      return apiGetSchedule.response.value!;
    }

    return [];
  };

  const load = async () => {
    allSchedules = await loadSchedule();
    schedules.value = allSchedules;
  };

  const getTutorSchedule = (tutorId: number) => {
    return allSchedules.find((schedule) => schedule.tutorId === tutorId);
  };

  const getScheduleById = (id: number) => {
    return allSchedules.find((schedule) => schedule.id === id);
  };

  const addSchedule = async (schedule: Schedule) => {
    const apiAddSchedule = useApi<Schedule>('schedule  ', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(schedule),
    });

    await apiAddSchedule.request();
    if (apiAddSchedule.response.value) {
      allSchedules.push(apiAddSchedule.response.value!);
      schedules.value = allSchedules;
    }
  };

  // const updateSchedule = async (schedule: Schedule) => {
  //   const apiAddSchedule = useApi<Schedule>('schedule/' + schedule.id, {
  //     method: 'PUT',
  //     headers: {
  //       Accept: 'application/json',
  //       'Content-Type': 'application/json',
  //     },
  //     body: JSON.stringify(schedule),
  //   });

  //   await apiAddSchedule.request();
  //   if (apiAddSchedule.response.value) {
  //     load();
  //   }
  // };

  return {
    addSchedule,
    schedules,
    load,
    getScheduleById,
    getTutorSchedule,
    //updateSchedule,
  };
});

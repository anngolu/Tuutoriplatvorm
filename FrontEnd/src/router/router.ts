import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import TutorsVue from '@/views/Tutors.vue';
import AddTutorVue from '@/views/AddTutor.vue';
import StudentsVue from '@/views/Students.vue';
import AddStudentVue from '@/views/AddStudent.vue';
import MainPageVue from '@/views/MainPage.vue';
import ScheduleVue from '@/views/Schedule.vue';
import AddScheduleVue from '@/views/AddSchedule.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Avaleht',
    component: MainPageVue,
    props: { title: 'Avaleht' },
  },
  {
    path: '/tutors',
    name: 'Tuutorid',
    component: TutorsVue,
  },
  {
    path: '/newTutor',
    name: 'Lisa tuutor (tuutori registreerumine)',
    component: AddTutorVue,
  },
  {
    path: '/students',
    name: 'Tudengid',
    component: StudentsVue,
  },
  {
    path: '/newStudent',
    name: 'Lisa tudeng (tudengite registreerumine)',
    component: AddStudentVue,
  },
  {
    path: '/schedule',
    name: 'Tunniplaan',
    component: ScheduleVue
  },
  {
    path: '/newSchedule',
    name: 'SLisa tunniplaan',
    component: AddScheduleVue
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

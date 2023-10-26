import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import TutorsVue from '@/views/Tutors.vue';
import AddTutorVue from '@/views/AddTutor.vue';
import StudentsVue from '@/views/Students.vue';
import AddStudentVue from '@/views/AddStudent.vue';
import MainPageVue from '@/views/MainPage.vue';

//import MainVue from '@/views/Main.vue';

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
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

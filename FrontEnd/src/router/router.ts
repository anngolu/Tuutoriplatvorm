import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import TutorsVue from '@/views/Tutors.vue';
import AddTutorVue from '@/views/AddTutor.vue';
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
    name: 'Tudengid',
    component: TutorsVue,
    props: { title: 'Tuutorite nimekiri' },
  },
  {
    path: '/newTutor',
    name: 'Lisa tuutor (tuutori registreerumine)',
    component: AddTutorVue,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

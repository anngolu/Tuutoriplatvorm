import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import TutorsVue from '@/views/Tutors.vue';
import AddTutorVue from '@/views/AddTutor.vue';
import UpdateTutor from '@/views/UpdateTutor.vue';
import StudentsVue from '@/views/Students.vue';
import AddStudentVue from '@/views/AddStudent.vue';
import MainPageVue from '@/views/MainPage.vue';
import ScheduleVue from '@/views/Schedule.vue';
import AddScheduleVue from '@/views/AddSchedule.vue';
import LoginFormVue from '@/components/LoginForm.vue';
import loadToken from '@/model/auth';
import SignUp from '@/components/SignUp.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Pealeht',
    component: MainPageVue,
    props: { title: 'Pealeht' },
  },
  {
    path: '/tutors',
    name: 'Tuutorid',
    component: TutorsVue,
    meta: {
      requiresAuth: true 
    }
  },
  {
    path: '/newTutor/:id?',
    name: 'Lisa tuutor (tuutori registreerumine)',
    component: AddTutorVue,
    meta: {
      requiresAuth: true 
    }
  },
  {
    path: '/updateTutor',
    name: 'Muuda tuutori andmed',
    component: UpdateTutor,
  },
  {
    path: '/students',
    name: 'Tudengid',
    component: StudentsVue,
    meta: {
      requiresAuth: true 
    }
  },
  {
    path: '/newStudent',
    name: 'Lisa tudeng (tudengite registreerumine)',
    component: AddStudentVue,
    meta: {
      requiresAuth: true 
    }
  },
  {
    path: '/schedule',
    name: 'Tunniplaan',
    component: ScheduleVue,
    meta: {
      requiresAuth: true 
    }
  },
  {
    path: '/newSchedule',
    name: 'Lisa tunniplaan',
    component: AddScheduleVue,
    meta: {
      requiresAuth: true 
    }
  },

  {
    path: '/login',
    name: 'Login',
    component: LoginFormVue
  },
  // {
  //   path: '/signup',
  //   name: 'SignUp',
  //   component: SignUp
  // },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});


router.beforeEach( (to, from, next) => {
  if (to.meta.requiresAuth) {
    const token = loadToken();
    if (token) {
      // User is authenticated, proceed to the route
      next();
    } else {
      // User is not authenticated, redirect to login
      next('/login');
    }
  } else {
    // Non-protected route, allow access
    next();
  }
});

export default router;

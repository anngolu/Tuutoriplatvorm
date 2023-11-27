<template>
  <nav class="bg-blue-900">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="relative flex h-16 items-center justify-between">
        <div
          class="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start"
        >
          <div class="hidden sm:ml-6 sm:block">
            <div class="flex space-x-4">
              <router-link
                to="/"
                class="text-gray-300 hover:bg-gray-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-gray-900 text-white"
                aria-current="page"
                >Pealeht</router-link
              >

              <router-link
                to="/tutors"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                aria-current="page"
                >Tuutorid</router-link
              >

              <router-link
                to="/newtutor"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                >Lisa tuutor</router-link
              >

              <router-link
                to="/students"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                aria-current="page"
                >Tudengid</router-link
              >

              <router-link
                to="/newstudent"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                >Lisa tudeng</router-link
              >

              <router-link
                to="/schedule"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                aria-current="page"
                >Tunniplaan</router-link
              >
              <router-link
                to="/newSchedule"
                class="text-blue-300 hover:bg-blue-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                active-class="bg-blue-900 text-white"
                >Lisa tunniplaan</router-link
              >
              
            </div>
          </div>
        </div>
        <div class="flex flex-1 items-end justify-center sm:items-stretch sm:justify-end">
          <Button label="Logout" icon="pi pi-sign-out" severity="danger" v-on:click="logout()" v-if="token"/>
          <Button label="Login" icon="pi pi-sign-in" severity="primary" @click="$router.push('Login')" v-if="!token"/>
        </div>
      </div>
    </div>
  </nav>

  <router-view />
</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { useRouter } from 'vue-router';
import { useAuthStore } from './stores/authStore';

const router = useRouter();
const authStore = useAuthStore();
const { token } = storeToRefs(authStore);


const logout = () => {
  authStore.logout();
  router.push({ name: 'Pealeht' });
}

</script>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #12cc78aa);
}
</style>

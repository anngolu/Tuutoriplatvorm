<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
  
    <form class="max-w-md w-full space-y-8">
      <h1 class="font-bold ">Sisene või <router-link
        to="/signup"
        >Registreeru</router-link
      ></h1>
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">
          <div>
            <label for="username">Kasutajanimi</label>
            <input
              id="username"
              name="username"
              v-model="user.username"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Kasutajanimi"
            />
          </div>

          <div>
            <label for="password">Parool</label>
            <input
              type="password"
              id="password"
              name="password"
              v-model="user.password"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Parool"
            />
          </div>
        </div>

        <div>
          <button
            @click.prevent="submitForm"
            class="group relative w-full flex justify-center mt-6 py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Siseneda
          </button>
        </div>

        <div>
          <a href="/signup" class="p-button group relative w-full flex justify-center mt-6 py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-100 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-100">Registreeru</a>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { useAuthStore } from '@/stores/authStore';
import { useRouter } from 'vue-router';

const router = useRouter();
const authStore = useAuthStore();

const user: { username?: string; password?: string } = {
  username: undefined,
  password: undefined,
};

const submitForm = async () => {
  const token = await authStore.login(user.username!, user.password!);
  if (token) router.push({ name: 'Pealeht' });
};
</script>
@/model/auth @/stores/authStore

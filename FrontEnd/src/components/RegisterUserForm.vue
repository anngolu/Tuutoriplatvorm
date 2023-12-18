<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <h1 class="font-bold">Registreeru</h1>
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

          <div>
            <label for="role">Registreeruge end</label>
            <select
              id="role"
              name="role"
              v-model="user.role"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Roll"
            >
              <option v-if="authStore.isInRole(['Admin'])" value="Admin">Admin</option>
              <option value="Tutor">Tuutoriks</option>
              <option value="Student">Tudengiks</option>
            </select>
          </div>
        </div>

        <div>
          <button
            @click.prevent="submitForm"
            class="group relative w-full flex justify-center mt-6 py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Registreeru
          </button>
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

  const user: { username?: string; password?: string, role?: string } = {
    username: undefined,
    password: undefined,
    role: undefined
  };

  const submitForm = async () => {
    await authStore.signup(user.username!, user.password!, user.role!);
    router.push({ name: 'Login' });
  };
</script>
@/model/auth @/stores/authStore

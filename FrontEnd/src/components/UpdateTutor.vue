<template>
  <div
    class="min-h-full flex items-center justify-center flex-column py-12 px-4 sm:px-6 lg:px-8"
  >
    <div><h1 class="mr-5">Kontole edastamine...</h1></div>
    <div><ProgressSpinner style="width: 50px; height: 50px" strokeWidth="8" fill="var(--surface-ground)"
      animationDuration=".5s" aria-label="Custom ProgressSpinner" /></div>
  </div>
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useAccountStore } from '@/stores/accountStore';
import { useAuthStore } from '@/stores/authStore';

const router = useRouter();
const accoountStore = useAccountStore();
const authStore = useAuthStore();

onMounted(async () => {
  await accoountStore.load();
  // setTimeout(function () {}, 3000);

  if (!accoountStore.account) {
    return;
  }

  if (authStore.isTutor()) {
    setTimeout(
      () => router.push('/newtutor/' + accoountStore.account!.id),
      1000,
    );
  }

  if (authStore.isStudent()) {
    setTimeout(
      () => router.push('/newstudent/' + accoountStore.account!.id),
      1000,
    );
  }
});
</script>
@/model/tutor @/stores/tutorsStore

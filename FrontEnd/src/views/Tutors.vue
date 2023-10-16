<template>
  <TutorList :title="title" />
</template>

<script setup lang="ts">
import TutorList from '@/components/TutorList.vue';

defineProps<{ title: String }>();
</script>

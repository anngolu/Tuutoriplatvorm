<template>
  <StudentList :title="title" />
</template>

<script setup lang="ts">
import StudentList from '@/components/StudentList.vue';

defineProps<{ title: String }>();
</script>

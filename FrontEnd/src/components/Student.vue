<template>
    <div>
      {{ student.code }} :{{ student.name }} : {{ student.surname }} :
      {{ student.university }} : {{ student.subject }} {{ student.status }} :
      {{ student.gender }}
    </div>
  </template>
  <script setup lang="ts">
  import { Student } from '@/model/student';
  defineProps<{ student: Student }>();
  </script>
  @/model/tutor
  
<template>
  <div>
    {{ tutor.code }} :{{ tutor.name }} : {{ tutor.surname }} :
    {{ tutor.university }} : {{ tutor.faculty }} {{ tutor.status }} :
    {{ tutor.gender }} : {{ tutor.hourlyPrice }}
  </div>
</template>
<script setup lang="ts">
import { Tutor } from '@/model/tutor';
defineProps<{ tutor: Tutor }>();
</script>
@/model/tutor

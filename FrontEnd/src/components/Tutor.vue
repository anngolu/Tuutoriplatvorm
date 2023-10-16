<template>
  <div>
    {{ tutor.code }} :{{ tutor.name }} : {{ tutor.surname }} :
    {{ tutor.status }} : {{ tutor.gender }} : {{ tutor.birthday }}
  </div>
</template>
<script setup lang="ts">
import { Tutor } from '@/model/tutor';
defineProps<{ tutor: Tutor }>();
</script>
@/model/tutor

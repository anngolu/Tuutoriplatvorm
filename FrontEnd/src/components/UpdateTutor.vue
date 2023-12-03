<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">
      
          <button> Uuendame andmed kasutajale ID: {{  tutor.id }}</button> <br>
          <div>
            <label for="name">Sisesta kasutaja ID</label>
            <input
              id="id"
              name="id"
              v-model="tutor.id"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Kasutaja ID"
            />
          </div>        
        </div>

        <div>
          <button
            @click.prevent="submitForm"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            <span class="absolute left-0 inset-y-0 flex items-center pl-3">
            </span>
           Jätka
            
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { Tutor } from '@/model/tutor';
import { useTutorsStore } from '@/stores/tutorsStore';
import { Ref, ref, onMounted, computed , watch} from 'vue';
import { useRouter,useRoute } from 'vue-router';
  


const tutor: Ref<Tutor> = ref({
  id:''
});

const { getTutorById} = useTutorsStore();
const router = useRouter();
const route = useRoute();

watch(
      () => route.params.id,
       newId => {
        const tutorById= getTutorById(Number(newId));
        console.log("Kontroll: ",tutorById)
      }
    )


    

const submitForm = () => {
  console.log(1)
  if(tutor.value.id!==undefined){
    if (getTutorById(tutor.value.id)?.id==undefined){
    router.push('/newtutor/'+tutor.value.id);
    delete tutor.value.id
  } }
 
};



</script>
@/model/tutor @/stores/tutorsStore

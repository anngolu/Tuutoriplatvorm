<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">

          <div>
            <label for="tutor">Tutori nimi</label>
            <Dropdown 
            id="tutor"
            v-model="schedule.tutorId" 
            :options="tutors" 
            filter
            optionLabel="name" 
            optionValue="id"
            class="z-50 appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            placeholder="Vali tuutor"
            />
          </div>

          <div>
            <label for="subject">Aine</label>
            <MultiSelect
              id="subject"
              name="subject"
              v-model="schedule.subjects"
              display="chip"
              :options="subjects"
              optionValue="code"
              optionLabel="name"
              :maxSelectedLabels="3"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            >
            </MultiSelect>
          </div>

          <div>
            <label for="hourlyPrice">Tunnihind</label>
            <input
              type="number"
              id="hourlyPrice"
              name="hourlyPrice"
              v-model="schedule.hourlyPrice"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-blue-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            />
          </div>



          <div class="flex">
            <div class="flex-auto mr-4">
              <label for="startTime" class="font-bold block mb-2"
                >Alguse aeg</label
              >
              <Calendar
                v-model="schedule.startTime"
                name="startTime"
                placeholder="Alguse aeg"
                showTime
                hourFormat="24"
              />
            </div>

            <div class="flex-auto">
              <div class="mb-6">
                <label for="endTime" class="font-bold block mb-2"
                  >Lõpetamise aeg</label
                >
                <Calendar
                  v-model="schedule.endTime"
                  name="endTime"
                  placeholder="Lõpetamise aeg"
                  showTime
                  hourFormat="24"
                />
              </div>
            </div>
          </div>
        </div>

        <div>
          <button
            @click.prevent="submitForm"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            <span
              class="absolute left-0 inset-y-0 flex items-center pl-3"
            ></span>
            Lisa tunniplaanile
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { Subject, Schedule } from '@/model/schedule';
import { useScheduleStore } from '@/stores/scheduleStore';
import { Ref, onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import { useTutorsStore } from '@/stores/tutorsStore';
import { storeToRefs } from 'pinia';

const schedule: Ref<Schedule> = ref({
  tutorId: 0,
  name: '',
  subjects: [],
  hourlyPrice: 0,
  startTime: new Date(),
  endTime: new Date(),
});

const { addSchedule } = useScheduleStore();
const router = useRouter();
const tutorsStore = useTutorsStore();
const {tutors} = storeToRefs(tutorsStore);

const submitForm = () => {
  addSchedule({ ...schedule.value });

  schedule.value.name = '';
  schedule.value.subjects = [];
  schedule.value.hourlyPrice = 0;
  schedule.value.startTime = new Date();
  schedule.value.endTime = new Date();

  router.push({ name: 'Tunniplaan' });
};

const subjects = ref([
  { name: 'Economics', code: Subject.Economics },
  { name: 'Maths', code: Subject.Maths },
  { name: 'Programming', code: Subject.Programming },
  { name: 'Start up', code: Subject.Startup },
  { name: 'PE', code: Subject.PE },
  { name: 'Discrete Maths', code: Subject.DiscMaths },
]);

onMounted(() => {
  tutorsStore.load();
});

</script>
@/model/tutor @/stores/scheduleStore

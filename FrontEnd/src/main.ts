import { createApp } from 'vue';
import App from './App.vue';
import { createPinia } from 'pinia';
import 'virtual:windi.css';
import PrimeVue from 'primevue/config';
import 'primevue/resources/themes/saga-blue/theme.css'; //theme
import 'primevue/resources/primevue.min.css'; //core css
import 'primeicons/primeicons.css'; //icons
import router from './router/router';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Rating from 'primevue/rating';
import MultiSelect from 'primevue/multiselect';
import { setApiUrl } from './model/api';
import Calendar from 'primevue/calendar';
import Dropdown from 'primevue/dropdown';
import Button from 'primevue/button';
import Card from 'primevue/card';
import InputText from 'primevue/inputtext';
import Image from 'primevue/image';
import Avatar from 'primevue/avatar';
import ConfirmPopup from 'primevue/confirmpopup';
import ConfirmationService from 'primevue/confirmationservice';
import ProgressSpinner from 'primevue/progressspinner';



const getRuntimeConf = async () => {
  const runtimeConf = await fetch('/config/runtime-config.json');
  return await runtimeConf.json();
};

const app = createApp(App);

getRuntimeConf().then((json) => {
  setApiUrl(json.API_URL);

  app.use(createPinia());
  app.use(PrimeVue);
  app.use(router);
  app.use(ConfirmationService);

  app.component('DataTable', DataTable);
  app.component('Column', Column);
  app.component('Rating', Rating);
  app.component('MultiSelect', MultiSelect);
  app.component('Calendar', Calendar);
  app.component('Dropdown', Dropdown);
  app.component('Button', Button);
  app.component('Card', Card);
  app.component('InputText', InputText);
  app.component('Image', Image);
  app.component('Avatar', Avatar);
  app.component('ConfirmPopup', ConfirmPopup);
  app.component('ProgressSpinner', ProgressSpinner);

  app.mount('#app');
});

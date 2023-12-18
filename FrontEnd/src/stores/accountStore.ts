import useApi from '@/model/api';
import { Account } from '@/model/auth';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useAccountStore = defineStore('accountStore', () => {
  const apiGetAccount = useApi<Account>('account');
  const account = ref<Account>();

  const load = async () => {
    await apiGetAccount.request();

    if (apiGetAccount.response.value) {
      account.value = apiGetAccount.response.value;
      return apiGetAccount.response.value!;
    }

    return null;
  };

  return {
    load,
    account
  };
});

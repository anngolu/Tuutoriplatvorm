import loadToken, { TokenModel } from '@/model/auth';
import { defineStore } from 'pinia';
import useApi from '@/model/api';
import { ref } from 'vue';

export const useAuthStore = defineStore('authStore', () => {

  const token = ref<TokenModel|undefined>(loadToken());


  const login = async (username: string, password: string) => {
    const apiGetToken = useApi<TokenModel>('authenticate/login', {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({username, password}),
    });

    await apiGetToken.request();

    const responseValue = apiGetToken.response.value;
    if (responseValue && apiGetToken.status.value === 200) {
      localStorage.setItem("token", JSON.stringify(responseValue));  
      token.value = responseValue;
      return responseValue;
    } 
      
    token.value = undefined;
    localStorage.removeItem('token');

    return null;
  };

  const logout = () => {
    localStorage.removeItem('token');
    token.value = undefined;
  }

  return {
    login, logout, token
  }
  
});

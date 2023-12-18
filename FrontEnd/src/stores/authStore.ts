import loadToken, { TokenModel } from '@/model/auth';
import { defineStore } from 'pinia';
import useApi from '@/model/api';
import { ref } from 'vue';

export const useAuthStore = defineStore('authStore', () => {
  const token = ref<TokenModel | undefined>(loadToken());

  const login = async (username: string, password: string) => {
    const apiGetToken = useApi<TokenModel>('authenticate/login', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });
    await apiGetToken.request();
    const responseValue = apiGetToken.response.value;
    if (responseValue && apiGetToken.status.value === 200) {
      localStorage.setItem('token', JSON.stringify(responseValue));
      token.value = responseValue;
      return responseValue;
    }
    token.value = undefined;
    localStorage.removeItem('token');

    return null;
  };

  const signup = async (username: string, password: string, role: string) => {
    const apiRegister = useApi<TokenModel>('authenticate/register', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password, role }),
    });

    await apiRegister.request();
  };

  const logout = () => {
    localStorage.removeItem('token');
    token.value = undefined;
  };

  const isStudent = () => {
    const tokenJSON = getAuthToken()
    return tokenJSON && tokenJSON.roles?.includes('Student');
  };

  const isTutor = () => {
    const tokenJSON = getAuthToken()
    return tokenJSON && tokenJSON.roles?.includes('Tutor');
  };

  const isInRole = (roles: string[]): boolean => {
    const tokenJSON = getAuthToken()
    return (
      tokenJSON &&
      tokenJSON.roles?.filter((r: string) => roles.includes(r)).length > 0
    );
  };

  const isAuth = () => {
    return !!getAuthToken();
  };

  const getAuthToken = () => {
    const tokenString = localStorage.getItem('token');
    if (!tokenString) {
      false;
    }
    const tokenJSON = JSON.parse(tokenString!);
    return tokenJSON;
  }

  return {
    login,
    logout,
    token,
    signup,
    isStudent,
    isTutor,
    isInRole,
    isAuth,
  };
});

// import loadToken, { TokenModel } from '@/model/auth';
// import { defineStore } from 'pinia';
// import useApi from '@/model/api';
// import { ref } from 'vue';

// export const useAuthStore = defineStore('authStore', () => {

//   const token = ref<TokenModel|undefined>(loadToken());


//   const login = async (username: string, password: string) => {
//     const apiGetToken = useApi<TokenModel>('authenticate/login', {
//         method: 'POST',
//         headers: {
//           Accept: 'application/json',
//           'Content-Type': 'application/json',
//         },
//         body: JSON.stringify({username, password}),
//     });

//     await apiGetToken.request();

//     const responseValue = apiGetToken.response.value;
//     if (responseValue && apiGetToken.status.value === 200) {
//       localStorage.setItem("token", JSON.stringify(responseValue));  
//       token.value = responseValue;
//       return responseValue;
//     } 
      
//     token.value = undefined;
//     localStorage.removeItem('token');

//     return null;
//   };
//   const signup = async (username: string, password: string) => {
//     const apiGetToken = useApi<TokenModel>('authenticate/register-admin', {
//         method: 'POST',
//         headers: {
//           Accept: 'application/json',
//           'Content-Type': 'application/json',
//         },
//         body: JSON.stringify({username, password}),
//     });


//   const logout = () => {
//     localStorage.removeItem('token');
//     token.value = undefined;
//   }

//   return {
//     login, logout, token, signup
//   }
  
  
// }});


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

  // Метод для регистрации нового пользователя
  const signup = async (username: string, password: string) => {
    // Использование API для регистрации
    const apiRegister = useApi<TokenModel>('authenticate/register-admin', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });

    // Отправка запроса на сервер
    await apiRegister.request();

    // Обработка ответа от сервера
    const responseValue = apiRegister.response.value;
    if (responseValue && apiRegister.status.value === 200) {
      // Сохранение токена в локальном хранилище и обновление значения токена в хранилище Pinia
      localStorage.setItem('token', JSON.stringify(responseValue));
      token.value = responseValue;
      return responseValue;
    }

    // Если регистрация неудачна, сброс значения токена и удаление из локального хранилища
    token.value = undefined;
    localStorage.removeItem('token');

    return null;
  };
  const logout = () => {
    localStorage.removeItem('token');
    token.value = undefined;
  };
  return {
    login,
    logout,
    token,
    signup,
  };
});



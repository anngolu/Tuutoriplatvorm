import { ref, Ref } from 'vue';
import loadToken from './auth';

export type ApiRequest = () => Promise<void>;

export interface UseableApi<T> {
  response: Ref<T | undefined>;
  status: Ref<number | undefined>;
  request: ApiRequest;
}

let apiUrl = '';

export function setApiUrl(url: string) {
  apiUrl = url;
}

export default function useApi<T>(
  url: RequestInfo,
  options?: RequestInit,
): UseableApi<T> {
  const response: Ref<T | undefined> = ref();

  const status: Ref<number | undefined> = ref();

  const request: ApiRequest = async () => {
    const token = loadToken();
    if (token) {
      const headers = options?.headers ? new Headers(options.headers) : new Headers();
      headers.set("Authorization", `Bearer ${token.token}`);
      options = {...options, headers}
    }
    const res = await fetch(apiUrl + url, options);
    const data = await res.json();
    const statusCode = await res.status;
    status.value = statusCode;
    response.value = data;
  };

  return { response, status, request };
}



export function useApiRawRequest(url: RequestInfo, options?: RequestInit) {
  const request: () => Promise<Response> = async () => {
    return await fetch(apiUrl + url, options);
  };
  return request;
}
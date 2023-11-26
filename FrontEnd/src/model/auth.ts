export interface TokenModel{
    token: string;
    expiration: string;
    roles: string[];
}

export default function loadToken() : TokenModel|null {

    if(localStorage.getItem("token")){
        return JSON.parse(localStorage.getItem("token")!);
    }
  
    return null;
  };
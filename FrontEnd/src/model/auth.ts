export interface TokenModel{
    token: string;
    expiration: string;
    roles: string[];
}

export default function loadToken() : TokenModel|undefined {

    if(localStorage.getItem("token")){
        return JSON.parse(localStorage.getItem("token")!);
    }
  
    return undefined;
  };
import axios from 'axios';
import { monoURL, microURL, testUser } from './Constants.js';

const createTestUser = async (url) => {
  const response = await axios.post(`${url}/api/Auth/Register`, testUser);
  if((response.status < 200 || response.status > 399) && response.status !== 409)
    throw new Error(response);
}

export const getTestUserAuthToken = async (url) => {
  const response = await axios.post(`${url}/api/Auth/Login`, {email: testUser.email, password: testUser.password});
  if(response.status === 200)
    return response.data.token;
  throw new Error(response);
}

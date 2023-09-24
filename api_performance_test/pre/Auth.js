import axios from 'axios';
import { writeFileSync } from 'fs';
import { monoURL, microURL, testUser, protocol } from './Constants.js';

const createTestUser = async (url) => {
  const response = await axios.post(`${url}/api/Auth/Register`, testUser);
  if((response.status < 200 || response.status > 399) && response.status !== 409)
    throw new Error(response);
}

const getTestUserAuthToken = async (url) => {
  const response = await axios.post(`${url}/api/Auth/Login`, {email: testUser.email, password: testUser.password});
  if(response.status === 200)
    return response.data.token;
  throw new Error(response);
}

const saveTokenToFile = (url, token) => {
  writeFileSync(`${url}.token`, token, {flag: 'w+'}, (err) => {
    if (err)
      console.error(err);
    console.log(`Saved token to file ${url}.token`);
  });
}

// createTestUser(protocol+monoURL);
// createTestUser(protocol+microURL);
saveTokenToFile(monoURL, await getTestUserAuthToken(protocol+monoURL));
saveTokenToFile(microURL, await getTestUserAuthToken(protocol+microURL));

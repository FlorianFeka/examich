import * as http from 'http';
import { monoURL, microURL, testUser } from './Constants.js';

const getTestUserAuthToken = async (url) => {
  const optsions = {
    host: url,
    path: '/api/Auth/Login',
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json; charset=UTF-8'
    }
  };
  let result = '';
  const request = http.request(optsions, (res) => {
    if (res.statusCode < 200 && res.statusCode > 399) {
      console.error(`Did not get an OK from the server. Code: ${res.statusCode}`);
      console.error(res.statusMessage);
      res.resume();
      return null;
    }

    res.on('data', (chunk) => {
      result += chunk;
    });

    res.on('close', () => {
      console.log(JSON.parse(result));
    });
  });

  request.write(JSON.stringify({
    email: testUser.email,
    password: testUser.password,
  }));

  request.end();

  request.on('error', (err) => {
    console.error(`Encountered an error trying to make a request: ${err.message}`);
  });
  request.on('response', (res) => {
  });
}

const createTestUser = (url) => {
  const optsions = {
    host: url,
    path: '/api/Auth/Register',
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json; charset=UTF-8'
    }
  };
  let result = '';
  const request = http.request(optsions, (res) => {
    if (res.statusCode < 200 && res.statusCode > 399) {
      console.error(`Did not get an OK from the server. Code: ${res.statusCode}`);
      console.error(res.statusMessage);
      res.resume();
      return null;
    }


    res.on('data', (chunk) => {
      result += chunk;
    });

    res.on('close', () => {
      console.log(JSON.parse(result));
    });
  });

  request.write(JSON.stringify(testUser));

  request.end();

  request.on('error', (err) => {
    console.error(`Encountered an error trying to make a request: ${err.message}`);
  });
};

getTestUserAuthToken(microURL);
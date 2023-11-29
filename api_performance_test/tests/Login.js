import http from "k6/http";
import { protocol, monoURL, microURL } from '/home/feka/Documents/projects/FH_Project_Examich/api_performance_test/pre/Constants.js';

export const options = {
  scenarios: {
    constant_request_rate_30: {
      executor: 'constant-arrival-rate',
      rate: 30,
      timeUnit: '1m',
      duration: '2m',
      preAllocatedVUs: 1,
      maxVUs: 1,
    },
    constant_request_rate_1100: {
      executor: 'constant-arrival-rate',
      rate: 1100,
      timeUnit: '1m',
      duration: '2m',
      preAllocatedVUs: 1,
      maxVUs: 1,
    },
  },
};
const target = __ENV.MONO === 'true' ? monoURL : microURL;

export default function () {
  const url =
    `${protocol}${target}/api/Auth/Login`;
  const payload = JSON.stringify({
    email: "max@gmail.com",
    password: "password",
  });

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
    },
  };

  http.post(url, payload, params);
}

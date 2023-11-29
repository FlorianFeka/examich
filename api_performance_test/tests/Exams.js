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
    constant_request_rate_100100: {
      executor: 'constant-arrival-rate',
      rate: 100100,
      timeUnit: '1m',
      duration: '2m',
      preAllocatedVUs: 1,
      maxVUs: 1,
    },
  },
};
const target = typeof __ENV.TARGET_URL !== 'undefined' ? __ENV.TARGET_URL : __ENV.MONO === 'true' ? monoURL : microURL;
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/Exams/User`;

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
  };

  http.get(url, params);
}

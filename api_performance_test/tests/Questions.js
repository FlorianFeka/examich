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
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/Questions/Exam/00000000-0000-0000-0000-000000000002`;

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
  };

  const a = http.get(url, params);
  if(a.error_code === 500){
    console.log("############ ERROR");
    console.log(`################# ERROR: HIHIHI: ${a.body}`);
  }
}

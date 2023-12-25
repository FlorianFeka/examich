import http from "k6/http";
import { protocol, monoURL, microURL } from '/home/feka/Documents/projects/FH_Project_Examich/api_performance_test/pre/Constants.js';

export const options = {
  scenarios: {
    // constant_request_rate_30: {
    //   executor: 'constant-arrival-rate',
    //   rate: 30,
    //   timeUnit: '1m',
    //   duration: '2m',
    //   preAllocatedVUs: 1,
    //   maxVUs: 1,
    // },
    constant_request_rate_300000: {
      executor: 'constant-arrival-rate',
      rate: 300000,
      timeUnit: '1m',
      duration: '2m',
      preAllocatedVUs: 100,
      maxVUs: 200,
    },
  },
};
const target = microURL;
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/File/00000000-0000-0000-0000-000000000002/PDF?markAnswers=false`;

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
  };

  http.post(url, null, params);
}

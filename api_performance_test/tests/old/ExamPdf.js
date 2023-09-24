import http from "k6/http";
// import getTestUserAuthToken from './pre/Auth.js'
import { monoURL, microURL, testUser } from './pre/Constants.js';

export const options = {
  scenarios: {
    // define scenarios
    breaking: {
      executor: "ramping-vus",
      stages: [
        { duration: "10s", target: 20 },
        { duration: "50s", target: 20 },
        { duration: "50s", target: 40 },
        { duration: "50s", target: 60 },
        { duration: "50s", target: 80 },
        { duration: "50s", target: 10 },
        { duration: "50s", target: 10 },
        { duration: "50s", target: 10 },
        //....
      ],
    },
  },
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};

export default async function () {
  const url =
    `${microURL}/api/File/00000000-0000-0000-0000-000000000002/PDF?markAnswers=true`;
  const TOKEN = await getTestUserAuthToken(microURL);

  const params = {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
    timeout: "3600s",
    thresholds: {
      http_req_failed: ['rate<0.01'], // http errors should be less than 1%
      http_req_duration: ['p(0)<3600000'], // 95% of requests should be below 1h
    },
  };

  const a = http.post(url, null, params);
}

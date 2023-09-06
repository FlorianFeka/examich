import http from "k6/http";
import getTestUserAuthToken from './pre/Auth'
import { monoURL, microURL, testUser } from './Constants.js';

export const options = {
  stages: [
    { duration: '1m', target: 10 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 10 },
    { duration: '1m', target: 0 },
  ],
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

import http from "k6/http";
import { protocol, monoURL, microURL } from '/home/feka/Documents/projects/FH_Project_Examich/api_performance_test/pre/Constants.js';

export const options = {
  stages: [
    { duration: '1m', target: 300 },
    { duration: '1m', target: 300 },
    { duration: '2m', target: 900 },
    { duration: '2m', target: 900 },
    { duration: '2m', target: 300 },
    { duration: '1m', target: 300 },
  ],
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};
const target = monoURL;
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/Exams/00000000-0000-0000-0000-000000000002/PDF`;

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
  };

  http.post(url, null, params);
}

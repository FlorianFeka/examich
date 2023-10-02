import http from "k6/http";
import { protocol, monoURL, microURL } from '/home/feka/Documents/projects/FH_Project_Examich/api_performance_test/pre/Constants.js';

export const options = {
  // scenarios: {
  //   contacts: {
  //     executor: 'constant-vus',
  //     vus: 900,
  //     duration: '8m'
  //   }
  // },
  stages: [
    { duration: '30s', target: 10 },
    { duration: '30s', target: 10 },
    { duration: '30s', target: 60 },
    { duration: '1m', target: 60 },
    { duration: '30s', target: 10 },
    { duration: '30s', target: 10 },
    { duration: '30s', target: 0 },
  ],
  // stages: [
  //   { duration: '1m', target: 20 },
  //   { duration: '1m', target: 20 },
  //   { duration: '2m', target: 80 },
  //   { duration: '2m', target: 80 },
  //   { duration: '2m', target: 20 },
  //   { duration: '1m', target: 20 },
  //   { duration: '1m', target: 0 },
  // ],
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};
const target = monoURL;
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/Exams/00000000-0000-0000-0000-000000000002/PDF?markAnswers=false`;

  const params = {
    timeout: '800s',
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${TOKEN}`,
    },
  };

  http.post(url, null, params);
}

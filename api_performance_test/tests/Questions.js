import http from "k6/http";
import { protocol, monoURL, microURL } from '/home/feka/Documents/projects/FH_Project_Examich/api_performance_test/pre/Constants.js';

export const options = {
  scenarios: {
    // define scenarios
    breaking: {
      executor: "ramping-vus",
      stages: [
        { duration: '1m', target: 300 },
        { duration: '1m', target: 300 },
        { duration: '2m', target: 900 },
        { duration: '4m', target: 900 },
        { duration: '2m', target: 300 },
        { duration: '1m', target: 300 },
        { duration: '1m', target: 0 },
        //....
      ],
    },
  },
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};
const target = __ENV.MONO === 'true' ? monoURL : microURL;
const TOKEN = open(`../${target}.token`);

export default async function () {
  const url =
    `${protocol}${target}/api/Questions/Exam/00000000-0000-0000-0000-000000000002`;

  const params = {
    // params: '300sec',
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

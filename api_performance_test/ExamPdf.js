import http from "k6/http";
const TOKEN =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYzQ1NWU2NS03MDNjLTQ3MDMtOGFiNy0wMzM3ZGRjZGMyMDMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Im1heEBnbWFpbC5jb20iLCJleHAiOjE3MTYyMDM0OTEsImlzcyI6Ind3dy5leGFtaWNoLmlvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMS8ifQ.Od9B6dHL9JbkzNYNOA0UOZc7cmjyZrq-O7EvD_ynLJU";

export const options = {
  stages: [
    { duration: '1m', target: 10 },
//    { duration: '1m', target: 20 },
//    { duration: '1m', target: 0 },
  ],
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};

export default function () {
  const url =
    "http://k1s.fillerserver.net:30001/api/File/00000000-0000-0000-0000-000000000002/PDF?markAnswers=true";

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

import http from "k6/http";
const TOKEN =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJiOGIxZTVlMS0wMzc0LTRjODQtOTY0OS1iNDZjNmFjMzVkNDUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Im1heEBnbWFpbC5jb20iLCJleHAiOjE2OTU1NjE5MzcsImlzcyI6Ind3dy5leGFtaWNoLmlvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMS8ifQ.XOQ6YNHpnpf4z5X4Q3DcOTihuMHsZWMgqlIyMqQyI7I";

export default function () {
  const url =
    "http://localhost:5000/api/Exams/00000000-0000-0000-0000-000000000002/PDF?markAnswers=true";

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
  console.log(a.status);
}
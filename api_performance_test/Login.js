import http from "k6/http";

export const options = {
  stages: [
    { duration: '10s', target: 10 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 30 },
    { duration: '1m', target: 30 },
    { duration: '1m', target: 40 },
    { duration: '1m', target: 40 },
    { duration: '1m', target: 50 },
    { duration: '1m', target: 50 },
    { duration: '1m', target: 40 },
    { duration: '1m', target: 40 },
    { duration: '1m', target: 30 },
    { duration: '1m', target: 30 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 10 },
    { duration: '1m', target: 10 },
    { duration: '1m', target: 0 },
  ],
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};

export default function () {
  const url = 'http://k1s.fillerserver.net/api/Auth/Login';
  const payload = JSON.stringify({
    email: "max@gmail.com",
    password: "password",
  });

  const params = {
    headers: {
      "Content-Type": "application/json",
    },
  };

  http.post(url, payload, params);
}

import http from "k6/http";

export const options = {
  hosts: {
    'mo.no': '192.168.178.105:30002',
    'mi.cro': '192.168.178.105'
  },
  stages: [
    { duration: '1s', target: 10 },
    { duration: '1m', target: 10 },
    { duration: '1m', target: 20 },
    { duration: '1m', target: 0 },
  ],
//  thresholds: { http_req_duration: ['avg<100', 'p(95)<200'] },
  noConnectionReuse: true,
  userAgent: 'MyK6UserAgentString/1.0',
};

export default function () {
  const url = 'http://mo.no/api/Auth/Login';
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

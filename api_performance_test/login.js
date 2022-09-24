import http from "k6/http";

export default function () {
  const url = "http://localhost:5000/api/Login";
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

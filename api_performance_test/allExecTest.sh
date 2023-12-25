#!/bin/bash

export K6_INFLUXDB_ADDR=https://influxdbb.spiegeleione.fillerserver.net 
export K6_INFLUXDB_ORGANIZATION=examich
export K6_INFLUXDB_TOKEN=lbvnJ4mE0c5XL3Au5mopYPiW7iY_YJS1j6YyntvmdIxF5v36kXRjkll2rVQglgbqthAx7DcC-nYaM6y5Exlshg==
export K6_INFLUXDB_PUSH_INTERVAL=5s

K6_INFLUXDB_BUCKET=tmp_new_big ./k6 run -e MONO=false -o xk6-influxdb tests/Exams.js
K6_INFLUXDB_BUCKET=tmp_new_big ./k6 run -e MONO=true -o xk6-influxdb tests/Exams.js
K6_INFLUXDB_BUCKET=tmp_new_big ./k6 run -e MONO=false -o xk6-influxdb tests/FileMicro.js
K6_INFLUXDB_BUCKET=tmp_new_big ./k6 run -e MONO=true -o xk6-influxdb tests/FileMono.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=false -o xk6-influxdb tests/Login.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=true -o xk6-influxdb tests/Login.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=false -o xk6-influxdb tests/Questions.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=true -o xk6-influxdb tests/Questions.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=false -o xk6-influxdb tests/Users.js
# K6_INFLUXDB_BUCKET=tmp_small ./k6 run -e MONO=true -o xk6-influxdb tests/Users.js


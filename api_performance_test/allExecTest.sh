#!/bin/bash

export K6_INFLUXDB_ADDR=https://influxdbb.spiegeleione.fillerserver.net 
export K6_INFLUXDB_ORGANIZATION=examich
export K6_INFLUXDB_TOKEN=lbvnJ4mE0c5XL3Au5mopYPiW7iY_YJS1j6YyntvmdIxF5v36kXRjkll2rVQglgbqthAx7DcC-nYaM6y5Exlshg==
export K6_INFLUXDB_PUSH_INTERVAL=4s

K6_INFLUXDB_BUCKET=examich_exam_micro ./k6 run --verbose -e MONO=false -o xk6-influxdb tests/Exams.js
K6_INFLUXDB_BUCKET=examich_exam_mono ./k6 run --verbose -e MONO=true -o xk6-influxdb tests/Exams.js
K6_INFLUXDB_BUCKET=examich_file_micro ./k6 run --verbose -e MONO=false -o xk6-influxdb tests/FileMicro.js
K6_INFLUXDB_BUCKET=examich_file_mono ./k6 run --verbose -e MONO=true -o xk6-influxdb tests/FileMono.js
K6_INFLUXDB_BUCKET=examich_login_micro ./k6 run --verbose -e MONO=false -o xk6-influxdb tests/Login.js
K6_INFLUXDB_BUCKET=examich_login_mono ./k6 run --verbose -e MONO=true -o xk6-influxdb tests/Login.js
K6_INFLUXDB_BUCKET=examich_question_micro ./k6 run --verbose -e MONO=false -o xk6-influxdb tests/Questions.js
K6_INFLUXDB_BUCKET=examich_question_mono ./k6 run --verbose -e MONO=true -o xk6-influxdb tests/Questions.js
K6_INFLUXDB_BUCKET=examich_user_micro ./k6 run --verbose -e MONO=false -o xk6-influxdb tests/Users.js
K6_INFLUXDB_BUCKET=examich_user_mono ./k6 run --verbose -e MONO=true -o xk6-influxdb tests/Users.js
#!/bin/bash

K6_INFLUXDB_ADDR=https://influxdbb.spiegeleione.fillerserver.net K6_INFLUXDB_ORGANIZATION=examich K6_INFLUXDB_BUCKET=$1 K6_INFLUXDB_TOKEN=lbvnJ4mE0c5XL3Au5mopYPiW7iY_YJS1j6YyntvmdIxF5v36kXRjkll2rVQglgbqthAx7DcC-nYaM6y5Exlshg== ./k6 run -o xk6-influxdb $2
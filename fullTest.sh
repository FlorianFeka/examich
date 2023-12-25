#!/bin/bash

sed -i -e 's/replicas: [0-9]/replicas: 1/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 1/g' mono.yaml
./redeployMono.sh latest
./redeployMicro.sh latest
sleep 120
cd api_performance_test
# sed -i -e 's/K6_INFLUXDB_BUCKET=tmp_[0-9]/K6_INFLUXDB_BUCKET=tmp_1/g' allExecTest.sh
./allExecTest.sh

cd ..
sed -i -e 's/replicas: [0-9]/replicas: 2/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 2/g' mono.yaml
./redeployMono.sh latest
./redeployMicro.sh latest
sleep 120
cd api_performance_test
# sed -i -e 's/K6_INFLUXDB_BUCKET=tmp_[0-9]/K6_INFLUXDB_BUCKET=tmp_2/g' allExecTest.sh
./allExecTest.sh

cd ..
sed -i -e 's/replicas: [0-9]/replicas: 4/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 4/g' mono.yaml
./redeployMono.sh latest
./redeployMicro.sh latest
sleep 220
cd api_performance_test
# sed -i -e 's/K6_INFLUXDB_BUCKET=tmp_[0-9]/K6_INFLUXDB_BUCKET=tmp_4/g' allExecTest.sh
./allExecTest.sh
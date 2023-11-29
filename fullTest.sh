#!/bin/bash

sed -i -e 's/replicas: [0-9]/replicas: 1/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 1/g' mono.yaml
./redeployMono.sh
./redeployMicro.sh
sleep 120
cd api_performance_test
./allExecTest.sh

cd ..
sed -i -e 's/replicas: [0-9]/replicas: 2/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 2/g' mono.yaml
./redeployMono.sh
./redeployMicro.sh
sleep 120
cd api_performance_test
./allExecTest.sh

cd ..
sed -i -e 's/replicas: [0-9]/replicas: 4/g' dmicro.yaml
sed -i -e 's/replicas: [0-9]/replicas: 4/g' mono.yaml
./redeployMono.sh
./redeployMicro.sh
sleep 120
cd api_performance_test
./allExecTest.sh
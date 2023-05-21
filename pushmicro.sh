#!/bin/bash

cd backend_microservice/Examich_User_Service
docker build --no-cache -t registry.feka.info/examich-microservice-user:$1 -t registry.feka.info/examich-microservice-user:latest .
docker push registry.feka.info/examich-microservice-user:$1
docker push registry.feka.info/examich-microservice-user:latest
cd ../..

cd backend_microservice/Examich_Service
docker build --no-cache -t registry.feka.info/examich-microservice-exam:$1 -t registry.feka.info/examich-microservice-exam:latest .
docker push registry.feka.info/examich-microservice-exam:$1
docker push registry.feka.info/examich-microservice-exam:latest
cd ../..

cd backend_microservice/Examich_PDF_Service
docker build --no-cache -t registry.feka.info/examich-microservice-pdf:$1 -t registry.feka.info/examich-microservice-pdf:latest .
docker push registry.feka.info/examich-microservice-pdf:$1
docker push registry.feka.info/examich-microservice-pdf:latest
cd ../..


#!/bin/bash

cd backend_microservice/Examich_User_Service
docker build -t registry.feka.info/micro-user:$1 .
docker push registry.feka.info/micro-user:$1
cd ../..

cd backend_microservice/Examich_Service
docker build -t registry.feka.info/micro-exam:$1 .
docker push registry.feka.info/micro-exam:$1
cd ../..

cd backend_microservice/Examich_PDF_Service
docker build -t registry.feka.info/micro-pdf:$1 .
docker push registry.feka.info/micro-pdf:$1
cd ../..

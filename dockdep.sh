#!/bin/bash

cd backend_microservice/Examich_User_Service
docker build -t dockernexus.spiegeleione.fillerserver.net/examich/micro-user:$1 .
docker push dockernexus.spiegeleione.fillerserver.net/examich/micro-user:$1
cd ../..

cd backend_microservice/Examich_Service
docker build -t dockernexus.spiegeleione.fillerserver.net/examich/micro-exam:$1 .
docker push dockernexus.spiegeleione.fillerserver.net/examich/micro-exam:$1
cd ../..

cd backend_microservice/Examich_PDF_Service
docker build -t dockernexus.spiegeleione.fillerserver.net/examich/micro-pdf:$1 .
docker push dockernexus.spiegeleione.fillerserver.net/examich/micro-pdf:$1
cd ../..

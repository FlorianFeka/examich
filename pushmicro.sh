#!/bin/bash

cd backend_microservice/Examich_User_Service
docker build --no-cache -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-user:$1 -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-user:latest .
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-user:$1
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-user:latest
cd ../..

cd backend_microservice/Examich_Service
docker build --no-cache -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-exam:$1 -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-exam:latest .
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-exam:$1
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-exam:latest
cd ../..

cd backend_microservice/Examich_PDF_Service
docker build --no-cache -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-pdf:$1 -t dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-pdf:latest .
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-pdf:$1
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-microservice-pdf:latest
cd ../..


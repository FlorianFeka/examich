#!/bin/bash


cd backend_microservice/Examich_User_Service
docker build -t micro-user:v$1 .
cd ../..
docker save micro-user:v$1 > micro-userv$1.tar
microk8s ctr image import micro-userv$1.tar

cd backend_microservice/Examich_Service
docker build -t micro-exam:v$1 .
cd ../..
docker save micro-exam:v$1 > micro-examv$1.tar
microk8s ctr image import micro-examv$1.tar

cd backend_microservice/Examich_PDF_Service
docker build -t micro-pdf:v$1 .
cd ../..
docker save micro-pdf:v$1 > micro-pdfv$1.tar
microk8s ctr image import micro-pdfv$1.tar

#!/bin/bash


cd backend_microservice/Examich_User_Service
docker build --no-cache -t florianfeka/micro-user:v$1 .
cd ../..
docker save florianfeka/micro-user:v$1 > micro-userv$1.tar
microk8s ctr image import micro-userv$1.tar

cd backend_microservice/Examich_Service
docker build --no-cache -t florianfeka/micro-exam:v$1 .
cd ../..
docker save florianfeka/micro-exam:v$1 > micro-examv$1.tar
microk8s ctr image import micro-examv$1.tar

cd backend_microservice/Examich_PDF_Service
docker build --no-cache -t florianfeka/micro-pdf:v$1 .
cd ../..
docker save florianfeka/micro-pdf:v$1 > micro-pdfv$1.tar
microk8s ctr image import micro-pdfv$1.tar

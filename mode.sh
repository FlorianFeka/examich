#!/bin/bash


cd backend/Examich
docker build -t mono:$1 .
docker save mono:$1 > monov$1.tar
microk8s ctr image import monov$1.tar
cd ../..

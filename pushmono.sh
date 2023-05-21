#!/bin/bash


cd backend/Examich
docker build --no-cache -t registry.feka.info/examich-monolith:$1 -t registry.feka.info/examich-monolith:latest .
docker push registry.feka.info/examich-monolith:$1 
docker push registry.feka.info/examich-monolith:latest
cd ../..

#!/bin/bash


cd backend/Examich
docker build --no-cache -t dockernexus.spiegeleione.fillerserver.net/examich/examich-monolith:$1 -t dockernexus.spiegeleione.fillerserver.net/examich/examich-monolith:latest .
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-monolith:$1 
docker push dockernexus.spiegeleione.fillerserver.net/examich/examich-monolith:latest
cd ../..

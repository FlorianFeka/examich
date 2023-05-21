#!/bin/bash

./pushmicro.sh $1
kubectl delete -f dmicro.yaml && kubectl apply -f dmicro.yaml
kubectl get pods
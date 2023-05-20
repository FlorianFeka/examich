#!/bin/bash

./pushmono.sh $1
kubectl delete -f mono.yaml && kubectl apply -f mono.yaml
kubectl get pods
#!/bin/bash

# ./pushmicro.sh $1
kubectl --kubeconfig /home/feka/.kube/config delete -f dmicro.yaml && kubectl --kubeconfig /home/feka/.kube/config apply -f dmicro.yaml
kubectl --kubeconfig /home/feka/.kube/config get pods
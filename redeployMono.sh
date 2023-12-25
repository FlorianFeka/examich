#!/bin/bash

# ./pushmono.sh $1
kubectl --kubeconfig /home/feka/.kube/config delete -f mono.yaml && kubectl --kubeconfig /home/feka/.kube/config apply -f mono.yaml
kubectl --kubeconfig /home/feka/.kube/config get pods
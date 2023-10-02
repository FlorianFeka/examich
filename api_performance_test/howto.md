```sh
node Auth.js

# Set TCP to reuse so the load test won't fail
sudo sysctl -w net.ipv4.tcp_tw_reuse=1

# To check if set https://k6.io/docs/misc/fine-tuning-os/ or https://k6.io/docs/testing-guides/running-large-tests/
cat /proc/sys/net/ipv4/tcp_tw_reuse
ulimit -n 5000
sysctl -w net.ipv4.ip_local_port_range="16384 65000"

./execTest.sh <bucket_name> <name_of_test.js>
# or
./allExecTest.sh
```

Done:
Login.js
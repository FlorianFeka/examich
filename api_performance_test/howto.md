```sh
node Auth.js

# Set TCP to reuse so the load test won't fail
sudo sysctl -w net.ipv4.tcp_tw_reuse=1

# To check if set
cat /proc/sys/net/ipv4/tcp_tw_reuse

./execTest.sh <bucket_name> <name_of_test.js>
```

Done:
Login.js
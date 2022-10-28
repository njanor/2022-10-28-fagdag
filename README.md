sudo apt-get update && sudo apt-get install redir
redir :8081 cosmosdb:8081
curl -k https://cosmosdb:8081/_explorer/emulator.pem > emulatorcert.crt
sudo cp emulatorcert.crt /usr/local/share/ca-certificates/ & sudo update-ca-certificates
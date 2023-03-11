start-process -FilePath WindowsApp.exe -ArgumentList "App1", "App2"

docker run -d -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
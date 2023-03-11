const webSocket = new WebSocket('ws://localhost:59521/ws');
const messageReceiveListeners = [];

webSocket.addEventListener('open', event => {
    console.log('WebSocket connection established');

    // Send a message to the server
    webSocket.send('Hello, server!');
});

webSocket.addEventListener('message', event => {
    console.log(`Received message from server: ${event.data}`);
    messageReceiveListeners.forEach((listener) => listener(event.data))
    //// Send another message to the server
    //webSocket.send('Hello again, server!');
});

webSocket.addEventListener('close', event => {
    console.log('WebSocket connection closed');
});

const sendMessage = (message) => {
    console.log(`Message send to server: ${message}`);
    webSocket.send(message);
}

const registerMessageReceiveListener = (listener) => {
    messageReceiveListeners.push(listener);
} 


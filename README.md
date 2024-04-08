# How to test this application

1. Run the application via `dotnet run`
2. Copy the URL from the browser.
3. Change `https://` to `wss://` and add this URL to postman as Socket connection.
4. Run the following command in the Postman (COPY IT DIRECTLY FROM HERE!!):
5. `{"protocol":"json","version":1}
    {
        "type": 1,
        "target": "GetClientId",
        "arguments": []
    }`
6. Copy value from arguments in Postman response.
7. Insert them into Swagger "try it out: `GetSpecificClient` connectionId parameter value.
8. Click Execute.
9. In Postman you can see the message from SignalR.

# Description
We can receive the whole big request with signalR connectionId (clientId) via API, split it into so many requests so we want to, and send them via sockets, using this connectionId, as soon as they are completed.

# Class overview
- IMessageHub - interface for custom SignalR hub
- MessageHubClient - client, which uses type-specified SignalR hub, which uses the IMessageHub interface. You can directly call this class from WebSocket to receive the ConnectionId (ClientId).
- Controllers/ProductOfferController - Controller, which provides an API to make big requests, which will make responses via SignalR.


   

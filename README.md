# How to test this application

1. Run the application via `dotnet run`
2. Copy the URL from the browser
3. Change `https://` to `wss://` and add this URL to postman as Socket connection
4. Run the following command in the Postman:
5. `{"protocol":"json","version":1}
    {
        "type": 1,
        "target": "GetClientId",
        "arguments": []
    }`
6. Copy value from arguments in Postman response
7. Insert them into Swagger "try it out: `GetSpecificClient` connectionId parameter value
8. Click Execute
9. In postman you can see the message from SignalR

# Description
We can receive the whole big request with signalR connectionId (clientId) via API, split it into so many requests so we want to, and send them via sockets, using this connectionId, as soon as they completed.

   

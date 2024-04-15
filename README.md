# How to test this application

1. Run the application via `dotnet run`
2. Create a Socket connection in Postman with the following URL: `wss://localhost:7189/offers`.
3. Click "Connect".
4. Run the following command in the Postman (COPY IT DIRECTLY FROM HERE!!): # You can change TestUser for your username
   `
    {"protocol":"json","version":1} 
    { "type": 1, "target": "SetClientConnectionPair", "arguments": ["TestUser"] }
   `
7. You can try the following swagger actions:
   7.1. NotifyAllViaDataByTenantId - insert the correct tenantId (4, 13, 16 ONLY!) - will be notified of ALL connections with these data.
   7.2. Send all Hierarchies - returns All hierarchies for all connected users. (Simulating of loading data enabled).
   7.2 NotifyByTenantIdAndUserName - returns specified hierarchy only to specified user (need "SetClientConnectionPair" executed in step 4)
9. Click Execute.
10. In Postman you can see the message from SignalR.

# Description
We can receive the whole big request with signalR connectionId (clientId) via API, split it into so many requests so we want to, and send them via sockets, using this connectionId, as soon as they are completed.

# Class overview
- IMessageHub - interface for custom SignalR hub
- MessageHubClient - client, which uses type-specified SignalR hub, which uses the IMessageHub interface. You can directly call this class from WebSocket to receive the ConnectionId (ClientId).
- Controllers/HierarchyController - Controller, which provides an API to make big requests, which will make responses via SignalR.


   

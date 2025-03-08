# Ocelot

## Introduction

Ocelot is a .NET API Gateway that provides a unified entry point for microservices. It is designed to handle routing, load balancing, and other cross-cutting concerns in a microservices architecture. Ocelot is lightweight and easy to configure, making it a popular choice for developers looking to implement an API Gateway in their applications.

## How to

### Add a service to the gateway

In Ocelot, you can add a service to the gateway by defining a route in the `ocelot.json` configuration file. Here is an example of how to do this:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/orders/{orderId}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 5001
        }
      ],
      "UpstreamPathTemplate": "/orders/{orderId}",
      "UpstreamHttpMethod": [ "GET" ]
    }
  ]
}
```
In this example, we define a route that maps incoming requests to the `/orders/{orderId}` endpoint to the downstream service running on `localhost:5001` at the `/api/orders/{orderId}` endpoint. The `UpstreamHttpMethod` specifies that this route only accepts GET requests.

# K6 Load Testing Demo for .NET Web API

This project is a demo for performing load testing using [K6](https://k6.io/) on a simple .NET 8 Web API.

It contains:

- Public and secure endpoints
- JWT-based authentication
- In-memory seeded data (users and products)
- Three K6 test scripts

## Blog

Read the full blog post here: [How to Load Test a .NET API Using K6](https://wntech.hashnode.dev/load-testing-net-apis-with-k6-a-developers-guide)

## How to Run This Project

```bash
git clone https://github.com/WaleedNaveed/blog-k6-dotnet-loadtest.git
cd blog-k6-dotnet-loadtest
dotnet run
```

> Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

The API will start at:  
**https://localhost:7061**

## Load Test Scripts

Navigate to the `load-tests` folder and run any script using K6.

> ⚠️ Since the API runs on HTTPS (localhost), use the `--insecure-skip-tls-verify` flag.

### 1. Public Endpoint Test

```bash
k6 run --insecure-skip-tls-verify publicEndpointTest.js
```

### 2. Secure Endpoint with Token Fetch

```bash
k6 run --insecure-skip-tls-verify secureEndpointWithTokenFetch.js
```

### 3. Secure Endpoint with Hardcoded Token

```bash
k6 run --insecure-skip-tls-verify secureEndpointWithHardcodedToken.js
```

## Users (Seeded)

The following user is seeded by default for login testing:

```json
{
  "username": "admin@example.com",
  "password": "123456"
}
```

## API Endpoints

- `GET /api/Product/public` — public access  
- `GET /api/Product/secure?id={id}` — requires JWT  
- `POST /api/Auth/login` — get JWT token



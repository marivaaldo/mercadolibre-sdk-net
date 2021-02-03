# mercadolibre-sdk-net
.NET 5 wrapper for Mercado Libre

## How to Use

This minimal example.

```csharp
...

var meli = new Meli(<clientId>, "<clientSecret>");

var authUrl = meli.GetAuthUrl(AuthUrls.MLB, "https://localhost:5000/ml")

...
```

## Links

- GitHub Repo: [marivaaldo/mercadolibre-sdk-net](https://github.com/marivaaldo/mercadolibre-sdk-net)

# mercadolibre-sdk-net
.NET 5 wrapper for Mercado Libre

![Mercado Libre SDK .NET - CI](https://github.com/marivaaldo/mercadolibre-sdk-net/workflows/Mercado%20Libre%20SDK%20.NET%20-%20CI/badge.svg)

![Mercado Libre SDK .NET - Release](https://github.com/marivaaldo/mercadolibre-sdk-net/workflows/Mercado%20Libre%20SDK%20.NET%20-%20Release/badge.svg)

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

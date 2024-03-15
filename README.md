# WebApplication1

#application.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Jwt": {
    "Key": "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm", // any statement to write it.
    "Issuer": "JWTAuthenticationServer",
    "Audience": "JWTServicePostmanClient",
    "Subject": "JWTServiceAccessToken"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-IJ1ETP0;Initial Catalog=angular16_core8_api;Persist Security Info=True;User ID=sa;Password=natrix2022;TrustServerCertificate=True"
  },
  "AllowedHosts": "*"
}

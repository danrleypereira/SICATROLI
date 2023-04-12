## install .NET 7
wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-7.0

## create new webapi using template
dotnet new webapi -lang "C#" --name dal --framework "net7.0" --output . --auth SingleOrg --client-id 11111111-8709-4321-11111111111111111 --tenant-id 22222222-1304-1997-0987-222222222222 --use-program-main
dotnet dev-certs https --trust
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 7.0.5
dotnet add package Microsoft.EntityFrameworkCore.Design -v 7.0.4
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL -v 7.0.3
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
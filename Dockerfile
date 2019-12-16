#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Sofomo/Sofomo.csproj", "Sofomo/"]
COPY ["Sofomo.Logic/Sofomo.Logic.csproj", "Sofomo.Logic/"]
COPY ["Common/Sofomo.Common.csproj", "Common/"]
COPY ["Sofomo.Data/Sofomo.Data.csproj", "Sofomo.Data/"]
COPY ["Sofomo.Models/Sofomo.Models.csproj", "Sofomo.Models/"]
RUN dotnet restore "Sofomo/Sofomo.csproj"
COPY . .
WORKDIR "/src/Sofomo"
RUN dotnet build "Sofomo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sofomo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sofomo.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
COPY bin/pub/ /root/
WORKDIR /root/
ENV ASPNETCORE_URLS="http://*:80"
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "BookInfo.dll"]

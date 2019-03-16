# download a base image from the repository
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
# set the working directory for the Docker image
WORKDIR /app
# set the environment variable for testing, remove this for production
ENV ASPNETCORE_MEMDB True
ENV ASPNETCORE_ENVIRONMENT Development

# copy the project file into the image and restore dependencies
COPY BookInfo.csproj ./
RUN dotnet restore

# copy the source code and build it
COPY . ./
RUN dotnet publish -c Release -o out

# run the web app
ENTRYPOINT ["dotnet", "out/BookInfo.dll"] 
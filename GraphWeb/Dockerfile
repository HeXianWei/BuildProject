#FROM microsoft/dotnet:1.0.1-runtime
#FROM registry.alauda.cn/longhronshen/docker-dotnet-libgdiplus
FROM microsoft/aspnetcore:2.0.8

COPY ./artifacts /app
RUN mkdir -p /app/logs/
WORKDIR /app

EXPOSE 5000
ENV ASPNETCORE_ENVIRONMENT Production

ENTRYPOINT ["dotnet", "GraphWeb.dll"]
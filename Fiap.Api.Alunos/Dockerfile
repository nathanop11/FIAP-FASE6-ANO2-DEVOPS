# Etapa de base - Define o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build - Prepara a compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto (somente o .csproj) e restaura as dependências
COPY ["Fiap.Api.Alunos/Fiap.Api.Alunos.csproj", "Fiap.Api.Alunos/"]
RUN dotnet restore "Fiap.Api.Alunos/Fiap.Api.Alunos.csproj"

# Copia todo o restante do código para o container
COPY Fiap.Api.Alunos/. .

# Define o diretório do projeto
WORKDIR "/src/Fiap.Api.Alunos"


# Realiza o build da aplicação
# Altere isso conforme necessário
RUN dotnet build "Fiap.Api.Alunos.csproj" -c Release -o /app/build

# Publica a aplicação
RUN dotnet publish "Fiap.Api.Alunos.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final - Prepara a execução
FROM base AS final
WORKDIR /app

# Copia os artefatos publicados da etapa de build
COPY --from=build /app/publish .

# Comando de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "Fiap.Api.Alunos.dll"]

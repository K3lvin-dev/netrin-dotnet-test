# LojaVirtual - Docker

Este projeto é uma aplicação .NET dividida em múltiplos projetos (API, Application, Domain, Infrastructure, Tests).

## Como rodar a aplicação com Docker

### Pré-requisitos
- Docker instalado

### Passos

1. **Build da imagem**
    docker build -t minhaloja-api .
2. **Rodar a imagem**
   docker run -p 5000:5000 minhaloja-api
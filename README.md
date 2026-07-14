# Tech Challenge Fase 2 - Sistema de E-commerce de Jogos (Orquestração)

Este é o repositório central de orquestração do projeto de e-commerce de jogos. Ele contém os manifestos do Kubernetes (`Deployment`, `Service`, `ConfigMap` e `Secret`) e o arquivo `docker-compose.yml` para a execução conjunta de todos os microsserviços.

## Estrutura da Arquitetura
O sistema é composto por 4 microsserviços principais comunicando-se de forma assíncrona via RabbitMQ (utilizando MassTransit):
1. **Users API**: Gerenciamento e cadastro de usuários.
2. **Catalog API**: Catálogo de jogos e consulta de preços.
3. **Payments API**: Processamento de compras e emissão de eventos de pedido (`OrderPlacedEvent`).
4. **Notifications API**: Consumo de eventos e notificação de processamento ao usuário final.

---

## ⚙️ Pré-requisitos (Configuração do Ambiente Local)

Para executar o projeto localmente, é estritamente necessário configurar o ambiente com **WSL 2** e **Docker Desktop**.

### Passo 1: Configurar WSL 2 (Windows Subsystem for Linux)
1. Abra o PowerShell como Administrador e execute: `wsl --install`
2. Reinicie o computador, se solicitado.

### Passo 2: Configurar Docker Desktop e Kubernetes
1. Baixe e instale o [Docker Desktop](https://www.docker.com/products/docker-desktop/).
2. Abra o Docker Desktop e vá em **Settings (Engrenagem)**:
   - Em **General**: Certifique-se de que a opção `"Use the WSL 2 based engine"` está marcada.
   - Em **Resources > WSL Integration**: Ative a integração com a sua distribuição Linux padrão (ex: Ubuntu).
   - Em **Kubernetes**: Marque a caixa `"Enable Kubernetes"` e clique em **Apply & Restart**. Aguarde até que o ícone do Kubernetes fique verde (Running) no canto inferior esquerdo.

---

## Como Executar: Via Docker Compose

A forma mais rápida de testar a comunicação entre os serviços.

1. Clone este repositório.
2. Abra o terminal (PowerShell ou WSL) na pasta raiz do repositório.
3. Execute o comando para subir toda a infraestrutura e os microsserviços:
   ```bash
   docker-compose up -d

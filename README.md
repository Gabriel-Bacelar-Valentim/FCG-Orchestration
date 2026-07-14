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

## 🐳 Como Executar: Via Docker Compose

A forma mais rápida de testar a comunicação entre os serviços.

1. Clone este repositório.
2. Abra o terminal (PowerShell ou WSL) na pasta raiz do repositório.
3. Execute o comando para subir toda a infraestrutura e os microsserviços:
   ```bash
   docker-compose up -d

Para acompanhar os logs de todos os serviços simultaneamente, utilize:
docker-compose logs -f

Para encerrar e remover os containers:
docker-compose down

☸️ Como Executar: Via Kubernetes (K8s)
A arquitetura foi desenhada para rodar de forma nativa no Kubernetes, utilizando o padrão Database per Service (um banco Postgres isolado para cada API) e um barramento central de mensageria.

Passo 1: Provisionar a Infraestrutura Base (Mensageria e Bancos)
Antes de subir as APIs, precisamos garantir que o RabbitMQ e os bancos de dados estejam rodando.

Acesse este repositório de Orquestração e suba o RabbitMQ:

Bash
kubectl apply -f k8s/rabbitmq.yaml
Acesse a pasta raiz de cada um dos repositórios dos microsserviços (FCG.Users, FCG.Catalog, FCG.Payments) e aplique os bancos e as credenciais:

Bash
# Execute dentro da pasta de CADA repositório:
kubectl apply -f k8s/secret.yaml
kubectl apply -f k8s/database.yaml
Passo 2: Subir os Microsserviços
Com a infraestrutura base pronta (Running), aplique os manifestos das APIs a partir de seus respectivos repositórios:

Bash
# Execute dentro da pasta de CADA repositório (Users, Catalog, Payments, Notifications):
kubectl apply -f k8s/
Passo 3: Verificação de Status
Acompanhe a subida dos pods em tempo real. As APIs irão conectar em seus respectivos bancos, rodar as migrations (Entity Framework) e conectar no RabbitMQ.

Bash
kubectl get pods -w
(Aguarde até que todos os pods estejam com o status Running e 1/1 no READY).

🌐 Acessando a Aplicação (Port-Forward)
Como o Kubernetes isola a rede internamente, precisamos criar túneis (Port-Forward) para acessar o Swagger de cada API e o painel do RabbitMQ através do nosso localhost.

Abra diferentes abas no seu terminal e execute os comandos abaixo, mantendo-os abertos para navegar:

1. Users API (Porta 30001):

Bash
kubectl port-forward svc/users-api 30001:8080
👉 Acesso: http://localhost:30001/swagger

2. Payments API (Porta 30002):

Bash
kubectl port-forward svc/payments-api 30002:8080
👉 Acesso: http://localhost:30002/swagger

3. Catalog API (Porta 30003):

Bash
kubectl port-forward svc/catalog-api 30003:8080
👉 Acesso: http://localhost:30003/swagger

4. Painel do RabbitMQ (Porta 15672):

Bash
kubectl port-forward svc/rabbitmq 15672:15672
👉 Acesso: http://localhost:15672 (Usuário: guest | Senha: guest)

🔗 Links dos Repositórios (Microsserviços)
A arquitetura completa é composta pelos seguintes repositórios:

[FCG-Users](https://github.com/Gabriel-Bacelar-Valentim/FCG-Users/tree/main)

[FCG-Catalog](https://github.com/Gabriel-Bacelar-Valentim/FCG-Catalog/tree/main)

[FCG-Payment](https://github.com/Gabriel-Bacelar-Valentim/FCG-Payment/tree/main)

[FCG-Notifications](https://github.com/Gabriel-Bacelar-Valentim/FCG-Notifications/tree/main)

FCG-Orchestration (Este repositório)

Desenvolvido como parte do Tech Challenge (Fase 2) - Arquitetura de Microsserviços e Mensageria.

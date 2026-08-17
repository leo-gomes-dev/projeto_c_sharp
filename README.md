# ⚡ .NET 10 Minimal Web API & Password Reset Backend

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![C%23](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white) ![CORS](https://img.shields.io/badge/CORS-Enabled-4CAF50?style=for-the-badge)

Este repositório contém o código de um backend ultra leve desenvolvido em **C# utilizando as Minimal APIs do .NET 10**. Ele foi projetado com suporte nativo a documentação OpenAPI e inclui uma política manual de CORS para facilitar a integração direta com aplicações frontend de redefinição de senha e controle de dados.

---

## ✨ Funcionalidades do Servidor

- **🌐 CORS Middleware Global:** Injeção manual de cabeçalhos HTTP que liberam o acesso de qualquer origem (`*`), além de interceptar e responder automaticamente requisições do tipo `OPTIONS` (Preflight).
- **📋 Endpoints Prontos:** Rotas estruturadas para listagem e cadastro de dados em memória (`GET` e `POST` para `/api/devs`).
- **🗂️ Record Types:** Uso de recursos modernos do C# para validação estrutural limpa de dados recebidos no payload.
- **🔍 OpenAPI (Swagger):** Suporte nativo para mapeamento de rotas e documentação interativa para ferramentas de desenvolvimento.

---

## 🛠️ Como Integrar com a sua Tela Web

Para que a sua tela de redefinição de senha ou a sua aplicação em JavaScript Vanilla converse com este backend rodando localmente, configure a chamada do `fetch` apontando para a URL padrão do seu servidor .NET.

1. Identifique a porta em que o seu projeto .NET está rodando (configurada no arquivo `Properties/launchSettings.json`). Geralmente é `http://localhost:5000` ou similar.
2. Altere o endereço da requisição no seu arquivo de frontend:
   ```javascript
   const response = await fetch("http://localhost:5000/api/devs", { // 👈 Exemplo de porta do backend
     method: "POST",
     headers: { "Content-Type": "application/json" },
     body: JSON.stringify({ nome: "Léo Gomes", tecnologia: "React & TypeScript" }),
   });
   ```

---

## 🎮 Como Executar o Servidor

Certifique-se de ter o [SDK do .NET 10](https://microsoft.com) instalado em sua máquina antes de iniciar.

1. Clone o repositório em seu diretório de projetos:
   ```bash
   git clone https://github.com
   ```
2. Acesse a pasta do projeto (onde o arquivo `servidor.csproj` está localizado):
   ```bash
   cd nome-da-pasta
   ```
3. Restaure as dependências do ecossistema NuGet:
   ```bash
   dotnet restore
   ```
4. Execute a aplicação em modo de desenvolvimento:
   ```bash
   dotnet watch run
   ```
   *(O comando `dotnet watch` monitora os arquivos e recarrega o servidor automaticamente a cada alteração no código).*

---

## 📂 Estrutura do Projeto

Os arquivos essenciais do ecossistema .NET gerados no build estão organizados na seguinte estrutura:

```text
├── Properties/
│   └── launchSettings.json       # Configurações de portas locais (HTTP/HTTPS)
├── Program.cs                    # Lógica principal do servidor, rotas e CORS
├── servidor.csproj               # Arquivo de configuração de referências do projeto
└── servidor.http                 # Arquivo de testes rápidos de requisição HTTP
```

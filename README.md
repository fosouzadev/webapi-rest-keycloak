# Web Api Rest Keycloak
Web Api Rest simples para validar um token de usuário gerado pelo Keycloak

## Comandos utilizados para criação do projeto
```csharp
dotnet new sln -n WebApiRestKeycloak
dotnet new webapi --use-controllers -n WebApiServer
dotnet sln add ./WebApiServer
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

## Keycloak
Documentação para criar [container do Keycloak](https://www.keycloak.org/getting-started/getting-started-docker), criar um usuário básico e gerar um token JWT para teste.

## Configurações do Keycloak
Algumas das etapas abaixo possuem detalhes na [documentação](https://www.keycloak.org/getting-started/getting-started-docker) que não serão mencionados aqui.

Crie um novo `Realm`, e entre em suas configurações.

Em `Realm roles`, crie as roles desejadas, exemplo: `admin`, `manager`, `user`, etc.

Em `Groups`, crie os grupos para agrupar as roles conforme desejado, exemplo: um grupo `administrators` pode agrupar as roles `admin` e `manager`. Nas configurações do grupo, utilize a aba `Role mapping` para adicionar as roles.

Em `Users`, crie um novo usuário, e faça as seguintes configurações:
* Na aba `Credentials`, defina uma senha para o usuário;
* Na aba `Groups`, associe o(s) grupo(s) criado(s).

Em `Clients`, crie um novo cliente para representar a aplicação que o usuário utilizará para fazer login. Nas configurações do cliente, na aba `Client scopes`, faça as seguintes configurações:
* Exclua todos os escopos que são adicionados por padrão;
* Adicione o escopo `basic`, ele é responsável por adicionar o id do usuário no token com a nomenclatura `sub`;
* Entre no escopo `{ClientName}-dedicated` e faça as seguintes configurações:
    * Adicione um novo `mapper` do tipo `By configuration` chamado `Audience`. Defina um nome e selecione sua aplicação no campo `Included Client Audience`, verifique se está marcado `On` para adicionar no token;
    * Adicione um novo `mapper` do tipo `By configuration` chamado `User Realm Role`. Defina um nome, coloque o valor `roles` no campo `Token Claim Name` e verifique se está marcado `On` para adicionar no token;
    * Na aba `Scope`, coloque `Off` na chave `Full scope allowed` e adicione as roles que criou anteriormente.

## Configurações da aplicação
No arquivo `appsettings.json`, informe os valores para `{RealmName}`, `{Audience}` e `{PublicKey}`.

Nos `controllers`, configure as roles criadas.
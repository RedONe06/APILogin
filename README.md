![image](https://user-images.githubusercontent.com/98191980/205299034-ce2af5f6-837d-4599-bab8-12d6bfabed06.png)

<img src="https://img.shields.io/static/v1?label=by&message=Alura&color=blue&style=for-the-badge"> <img src="https://img.shields.io/static/v1?label=Tech&message=.NET 6.0&color=orange&style=for-the-badge&logo=.NET"> <img src="https://img.shields.io/static/v1?label=Tech&message=C%23&color=orange&style=for-the-badge&logo=csharp">

# Descrição do sistema

O projeto se trata de uma API Rest com .NET 6.0 de **login com confirmação por email** utilizando EFCore 6.0, conectada a um banco de dados MySQL. Utilizou-se as ferramentas de Identity para o gerenciamento das operações e como referência foi-se utilizado um projeto da Alura, construído na versão 5.0 do .NET.

# Sobre o curso

- Boas práticas para a criação de APIs;
- Refatoração de dependências;
- Implementação de services;
- Definição de resultados acertivos;
- Configurações personlaizadas do Identity;
- Utilização do pacote FluentResult para extrair resultados;
- Confirmação de contas por email (utilizando o [MailTrap.io](https://mailtrap.io/inboxes/1981858/messages/3147013134));
- Criação de email com MailKit e MimeKit;

# Executando

## 🔗 EndPoint

```
localhost/cadastro
localhost/login
localhost/logout
```
## ⚙ Downloads

- Para fazer as requisições: [Postman](https://www.postman.com/);
- Banco de dados: [MySQL WorkBench (v.8.0)](https://dev.mysql.com/downloads/workbench/);
- Servidor: [Xampp (v.3.3)](https://www.apachefriends.org/download.html);

## Instruções

Primeiro deve-se alterar as configurações de envio dos email em appsettings.json de forma que sua conta no mailtrap capture os emails de confirmação. Estes emails de confirmação possuem em seu corpo a url para a ativação da conta que deve ser enviada em uma requisição do tipo GET. Após confirmado a ativação o usuário está liberado para fazer o login em sua conta. O processo de logout se dá com o resultado de OK(200). 

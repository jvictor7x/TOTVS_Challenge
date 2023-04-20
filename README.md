Desafio técnico da TOTVS. Este projeto inclui todos os requisitos especificados, exceto login/autenticação e testes unitários por conta do prazo curto.

Para compilar, é necessário ter:
	- .NET 6.0 e o Visual Studio instalados e configurados na máquina
	- SQL Server para visualização do banco de dados
	
Após isso, abra o SQL Server e realize a conexão manual com o seguinte nome do servidor: (local)\sqlexpress.
Feita a conexão com o SQL Server, abra o projeto, clique em Tools na aba superior -> NuGet Package Manager -> Package Manager Console.

Aberto o console, insira o seguinte comando: Add-Migration "Creation"
Após finalizar a execução dele, execute este: Update-Database

Tudo isso realizado, o projeto deve estar plenamente configurado e funcionando, podendo ser executado diretamente.
Para realizá-lo, utilizei o ASP.NET com MVC, EntityFramework Core como ORM e SQL Server para gerenciamento do banco de dados. 


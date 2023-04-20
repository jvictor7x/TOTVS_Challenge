Desafio t�cnico da TOTVS. Este projeto inclui todos os requisitos especificados, exceto login/autentica��o e testes unit�rios por conta do prazo curto.

Para compilar, � necess�rio ter:
	- .NET 6.0 e o Visual Studio instalados e configurados na m�quina
	- SQL Server para visualiza��o do banco de dados
	
Ap�s isso, abra o SQL Server e realize a conex�o manual com o seguinte nome do servidor: (local)\sqlexpress.
Feita a conex�o com o SQL Server, abra o projeto, clique em Tools na aba superior -> NuGet Package Manager -> Package Manager Console.

Aberto o console, insira o seguinte comando: Add-Migration "Creation"
Ap�s finalizar a execu��o dele, execute este: Update-Database

Tudo isso realizado, o projeto deve estar plenamente configurado e funcionando, podendo ser executado diretamente.
Para realiz�-lo, utilizei o ASP.NET com MVC, EntityFramework Core como ORM e SQL Server para gerenciamento do banco de dados. 


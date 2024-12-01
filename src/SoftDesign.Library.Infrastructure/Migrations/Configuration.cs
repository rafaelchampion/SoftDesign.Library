namespace SoftDesign.Library.Infrastructure.Migrations
{
    using SoftDesign.Library.Domain.Entities.Books;
    using SoftDesign.Library.Domain.Entities.Users;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataPersistence.SoftDesignLibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataPersistence.SoftDesignLibraryContext context)
        {
            context.Users.AddOrUpdate(
                u => u.Username,
                User.Create("systemadmin", "gr3at@3wdsG", "t@t.com").Value
            );

            context.Books.AddOrUpdate(
                u => u.Isbn,
                Book.Create("Refatoração: Aperfeiçoando o Design de Códigos Existentes", "Martin Fowler", "9788575227244").Value,
                Book.Create("Código Limpo: Habilidades Práticas do Agile Software", "Robert C. Martin", "9788576082675").Value,
                Book.Create("C# e .NET - Fundamentos e Técnicas Avançadas", "Rodrigo Turini e Loiane Groner", "9788535286168").Value,
                Book.Create("C#. Como Programar", "Harvey Deitel e Paul J. Deitel", "9788534614597").Value,
                Book.Create("Trabalho Eficaz com Código Legado", "Michael Feathers", "9788576089797").Value,
                Book.Create("Domain-Driven Design: Atacando as Complexidades no Coração do Software", "Eric Evans", "9788576082736").Value,
                Book.Create("Estruturas de Dados e Algoritmos com C#", "D. Malhotra e N. Chaudhary", "9788575226100").Value,
                Book.Create("Introdução ao Design de Interfaces para a Web", "Patrick J. Lynch e Sarah Horton", "9788576082101").Value,
                Book.Create("Desenvolvimento Web com ASP.NET Core", "Adam Freeman", "9788575225967").Value,
                Book.Create("Programando com C# 9 e .NET 5", "Mark J. Price", "9788575227121").Value,
                Book.Create("Desenvolvimento de Aplicações Empresariais com C# e .NET", "Jon Galloway e Philip Japikse", "9788575226551").Value,
                Book.Create("Head First Design Patterns", "Eric Freeman e Elisabeth Robson", "9788576088776").Value,
                Book.Create("Design Patterns: Padrões de Projeto", "Erich Gamma e outros", "9788573939897").Value,
                Book.Create("Arquitetura Limpa: O Guia do Artesão para Estruturas de Software", "Robert C. Martin", "9788576082674").Value,
                Book.Create("The Pragmatic Programmer", "Andrew Hunt e David Thomas", "9788576086634").Value,
                Book.Create("Microsoft .NET: Architecting Applications for the Enterprise", "Dino Esposito e Andrea Saltarello", "9788576089901").Value,
                Book.Create("Entity Framework Core in Action", "Jon Smith", "9788575226735").Value,
                Book.Create("Pro ASP.NET Core MVC", "Adam Freeman", "9788575225899").Value,
                Book.Create("Clean Architecture: A Craftsman's Guide to Software Structure", "Robert C. Martin", "9788576087593").Value,
                Book.Create("Padrões de Arquitetura de Aplicações Corporativas", "Martin Fowler", "9788576088583").Value,
                Book.Create("C# Pocket Reference", "Joseph Albahari e Ben Albahari", "9788576088316").Value,
                Book.Create("More Effective C#", "Bill Wagner", "9788576086120").Value,
                Book.Create("Kotlin for Android Developers", "Antonio Leiva", "9788576088070").Value,
                Book.Create("Python Fluente", "Luciano Ramalho", "9788576086731").Value,
                Book.Create("Estruturas de Dados com Java", "Narasimha Karumanchi", "9788576087987").Value
            );
        }
    }
}

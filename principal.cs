  using System;
  using System.Collections.Generic;

  class Program
  {
      static void Main(string[] args)
      {
          var books = new List<Book>
          {
              new Book("O Pequeno Príncipe", "Antoine de Saint-Exupéry", 39.90m, "Um clássico da literatura infantil que narra a amizade entre um menino e um piloto de avião."),
              new Book("É assim que acaba", "Collen Hoover", 59.90m, "O romance mais pessoal da carreira de Colleen Hoover aborda temas como violência doméstica e abuso psicológico."),
              new Book("1984", "George Orwell", 29.90m, "Um famoso romance inglês que mostra uma futura realidade distópica."),
              new Book("O conto da aia", "Margareth Atwood", 69.90m, "Retrata um mundo distópico onde a humanidade se tornou em sua maioria infértil."),
              new Book("Guerra das papoulas", "R. F. Kuang", 44.90m, "Uma jovem em uma nação prestes a ruir, em meio a uma guerra pelo ópio.")
          };
          var sales = new List<Sale>();
          decimal budget = 200.00m;

          while (true)
          {
              Console.WriteLine($"\nOrçamento disponível: R${budget:F2}");
              Console.WriteLine("Bem-vindo à DreamBook's! Escolha uma opção:");
              Console.WriteLine("1. Listar livros");
              Console.WriteLine("2. Ver detalhes de um livro");
              Console.WriteLine("3. Adicionar um novo livro");
              Console.WriteLine("4. Comprar um livro");
              Console.WriteLine("5. Ver relatório de vendas");
              Console.WriteLine("6. Sair");

              if (!int.TryParse(Console.ReadLine(), out int choice))
              {
                  Console.WriteLine("Escolha inválida. Tente novamente.");
                  continue;
              }

              Console.WriteLine(new string('-', 40));
              switch (choice)
              {
                  case 1:
                      ListBooks(books);
                      break;
                  case 2:
                      ShowBookDetails(books);
                      break;
                  case 3:
                      AddBook(books);
                      break;
                  case 4:
                      budget = BuyBook(books, sales, budget);
                      break;
                  case 5:
                      ShowSalesReport(sales);
                      break;
                  case 6:
                      return;
                  default:
                      Console.WriteLine("Escolha inválida. Tente novamente.");
                      break;
              }
              Console.WriteLine(new string('-', 40));
          }
      }

      static void ListBooks(List<Book> books)
      {
          Console.WriteLine("\nLivros disponíveis:");
          if (books.Count == 0)
          {
              Console.WriteLine("Nenhum livro disponível.");
              return;
          }
          for (int i = 0; i < books.Count; i++)
          {
              Console.WriteLine($"{i + 1}. {books[i].Title} - {books[i].Author} - R${books[i].Price:F2}");
          }
      }

      static void ShowBookDetails(List<Book> books)
      {
          Console.WriteLine("\nDigite o número do livro que você gostaria de ver:");
          if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= books.Count)
          {
              var selectedBook = books[choice - 1];
              Console.WriteLine($"\nTítulo: {selectedBook.Title}");
              Console.WriteLine($"Autor: {selectedBook.Author}");
              Console.WriteLine($"Preço: R${selectedBook.Price:F2}");
              Console.WriteLine($"Descrição: {selectedBook.Description}");
          }
          else
          {
              Console.WriteLine("Escolha inválida. Por favor, digite um número válido.");
          }
      }

      static void AddBook(List<Book> books)
      {
          Console.WriteLine("\nDigite o título do livro:");
          string title = Console.ReadLine();
          Console.WriteLine("Digite o autor do livro:");
          string author = Console.ReadLine();
          Console.WriteLine("Digite o preço do livro:");
          if (!decimal.TryParse(Console.ReadLine(), out decimal price))
          {
              Console.WriteLine("Preço inválido. O livro não foi adicionado.");
              return;
          }
          Console.WriteLine("Digite a descrição do livro:");
          string description = Console.ReadLine();
          books.Add(new Book(title, author, price, description));
          Console.WriteLine("Livro adicionado com sucesso!");
      }

      static decimal BuyBook(List<Book> books, List<Sale> sales, decimal budget)
      {
          Console.WriteLine("\nDigite o número do livro que você gostaria de comprar:");
          if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= books.Count)
          {
              var selectedBook = books[choice - 1];
              if (budget >= selectedBook.Price)
              {
                  books.RemoveAt(choice - 1);
                  sales.Add(new Sale(selectedBook.Title, selectedBook.Author, selectedBook.Price));
                  budget -= selectedBook.Price;
                  Console.WriteLine($"Você comprou '{selectedBook.Title}' por R${selectedBook.Price:F2}!");
              }
              else
              {
                  Console.WriteLine("Orçamento insuficiente para comprar este livro.");
              }
          }
          else
          {
              Console.WriteLine("Escolha inválida. Por favor, digite um número válido.");
          }
          return budget;
      }

      static void ShowSalesReport(List<Sale> sales)
      {
          Console.WriteLine("\nRelatório de Vendas:");
          if (sales.Count == 0)
          {
              Console.WriteLine("Nenhuma venda registrada.");
              return;
          }
          foreach (var sale in sales)
          {
              Console.WriteLine($"Título: {sale.Title}, Autor: {sale.Author}, Preço: R${sale.Price:F2}");
          }
      }
  }

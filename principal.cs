using System;
using System.Collections.Generic;
class Program
{
static void Main(string[] args)
{
var books = new List&lt;Book&gt;
{
new Book(&quot;O Pequeno Príncipe&quot;, &quot;Antoine de Saint-Exupéry&quot;, 39.90m, &quot;Um clássico
da literatura infantil que narra a amizade entre um menino e um piloto de avião.&quot;),
new Book(&quot;É assim que acaba&quot;, &quot;Collen Hoover&quot;, 59.90m, &quot;O romance mais pessoal
da carreira de Colleen Hoover aborda temas como violência doméstica e abuso
psicológico.&quot;),
new Book(&quot;1984&quot;, &quot;George Orwell&quot;, 29.90m, &quot;Um famoso romance inglês que mostra
uma futura realidade distópica.&quot;),
new Book(&quot;O conto da aia&quot;, &quot;Margareth Atwood&quot;, 69.90m, &quot;Retrata um mundo
distópico onde a humanidade se tornou em sua maioria infértil.&quot;),
new Book(&quot;Guerra das papoulas&quot;, &quot;R. F. Kuang&quot;, 44.90m, &quot;Uma jovem em uma
nação prestes a ruir, em meio a uma guerra pelo ópio.&quot;)
};
var sales = new List&lt;Sale&gt;(); // Lista para armazenar as vendas
decimal budget = 200.00m; // Orçamento inicial
while (true)
{
Console.WriteLine($&quot;\nOrçamento disponível: R${budget:F2}&quot;);
Console.WriteLine(&quot;Bem-vindo à DreamBook&#39;s! Escolha uma opção:&quot;);
Console.WriteLine(&quot;1. Listar livros&quot;);
Console.WriteLine(&quot;2. Ver detalhes de um livro&quot;);
Console.WriteLine(&quot;3. Adicionar um novo livro&quot;);
Console.WriteLine(&quot;4. Comprar um livro&quot;);
Console.WriteLine(&quot;5. Ver relatório de vendas&quot;);
Console.WriteLine(&quot;6. Sair&quot;);
if (!int.TryParse(Console.ReadLine(), out int choice))
{
Console.WriteLine(&quot;Escolha inválida. Tente novamente.&quot;);
continue;
}
Console.WriteLine(new string(&#39;-&#39;, 40)); // Linha pontilhada
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
Console.WriteLine(&quot;Escolha inválida. Tente novamente.&quot;);
break;
}
Console.WriteLine(new string(&#39;-&#39;, 40)); // Linha pontilhada
}
}
static void ListBooks(List&lt;Book&gt; books)
{
Console.WriteLine(&quot;\nLivros disponíveis:&quot;);
if (books.Count == 0)
{
Console.WriteLine(&quot;Nenhum livro disponível.&quot;);
return;
}
for (int i = 0; i &lt; books.Count; i++)
{
Console.WriteLine($&quot;{i + 1}. {books[i].Title} - {books[i].Author} -
R${books[i].Price:F2}&quot;);
}
}
static void ShowBookDetails(List&lt;Book&gt; books)
{
Console.WriteLine(&quot;\nDigite o número do livro que você gostaria de ver:&quot;);
if (int.TryParse(Console.ReadLine(), out int choice) &amp;&amp; choice &gt; 0 &amp;&amp; choice &lt;=
books.Count)
{
var selectedBook = books[choice - 1];

Console.WriteLine($&quot;\nTítulo: {selectedBook.Title}&quot;);
Console.WriteLine($&quot;Autor: {selectedBook.Author}&quot;);
Console.WriteLine($&quot;Preço: R${selectedBook.Price:F2}&quot;);
Console.WriteLine($&quot;Descrição: {selectedBook.Description}&quot;);
}
else
{
Console.WriteLine(&quot;Escolha inválida. Por favor, digite um número válido.&quot;);
}
}
static void AddBook(List&lt;Book&gt; books)
{
Console.WriteLine(&quot;\nDigite o título do livro:&quot;);
string title = Console.ReadLine();
Console.WriteLine(&quot;Digite o autor do livro:&quot;);
string author = Console.ReadLine();
Console.WriteLine(&quot;Digite o preço do livro:&quot;);
if (!decimal.TryParse(Console.ReadLine(), out decimal price))
{
Console.WriteLine(&quot;Preço inválido. O livro não foi adicionado.&quot;);
return;
}
Console.WriteLine(&quot;Digite a descrição do livro:&quot;);
string description = Console.ReadLine();
books.Add(new Book(title, author, price, description));
Console.WriteLine(&quot;Livro adicionado com sucesso!&quot;);
}
static decimal BuyBook(List&lt;Book&gt; books, List&lt;Sale&gt; sales, decimal budget)
{
Console.WriteLine(&quot;\nDigite o número do livro que você gostaria de comprar:&quot;);
if (int.TryParse(Console.ReadLine(), out int choice) &amp;&amp; choice &gt; 0 &amp;&amp; choice &lt;=
books.Count)
{
var selectedBook = books[choice - 1];
// Verifica se há orçamento suficiente
if (budget &gt;= selectedBook.Price)
{
books.RemoveAt(choice - 1); // Remove o livro da lista
// Registra a venda

sales.Add(new Sale(selectedBook.Title, selectedBook.Author,
selectedBook.Price));
budget -= selectedBook.Price; // Deduz o preço do livro do orçamento
Console.WriteLine($&quot;Você comprou &#39;{selectedBook.Title}&#39; por
R${selectedBook.Price:F2}!&quot;);
}
else
{
Console.WriteLine(&quot;Orçamento insuficiente para comprar este livro.&quot;);
}
}
else
{
Console.WriteLine(&quot;Escolha inválida. Por favor, digite um número válido.&quot;);
}
return budget; // Retorna o orçamento atualizado
}
static void ShowSalesReport(List&lt;Sale&gt; sales)
{
Console.WriteLine(&quot;\nRelatório de Vendas:&quot;);
if (sales.Count == 0)
{
Console.WriteLine(&quot;Nenhuma venda registrada.&quot;);
return;
}
foreach (var sale in sales)
{
Console.WriteLine($&quot;Título: {sale.Title}, Autor: {sale.Author}, Preço:
R${sale.Price:F2}&quot;);
}
}
}

class Sale
{
public string Title { get; }
public string Author { get; }
public decimal Price { get; }
public Sale(string title, string author, decimal price)
{
Title = title;
Author = author;
Price = price;
}
}

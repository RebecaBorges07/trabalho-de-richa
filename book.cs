class Book
{
public string Title { get; }
public string Author { get; }
public decimal Price { get; }
public string Description { get; }
public Book(string title, string author, decimal price, string description)
{
Title = title;
Author = author;

Price = price;
Description = description;
}
}

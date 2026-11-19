namespace Auto_Repair_Managment.Entity;

public sealed class SparePart : EntityBase
{
    public string Article { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int QuantityInStock { get; private set; }

    private SparePart(string article, string name, decimal price, int quantityInStock)
    {
        Article = article;
        Name = name;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    public static SparePart Create(string article, string name, decimal price, int quantityInStock)
    {
        return new SparePart(
            Guard.RequireText(article, "Артикул", 50),
            Guard.RequireText(name, "Наименование запчасти"),
            Guard.RequireNonNegative(price, "Цена"),
            Guard.RequireNonNegative(quantityInStock, "Остаток на складе"));
    }

    public void Update(string article, string name, decimal price, int quantityInStock)
    {
        string validatedArticle = Guard.RequireText(article, "Артикул", 50);
        string validatedName = Guard.RequireText(name, "Наименование запчасти");
        decimal validatedPrice = Guard.RequireNonNegative(price, "Цена");
        int validatedQuantityInStock = Guard.RequireNonNegative(quantityInStock, "Остаток на складе");
        Article = validatedArticle;
        Name = validatedName;
        Price = validatedPrice;
        QuantityInStock = validatedQuantityInStock;
    }

    public void WriteOff(int quantity)
    {
        Guard.RequirePositive(quantity, "Количество");
        if (quantity > QuantityInStock)
        {
            throw new ArgumentException($"Недостаточно запчастей на складе: «{Name}» (остаток {QuantityInStock}).");
        }

        QuantityInStock -= quantity;
    }
}

namespace RestAPI_Items.Models;


public class ItemModelDTO
{
    public string? ItemName {get; set;}
    public double? ItemPrice {get; set;}
    public int? ItemCount {get; set;}
    public char? ItemFabric {get; set;} // C - cotton, P - polyester, A - acrylic, W - wool
    public bool ItemWillRestock {get; set;}

    public ItemModel MapToItemModel() 
    {
        return new ItemModel()
        {
            ItemName = ItemName,
            ItemPrice = ItemPrice,
            ItemCount = ItemCount,
            ItemFabric = ItemFabric,
            ItemWillRestock = ItemWillRestock,
        };
    
    }
}



using Microsoft.AspNetCore.Http.Features;

namespace RestAPI_Items.Models;

public class ItemModel
{
    public string? ItemName {get; set;}
    public double? ItemPrice {get; set;}
    public int? ItemCount {get; set;}
    public char? ItemFabric {get; set;} // C - cotton, P - polyester, A - acrylic, W - wool
    public bool ItemWillRestock {get; set;}
}




/* made a list but then i realized i could try to make my own csv file
public class ItemLIst
{
    public static List<ItemModel> Items = new List<ItemModel>()
    {
        
    }

}
*/
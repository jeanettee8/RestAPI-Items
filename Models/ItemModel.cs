

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

namespace RestAPI_Items.Models;

public class ItemModel
{
    [Key]
    public string? ItemName {get; set;}
    public double? ItemPrice {get; set;}
    public int? ItemCount {get; set;}
    public char? ItemFabric {get; set;} // C - cotton, P - polyester, A - acrylic, W - wool
    public bool ItemWillRestock {get; set;}
}
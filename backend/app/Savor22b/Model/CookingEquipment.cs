namespace Savor22b.Model;
using Libplanet.Assets;

public class CookingEquipment
{
    public int ID { get; set; }
    public int CookingEquipmentCategoryID { get; set; }
    public string Name { get; set; }
    public double BlockTimeReductionPercent { get; set; }
    public string Price { get; set; }

    public FungibleAssetValue PriceToFungibleAssetValue()
    {
        return FungibleAssetValue.Parse(Currencies.KeyCurrency, Price);
    }
}

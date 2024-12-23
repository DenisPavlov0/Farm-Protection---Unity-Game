public class Item : IItem
{
    private ItemData itemData;

    public Item(ItemData data)
    {
        itemData = data;
    }

    public string Name => itemData.itemName;
    public int HealthBonus => itemData.healthBonus;
    public int AttackBonus => itemData.attackBonus;
}
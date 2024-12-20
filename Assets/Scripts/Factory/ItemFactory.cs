using UnityEditor;

public class ItemFactory
{
    public static IItem CreateItem(ItemData itemData)
    {
        return new Item(itemData);
    }
}
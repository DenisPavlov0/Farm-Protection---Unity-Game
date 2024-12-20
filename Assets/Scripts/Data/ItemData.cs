using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int healthBonus;
    public int attackBonus;
    public string itemDescription;   
    public Sprite itemSprite;        
    public GameObject itemPrefab;   
    public float rechargeTime;       
}
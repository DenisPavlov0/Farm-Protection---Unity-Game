using System.Collections.Generic;
using UnityEngine;

public class Player : Character // Наследуем от Character
{
    public int Level { get; set; }
    public List<ItemData> EquippedItems { get; private set; }

    private void Start()
    {
        Name = "Hero";
        Health = 100;
        AttackPower = 10;
        Level = 1;
        EquippedItems = new List<ItemData>();

        // Выводим в консоль для проверки
        Debug.Log("Player created: " + Name);
    }
    

    // Метод для экипировки предмета
    public void EquipItem(ItemData item)
    {
        Debug.Log(item.itemName);
        EquippedItems.Add(item);
        ApplyItemBonuses(item);
        
    }

    // Применяем бонусы от предмета
    private void ApplyItemBonuses(ItemData item)
    {
        Health += item.healthBonus;
        AttackPower += item.attackBonus;
        Debug.Log(Health);
        Debug.Log(AttackPower);
    }

    // Сбрасываем характеристики игрока
    public override void ResetStats()
    {
        Health = 100;
        AttackPower = 10;
    }
}
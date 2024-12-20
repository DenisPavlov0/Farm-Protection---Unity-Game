using UnityEngine;

public abstract class Character: MonoBehaviour
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    
    public abstract void ResetStats();
}
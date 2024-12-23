using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Weapons/Bullet")]
public class BulletData : ScriptableObject
{
    public string bulletName;      // Название пули
    public GameObject prefab;      // Префаб пули
    public int damage;             // Урон пули
    public float speed;            // Скорость пули
    public float lifetime;         // Время жизни пули
}
using UnityEngine;

public class Enemy : Character
{
    public EnemyData enemyData;  // Данные врага, задаются через ScriptableObject
    private Transform player;    // Ссылка на игрока
    public float _health;
    public string _name;

    private void Start()
    {
        if (enemyData == null)
        {
            Debug.LogError("EnemyData не задан для врага: " + gameObject.name);
            return;
        }

        _health = enemyData.health; // Задаем здоровье врага
        _name = enemyData.enemyName;
        player = GameObject.FindWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Игрок с тегом 'Player' не найден!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    // Метод движения врага к игроку
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized; // Направление к игроку
        transform.Translate(direction * enemyData.speed * Time.deltaTime, Space.World);
    }

    // Метод получения урона
    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"{enemyData.enemyName} получил {damage} урона. Осталось здоровья: {_health}");

        if (_health <= 0)
        {
            Debug.Log($"{enemyData.enemyName} уничтожен!");
            Destroy(gameObject); // Уничтожаем врага, если его здоровье <= 0
        }
    }

    public override void ResetStats()
    {
        _health = enemyData.health; // Сбрасываем здоровье к начальному значению
    }
}
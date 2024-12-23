using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    private Transform target; // Цель пули
    private BulletPool bulletPool; // Ссылка на пул пуль

    private void Start()
    {
        // Ищем пул в родительском объекте или в другом месте
        bulletPool = FindObjectOfType<BulletPool>(); 
    }

    private void Update()
    {
        if (target != null)
        {
            // Движение к цели
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * (bulletData.speed * Time.deltaTime), Space.World);
        }
        else
        {
            // Если цель пропала, возвращаем пулю в пул
            ReturnBulletToPool();
        }
    }

    public void SetTarget(Transform enemyTarget)
    {
        target = enemyTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Убедимся, что пуля попадает только во врагов
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletData.damage); // Наносим урон
            }
            // Возвращаем пулю в пул после попадания
            ReturnBulletToPool();
        }
    }

    private void ReturnBulletToPool()
    {
        // Возвращаем пулю в пул
        if (bulletPool != null)
        {
            bulletPool.ReturnBulletToPool(gameObject); // Деактивируем пулю и возвращаем в пул
        }
        else
        {
            // Если пул не найден, уничтожаем пулю
            Destroy(gameObject);
        }
    }
}
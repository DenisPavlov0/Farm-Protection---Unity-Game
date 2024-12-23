using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;  // Префаб пули
    public int poolSize = 5;        // Размер пула
    public Transform bulletsParent; 

    private List<GameObject> bulletPool;  // Список пуль в пуле

    private void Start()
    {
        bulletPool = new List<GameObject>();

        // Инициализация пула с заранее созданными пулями
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletsParent);  // Устанавливаем родителя при создании
            bullet.SetActive(false);  // Делаем пулю неактивной
            bulletPool.Add(bullet);
        }
    }

    // Получить пулю из пула
    public GameObject GetBullet()
    {
        // Ищем неактивные пули
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)  // Если пуля неактивна, можно её использовать
            {
                bullet.SetActive(true);  // Активируем пулю
                return bullet;
            }
        }

        // Если не нашли неактивную пулю, создаем новую
        GameObject newBullet = Instantiate(bulletPrefab);
        bulletPool.Add(newBullet);
        return newBullet;
    }

    // Возврат пули в пул
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);  // Деактивируем пулю
    }
}
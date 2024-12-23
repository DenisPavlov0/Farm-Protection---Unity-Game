using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;        // Точка вылета пули
    public BulletData currentBullet;   // Текущая пуля
    public float fireRate = 1f;        // Скорострельность
    private float lastFireTime;        // Время последнего выстрела
    private EnemyDetector enemyDetector;

    private PlayerAnimator playerAnimator;  // Ссылка на аниматор игрока
    private BulletPool bulletPool;          // Ссылка на пул пуль

    private void Start()
    {
        enemyDetector = GetComponent<EnemyDetector>();
        playerAnimator = GetComponent<PlayerAnimator>();  // Получаем аниматор игрока
        bulletPool = FindObjectOfType<BulletPool>();  // Получаем пул пуль
    }

    // Метод для проверки, есть ли враг и можно ли стрелять
    private void Update()
    {
        TryShoot();  // Проверяем возможность стрельбы в каждом кадре
    }

    // Метод для попытки выстрела
    public void TryShoot()
    {
        // Проверяем наличие цели (врага) и перезарядку
        Transform target = GetTarget();

        if (target == null || Time.time - lastFireTime < fireRate) return;  // Если врага нет или перезарядка не прошла

        // Если враг есть и можно стрелять
        playerAnimator.PlayShootAnimation();  // Запускаем анимацию выстрела

        lastFireTime = Time.time;  // Обновляем время последнего выстрела
    }

    // Метод для получения цели
    private Transform GetTarget()
    {
        if (currentBullet == null || enemyDetector == null) return null;

        Transform closestEnemy = enemyDetector.GetClosestEnemy();
        if (closestEnemy == null) return null;  // Если врагов нет, не стреляем

        return closestEnemy;
    }

    // Этот метод будет вызван по окончанию анимации выстрела (событие из анимации)
    public void ShootBullet()
    {
        Transform target = GetTarget();  // Проверяем, есть ли цель

        if (target == null) return;  // Если цели нет, ничего не делаем

        // Получаем пулю из пула
        GameObject bullet = bulletPool.GetBullet();  // Берем пулю из пула
        bullet.transform.position = firePoint.position;  // Устанавливаем позицию
        bullet.transform.rotation = firePoint.rotation;  // Устанавливаем ротацию

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.bulletData = currentBullet;
            bulletComponent.SetTarget(target);  // Пуля будет лететь к ближайшему врагу
        }
    }
}

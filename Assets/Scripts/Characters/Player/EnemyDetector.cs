using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public float detectionRadius = 10f; // Радиус обнаружения врагов
    public LayerMask enemyLayer; // Слой, на котором находятся враги

    private List<GameObject> detectedEnemies = new List<GameObject>(); // Список обнаруженных врагов

    void Update()
    {
        DetectEnemies();
    }

    private void DetectEnemies()
    {
        // Найти все объекты в радиусе detectionRadius на слое enemyLayer
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
        // Очистить список и добавить новые найденные враги
        detectedEnemies.Clear();
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                GameObject enemy = collider.gameObject;
                detectedEnemies.Add(enemy);
                
            }
        }
    }

    public Transform GetClosestEnemy()
    {
        // Ищем всех врагов в радиусе
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);
        Enemy closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }
        }

        return closestEnemy != null ? closestEnemy.transform : null;
    }

    public float GetDistanceToEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            return Vector3.Distance(transform.position, enemy.transform.position);
        }
        return Mathf.Infinity; // Если враг null, вернуть бесконечное расстояние
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

   
}

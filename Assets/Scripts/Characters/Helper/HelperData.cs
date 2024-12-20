using UnityEngine;

[CreateAssetMenu(fileName = "New Helper", menuName = "Helpers/Helper")]
public class HelperData : ScriptableObject
{
    public string helperName;
    public GameObject helperPrefab; // Префаб помощника
    public Vector3 spawnPosition; // Позиция для спавна
}
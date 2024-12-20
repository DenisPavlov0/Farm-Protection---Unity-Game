using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject selectionPanel;  // Панель с выбором
    public Button itemButtonPrefab;    // Префаб кнопки для предметов
    public Button helperButtonPrefab;  // Префаб кнопки для помощников
    public Player player;              // Ссылка на игрока

    public List<ItemData> items;       // Список доступных предметов
    public List<HelperData> helpers;   // Список доступных помощников

    private void Start()
    {
        selectionPanel.SetActive(false);  // Скрываем панель по умолчанию
        StartCoroutine(ShowSelectionPanelAfterDelay(10f)); // Появляется через 10 секунд
    }

    private IEnumerator ShowSelectionPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Появляется панель с выбором
        selectionPanel.SetActive(true);

        // Выбираем случайные предметы и помощников для отображения
        for (int i = 0; i < 3; i++)
        {
            // Случайный выбор предмета или помощника
            bool isItem = Random.Range(0, 2) == 0;

            if (isItem)
            {
                ItemData randomItem = items[Random.Range(0, items.Count)];
                Button itemButton = Instantiate(itemButtonPrefab, selectionPanel.transform);
                itemButton.GetComponentInChildren<TMP_Text>().text = randomItem.itemName;

                itemButton.onClick.AddListener(() => player.EquipItem(randomItem));
            }
            else
            {
                HelperData randomHelper = helpers[Random.Range(0, helpers.Count)];
                Button helperButton = Instantiate(helperButtonPrefab, selectionPanel.transform);
                helperButton.GetComponentInChildren<TMP_Text>().text = randomHelper.helperName;

                helperButton.onClick.AddListener(() => SpawnHelper(randomHelper));
            }
        }
    }

    private void SpawnHelper(HelperData helper)
    {
        Instantiate(helper.helperPrefab, helper.spawnPosition, Quaternion.identity);
        Debug.Log($"{helper.helperName} has been spawned!");
    }
}

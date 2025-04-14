using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisualInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;//Число монет в кошельке (текст)

    [SerializeField]
    private TextMeshProUGUI healthText;//Число здоровья (текст)

    //Подключаем объект игрока для доступа к PlayerInfo
    private GameObject player;
    private PlayerInfo playerInfo;

    //Подключаем интерактивные текстовые элементы
    [SerializeField]
    private GameObject bonusActiveText;

    //Подключаем скрипт подбора предметов
    [SerializeField]
    private GameObject synergyBonus;
    private TakeItem takeItem;

    private void Start()
    {
        Activator();
    }

    private void Update()
    {
        Errors();
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = "" + playerInfo.Money;
        healthText.text = "" + playerInfo.Health;
        if (takeItem.IsBonusActive)
        {
            bonusActiveText.SetActive(true);
            //Задаю положение текста об активации бонуса
            bonusActiveText.transform.position = new Vector2(83, 2);
        }
    }

    /// <summary>
    /// Для разгрузки метода старт, всё что должно быть в нём - перенесено сначала сюда.
    /// </summary>
    private void Activator()
    {
        //Активируем объекты и их компоненты
        player = GameObject.Find("PLAYER");
        playerInfo = player.GetComponent<PlayerInfo>();
        takeItem = synergyBonus.GetComponent<TakeItem>();


        if (bonusActiveText.activeSelf == true)
        {
            bonusActiveText.SetActive(false);
        }
    }

    private void Errors()
    {
        if (player == null)
        {
            Debug.LogError("Ошибка! Объект player не найден!");
        }
        if (playerInfo == null)
        {
            Debug.LogError("Ошибка! Объект playerInfo не найден!");
        }
        if (moneyText == null)
        {
            Debug.LogError("Ошибка! Объект moneyText не найден!");
        }
        if (bonusActiveText == null)
        {
            Debug.LogError("Ошибка! Объект bonusActiveText не найден!");
        }
        if (synergyBonus == null)
        {
            Debug.LogError("Ошибка! Объект synergyBonus не найден!");
        }
        if (takeItem == null)
        {
            Debug.LogError("Ошибка! Объект takeItem не найден!");
        }
    }
}

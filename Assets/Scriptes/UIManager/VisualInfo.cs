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

    //Инфа по бочкам
    [SerializeField]
    private GameObject bochka_1;
    [SerializeField]
    private GameObject bochka_2;
    [SerializeField]
    private TextMeshProUGUI healthTextBochka_1;
    [SerializeField]
    private TextMeshProUGUI healthTextBochka_2;
    private Enemy enemy_1;
    private Enemy enemy_2;

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
        healthTextBochka_1.text = "" + enemy_1.Health;
        healthTextBochka_2.text = "" + enemy_2.Health;
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
        enemy_1 = bochka_1.GetComponent<Enemy>();
        enemy_2 = bochka_2.GetComponent<Enemy>();

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
        if (healthText == null)
        {
            Debug.LogError("Ошибка! Объект healthText не найден!");
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
        if (bochka_1 == null)
        {
            Debug.LogError("Ошибка! Объект bochka_1 не найден!");
        }
        if (bochka_2 == null)
        {
            Debug.LogError("Ошибка! Объект bochka_2 не найден!");
        }
        if (healthTextBochka_1 == null)
        {
            Debug.LogError("Ошибка! Объект healthTextBochka_1 не найден!");
        }
        if (healthTextBochka_2 == null)
        {
            Debug.LogError("Ошибка! Объект healthTextBochka_2 не найден!");
        }
        if (enemy_1 == null)
        {
            Debug.LogError("Ошибка! Объект enemy_1 не найден!");
        }
        if (enemy_2 == null)
        {
            Debug.LogError("Ошибка! Объект enemy_2 не найден!");
        }
    }
}

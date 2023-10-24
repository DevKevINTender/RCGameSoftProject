using UnityEngine;
using UnityEngine.UI;

public class UICirclePlacement : MonoBehaviour
{
    public int numberOfObjects = 8; // Количество объектов
    public GameObject buttonPrefab; // Префаб кнопки UI
    public float radius = 50f;


    [ContextMenu("PlaceButtonsInCircle")]
    private void PlaceButtonsInCircle()
    {
        RectTransform parentTransform = GetComponent<RectTransform>(); // Получаем RectTransform текущего объекта

        if (parentTransform == null)
        {
            Debug.LogError("UI объект не содержит RectTransform компонент.");
            return;
        }

        float angleIncrement = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * angleIncrement;
            float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector2 anchoredPosition = new Vector2(x, y) * parentTransform.rect.width / 4f; // Размер объекта UI делится на 4 для радиуса
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);

            GameObject button = Instantiate(buttonPrefab, anchoredPosition, rotation, parentTransform);
            RectTransform buttonTransform = button.GetComponent<RectTransform>();
            buttonTransform.anchoredPosition = anchoredPosition;
        }
    }
}

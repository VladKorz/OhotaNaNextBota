using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] objectsToDestroy; // Массив объектов, которые нужно удалить
    public TextMeshProUGUI counterText; // Ссылка на текстовый компонент счетчика (TextMeshProUGUI)
    public static int sceneIndex = 1;

    private int destroyedObjectsCount = 0; // Счетчик уничтоженных объектов

    private void Start()
    {
        // Обновляем текст счетчика
        UpdateCounterText();
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        // Находим индекс объекта в массиве
        int index = Array.IndexOf(objectsToDestroy, objectToDestroy);

        // Если объект найден, удаляем его из массива
        if (index >= 0)
        {
            // Создаем новый массив, исключая удаляемый объект
            GameObject[] newObjectsToDestroy = new GameObject[objectsToDestroy.Length - 1];
            Array.Copy(objectsToDestroy, 0, newObjectsToDestroy, 0, index);
            Array.Copy(objectsToDestroy, index + 1, newObjectsToDestroy, index, objectsToDestroy.Length - index - 1);

            // Заменяем старый массив на новый
            objectsToDestroy = newObjectsToDestroy;

            // Увеличиваем счетчик уничтоженных объектов
            destroyedObjectsCount++;

            // Обновляем текст счетчика
            UpdateCounterText();

            // Проверяем, были ли уничтожены все объекты
            if (destroyedObjectsCount == 5)
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    private void UpdateCounterText()
    {
        // Обновляем текст счетчика
        counterText.text = destroyedObjectsCount + "/5";
    }
}

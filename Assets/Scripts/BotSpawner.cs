using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class BotSpawner : MonoBehaviour
{
    public GameObject[] botPrefabs; // Массив префабов ботов
    public float spawnInterval = 5f; // Интервал между спавнами
    public Transform[] spawnPoints; // Массив точек спавна

    private Coroutine spawnCoroutine; // Переменная для хранения корутины

    private void Start()
    {
        // Запускаем корутину спавна
        spawnCoroutine = StartCoroutine(SpawnBots());
    }

    private IEnumerator SpawnBots()
    {
        while (true)
        {
            // Проверяем, есть ли на сцене боты, которые еще не спавнились
            bool allBotsSpawned = true;
            foreach (GameObject prefab in botPrefabs)
            {
                if (GameObject.FindGameObjectsWithTag(prefab.tag).Length < 1)
                {
                    allBotsSpawned = false;
                    break;
                }
            }

            // Если не все боты спавнились, выбираем случайный префаб из тех, которых нет на сцене
            if (!allBotsSpawned)
            {
                // Получаем список префабов, которых нет на сцене
                List<GameObject> availablePrefabs = new List<GameObject>(botPrefabs);
                foreach (GameObject prefab in botPrefabs)
                {
                    if (GameObject.FindGameObjectsWithTag(prefab.tag).Length > 0)
                    {
                        availablePrefabs.Remove(prefab);
                    }
                }

                // Выбираем случайный префаб из списка доступных
                int randomIndex = UnityEngine.Random.Range(0, availablePrefabs.Count);
                GameObject botPrefab = availablePrefabs[randomIndex];

                // Спавним бота
                SpawnBot(botPrefab);
            }
            else
            {
                // Если все боты спавнились, выбираем случайный префаб из общего массива
                int randomIndex = UnityEngine.Random.Range(0, botPrefabs.Length);
                GameObject botPrefab = botPrefabs[randomIndex];

                // Спавним бота
                SpawnBot(botPrefab);
            }

            // Ждем заданный интервал
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBot(GameObject botPrefab)
    {
        // Получаем список точек спавна, которые не пустые
        List<Transform> validSpawnPoints = new List<Transform>();
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                validSpawnPoints.Add(spawnPoint);
            }
        }

        // Проверяем, есть ли точки спавна
        if (validSpawnPoints.Count > 0)
        {
            // Выбираем случайную точку спавна
            int randomSpawnIndex = UnityEngine.Random.Range(0, validSpawnPoints.Count);
            Transform spawnPoint = validSpawnPoints[randomSpawnIndex];

            // Спавним бота в выбранной точке
            Instantiate(botPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void RemoveBotPrefab(GameObject prefabToRemove)
    {
        // Находим индекс префаба в массиве
        int index = Array.IndexOf(botPrefabs, prefabToRemove);

        // Если префаб найден, удаляем его из массива
        if (index >= 0)
        {
            // Создаем новый массив, исключая удаляемый префаб
            GameObject[] newBotPrefabs = new GameObject[botPrefabs.Length - 1];
            Array.Copy(botPrefabs, 0, newBotPrefabs, 0, index);
            Array.Copy(botPrefabs, index + 1, newBotPrefabs, index, botPrefabs.Length - index - 1);

            // Заменяем старый массив на новый
            botPrefabs = newBotPrefabs;

            // Удаляем этот спавнер из сцены
            Destroy(this.gameObject);
        }
    }
}

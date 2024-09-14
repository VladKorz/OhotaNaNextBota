using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class BotSpawner : MonoBehaviour
{
    public GameObject[] botPrefabs; // ������ �������� �����
    public float spawnInterval = 5f; // �������� ����� ��������
    public Transform[] spawnPoints; // ������ ����� ������

    private Coroutine spawnCoroutine; // ���������� ��� �������� ��������

    private void Start()
    {
        // ��������� �������� ������
        spawnCoroutine = StartCoroutine(SpawnBots());
    }

    private IEnumerator SpawnBots()
    {
        while (true)
        {
            // ���������, ���� �� �� ����� ����, ������� ��� �� ����������
            bool allBotsSpawned = true;
            foreach (GameObject prefab in botPrefabs)
            {
                if (GameObject.FindGameObjectsWithTag(prefab.tag).Length < 1)
                {
                    allBotsSpawned = false;
                    break;
                }
            }

            // ���� �� ��� ���� ����������, �������� ��������� ������ �� ���, ������� ��� �� �����
            if (!allBotsSpawned)
            {
                // �������� ������ ��������, ������� ��� �� �����
                List<GameObject> availablePrefabs = new List<GameObject>(botPrefabs);
                foreach (GameObject prefab in botPrefabs)
                {
                    if (GameObject.FindGameObjectsWithTag(prefab.tag).Length > 0)
                    {
                        availablePrefabs.Remove(prefab);
                    }
                }

                // �������� ��������� ������ �� ������ ���������
                int randomIndex = UnityEngine.Random.Range(0, availablePrefabs.Count);
                GameObject botPrefab = availablePrefabs[randomIndex];

                // ������� ����
                SpawnBot(botPrefab);
            }
            else
            {
                // ���� ��� ���� ����������, �������� ��������� ������ �� ������ �������
                int randomIndex = UnityEngine.Random.Range(0, botPrefabs.Length);
                GameObject botPrefab = botPrefabs[randomIndex];

                // ������� ����
                SpawnBot(botPrefab);
            }

            // ���� �������� ��������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBot(GameObject botPrefab)
    {
        // �������� ������ ����� ������, ������� �� ������
        List<Transform> validSpawnPoints = new List<Transform>();
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                validSpawnPoints.Add(spawnPoint);
            }
        }

        // ���������, ���� �� ����� ������
        if (validSpawnPoints.Count > 0)
        {
            // �������� ��������� ����� ������
            int randomSpawnIndex = UnityEngine.Random.Range(0, validSpawnPoints.Count);
            Transform spawnPoint = validSpawnPoints[randomSpawnIndex];

            // ������� ���� � ��������� �����
            Instantiate(botPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void RemoveBotPrefab(GameObject prefabToRemove)
    {
        // ������� ������ ������� � �������
        int index = Array.IndexOf(botPrefabs, prefabToRemove);

        // ���� ������ ������, ������� ��� �� �������
        if (index >= 0)
        {
            // ������� ����� ������, �������� ��������� ������
            GameObject[] newBotPrefabs = new GameObject[botPrefabs.Length - 1];
            Array.Copy(botPrefabs, 0, newBotPrefabs, 0, index);
            Array.Copy(botPrefabs, index + 1, newBotPrefabs, index, botPrefabs.Length - index - 1);

            // �������� ������ ������ �� �����
            botPrefabs = newBotPrefabs;

            // ������� ���� ������� �� �����
            Destroy(this.gameObject);
        }
    }
}

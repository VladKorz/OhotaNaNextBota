using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] objectsToDestroy; // ������ ��������, ������� ����� �������
    public TextMeshProUGUI counterText; // ������ �� ��������� ��������� �������� (TextMeshProUGUI)
    public static int sceneIndex = 1;

    private int destroyedObjectsCount = 0; // ������� ������������ ��������

    private void Start()
    {
        // ��������� ����� ��������
        UpdateCounterText();
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        // ������� ������ ������� � �������
        int index = Array.IndexOf(objectsToDestroy, objectToDestroy);

        // ���� ������ ������, ������� ��� �� �������
        if (index >= 0)
        {
            // ������� ����� ������, �������� ��������� ������
            GameObject[] newObjectsToDestroy = new GameObject[objectsToDestroy.Length - 1];
            Array.Copy(objectsToDestroy, 0, newObjectsToDestroy, 0, index);
            Array.Copy(objectsToDestroy, index + 1, newObjectsToDestroy, index, objectsToDestroy.Length - index - 1);

            // �������� ������ ������ �� �����
            objectsToDestroy = newObjectsToDestroy;

            // ����������� ������� ������������ ��������
            destroyedObjectsCount++;

            // ��������� ����� ��������
            UpdateCounterText();

            // ���������, ���� �� ���������� ��� �������
            if (destroyedObjectsCount == 5)
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    private void UpdateCounterText()
    {
        // ��������� ����� ��������
        counterText.text = destroyedObjectsCount + "/5";
    }
}

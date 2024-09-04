using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SvapScens : MonoBehaviour
{
    public static int scenId;
    private int scenMenu = 0;
    public Button[] buttons;

    void Start()
    {
        // ������������� �� ������� ������ ������
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ������� ��������� ����� ������� (�������� ������� � ����������)
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));

            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }
    }

    public void back()
    {
        SceneManager.LoadScene(scenId);
    }

    public void Menu()
    {
        SceneManager.LoadScene(scenMenu);
    }

    public void Next()
    {
        scenId++;
        SceneManager.LoadScene(scenId);
    }

    private void OnButtonClicked(int index)
    {
        SceneManager.LoadScene(index + 3);
    }
}
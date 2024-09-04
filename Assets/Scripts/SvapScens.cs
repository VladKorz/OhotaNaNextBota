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
        // Подписываемся на события кликов кнопок
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Создаем локальную копию индекса (избегаем проблем с замыканием)
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
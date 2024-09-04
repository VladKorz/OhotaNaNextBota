using UnityEngine;

public class KeepCursorVisible : MonoBehaviour
{
    void Start()
    {
        // «апрещаем автоматическое скрытие курсора
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // »змен€ем курсор на изображение "myCursor.png"
        Cursor.SetCursor(Resources.Load<Texture2D>("myCursor"), Vector2.zero, CursorMode.Auto);
    }
}

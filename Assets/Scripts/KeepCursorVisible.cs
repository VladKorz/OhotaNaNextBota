using UnityEngine;

public class KeepCursorVisible : MonoBehaviour
{
    void Start()
    {
        // ��������� �������������� ������� �������
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // �������� ������ �� ����������� "myCursor.png"
        Cursor.SetCursor(Resources.Load<Texture2D>("myCursor"), Vector2.zero, CursorMode.Auto);
    }
}

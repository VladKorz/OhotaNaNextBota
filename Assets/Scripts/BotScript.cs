using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    public PlayerManager playerManager; // ������ �� ������ PlayerManager

    private void OnDestroy()
    {
        // �������� ������� DestroyObject �� PlayerManager
        playerManager.DestroyObject(gameObject);
    }
}
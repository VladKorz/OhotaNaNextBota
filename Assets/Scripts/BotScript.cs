using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    public PlayerManager playerManager; // Ссылка на скрипт PlayerManager

    private void OnDestroy()
    {
        // Вызываем функцию DestroyObject из PlayerManager
        playerManager.DestroyObject(gameObject);
    }
}
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Ссылка на объект игрока
    public GameObject player;

    // Ссылка на AudioClip, который будет воспроизводиться
    public AudioClip soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        // Проверка, является ли входящий объект игроком
        if (other.gameObject == player)
        {
            // Получаем AudioSource на игроке
            AudioSource playerAudioSource = player.GetComponent<AudioSource>();

            // Проверка, существует ли AudioSource на игроке
            if (playerAudioSource != null)
            {
                // Воспроизводим звук на игроке
                playerAudioSource.PlayOneShot(soundToPlay);
            }
            else
            {
                Debug.LogError("Не найден AudioSource на игроке!");
            }
        }
    }
}
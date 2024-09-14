using UnityEngine;

public class Sound : MonoBehaviour
{
    // ������ �� ������ ������
    public GameObject player;

    // ������ �� AudioClip, ������� ����� ����������������
    public AudioClip soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        // ��������, �������� �� �������� ������ �������
        if (other.gameObject == player)
        {
            // �������� AudioSource �� ������
            AudioSource playerAudioSource = player.GetComponent<AudioSource>();

            // ��������, ���������� �� AudioSource �� ������
            if (playerAudioSource != null)
            {
                // ������������� ���� �� ������
                playerAudioSource.PlayOneShot(soundToPlay);
            }
            else
            {
                Debug.LogError("�� ������ AudioSource �� ������!");
            }
        }
    }
}
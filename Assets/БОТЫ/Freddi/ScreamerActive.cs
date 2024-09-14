using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreamerActive : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.sceneIndex = 2;
            SceneManager.LoadScene(2);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPadTeleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("TerrainScene");
        }
    }
}

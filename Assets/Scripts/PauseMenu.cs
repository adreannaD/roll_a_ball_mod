using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public TextMeshProUGUI dashCooldownText;
    private bool isPaused = false;
    private PlayerControllerCharacter player;

    void Start()
    {
        player = FindObjectOfType<PlayerControllerCharacter>();
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
            TogglePause();

        if (player != null && dashCooldownText != null)
        {
            float cooldown = Mathf.Max(0, player.GetDashCooldownRemaining());
            dashCooldownText.text = cooldown > 0
                ? $"Dash Cooldown: {cooldown:F1}s"
                : "Dash Ready!";
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

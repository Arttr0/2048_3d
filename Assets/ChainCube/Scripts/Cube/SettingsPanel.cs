using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Панель паузы (задать в инспекторе)

    // Метод для открытия панели паузы
    public void OpenPausePanel()
    {
        if (pausePanel != null)
        {
            AudioManager.Instance.PlaySFX(2);
            pausePanel.SetActive(true);
            Time.timeScale = 0f; // Останавливаем игру
        }
    }

    // Метод для закрытия панели паузы
    public void ClosePausePanel()
    {
        if (pausePanel != null)
        {
            AudioManager.Instance.PlaySFX(2);
            pausePanel.SetActive(false);
            Time.timeScale = 1f; // Возобновляем игру
        }
    }

    // Метод для перезапуска текущей сцены
    public void RestartScene()
    {
        AudioManager.Instance.PlaySFX(2);
        Time.timeScale = 1f; // Убедимся, что игра не на паузе
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

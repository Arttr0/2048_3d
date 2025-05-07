using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // ������ ����� (������ � ����������)

    // ����� ��� �������� ������ �����
    public void OpenPausePanel()
    {
        if (pausePanel != null)
        {
            AudioManager.Instance.PlaySFX(2);
            pausePanel.SetActive(true);
            Time.timeScale = 0f; // ������������� ����
        }
    }

    // ����� ��� �������� ������ �����
    public void ClosePausePanel()
    {
        if (pausePanel != null)
        {
            AudioManager.Instance.PlaySFX(2);
            pausePanel.SetActive(false);
            Time.timeScale = 1f; // ������������ ����
        }
    }

    // ����� ��� ����������� ������� �����
    public void RestartScene()
    {
        AudioManager.Instance.PlaySFX(2);
        Time.timeScale = 1f; // ��������, ��� ���� �� �� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

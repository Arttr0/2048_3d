using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource; // �������� ������
    public AudioSource sfxSource; // �������� �������� ��������
    public Slider musicSlider; // ������� ��� ������
    public Slider sfxSlider; // ������� ��� �������� ��������
    public AudioClip[] audioClips; // ������ �������� ��������

    private void Awake()
    {
        // ���������, ���� �� ��� ��������� AudioManager
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // ��������� ��������� �������� ���������
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // ���������� ���������
        UpdateMusicVolume();
        UpdateSFXVolume();
        // �������� �� ��������� ���������
        musicSlider.onValueChanged.AddListener(delegate { UpdateMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { UpdateSFXVolume(); });
    }
    public void UpdateMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void UpdateSFXVolume()
    {
        sfxSource.volume = sfxSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            sfxSource.clip = audioClips[index];
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("Index out of bounds: " + index);
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop(); // ������������� �������� ������
    }

    public bool IsSFXPlaying(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            return sfxSource.clip == audioClips[index] && sfxSource.isPlaying;
        }
        return false;
    }

}

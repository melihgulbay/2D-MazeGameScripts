using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider soundSlider;
    private const string VolumeKey = "SoundVolume";

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        soundSlider.value = savedVolume;
        soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
        ChangeSoundVolume(savedVolume);
    }

    private void ChangeSoundVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
    }
}

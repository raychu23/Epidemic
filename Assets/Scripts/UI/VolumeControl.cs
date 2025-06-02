using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the sound effects and soundtrack volume via sliders.
/// </summary>
public class VolumeControl : MonoBehaviour
{
    // Slider for sound effects volume
    public Slider sound;
    // Slider for soundtrack volume
    public Slider music;
    // Button for mute
    public Button mute;

    // Bool for current mute state
    private bool muted = false;
    // Last value storage
    private float lastSoundVal, lastMusicVal;

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        //Debug.Assert(sound && music, "Wrong initial settings");

        if (mute != null)
            mute.onClick.AddListener(delegate { OnMuteClick(); });
        sound.value = DataManager.instance.configs.soundVolume;
        music.value = DataManager.instance.configs.musicVolume;
        sound.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        music.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    /// <summary>
    /// Raises the volume changed event.
    /// </summary>
    private void OnVolumeChanged()
    {
        muted = false;
        // Store new settings
        DataManager.instance.configs.soundVolume = sound.value;
        DataManager.instance.configs.musicVolume = music.value;
        DataManager.instance.SaveGameConfigs();
        // Apply new settings
        AudioManager.instance.SetVolume(DataManager.instance.configs.soundVolume, DataManager.instance.configs.musicVolume);
    }

    private void OnMuteClick()
    {
        if (muted)
        {
            sound.value = lastSoundVal;
            music.value = lastMusicVal;
            OnVolumeChanged();
        }
        else
        {
            lastSoundVal = sound.value;
            lastMusicVal = music.value;
            sound.value = 0f;
            music.value = 0f;
            OnVolumeChanged();
            muted = true;
        }
    }
}

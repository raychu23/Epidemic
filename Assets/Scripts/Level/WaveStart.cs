using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveStart : MonoBehaviour
{
    Button _button;
    private int currentWave = 0;

    // Current wave text field
    private Text currentWaveText;

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("WaveEnd", WaveEnd);
        EventManager.StartListening("AllEnemiesAreDead", AllEnemiesAreDead);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("WaveEnd", WaveEnd);
        EventManager.StopListening("AllEnemiesAreDead", AllEnemiesAreDead);
    }

    public void HandleClick()
    {
        EventManager.TriggerEvent("WaveStart", null, currentWave.ToString());
        currentWave++;
        currentWaveText.text = currentWave.ToString();
        _button.interactable = false;
    }

    void Awake()
    {
        _button = GetComponent<Button>();
        currentWaveText = GameObject.Find("CurrentWave").GetComponent<Text>();
    }

    private void WaveEnd(GameObject obj, string param)
    {
        _button.interactable = true;
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }
    /// <summary>
    /// Once all enemies in the whole game (not just one wave) are dead, the start wave button is set non-interactable
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="param"></param>
    private void AllEnemiesAreDead(GameObject obj, string param)
    {
        _button.interactable = false;
    }
}
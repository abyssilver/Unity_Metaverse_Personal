using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] public TextMeshProUGUI waveText;
    [SerializeField] public Slider hpSlider;
    [SerializeField] public TextMeshProUGUI timeText;

    private float elapsedTime;

    private void Start()
    {
        UpdateHPSlider(1);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        timeText.text = elapsedTime.ToString("F2");
    }
    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }

    public void UpdateWaveText(int wave)
    {
        waveText.text = wave.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}


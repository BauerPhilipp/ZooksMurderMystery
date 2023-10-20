using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsManager : MonoBehaviour
{

    VisualElement root;

    Slider soundSlider;
    Slider sfxSlider;

    CustomSlider customSlider;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        soundSlider = root.Q<Slider>("SoundSlider");
        sfxSlider = root.Q<Slider>("SFXSlider");

        soundSlider.RegisterCallback<ChangeEvent<float>>(SoundSliderChange);
        sfxSlider.RegisterCallback<ChangeEvent<float>>(SFXSliderChange);

        customSlider = FindFirstObjectByType<CustomSlider>();

    }

    private void SoundSliderChange(ChangeEvent<float> e)
    {
        customSlider.UpdateSoundBar(e.newValue);
        //Debug.Log("Sound slider value: " + e.newValue);
    }
    private void SFXSliderChange(ChangeEvent<float> e)
    {
        customSlider.UpdateSFXBar(e.newValue);
        //Debug.Log("SFX slider value: " + e.newValue);
    }
}

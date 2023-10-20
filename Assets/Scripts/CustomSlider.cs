using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomSlider : MonoBehaviour
{

    VisualElement root;
    VisualElement sfxBarFill;
    VisualElement soundBarFill;
    VisualElement soundDragger;
    VisualElement sfxDragger;
    VisualElement sfxDragContainer;
    VisualElement soundTracker;
    VisualElement sfxTracker;
    VisualElement soundDragContainer;
    VisualElement soundSlider;
    VisualElement sfxSlider;

    VisualElement newSoundDragger;
    VisualElement newSFXDragger;

    [SerializeField] Vector2 offsetSFXSliderSymbol;
    [SerializeField] Vector2 offsetSoundSliderSymbol;




    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        soundSlider = root.Q("SoundSlider");
        sfxSlider = root.Q("SFXSlider");

        soundDragger = soundSlider.Q("unity-dragger");
        soundDragContainer = soundSlider.Q("unity-drag-container");
        sfxDragger = sfxSlider.Q("unity-dragger");
        sfxDragContainer = sfxSlider.Q("unity-drag-container");

        soundTracker = soundSlider.Q("unity-tracker");
        sfxTracker = sfxSlider.Q("unity-tracker");

        newSoundDragger = root.Q("NewSoundDragger");

        newSFXDragger = root.Q("NewSFXDragger");

        sfxBarFill = new VisualElement();
        sfxBarFill.AddToClassList("bar2");

        sfxBarFill.name = "CustomSFXBarSlider";

        sfxDragger.Add(sfxBarFill);

        soundBarFill = new VisualElement();
        soundBarFill.AddToClassList("bar");

        soundBarFill.name = "CustomSoundBarSlider";

        soundDragger.Add(soundBarFill);

        UpdateSFXBar(50f);
        UpdateSoundBar(50f);
    }

    public void UpdateSFXBar(float value)
    {
        float newBarSize = sfxDragContainer.resolvedStyle.width * (value / 100f);
        float draggerSize = sfxDragger.resolvedStyle.width;
        sfxBarFill.style.width = newBarSize - draggerSize / 2 * (value / 100f) - (draggerSize / 2 * (value / 100f));

        Vector2 posSFXDraggerInWorldSpace = sfxDragger.parent.LocalToWorld(sfxDragger.transform.position);

        newSFXDragger.transform.position = sfxDragger.parent.WorldToLocal(posSFXDraggerInWorldSpace - offsetSFXSliderSymbol);          
    }
    public void UpdateSoundBar(float value)
    {
        float newBarSize = soundDragContainer.resolvedStyle.width * (value / 100f);
        float draggerSize = soundDragger.resolvedStyle.width;
        soundBarFill.style.width = newBarSize - draggerSize / 2 * (value / 100f) - (draggerSize / 2 * (value / 100f));

        Vector2 posSoundDraggerInWorldSpace = soundDragger.parent.LocalToWorld(soundDragger.transform.position);

        newSoundDragger.transform.position = sfxDragger.parent.WorldToLocal(posSoundDraggerInWorldSpace - offsetSoundSliderSymbol);
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text[] textButton;
    public TMP_InputField [] inputField;
    public Slider[] slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int index = 0; index < GameBase.audVol.Length; index++)
        {
            int i = index;
            inputField[i].onValueChanged.AddListener((text) => OnValueChangedInput(i, text));
            slider[i].onValueChanged.AddListener((value) => OnValueChanged(i, value));
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int index = 0; index < inputField.Length; index++)
        {
            if(eventData.pointerCurrentRaycast.gameObject == inputField[index].gameObject)
            {
                inputField[index].ActivateInputField();
                inputField[index].Select();
                break;
            }
        }

        for (int index = 0; index < textButton.Length; index++)
        {
            if (eventData.pointerCurrentRaycast.gameObject == textButton[index].gameObject)
            {
                TMP_Text text = inputField[index].textComponent;
                inputField[index].interactable = GameBase.mute[index];
                slider[index].interactable = GameBase.mute[index];
                GameBase.mute[index] = !GameBase.mute[index];
                textButton[index].text = (GameBase.mute[index]) ? "ON" : "OFF";
                textButton[index].color = (GameBase.mute[index]) ? new Color32(255, 0, 0, 255) : new Color32(128, 0, 0, 255);
                text.color = (GameBase.mute[index]) ?  new Color32(128, 128, 128, 255): new Color32(255, 255, 255, 255);

                foreach (Transform child in slider[index].transform)
                {
                    if (child.name == "UI_Slider_Back") continue;
                    Image image = child.GetComponent<Image>();
                    if (child.name == "UI_Slider_Front") image.color = (GameBase.mute[index]) ? new Color32(128, 64, 0, 255) : new Color32(255, 128, 0, 255);
                    else                                 image.color = (GameBase.mute[index]) ? new Color32(128, 128, 128, 255) : new Color32(255, 255, 255, 255);
                }

                break;
            }
        }
    }

    void OnValueChangedInput(int index, string text)
    {
        if (int.TryParse(text, out int value))
        {
            value = Mathf.Clamp(value, (int)slider[index].minValue, (int)slider[index].maxValue);
            inputField[index].text = value.ToString();
            slider[index].value = value;
            GameBase.audVol[index] = value;
        }
        else
        {
            inputField[index].text = "0";
            slider[index].value = 0;
        }

        StartCoroutine(TextEnd(index));
    }

    void OnValueChanged(int index, float value)
    {
        int intValue = Mathf.RoundToInt(value);
        inputField[index].text = intValue.ToString();
    }

    IEnumerator TextEnd(int index)
    {
        yield return null;
        inputField[index].MoveTextEnd(false);
    }
}
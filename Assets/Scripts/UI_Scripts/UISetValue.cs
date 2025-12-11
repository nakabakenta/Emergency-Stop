using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UISetValue : MonoBehaviour, IPointerClickHandler
{
    private Image imageIU;
    public TMP_Text textValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageIU = this.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        displayText.gameObject.SetActive(false);
        inputField.gameObject.SetActive(true);

        inputField.text = displayText.text;
        inputField.ActivateInputField(); // Ž©“®‚Å“ü—Í‚µŽn‚ß‚é
    }
}

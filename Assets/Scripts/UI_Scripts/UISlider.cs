using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlider : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public TMP_Text textValue;
    private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        int value = (int)slider.value;
        textValue.text = value.ToString();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("スライダー操作終了");
    }
}

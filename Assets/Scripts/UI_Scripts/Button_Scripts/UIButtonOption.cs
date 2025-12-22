using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonOption : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public float splitFlapDur;
    public GameObject[] objUI;
    public UISplitFlap[] uISplitFlaps;

    private enum State { Screen, Control, Audio }
    private State nowState = State.Screen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        for (int num = 0; num < objButton.Length; num++)
        {
            GameObject objAlpha = Function.FindAllChild(objButton[num].transform, "UI_Alpha");

            if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[num].transform) == objButton[num])
            {
                if(objAlpha.gameObject.activeSelf)
                {
                    nowState = (State)num;
                    objAlpha.SetActive(false);

                    for (int index = 0; index < uISplitFlaps.Length; index++)
                        StartCoroutine(uISplitFlaps[index].SplitFlap(num));
                }
            }
            else objAlpha.SetActive(true);
        }
    }
}

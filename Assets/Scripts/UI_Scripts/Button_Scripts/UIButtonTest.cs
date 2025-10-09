using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonTest : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool openMenu = false;//���j���[���J�������ǂ����̉�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    //�N���b�N���ꂽ�ꍇ
    public override void OnPointerClick(PointerEventData eventData)
    {
        RectTransform rectTransform
            = this.transform.Find("UI_Menu").GetComponent<RectTransform>();

        openMenu = !openMenu;
        rectTransform.sizeDelta = (openMenu) ? new Vector2(450, 750) : new Vector2(0, 0);
    }

    //�}�E�X���d�Ȃ����ꍇ
    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    //�}�E�X�����ꂽ�ꍇ
    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}

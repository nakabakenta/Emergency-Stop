using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected string[] excludeName;//除外する名前
    public GameObject[] objButton; //ボタンオブジェクト
    protected Button button;       //Buttonコンポーネント

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        List<GameObject> listObjButton = new List<GameObject>();//ボタンオブジェクトリスト

        //取得
        button = this.GetComponent<Button>();//Button
        Transform transformChild
            = GameObject.Find("UI_" + GameBase.scene).transform.Find("UI_Button");

        //
        foreach (Transform transform in transformChild.transform)
        {
            bool exclude = false;//除外フラグ

            //除外する名前が存在する場合
            if (excludeName != null)
            {
                //除外する名前が含まれているかチェックする
                foreach (string name in excludeName)
                {
                    ///除外する名前が含まれている場合
                    if (transform.name.Contains(name))
                    {
                        exclude = true;//除外する
                        break;
                    }
                }
            }

            //除外していない場合
            if (!exclude)
            {
                listObjButton.Add(transform.gameObject);//リストにオブジェクトを入れる
            }
        }

        objButton = listObjButton.ToArray();//リストを配列に変換してオブジェクトに入れる
    }

    //クリックされた場合
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    //マウスが重なった場合
    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    //マウスが離れた場合
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }
}

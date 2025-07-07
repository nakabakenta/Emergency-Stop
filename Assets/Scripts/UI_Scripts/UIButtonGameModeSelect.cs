using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIButtonGameModeSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//現在のボタン

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        List<GameObject> listObjButton = new List<GameObject>();//ボタンオブジェクトリスト
        Transform transformChild
            = GameObject.Find("UI_" + GameBase.scene).transform.Find("UI_Button_" + GameBase.scene);

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
        nowButton = 0;

        SetScale(1.25f);
    }

    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            //ボタンオブジェクトを探す
            for (int i = 0; i < objButton.Length; i++)
            {
                //押されたボタンとボタンオブジェクトの名前が一致した場合
                if (gameObject.name == objButton[i].name)
                {
                    GameBase.gameMode = ((GameModeName)i).ToString();//配列番号をゲームモード名に変換する
                    break;
                }
            }

            //if(GameBase.gameMode == GameModeName.Normal.ToString())
            //{
            //    SceneLoader.LoadScene(SceneName.StageSelect.ToString());
            //}

            SceneLoader.LoadScene(SceneName.StageSelect.ToString());
        }
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            
        }    
    }

    //マウスが離れた場合
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {

        }
    }

    //スクロール操作が行われた場合
    public void OnScroll(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            float scrollDelta = eventData.scrollDelta.y;//スクロールの回転量

            if (scrollDelta != 0)
            {
                //上にスクロールされた場合は-200、それ以外は200
                int vertical = (scrollDelta > 0) ? -1 : 1;

                if ((gameObject.name == objButton[0].name && vertical == -1) ||
                   (gameObject.name == objButton[objButton.Length - 1].name && vertical == 1))
                {
                    return;
                }

                SetScale(1);
                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for(int i = 0; i < objButton.Length; i++)
        {
            RectTransform rectTransform 
                = objButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition 
                = new Vector2(rectTransform.anchoredPosition.x + vertical * -50, rectTransform.anchoredPosition.y + vertical * 200);
        }

        nowButton += vertical;
        SetScale(1.25f);
    }

    void SetScale(float scale)
    {
        RectTransform rectTransform
                = objButton[nowButton].GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(scale, scale, rectTransform.localScale.z);
    }
}

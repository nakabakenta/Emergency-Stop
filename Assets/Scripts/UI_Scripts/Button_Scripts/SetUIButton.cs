using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class SetUIButton : MonoBehaviour
{
    public GameObject[] objUIButton;//ボタンオブジェクト

    //スクリプト名一覧
    enum ScriptName
    {
        UIButtonMenu,
        UIButtonGameMode,
        UIButtonSelection
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    { 
        Transform thisTransform = this.transform;               //子オブジェクトを取得するトランスフォーム
        List<GameObject> listObjButton = new List<GameObject>();//ボタンオブジェクトリスト

        //子オブジェクトの数まで実行する
        for (int i = 0; i < thisTransform.childCount; i++)
        {
            Transform transform = thisTransform.GetChild(i);//子オブジェクトを取得する

            //取得した子オブジェクトにどのスクリプトがついているか調べる
            for (int j = 0; j < (int)ScriptName.UIButtonSelection + 1; j++)
            {
                Type scriptType = Type.GetType(((ScriptName)j).ToString());      //スクリプト名を登録する
                Component script = transform.gameObject.GetComponent(scriptType);//登録した名前のスクリプトがついているか確認する

                //登録した名前のスクリプトがついていた場合
                if (script)
                {
                    FieldInfo publicFieldInfo                                          //取得したスクリプト内の変数"setUIButton"をリフレクションする
                        = scriptType.GetField("setUIButton");
                    publicFieldInfo.SetValue(script, this.GetComponent<SetUIButton>());//リフレクションした変数にこのオブジェクトのスクリプトを渡す

                    //ボタンの初期化(i == 0の時だけ)
                    if (i == 0)
                    {
                        RectTransform rectTransform//子オブジェクトの"RectTransform"を取得する
                            = transform.gameObject.GetComponent<RectTransform>();
                        FieldInfo staticFieldInfo  //取得したスクリプト内の静的変数"nowButton"をリフレクションする
                            = scriptType.GetField("nowButton");
                        rectTransform.localScale = Vector3.one;//子オブジェクトのスケールを1にする
                        staticFieldInfo.SetValue(null, i);     //リフレクションした変数に"i(0)"を渡す
                    }

                    break;//for終了
                }
            }

            listObjButton.Add(transform.gameObject);//リストに子オブジェクトを入れる
        }

        objUIButton = listObjButton.ToArray();//リストを配列に変換する
    }
}

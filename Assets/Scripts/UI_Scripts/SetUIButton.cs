using System.Collections.Generic;
using UnityEngine;

public class SetUIButton : MonoBehaviour
{
    public GameObject[] objUIButton;//ボタンオブジェクト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    { 
        Transform thisTransform = this.transform;               //子オブジェクトを取得するトランスフォーム
        List<GameObject> listObjButton = new List<GameObject>();//ボタンオブジェクトリスト

        //指定したトランスフォームの子オブジェクトを取得
        foreach (Transform transform in thisTransform.transform)
        {
            UIButtonBase uIButtonBase = transform.gameObject.GetComponent<UIButtonBase>();//子オブジェクトのUIButtonBaseスクリプトを取得する
            uIButtonBase.setUIButton = this.GetComponent<SetUIButton>();                  //取得したUIButtonBaseスクリプトにこのオブジェクトのSetUIButtonスクリプトを渡す
            listObjButton.Add(transform.gameObject);                                      //リストに子オブジェクトを入れる
        }

        objUIButton = listObjButton.ToArray();//リストを配列に変換する
    }
}

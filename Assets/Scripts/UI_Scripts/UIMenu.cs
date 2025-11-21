using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{
    public GameObject[] objUI;          //UIオブジェクト
    public GameObject objBackGround;    //背景オブジェクト
    public GameObject objUIButtonBack;
    public TMP_Text textDes;            //ボタンテキスト
    private int nowStatus;              //現在の状態
    private string[] strDesc            //説明
        = { "プレイするゲームモードを選択します",
            "ゲーム内で使用したモデルを閲覧できます",
            "ゲームのオプションを確認できます",
            "タイトルに戻ります"};

    public static UIMenu uIMenu;

    //限られた数のオブジェクトを配置して電車を停車させるモード
    //タイトルに戻りますか？

    //UI名一覧
    public enum UIName
    {
        Menu,
        GameMode,
        Option,
        BackToTtle
    }

    private void Awake()
    {
        uIMenu = this.GetComponent<UIMenu>();
        GameBase.scene = "Menu";//デバック用
        nowStatus = (int)UIName.Menu;
    }

    public void SetMenu(int num)
    {
        nowStatus = num;

        for (int index = 0; index < objUI.Length; index++)
        {
            if (index == num)
            {
                objUI[index].SetActive(true);
            }
            else
            {
                objUI[index].SetActive(false);
            }
        }

        if (num == (int)UIName.Menu)
        {
            objBackGround.SetActive(false);
            objUIButtonBack.SetActive(false);
        }
        else if (num == (int)UIName.GameMode)
        {
            objUI[(int)UIName.Menu].SetActive(false);
            objUIButtonBack.SetActive(true);
        }
        else if(num == (int)UIName.BackToTtle)
        {
            objUI[(int)UIName.Menu].SetActive(true);
            objBackGround.SetActive(true);
        }
    }

    public void SetTextDes(int num)
    {
        textDes.text = strDesc[num];
    }
}

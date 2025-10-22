using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{
    public GameObject[] objUI;          //UIオブジェクト
    public GameObject objBackGround;    //背景オブジェクト
    public GameObject objUIButtonReturn;
    public TMP_Text buttonText;         //ボタンテキスト
    public static int nowStatus;        //現在の状態
    private string[] description        //説明
        = { "プレイするゲームモードを選択します", "ゲーム内で使用したモデルを閲覧できます", "ゲームのオプションを確認できます", "タイトルに戻ります"};

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
        GameBase.nowScene = "Menu";//デバック用
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowStatus = (int)UIName.Menu;
    }

    public void SetMenu()
    {
        if (nowStatus == (int)UIName.Menu)
        {
            objUI[(int)UIName.Menu].SetActive(true);
            objUI[(int)UIName.GameMode].SetActive(false);
            objUI[(int)UIName.BackToTtle].SetActive(false);
            objBackGround.SetActive(false);
            objUIButtonReturn.SetActive(false);
        }
        else if (nowStatus == (int)UIName.GameMode)
        {
            objUI[(int)UIName.Menu].SetActive(false);
            objUI[(int)UIName.GameMode].SetActive(true);
            objUIButtonReturn.SetActive(true);
        }
        else if(nowStatus == (int)UIName.BackToTtle)
        {
            objUI[(int)UIName.BackToTtle].SetActive(true);
            objBackGround.SetActive(true);
        }
    }

    public void SetText(int number)
    {
        buttonText.text = description[number];
    }
}

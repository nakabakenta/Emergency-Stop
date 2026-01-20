using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject[] objUI;      //UIオブジェクト
    public GameObject objBackGround;//背景オブジェクト

    private enum State { GameModeSelect, Museum, Option, BackToTtle }

    private string[] strDesc        //説明
        = { "プレイするゲームモードを選択します",
            "ゲーム内で使用したモデルを閲覧できます",
            "ゲームのオプションを確認できます",
            "タイトルに戻ります"};

    public static UIMenu uIMenu;

    //限られた数のオブジェクトを配置して電車を停車させるモード
    //タイトルに戻りますか？

    //UI一覧
    public enum UI{ Menu, Museum, Option, BackToTitle, GameMode }

    private void Awake()
    {
        uIMenu = this.GetComponent<UIMenu>();
        GameBase.scene = "Menu";//デバック用
    }

    public void SetMenu(int num)
    {
        objBackGround.SetActive(num == (int)UI.Option || num == (int)UI.BackToTitle);

        switch (num)
        {
            case (int)UI.Menu:
                objUI[0].SetActive(false);
                objUI[1].SetActive(true);
                break;
            case (int)UI.Museum:

                break;
            case (int)UI.Option:
                objUI[0].SetActive(true);
                objUI[2].SetActive(true);
                break;
            case (int)UI.BackToTitle:
                objUI[0].SetActive(true);
                objUI[3].SetActive(true);
                break;
            case (int)UI.GameMode:
                objUI[0].SetActive(true);
                objUI[1].SetActive(false);
                objUI[2].SetActive(false);
                objUI[3].SetActive(false);
                break;
        }
    }
}

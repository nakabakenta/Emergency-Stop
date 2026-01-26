using UnityEngine;

//シーン一覧
public enum SceneName
{
    Title,
    Menu,
    StageSelect,
    Stage,
    Free,
    Museum,
}

//ゲームモード
public enum GameMode
{
    Normal, //ノーマル
    Score,  //スコア
    Defense,//ディフェンス
    Endless,//エンドレス
    Free,   //フリー
}

//ステージ難易度
public enum StageLevel
{
    Local,              //
    SemiExpress,        //
    Express,            //
    LimitedExpress,     //
    SuperLimitedExpress,//
    MultiTrackDrifting, //
}

//ステージ
public enum StgaeName
{
    MainLine,//本線

}

//ゲーム難易度
enum GameLevel
{
    Tutorial,//チュートリアル(試運転)
    Normal,  //ノーマル      (定刻)
    Hard,    //ハード        (遅延)
}

//
enum GameStatus
{
    GameStart,//
    GamePrep, //準備
    GameDep,  //発車
    GameClear,
    GameOver,
}

public enum TrainStatus
{
    Normal,    //通常
    Collision, //衝突
    Derailment,//脱線
}

public class GameBase : MonoBehaviour
{
    public static string scene; //現在のシーン
    public static int gameMode; //ゲームモード
    public static int gameLevel;//ゲーム難易度
    public static int stage;    //ステージ

    public static bool[] stageClear
        = new bool[6] { false, false, false, false, false, false };

    //音量
    const int defVol = 75;                      //デフォルト
    public static int[] audVol                  //マスター, BGM, SE
        = new int[3] { defVol, defVol, defVol };
    public static bool[] mute                   //ミュート
        = new bool[3] { false, false, false };


}

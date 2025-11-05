using UnityEngine;

//シーン一覧
public enum SceneName
{
    StartUp,
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
    TestRun,            //
    Local,              //
    SemiExpress,        //
    Rapid,              //
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
    Normal,//ノーマル
    Hard,  //ハード
    Expert //エキスパート
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
    //待機時間(難易度)
    public static float[] waitTime
        = { 30, 20, 15};//ノーマル, ハード, エキスパート
}

using UnityEngine;

//シーン一覧
public enum Scene
{
    StartUp,
    Title,
    Menu,
    StageSelect,
    Stage,
    Free,
    Museum,
}

//ゲームモード一覧
public enum GameMode
{
    Normal, //ノーマル
    Score,  //スコア
    Defense,//ディフェンス
    Endless,//エンドレス
    Free,   //フリー
}

//ゲーム難易度
enum GameLevel
{
    Normal,
    Hard,
    Expert
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
    public static float[,] waitTime      
        = { { 30, 10, 10, 10, 10, 10, 10, 10 },  //ノーマル
            { 10, 10, 10, 10, 10, 10, 10, 10 },  //ハード
            { 10, 10, 10, 10, 10, 10, 10, 10 } };//エキスパート

    public static int[,] putNum
        = { { 3, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 0, 0 } };
}

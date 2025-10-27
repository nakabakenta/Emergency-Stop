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

//ステージ難易度一覧
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

enum StageStatus
{
    GameClear,
    GameOver,
}

public enum TrainStatus
{
    Normal,    //通常
    Derailment,//脱線
    Stop,      //停止
}

public class GameBase : MonoBehaviour
{
    public static string nowScene;   //現在のシーン
    public static string nowGameMode;//現在のゲームモード
}

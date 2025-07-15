using UnityEngine;

//シーン名一覧
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

//ゲームモード名一覧
public enum GameModeName
{
    Normal, //ノーマル
    Score,  //スコア
    Defense,//ディフェンス
    Endless,//エンドレス
    Free,   //フリー
}

//ステージ難易度名一覧
public enum StageLevelName
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

public class GameBase : MonoBehaviour
{
    public static string nowScene;   //現在のシーン
    public static string nowGameMode;//現在のゲームモード
}

using UnityEngine;

//シーン名一覧
public enum SceneName
{
    StartUp,
    Title,
    GameModeSelect,
    StageSelect,
    Stage
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
    public static string scene;   //シーン
    public static string gameMode;//ゲームモード
}

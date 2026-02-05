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
{ Normal, Score, Defense, Endless, Free }//ノーマル, スコア, ディフェンス,エンドレス,フリー

//
public enum StageLevel { Local, SemiExpress, Express, LimitedExpress, SuperLimitedExpress, MultiTrackDrifting }

//ステージ
public enum StgaeName
{
    MainLine,//本線
}

//ゲーム設定
enum GameLevel
{ Normal, Hard } //ノーマル(定刻), ハード(遅延)

//ステージ状態（未開放, 開放, クリア）
//public enum StageState { Lock, Unlock, Clear };

public class GameBase : MonoBehaviour
{
    public static string scene;        //現在のシーン
    public static int gameMode = 0;    //ゲームモード
    public static int gameLevel = 0;   //ゲーム難易度
    public static int stage = 1;       //ステージ
    public static int totalStage = 4;  //
    public static bool tutorial = true;//チュートリアル

    //音量
    const int defVol = 75;                      //デフォルト
    public static int[] audVol                  //マスター, BGM, SE
        = new int[3] { defVol, defVol, defVol };
    public static bool[] mute                   //ミュート
        = new bool[3] { false, false, false };

    public static Color32 signalNull = new Color32(51, 51, 51, 255);
    public static Color32 signalRed = new Color32(255, 0, 0, 255);
    public static Color32 signalBlue = new Color32(0, 223, 63, 255);

    public const int textJP = 0;
    public const int textEN = 1;

    public static float[] baseSpeed
        = new float[6] { 90f, 100f, 115f, 130f, 160f, 170f };

    public static int[] formNum
        = new int[6] { 8, 8, 8, 8, 8, 8};
}

//直線、曲線
//高架、地上、地下

//なし
//鉄橋（高架）
//踏切（地上）
//トンネル（高架、地上）
//駅（高架、地上、地下）
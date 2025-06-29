using UnityEngine;

public class GameBase : MonoBehaviour
{
    //ゲームモード一覧
    public enum GameMode
    {
        Normal, //ノーマル
        Score,  //スコア
        Endless,//エンドレス
        OnePut, //ワンプット
        Defense,//防衛
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
}

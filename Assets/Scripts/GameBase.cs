using UnityEngine;

//�V�[�����ꗗ
public enum SceneName
{
    StartUp,
    Title,
    GameModeSelect,
    StageSelect,
    Stage
}

//�Q�[�����[�h���ꗗ
public enum GameModeName
{
    Normal, //�m�[�}��
    Score,  //�X�R�A
    Defense,//�f�B�t�F���X
    Endless,//�G���h���X
    Free,   //�t���[
}

//�X�e�[�W��Փx���ꗗ
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
    public static string scene;   //�V�[��
    public static string gameMode;//�Q�[�����[�h
}

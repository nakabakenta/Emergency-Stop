using UnityEngine;

//�V�[�����ꗗ
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
    public static string nowScene;   //���݂̃V�[��
    public static string nowGameMode;//���݂̃Q�[�����[�h
}

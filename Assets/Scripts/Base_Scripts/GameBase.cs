using UnityEngine;

//�V�[���ꗗ
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

//�Q�[�����[�h�ꗗ
public enum GameMode
{
    Normal, //�m�[�}��
    Score,  //�X�R�A
    Defense,//�f�B�t�F���X
    Endless,//�G���h���X
    Free,   //�t���[
}

//�X�e�[�W��Փx�ꗗ
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
    Normal,    //�ʏ�
    Derailment,//�E��
    Stop,      //��~
}

public class GameBase : MonoBehaviour
{
    public static string nowScene;   //���݂̃V�[��
    public static string nowGameMode;//���݂̃Q�[�����[�h
}

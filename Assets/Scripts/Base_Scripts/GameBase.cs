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

//�Q�[����Փx
enum GameLevel
{
    Normal,
    Hard,
    Expert
}

//�X�e�[�W��Փx
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
    GamePrep, //����
    GameDep,  //����
    GameClear,
    GameOver,
}

public enum TrainStatus
{
    Normal,    //�ʏ�
    Collision, //�Փ�
    Derailment,//�E��
}

public class GameBase : MonoBehaviour
{
    public static string scene; //���݂̃V�[��
    public static int gameMode; //�Q�[�����[�h
    public static int gameLevel;//�Q�[����Փx
    public static int stage;    //�X�e�[�W
    //�ҋ@����(��Փx)
    public static float[,] waitTime      
        = { { 30, 10, 10, 10, 10, 10, 10, 10 },  //�m�[�}��
            { 10, 10, 10, 10, 10, 10, 10, 10 },  //�n�[�h
            { 10, 10, 10, 10, 10, 10, 10, 10 } };//�G�L�X�p�[�g

    public static int[,] putNum
        = { { 3, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 0, 0 } };
}

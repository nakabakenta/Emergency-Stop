using UnityEngine;

public class GameBase : MonoBehaviour
{
    //�Q�[�����[�h�ꗗ
    public enum GameMode
    {
        Normal, //�m�[�}��
        Score,  //�X�R�A
        Endless,//�G���h���X
        OnePut, //�����v�b�g
        Defense,//�h�q
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
}

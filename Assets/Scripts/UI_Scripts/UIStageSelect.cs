using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStageSelect : MonoBehaviour
{
    public GameObject[] objSecret;
    public TMP_Text[] textGameMode;
    public Image[] imgSignal;
    public TMP_Text textStageLevel;
    public TMP_Text textSpeed;
    public Image imgCustomAlpha;

    private int totalStage = GameBase.totalStage;
    private string[] strGameMode = {"ノーマル", "スコア", "ディフェンス" };
    private string[] strStageLevel = { "普<space=10>通", "準<space=10>急", "急<space=10>行", "特<space=10>急", "超特急", "複線ドリフト" };
    private int[] fontSize = { 48, 48, 48, 48, 48, 32 };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Stage1", 1);
        PlayerPrefs.SetInt("Stage2", 1);
        PlayerPrefs.SetInt("Stage3", 1);
        PlayerPrefs.SetInt("Stage4", 1);
        PlayerPrefs.SetInt("Stage5", 0);
        PlayerPrefs.SetInt("Stage6", 0);
        PlayerPrefs.Save();

        textGameMode[0].text = strGameMode[GameBase.gameMode] + "モード";
        textGameMode[1].text = ((GameMode)GameBase.gameMode).ToString() + " Mode";

        if(StageClear())
        {
            if(totalStage != (int)StageLevel.MultiTrackDrifting + 1)
            {
                totalStage++;
                GameBase.totalStage = totalStage;
            }

            if (totalStage == (int)StageLevel.SuperLimitedExpress + 1)
            {
                objSecret[0].SetActive(false);
            }
            else if (totalStage == (int)StageLevel.MultiTrackDrifting + 1)
            {
                objSecret[0].SetActive(false);
                objSecret[1].SetActive(false);
            }
        }

        for (int index = 0; index < totalStage; index++)
        {
            if      (PlayerPrefs.GetInt($"Stage{index + 1}") == 1) imgSignal[index].color = GameBase.signalRed;
            else if (PlayerPrefs.GetInt($"Stage{index + 1}") == 2) imgSignal[index].color = GameBase.signalBlue;
        }

        imgCustomAlpha.enabled = PlayerPrefs.GetInt($"Stage{GameBase.stage}") == 2 ? false : true;
    }

    bool StageClear()
    {
        for (int index = 0; index < totalStage; index++)
            if (PlayerPrefs.GetInt($"Stage{index + 1}") == 1) return false;

        return true;
    }

    public void SetStageInfo(int valve)
    {
        GameBase.stage = valve + 1;
        textStageLevel.text = strStageLevel[valve];
        textStageLevel.fontSize = fontSize[valve];
        textSpeed.text = GameBase.baseSpeed[valve].ToString();

        imgCustomAlpha.enabled = PlayerPrefs.GetInt($"Stage{GameBase.stage}") == 2 ? false : true;
    }
}

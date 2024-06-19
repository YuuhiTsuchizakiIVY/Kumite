using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject HpGauge;
    GameObject SkillGauge;
    GameObject PortionNum;
    public EnemyController EnemyController;
    GameObject TimerText;
    GameObject GameOverTime;
    public GameObject GameOverCanvas;
    int Exp;
    int PlayerLevel;
    int ExpLimit;
    public int BonusATK;
    public int BonusEnemyHP;
    float NowTime = 0.0f;
    public float TimeEnd = 0.0f;
    int Span;
    float SpanTime;
    bool GameOver;
    public bool SkillOK;
    public int NowPortionNum;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
        HpGauge = GameObject.Find("hpGauge");
        TimerText = GameObject.Find("Time");
        SkillGauge = GameObject.Find("SkillGauge");
        PortionNum = GameObject.Find("PortionNum");
        //EnemyController = GameObject.Find("Skelton").GetComponent<EnemyController>();
        SkillGauge.GetComponent<Image>().fillAmount -= 50.0f;
        Exp = 0;
        PlayerLevel = 1;
        ExpLimit = 5;
        BonusATK = 0;
        NowPortionNum = 0;
        Span = 10;
        SpanTime = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        if (!GameOver)
        {
            NowTime += Time.deltaTime;
            SpanTime += Time.deltaTime;
            TimeEnd += Time.deltaTime;
        }
        

        if (SpanTime >= Span)
        {
            BonusEnemyHP += 10;
            SpanTime = 0;
        }

        if (ExpLimit < Exp)        //レベルアップの判定
        {
            PlayerLevel++;
            ExpLimit = ExpLimit + 8 + PlayerLevel;        //レベル上限を増やす
            BonusATK = BonusATK + 3;                      //攻撃力をアップする
        }

        TimerText.GetComponent<TextMeshProUGUI>().text =
            NowTime.ToString("F1");

        if (CheckHp())      //HPが0になったとき
        {
            GameOver = true;
            GameOverCanvas.SetActive(true);
            GameOverTime = GameObject.Find("GameOverTime");
            GameOverTime.GetComponent<TextMeshProUGUI>().text =
            NowTime.ToString("F1");
        }

        if(SkillGauge.GetComponent<Image>().fillAmount == 1.0)     //スキルゲージの量を判定
        {
            SkillOK = true;
        }
        else
        {
            SkillOK = false;
        }
        PortionNum.GetComponent<TextMeshProUGUI>().text =
             NowPortionNum.ToString("D");
        SkillGauge.GetComponent<Image>().fillAmount += 0.00005f;   //スキルゲージを時間経過で回復
    }

    public void DecreaseHp()
    {
        HpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }

    public void DecreaseHp_Tama()
    {
        HpGauge.GetComponent<Image>().fillAmount -= 0.10f;
    }

    public void DecreaseSkillGauge()
    {
        SkillGauge.GetComponent<Image>().fillAmount -= 1.0f;
    }

    public void PlusSkillGauge()
    {
       SkillGauge.GetComponent<Image>().fillAmount += 0.05f;
    }

    public void Portion_Heal()
    {
        HpGauge.GetComponent<Image>().fillAmount += 0.10f;
    }

    public bool CheckHp()
    {
        bool check;
        if (HpGauge.GetComponent<Image>().fillAmount < 0.001)
        {
            check = true;
        }
        else
        {
            check = false;
        }
        return check;
    }

    public void Plus_Exp()
    {
        Exp++;
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}

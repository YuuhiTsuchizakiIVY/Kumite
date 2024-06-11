using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    public GameObject SkillGauge;
    public GameObject PortionNum;
    Enemy_Generator enemy_GeneratorScript;
    EnemyController enemy_ConScript;
    GameOverTime GameOverTimeText;
    GameObject timerText;
    GameObject GameOverTime;
    public GameObject GO_Canvas;
    int Exp;
    int P_Level;
    int Exp_Limit;
    public int Bonus_ATK;
    float time = 0.0f;
    public float timeEnd = 0.0f;
    bool GameOver;
    public bool SkillOK;
    public int nowPortionNum;

    // Start is called before the first frame update
    void Start()
    {
        GO_Canvas.SetActive(false);
        this.hpGauge = GameObject.Find("hpGauge");
        this.timerText = GameObject.Find("Time");
        this.SkillGauge = GameObject.Find("SkillGauge");
        this.PortionNum = GameObject.Find("PortionNum");
        enemy_GeneratorScript = GameObject.Find("Enemy_Generator").GetComponent<Enemy_Generator>();
        enemy_ConScript = GameObject.Find("Enemy").GetComponent<EnemyController>();
        //this.SkillGauge.GetComponent<Image>().fillAmount -= 100.0f;
        Exp = 0;
        P_Level = 1;
        Exp_Limit = 5;
        Bonus_ATK = 0;
        nowPortionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        if (!GameOver)
        {
            this.time += Time.deltaTime;
            timeEnd += Time.deltaTime;
        }
        

        if (this.time / 10 == 0)
        {
            enemy_ConScript.E_HP += 10;
        }

        if (Exp_Limit < Exp)
        {
            P_Level++;
            Exp_Limit = Exp_Limit + 8 + P_Level;
            Bonus_ATK = Bonus_ATK + 3;
            Debug.Log("Level" + P_Level);
            Debug.Log("Bonus_ATK" + Bonus_ATK);
            Debug.Log("Exp_Limit" + Exp_Limit);
        }

        this.timerText.GetComponent<TextMeshProUGUI>().text =
            this.time.ToString("F1");

        if (CheckHp())
        {
            GameOver = true;
            GO_Canvas.SetActive(true);
            this.GameOverTime = GameObject.Find("GameOverTime");
            this.GameOverTime.GetComponent<TextMeshProUGUI>().text =
             this.time.ToString("F1");
        }

        if(this.SkillGauge.GetComponent<Image>().fillAmount == 1.0)
        {
            SkillOK = true;
        }
        else
        {
            SkillOK = false;
        }
        this.PortionNum.GetComponent<TextMeshProUGUI>().text =
             this.nowPortionNum.ToString("D");
        this.SkillGauge.GetComponent<Image>().fillAmount += 0.00005f;
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }

    public void DecreaseHp_Tama()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.10f;
    }

    public void DecreaseSkillGauge()
    {
        this.SkillGauge.GetComponent<Image>().fillAmount -= 1.0f;
    }

    public void PlusSkillGauge()
    {
        this.SkillGauge.GetComponent<Image>().fillAmount += 0.08f;
    }

    public void Portion_Heal()
    {
        this.hpGauge.GetComponent<Image>().fillAmount += 0.10f;
    }

    public bool CheckHp()
    {
        bool check;
        if (this.hpGauge.GetComponent<Image>().fillAmount < 0.001)
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
        Debug.Log("現在のEXP" + Exp);
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

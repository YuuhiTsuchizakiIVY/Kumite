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
    EnemyController EnemyController;
    GameObject TimerText;
    GameObject GameOverTime;
    public GameObject GameOverCanvas;
    int Exp;
    int PlayerLevel;
    int ExpLimit;
    public int BonusATK;
    float time = 0.0f;
    public float TimeEnd = 0.0f;
    bool GameOver;
    public bool SkillOK;
    public int NowPortionNum;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
        this.HpGauge = GameObject.Find("hpGauge");
        this.TimerText = GameObject.Find("Time");
        this.SkillGauge = GameObject.Find("SkillGauge");
        this.PortionNum = GameObject.Find("PortionNum");
        EnemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
        this.SkillGauge.GetComponent<Image>().fillAmount -= 50.0f;
        Exp = 0;
        PlayerLevel = 1;
        ExpLimit = 5;
        BonusATK = 0;
        NowPortionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        if (!GameOver)
        {
            this.time += Time.deltaTime;
            TimeEnd += Time.deltaTime;
        }
        

        if (this.time / 10 == 0)
        {
            EnemyController.EnemyHP += 10;
        }

        if (ExpLimit < Exp)        //���x���A�b�v�̔���
        {
            PlayerLevel++;
            ExpLimit = ExpLimit + 8 + PlayerLevel;        //���x������𑝂₷
            BonusATK = BonusATK + 3;                  //�U���͂��A�b�v����
        }

        this.TimerText.GetComponent<TextMeshProUGUI>().text =
            this.time.ToString("F1");

        if (CheckHp())      //HP��0�ɂȂ����Ƃ�
        {
            GameOver = true;
            GameOverCanvas.SetActive(true);
            this.GameOverTime = GameObject.Find("GameOverTime");
            this.GameOverTime.GetComponent<TextMeshProUGUI>().text =
             this.time.ToString("F1");
        }

        if(this.SkillGauge.GetComponent<Image>().fillAmount == 1.0)     //�X�L���Q�[�W�̗ʂ𔻒�
        {
            SkillOK = true;
        }
        else
        {
            SkillOK = false;
        }
        this.PortionNum.GetComponent<TextMeshProUGUI>().text =
             this.NowPortionNum.ToString("D");
        this.SkillGauge.GetComponent<Image>().fillAmount += 0.00005f;   //�X�L���Q�[�W�����Ԍo�߂ŉ�
    }

    public void DecreaseHp()
    {
        this.HpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }

    public void DecreaseHp_Tama()
    {
        this.HpGauge.GetComponent<Image>().fillAmount -= 0.10f;
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
        this.HpGauge.GetComponent<Image>().fillAmount += 0.10f;
    }

    public bool CheckHp()
    {
        bool check;
        if (this.HpGauge.GetComponent<Image>().fillAmount < 0.001)
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
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }

}

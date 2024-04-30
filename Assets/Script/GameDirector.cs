using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    Enemy_Generator enemy_GeneratorScript;
    EnemyController enemy_ConScript;
    int Exp;
    int P_Level;
    int Exp_Limit;
    public int Bonus_ATK;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        enemy_GeneratorScript = GameObject.Find("Enemy_Generator").GetComponent<Enemy_Generator>();
        enemy_ConScript = GameObject.Find("Enemy").GetComponent<EnemyController>();
        Exp = 0;
        P_Level = 1;
        Exp_Limit = 5;
        Bonus_ATK = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;

        if(this.time / 10 == 0)
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
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }

    public void DecreaseHp_Tama()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.10f;
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
        Debug.Log("Œ»Ý‚ÌEXP" + Exp);
    }

    /*void EnemyGene(float time)
    {
        if(time < 5)
        {
            for(int num = 0;num < 5; num++)
            {
                Invoke("Gene", 0.3f);
            }
            //Invoke("Gene", 0.3f);
            
        }
    }

    void Gene()
    {
        enemy_GeneratorScript.Enemy_Gene();
    }*/

  }

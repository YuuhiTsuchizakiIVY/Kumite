using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    #region//インスペクターで設定する
    float speed = 1;
    [Header("重力")] public float Gravity;
    GameObject Player;
    HeroKnight PlayerScript;
    Orb_Generator OrbGenerator;
    GameDirector GameDirectorScript;
    #endregion

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    public Vector3 _PlayerPosition;
    public Vector3 _EnemyPosition;
    int xVector;
    bool Move = true;
    bool Death = false;
    int EnemyHP;
    int cnt = 0;
    private Animator EnemyAnimator;

    HealPortion_Generator HealPortionGenerator;
    Transform PlayerTransform;
    Transform EnemyTransform;

    E2_firetama Enemy2Firetama;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Player = GameObject.Find("HeroKnight");
        PlayerScript = Player.GetComponent<HeroKnight>();

        OrbGenerator = GameObject.Find("Orb_Generator").GetComponent<Orb_Generator>();
        HealPortionGenerator = GameObject.Find("HPortion_Generator").GetComponent<HealPortion_Generator>();

        GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        EnemyAnimator = GetComponent<Animator>();
        EnemyHP = 50;

        PlayerTransform = Player.transform;
        EnemyTransform = this.transform;

        Enemy2Firetama = GameObject.Find("Enemy2_firetama").gameObject.GetComponent<E2_firetama>();
    }

    void Update()
    {
        _PlayerPosition = PlayerTransform.position;
        _EnemyPosition = EnemyTransform.position;
        if (EnemyHP <= 0)
        {
            
            if (cnt == 0)
            {
                cnt++;
                EnemyAnimator.SetTrigger("death");
                Invoke("destroy", 1.0f);
            }
            Death = true;
            
        }

        if (!Death && Move)
        {

            if (_PlayerPosition.x < _EnemyPosition.x)  //敵が左を向く
            {
                xVector = -1;
                transform.localScale = new Vector3(-3, 3, 3);
            }
            else
            {                       //敵が左を向く
                xVector = 1;
                transform.localScale = new Vector3(3, 3, 3);
            }
            if (_EnemyPosition.x - _PlayerPosition.x < 3 && _EnemyPosition.x - _PlayerPosition.x >= 2 || _EnemyPosition.x - _PlayerPosition.x < -3 && _EnemyPosition.x - _PlayerPosition.x <= -2)
            {
                rb.velocity = new Vector2(xVector * speed, 0.1f);
            }
            else
            {
                MoveStop();
                Invoke("MoveStart", 1.0f);
            }
        }

        if (!Move)
        {
            rb.velocity = new Vector2(xVector * speed, 0.05f);
        }
    }

    void FixedUpdate()
    {
        

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject director = GameObject.Find("GameDirector");
        if (collision.gameObject.tag == "Player" && !Death)       //プレイヤーに触れたらダメージを与える
        {
            director.GetComponent<GameDirector>().DecreaseHp();     //プレイヤーにダメージを与える
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ATK")      //攻撃判定に触れたら
        {
            KnockBack();
            ATKDamage();
            Enemy2Firetama.Delta = 0.0f;
        }
    }

    void MoveStart()
    {
        Move = true;
        EnemyAnimator.SetBool("damage", false);
        EnemyAnimator.SetBool("run", Move);
    }

    void MoveStop()
    {
        Move = false;
    }

    void destroy()
    {
        OrbGenerator.OrbGenerate(_EnemyPosition);
        GameDirectorScript.PlusSkillGauge();
        int rnd = (int)Random.Range(1.0f, 101.0f);
        if(rnd < 31)
        {
            HealPortionGenerator.HealPortionGenerate(_EnemyPosition);
        }        
        Destroy(this.gameObject);
    }

    void KnockBack()
    {
        Move = false;
        if (xVector == 1)                       //向きに応じてノックバックする
        {
            this.rb.velocity = new Vector2(-1, 0);
        }
        else
        {
            this.rb.velocity = new Vector2(1, 0);
        }
        Invoke("MoveStart", 0.3f);
    }

    void ATKDamage()
    {
        switch (PlayerScript.m_currentAttack)   //プレイヤーの攻撃の段階によってダメージを受ける
        {
            case 1:
                EnemyHP = EnemyHP - (15 + GameDirectorScript.BonusATK);
                break;
            case 2:
                EnemyHP = EnemyHP - (20 + GameDirectorScript.BonusATK);
                break;
            case 3:
                EnemyHP = EnemyHP - (30 + GameDirectorScript.BonusATK);
                break;
            default:
                EnemyHP = EnemyHP - (15 + GameDirectorScript.BonusATK);
                break;
        }
        EnemyAnimator.SetBool("damage", true);
    }
}
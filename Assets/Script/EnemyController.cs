using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region//インスペクターで設定する
    float Speed = 1.5f;
    [Header("重力")] public float Gravity;
    GameObject Player;
    HeroKnight HeroKnight;
    Orb_Generator OrbGenerator;
    GameDirector GameDirector;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    #endregion
    Vector3 _PlayerPosition;
    public Vector3 _EnemyPosition;
    int xVector;
    bool Move = false;
    bool Death = false;
    public int EnemyHP;
    int cnt = 0;
    private Animator EnemyAnimator;

    Transform PlayerTransform;
    Transform EnemyTransform;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Player = GameObject.Find("HeroKnight");
        HeroKnight = Player.GetComponent<HeroKnight>();

        OrbGenerator = GameObject.Find("Orb_Generator").GetComponent<Orb_Generator>();

        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        EnemyAnimator = GetComponent<Animator>();
        EnemyHP = 50 + GameDirector.BonusEnemyHP;
        Debug.Log("EnemyHP" + EnemyHP);
        PlayerTransform = Player.transform;
        EnemyTransform = this.transform;
    }

    void FixedUpdate()
    {
        _PlayerPosition = PlayerTransform.position;
        _EnemyPosition = EnemyTransform.position;
        if (Move && !Death)
        {

            if (_PlayerPosition.x < _EnemyPosition.x)  //敵が左を向く
            {
                xVector = -1;
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {                       //敵が左を向く
                xVector = 1;
                transform.localScale = new Vector3(2, 2, 2);
            }

            rb.velocity = new Vector2(xVector * Speed, - Gravity);
        }

        if(EnemyHP <= 0)
        {
            Death = true;

            if(cnt == 0)
            {
                EnemyAnimator.SetBool("death", true);
                cnt++;
                Invoke("destroy", 1.3f);
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Move = true;
            EnemyAnimator.SetBool("run", Move);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject director = GameObject.Find("GameDirector");
        if (collision.gameObject.tag == "Player" && !Death)       //プレイヤーに触れたらダメージを与える
        {
            director.GetComponent<GameDirector>().DecreaseHp();     //プレイヤーにダメージを与える
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Move = false;
            EnemyAnimator.SetBool("run", Move);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ATK")      //攻撃判定に触れたら
        {
            KnockBack();
            ATKDamage();
        }   
    }

    void MoveStart()
    {
        Move = true;
    }

    void destroy()
    {
        OrbGenerator.OrbGenerate(_EnemyPosition);
        GameDirector.PlusSkillGauge();
        Destroy(this.gameObject);
    }

    void KnockBack()
    {
        Move = false;
        if (xVector == 1)                       //向きに応じてノックバックする
        {
            this.rb.velocity = new Vector2(-3, 2);
        }
        else
        {
            this.rb.velocity = new Vector2(3, 2);
        }
    }

    void ATKDamage()
    {
        switch (HeroKnight.m_currentAttack)   //プレイヤーの攻撃の段階によってダメージを受ける
        {
            case 1:
                EnemyHP = EnemyHP - (15 + GameDirector.BonusATK);
                break;
            case 2:
                EnemyHP = EnemyHP - (20 + GameDirector.BonusATK);
                break;
            case 3:
                EnemyHP = EnemyHP - (30 + GameDirector.BonusATK);
                break;
            default:
                EnemyHP = EnemyHP - (15 + GameDirector.BonusATK);
                break;
        }
        EnemyAnimator.SetTrigger("damage");
    }

    public void Jump()
    {
        Move = false;
        if (xVector == 1)                       //向きに応じてジャンプする
        {
            this.rb.velocity = new Vector2(1, 5);   //右向き
        }
        else
        {
            this.rb.velocity = new Vector2(-1, 5);  //左向き
        }
    }
}
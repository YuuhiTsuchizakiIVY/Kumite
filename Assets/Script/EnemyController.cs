using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region//インスペクターで設定する
    float speed = 1.5f;
    [Header("重力")] public float gravity;
    GameObject Player;
    HeroKnight PlayerScript;
    Orb_Generator Orb_GeneratorScript;
    HealPortion_Generator HPortion_GeneratorScript;
    GameDirector GameDirectorScript;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    #endregion
    Vector3 P_pos;
    public Vector3 E_pos;
    int xVector;
    bool move = false;
    bool death = false;
    public int E_HP;
    private Animator e_animator;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Player = GameObject.Find("HeroKnight");
        PlayerScript = Player.GetComponent<HeroKnight>();

        Orb_GeneratorScript = GameObject.Find("Orb_Generator").GetComponent<Orb_Generator>();
        HPortion_GeneratorScript = GameObject.Find("HPortion_Generator").GetComponent<HealPortion_Generator>();

        GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        e_animator = GetComponent<Animator>();
        E_HP = 50;
    }

    void FixedUpdate()
    {
        P_pos = Player.transform.position;
        E_pos = this.transform.position;
        if (Orb_GeneratorScript == null)
        {
            Debug.LogError("Player、HeroKnightスクリプト、またはOrb_Generatorスクリプトがnullだよ。");
            return;
        }
        if (move && !death)
        {

            if (P_pos.x < E_pos.x)  //敵が左を向く
            {
                xVector = -1;
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {                       //敵が左を向く
                xVector = 1;
                transform.localScale = new Vector3(2, 2, 2);
            }

            rb.velocity = new Vector2(xVector * speed, -gravity);
        }

        if(E_HP <= 0)
        {
            death = true;
            int cnt = 0;
            if(cnt == 0)
            {
                e_animator.SetBool("death", true);
                cnt++;
            }
            
            
            Invoke("destroy", 1.0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            move = true;
            e_animator.SetBool("run", move);
            e_animator.SetBool("damage", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject director = GameObject.Find("GameDirector");
        if (collision.gameObject.tag == "Player" && !death)       //プレイヤーに触れたらダメージを与える
        {
            director.GetComponent<GameDirector>().DecreaseHp();     //プレイヤーにダメージを与える
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            move = false;
            e_animator.SetBool("run", move);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ATK")      //攻撃判定に触れたら
        {
            Knock_Back();
            ATK_damage();
        }   
    }

    void moveStart()
    {
        move = true;
    }

    void destroy()
    {
        Orb_GeneratorScript.Orb_Gene(E_pos);
        GameDirectorScript.PlusSkillGauge();
        //HPortion_GeneratorScript.HPortion_Gene(E_pos);
        Destroy(this.gameObject);
    }

    void Knock_Back()
    {
        move = false;
        if (xVector == 1)                       //向きに応じてノックバックする
        {
            this.rb.velocity = new Vector2(-3, 2);
            //Debug.Log("右向き＿左飛び");
        }
        else
        {
            this.rb.velocity = new Vector2(3, 2);
            //Debug.Log("左向き＿右飛び");
        }
    }

    void ATK_damage()
    {
        switch (PlayerScript.m_currentAttack)   //プレイヤーの攻撃の段階によってダメージを受ける
        {
            case 1:
                E_HP = E_HP - (15 + GameDirectorScript.Bonus_ATK);
                break;
            case 2:
                E_HP = E_HP - (20 + GameDirectorScript.Bonus_ATK);
                break;
            case 3:
                E_HP = E_HP - (30 + GameDirectorScript.Bonus_ATK);
                break;
            default:
                E_HP = E_HP - (15 + GameDirectorScript.Bonus_ATK);
                break;
        }
        e_animator.SetBool("damage", true);
        Debug.Log(E_HP);
    }

    public void Jump()
    {
        move = false;
        if (xVector == 1)                       //向きに応じてジャンプする
        {
            this.rb.velocity = new Vector2(1, 5);   //右向き
        }
        else
        {
            this.rb.velocity = new Vector2(-1, 5);  //左向き
        }
    }

    public void Test()
    {
        Debug.Log("test");
    }
}
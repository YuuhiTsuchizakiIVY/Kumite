using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    float speed = 1;
    [Header("�d��")] public float gravity;
    GameObject Player;
    HeroKnight PlayerScript;
    Orb_Generator Orb_GeneratorScript;
    GameDirector GameDirectorScript;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    #endregion
    public Vector3 P_pos;
    public Vector3 E_pos;
    int xVector;
    bool move = true;
    bool death = false;
    int E_HP;
    private Animator e_animator;
    float span = 2.0f;
    float delta = 0;
    HealPortion_Generator HPortion_GeneratorScript;

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

    void Update()
    {
        if (!death && move)
        {

            if (P_pos.x < E_pos.x)  //�G����������
            {
                xVector = -1;
                transform.localScale = new Vector3(-3, 3, 3);
            }
            else
            {                       //�G����������
                xVector = 1;
                transform.localScale = new Vector3(3, 3, 3);
            }
            if (E_pos.x - P_pos.x < 3 && E_pos.x - P_pos.x >= 2 || E_pos.x - P_pos.x < -3 && E_pos.x - P_pos.x <= -2)
            {
                rb.velocity = new Vector2(xVector * speed, 0.1f);
            }
            else
            {
                moveStop();
                Invoke("moveStart", 1.0f);
            }
        }

        if (!move)
        {
            rb.velocity = new Vector2(xVector * speed, -0.05f);
        }
    }

    void FixedUpdate()
    {
        this.delta += Time.deltaTime;
        P_pos = Player.transform.position;
        E_pos = this.transform.position;
        if (Orb_GeneratorScript == null)
        {
            Debug.LogError("Player�AHeroKnight�X�N���v�g�A�܂���Orb_Generator�X�N���v�g��null����B");
            return;
        }
        
        if (E_HP <= 0)
        {
            death = true;
            e_animator.SetBool("death", true);
            Invoke("destroy", 1.0f);
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject director = GameObject.Find("GameDirector");
        if (collision.gameObject.tag == "Player" && !death)       //�v���C���[�ɐG�ꂽ��_���[�W��^����
        {
            director.GetComponent<GameDirector>().DecreaseHp();     //�v���C���[�Ƀ_���[�W��^����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ATK")      //�U������ɐG�ꂽ��
        {
            Knock_Back();
            ATK_damage();
        }
    }

    void moveStart()
    {
        move = true;
        e_animator.SetBool("damage", false);
        e_animator.SetBool("run", move);
    }

    void moveStop()
    {
        move = false;
    }

    void destroy()
    {
        Orb_GeneratorScript.Orb_Gene(E_pos);
        GameDirectorScript.PlusSkillGauge();
        int rnd = (int)Random.Range(1.0f, 101.0f);
        if(rnd < 31)
        {
            HPortion_GeneratorScript.HPortion_Gene(E_pos);
        }
        
        Destroy(this.gameObject);
    }

    void Knock_Back()
    {
        move = false;
        if (xVector == 1)                       //�����ɉ����ăm�b�N�o�b�N����
        {
            this.rb.velocity = new Vector2(-1, 0);
            //Debug.Log("�E�����Q�����");
        }
        else
        {
            this.rb.velocity = new Vector2(1, 0);
            //Debug.Log("�������Q�E���");
        }
        Invoke("moveStart", 0.3f);
    }

    void ATK_damage()
    {
        switch (PlayerScript.m_currentAttack)   //�v���C���[�̍U���̒i�K�ɂ���ă_���[�W���󂯂�
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

    void Test()
    {
        Debug.Log("test");
    }

}
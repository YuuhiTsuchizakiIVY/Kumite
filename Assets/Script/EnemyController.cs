using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float Speed = 1.5f;
    [Header("�d��")] public float Gravity;
    GameObject Player;
    HeroKnight HeroKnight;
    Orb_Generator OrbGenerator;
    GameDirector GameDirector;

    private Rigidbody2D RigitBody = null;
    private SpriteRenderer SpriteRenderer = null;
    private bool rightTleftF = false;

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
        RigitBody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        Player = GameObject.Find("HeroKnight");
        HeroKnight = Player.GetComponent<HeroKnight>();

        OrbGenerator = GameObject.Find("Orb_Generator").GetComponent<Orb_Generator>();

        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        EnemyAnimator = GetComponent<Animator>();
        EnemyHP = 50 + GameDirector.BonusEnemyHP;
        PlayerTransform = Player.transform;
        EnemyTransform = this.transform;
    }

    void FixedUpdate()
    {
        _PlayerPosition = PlayerTransform.position;
        _EnemyPosition = EnemyTransform.position;
        if (Move && !Death)
        {

            if (_PlayerPosition.x < _EnemyPosition.x)  //�G����������
            {
                xVector = -1;
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {                       //�G����������
                xVector = 1;
                transform.localScale = new Vector3(2, 2, 2);
            }

            RigitBody.velocity = new Vector2(xVector * Speed, - Gravity);
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
        if (collision.gameObject.tag == "Player" && !Death)       //�v���C���[�ɐG�ꂽ��_���[�W��^����
        {
            director.GetComponent<GameDirector>().DecreaseHp();     //�v���C���[�Ƀ_���[�W��^����
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
        if (collision.gameObject.tag == "ATK")      //�U������ɐG�ꂽ��
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
        if (xVector == 1)                       //�����ɉ����ăm�b�N�o�b�N����
        {
            this.RigitBody.velocity = new Vector2(-3, 2);
        }
        else
        {
            this.RigitBody.velocity = new Vector2(3, 2);
        }
    }

    void ATKDamage()
    {
        switch (HeroKnight.m_currentAttack)   //�v���C���[�̍U���̒i�K�ɂ���ă_���[�W���󂯂�
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
        if (xVector == 1)                       //�����ɉ����ăW�����v����
        {
            this.RigitBody.velocity = new Vector2(1, 5.3f);   //�E����
        }
        else
        {
            this.RigitBody.velocity = new Vector2(-1, 5.3f);  //������
        }
    }
}
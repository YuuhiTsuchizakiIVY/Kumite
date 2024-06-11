using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Controller : MonoBehaviour
{
    //[SerializeField] Transform _target;
    GameObject Player;
    Vector3 P_pos;
    Vector3 diff;
    private Rigidbody2D rb = null;

    //transform�Ŗ��t���[���擾����ƕ��ׂ��|����ׁA�ʂɎQ�Ƃ�ێ��B
    Transform tf;

    //-1.0f�Ŏ��v���A1.0f�Ŕ����v���B
    float direction = -1.0f;

    //�ړ����x�Ƃ������ړ��p�x�B
    float moveSpeed = 3.5f;

    //�v���C���[��ǔ����鑬�x�̃��[�g(�傫��������)�B
    float followRate = 0.5f;

    //�ǔ�����|�C���g�̃v���C���[����̋���(�܂菬�������A�ߕt��)�B
    float followTargetDistance = 2.0f;

    //�@���񂷂�^�[�Q�b�g
    
    private Transform target;
    //�@���݂̊p�x
    private float angle;
    //�@��]����X�s�[�h
    [SerializeField]
    private float rotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1.1f, 0f);
    //�@�e���΂���
    [SerializeField]
    private float shotPower = 1000f;


    bool hassha;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RotateCenter");
        target = Player.transform;
    }

    private void Awake()
    {
        tf = transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        P_pos = Player.transform.position;
        if (!hassha)
        {
            //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
            transform.position = target.position + Quaternion.Euler(0f, 0f, angle) * distanceFromTarget;
            //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
            transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z), Vector3.up);
            //�@���j�b�g�̊p�x��ύX
            angle += rotateSpeed * Time.deltaTime;
            //�@�p�x��0�`360�x�̊ԂŌJ��Ԃ�
            angle = Mathf.Repeat(angle, 360f);
            //������Ƀv���C���[�̕����������悤�ɂ���
            diff = (this.transform.position - Player.gameObject.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //this.rb.velocity = new Vector2(0, 3);
            
        }




    }

    public void ShootStart()
    {
        StartCoroutine(Shoot());
    }
    
    public IEnumerator Shoot()
    {
        Debug.Log("shoot");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("shoot1");
        hassha = true;
        rb.AddForce(transform.up * shotPower, ForceMode2D.Force);
        Destroy(this.gameObject, 3f);
    }
}
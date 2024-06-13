using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Controller : MonoBehaviour
{
    //[SerializeField] Transform _target;
    GameObject Player;
    Vector3 diff;
    private Rigidbody2D RigitBody = null;
    //�@���񂷂�^�[�Q�b�g  
    private Transform Target;
    //�@���݂̊p�x
    private float Angle;
    //�@��]����X�s�[�h
    [SerializeField]
    private float RotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1.1f, 0f);
    //�@�e���΂���
    [SerializeField]
    private float ShotPower = 1000f;

    bool Hassha;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RotateCenter");
        Target = Player.transform;
        RigitBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Hassha)
        {
            //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
            transform.position = Target.position + Quaternion.Euler(0f, 0f, Angle) * distanceFromTarget;
            //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
            transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(Target.position.x, transform.position.y, Target.position.z), Vector3.up);
            //�@���j�b�g�̊p�x��ύX
            Angle += RotateSpeed * Time.deltaTime;
            //�@�p�x��0�`360�x�̊ԂŌJ��Ԃ�
            Angle = Mathf.Repeat(Angle, 360f);
            //������Ƀv���C���[�̕����������悤�ɂ���
            diff = (this.transform.position - Player.gameObject.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        }
    }

    public void ShotStart()
    {
        StartCoroutine(Shot());
    }
    
    public IEnumerator Shot()
    {
        yield return new WaitForSeconds(3.0f);
        Hassha = true;
        RigitBody.AddForce(transform.up * ShotPower, ForceMode2D.Force);
        Destroy(this.gameObject, 3f);
    }
}
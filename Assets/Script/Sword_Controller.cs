using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Controller : MonoBehaviour
{
    //[SerializeField] Transform _target;
    GameObject Player;
    Vector3 diff;
    private Rigidbody2D RigitBody = null;
    //　旋回するターゲット  
    private Transform Target;
    //　現在の角度
    private float Angle;
    //　回転するスピード
    [SerializeField]
    private float RotateSpeed = 180f;
    //　ターゲットからの距離
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1.1f, 0f);
    //　弾を飛ばす力
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
            //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
            transform.position = Target.position + Quaternion.Euler(0f, 0f, Angle) * distanceFromTarget;
            //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
            transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(Target.position.x, transform.position.y, Target.position.z), Vector3.up);
            //　ユニットの角度を変更
            Angle += RotateSpeed * Time.deltaTime;
            //　角度を0～360度の間で繰り返す
            Angle = Mathf.Repeat(Angle, 360f);
            //剣が常にプレイヤーの方向を向くようにする
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
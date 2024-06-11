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

    //transformで毎フレーム取得すると負荷が掛かる為、別に参照を保持。
    Transform tf;

    //-1.0fで時計回り、1.0fで反時計回り。
    float direction = -1.0f;

    //移動速度というか移動角度。
    float moveSpeed = 3.5f;

    //プレイヤーを追尾する速度のレート(大きい程高速)。
    float followRate = 0.5f;

    //追尾するポイントのプレイヤーからの距離(つまり小さい程、近付く)。
    float followTargetDistance = 2.0f;

    //　旋回するターゲット
    
    private Transform target;
    //　現在の角度
    private float angle;
    //　回転するスピード
    [SerializeField]
    private float rotateSpeed = 180f;
    //　ターゲットからの距離
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1.1f, 0f);
    //　弾を飛ばす力
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
            //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
            transform.position = target.position + Quaternion.Euler(0f, 0f, angle) * distanceFromTarget;
            //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
            transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z), Vector3.up);
            //　ユニットの角度を変更
            angle += rotateSpeed * Time.deltaTime;
            //　角度を0～360度の間で繰り返す
            angle = Mathf.Repeat(angle, 360f);
            //剣が常にプレイヤーの方向を向くようにする
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
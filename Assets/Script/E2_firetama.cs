using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_firetama : MonoBehaviour
{
    public GameObject enemyTamaPrefab;
    GameObject enemyTama;
    Rigidbody2D enemyTamaRb;
    private GameObject target;
    public float speed;
    private int timeCount = 0;
    GameObject oya;
    Enemy2Controller oyaScript;
    Vector3 Targethosei;
    void Start()
    {
        oya = transform.parent.gameObject;
        oyaScript = oya.GetComponent<Enemy2Controller>();
        Targethosei = new Vector3(0, 1, 0);
        target = GameObject.Find("HeroKnight");
    }

    void Update()
    {
        timeCount += 1;

        transform.LookAt(target.transform.position + Targethosei);
        if (timeCount % 600 == 0)
        {
            // “G‚Ì’e‚ğ¶¬‚·‚é
            enemyTama = Instantiate(enemyTamaPrefab, transform.position, Quaternion.identity);
            enemyTamaRb = enemyTama.GetComponent<Rigidbody2D>();

            //’e‚ğ”ò‚Î‚·•ûŒü‚ğŒˆ‚ß‚éB
            enemyTamaRb.AddForce(transform.forward * speed);
            
            // 10•bŒã‚É“G‚Ì’e‚ğíœ‚·‚éB
            Destroy(enemyTama, 10);
        }
    }
}

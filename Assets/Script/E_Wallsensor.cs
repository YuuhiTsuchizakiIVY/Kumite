using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Wallsensor : MonoBehaviour
{
    EnemyController EnemyController;
    // Start is called before the first frame update
    void Start()
    {
        EnemyController = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")    //�ǂɂԂ�������W�����v
        {
            EnemyController.Jump();
        }
    }
}

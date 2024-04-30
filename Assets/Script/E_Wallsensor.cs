using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Wallsensor : MonoBehaviour
{
    EnemyController E_Con;
    // Start is called before the first frame update
    void Start()
    {
        E_Con = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            E_Con.Jump();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    public GameObject Enemy_Prefab;
    float span = 3.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        this.delta += Time.deltaTime;
        if(Time.deltaTime < 20)
        {
            span = 5.0f;
            if (this.delta > this.span)
            {
                this.delta = 0;
                Enemy_Gene();
            }
        }
        else if (Time.deltaTime < 30)
        {
            span = 4.0f;
            if (this.delta > this.span)
            {
                this.delta = 0;
                Enemy_Gene();
            }
        }
        else if (Time.deltaTime < 50)
        {
            span = 3.0f;
            if (this.delta > this.span)
            {
                this.delta = 0;
                Enemy_Gene();
            }
        }
    }

    public void Enemy_Gene()
    {
        GameObject Orb = Instantiate(Enemy_Prefab);
        Orb.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }
}

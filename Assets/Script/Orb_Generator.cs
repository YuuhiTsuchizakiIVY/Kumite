using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Generator : MonoBehaviour
{
    public GameObject OrbPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OrbGenerate(Vector3 EnemyPosition)
    {
        GameObject Orb = Instantiate(OrbPrefab);
        Orb.transform.position = new Vector3(EnemyPosition.x, EnemyPosition.y, 0);
    }
}

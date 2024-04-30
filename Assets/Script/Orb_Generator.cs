using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Generator : MonoBehaviour
{
    public GameObject Orb_Prefab;  // publicに変更してUnityエディタから設定可能にする
    private EnemyController EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Orb_Gene(Vector3 E_pos)
    {
        //Debug.Log("オーブじぇね呼び出し");

        // nullチェックを追加
        if (Orb_Prefab != null)
        {
            GameObject Orb = Instantiate(Orb_Prefab);
            Orb.transform.position = new Vector3(E_pos.x,E_pos.y, 0);
        }
        else
        {
            Debug.LogError("Orb_Prefab or EnemyScript is null.");
        }
    }
}

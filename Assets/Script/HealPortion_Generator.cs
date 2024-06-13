using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPortion_Generator : MonoBehaviour
{
    public GameObject HealPortionPrefab;  // publicに変更してUnityエディタから設定可能にする

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealPortionGenerate(Vector3 EnemyPosition)
    {

        // nullチェックを追加
        if (HealPortionPrefab != null)
        {
            GameObject Orb = Instantiate(HealPortionPrefab);
            Orb.transform.position = new Vector3(EnemyPosition.x, EnemyPosition.y, 0);
        }
        else
        {
            Debug.LogError("HealPortionPrefab or EnemyScript is null.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPortion_Generator : MonoBehaviour
{
    public GameObject HPortion_Prefab;  // public�ɕύX����Unity�G�f�B�^����ݒ�\�ɂ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPortion_Gene(Vector3 E_pos)
    {
        //Debug.Log("�I�[�u�����ˌĂяo��");

        // null�`�F�b�N��ǉ�
        if (HPortion_Prefab != null)
        {
            GameObject Orb = Instantiate(HPortion_Prefab);
            Orb.transform.position = new Vector3(E_pos.x, E_pos.y, 0);
        }
        else
        {
            Debug.LogError("HPortion_Prefab or EnemyScript is null.");
        }
    }
}

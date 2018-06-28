using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Syagami : MonoBehaviour
{
    //変数定義
    bool ONE;           //1回だけ処理のフラグ
    bool smokeFlg;    //煙範囲内にいるかどうか
    Vector3 startPos;   //初期位置の代入する変数
    Vector3 pos;        //常に更新する座標

    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "smokeDamage")
        {//otherには入ってきたオブジェクトが渡されているのでtagを比較しています。
            smokeFlg = true;
           // Debug.Log("煙");
        }
        else
        {
            smokeFlg = false;
            FindObjectOfType<ImageEffectControl>().recovery = true;
        }
 

    }


    
    // Use this for initialization
    void Start()
    {
        ONE = true;
        smokeFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ONE)
        {
            startPos = transform.position;
            ONE = false;

        }
        pos = transform.position;

        if(smokeFlg == true)
        {
            if (pos.y <= startPos.y * 0.65)
            {
                FindObjectOfType<ImageEffectControl>().recovery = true;
            }
            else
            {
                FindObjectOfType<ImageEffectControl>().damageone = true;
            }
            
            Debug.Log("しゃがみ");
        }

        Debug.Log("startPos"+startPos);
        Debug.Log(pos);
    }
}

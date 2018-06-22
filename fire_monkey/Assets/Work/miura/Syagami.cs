using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;


public class Syagami : MonoBehaviour
{
    bool ONE;       //1回だけ処理のフラグ
    int cnt;
    Vector3 startPos;   //初期位置の代入する変数
    Vector3 pos;        //常に更新する座標
    // Use this for initialization
    void Start()
    {
        ONE = true;
        cnt = 0;
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

        if (pos == startPos / 3  )
        {
            Debug.Log(pos);
        }
        Debug.Log("startPos"+startPos);
        Debug.Log(pos);
    }
}

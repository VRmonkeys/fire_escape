using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{ 
    [SerializeField]
    SCENES scene;

    [SerializeField]
    SCENES debug;

    //現在のシーンの名前
    string SceneName;

    //カウント
    public float time;

    //ワープまでの時間
    [SerializeField]
    private float warpTime = 10;

    void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        DebugKey();
    }

    void Move()
    {
        if(SceneName == "GameOver" || SceneName == "Clear")
        {
            time += Time.deltaTime;

            if (time > warpTime)
            {
                SceneManage.SceneMove(scene);
            }
        }
    }

    void DebugKey()
    {
        //タイトルに戻る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }

        //各シーンの初期位置にワープ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManage.SceneMove(debug);
        }
    }
}

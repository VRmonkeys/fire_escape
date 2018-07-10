using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendScene : MonoBehaviour {

    private float time = 0;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OntriggerEnter(Collider other)
    {
        if (other.tag == "door")
        {
            time += Time.deltaTime;
            //ホワイトアウト処理
            SteamVR_Fade.Start(Color.white, 2f);

            //ホワイトアウト終了後メインシーンへ
            if (time > 2)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}

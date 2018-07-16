using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour {

    //6階のマップのスプライト
    public Sprite f6;

    //5階のマップのスプライト
    public Sprite f5;

    SpriteRenderer sprRen;

    //現在のシーンの名前
    string SceneName;

    // Use this for initialization
    void Start () {

        sprRen = GetComponent<SpriteRenderer>();

        SceneName = SceneManager.GetActiveScene().name;

    }
	
	// Update is called once per frame
	void Update () {

        Change();
		
	}

    void Change()
    {
        //シーン毎にマップスプライトを変える
        switch (SceneName)
        {
            case "school6":
                sprRen.sprite = f6;
                break;
            case "school5":
                sprRen.sprite = f5;
                break;
            default:
                break;
        }
    }
}

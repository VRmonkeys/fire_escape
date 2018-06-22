using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class Decision : MonoBehaviour {

    //プレイヤー
    [SerializeField]
    private GameObject area;

    //映すカメラ
    [SerializeField]
    private GameObject cam;

    //ゲームバー
    [SerializeField]
    private GameObject reset;

    //クリア時に表示するスプライト
    [SerializeField]
    private Sprite sprClear;

    //見えないスプライト
    [SerializeField]
    private Sprite sprReset;

    //炎で死んだ時に表示するスプライト
    [SerializeField]
    private Sprite sprFireGameOver;

    //煙で死んだ時に表示するスプライト
    [SerializeField]
    private Sprite sprSmokeGameOver;

    //爆死した時に表示するスプライト
    [SerializeField]
    private Sprite sprDraftGameOver;

    private Renderer _renderer;

    private SpriteRenderer sprRenderer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //ゲームクリア
    private IEnumerator DelayMethod_C(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        sprRenderer.sprite = sprClear;//ゲームクリアスプライト埋め込み表示
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        area.GetComponent<VRTK_HeadsetFade>().Unfade(0);

    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //炎による死亡
    private IEnumerator DelayMethod_F(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);

        yield return new WaitForSeconds(waitTime);

        //炎ゲームオーバー表示
        sprRenderer.sprite = sprFireGameOver;
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        area.GetComponent<VRTK_HeadsetFade>().Unfade(0);

    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //煙による死亡
    private IEnumerator DelayMethod_S(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);

        yield return new WaitForSeconds(waitTime);

        //煙ゲームオーバー表示
        sprRenderer.sprite = sprSmokeGameOver;
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        area.GetComponent<VRTK_HeadsetFade>().Unfade(0);

    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //煙による死亡
    private IEnumerator DelayMethod_B(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);

        yield return new WaitForSeconds(waitTime);

        //煙ゲームオーバー表示
        sprRenderer.sprite = sprDraftGameOver;
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        area.GetComponent<VRTK_HeadsetFade>().Unfade(0);

    }

    //色やスプライトなどを設定するためのセットアップ関数
    public void setUp()
    {
        //Rendererコンポーネントを取得（Material取得のため） ドームの色を変えるためのもの
        _renderer = GetComponent<Renderer>();

        //GameBarを表示するためのスプライトレンダラー
        sprRenderer = reset.GetComponent<SpriteRenderer>(); 
    }

    public void gameOver(string damegeName)
    {

        //色やスプライトなどを設定するためのセットアップ関数　呼び出し
        setUp();

        _renderer.sharedMaterial.EnableKeyword("_EMISSION");//EMISSIONの設定をするための呼び出し
        _renderer.sharedMaterial.SetColor("_EmissionColor", new Color(0, 0, 0));//emissionのCollar変更


        //煙によるゲームーバー
        if (damegeName == "smoke")
        {
            //遅延をしてドームに移動させる
            Coroutine coroutine = StartCoroutine("DelayMethod_S", 3.0f);
        }

        if (damegeName == "fire")
        {
            //遅延をしてドームに移動させる
            Coroutine coroutine = StartCoroutine("DelayMethod_F", 3.0f);
        }

        if (damegeName == "backDraft")
        {
            //遅延をしてドームに移動させる
            Coroutine coroutine = StartCoroutine("DelayMethod_B", 3.0f);
        }


    }

    public void gameClear()
    {

        //色やスプライトなどを設定するためのセットアップ関数　呼び出し
        setUp();

        //EMISSIONの設定をするための呼び出し
        _renderer.sharedMaterial.EnableKeyword("_EMISSION");
                        
        //emissionのCollar変更
        _renderer.sharedMaterial.SetColor("_EmissionColor", new Color(1, 1, 1));

        //ゲームクリアスプライト埋め込み表示
        sprRenderer.sprite = sprClear;                           

        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.white, 2.0f);
        Debug.Log("Clear");

        //遅延をしてドームに移動させる
        Coroutine coroutine = StartCoroutine("DelayMethod_C", 2.0f);


    }


}

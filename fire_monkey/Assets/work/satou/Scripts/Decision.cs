using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class Decision : MonoBehaviour {

    //プレイヤー
    [SerializeField]
    private GameObject area;

    //ゲームクリア
    private IEnumerator DelayMethod_C(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.white, 2.0f);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Clear");
    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //炎による死亡
    private IEnumerator DelayMethod_F(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);
        yield return new WaitForSeconds(waitTime);

        Change.num = 0;
        SceneManager.LoadScene("GameOver");

    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //煙による死亡
    private IEnumerator DelayMethod_S(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);
        yield return new WaitForSeconds(waitTime);

        Change.num = 1;
        SceneManager.LoadScene("GameOver");
    }

    //炎専用遅延処理をしてプレイヤーを移動させる関数
    //煙による死亡
    private IEnumerator DelayMethod_B(float waitTime)
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3.0f);
        yield return new WaitForSeconds(waitTime);

        Change.num = 2;
        SceneManager.LoadScene("GameOver");
    }

    public void gameOver(string damegeName)
    {

        if (damegeName == "fireWall")
        {
                Coroutine coroutine = StartCoroutine("DelayMethod_F", 3.0f);
        }
    }

    public void SmokeDead()
    {
        Coroutine coroutine = StartCoroutine("DelayMethod_S", 1.0f);
    }

    public void DraftDead()
    {
        Coroutine coroutine = StartCoroutine("DelayMethod_B", 1.0f);
    }

    public void gameClear()
    {
        area.GetComponent<VRTK_HeadsetFade>().Fade(Color.white, 2.0f);
        Debug.Log("Clear");

        //遅延をしてドームに移動させる
        Coroutine coroutine = StartCoroutine("DelayMethod_C", 2.0f);
    }


}

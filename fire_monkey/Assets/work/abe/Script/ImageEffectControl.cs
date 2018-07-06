using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ImageEffectControl : MonoBehaviour
{
    //触らない！！
    [SerializeField]
    //private PostProcessingProfile postprocessing;
    public PostProcessingProfile postprocessing;
    private VignetteModel.Settings vig;

    [SerializeField]
    private GameObject decision;

    //このboolean型をtrueにすれば各ダメージ。
    public bool damageone = false;
    //このboolean型をtrueにすれば回復。
    public bool recovery = false;

    //死亡処理のカウントダウンを制御する
    public bool dead = false;
    //死亡までのカウント
    public int deadTime = 0;

    private bool trg = false;




    // Use this for initialization
    void Start()
    {
        vig = postprocessing.vignette.settings;
        vig.intensity = 0.0f;                    //vignetteの初期化
        postprocessing.vignette.settings = vig;  //vignetteへ初期化の値を反映
    }


    // Update is called once per frame
    void Update()
    {

        //ダメージOne
        if (damageone)
        {
            vig.intensity += 0.005f;

            if (vig.intensity >= 0.45f)
            {
                vig.intensity = 0.45f;

                dead = true;
                damageone = false;
            }
            postprocessing.vignette.settings = vig;
        }

        //回復
        if (recovery)
        {
            dead = false;
            vig.intensity -= 0.05f;
            if (vig.intensity <= 0.0f)
            {
                vig.intensity = 0.0f;
                recovery = false;
            }
            postprocessing.vignette.settings = vig;
        }

        if (dead)
        {
            if (deadTime >= 100)
            {
                if(trg == false)
                decision.GetComponent<Decision>().SmokeDead();
                trg = true;
            }
            else
            {
                deadTime++;
            }
        }

    }
}

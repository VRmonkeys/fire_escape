using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ImageEffectControl : MonoBehaviour {


    //触らない！！
   [SerializeField]
    //private PostProcessingProfile postprocessing;


	public PostProcessingProfile postprocessing;
    private VignetteModel.Settings vig;

    // 値が1ならdamageOne 値が2ならdamegeTwo 値が3ならdamageThree
    // 自身にダメージがあるかどうか判定をとるために現在の状態を示すもの
    private int damage;


    //このboolean型をtrueにすれば各ダメージ。
    public bool damageone = false,  damagetwo = false,  damagethree = false;
    //このboolean型をtrueにすれば回復。
    public bool recovery = false;




    // Use this for initialization
    void Start () {
        vig = postprocessing.vignette.settings;


        damage = 0;                              //初期化の状態
        vig.intensity = 0.0f;                    //vignetteの初期化
        postprocessing.vignette.settings = vig;  //vignetteへ初期化の値を反映

    }
	

	// Update is called once per frame
	void Update () {
        
        //ダメージOne
        if(damageone == true)
        {
            vig.intensity += 0.01f;

            if (vig.intensity >= 0.25f)
            {
              damageone = false;
              damage = 1;
            }
            postprocessing.vignette.settings = vig;
        }

        //ダメージTwo
        if(damagetwo == true && damage == 1)
        {
            vig.intensity += 0.01f;

            if (vig.intensity >= 0.45f)
            {
                damagetwo = false;
                damage = 2;
            }
            postprocessing.vignette.settings = vig;
        }

        //ダメージThree
        if (damagethree == true && damage == 2)
        {
            vig.intensity += 0.01f;

            if (vig.intensity >= 0.7f)
            {
                damagethree = false;
                damage = 3;
            }
            postprocessing.vignette.settings = vig;
        }

        //回復
        if(recovery == true)
        {
            vig.intensity -= 0.01f;
            if(vig.intensity <= 0.0f)
            {
                vig.intensity = 0.0f;
                recovery = false;
            }
            postprocessing.vignette.settings = vig;
        }
    }
}

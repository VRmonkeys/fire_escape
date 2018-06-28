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
            vig.intensity += 0.005f;

            if (vig.intensity >= 0.45f)
            {
                vig.intensity = 0.45f;
                damageone = false;
                damage = 1;
            }
            postprocessing.vignette.settings = vig;
        }
       
        //回復
        if(recovery == true)
        {
            vig.intensity -= 0.05f;
            if(vig.intensity <= 0.0f)
            {
                vig.intensity = 0.0f;
                recovery = false;
            }
            postprocessing.vignette.settings = vig;
        }
    }
}

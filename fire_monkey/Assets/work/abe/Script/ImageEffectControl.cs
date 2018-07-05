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

    //このboolean型をtrueにすれば各ダメージ。
    public bool damageone = false;
    //このboolean型をtrueにすれば回復。
    public bool recovery = false;




    // Use this for initialization
    void Start () {
        vig = postprocessing.vignette.settings;
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

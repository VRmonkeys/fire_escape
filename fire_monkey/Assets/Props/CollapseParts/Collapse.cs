using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour {


    private GameObject[] roofparts,particles;
	private Rigidbody[] test = new Rigidbody[6];
    private Vector3 speed;
    private float ran1,ran2,ran3;
    private float time;

    public bool collapseAwake;
    public int roofnum,particlenum;
    public GameObject steelbeams;



    //タグで指定したもの探す
    void Awake()
    {
      roofparts = GameObject.FindGameObjectsWithTag("Roofparts");
      particles = GameObject.FindGameObjectsWithTag("fireEffect");



		for(int i = 0; i < 6; i++) {
			test[i] = roofparts[i].GetComponent<Rigidbody>();
			Debug.Log(test[i]);
		}
    }

    //スタートの状態ではただの天井にするためすべて初期化
    void Start ()
    {
        collapseAwake = false;
        steelbeams.SetActive(false);

        for (int j = 0; j < particlenum; j++) particles[j].SetActive(false);
    }

    void Update()
    {
        if(collapseAwake == true){

            steelbeams.SetActive(true);
            roofCollpase();
            particleContorl();

            collapseAwake = false;
        }
    }

    //天井が落ちる関数　ここでrigidndyもtureにしている
    void roofCollpase()
    {
        speed = transform.TransformDirection(Vector3.down) * (100.0f);
        speed += Vector3.right * (8.0f);

        for (int i = 0; i < roofnum; i++){

            ran1 = Random.Range(10, 100);
            ran2 = Random.Range(10, 75);
            ran3 = Random.Range(0.01f, 0.05f);

            roofparts[i].GetComponent<Rigidbody>().velocity = speed * ran3;
            roofparts[i].GetComponent<Rigidbody>().angularVelocity = Vector3.right * 50;
            roofparts[i].GetComponent<Rigidbody>().rotation = Quaternion.Euler(ran1, ran2, ran2);

            roofparts[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }

    //エフェクトを起動する関数　※trueにするだけなので変更可※
    void particleContorl()
    {
        for (int k = 0; k < particlenum; k++) particles[k].SetActive(true);
    }


}
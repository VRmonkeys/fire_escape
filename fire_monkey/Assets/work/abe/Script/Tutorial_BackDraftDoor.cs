using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_BackDraftDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject decision;

    //private Decision decision;

    private ParticleSystem particle;

    //1回だけ処理するトリガー
    private bool trg = false;

    void Start()
    {
        //decision = GetComponent<Decision>();
        particle = this.GetComponent<ParticleSystem>();

        // ここで Particle System を停止する.
        particle.Stop();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "door")
        {
            // ここで Particle System を開始します.
            particle.Play();

            if (trg == false)
            {
                decision.GetComponent<Decision>().TutorialDead();
                trg = true;
            }
        }
    }
}



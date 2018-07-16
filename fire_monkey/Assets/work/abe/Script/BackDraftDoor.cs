using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDraftDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject decision;

    //private Decision decision;

    private ParticleSystem particle;

    public AudioClip se;

    private AudioSource audioSource;

    //1回だけ処理するトリガー
    private bool trg = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
                audioSource.PlayOneShot(se);
                decision.GetComponent<Decision>().DraftDead();
                trg = true;
            }
        }
    }
}



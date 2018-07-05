using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDraftDoor : MonoBehaviour {

    private ParticleSystem particle;

    void Start()
    {
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
        }
    }
}

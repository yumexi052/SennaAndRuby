using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleOn : MonoBehaviour
{
    private float timer = 0.0f;
    private bool isParticleOn = false;
    //public GameObject tips;
    //public GameObject traps;
    public ParticleSystem particle;

    // Update is called once per frame
    void Update()
    {
        //tips = GameObject.FindWithTag("TipsParticle");
        //traps = GameObject.FindWithTag("TrapParticle");

        if (Input.GetAxis("Skill") != 0 && !isParticleOn && !foxAnimation.died)
        {
            isParticleOn = true;
        }

        if (isParticleOn)
        {
            timer += Time.deltaTime;
            //tips.GetComponent<ParticleSystem>().Play();
            //traps.GetComponent<ParticleSystem>().Play();
            particle.Play();
        }

        if (timer > 1)
        {
            isParticleOn = false;
            //tips.GetComponent<ParticleSystem>().Stop();
            //traps.GetComponent<ParticleSystem>().Stop();
            particle.Stop();
            timer = 0.0f;
        }
    }
}

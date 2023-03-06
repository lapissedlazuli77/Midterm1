using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshooty : MonoBehaviour
{
    Animator anim;
    public GameObject bullet;

    AudioSource audiodata;

    bool isfire = false;

    float timer = 0f;
    float waittime = 0.8f;

    Vector3 shotspot;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        audiodata = this.GetComponent<AudioSource>();
        shotspot = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        shotspot = this.transform.position;
        if (Input.GetKeyDown("space") && isfire == false)
        {
            isfire = true;
            anim.SetBool("Firing", true);
            audiodata.Play();
            GameObject shot = Instantiate(bullet, shotspot, Quaternion.identity) as GameObject;
            shot.GetComponent<Rigidbody>().AddForce(transform.right * 20000);
        }
        while (isfire)
        {
            if (timer >= waittime)
            {
                isfire = false;
                anim.SetBool("Firing", false);
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
}

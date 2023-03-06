using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshooty : MonoBehaviour
{
    public Animator anim;
    public GameObject bullet;

    bool isfire;

    float timer = 0f;
    float waittime = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        isfire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && isfire == false)
        {
            isfire = true;
            anim.SetBool("Firing", true);
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
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

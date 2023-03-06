using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDinosaur : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;

    bool hunting = false;

    float timer = 0;
    float timertime;
    float hunttime;

    public float posx;
    public float posz;

    Vector3 destination;

    AudioSource thissound;
    public AudioClip walksound;
    public AudioClip runsound;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        thissound = GetComponent<AudioSource>();

        timertime = Random.Range(4f, 10f);
        hunttime = 10f;

        posx = Random.Range(-100f, 100f);
        posz = Random.Range(-100f, 100f);
        destination.Set(posx, 0, posz);
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting)
        {
            Chase();
        }
        else
        {
            Wander();
        }
        timer += Time.deltaTime;
    }
    virtual void Chase()
    {
        thissound.clip = runsound;
        nav.destination = player.position;
        if (timer >= hunttime)
        {
            hunting = false;
            timer = 0;

            posx = Random.Range(-100f, 100f);
            posz = Random.Range(-100f, 100f);
            destination.Set(posx, 0, posz);
        }
    }
    virtual void Wander()
    {
        thissound.clip = walksound;
        nav.destination = destination;
        if (timer >= timertime)
        {
            posx = Random.Range(-100f, 100f);
            posz = Random.Range(-100f, 100f);
            destination.Set(posx, 0, posz);

            timertime = Random.Range(4f, 10f);
            timer = 0;
        }
    }
}

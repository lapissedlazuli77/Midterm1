using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDinosaur : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;

    bool hunting = false;
    bool moving = true;

    float timer = 0;
    float timertime;
    float hunttime;
    float idletime;
    int idlethresh;

    public float posx;
    public float posz;

    Vector3 destination;

    AudioSource thissound;
    public AudioClip walksound;
    public AudioClip runsound;
    public AudioClip idlesound;
    public AudioClip huntsound;
    public AudioClip deathsound;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        thissound = GetComponent<AudioSource>();

        timertime = Random.Range(4f, 10f);
        hunttime = 10f;
        idletime = Random.Range(1f, 5f);

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
        } else if (!hunting && moving)
        {
            Wander();
        } else
        {
            Idle();
        }
        timer += Time.deltaTime;
    }
    protected virtual void Chase()
    {
        thissound.clip = runsound;
        thissound.loop = true;
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
    protected virtual void Wander()
    {
        thissound.clip = walksound;
        thissound.loop = true;
        nav.destination = destination;
        if (timer >= timertime)
        {
            int behavchooser = Random.Range(1, 4);
            if (behavchooser >= idlethresh)
            {
                timertime = Random.Range(4f, 10f);
                timer = 0;
                moving = false;
            } else
            {
                posx = Random.Range(-100f, 100f);
                posz = Random.Range(-100f, 100f);
                destination.Set(posx, 0, posz);

                timertime = Random.Range(4f, 10f);
                timer = 0;
            }
        }
    }
    protected virtual void Idle()
    {
        thissound.clip = idlesound;
        thissound.loop = false;
        nav.destination = transform.position;
        if (timer >= idletime)
        {
            posx = Random.Range(-100f, 100f);
            posz = Random.Range(-100f, 100f);
            destination.Set(posx, 0, posz);

            idletime = Random.Range(1f, 5f);
            timer = 0;
            moving = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDinosaur : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nav;

    bool hunting = false;
    bool moving = true;

    float timer = 0;
    float timertime;
    float hunttime;
    float idletime;
    float deathtime;
    int idlethresh;

    protected float hp = 100;

    public float posx;
    public float posz;

    float walkspeed;
    float chasespeed;

    Vector3 destination;
    Vector3 playerpos;

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

        walkspeed = nav.speed;

        thissound.clip = walksound;
        thissound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.position;
        if (hp > 0)
        {
            if (hunting)
            {
                Chase();
            }
            else if (!hunting && moving)
            {
                Wander();
            }
            else
            {
                Idle();
            }
        }
        timer += Time.deltaTime;
    }
    protected virtual void Chase()
    {
        AccelerateSpeed();
        nav.destination = playerpos;
        if (timer >= hunttime)
        {
            thissound.clip = walksound;
            thissound.loop = true;
            hunting = false;
            timer = 0;

            posx = Random.Range(-100f, 100f);
            posz = Random.Range(-100f, 100f);
            destination.Set(posx, 0, posz);
        }
    }
    protected virtual void Wander()
    {
        nav.speed = 3;
        nav.destination = destination;
        if (timer >= timertime)
        {
            int behavchooser = Random.Range(1, 4);
            if (behavchooser >= idlethresh)
            {
                thissound.clip = idlesound;
                thissound.loop = false;
                thissound.Play();

                timertime = Random.Range(4f, 10f);
                timer = 0;
                moving = false;
            }
            else
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
        nav.destination = transform.position;
        if (timer >= idletime)
        {
            thissound.clip = walksound;
            thissound.loop = true;
            thissound.Play();

            posx = Random.Range(-100f, 100f);
            posz = Random.Range(-100f, 100f);
            destination.Set(posx, 0, posz);

            idletime = Random.Range(1f, 5f);
            timer = 0;
            moving = true;
        }
    }
    protected virtual void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            timer = 0;
            Death();
        }
    }
    protected virtual void Death()
    {
        thissound.clip = deathsound;
        thissound.Play();

        if (timer >= deathtime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Damage(20);
            nav.destination = player.position;
            thissound.clip = huntsound;
            thissound.loop = false;
            thissound.Play();
            hunting = true;
            moving = true;

            thissound.clip = runsound;
            thissound.loop = true;
            thissound.Play();
        }
    }

    protected virtual void AccelerateSpeed()
    {
        nav.speed = 6;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Platform platform;
    [SerializeField] Gem gem;

    [Header("Variables")]
    [SerializeField] int platformsOnStart;
    
    [SerializeField] float gemChance;

    float spawnDelay;
    Vector3 platformPos;

    public static PlatformManager instance;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Summon()
    {
        Platform p = Instantiate(platform, transform.position, Quaternion.identity);

        if (Random.Range(0,1f) > gemChance)
        {
            print("gem");
            Gem g = Instantiate(gem, transform.position + Vector3.up, Quaternion.identity);
        }


        if (Random.Range(0, 2) == 0)//go left
        {
            transform.position += Vector3.forward *2;
        }
        else
        {
            transform.position += Vector3.right * 2;
        }
    }
    void Start()
    {
        for (int i = 0; i < platformsOnStart; i++)
        {
            Summon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BallController.instance.GetDead()) return;
        float dt = Time.deltaTime;
        spawnDelay -= dt;
        if (spawnDelay <= 0)
        {
            spawnDelay = 0.2f + spawnDelay;
            Summon();
        }
    }
}

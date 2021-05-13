using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    const int spawnRate = 3;


    private int count;
    private int max_spawned;
    private float timeCount;
    private int max_at_a_time;


    public GameObject[] targs = new GameObject[3];
    public int[] distances = new int[3];
    public int[] heights = new int[3];

    private GameObject[] current_targs;
    public GameObject bullet_prefab;
    private int targsDestroyed = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        max_spawned = 20;
        count = 0;
        timeCount = spawnRate;
        max_at_a_time = 3;
        current_targs = new GameObject[max_at_a_time];
    }

    // Update is called once per frame
    void Update()
    {
        print(current_targs.Length);
        print(count);


        if(targsDestroyed == 0 && count == max_spawned)
        {
            float hit = bullet_prefab.GetComponent<Bullet>().getHitCount();
            float total = bullet_prefab.GetComponent<Bullet>().getTotalCount();

            print("**********" + hit / total);
            GameObject.Find("Terrain").GetComponent<Control>().setAccuracy(hit / total);
            GameObject.Find("Terrain").GetComponent<Control>().onEnd();

            return;
        }
        testTargetSpawn();
    }

    public GameObject spawnTarg(GameObject targ, Vector3 location)
    {
        count++;
        return Instantiate(targ, location, Quaternion.Euler(new Vector3(0, -90, 0)));
    }

    public bool testTargetSpawn()
    {
        for(int i = 0; i < max_at_a_time; i++)
        {
            if(current_targs[i] == null && timeCount <= 0 && count < max_spawned)
            {
                timeCount = spawnRate;
                current_targs[i] = spawnTarg(pickTarget(), pickLocation());
                return true;
            }
        }

        timeCount -= Time.deltaTime;
        return false;
    }

    public GameObject pickTarget()
    {
        return targs[Random.Range(0, 2)];
    }

    public Vector3 pickLocation()
    {
        int rand = Random.Range(0, 2);
        int x = distances[rand];
        int y = heights[rand];
        int z = Random.Range(0, 45);
        return new Vector3(x, y, z);
    }

    public void decrementTargs()
    {
        targsDestroyed--;
    }
}

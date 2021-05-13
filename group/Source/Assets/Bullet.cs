using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public static int hit_count = 0;
    public static int total_count = 0;
    public GameObject range;

    // Start is called before the first frame update
    void Start()
    {
        total_count++;
        range = GameObject.Find("Testing_Range");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            hit_count++;
            range.GetComponent<SpawnTargets>().decrementTargs();
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);
    }

    public void resetCounts()
    {
        hit_count = 0;
        total_count = 0;
    }

    public int getHitCount()
    {
        return hit_count;
    }

    public int getTotalCount()
    {
        return total_count;
    }
}

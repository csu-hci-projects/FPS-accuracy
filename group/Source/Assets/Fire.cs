using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject shell;
    public GameObject bullet;
    private GameObject gun;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("gun");
        t = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (SimpleInput.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        

        if (t <= 0)
        {
            GameObject[] bull = GameObject.FindGameObjectsWithTag("Shell");
            foreach (GameObject b in bull)
            {
                Destroy(b);
            }

            t = 5;
        }

        t = t - Time.deltaTime;
    }

    void Shoot()
    {
        Quaternion bull_quat = gun.transform.rotation;

        if (bull_quat.eulerAngles.y <= 180)
            bull_quat.eulerAngles = new Vector3(bull_quat.eulerAngles.x + 90, bull_quat.eulerAngles.y, 0);
        else
            bull_quat.eulerAngles = new Vector3(bull_quat.eulerAngles.x - 90, bull_quat.eulerAngles.y, 0);
        //print(bull_quat.eulerAngles);

        Vector3 bull_pos = gun.transform.position;
        bull_pos.y += 0.1f;

        Vector3 sh_pos = gun.transform.position;
        sh_pos.z -= 0.1f;

        GameObject bul = Instantiate(bullet, bull_pos, bull_quat) ;
        GameObject sh = Instantiate(shell, sh_pos, gun.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float move_speed = 3;
    public float turn_speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void LateUpdate()
    {
        transform.Rotate(0, 0, -transform.eulerAngles.z);
    }

    public void Move()
    {
        float verticalInput = SimpleInput.GetAxis("Vertical");
        float horizontalInput = SimpleInput.GetAxis("Horizontal");

        //Debug.Log(verticalInput);
        //Debug.Log(horizontalInput);

        var newHorizontalPoint = Vector3.right * horizontalInput * move_speed * Time.deltaTime;
        var newVerticalPoint = Vector3.forward * verticalInput * move_speed * Time.deltaTime;

        transform.Translate(newVerticalPoint);
        transform.Translate(newHorizontalPoint);
    }

    public void Rotate()
    {
        float x = -SimpleInput.GetAxis("MouseY") / 25;
        float y = SimpleInput.GetAxis("MouseX") / 25;

        if(x < 0.01f && x > -0.01f)
        {
            x = 0;
        }

        if (y < 0.01f && y > -0.01f)
        {
            y = 0;
        }

        var vec = new Vector3(x, y, 0);
        transform.Rotate(vec, Time.deltaTime * turn_speed);
        
    }
}

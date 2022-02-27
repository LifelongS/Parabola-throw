using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceMover : MonoBehaviour
{
    public Transform Start;
    public Transform Runner;
    public Rigidbody rb;

    public Vector3 direction;
    public float distantion;
    public float speed;
    public float time;
    public float acceleration;
    private float U;

    public Text SpeedText;
    public Text AccelerationText;
    public Text DistantionText;
    public Text TimeText;
    public Text Coordinates;

    void Update()
    {

        rb.AddForce(direction.normalized * speed);
        rb.AddForce(direction.normalized * acceleration);
        distantion = Vector3.Distance(Start.position, Runner.position);
  //    Debug.Log("Дистанция между объектами: " + distantion.ToString("0.00"));
        time += Time.deltaTime;
        //    Debug.Log("за время: " + time.ToString("0.00"));

        SpeedText.text = "Скорость: " + speed;
        AccelerationText.text = "Ускорение: " + acceleration;
        DistantionText.text = "Расстояние: " + distantion.ToString("0.00");
        TimeText.text = "Время: " + time.ToString("0.00");
        Vector3 pos = Runner.transform.position;
        Coordinates.GetComponent<Text>().text = "x = " + pos.x.ToString("0.00") + ";      " + "y = " + pos.y.ToString("0.00") + ";   " + "z =  " + pos.z.ToString("0.00") + "   ";

        if (acceleration > 0)
        {
            U = speed + acceleration * time;
            SpeedText.text = "Скорость: " + U.ToString("0.00");
        }

  //   if (distantion > 150f)
       if (time >= 15)
       {
         speed = 0;
         acceleration = 0;
         time = 15;
         rb.AddForce(-rb.velocity);
         rb.velocity = Vector3.zero;
  //     rb.position = new Vector3(-10, 0.0f, 0);
       }
    }
}

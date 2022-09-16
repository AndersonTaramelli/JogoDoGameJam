using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroAi : MonoBehaviour
{
    Waypoint[] listaWaypoints;

    Carro carro;

    int atual = 0;
    float virar = 0f;

    private void Start()
    {
        GameObject parentWaypoints = GameObject.Find("WAYP");

        listaWaypoints = parentWaypoints.GetComponentsInChildren<Waypoint>();

        carro = GetComponent<Carro>();
    }

    private void FixedUpdate()
    {
        if (listaWaypoints[atual].velocidadeRecomendada > carro.velKMH)
        {
            carro.acc = 1f;
        }
        else
        {
            carro.acc = -1f;
        }

        Vector3 dir = transform.InverseTransformPoint(new Vector3(listaWaypoints[atual].transform.position.x, transform.position.y, listaWaypoints[atual].transform.position.z));

        virar = Mathf.Clamp((dir.x / dir.magnitude) * 10f, -1f, 1f);

        if (Vector3.Distance(transform.position, listaWaypoints[atual].transform.position) < 10f)
        {
            atual++;
            if (atual == listaWaypoints.Length)
            {
                atual = 0;
            }
        }
    }
}

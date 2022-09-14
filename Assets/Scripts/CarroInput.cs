using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroInput : MonoBehaviour
{
    CarController carro;

    private void Start()
    {
        carro = GetComponent<CarController>();
    }

    void Update()
    {
        carro.turnStrength = Input.GetAxis("Horizontal");
        carro.forwardAccel = Input.GetAxis("Vertical");
    }
}

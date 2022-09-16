using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroInput : MonoBehaviour
{
    Carro carro;

    private void Start()
    {
        carro = GetComponent<Carro>();
    }
    private void Update()
    {
        carro.gui = Input.GetAxis("Horizontal");
        carro.acc = Input.GetAxis("Vertical");
    }
}

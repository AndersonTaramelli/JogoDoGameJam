using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHud : MonoBehaviour
{
    CarMove carro;

    public RectTransform agulhaRPM;
    public Text VelKM;

    float newR;

    private void Start()
    {
        carro = GetComponent<CarMove>();
    }

    private void FixedUpdate()
    {
        VelKM.text = string.Format("{0:0}",carro.VelKM) + "KM/H";

        Vector3 rotAgulha = agulhaRPM.rotation.eulerAngles;

        newR = Mathf.Lerp(newR, carro.rpm, 0.3f);

        rotAgulha.z = ((newR * 116f) / carro.maxRpm) * -1f;

        agulhaRPM.eulerAngles = rotAgulha;
    }
}

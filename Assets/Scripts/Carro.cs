using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{

    public WheelCollider[] guiar;

    public AnimationCurve curvaRoda;

    public float gui = 0f;
    public float acc = 0f;

    Rigidbody rb;

    public AudioClip somCarro;
    public AudioSource audioCarro;

    public float maxTorque;
    public float forcaTravagem;


    public float minRPM;
    public float maxRPM;

    public float somPitch;

    public float velKMH;
    float rpm;

    public float[] racioMudancas;

    int mudancaAtual = 0;

    public Vector3 forcaFinal;

    public Transform Massa;

    public float instavelTravagem;

    int voltas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = Massa.localPosition;

        audioCarro.clip = somCarro;
    }

    public void SomarVolta()
    {
        voltas++;
        Debug.Log("Deu uma volta -" + voltas.ToString());
    }

    void FixedUpdate()
    {
        for (int i = 0; i < guiar.Length; i++)
        {
            guiar[i].steerAngle = gui * curvaRoda.Evaluate(velKMH);
            guiar[i].motorTorque = 1f;
        }

        velKMH = rb.velocity.magnitude * 3.6f;

        rpm = velKMH * racioMudancas[mudancaAtual] * 15f;

        if (rpm > maxRPM)
        {
            mudancaAtual++;
            if (mudancaAtual == racioMudancas.Length)
            {
                mudancaAtual--;
            }
        }

        if (rpm < minRPM)
        {
            mudancaAtual--;
            if (mudancaAtual < 0)
            {
                mudancaAtual = 0;
            }
        }

        if (acc < -0.5f)
        {
            rb.AddForce(-transform.forward * forcaTravagem);

            rb.AddTorque((transform.up * instavelTravagem * velKMH / 45f) * gui);

            acc = 0;
        }

        forcaFinal = transform.forward * (maxTorque / (mudancaAtual + 1) + maxTorque / 1.854f) * acc;

        rb.AddForce(forcaFinal);

        audioCarro.pitch = rpm / somPitch;

        float angulo = Vector3.Angle(transform.forward, rb.velocity);

        float valorFinal = (angulo / 10f) - 0.3f;

    }
}

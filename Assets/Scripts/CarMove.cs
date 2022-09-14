using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour

{
    Rigidbody rb;

    public AudioClip somCarro;
    public AudioSource audioCarro;

    public float VelKM;
    public float rpm;

    public float[] racioMudancas;
    int mudancaAtual = 0;

    public float maxRpm;
    public float minRpm;

    public float somPitch;

    public AudioSource audioDerrapar;

    int voltas = 0;


    void Start()
    {
        audioCarro.clip = somCarro;
    }

    public void SomarVolta()
    {
        voltas++;
        Debug.Log("Mais uma volta completa -" + voltas.ToString());
    }

    void FixedUpdate()
    {
        VelKM = rb.velocity.magnitude * 3.6f;

        rpm = VelKM * racioMudancas[mudancaAtual] * 15f;

        if (rpm > maxRpm)
        {
            mudancaAtual++;
            if (mudancaAtual == racioMudancas.Length)
            {
                mudancaAtual--;
            }
        }
        
        if (rpm < minRpm)
        {
            mudancaAtual--;
            if (mudancaAtual < 0)
            {
                mudancaAtual = 0;
            }
        }


        audioCarro.pitch = rpm / somPitch;

        if (VelKM >= 35f)
        {

            float angulo = Vector3.Angle(transform.forward, rb.velocity);
            float valorFinal = (angulo / 10f) - 0.3f;



            audioDerrapar.volume = Mathf.Clamp(valorFinal, 0f, 1f);
        }
    }

    //void OnGUI()
   // {
       // GUI.Label(new Rect(20, 20, 128, 32), rpm + "RPM");
       // GUI.Label(new Rect(20, 40, 128, 32), (mudancaAtual + 1).ToString());
        //GUI.Label(new Rect(20, 60, 128, 32), VelKM + "KM/H");
       // GUI.Label(new Rect(20, 80, 128, 32), forcaFinal.magnitude.ToString());
    //}
}

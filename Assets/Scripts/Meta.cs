using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    Checkpoint[] checkpoints;

    private void Awake()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CarMove x = other.transform.root.GetComponent<CarMove>();

        foreach (Checkpoint ch in checkpoints)
        {
            if (!ch.PassouCarro())
            {
                Debug.Log("Volta Invalida");

                ResetCheckpoints();

                return;
            }
        }

        x.SomarVolta();
        ResetCheckpoints();
    }

    void ResetCheckpoints()
    {
        foreach (Checkpoint cha in checkpoints)
        {
            cha.carro = null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject carro = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<CarMove>()) ;
        {
            carro = other.transform.root.gameObject;
        }
    }

    public bool PassouCarro()
    {
        if (carro!= null)
        {
            return true;
        }
        return false;
    }
}

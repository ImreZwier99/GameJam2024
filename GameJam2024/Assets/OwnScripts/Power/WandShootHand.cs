using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandShootHand : MonoBehaviour
{
    public GameObject Controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wand"))
        {
            GetComponent<FireSpell>().enabled = true;
        }
        else
        {
            GetComponent<FireSpell>().enabled = false;
        }
    }
}

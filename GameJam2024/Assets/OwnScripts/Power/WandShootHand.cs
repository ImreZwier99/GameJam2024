using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandShootHand : MonoBehaviour
{
    public GameObject Controller;
    public GameObject Hand;
    public GemBehaviour Gem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wand"))
        {
            Debug.Log(" test10");
            Hand.GetComponent<FireSpell>().enabled = true;
        }
        //else
        //{
        //    Hand.GetComponent<FireSpell>().enabled = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        Hand.GetComponent<FireSpell>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingItemScript : MonoBehaviour
{
    public AudioSource dropSound;

    private void OnCollisionEnter(Collision collision)
	{
        dropSound.Play();
	}
}

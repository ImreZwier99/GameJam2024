using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRespawn : MonoBehaviour
{
    public Transform respawnObject, respawnPoint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("void")) respawnObject.position = respawnPoint.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    public GameObject gem_Object;
    public Transform gemWandOrigin;
    private bool placedGemCheck = false;
    //private float distance;


    // Start is called before the first frame update
    void Start()
    {
        placedGemCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(placedGemCheck) gem_Object.transform.position = new Vector3(gemWandOrigin.position.x, gemWandOrigin.position.y, gemWandOrigin.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("gemOrigin") && !placedGemCheck)
		{
			placedGemCheck = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("gemOrigin")) placedGemCheck = false;
	}
}

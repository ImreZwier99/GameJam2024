using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarBehaviour : MonoBehaviour
{
    public GameObject gem_Object, choiceCanvas;
    public Transform altarOrigin;
    public static bool gemCheck = false;
	public ParticleSystem pentagram;
    //private float distance;


    // Start is called before the first frame update
    void Start()
    {
		gemCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (gemCheck)
		{
			gem_Object.transform.position = new Vector3(altarOrigin.position.x, altarOrigin.position.y, altarOrigin.position.z);
			//pentagram.Play();
			choiceCanvas.SetActive(true);
		}
		else
		{
			//pentagram.Stop();
			choiceCanvas.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("gemOrigin") && !gemCheck)
		{
			gemCheck = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("gemOrigin")) gemCheck = false;
	}
}

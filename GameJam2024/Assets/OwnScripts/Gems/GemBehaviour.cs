using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    public GameObject wand_Object, gem_Object;
    public Transform gemWandOrigin;
    private bool placedGemCheck = false;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gem_Object.transform.position, wand_Object.transform.position);
        GemLogic();
    }

    private void GemLogic()
	{
        if (!placedGemCheck && distance <= 0.2f)
		{
            gem_Object.transform.position = new Vector3(gemWandOrigin.position.x, gemWandOrigin.position.y, gemWandOrigin.position.z);
            placedGemCheck = true;
		}
        else if(placedGemCheck && distance > 0.2) placedGemCheck = false;
    }
}

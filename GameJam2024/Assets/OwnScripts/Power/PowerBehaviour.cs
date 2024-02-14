using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public Material gemMaterial;
    // Start is called before the first frame update
    void Start()
    {
        gemMaterial.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonBehaviour(int powerNum = 0)
	{
        if(AltarBehaviour.gemCheck == true)
		{
            if (powerNum == 1)
            {
                gemMaterial.color = Color.red;
            }
            else if (powerNum == 2)
            {
                gemMaterial.color = Color.blue;
            }
            else if (powerNum == 3)
            {
                gemMaterial.color = Color.yellow;
            }
            else if (powerNum == 4)
            {
                gemMaterial.color = Color.green;
            }
		}
	}
}

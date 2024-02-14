using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public Material gemMaterial;
    public ParticleSystem pentagram, powerChangedEffect;
    // Start is called before the first frame update
    void Start()
    {
        pentagram.startColor = Color.white;
        gemMaterial.color = Color.white;
    }

    public void ButtonBehaviour(int powerNum = 0)
	{
        //powerChangedEffect.Play();
        if(AltarBehaviour.gemCheck == true)
		{
            if (powerNum == 1)
            {
                gemMaterial.color = Color.red;
                pentagram.startColor = Color.red;
            }
            else if (powerNum == 2)
            {
                gemMaterial.color = Color.blue;
                pentagram.startColor = Color.blue;
            }
            else if (powerNum == 3)
            {
                gemMaterial.color = Color.yellow;
                pentagram.startColor = Color.yellow;
            }
            else if (powerNum == 4)
            {
                gemMaterial.color = Color.green;
                pentagram.startColor = Color.green;
            }
		}
	}
}

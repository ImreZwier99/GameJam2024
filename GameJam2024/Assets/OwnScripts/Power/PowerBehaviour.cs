using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public GameObject pentagramObject;
    public Material gemMaterial;
    public ParticleSystem pentagram, powerChangedEffect;
    public AudioSource enchantmentSound;
    // Start is called before the first frame update
    void Start()
    {
        gemMaterial.color = Color.white;
        pentagram.startColor = Color.white;
    }

    public void ButtonBehaviour(int powerNum = 0)
	{
        //powerChangedEffect.Play();
        enchantmentSound.Play();
        if(AltarBehaviour.gemCheck == true)
		{
            if (powerNum == 1)
            {
                gemMaterial.color = Color.red;
                pentagramObject.SetActive(false);
                pentagram.startColor = Color.red;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 2)
            {
                gemMaterial.color = Color.blue;
                pentagramObject.SetActive(false);
                pentagram.startColor = Color.blue;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 3)
            {
                gemMaterial.color = Color.yellow;
                pentagramObject.SetActive(false);
                pentagram.startColor = Color.yellow;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 4)
            {
                gemMaterial.color = Color.green;
                pentagramObject.SetActive(false);
                pentagram.startColor = Color.green;
                pentagramObject.SetActive(true);
            }
		}
	}
}

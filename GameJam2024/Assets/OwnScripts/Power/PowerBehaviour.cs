using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public GameObject pentagramObject;
    public Material gemMaterial, spellMaterial, trailSpellmaterial;
    public ParticleSystem pentagram, sideParticle1, sideParticle2, sideParticle3 ,spellParticle;
    public AudioSource enchantmentSound;
    // Start is called before the first frame update
    void Start()
    {
        gemMaterial.color = Color.white;
        pentagram.startColor = Color.white;
        spellParticle.startColor = Color.white;
        trailSpellmaterial.color = Color.white;
        spellMaterial.color = Color.white;
    }

    public void ButtonBehaviour(int powerNum)
	{
        enchantmentSound.Play();
        if(AltarBehaviour.gemCheck == true)
		{
            if (powerNum == 1)
            {
                pentagramObject.SetActive(false);
                gemMaterial.color = Color.red;
                pentagram.startColor = Color.red;
                sideParticle1.startColor = Color.red;
                sideParticle2.startColor = Color.red;
                sideParticle3.startColor = Color.red;
                spellParticle.startColor = Color.red;
                trailSpellmaterial.color = Color.red;
                spellMaterial.color = Color.red;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 2)
            {
                pentagramObject.SetActive(false);
                gemMaterial.color = Color.blue;
                pentagram.startColor = Color.blue;
                sideParticle1.startColor = Color.blue;
                sideParticle2.startColor = Color.blue;
                sideParticle3.startColor = Color.blue;
                spellParticle.startColor = Color.blue;
                trailSpellmaterial.color = Color.blue;
                spellMaterial.color = Color.blue;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 3)
            {
                pentagramObject.SetActive(false);
                gemMaterial.color = Color.yellow;
                pentagram.startColor = Color.yellow;
                sideParticle1.startColor = Color.yellow;
                sideParticle2.startColor = Color.yellow;
                sideParticle3.startColor = Color.yellow;
                spellParticle.startColor = Color.yellow;
                trailSpellmaterial.color = Color.yellow;
                spellMaterial.color = Color.green;
                pentagramObject.SetActive(true);
            }
            else if (powerNum == 4)
            {
                pentagramObject.SetActive(false);
                gemMaterial.color = Color.green;
                pentagram.startColor = Color.green;
                sideParticle1.startColor = Color.green;
                sideParticle2.startColor = Color.green;
                sideParticle3.startColor = Color.green;
                spellParticle.startColor = Color.green;
                trailSpellmaterial.color = Color.green;
                spellMaterial.color = Color.green;
                pentagramObject.SetActive(true);
            }
		}
	}
}

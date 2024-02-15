using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireSpell : MonoBehaviour
{
    public GameObject spell;

    public float shootforce, upwardforce;

    public float timebetweenshooting, spread, reloadtime, timebetweenshots;
    public int magazineSize, bulletspertap;
    public bool allowButtonHold;
    
    int bulletsLeft, bulletsShot;

    bool shooting, readytoshoot, reloading;

    public Camera myCamera;
    public Transform attackpoint;

    public TextMeshProUGUI ammunitionDisplay;

    public bool allowinvoke = true;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        readytoshoot = true;
    }

    private void Update()
    {
        SpellActivation();

        if (ammunitionDisplay != null) ammunitionDisplay.SetText(bulletsLeft / bulletspertap + " / " + magazineSize / bulletspertap);
    }

    public void SpellActivation()
    {
        var RightHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, RightHandedControllers);
        bool triggerValue;

        foreach (var device in RightHandedControllers)
        {
             Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
             if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
             {
                  Debug.Log("Trigger button is pressed.");
             }
        }



        //check if allowed to hold down button
        if (allowButtonHold) shooting = Input.GetButton("XRI_Right_trigger");
        else shooting = Input.GetButtonDown("XRI_Right_trigger");

        //reloading
        if (Input.GetButtonDown("XRI_Right_SecondaryButton") && bulletsLeft < magazineSize && !reloading) Reload();
        //reload automatically when trying to shoot without ammo
        if (readytoshoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readytoshoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
        
    }
    private void Shoot()
    {
        readytoshoot = false;
        //find the exact hit position using a raycast
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetpoint;
        if (Physics.Raycast(ray, out hit)) targetpoint = hit.point;
        else targetpoint = ray.GetPoint(75);//random point
        
        //calculate direction from attackpoint to targetpoint
        Vector3 directionWithoutSpread = targetpoint - attackpoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread 
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);//last digit is spread

        //instatiate Spell
        GameObject currentBullet = Instantiate(spell, attackpoint.position, Quaternion.identity);
        //rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //add force
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootforce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        //invoke ResetShot function
        if (allowinvoke)
        {
            Invoke("ResetShot", timebetweenshooting);
            allowinvoke = false;
        }

        //if moore than one bulletspertap repeat shoot funtion
        if (bulletsShot < bulletspertap && bulletsLeft > 0) Invoke("Shoot", timebetweenshots);
    }

    private void ResetShot()
    {
        readytoshoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadtime);
    }
    private void ReloadFinished()
    {
       bulletsLeft = magazineSize;
        reloading = false;
    }
}

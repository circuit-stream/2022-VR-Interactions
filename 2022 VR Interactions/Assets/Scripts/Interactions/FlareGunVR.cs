using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class FlareGunVR : XRGrabInteractable
{
    public Rigidbody flareBullet;
    public Transform barrelEnd;
    public GameObject muzzleParticles;
    public AudioClip flareShotSound;
    public AudioClip noAmmoSound;
    public AudioClip reloadSound;
    public int bulletSpeed = 2000;
    public int maxSpareRounds = 5;
    public int spareRounds = 3;
    public int currentRound = 0;

    
    void Start()
    {
		activated.AddListener(Shoot);
    }

	void Shoot(ActivateEventArgs args)
	{
		currentRound--;
		if (currentRound <= 0)
		{
			currentRound = 0;
		}

		GetComponent<Animation>().CrossFade("Shoot");
		GetComponent<AudioSource>().PlayOneShot(flareShotSound);


		Rigidbody bulletInstance;

		//instantiate flare projectile
		bulletInstance = Instantiate(flareBullet, barrelEnd.position, barrelEnd.rotation) as Rigidbody; 

		// add force on the flare projectile in the forward direction 
		bulletInstance.AddForce(barrelEnd.forward * bulletSpeed);

		// instantiate the gun's muzzle sparks
		Instantiate(muzzleParticles, barrelEnd.position, barrelEnd.rotation);
	}

	void Reload()
	{
		if (spareRounds >= 1 && currentRound == 0)
		{
			GetComponent<AudioSource>().PlayOneShot(reloadSound);
			spareRounds--;
			currentRound++;
			GetComponent<Animation>().CrossFade("Reload");
		}
	}
}

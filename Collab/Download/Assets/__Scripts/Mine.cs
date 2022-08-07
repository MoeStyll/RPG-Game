using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Weapon
{
    public GameObject mine;
    public Animator animator;

    public override void Shoot()
    {
        animator.SetTrigger("Fire1");

        //create bullet gameobject
        GameObject weapon = Instantiate(mine, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        StartCoroutine(Explode(weapon));
        Destroy(weapon, 4);

    }

    IEnumerator Explode(GameObject weapon)
    {
        yield return new WaitForSeconds(3);
        weapon.GetComponentInChildren<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = weapon.GetComponentInChildren<ParticleSystem>().emission;
        em.enabled = true;
    }
   
}

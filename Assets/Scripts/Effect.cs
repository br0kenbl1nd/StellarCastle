using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject deathEffect;

    public void DeathEffect()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

} //class

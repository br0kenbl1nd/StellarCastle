using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public class Health : MonoBehaviour
{
    public UnitStats unitStats;

    private Effect effect;

    private void Start()
    {
        effect = GetComponent<Effect>();
        
    } //start

    private void Update()
    {
        //if health falls below zero, kill the character
        if(unitStats.Health <= 0f)
        {
            if(effect != null)
            {
                effect.DeathEffect();
            }

            Destroy(gameObject);
        }
        
    } //update

    public void TakeDamage(float _value)
    {
        unitStats.Health -= _value;

    } //take damage

} //class

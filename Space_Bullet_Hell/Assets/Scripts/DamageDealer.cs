using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a general class to rule over all damage in the game
public class DamageDealer : MonoBehaviour
{
    //conf params
    [SerializeField] int damage = 1;

    //methods
    public int GetDamage() { return damage; }

    public void Hit() { Destroy(gameObject); }


}

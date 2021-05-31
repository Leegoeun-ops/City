using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerCtrl : MonoBehaviour
{
    private int hp = 2000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float amount)
    {
        hp -= (int)(amount);
        //animator.SetTrigger("IsHit");

        if (hp <= 0)
        {
             //
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int hp = 600;
    // Start is called before the first frame update
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

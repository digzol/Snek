using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodUnit : MonoBehaviour
{
    public void Consume()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("fadeout");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

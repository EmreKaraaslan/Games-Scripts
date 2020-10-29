using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public BallSecene3 Bs3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Sidecube")
        {
            Bs3.GameEnd();

        }
    }


}

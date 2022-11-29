using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{


    Rigidbody2D ManRigidBody;
    bool FaceRight = true;

   void Start()
    {
        ManRigidBody = GetComponent<Rigidbody2D>();
    } 

    public void FixedUpdate()
    {

        if (ManRigidBody.velocity.x< 0 && FaceRight)
        {
            Faceturn();
        }
        else if (ManRigidBody.velocity.x>0 && !FaceRight)
        {


            Faceturn();


        }

    }






    void Faceturn()
    {

        FaceRight = !FaceRight;

        Vector3 boyut3 = transform.localScale;

        boyut3.x *= -1;

        transform.localScale = boyut3;


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    public static ParentScript instance;

    Rigidbody2D ManRigidBody;
    public bool FaceRight = true ;

    private void Awake()
    {
        instance = this;
    }

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

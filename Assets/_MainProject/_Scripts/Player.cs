using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = 500.0f;
    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-1.57f, -5.96f, -127);
        _rb= GetComponent<Rigidbody>();
    
    }

    private void FixedUpdate()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        direction.Normalize();

        //Appliquer la rotation du personnage dans la direction de son déplacement
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }




        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

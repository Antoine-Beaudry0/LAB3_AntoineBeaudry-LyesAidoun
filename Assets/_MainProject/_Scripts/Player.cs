using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = 100.0f;
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
        _rb.AddForce(direction * Time.fixedDeltaTime * _vitesse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

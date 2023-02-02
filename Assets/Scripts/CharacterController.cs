using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rg;
    bool walkingRight = true;
    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rg.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
    }

    private void Switch()
    {
        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}

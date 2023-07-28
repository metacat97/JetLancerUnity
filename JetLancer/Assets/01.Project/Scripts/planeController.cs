using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class planeController : MonoBehaviour
{
    public float speed;
    private Vector2 mousePos;
    private Rigidbody2D myrigid;

   
    // Start is called before the first frame update
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dir = mousePos - new Vector2(transform.position.x , transform.position.y);
        dir.Normalize();
        myrigid.AddForce(dir * speed);

        float angle = Mathf.Atan(dir.y/ dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if (dir.x< 0)
        {
            angle += 180;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f , angle));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        //Vector2 mousePos = context.ReadValue<Vector2>();
        //Debug.Log(mousePos); 
    }


}

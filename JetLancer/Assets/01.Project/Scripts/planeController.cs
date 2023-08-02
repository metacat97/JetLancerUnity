using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class planeController : MonoBehaviour
{
    public float speed;
    public float gas = 100;
    public GameObject bulletPrefab; // 프리팹 담을 퍼블릭 겜오브젝트 
    public Transform shootingPos; //총알 나갈 위치

    private Vector2 mousePos;
    private Rigidbody2D myrigid;
    private bool boosting, shooting;
    private float shooTimer;


    // Start is called before the first frame update
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        shooTimer = Time.time + 0.5f;
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x,
            Camera.main.ScreenToWorldPoint(mousePos).y)- new Vector2(transform.position.x, transform.position.y);
        //Vector2 dir = mousePos - new Vector2(transform.position.x , transform.position.y);
        dir.Normalize();
        if( boosting && gas > 0f)
        {
            gas -= 0.5f;
            myrigid.AddForce(dir * speed * 2);
            //Debug.Log(gas);
        }
        else
        {
            if( gas < 100f)
            { 
                gas += 0.5f;
            }
            myrigid.AddForce(dir * speed);
            boosting = false;
            //Debug.Log(gas);
            //myrigid.AddForce(dir * speed);
        }

        float angle = Mathf.Atan(dir.y/ dir.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        if (dir.x< 0)
        {
            angle += 180;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0 , angle));

        if ( shooting && shooTimer < Time.time)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPos.position,transform.rotation); //Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(dir * 30, ForceMode2D.Impulse); //AddForce(myrigid.velocity*5, ForceMode2D.Impulse);
            shooTimer = Time.time + 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePos =context.ReadValue<Vector2>();
        //mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        //Vector2 mousePos = context.ReadValue<Vector2>();
        //Debug.Log(mousePos); 
    }

    public void Boost(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            boosting = false;
        }
        else
        {
            boosting = true;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            shooting = false;
        }
        else
        {
            shooting = true;
        }
        //GameObject bullet = Instantiate(bulletPrefab, shootingPos.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().AddForce(myrigid.velocity*5, ForceMode2D.Impulse);
    }
}

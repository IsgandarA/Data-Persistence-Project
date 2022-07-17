using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Vector3 direction;
    public Counter counter;
    private float shotPower;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        counter = GameObject.Find("GameManager").GetComponent<Counter>();
        rb = gameObject.GetComponent<Rigidbody>();
        counter.power.value=0;
        cam = Camera.main;
        counter.thisShot = false;
        rb.useGravity = false;
        transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)& counter.power.value<1)
        {
            counter.power.value += Time.deltaTime;
            shotPower += Time.deltaTime * 20;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        rb.useGravity = true;
        direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        rb.AddRelativeForce(direction * shotPower);
        counter.thisShot = true;
        Destroy(this);
    }
}

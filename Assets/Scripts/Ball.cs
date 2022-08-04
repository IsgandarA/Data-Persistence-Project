using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Vector3 direction;
    //public Counter counter;
    public float shotPower;
    private Rigidbody rb;
    //public Slider power;
    public bool shot;
    public float zAxis;
    public float forceMod;
    public static float sTzAxis;

    // Start is called before the first frame update
    void Awake()
    {
        zAxis = sTzAxis;
        //power = Counter.Instance.power;
        //counter = GameObject.Find("GameManager").GetComponent<Counter>();
        rb = gameObject.GetComponent<Rigidbody>();
        //Counter.Instance.power.value = 0;
        cam = Camera.main;
        Counter.Instance.powerScore = 0;
        //thisShot = Counter.Instance.thisShot;
        //Counter.Instance.thisShot = false;
        rb.useGravity = false;
        transform.parent = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)& shotPower<1)
        {
            Counter.Instance.powerScore += Time.deltaTime * 1.3f;
            

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Shoot();
        }
 
        }

    void OnMouseOver()
    {

    }
    void Shoot()
    {
        rb.useGravity = true;
        //RaycastHit hit;
        //if (Physics.Raycast(cam.transform.position, ))
        direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,100));
        rb.AddRelativeForce(direction * Counter.Instance.powerScore*40);
        shot = true;
        Destroy(this);
    }
}

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
    private LineRenderer lr;
    //public Slider power;
    public bool shot;
    public int numPoints = 50;
    public float timeBetweenPoints = .1f;
    public LayerMask collision;
    public float zAxis;
    public float forceMod;
    public static float sTzAxis;
    public LayerMask CollidableLayers;
    float HorInput = 0;
    float VerInput = -20;
    // Start is called before the first frame update
    void Awake()
    {
        zAxis = sTzAxis;
        //power = Counter.Instance.power;
        //counter = GameObject.Find("GameManager").GetComponent<Counter>();
        rb = gameObject.GetComponent<Rigidbody>();
        lr = gameObject.GetComponent<LineRenderer>();
        //lr.colorGradient 
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

        if (HorInput <25 && Input.GetKey(KeyCode.D))
            {
            HorInput = HorInput +  .05f; 
            }
        if (HorInput > -25 && Input.GetKey(KeyCode.A))
        {
            HorInput = HorInput - .05f;
        }
        if (VerInput < -10 && Input.GetKey(KeyCode.S))
        {
            VerInput = VerInput + .05f;
        }
        if (VerInput > -30 && Input.GetKey(KeyCode.W))
        {
            VerInput = VerInput - .05f;
        }
        Debug.Log(HorInput +", "+ VerInput);
        Debug.Log(direction);
        shotPower = 1;
        direction = new Vector3(HorInput, 0, VerInput* -1* Counter.Instance.powerScore * shotPower);

        Debug.Log(direction);
        lr.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startPos = transform.position;
        Vector3 vel = direction;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = (startPos + t * vel);
            newPoint.y = startPos.y + vel.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);
            if (Physics.OverlapSphere(newPoint, .5f, CollidableLayers).Length > 0)
            {
                lr.positionCount = points.Count;
                break;
            }

        }
        lr.SetPositions(points.ToArray());
        if (Input.GetKey(KeyCode.Space)& Counter.Instance.powerScore < 1)
        {
            Counter.Instance.powerScore += Time.deltaTime * 1.3f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
        }

    void Shoot()
    {
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Physics.Raycast(ray, out RaycastHit raycasthit);

        rb.useGravity = true;
        //direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Counter.Instance.powerScore * 5000));
        //rb.AddForce(direction);
        //direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2000 * Counter.Instance.powerScore ));
        rb.AddForce(direction*shotPower, ForceMode.Impulse);
        lr.enabled = false;
        ////transform.Translate(direction);
        Debug.Log(Counter.Instance.powerScore);
        Debug.Log(direction);
        //        rb.AddForce(direction , ForceMode.Impulse);
        //* Counter.Instance.powerScore*100
        shot = true;
        Destroy(this);
    }
}

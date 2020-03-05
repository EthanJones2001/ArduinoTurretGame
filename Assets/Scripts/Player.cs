using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);

    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private float gunForce;
    [SerializeField]
    private float turretRotateSpeed;
    [SerializeField]
    private float fireRate = 0.5f;
    float nextFire = 0.0f;

    private Camera cam;

    public GameObject playerOne;
    public GameObject playerTwo;
    public bool controllerActive = false;
 //   public int commPort = 0;

  //  private SerialPort serial = null;
    private bool connected = false;



    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;

        cam = GetComponentInChildren<Camera>();
    }
    /*
        void Start()
        {
            ConnectToSerial();
        }

        void ConnectToSerial()
        {
            Debug.Log("Attempting Serial: " + commPort);

            // Read this: https://support.microsoft.com/en-us/help/115831/howto-specify-serial-ports-larger-than-com9
            serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
            serial.ReadTimeout = 50;
            serial.Open();

        }
        */
    void Update()
    {
        if(sp.IsOpen)
        {
        try
        {         
            if (sp.ReadByte() == 1 && Time.time > nextFire)
            {
                Shoot();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                cam.transform.Rotate(Vector3.down, turretRotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                cam.transform.Rotate(Vector3.up, turretRotateSpeed * Time.deltaTime);
            }

        } catch (System.Exception) { }

        }

    }

    void Shoot()
    {
        nextFire = Time.time + fireRate; 
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation) as Rigidbody;
        projectileInstance.AddForce(shootPoint.forward * gunForce);
    }
}

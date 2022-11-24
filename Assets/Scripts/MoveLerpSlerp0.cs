using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLerpSlerp0 : MonoBehaviour
{

    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    [SerializeField] private GameObject Cube3;
    [SerializeField] private GameObject Cube4;
    [SerializeField] private GameObject Cube5;
    [SerializeField] private GameObject Cube6;
    [SerializeField] private GameObject Targett;

    private Vector3 TargetTP;
    [SerializeField] private float speed = 0.9f;
    


    // Start is called before the first frame update
    void Start()
    {
        TargetTP = Targett.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }



    void MoveTo()
    {
        Cube1.transform.position = Vector3.Lerp(Cube1.transform.position, TargetTP, speed * Time.deltaTime);
        Cube2.transform.position = Vector3.Lerp(Cube2.transform.position, TargetTP, speed * Time.deltaTime);
        Cube3.transform.position = Vector3.Slerp(Cube3.transform.position, TargetTP, speed * Time.deltaTime);
        Cube4.transform.position = Vector3.Slerp(Cube4.transform.position, TargetTP, speed * Time.deltaTime);
        Cube5.transform.position = Vector3.MoveTowards(Cube5.transform.position, TargetTP,  (speed /Time.deltaTime) / 1000);
        Cube6.transform.position = Vector3.MoveTowards(Cube6.transform.position, TargetTP,  (speed /Time.deltaTime) / 1000);

    }
}

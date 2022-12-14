using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveLerpSlerp : MonoBehaviour
{

    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    [SerializeField] private GameObject Cube3;
    [SerializeField] private GameObject Cube4;
    [SerializeField] private GameObject Cube5;
    [SerializeField] private GameObject Cube6;
    [SerializeField] private GameObject Targett;

    private Vector3 TargetTP2;
    [SerializeField] private float speed = 0.9f;

    [HideInInspector] private Text Text__info003;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;



    // Start is called before the first frame update
    void Start()
    {
        TargetTP2 = Targett.transform.position;
        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info001.text = "";
        Text__info002.text = "";
        Text__info003.text = "";
        StartCoroutine("MoveTo", TargetTP2);

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }



    IEnumerator MoveTo(Vector3 TargetTP)
    {
        
        while ( Vector3.Distance(  Cube1.transform.position,TargetTP) > 10.2f)
        { 
        Cube1.transform.position = Vector3.Lerp(Cube1.transform.position, TargetTP, speed * Time.deltaTime);
        Cube2.transform.position = Vector3.Lerp(Cube2.transform.position, TargetTP, speed * Time.deltaTime);
        Cube3.transform.position = Vector3.Slerp(Cube3.transform.position, TargetTP, speed * Time.deltaTime);
        Cube4.transform.position = Vector3.Slerp(Cube4.transform.position, TargetTP, speed * Time.deltaTime);
        Cube5.transform.position = Vector3.MoveTowards(Cube5.transform.position, TargetTP,  (speed /Time.deltaTime) / 1000);
        Cube6.transform.position = Vector3.MoveTowards(Cube6.transform.position, TargetTP,  (speed /Time.deltaTime) / 1000);

            Text__info001.text = Cube4.transform.position.ToString();
            yield return null;
        }
        Text__info002.text = "WaitForSeconds(3f)";
        yield return new WaitForSeconds(3f);
        Text__info003.text = "WaitForSeconds(3f) Complete ";

    }
}

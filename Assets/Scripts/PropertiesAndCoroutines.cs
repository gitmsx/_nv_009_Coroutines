using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;




public class PropertiesAndCoroutines : MonoBehaviour
{
    [SerializeField] public int cicles=0;
    [HideInInspector] private Text Text__info003;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;


    public float smoothing = 7f;
    public Vector3 Target
    {
        get { return target; }
        set
        {
            target = value;
            StopCoroutine("Movement");
            StartCoroutine("Movement", target);
        }
    }



    private void Start()
    {

        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info001.text = "";
        Text__info002.text = "";
        Text__info003.text = "";

        cicles = 0;
        Vector3 randomVector = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        StartCoroutine(Random2, randomVector,out );
    }

    IEnumerator Random2(Vector3 target2)
    {
        while (cicles < 7) {
            cicles++;
            Text__info001.text = "cicles = " + cicles.ToString();
            yield return new WaitForSeconds(3);
            Text__info002.text = "Movement to target2 = " + target2.ToString();
            Movement(target2);
        }
    }



    private Vector3 target;



    IEnumerator Movement(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
            yield return null;

        }
    }
}

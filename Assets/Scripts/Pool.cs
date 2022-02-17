using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    
    public static Pool instance;

    public List<GameObject> objects = new List<GameObject>();
    public Transform desPos;

    private GameObject notListedObject;

    private void Start(){
        Shoot();
    }

    private void Shoot(){
        objects[0].gameObject.SetActive(true);
        objects[0].GetComponent<Rigidbody>().velocity = Vector3.back * 10;
        notListedObject = objects[0];

        objects.RemoveAt(0);

        Invoke("GetToThePool", 2);
    }

    public void GetToThePool(){
        objects.Add(notListedObject);
        notListedObject.transform.position = desPos.position;
        notListedObject.SetActive(false);

        Shoot();
    }
}

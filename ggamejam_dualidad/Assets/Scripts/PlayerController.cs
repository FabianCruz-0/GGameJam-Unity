using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string actualPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
    Physics.Raycast(this.transform.position,Vector3.down,out hit,10f);
     Debug.DrawRay(this.transform.position,Vector3.down,Color.red);
     actualPos = hit.collider.gameObject.name;
     Debug.Log(actualPos);
    }
}

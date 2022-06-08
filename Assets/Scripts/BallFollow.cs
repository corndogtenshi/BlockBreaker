using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    
    List<Vector3> last5Positions = new List<Vector3>();
    [SerializeField] float lerpFollowValue = 0.18f;
    public GameObject followObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //AddPosition();
        Follow();
    }

    void AddPosition(){
        last5Positions.Add(followObject.transform.position);
        if(last5Positions.Count >= 6){
            last5Positions.RemoveAt(0);
        }
        Debug.Log(last5Positions);
    }

    void Follow(){
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, followObject.gameObject.transform.position, lerpFollowValue);
    }
}

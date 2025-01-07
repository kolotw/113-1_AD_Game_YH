using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 小兵的行為 : MonoBehaviour
{
    NavMeshAgent 專員;
    Transform 目標;
    Vector3 鎖定方向;
    // Start is called before the first frame update
    void Start()
    {
        專員 = GetComponent<NavMeshAgent>();
        目標 = GameObject.Find("Player").transform;
        專員.SetDestination(目標.position);
        鎖定方向 = this.transform.eulerAngles;
        if (this.tag == "小兵") { 鎖定方向.y = 0; }
        else if(this.tag == "敵人"){鎖定方向.y = 180;}
        else { }
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = 鎖定方向; 
        if(Vector3.Distance(this.transform.position,目標.position) > 3.2f)
        {
            專員.isStopped = false;
            專員.SetDestination(目標.position);
        }
        else
        {
            專員.isStopped = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.tag == "敵人")
        {
            if(other.tag == "我方子彈")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}

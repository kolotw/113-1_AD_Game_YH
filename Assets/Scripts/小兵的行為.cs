using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 小兵的行為 : MonoBehaviour
{
    NavMeshAgent 專員;
    Transform 目標;
    Vector3 鎖定方向;

    public GameObject 子彈;
    public Transform 發射點;
    //public 遊戲管理員 GM;
    public GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("00遊戲管理員");
        
        專員 = GetComponent<NavMeshAgent>();
        //目標 = GameObject.Find("Player").transform;
        
        鎖定方向 = this.transform.eulerAngles;
        if (this.tag == "小兵") 
        {
            目標 = GameObject.FindWithTag("敵人").transform;
            鎖定方向.y = 0;
            InvokeRepeating("發射子彈", 1f, 3.0f);
        }
        else if(this.tag == "敵人")
        {
            目標 = GameObject.FindWithTag("小兵").transform;
            鎖定方向.y = 180;
        }
        else { }

        專員.SetDestination(目標.position);

        
        
    }
    void 發射子彈()
    {
        GameObject bb = Instantiate(子彈, 發射點.position, Quaternion.identity);
        bb.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100000f * Time.deltaTime);
        Destroy(bb, 2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<遊戲管理員>().isLost || GM.GetComponent<遊戲管理員>().isWon) return;

        if (目標 == null)
        {
            if (this.tag == "敵人")
            {
                目標 = GameObject.FindWithTag("小兵").transform;
                if (目標 == null) return;
            }
            else if (this.tag == "小兵")
            {
                目標 = GameObject.FindWithTag("敵人").transform;
                if (目標 == null) return;
            }
        }
            

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
            if((other.tag == "我方子彈") || (other.tag == "小兵"))
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}

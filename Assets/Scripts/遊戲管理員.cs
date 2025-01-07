using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 遊戲管理員 : MonoBehaviour
{
    public GameObject 敵人;
    public Transform 生成點;
    public bool isWon = false;
    public bool isLost = false;
    public int 敵人總數 = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 敵人總數; i++)
        {
            Instantiate(敵人, 生成點.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWon)
        {
            print("WIN");
            return;
        }
        if(GameObject.FindGameObjectsWithTag("敵人").Length == 0) { isWon = true; }
        if (GameObject.FindGameObjectsWithTag("小兵").Length == 0) { isLost = true; }
    }
}

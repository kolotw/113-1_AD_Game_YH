using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 遊戲管理員 : MonoBehaviour
{
    public GameObject 敵人;
    public Transform 生成點;
    public bool isWon = false;
    public bool isLost = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(敵人, 生成點.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

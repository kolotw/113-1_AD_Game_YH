using UnityEngine;

public class 玩家控制器 : MonoBehaviour
{
    public GameObject 子彈;
    public Transform 發射點;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("發射子彈", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //滑鼠移動法 獲取滑鼠位置並轉換為 Ray
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 使用 Raycast 檢測，確保射線擊中目標圖層
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag != "Player")
                {
                    // 移動 targetObject 到擊中的位置
                    Vector3 targetPosition = hit.point;
                    targetPosition.y = 0;
                    this.transform.position = targetPosition;
                }
            }
        }
    }

    void 發射子彈()
    {
        GameObject bb = Instantiate(子彈,發射點.position,Quaternion.identity);
        bb.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100000f * Time.deltaTime); 
        Destroy(bb,2f);
    }
}

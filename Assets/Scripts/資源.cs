using UnityEngine;
using TMPro;

public class 資源 : MonoBehaviour
{
    [SerializeField] string 符號 = "";
    [SerializeField] int 數值 = 0;
    public TextMeshPro 文字;
    public string 字串;
    public GameObject 小兵;
    GameObject[] soliders;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //要先確認這個資源是 +-*/
        字串 = 文字.text;
        符號 = 字串.Substring(0, 1);
        數值 = int.Parse(字串.Substring(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        //邏輯運算符號： 
        1. == 就是等於的意思
        2. || 或者
        3. && 而且
        4. <
        5. >
         */
        if (符號 == "+")
        {
            if (other.tag == "我方子彈")
            {
                數值++;
                文字.text = 符號 + 數值.ToString();
                Destroy(other.gameObject);
            }
            增加小兵(other);
        }        
        else if (符號 == "-")
        {
            尋找小兵數();
            if (soliders.Length < 數值) 數值 = soliders.Length;
            for (int i = 0; i < 數值; i++) 
            {
                Destroy(soliders[i]);
            }
            Destroy(this.gameObject);
        }
        else if (符號 == "x")
        {
            尋找小兵數();
            print(數值);
            數值 = (數值 * soliders.Length) - 數值;
            print(數值);
            增加小兵(other);
        }
        else if (符號 == "÷")
        {
            /*
             目前小兵數 6  /  (數值)3  = 2 餘 0 ---> 減4(數值) 
             四捨五入 RoundToInt
             */
            尋找小兵數();
            float minus = (soliders.Length / 數值);
            數值 = soliders.Length - Mathf.RoundToInt(minus);
            for (int i = 0; i < 數值; i++)
            {
                Destroy(soliders[i]);
            }
            Destroy(this.gameObject) ;
        }
        else { }
    }
    void 尋找小兵數()
    {
        soliders = null;
        soliders = GameObject.FindGameObjectsWithTag("小兵");        
    }
    void 增加小兵(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < 數值; i++)
            {
                Instantiate(小兵, this.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

}

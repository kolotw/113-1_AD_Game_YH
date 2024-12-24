using UnityEngine;
using TMPro;

public class 資源 : MonoBehaviour
{
    [SerializeField] string 符號 = "";
    [SerializeField] int 數值 = 0;
    public TextMeshPro 文字;
    public string 字串;
    public GameObject 小兵;
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
        if(other.tag == "我方子彈")
        {
            數值++;
            文字.text = 符號 + 數值.ToString();
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            for(int i = 0; i < 數值; i++)
            {
                Instantiate(小兵,this.transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }


}

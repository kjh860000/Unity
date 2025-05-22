using Unity.VisualScripting;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;
    public Mesh msh;
    public Material mat;

    //public Transform objTf;
    //public string changeName;

    void Start()
    {
        //obj = GameObject.Find("Main Camera");
        //obj = GameObject.FindGameObjectWithTag("Player");

        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

/*        objTf = GameObject.FindGameObjectWithTag("Player").transform;

        objTf.gameObject.SetActive(false);
        
        obj.name = changeName;

        Debug.Log($"이름 {obj.name}");
        Debug.Log($"태그 {obj.tag}");
        Debug.Log($"위치 {obj.transform.position}");
        Debug.Log($"회전 {obj.transform.rotation}");
        Debug.Log($"크기 {obj.transform.localScale}");

        Debug.Log($"mesh 데이터 {obj.GetComponent<MeshFilter>().mesh}");
        Debug.Log($"material 데이터 {obj.GetComponent<MeshRenderer>().material}");

        obj.GetComponent<MeshRenderer>().enabled = false;
        obj.SetActive(false);

        Debug.Log(obj.layer);*/

        CreateCube();
        CreateCube("Hello world");

    }
    public void CreateCube(string name = "Cube")
    {
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }
}

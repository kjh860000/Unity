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

        Debug.Log($"�̸� {obj.name}");
        Debug.Log($"�±� {obj.tag}");
        Debug.Log($"��ġ {obj.transform.position}");
        Debug.Log($"ȸ�� {obj.transform.rotation}");
        Debug.Log($"ũ�� {obj.transform.localScale}");

        Debug.Log($"mesh ������ {obj.GetComponent<MeshFilter>().mesh}");
        Debug.Log($"material ������ {obj.GetComponent<MeshRenderer>().material}");

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

using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;
/*    public GameObject destroyObj;

    public Vector3 pos;
    public Quaternion rot;*/

    void Awake()
    {
/*        Debug.Log("�����Ǿ����ϴ�.");
*/        CreateAmongus();

/*        Destroy(destroyObj, 3f);*/
    }

/*    private void OnDestroy()
    {
        Debug.Log("�ı��Ǿ����ϴ�.");
    }*/
    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab); //, pos, rot
        obj.name = "AmongusPlayer";

/*        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"ĳ������ �ڽ� ������Ʈ �� : {count}");

        Debug.Log($"ĳ������ ù��° �ڽ� ������Ʈ �̸� : {obj.transform.GetChild(0).name}");

        Debug.Log($"ĳ������ ������ �ڽ� ������Ʈ �̸� : {obj.transform.GetChild(count - 1).name}");*/

    }
}

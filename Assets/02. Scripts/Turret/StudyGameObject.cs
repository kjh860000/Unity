using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;
/*    public GameObject destroyObj;

    public Vector3 pos;
    public Quaternion rot;*/

    void Awake()
    {
/*        Debug.Log("생성되었습니다.");
*/        CreateAmongus();

/*        Destroy(destroyObj, 3f);*/
    }

/*    private void OnDestroy()
    {
        Debug.Log("파괴되었습니다.");
    }*/
    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab); //, pos, rot
        obj.name = "AmongusPlayer";

/*        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"캐릭터의 자식 오브젝트 수 : {count}");

        Debug.Log($"캐릭터의 첫번째 자식 오브젝트 이름 : {obj.transform.GetChild(0).name}");

        Debug.Log($"캐릭터의 마지막 자식 오브젝트 이름 : {obj.transform.GetChild(count - 1).name}");*/

    }
}

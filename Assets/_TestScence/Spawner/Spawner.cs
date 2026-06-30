using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefab();   
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ":LoadHolder",gameObject);
    }
    protected virtual void LoadPrefab()
    {
        if(this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + " " + ": LoadPrefab ",gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName,Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);// tìm kiếm tên prefab theo tên
        if(prefab.name == null)
        {
            Debug.LogError("prefab not found: " + prefab.name);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab); // lấy object
        newPrefab.SetPositionAndRotation(spawnPos,rotation); // đặt vị trí và góc quay
        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName)
            {
                return prefab; // lệnh return sẽ trực tiếp bỏ qua các câu lệnh ở dưới và thoát vòng lặp
            }
        }
        return null; // lệnh này sẽ không được chạy vì ta đã có lệnh return ở trên(nếu điều kiện ở trên đúng)
    }
    public virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolobj in this.poolObjs)
        {
            if(poolobj.name == prefab.name) // so sánh tên object với prefab
            {
                this.poolObjs.Remove(poolobj);
                return poolobj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        Debug.Log("SetActive: " + transform.name);
        this.spawnedCount--;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0,this.prefabs.Count);
        return this.prefabs[rand];
    }
}

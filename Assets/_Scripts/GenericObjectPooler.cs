using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts
{
    // to jest mój bardzo hacky system do super szybkiego setapuwoanego poolowania
    public class GenericObjectPooler : MonoBehaviour
    {
        public static List<PooledObjectInfo> ObjectPools = new();

        public enum PoolType
        {
            None,
            ItemDisplay,
            ItemDrop,
        }

        private static Dictionary<PoolType, Transform> poolParents = new();
    
        private void Awake()
        {
            SetupEmptyObjects();
        }

        private void SetupEmptyObjects()
        {
            foreach (PoolType poolType in Enum.GetValues(typeof(PoolType)))
            {
                poolParents[poolType] = new GameObject(poolType.ToString()).transform;
                poolParents[poolType].transform.SetParent(this.transform);
            }
        }


        public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
        {
            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString.Equals(objectToSpawn.name + "(Clone)"));

            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString  =  objectToSpawn.name + "(Clone)"};
                ObjectPools.Add(pool);
            }

            GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

            if (spawnableObj == null)
            {
                spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation, poolParents[poolType]);
            }
            else
            {
                spawnableObj.transform.position = spawnPosition;
                spawnableObj.transform.rotation = spawnRotation;
                spawnableObj.transform.SetParent(poolParents[poolType]);
                pool.InactiveObjects.Remove(spawnableObj);
                
            }
            spawnableObj.SetActive(true);
            
            return spawnableObj;
        }

        public static void ReturnObjectToPool(GameObject obj, bool destroyIfNoPoolFound = false)
        {
            if (obj == null)
            {
                return;
            }

            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString.Equals(obj.name));

            if (pool == null)
            {
                if (destroyIfNoPoolFound)
                {
                    Destroy(obj);
                }

                else
                {
                    Debug.LogError("Returning object without initialized pool " + obj.name, obj);
                }
            }
            else
            {
                obj.SetActive(false);
                pool.InactiveObjects.Add(obj);
            }
        }
    }


    public class PooledObjectInfo
    {
        public string LookupString;
        public List<GameObject> InactiveObjects = new();
    }
}
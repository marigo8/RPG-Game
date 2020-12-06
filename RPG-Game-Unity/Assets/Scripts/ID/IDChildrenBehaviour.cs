using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDChildrenBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct Child
    {
        public ID id;
        public GameObject obj;
    }

    public List<Child> children;

    public GameObject GetChildWithId(ID id)
    {
        foreach (var child in children)
        {
            if (child.id != id) continue;
            return child.obj;
        }

        return null;
    }
}

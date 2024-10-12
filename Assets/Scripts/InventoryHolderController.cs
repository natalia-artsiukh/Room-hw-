using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolderController : MonoBehaviour
{
    private Rigidbody _childRigidbody;
    
    [SerializeField]
    private float _pushForce = 500;
    
    void Update()
    {
        if (transform.childCount > 0)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                LeaveObject();
                _childRigidbody.AddForce(transform.forward * _pushForce);
            }
        }
    }

    public void TakeObject(Transform selectedObject)
    {
        if (transform.childCount == 1)
        {
            LeaveObject();
        }
        _childRigidbody = selectedObject.GetComponent<Rigidbody>();
        selectedObject.SetParent(transform, true);
        selectedObject.localPosition = new Vector3(0, 0, 0);
        _childRigidbody.isKinematic = true;
    }

    private void LeaveObject()
    {
        _childRigidbody.isKinematic = false;
        _childRigidbody.transform.SetParent(null);
    }
}

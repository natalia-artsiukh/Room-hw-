using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractionController : MonoBehaviour
{
    private GameObject _currentObject;
    private GameObject _previousObject;
    void Update()
    {
        var ray = new Ray(Camera.main.transform.position, transform.forward);
        var hasObject = Physics.Raycast(ray, out RaycastHit hitInfo);
        if (hasObject)
        {
            _currentObject = hitInfo.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_currentObject.layer== LayerMask.NameToLayer("Door"))
                {
                    _currentObject.GetComponent<Door>().SwitchDoorState();
                }

                if (_currentObject.layer == LayerMask.NameToLayer("Items"))
                {
                    transform.GetComponentInChildren<InventoryHolderController>().TakeObject(_currentObject.transform);
                }
            }
            
            if (_currentObject.layer == LayerMask.NameToLayer("Items") && _currentObject != _previousObject)
            {
                _currentObject.GetComponent<InteractableItem>().SetFocus();
            }
        }
        else
        {
            _currentObject = null;
        }
        
        if (_previousObject != _currentObject && _previousObject != null && _previousObject.layer == LayerMask.NameToLayer("Items"))
        {
            _previousObject.GetComponent<InteractableItem>().RemoveFocus();
        }

        _previousObject = _currentObject;

    }
}

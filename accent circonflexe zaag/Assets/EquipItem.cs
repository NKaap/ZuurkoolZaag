using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public Transform empty;
    public Transform camera;
    public GameObject item;

    private RaycastHit hit;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (item == null)
            {
                if (Physics.Raycast(camera.position, camera.forward, out hit, 10))
                {
                    if (hit.transform.tag == "Item")
                    {
                        item = hit.transform.gameObject;
                        item.transform.GetComponent<Rigidbody>().isKinematic = true;
                        item.transform.SetParent(camera.transform.parent, false);
                        item.transform.SetPositionAndRotation(empty.position, empty.rotation);
                    }
                }
            }
            else
            {             
                item.transform.SetParent(null);
                item.transform.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddForce(camera.forward * 150 + Vector3.up * 50, ForceMode.Impulse);
                item = null;
            }
        }
    }
}

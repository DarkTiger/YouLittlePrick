using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] private GameObject missionObjectEquiped;
    private bool _missionEquiped=false;

    public bool MissionEquiped
    {
        get => _missionEquiped;

        set
        {
            _missionEquiped = value;
            OnMissionObjectBool.Invoke(_missionEquiped);
        }
    }
    

    [SerializeField] private GameObject funnyObjectEquiped;
    private bool _funnyEquiped = false;

    public bool FunnyEquiped
    {
        get => _funnyEquiped;

        set
        {
            _funnyEquiped = value;
            OnFunnyObjectBool.Invoke(_funnyEquiped);
        }
    }

    [SerializeField] float throwForce;

    bool canInteract = true;

    [SerializeField] float interactionCD = 0.5f;

    

    public void ChangeObject(GameObject obj)
    {
        if(!canInteract)
        {
            return;
        }

        PickableObject newObject= obj.GetComponent<PickableObject>();

        if ( newObject != null )
        {
            if(newObject.GetObjectType()== pickableObjectType.Mission)
            {
                if(missionObjectEquiped!=null)
                {
                    missionObjectEquiped.SetActive(true);
                    missionObjectEquiped.transform.parent = null;
                    missionObjectEquiped.GetComponent<Rigidbody>().AddExplosionForce(throwForce, new Vector3(transform.localScale.x, 0), 0.3f);

                    SetMissionObject(newObject);
                }
                else
                {
                    SetMissionObject(newObject);
                }

                canInteract = false;
                StartCoroutine(StartInteractionCD());
            }
            else if(newObject.GetObjectType() == pickableObjectType.Funny)
            {
                if (funnyObjectEquiped != null)
                {
                    funnyObjectEquiped.SetActive(true);
                    funnyObjectEquiped.transform.parent = null;
                    funnyObjectEquiped.GetComponent<Rigidbody>().AddForce(Vector3.right * throwForce);

                    SetFunnyObject(newObject);
                }
                else
                {
                    SetFunnyObject(newObject);
                }
            }

            canInteract= false;
            StartCoroutine(StartInteractionCD());
        }
    }

    private void SetMissionObject(PickableObject newObject)
    {
        missionObjectEquiped = newObject.gameObject;
        missionObjectEquiped.transform.parent = gameObject.transform;
        missionObjectEquiped.transform.localPosition = Vector3.zero;
        missionObjectEquiped.SetActive(false);

        MissionEquiped = true;
    }

    private void SetFunnyObject(PickableObject newObject)
    {
        funnyObjectEquiped = newObject.gameObject;
        funnyObjectEquiped.transform.parent = gameObject.transform;
        funnyObjectEquiped.transform.localPosition = Vector3.zero;
        funnyObjectEquiped.SetActive(false);

        FunnyEquiped = true;
    }

    IEnumerator StartInteractionCD()
    {
        yield return new WaitForSeconds(interactionCD);

        canInteract = true;
    }

    public delegate void OnMissionObjectBoolChanged(bool newValue);
    public event OnMissionObjectBoolChanged OnMissionObjectBool;

    public delegate void OnFunnyObjectBoolChanged(bool newValue);
    public event OnFunnyObjectBoolChanged OnFunnyObjectBool;

    public GameObject GetMissionObject()
    {
        return missionObjectEquiped;
    }

    public GameObject GetFunnyObject()
    {
        return funnyObjectEquiped;
    }
}
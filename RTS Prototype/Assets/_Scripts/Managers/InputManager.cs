using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{

    public Camera cam;
    public GameObject navPointer;
    public GameObject selectedObj;
    private EntityController _activeEntity;
    public Text objectTeam;
    public Text objectName;
    public Text objectHealth;
    public GameObject taskObject;

    void Start()
    {
        ResetUnitText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick();
        }

        if (_activeEntity != null)
        {
            objectHealth.text = _activeEntity.currentHealth.ToString();
            PointerCheck();
        } 
    }

    void OnLeftClick()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Select a Single Unit
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Deselect an Object if Clicked Object is Not Selectable
                if (hit.collider.GetComponent<EntityController>() == null)
                {
                    ObjectDeselect();
                    ResetUnitText();
                }
                //Select an Object if Object is Selectable
                else if (hit.collider.GetComponent<EntityController>().isSelectable)
                {
                    ObjectDeselect();

                    _activeEntity = hit.collider.GetComponent<EntityController>();
                    selectedObj = hit.collider.gameObject;
                    
                    _activeEntity.selectionCircle.SetActive(true);
                    objectName.text = _activeEntity.objName;
                    switch (_activeEntity.team.teamAttribute)
                    {
                        case Team.TeamAttribute.Player:
                            objectTeam.text = "Player";
                            break;
                        case Team.TeamAttribute.Enemy:
                            objectTeam.text = "Enemy";
                            break;
                        default:
                            objectTeam.text = "Neutral";
                            break;
                    }
                }
            }
        }
    }

    void OnRightClick()
    {
        if (_activeEntity != null && _activeEntity.team.teamAttribute == Team.TeamAttribute.Player)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move to Ground Position
                if (hit.collider.CompareTag("Ground"))
                {
                    _activeEntity.isTasked = false;
                    _activeEntity.assignedTask = null;
                    if (_activeEntity.agent != null)
                    {
                        _activeEntity.agent.SetDestination(hit.point);
                        _activeEntity.anim.SetTrigger("Idle");
                        navPointer.SetActive(true);
                        navPointer.transform.position = hit.point;
                    }
                }

                if (hit.collider.GetComponent<EntityController>() != null &&
                    hit.collider.GetComponent<EntityController>().isSelectable &&
                    hit.collider.gameObject != selectedObj)
                {
                    _activeEntity.assignedTask = hit.collider.gameObject;
                    _activeEntity.isTasked = true;
                    navPointer.SetActive(false);
                }
            }
        }
    }

    void ResetUnitText()
    {
        objectTeam.text = "Left Click to Select an Object.";
        objectName.text = "Right Click to Move a Selected Object.";
        objectHealth.text = "";
    }

    void ObjectDeselect()
    {
        //Reset Selection
        if (_activeEntity != null)
        {
            _activeEntity.selectionCircle.SetActive(false);
            navPointer.SetActive(false);
            _activeEntity = null;
        }
    }

    void PointerCheck()
    {
        if (!_activeEntity.agent.pathPending)
        {
            if (_activeEntity.agent.remainingDistance <= _activeEntity.agent.stoppingDistance)
            {
                if (!_activeEntity.agent.hasPath || _activeEntity.agent.velocity.sqrMagnitude == 0f)
                {
                    navPointer.SetActive(false);
                }
            }
        }
    }
}

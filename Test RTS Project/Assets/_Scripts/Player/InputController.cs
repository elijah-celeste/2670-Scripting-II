using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{

	public Camera cam;
	public GameObject navpointer;
	public GameObject selectedObj;
	private EntityData _activeEntity;
	public Text objectName;
	public Text objectTeam;
	public Text objectHealth;
	public GameObject taskObject;
	public Button contextA;
	public Button contextB;

	void Start()
	{
		objectName.text = "Left Click to Select an Object.";
		objectTeam.text = "";
		objectHealth.text = "";
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			OnLeftClick();
		}
		if (Input.GetMouseButtonDown(1))
		{
			OnRightClick();
		}
		
		//Update Selected Unit Health
		if (_activeEntity != null)
		{
			objectHealth.text = _activeEntity.currentHealth.ToString();
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
				if (hit.collider.GetComponent<EntityData>() == null)
				{
					if (_activeEntity != null)
					{
						_activeEntity.selectionCircle.SetActive(false);
						_activeEntity = null;
					}
					_activeEntity = null;
					objectName.text = "Left Click to Select an Object.";
					objectTeam.text = "";
					objectHealth.text = "";
					contextA.gameObject.SetActive(false);
					contextB.gameObject.SetActive(false);	
				}
				else if (hit.collider.GetComponent<EntityData>().isSelectable)
				{
					//Reset Selection
					if (_activeEntity != null)
					{
						_activeEntity.selectionCircle.SetActive(false);
						_activeEntity = null;
						contextA.gameObject.SetActive(false);
						contextB.gameObject.SetActive(false);
					}

					//Set New Active GameObject
					_activeEntity = hit.collider.GetComponent<EntityData>();
					selectedObj = hit.collider.gameObject;
				
					_activeEntity.selectionCircle.SetActive(true);
					objectName.text = _activeEntity.objName;
					switch (_activeEntity.team.TeamAttribute)
					{
						case Team.teamAttribute.Player:
							objectTeam.text = "Player";
							break;
						case Team.teamAttribute.Enemy:
							objectTeam.text = "Enemy";
							break;
						default:
							objectTeam.text = "Neutral";	
							break;
					}
				
					//Enable ContextButtons if Option
					if (_activeEntity.team.TeamAttribute == Team.teamAttribute.Player && _activeEntity.hasContextMenu)
					{
						if (_activeEntity.hasContextA == true)
						{
							contextA.gameObject.SetActive(true);
							contextA.GetComponentInChildren<Text>().text = _activeEntity.textA;
						}

						if (_activeEntity.hasContextB == true)
						{
							contextB.gameObject.SetActive(true);
							contextB.GetComponentInChildren<Text>().text = _activeEntity.textB;
						}
					}
					else if (!_activeEntity.hasContextMenu)
					{
						contextA.gameObject.SetActive(false);
						contextB.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	//Unit Movement and Tasking
	void OnRightClick()
	{
		if (_activeEntity != null && _activeEntity.team.TeamAttribute == Team.teamAttribute.Player)
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (_activeEntity.baseDamage > 0)
			{
				_activeEntity.anim.SetTrigger("Attack");
			}

			if (Physics.Raycast(ray, out hit))
			{
				//Move to Ground Position
				if (hit.collider.CompareTag("Ground"))
				{
					_activeEntity.isTasked = false;
					navpointer.transform.position = hit.point;
					navpointer.SetActive(false);
					navpointer.SetActive(true);
					if (_activeEntity.agent != null)
					{
						_activeEntity.agent.SetDestination(hit.point);
						_activeEntity.directionArrow.SetActive(false);
						_activeEntity.directionArrow.SetActive(true);
					}
				}

				if (hit.collider.GetComponent<EntityData>() != null && 
				    hit.collider.GetComponent<EntityData>().isSelectable)
				{
					Debug.Log("Unit Selected");
					_activeEntity.assignedTask = hit.collider.gameObject;
					_activeEntity.isTasked = true;
				}
			}
		}
	}
	
	//Button Functions
	public void ButtonA()
	{
		Debug.Log("Button A Pressed");
	}
	public void ButtonB()
	{
		Debug.Log("Button B Pressed");
	}
}
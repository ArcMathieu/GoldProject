//--- Copyright Francko et Romain, tous droits réservés ---//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[System.Serializable]
	public class InputConfig
	{
		public int _id;
		public GameObject _goTouch;

		public Vector2 _initPos;
		public Vector2 _currentPos;
		public Vector2 _lastPos;

		public InputConfig() 
		{
			_id = 0;
			_goTouch = null;
			_initPos = Vector2.zero;
			_currentPos = Vector2.zero;
			_lastPos = Vector2.zero;
		}

		public InputConfig(int id, GameObject goTouch, Vector2 initPos, Vector2 currentPos, Vector2 lastPos) 
		{
			_id = id;
			_goTouch = goTouch;
			_initPos = initPos;
			_currentPos = currentPos;
			_lastPos = lastPos;


		}
	}

	public List<InputConfig> inputBegan = new List<InputConfig>();
	public List<InputConfig> inputMoved = new List<InputConfig>();
	public List<InputConfig> inputEnded = new List<InputConfig>();

	public Camera cam;
	private Vector2 inputPosition;
	private int nbTouch = 0;


	private void Start()
	{
		//cam = FindObjectOfType<ControlCamera>().GetComponent<Camera>();
	}

	private void Update()
	{
		if(Input.touchCount > 0)
		{
			CheckInputMobile();
		}
		UpdateTouch();
		RefreshInputBeganList();
		RefreshInputEndedList();
	}

	//--- Check le nombre de touch sur l'écran ---// 
	void UpdateTouch()
	{
		nbTouch = inputBegan.Count + inputMoved.Count + inputEnded.Count;

		if(nbTouch > 0)
		{
			if(nbTouch == 1)
			{
				SingleTouchController();
			}

			else
			{
				SelectMultiTouch();
			}
		}
	}

	//--- S'il y a un appui sur l'écran ---// 
	void SingleTouchController()
	{
		Debug.Log("Single touch select");

		if(inputBegan.Count > 0 && inputBegan[0] != null)
		{
			if (CheckGoHit(inputBegan[0]))
			{
				SelectObject(inputBegan[0]);
			}
		}

		else if(inputMoved.Count > 0 && inputMoved[0] != null)
		{
			MoveObject(inputMoved[0]);
		}

		else if(inputEnded.Count > 0 && inputEnded[0] != null)
		{
			DeselectObject(inputEnded[0]);
		}
	}

	//--- S'il y a plusieurs appuis à l'écran ---// 
	void SelectMultiTouch()
	{
		Debug.Log("Multi touch select");

		if(inputBegan.Count > 0)
		{
			for (int i = 0; i < inputBegan.Count; i++)
			{
				if(inputBegan[i] != null)
				{
					if (CheckGoHit(inputBegan[i]))
					{
						SelectObject(inputBegan[i]);
					}
				}
			}
		}

		if (inputMoved.Count > 0)
		{
			for (int i = 0; i < inputMoved.Count; i++)
			{
				if (inputMoved[i] != null)
				{
					MoveObject(inputMoved[i]);
				}
			}
		}
		
		if (inputEnded.Count > 0)
		{
			for (int i = 0; i < inputMoved.Count; i++)
			{
				if (inputMoved[i] != null)
				{
					DeselectObject(inputMoved[i]);
					inputEnded.Remove(inputMoved[i]);
				}
			}
		}
	}

	//--- Check s'il touche un transform ---//
	bool CheckHit2D(Vector2 pos, out RaycastHit2D hit2D)
	{
		if (cam != null)
		{
			hit2D = Physics2D.Raycast(cam.ScreenPointToRay(pos).origin, Vector3.back);

			if(hit2D.transform != null)
			{
				return true;
			}
		}

		hit2D = new RaycastHit2D();
		return false;
	}

	//--- Check s'il touche un GameObject ---//
	bool CheckGoHit(InputConfig input)
	{
		RaycastHit2D hit2D;

		if(CheckHit2D(input._currentPos, out hit2D))
		{
			input._goTouch = hit2D.transform.gameObject;
			return true;
		}

		return false;
	}

	//--- Selectionne un objet ---//
	void SelectObject(InputConfig input)
	{
		if(input != null && input._goTouch != null)
		{
			//-- Appelle SelectObject dans le script de l'objet ---//
			//input._goTouch.GetComponent<DragAndDrop>().SelectObject(input._initPos);
		}
	}

	//--- Bouge un objet ---//
	void MoveObject(InputConfig input)
	{
		if(input != null && input._goTouch != null)
		{
			//-- Appelle MoveObject dans le script de l'objet ---//
			//input._goTouch.GetComponent<DragAndDrop>().MoveObject(input._currentPos);
		}
	}

	//--- Deselectionne un objet ---//
	void DeselectObject(InputConfig input)
	{
		if(input != null && input._goTouch != null)
		{
			//-- Appelle DeselectObject dans le script de l'objet ---//
			//input._goTouch.GetComponent<DragAndDrop>().DeselectObject(input._currentPos);
		}
	}

	//--- Bridge d'Input Began à Input Moved ---//
	void RefreshInputBeganList()
	{
		if(inputBegan.Count > 0)
		{
			foreach (InputConfig ic in inputBegan)
			{
				inputMoved.Add(ic);
			}

			inputBegan.Clear();
		}
	}

	//--- Bridge d'Input Moved à Input Ended ---//
	void RefreshInputEndedList()
	{
		if(inputEnded.Count > 0)
		{
			inputEnded.Clear();
		}
	}

	//--- Gère la phase "Began" ---//
	void InputBegan(int idInput, Vector2 pos)
	{
		InputConfig newIC = new InputConfig();

		if(newIC != null)
		{
			newIC._id = idInput;
			newIC._initPos = pos;
			newIC._currentPos = pos;
			newIC._lastPos = pos;

			inputBegan.Add(newIC);
		}
		Debug.Log("Input Began");

	}

	//--- Gère la phase "Moved" ---//
	void InputMoved(int idInput, Vector2 pos)
	{
		if(inputMoved.Count > 0)
		{
			InputConfig ic = inputMoved.Find(x => x._id == idInput);
			ic._lastPos = ic._currentPos;
			ic._currentPos = pos;
		}
		Debug.Log("Input Moved");

	}

	//--- Gère la phase "Ended" ---//
	void InputEnded(int idInput, Vector2 pos)
	{
		if(inputMoved.Count > 0)
		{
			InputConfig ic = inputMoved.Find(x => x._id == idInput);
			inputEnded.Add(ic);
			inputMoved.Remove(ic);
		}
		Debug.Log("Input Ended");
	}

	//--- Gère les différentes phases des Inputs ---//
	void CheckInputMobile()
	{
		for(int i = 0; i < Input.touchCount; i++)
		{
			Touch t = Input.GetTouch(i);

			if(t.phase == TouchPhase.Began)
			{
				InputBegan(t.fingerId, t.position);
			}
			else if (t.phase == TouchPhase.Moved)
			{
				InputMoved(t.fingerId, t.position);
			}
			else if(t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
			{
				InputEnded(t.fingerId, t.position);
			}
		}
	}
}

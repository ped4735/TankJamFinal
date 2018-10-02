using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandController : MonoBehaviour
{
	//TODO trocar para script principal de comandos do tank
	[SerializeField] private ComplexTankMoviment _tank;
	[SerializeField] private TMP_InputField _cmdInput;
	[SerializeField] private TextMeshProUGUI _cmdLog;
	//[SerializeField] private Text cmdLog;
	private List<string> _cmds;
	private bool _incorrectCmd;
	private bool _isDeselected;

	
	public void ChangeText()
	{
		//Debug.Log(cmdInput.text);
		
	}

	private void Start()
	{
		_cmdLog.text = "";
	}

	public void Selected()
	{
		//Debug.Log("Selected!");
	}
	
	public void Deselected()
	{
		Debug.Log("Deselected!");
		_isDeselected = true;
	}
	
	
	public void EndCommand()
	{
		//Debug.Log(cmdInput.text);
		
		Debug.Log("End Command");
		try
		{
			_cmds = new List<string>(_cmdInput.text.Split(' '));
			
			
			//TODO enviar comandos para o tank
			switch (_cmds[0])
			{
				
				case "brk":
					_cmdLog.text += "<color=#55b938>BREAK! " + float.Parse(_cmds[1]) + "\n";
					_tank.BreakByTime(float.Parse(_cmds[1]));
					break;
				case "acc":
					_cmdLog.text += "<color=#55b938>ACC! " + float.Parse(_cmds[1]) + "\n";
					_tank.AccByTime(float.Parse(_cmds[1]));
					break;
				case "help":
					_cmdLog.text += "<color=\"blue\"><<help>>\n" +
					                "ACC num\n" +
					                "BRK num\n" +
					                "RR num\n" +
					                "RL num\n";
					break;
				case "sht":
					//_cmdLog.text += "<color=#55b938>SHOOT\n";
					_tank.Shoot();
					break;
				case ""://Não tira isso - vai bugar 
					break;
				default:
					throw new Exception();
					break;
			}
			
		}
		catch (Exception e)
		{
			Debug.Log(e.ToString());
			_incorrectCmd = true;
		}		
	
		if (_incorrectCmd)
		{
			_cmdLog.text += "<color=\"red\">Invalid CMD \nTry:<color=\"blue\">help\n";
			_incorrectCmd = false;
		}

		//Volta a dar foco no inputbox após enter
		if (!_isDeselected)
		{
			_cmdInput.ActivateInputField();
		}
		
		_cmdInput.text = "";
		
	}

	public void ReceiveCommand(string cmd)
	{
		_cmdLog.text += "<color=#55b938>" + cmd;
	}
	
}

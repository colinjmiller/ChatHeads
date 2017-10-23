using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatHeadsAPI : MonoBehaviour {

	public GameObject nameBackground;
	public GameObject nameText;
	public GameObject speechBackground;
	public GameObject speechText;
	public GameObject speechGiver;
	public GameObject queryOption1;
	public GameObject queryOption2;
	public GameObject queryIndicator;

	private GameObject _nameBackground;
	private GameObject _nameText;
	private GameObject _speechBackground;
	private GameObject _speechText;
	private GameObject _speechGiver;
	private GameObject _queryOption1;
	private GameObject _queryOption2;
	private GameObject _queryIndicator;
	private bool _optionOneHighlighted;
	private ChatQueryOption[] _chatQueryOptions;

	private bool _isMessageShown;
	private bool _isQueryShown;

	private void hideAll() {
		_nameBackground.SetActive (false);
		_nameText.SetActive (false);
		_speechBackground.SetActive (false);
		_speechText.SetActive (false);
		_speechGiver.SetActive (false);
		_queryOption1.SetActive (false);
		_queryOption2.SetActive (false);
		_queryIndicator.SetActive (false);
		_isMessageShown = false;
		_isQueryShown = false;
	}

	private void setMessageActive() {
		hideAll ();

		_isMessageShown = true;
		_nameBackground.SetActive (true);
		_nameText.SetActive (true);
		_speechBackground.SetActive (true);
		_speechText.SetActive (true);
		_speechGiver.SetActive (true);
	}

	private void setQueryActive() {
		setMessageActive ();

		_isQueryShown = true;
		_optionOneHighlighted = true;
		_queryOption1.SetActive (true);
		_queryOption2.SetActive (true);
		_queryIndicator.SetActive (true);
	}

	void Awake () {
		_nameBackground = Instantiate (nameBackground, gameObject.transform);
		_nameText = Instantiate (nameText, gameObject.transform);
		_speechBackground = Instantiate (speechBackground, gameObject.transform);
		_speechText = Instantiate (speechText, gameObject.transform);
		_speechGiver = Instantiate (speechGiver, gameObject.transform);
		_queryOption1 = Instantiate (queryOption1, gameObject.transform);
		_queryOption2 = Instantiate (queryOption2, gameObject.transform);
		_queryIndicator = Instantiate (queryIndicator, gameObject.transform);
		_optionOneHighlighted = true;
		hideAll ();
	}

	public bool isMessageShown() {
		return _isMessageShown;
	}

	void Update() {
		/*
		 * If a query is displayed, the player can scroll through the options
		 */
		if (_isQueryShown) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
				_optionOneHighlighted = !_optionOneHighlighted;
				Transform indicatorTransform = _queryIndicator.transform;
				if (_optionOneHighlighted) {
					indicatorTransform.position = new Vector3 (indicatorTransform.position.x, _queryOption1.transform.position.y);
				} else {
					indicatorTransform.position = new Vector3 (indicatorTransform.position.x, _queryOption2.transform.position.y);
				}
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				Action callback = _chatQueryOptions[_optionOneHighlighted ? 0 : 1].getCallback();
				callback();
			}
		}
	}

	private void _showMessage(ChatMessage message) {
		setMessageActive ();
	}

	private void _showQuery(ChatQuery message) {
		_chatQueryOptions = message.getQueryOptions ();
		_queryOption1.GetComponent<Text> ().text = _chatQueryOptions [0].getLabel ();
		_queryOption2.GetComponent<Text> ().text = _chatQueryOptions [1].getLabel ();
		setQueryActive ();
	}
		
	public void showMessage(ChatMessage message) {
		_speechText.GetComponent<Text> ().text = message.getSpeechText();
		if (message.hasNameText()) {
			_nameText.GetComponent<Text> ().text = message.getNameText();
		}
		if (message.hasSpeechGiver()) {
			_speechGiver.GetComponent<Image> ().sprite = message.getSpeechGiver();
		}
		if (message.GetType () == typeof(ChatMessage)) {
			_showMessage (message);
		} else {
			_showQuery ((ChatQuery) message);
		}
	}

	public void hide() {
		hideAll ();
		_isQueryShown = false;
	}
}

using System;
using UnityEngine;

public class ChatMessage {

	private string speechText;
	private string nameText;
	private Sprite speechGiver;

	public ChatMessage(string speechText, string nameText = null, Sprite speechGiver = null) {
		this.speechText = speechText;
		this.nameText = nameText;
		this.speechGiver = speechGiver;
	}

	public string getSpeechText() {
		return speechText;
	}

	public bool hasNameText() {
		return nameText != null;
	}

	public string getNameText() {
		return nameText;
	}

	public bool hasSpeechGiver() {
		return speechGiver != null;
	}

	public Sprite getSpeechGiver() {
		return speechGiver;
	}

	public ChatQueryOption[] getQueryOptions() {
		throw new NotImplementedException ("Trying to get query options on ChatMessage");
	}
}

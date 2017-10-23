using System;
using UnityEngine;

public class ChatQuery : ChatMessage {

	private string speechText;
	private ChatQueryOption[] options;
	private string nameText;
	private Sprite speechGiver;

	public ChatQuery(string speechText, ChatQueryOption[] options, string nameText = null, Sprite speechGiver = null)
			:base(speechText, nameText, speechGiver) {
		this.options = options;
	}

	public new ChatQueryOption[] getQueryOptions() {
		return options;
	}
}

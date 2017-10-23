using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testChatter : MonoBehaviour {

	public GameObject canvas;
	public Sprite colinSprite;
	public Sprite tommySprite;

	private ChatHeadsAPI chatHeadsAPI;
	private int chatMessageIndex = 0;
	private ChatMessage[] messages;

	public void firstAction() {
		chatMessageIndex = 0;
		messages = new ChatMessage[] {
			new ChatMessage("You like questions, too??", "Tommy", tommySprite),
			new ChatMessage("Wow, we have so much in common!")
		};
	}

	public void secondAction() {
		chatMessageIndex = 0;
		messages = new ChatMessage[] {
			new ChatMessage("Well, I suppose you can have your opinion...", "Tommy", tommySprite)
		};
	}

	void Start() {
		chatHeadsAPI = canvas.GetComponent<ChatHeadsAPI> ();
		messages = new ChatMessage[] {
			new ChatMessage("Hey, look at us go!", "Colin", colinSprite),
			new ChatMessage("Wow, you ARE funny and handsome!", "Tommy", tommySprite),
			new ChatMessage("What happens if I give this a really long string? Does it wrap okay?", "Colin", colinSprite),
			new ChatQuery(
				"Do you like questions?",
				new ChatQueryOption[] {new ChatQueryOption("Yes", firstAction), new ChatQueryOption("No", secondAction)},
				"Tommy",
				tommySprite)
		};
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (chatMessageIndex < messages.Length) {
				chatHeadsAPI.showMessage (messages [chatMessageIndex]);
				chatMessageIndex++;
			} else {
				chatHeadsAPI.hide ();
			}
		}
	}
}

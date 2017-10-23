using System;
using UnityEngine;

public class ChatQueryOption  {

	private String label;
	private Action callback;

	public ChatQueryOption(String label, Action callback) {
		this.label = label;
		this.callback = callback;
	}

	public String getLabel() {
		return label;
	}

	public Action getCallback() {
		return callback;
	}
}

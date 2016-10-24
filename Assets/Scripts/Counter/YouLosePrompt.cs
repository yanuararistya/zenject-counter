using UnityEngine.UI;
using Zenject;

public class YouLosePrompt : ILoseHandler {

	public Text _counter;

	bool isDone;

	public YouLosePrompt (Text counter) {
		_counter = counter;

		Reset ();
	}

	public void Execute () {
		_counter.text = "YOU LOSE";
		isDone = true;
	}

	public bool IsDone () {
		return isDone;
	}

	public void Reset () {
		isDone = false;
	}
}

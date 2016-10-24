using UnityEngine;
using System.Collections;

public interface ILoseHandler {

	void Execute ();
	bool IsDone ();
	void Reset ();
}
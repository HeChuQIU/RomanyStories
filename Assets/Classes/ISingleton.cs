using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton<T> where T : class
{
	static T Instance { get; }
}

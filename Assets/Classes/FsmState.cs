using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
	[Serializable]
	public abstract class FsmState<TFsm> where TFsm : class
	{
		public abstract TFsm Fsm { get; protected set; }
		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract void OnFixedUpdate();
	}
}

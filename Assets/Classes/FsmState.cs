using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
	public interface IFsmState
	{
		string Name { get; set; }
		Action OnEnter { get; set; }
		Action OnExit { get; set; }
		Action OnFixedUpdate { get; set; }
	}

	[Serializable]
	public class FsmState:IFsmState
	{
		public string Name { get; set; }
		public Action OnEnter { get; set; }
		public Action OnExit { get; set; }
		public Action OnFixedUpdate { get; set; }
	}
}

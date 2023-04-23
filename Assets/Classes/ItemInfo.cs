namespace Assets.Classes
{
	public interface IItemInfo
	{
		string Id { get; set; }
		string Name { get; set; }
		int MaxStackSize { get;set; }
	}

	public struct ItemInfo : IItemInfo
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int MaxStackSize { get; set; }
	}
}

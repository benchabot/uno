#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Automation
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public   enum ExpandCollapseState 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		Collapsed,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		Expanded,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		PartiallyExpanded,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		LeafNode,
		#endif
	}
	#endif
}

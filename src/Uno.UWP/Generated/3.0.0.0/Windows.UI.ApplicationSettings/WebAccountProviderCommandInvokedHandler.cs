#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.ApplicationSettings
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	public delegate void WebAccountProviderCommandInvokedHandler(global::Windows.UI.ApplicationSettings.WebAccountProviderCommand @command);
	#endif
}

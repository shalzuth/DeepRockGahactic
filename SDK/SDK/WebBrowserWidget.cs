using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.UMGSDK;
namespace SDK.Script.WebBrowserWidgetSDK
{
    public class WebBrowser : Widget
    {
        public WebBrowser(ulong addr) : base(addr) { }
        public Object OnUrlChanged { get { return this[nameof(OnUrlChanged)]; } set { this[nameof(OnUrlChanged)] = value; } }
        public Object OnBeforePopup { get { return this[nameof(OnBeforePopup)]; } set { this[nameof(OnBeforePopup)] = value; } }
        public Object InitialURL { get { return this[nameof(InitialURL)]; } set { this[nameof(InitialURL)] = value; } }
        public bool bSupportsTransparency { get { return this[nameof(bSupportsTransparency)].Flag; } set { this[nameof(bSupportsTransparency)].Flag = value; } }
        public void OnUrlChanged__DelegateSignature(Object Text) { Invoke(nameof(OnUrlChanged__DelegateSignature), Text); }
        public void OnBeforePopup__DelegateSignature(Object URL, Object Frame) { Invoke(nameof(OnBeforePopup__DelegateSignature), URL, Frame); }
        public void LoadURL(Object NewURL) { Invoke(nameof(LoadURL), NewURL); }
        public void LoadString(Object Contents, Object DummyURL) { Invoke(nameof(LoadString), Contents, DummyURL); }
        public Object GetUrl() { return Invoke<Object>(nameof(GetUrl)); }
        public Object GetTitleText() { return Invoke<Object>(nameof(GetTitleText)); }
        public void ExecuteJavascript(Object ScriptText) { Invoke(nameof(ExecuteJavascript), ScriptText); }
    }
    public class WebBrowserAssetManager : Object
    {
        public WebBrowserAssetManager(ulong addr) : base(addr) { }
        public Object DefaultMaterial { get { return this[nameof(DefaultMaterial)]; } set { this[nameof(DefaultMaterial)] = value; } }
    }
}

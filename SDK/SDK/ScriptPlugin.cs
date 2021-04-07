using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.ScriptPluginSDK
{
    public class ScriptBlueprint : Blueprint
    {
        public ScriptBlueprint(ulong addr) : base(addr) { }
        public Array<byte> ByteCode { get { return new Array<byte>(this[nameof(ByteCode)].Address); } }
        public Object SourceCode { get { return this[nameof(SourceCode)]; } set { this[nameof(SourceCode)] = value; } }
    }
    public class ScriptBlueprintGeneratedClass : BlueprintGeneratedClass
    {
        public ScriptBlueprintGeneratedClass(ulong addr) : base(addr) { }
        public Array<byte> ByteCode { get { return new Array<byte>(this[nameof(ByteCode)].Address); } }
        public Object SourceCode { get { return this[nameof(SourceCode)]; } set { this[nameof(SourceCode)] = value; } }
        public Array<Property> ScriptProperties { get { return new Array<Property>(this[nameof(ScriptProperties)].Address); } }
    }
    public class ScriptContext : Object
    {
        public ScriptContext(ulong addr) : base(addr) { }
        public void CallScriptFunction(Object FunctionName) { Invoke(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptContextComponent : ActorComponent
    {
        public ScriptContextComponent(ulong addr) : base(addr) { }
        public void CallScriptFunction(Object FunctionName) { Invoke(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptPluginComponent : ActorComponent
    {
        public ScriptPluginComponent(ulong addr) : base(addr) { }
        public bool CallScriptFunction(Object FunctionName) { return Invoke<bool>(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptTestActor : Actor
    {
        public ScriptTestActor(ulong addr) : base(addr) { }
        public Object TestString { get { return this[nameof(TestString)]; } set { this[nameof(TestString)] = value; } }
        public float TestValue { get { return this[nameof(TestValue)].GetValue<float>(); } set { this[nameof(TestValue)].SetValue<float>(value); } }
        public bool TestBool { get { return this[nameof(TestBool)].Flag; } set { this[nameof(TestBool)].Flag = value; } }
        public float TestFunction(float InValue, float InFactor, bool bMultiply) { return Invoke<float>(nameof(TestFunction), InValue, InFactor, bMultiply); }
    }
}

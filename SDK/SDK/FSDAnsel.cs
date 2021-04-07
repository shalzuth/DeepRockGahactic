using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.FSDAnselSDK
{
    public class FSDAnselFunctionLibrary : BlueprintFunctionLibrary
    {
        public FSDAnselFunctionLibrary(ulong addr) : base(addr) { }
        public void StopPhotographySession(Object WorldContextObject) { Invoke(nameof(StopPhotographySession), WorldContextObject); }
        public void StartPhotographySession(Object WorldContextObject) { Invoke(nameof(StartPhotographySession), WorldContextObject); }
        public void SetUIControlVisibility(Object WorldContextObject, byte UIControlTarget, bool bIsVisible) { Invoke(nameof(SetUIControlVisibility), WorldContextObject, UIControlTarget, bIsVisible); }
        public void SetSettleFrames(int NumSettleFrames) { Invoke(nameof(SetSettleFrames), NumSettleFrames); }
        public void SetIsPhotographyAllowed(bool bIsPhotographyAllowed) { Invoke(nameof(SetIsPhotographyAllowed), bIsPhotographyAllowed); }
        public void SetCameraMovementSpeed(float TranslationSpeed) { Invoke(nameof(SetCameraMovementSpeed), TranslationSpeed); }
        public void SetCameraConstraintDistance(float MaxCameraDistance) { Invoke(nameof(SetCameraConstraintDistance), MaxCameraDistance); }
        public void SetCameraConstraintCameraSize(float CameraSize) { Invoke(nameof(SetCameraConstraintCameraSize), CameraSize); }
        public void SetAutoPostprocess(bool bShouldAutoPostprocess) { Invoke(nameof(SetAutoPostprocess), bShouldAutoPostprocess); }
        public void SetAutoPause(bool bShouldAutoPause) { Invoke(nameof(SetAutoPause), bShouldAutoPause); }
        public bool IsPhotographyAvailable() { return Invoke<bool>(nameof(IsPhotographyAvailable)); }
        public bool IsPhotographyAllowed() { return Invoke<bool>(nameof(IsPhotographyAllowed)); }
        public void ConstrainCameraByGeometry(Object WorldContextObject, Vector NewCameraLocation, Vector PreviousCameraLocation, Vector OriginalCameraLocation, Vector OutCameraLocation) { Invoke(nameof(ConstrainCameraByGeometry), WorldContextObject, NewCameraLocation, PreviousCameraLocation, OriginalCameraLocation, OutCameraLocation); }
        public void ConstrainCameraByDistance(Object WorldContextObject, Vector NewCameraLocation, Vector PreviousCameraLocation, Vector OriginalCameraLocation, Vector OutCameraLocation, float MaxDistance) { Invoke(nameof(ConstrainCameraByDistance), WorldContextObject, NewCameraLocation, PreviousCameraLocation, OriginalCameraLocation, OutCameraLocation, MaxDistance); }
    }
    public enum EUIControlEffectTarget : int
    {
        Bloom = 0,
        DepthOfField = 1,
        ChromaticAberration = 2,
        MotionBlur = 3,
        EUIControlEffectTarget_MAX = 4,
    }
}

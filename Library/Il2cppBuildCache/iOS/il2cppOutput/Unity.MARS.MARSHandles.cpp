#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


struct VirtActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2>
struct VirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct VirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>
struct Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F;
// System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>
struct Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5;
// System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>
struct Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824;
// System.Action`1<Unity.MARS.MARSHandles.ScalingUpdatedInfo>
struct Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144;
// System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>
struct Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8;
// System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>
struct Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA;
// System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>
struct Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1;
// System.Collections.Generic.Dictionary`2<System.Object,System.Object>
struct Dictionary_2_tBD1E3221EBD04CEBDA49B84779912E91F56B958D;
// System.Collections.Generic.Dictionary`2<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>
struct Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED;
// System.Collections.Generic.IEnumerable`1<Unity.MARS.MARSHandles.HandleBehaviour>
struct IEnumerable_1_t5F68D2374F73AB3A29202979CE8E6478E50FF63A;
// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_t52B1AC8D9E5E1ED28DF6C46A37C9A1B00B394F9D;
// System.Collections.Generic.IEqualityComparer`1<System.Type>
struct IEqualityComparer_1_t7EEC9B4006D6D425748908D52AA799197F29A165;
// System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>
struct IReadOnlyList_1_t7453370C5361E060CD390551EC47318B25EDE91A;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>
struct KeyCollection_t60EB21A42548AAE5F54281CBA13AD03274F6B039;
// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5;
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>
struct List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D;
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>
struct List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021;
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle>
struct List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5;
// System.Collections.Generic.List`1<UnityEngine.Renderer>
struct List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>
struct ValueCollection_t9D6CE8CA8B067159D2700E559CC8D34AB750D5C3;
// System.Collections.Generic.Dictionary`2/Entry<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>[]
struct EntryU5BU5D_t1A28E51C29DF0189206AF945F7C387DC125F2028;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642;
// Unity.MARS.MARSHandles.HandleBehaviour[]
struct HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221;
// Unity.MARS.MARSHandles.HandleContext[]
struct HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8;
// System.Int32[]
struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32;
// System.IntPtr[]
struct IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6;
// Unity.MARS.MARSHandles.InteractiveHandle[]
struct InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C;
// UnityEngine.Material[]
struct MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492;
// UnityEngine.Renderer[]
struct RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7;
// Unity.MARS.MARSHandles.RotatorHandle[]
struct RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A;
// Unity.MARS.MARSHandles.SliderHandleBase[]
struct SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971;
// System.Action
struct Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6;
// System.ArgumentNullException
struct ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB;
// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA;
// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71;
// UnityEngine.Behaviour
struct Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9;
// UnityEngine.Camera
struct Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C;
// UnityEngine.Component
struct Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684;
// Unity.MARS.MARSHandles.ComponentCache
struct ComponentCache_tA2472D14450BFDA2BCCDB41B3917D5C2142237E1;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288;
// Unity.MARS.MARSHandles.EditorHandleStateColors
struct EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725;
// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_t736B90E5A44AFAD4A8C4984092F6F12691FF549C;
// UnityEngine.GameObject
struct GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319;
// Unity.MARS.MARSHandles.HandleBehaviour
struct HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE;
// Unity.MARS.MARSHandles.HandleContext
struct HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B;
// Unity.MARS.MARSHandles.HandleStateColors
struct HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85;
// System.IAsyncResult
struct IAsyncResult_tC9F97BF36FCF122D29D3101D80642278297BF370;
// System.Collections.IDictionary
struct IDictionary_t99871C56B8EC2452AC5C4CF3831695E617B89D3A;
// Unity.MARS.MARSHandles.Picking.IPickingTarget
struct IPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB;
// Unity.MARS.MARSHandles.InteractiveHandle
struct InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F;
// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_tBB3A65EFBD4A5C11A2837FA9CF013450EC3A0011;
// UnityEngine.LineRenderer
struct LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967;
// Unity.MARS.MARSHandles.LineRendererConstraint
struct LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1;
// UnityEngine.Material
struct Material_t8927C00353A72755313F046D0CE85178AE8218EE;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A;
// UnityEngine.Object
struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A;
// Unity.MARS.MARSHandles.PositionHandle
struct PositionHandle_t507E61E6A8E839708379198222365B39213A4835;
// UnityEngine.Renderer
struct Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C;
// Unity.MARS.MARSHandles.RotationHandle
struct RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78;
// Unity.MARS.MARSHandles.RotatorHandle
struct RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB;
// Unity.MARS.MARSHandles.RuntimeHandleContext
struct RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F;
// Unity.MARS.MARSHandles.ScaleHandle
struct ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719;
// Unity.MARS.MARSHandles.ScaleWithCameraDistance
struct ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21;
// UnityEngine.Shader
struct Shader_tB2355DC4F3CAF20B2F1AB5AABBF37C3555FFBC39;
// Unity.MARS.MARSHandles.Slider1DHandle
struct Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30;
// Unity.MARS.MARSHandles.Slider2DHandle
struct Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06;
// Unity.MARS.MARSHandles.SliderHandleBase
struct SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A;
// System.String
struct String_t;
// UnityEngine.Transform
struct Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1;
// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;
// UnityEngine.Camera/CameraCallback
struct CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D;
// Unity.MARS.MARSHandles.HandleContext/InteractionState
struct InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2;
// Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0
struct U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61;

IL2CPP_EXTERN_C RuntimeClass* Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Material_t8927C00353A72755313F046D0CE85178AE8218EE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral2A7CB35E4614F3EDE8928AE07B4A3FB68E4CD11A;
IL2CPP_EXTERN_C String_t* _stringLiteral4B247C13053AB16D1668B60F2A407C881E8EEC64;
IL2CPP_EXTERN_C String_t* _stringLiteral6BF3D8705F4F5025D5392E7A9C1879B05AC6DA08;
IL2CPP_EXTERN_C String_t* _stringLiteral88B4B87ACB6CA3515F049E15D662A8C185893386;
IL2CPP_EXTERN_C String_t* _stringLiteralFFE3A1B73CD7FC81540FBBE737435B0A887629D5;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Component_GetComponent_TisLineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967_mD5BC9EADE1AA529A5299A4D8B020FB49663DAC3A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Component_GetComponent_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m436E5B0F17DDEF3CC61F77DEA82B1A92668AF019_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_mEDA9E9B930FC9C880167E6A35E5F7CAAEC864323_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_m48E109156D5ADB530A13B9DAB915F91DF854194A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_mE21E49F8B1BE64C87CBFACE1B4B0D702C501210F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m203CD6DEF51BD4293A08C00A7DD3340EC4163549_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m7090935F4B9051282BB0D6DE72B096073274DD33_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m1C905C3F07EA78F157C733364DA3A9D6EDC57904_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_mFA9DA346C8173FC7CD9C3D5A4FD14FC7FCBAA846_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponents_TisHandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE_m40A1BA6F7AFB140C4B32EADA3F965B1926F9AF9E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponents_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m28FCAD0BE737DA09091250839D36AF8A8D22E0C8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* HandleContext_CreateHandle_m9B4F0364872169F2131EE55027F3F10D88CC2102_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* HandleContext_DestroyHandle_m980740978281037E35AAF81AF977A3239F5A7881_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_AddRange_m10A04B53537D5AB1DC6243720AF3D18EB6BC7923_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m3DD76DE838FA83DF972E0486A296345EB3A7DDF3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m5CAB84213E397FBA644EA314B6F2C6B304D20BE0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m84BF7301FB1FDAB49751F01F230B99C4D240FB9F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mCB6E4FC5A548DA624CF4B18D0E6D83FB8FDE3845_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_m76B072C05663936EA6BFBCC57761E394E9E66ED0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Contains_mE508A129A7CB4DC89530674E7854B7F699BB486F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_m2C6D9F87F1CB97F7FD4AC838538016B718EA19C7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_mE260B4092AF4305011540A431D02BC928E2B3997_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Remove_m4A5249E88B4FF796C1E6409C894BD55AE0A8F3D9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Remove_m664733BB2DD16FD00F2503C7A6569448FF112AD1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Remove_m66C2969804F6C58F4E6EF1949409DD9D83783A74_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Remove_mD36BF07C31C1DF947856EFECE89BAF4D6A24DEB7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m2E5CD7DAF88452A4E392FE590162D47B2AE87FBF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m4AD4610A14E65261162EDC2D813C7F126F1BDD9F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m4B08F7BE66CF6C1E0652CD16A2413BE7D75A5B40_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m7774C10070F49CBF0F80ADC0E948659B630DDD48_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m859B0EE8491FDDEB1A3F7115D334B863E025BBC8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Object_Instantiate_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m26431AC51B9B7A43FBABD10B4923B72B0C578F33_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PositionHandle_OnTranslationBegun_m04ADE23392A6C566E59604ACD9B5B17B466D0CFA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PositionHandle_OnTranslationEnded_m7688135C8CFA37DD8C1781D86F7E249CBE973EEF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PositionHandle_OnTranslationUpdated_m7A815858FA04DBAD217D24549CE70F7F65563265_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Resources_Load_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m2A4C89C1E5F65890D408978197DB125739C6000C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* RotationHandle_OnRotationBegun_m4DA578F6E63C5E92639DD91825F3BE32668F3E2E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* RotationHandle_OnRotationEnded_mADA3A5EADD676E2550EAAC134EDBA41DA6687F2E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* RotationHandle_OnRotationUpdated_m51718E7169CD232FF57908ECA103AA7BF34E13A2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__0_mFE947AF56949443180513A6BD887A1C279EBB3E4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__1_mB4404C47AE65E376D9C7C6064DDBC49A70EE2146_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__2_mBFF2C9E8DA52B885E63B152B581635F4FE9B3EAB_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492;
struct RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A;
struct SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tBFF4BADE973EC7176F6C35FB1DE69F1A72999BDE 
{
public:

public:
};


// System.Object


// System.Collections.Generic.Dictionary`2<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>
struct Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ___buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_t1A28E51C29DF0189206AF945F7C387DC125F2028* ___entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::count
	int32_t ___count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::version
	int32_t ___version_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::freeList
	int32_t ___freeList_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::freeCount
	int32_t ___freeCount_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::comparer
	RuntimeObject* ___comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::keys
	KeyCollection_t60EB21A42548AAE5F54281CBA13AD03274F6B039 * ___keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_t9D6CE8CA8B067159D2700E559CC8D34AB750D5C3 * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___buckets_0)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___buckets_0), (void*)value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___entries_1)); }
	inline EntryU5BU5D_t1A28E51C29DF0189206AF945F7C387DC125F2028* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_t1A28E51C29DF0189206AF945F7C387DC125F2028** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_t1A28E51C29DF0189206AF945F7C387DC125F2028* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___entries_1), (void*)value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___comparer_6), (void*)value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___keys_7)); }
	inline KeyCollection_t60EB21A42548AAE5F54281CBA13AD03274F6B039 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t60EB21A42548AAE5F54281CBA13AD03274F6B039 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t60EB21A42548AAE5F54281CBA13AD03274F6B039 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___keys_7), (void*)value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ___values_8)); }
	inline ValueCollection_t9D6CE8CA8B067159D2700E559CC8D34AB750D5C3 * get_values_8() const { return ___values_8; }
	inline ValueCollection_t9D6CE8CA8B067159D2700E559CC8D34AB750D5C3 ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_t9D6CE8CA8B067159D2700E559CC8D34AB750D5C3 * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___values_8), (void*)value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED, ____syncRoot_9)); }
	inline RuntimeObject * get__syncRoot_9() const { return ____syncRoot_9; }
	inline RuntimeObject ** get_address_of__syncRoot_9() { return &____syncRoot_9; }
	inline void set__syncRoot_9(RuntimeObject * value)
	{
		____syncRoot_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_9), (void*)value);
	}
};


// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5, ____items_1)); }
	inline GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* get__items_1() const { return ____items_1; }
	inline GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5_StaticFields, ____emptyArray_5)); }
	inline GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* get__emptyArray_5() const { return ____emptyArray_5; }
	inline GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(GameObjectU5BU5D_tA88FC1A1FC9D4D73D0B3984D4B0ECE88F4C47642* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>
struct List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D, ____items_1)); }
	inline HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* get__items_1() const { return ____items_1; }
	inline HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_StaticFields, ____emptyArray_5)); }
	inline HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* get__emptyArray_5() const { return ____emptyArray_5; }
	inline HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(HandleBehaviourU5BU5D_t7A996F9E2BC88E775D81AEE0A0A6CEEB705B4221* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>
struct List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021, ____items_1)); }
	inline HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* get__items_1() const { return ____items_1; }
	inline HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021_StaticFields, ____emptyArray_5)); }
	inline HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* get__emptyArray_5() const { return ____emptyArray_5; }
	inline HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(HandleContextU5BU5D_tB2953EC15919DDC6C4CC6873643A881CA88C1FF8* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle>
struct List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331, ____items_1)); }
	inline InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* get__items_1() const { return ____items_1; }
	inline InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331_StaticFields, ____emptyArray_5)); }
	inline InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* get__emptyArray_5() const { return ____emptyArray_5; }
	inline InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(InteractiveHandleU5BU5D_t0DA36499467395FAB2BD2E5C19EF947AFE7FC29C* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<UnityEngine.Renderer>
struct List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE, ____items_1)); }
	inline RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* get__items_1() const { return ____items_1; }
	inline RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE_StaticFields, ____emptyArray_5)); }
	inline RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* get__emptyArray_5() const { return ____emptyArray_5; }
	inline RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(RendererU5BU5D_tE2D3C4350893C593CA40DE876B9F2F0EBBEC49B7* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};

struct Il2CppArrayBounds;

// System.Array


// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.MARSHandles.ComponentCache
struct ComponentCache_tA2472D14450BFDA2BCCDB41B3917D5C2142237E1  : public RuntimeObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection> Unity.MARS.MARSHandles.ComponentCache::m_Collections
	Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED * ___m_Collections_0;
	// UnityEngine.GameObject Unity.MARS.MARSHandles.ComponentCache::m_Root
	GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___m_Root_1;

public:
	inline static int32_t get_offset_of_m_Collections_0() { return static_cast<int32_t>(offsetof(ComponentCache_tA2472D14450BFDA2BCCDB41B3917D5C2142237E1, ___m_Collections_0)); }
	inline Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED * get_m_Collections_0() const { return ___m_Collections_0; }
	inline Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED ** get_address_of_m_Collections_0() { return &___m_Collections_0; }
	inline void set_m_Collections_0(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED * value)
	{
		___m_Collections_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Collections_0), (void*)value);
	}

	inline static int32_t get_offset_of_m_Root_1() { return static_cast<int32_t>(offsetof(ComponentCache_tA2472D14450BFDA2BCCDB41B3917D5C2142237E1, ___m_Root_1)); }
	inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * get_m_Root_1() const { return ___m_Root_1; }
	inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 ** get_address_of_m_Root_1() { return &___m_Root_1; }
	inline void set_m_Root_1(GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * value)
	{
		___m_Root_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Root_1), (void*)value);
	}
};


// Unity.MARS.MARSHandles.DefaultHandles
struct DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357  : public RuntimeObject
{
public:

public:
};

struct DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_StaticFields
{
public:
	// UnityEngine.GameObject Unity.MARS.MARSHandles.DefaultHandles::s_PositionPrefab
	GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___s_PositionPrefab_0;

public:
	inline static int32_t get_offset_of_s_PositionPrefab_0() { return static_cast<int32_t>(offsetof(DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_StaticFields, ___s_PositionPrefab_0)); }
	inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * get_s_PositionPrefab_0() const { return ___s_PositionPrefab_0; }
	inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 ** get_address_of_s_PositionPrefab_0() { return &___s_PositionPrefab_0; }
	inline void set_s_PositionPrefab_0(GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * value)
	{
		___s_PositionPrefab_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_PositionPrefab_0), (void*)value);
	}
};


// Unity.MARS.MARSHandles.HandleContext
struct HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<UnityEngine.GameObject> Unity.MARS.MARSHandles.HandleContext::m_RawHandles
	List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * ___m_RawHandles_3;
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle> Unity.MARS.MARSHandles.HandleContext::m_InteractiveHandles
	List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * ___m_InteractiveHandles_4;
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext::m_HandleBehaviours
	List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___m_HandleBehaviours_5;
	// UnityEngine.Camera Unity.MARS.MARSHandles.HandleContext::m_Camera
	Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___m_Camera_6;

public:
	inline static int32_t get_offset_of_m_RawHandles_3() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B, ___m_RawHandles_3)); }
	inline List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * get_m_RawHandles_3() const { return ___m_RawHandles_3; }
	inline List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 ** get_address_of_m_RawHandles_3() { return &___m_RawHandles_3; }
	inline void set_m_RawHandles_3(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * value)
	{
		___m_RawHandles_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_RawHandles_3), (void*)value);
	}

	inline static int32_t get_offset_of_m_InteractiveHandles_4() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B, ___m_InteractiveHandles_4)); }
	inline List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * get_m_InteractiveHandles_4() const { return ___m_InteractiveHandles_4; }
	inline List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 ** get_address_of_m_InteractiveHandles_4() { return &___m_InteractiveHandles_4; }
	inline void set_m_InteractiveHandles_4(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * value)
	{
		___m_InteractiveHandles_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_InteractiveHandles_4), (void*)value);
	}

	inline static int32_t get_offset_of_m_HandleBehaviours_5() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B, ___m_HandleBehaviours_5)); }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * get_m_HandleBehaviours_5() const { return ___m_HandleBehaviours_5; }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D ** get_address_of_m_HandleBehaviours_5() { return &___m_HandleBehaviours_5; }
	inline void set_m_HandleBehaviours_5(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * value)
	{
		___m_HandleBehaviours_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_HandleBehaviours_5), (void*)value);
	}

	inline static int32_t get_offset_of_m_Camera_6() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B, ___m_Camera_6)); }
	inline Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * get_m_Camera_6() const { return ___m_Camera_6; }
	inline Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C ** get_address_of_m_Camera_6() { return &___m_Camera_6; }
	inline void set_m_Camera_6(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * value)
	{
		___m_Camera_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Camera_6), (void*)value);
	}
};

struct HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields
{
public:
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext> Unity.MARS.MARSHandles.HandleContext::s_Contexts
	List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * ___s_Contexts_0;
	// System.Collections.Generic.List`1<UnityEngine.Renderer> Unity.MARS.MARSHandles.HandleContext::s_RendererBuffer
	List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * ___s_RendererBuffer_1;
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext::s_BehaviourQueryBuffer
	List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___s_BehaviourQueryBuffer_2;

public:
	inline static int32_t get_offset_of_s_Contexts_0() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields, ___s_Contexts_0)); }
	inline List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * get_s_Contexts_0() const { return ___s_Contexts_0; }
	inline List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 ** get_address_of_s_Contexts_0() { return &___s_Contexts_0; }
	inline void set_s_Contexts_0(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * value)
	{
		___s_Contexts_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_Contexts_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_RendererBuffer_1() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields, ___s_RendererBuffer_1)); }
	inline List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * get_s_RendererBuffer_1() const { return ___s_RendererBuffer_1; }
	inline List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE ** get_address_of_s_RendererBuffer_1() { return &___s_RendererBuffer_1; }
	inline void set_s_RendererBuffer_1(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * value)
	{
		___s_RendererBuffer_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_RendererBuffer_1), (void*)value);
	}

	inline static int32_t get_offset_of_s_BehaviourQueryBuffer_2() { return static_cast<int32_t>(offsetof(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields, ___s_BehaviourQueryBuffer_2)); }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * get_s_BehaviourQueryBuffer_2() const { return ___s_BehaviourQueryBuffer_2; }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D ** get_address_of_s_BehaviourQueryBuffer_2() { return &___s_BehaviourQueryBuffer_2; }
	inline void set_s_BehaviourQueryBuffer_2(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * value)
	{
		___s_BehaviourQueryBuffer_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_BehaviourQueryBuffer_2), (void*)value);
	}
};


// Unity.MARS.MARSHandles.HandleUtility
struct HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47  : public RuntimeObject
{
public:

public:
};

struct HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_StaticFields
{
public:
	// UnityEngine.Material Unity.MARS.MARSHandles.HandleUtility::defaultMaterial
	Material_t8927C00353A72755313F046D0CE85178AE8218EE * ___defaultMaterial_0;

public:
	inline static int32_t get_offset_of_defaultMaterial_0() { return static_cast<int32_t>(offsetof(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_StaticFields, ___defaultMaterial_0)); }
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE * get_defaultMaterial_0() const { return ___defaultMaterial_0; }
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE ** get_address_of_defaultMaterial_0() { return &___defaultMaterial_0; }
	inline void set_defaultMaterial_0(Material_t8927C00353A72755313F046D0CE85178AE8218EE * value)
	{
		___defaultMaterial_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___defaultMaterial_0), (void*)value);
	}
};


// System.String
struct String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_5), (void*)value);
	}
};


// System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0
struct U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61  : public RuntimeObject
{
public:
	// Unity.MARS.MARSHandles.SliderHandleBase Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::slider
	SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider_0;
	// Unity.MARS.MARSHandles.ScaleHandle Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::<>4__this
	ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * ___U3CU3E4__this_1;

public:
	inline static int32_t get_offset_of_slider_0() { return static_cast<int32_t>(offsetof(U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61, ___slider_0)); }
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * get_slider_0() const { return ___slider_0; }
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A ** get_address_of_slider_0() { return &___slider_0; }
	inline void set_slider_0(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * value)
	{
		___slider_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___slider_0), (void*)value);
	}

	inline static int32_t get_offset_of_U3CU3E4__this_1() { return static_cast<int32_t>(offsetof(U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61, ___U3CU3E4__this_1)); }
	inline ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * get_U3CU3E4__this_1() const { return ___U3CU3E4__this_1; }
	inline ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 ** get_address_of_U3CU3E4__this_1() { return &___U3CU3E4__this_1; }
	inline void set_U3CU3E4__this_1(ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * value)
	{
		___U3CU3E4__this_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CU3E4__this_1), (void*)value);
	}
};


// System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleBehaviour>
struct Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::list
	List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840, ___list_0)); }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * get_list_0() const { return ___list_0; }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840, ___current_3)); }
	inline HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * get_current_3() const { return ___current_3; }
	inline HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___current_3), (void*)value);
	}
};


// System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleContext>
struct Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::list
	List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * ___list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68, ___list_0)); }
	inline List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * get_list_0() const { return ___list_0; }
	inline List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68, ___current_3)); }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * get_current_3() const { return ___current_3; }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___current_3), (void*)value);
	}
};


// System.Collections.Generic.List`1/Enumerator<System.Object>
struct Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::list
	List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * ___list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	RuntimeObject * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6, ___list_0)); }
	inline List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * get_list_0() const { return ___list_0; }
	inline List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6, ___current_3)); }
	inline RuntimeObject * get_current_3() const { return ___current_3; }
	inline RuntimeObject ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(RuntimeObject * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___current_3), (void*)value);
	}
};


// System.Collections.Generic.List`1/Enumerator<UnityEngine.Renderer>
struct Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::list
	List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * ___list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72, ___list_0)); }
	inline List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * get_list_0() const { return ___list_0; }
	inline List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72, ___current_3)); }
	inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * get_current_3() const { return ___current_3; }
	inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___current_3), (void*)value);
	}
};


// System.Boolean
struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrueString_5), (void*)value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FalseString_6), (void*)value);
	}
};


// UnityEngine.Color
struct Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 
{
public:
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;

public:
	inline static int32_t get_offset_of_r_0() { return static_cast<int32_t>(offsetof(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659, ___r_0)); }
	inline float get_r_0() const { return ___r_0; }
	inline float* get_address_of_r_0() { return &___r_0; }
	inline void set_r_0(float value)
	{
		___r_0 = value;
	}

	inline static int32_t get_offset_of_g_1() { return static_cast<int32_t>(offsetof(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659, ___g_1)); }
	inline float get_g_1() const { return ___g_1; }
	inline float* get_address_of_g_1() { return &___g_1; }
	inline void set_g_1(float value)
	{
		___g_1 = value;
	}

	inline static int32_t get_offset_of_b_2() { return static_cast<int32_t>(offsetof(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659, ___b_2)); }
	inline float get_b_2() const { return ___b_2; }
	inline float* get_address_of_b_2() { return &___b_2; }
	inline void set_b_2(float value)
	{
		___b_2 = value;
	}

	inline static int32_t get_offset_of_a_3() { return static_cast<int32_t>(offsetof(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659, ___a_3)); }
	inline float get_a_3() const { return ___a_3; }
	inline float* get_address_of_a_3() { return &___a_3; }
	inline void set_a_3(float value)
	{
		___a_3 = value;
	}
};


// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_t736B90E5A44AFAD4A8C4984092F6F12691FF549C  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA  : public ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52
{
public:

public:
};

struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_com
{
};

// Unity.MARS.MARSHandles.HoverBeginInfo
struct HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9 
{
public:
	union
	{
		struct
		{
		};
		uint8_t HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9__padding[1];
	};

public:
};


// Unity.MARS.MARSHandles.HoverEndInfo
struct HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8 
{
public:
	union
	{
		struct
		{
		};
		uint8_t HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8__padding[1];
	};

public:
};


// Unity.MARS.MARSHandles.HoverUpdateInfo
struct HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40 
{
public:
	union
	{
		struct
		{
		};
		uint8_t HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40__padding[1];
	};

public:
};


// System.Int32
struct Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};


// System.IntPtr
struct IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_tBB3A65EFBD4A5C11A2837FA9CF013450EC3A0011  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// UnityEngine.Matrix4x4
struct Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 
{
public:
	// System.Single UnityEngine.Matrix4x4::m00
	float ___m00_0;
	// System.Single UnityEngine.Matrix4x4::m10
	float ___m10_1;
	// System.Single UnityEngine.Matrix4x4::m20
	float ___m20_2;
	// System.Single UnityEngine.Matrix4x4::m30
	float ___m30_3;
	// System.Single UnityEngine.Matrix4x4::m01
	float ___m01_4;
	// System.Single UnityEngine.Matrix4x4::m11
	float ___m11_5;
	// System.Single UnityEngine.Matrix4x4::m21
	float ___m21_6;
	// System.Single UnityEngine.Matrix4x4::m31
	float ___m31_7;
	// System.Single UnityEngine.Matrix4x4::m02
	float ___m02_8;
	// System.Single UnityEngine.Matrix4x4::m12
	float ___m12_9;
	// System.Single UnityEngine.Matrix4x4::m22
	float ___m22_10;
	// System.Single UnityEngine.Matrix4x4::m32
	float ___m32_11;
	// System.Single UnityEngine.Matrix4x4::m03
	float ___m03_12;
	// System.Single UnityEngine.Matrix4x4::m13
	float ___m13_13;
	// System.Single UnityEngine.Matrix4x4::m23
	float ___m23_14;
	// System.Single UnityEngine.Matrix4x4::m33
	float ___m33_15;

public:
	inline static int32_t get_offset_of_m00_0() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m00_0)); }
	inline float get_m00_0() const { return ___m00_0; }
	inline float* get_address_of_m00_0() { return &___m00_0; }
	inline void set_m00_0(float value)
	{
		___m00_0 = value;
	}

	inline static int32_t get_offset_of_m10_1() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m10_1)); }
	inline float get_m10_1() const { return ___m10_1; }
	inline float* get_address_of_m10_1() { return &___m10_1; }
	inline void set_m10_1(float value)
	{
		___m10_1 = value;
	}

	inline static int32_t get_offset_of_m20_2() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m20_2)); }
	inline float get_m20_2() const { return ___m20_2; }
	inline float* get_address_of_m20_2() { return &___m20_2; }
	inline void set_m20_2(float value)
	{
		___m20_2 = value;
	}

	inline static int32_t get_offset_of_m30_3() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m30_3)); }
	inline float get_m30_3() const { return ___m30_3; }
	inline float* get_address_of_m30_3() { return &___m30_3; }
	inline void set_m30_3(float value)
	{
		___m30_3 = value;
	}

	inline static int32_t get_offset_of_m01_4() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m01_4)); }
	inline float get_m01_4() const { return ___m01_4; }
	inline float* get_address_of_m01_4() { return &___m01_4; }
	inline void set_m01_4(float value)
	{
		___m01_4 = value;
	}

	inline static int32_t get_offset_of_m11_5() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m11_5)); }
	inline float get_m11_5() const { return ___m11_5; }
	inline float* get_address_of_m11_5() { return &___m11_5; }
	inline void set_m11_5(float value)
	{
		___m11_5 = value;
	}

	inline static int32_t get_offset_of_m21_6() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m21_6)); }
	inline float get_m21_6() const { return ___m21_6; }
	inline float* get_address_of_m21_6() { return &___m21_6; }
	inline void set_m21_6(float value)
	{
		___m21_6 = value;
	}

	inline static int32_t get_offset_of_m31_7() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m31_7)); }
	inline float get_m31_7() const { return ___m31_7; }
	inline float* get_address_of_m31_7() { return &___m31_7; }
	inline void set_m31_7(float value)
	{
		___m31_7 = value;
	}

	inline static int32_t get_offset_of_m02_8() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m02_8)); }
	inline float get_m02_8() const { return ___m02_8; }
	inline float* get_address_of_m02_8() { return &___m02_8; }
	inline void set_m02_8(float value)
	{
		___m02_8 = value;
	}

	inline static int32_t get_offset_of_m12_9() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m12_9)); }
	inline float get_m12_9() const { return ___m12_9; }
	inline float* get_address_of_m12_9() { return &___m12_9; }
	inline void set_m12_9(float value)
	{
		___m12_9 = value;
	}

	inline static int32_t get_offset_of_m22_10() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m22_10)); }
	inline float get_m22_10() const { return ___m22_10; }
	inline float* get_address_of_m22_10() { return &___m22_10; }
	inline void set_m22_10(float value)
	{
		___m22_10 = value;
	}

	inline static int32_t get_offset_of_m32_11() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m32_11)); }
	inline float get_m32_11() const { return ___m32_11; }
	inline float* get_address_of_m32_11() { return &___m32_11; }
	inline void set_m32_11(float value)
	{
		___m32_11 = value;
	}

	inline static int32_t get_offset_of_m03_12() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m03_12)); }
	inline float get_m03_12() const { return ___m03_12; }
	inline float* get_address_of_m03_12() { return &___m03_12; }
	inline void set_m03_12(float value)
	{
		___m03_12 = value;
	}

	inline static int32_t get_offset_of_m13_13() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m13_13)); }
	inline float get_m13_13() const { return ___m13_13; }
	inline float* get_address_of_m13_13() { return &___m13_13; }
	inline void set_m13_13(float value)
	{
		___m13_13 = value;
	}

	inline static int32_t get_offset_of_m23_14() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m23_14)); }
	inline float get_m23_14() const { return ___m23_14; }
	inline float* get_address_of_m23_14() { return &___m23_14; }
	inline void set_m23_14(float value)
	{
		___m23_14 = value;
	}

	inline static int32_t get_offset_of_m33_15() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461, ___m33_15)); }
	inline float get_m33_15() const { return ___m33_15; }
	inline float* get_address_of_m33_15() { return &___m33_15; }
	inline void set_m33_15(float value)
	{
		___m33_15 = value;
	}
};

struct Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461_StaticFields
{
public:
	// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::zeroMatrix
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___zeroMatrix_16;
	// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::identityMatrix
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___identityMatrix_17;

public:
	inline static int32_t get_offset_of_zeroMatrix_16() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461_StaticFields, ___zeroMatrix_16)); }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  get_zeroMatrix_16() const { return ___zeroMatrix_16; }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * get_address_of_zeroMatrix_16() { return &___zeroMatrix_16; }
	inline void set_zeroMatrix_16(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  value)
	{
		___zeroMatrix_16 = value;
	}

	inline static int32_t get_offset_of_identityMatrix_17() { return static_cast<int32_t>(offsetof(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461_StaticFields, ___identityMatrix_17)); }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  get_identityMatrix_17() const { return ___identityMatrix_17; }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * get_address_of_identityMatrix_17() { return &___identityMatrix_17; }
	inline void set_identityMatrix_17(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  value)
	{
		___identityMatrix_17 = value;
	}
};


// UnityEngine.Quaternion
struct Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4 
{
public:
	// System.Single UnityEngine.Quaternion::x
	float ___x_0;
	// System.Single UnityEngine.Quaternion::y
	float ___y_1;
	// System.Single UnityEngine.Quaternion::z
	float ___z_2;
	// System.Single UnityEngine.Quaternion::w
	float ___w_3;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}

	inline static int32_t get_offset_of_z_2() { return static_cast<int32_t>(offsetof(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4, ___z_2)); }
	inline float get_z_2() const { return ___z_2; }
	inline float* get_address_of_z_2() { return &___z_2; }
	inline void set_z_2(float value)
	{
		___z_2 = value;
	}

	inline static int32_t get_offset_of_w_3() { return static_cast<int32_t>(offsetof(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4, ___w_3)); }
	inline float get_w_3() const { return ___w_3; }
	inline float* get_address_of_w_3() { return &___w_3; }
	inline void set_w_3(float value)
	{
		___w_3 = value;
	}
};

struct Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4_StaticFields
{
public:
	// UnityEngine.Quaternion UnityEngine.Quaternion::identityQuaternion
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___identityQuaternion_4;

public:
	inline static int32_t get_offset_of_identityQuaternion_4() { return static_cast<int32_t>(offsetof(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4_StaticFields, ___identityQuaternion_4)); }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  get_identityQuaternion_4() const { return ___identityQuaternion_4; }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4 * get_address_of_identityQuaternion_4() { return &___identityQuaternion_4; }
	inline void set_identityQuaternion_4(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  value)
	{
		___identityQuaternion_4 = value;
	}
};


// Unity.MARS.MARSHandles.RuntimeHandleContext
struct RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37  : public HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B
{
public:

public:
};


// System.Single
struct Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};


// UnityEngine.Vector2
struct Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 
{
public:
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}
};

struct Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields
{
public:
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___negativeInfinityVector_9;

public:
	inline static int32_t get_offset_of_zeroVector_2() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___zeroVector_2)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_zeroVector_2() const { return ___zeroVector_2; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_zeroVector_2() { return &___zeroVector_2; }
	inline void set_zeroVector_2(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___zeroVector_2 = value;
	}

	inline static int32_t get_offset_of_oneVector_3() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___oneVector_3)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_oneVector_3() const { return ___oneVector_3; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_oneVector_3() { return &___oneVector_3; }
	inline void set_oneVector_3(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___oneVector_3 = value;
	}

	inline static int32_t get_offset_of_upVector_4() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___upVector_4)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_upVector_4() const { return ___upVector_4; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_upVector_4() { return &___upVector_4; }
	inline void set_upVector_4(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___upVector_4 = value;
	}

	inline static int32_t get_offset_of_downVector_5() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___downVector_5)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_downVector_5() const { return ___downVector_5; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_downVector_5() { return &___downVector_5; }
	inline void set_downVector_5(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___downVector_5 = value;
	}

	inline static int32_t get_offset_of_leftVector_6() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___leftVector_6)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_leftVector_6() const { return ___leftVector_6; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_leftVector_6() { return &___leftVector_6; }
	inline void set_leftVector_6(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___leftVector_6 = value;
	}

	inline static int32_t get_offset_of_rightVector_7() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___rightVector_7)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_rightVector_7() const { return ___rightVector_7; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_rightVector_7() { return &___rightVector_7; }
	inline void set_rightVector_7(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___rightVector_7 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_8() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___positiveInfinityVector_8)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_positiveInfinityVector_8() const { return ___positiveInfinityVector_8; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_positiveInfinityVector_8() { return &___positiveInfinityVector_8; }
	inline void set_positiveInfinityVector_8(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___positiveInfinityVector_8 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_9() { return static_cast<int32_t>(offsetof(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_StaticFields, ___negativeInfinityVector_9)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_negativeInfinityVector_9() const { return ___negativeInfinityVector_9; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_negativeInfinityVector_9() { return &___negativeInfinityVector_9; }
	inline void set_negativeInfinityVector_9(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___negativeInfinityVector_9 = value;
	}
};


// UnityEngine.Vector3
struct Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;

public:
	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E, ___x_2)); }
	inline float get_x_2() const { return ___x_2; }
	inline float* get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(float value)
	{
		___x_2 = value;
	}

	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E, ___y_3)); }
	inline float get_y_3() const { return ___y_3; }
	inline float* get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(float value)
	{
		___y_3 = value;
	}

	inline static int32_t get_offset_of_z_4() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E, ___z_4)); }
	inline float get_z_4() const { return ___z_4; }
	inline float* get_address_of_z_4() { return &___z_4; }
	inline void set_z_4(float value)
	{
		___z_4 = value;
	}
};

struct Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___negativeInfinityVector_14;

public:
	inline static int32_t get_offset_of_zeroVector_5() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___zeroVector_5)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_zeroVector_5() const { return ___zeroVector_5; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_zeroVector_5() { return &___zeroVector_5; }
	inline void set_zeroVector_5(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___zeroVector_5 = value;
	}

	inline static int32_t get_offset_of_oneVector_6() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___oneVector_6)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_oneVector_6() const { return ___oneVector_6; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_oneVector_6() { return &___oneVector_6; }
	inline void set_oneVector_6(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___oneVector_6 = value;
	}

	inline static int32_t get_offset_of_upVector_7() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___upVector_7)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_upVector_7() const { return ___upVector_7; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_upVector_7() { return &___upVector_7; }
	inline void set_upVector_7(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___upVector_7 = value;
	}

	inline static int32_t get_offset_of_downVector_8() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___downVector_8)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_downVector_8() const { return ___downVector_8; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_downVector_8() { return &___downVector_8; }
	inline void set_downVector_8(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___downVector_8 = value;
	}

	inline static int32_t get_offset_of_leftVector_9() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___leftVector_9)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_leftVector_9() const { return ___leftVector_9; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_leftVector_9() { return &___leftVector_9; }
	inline void set_leftVector_9(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___leftVector_9 = value;
	}

	inline static int32_t get_offset_of_rightVector_10() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___rightVector_10)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_rightVector_10() const { return ___rightVector_10; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_rightVector_10() { return &___rightVector_10; }
	inline void set_rightVector_10(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___rightVector_10 = value;
	}

	inline static int32_t get_offset_of_forwardVector_11() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___forwardVector_11)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_forwardVector_11() const { return ___forwardVector_11; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_forwardVector_11() { return &___forwardVector_11; }
	inline void set_forwardVector_11(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___forwardVector_11 = value;
	}

	inline static int32_t get_offset_of_backVector_12() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___backVector_12)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_backVector_12() const { return ___backVector_12; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_backVector_12() { return &___backVector_12; }
	inline void set_backVector_12(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___backVector_12 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___positiveInfinityVector_13)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_positiveInfinityVector_13() const { return ___positiveInfinityVector_13; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_positiveInfinityVector_13() { return &___positiveInfinityVector_13; }
	inline void set_positiveInfinityVector_13(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___positiveInfinityVector_13 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_14() { return static_cast<int32_t>(offsetof(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_StaticFields, ___negativeInfinityVector_14)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_negativeInfinityVector_14() const { return ___negativeInfinityVector_14; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_negativeInfinityVector_14() { return &___negativeInfinityVector_14; }
	inline void set_negativeInfinityVector_14(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___negativeInfinityVector_14 = value;
	}
};


// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5__padding[1];
	};

public:
};


// Unity.MARS.MARSHandles.DefaultHandle
struct DefaultHandle_t5B6257EB29CCA7B7BD72D6DDBEFB2845CA0371C1 
{
public:
	// System.Int32 Unity.MARS.MARSHandles.DefaultHandle::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DefaultHandle_t5B6257EB29CCA7B7BD72D6DDBEFB2845CA0371C1, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Delegate
struct Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_target_2), (void*)value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___method_info_7), (void*)value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___original_method_info_8), (void*)value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * get_data_9() const { return ___data_9; }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___data_9), (void*)value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};

// Unity.MARS.MARSHandles.DragTranslation
struct DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA 
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::<initialPosition>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CinitialPositionU3Ek__BackingField_0;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::<currentPosition>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CcurrentPositionU3Ek__BackingField_1;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::<delta>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CdeltaU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CinitialPositionU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA, ___U3CinitialPositionU3Ek__BackingField_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CinitialPositionU3Ek__BackingField_0() const { return ___U3CinitialPositionU3Ek__BackingField_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CinitialPositionU3Ek__BackingField_0() { return &___U3CinitialPositionU3Ek__BackingField_0; }
	inline void set_U3CinitialPositionU3Ek__BackingField_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CinitialPositionU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CcurrentPositionU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA, ___U3CcurrentPositionU3Ek__BackingField_1)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CcurrentPositionU3Ek__BackingField_1() const { return ___U3CcurrentPositionU3Ek__BackingField_1; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CcurrentPositionU3Ek__BackingField_1() { return &___U3CcurrentPositionU3Ek__BackingField_1; }
	inline void set_U3CcurrentPositionU3Ek__BackingField_1(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CcurrentPositionU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CdeltaU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA, ___U3CdeltaU3Ek__BackingField_2)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CdeltaU3Ek__BackingField_2() const { return ___U3CdeltaU3Ek__BackingField_2; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CdeltaU3Ek__BackingField_2() { return &___U3CdeltaU3Ek__BackingField_2; }
	inline void set_U3CdeltaU3Ek__BackingField_2(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CdeltaU3Ek__BackingField_2 = value;
	}
};


// System.Exception
struct Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t * ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject * ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject * ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* ___native_trace_ips_15;

public:
	inline static int32_t get_offset_of__className_1() { return static_cast<int32_t>(offsetof(Exception_t, ____className_1)); }
	inline String_t* get__className_1() const { return ____className_1; }
	inline String_t** get_address_of__className_1() { return &____className_1; }
	inline void set__className_1(String_t* value)
	{
		____className_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____className_1), (void*)value);
	}

	inline static int32_t get_offset_of__message_2() { return static_cast<int32_t>(offsetof(Exception_t, ____message_2)); }
	inline String_t* get__message_2() const { return ____message_2; }
	inline String_t** get_address_of__message_2() { return &____message_2; }
	inline void set__message_2(String_t* value)
	{
		____message_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____message_2), (void*)value);
	}

	inline static int32_t get_offset_of__data_3() { return static_cast<int32_t>(offsetof(Exception_t, ____data_3)); }
	inline RuntimeObject* get__data_3() const { return ____data_3; }
	inline RuntimeObject** get_address_of__data_3() { return &____data_3; }
	inline void set__data_3(RuntimeObject* value)
	{
		____data_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____data_3), (void*)value);
	}

	inline static int32_t get_offset_of__innerException_4() { return static_cast<int32_t>(offsetof(Exception_t, ____innerException_4)); }
	inline Exception_t * get__innerException_4() const { return ____innerException_4; }
	inline Exception_t ** get_address_of__innerException_4() { return &____innerException_4; }
	inline void set__innerException_4(Exception_t * value)
	{
		____innerException_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____innerException_4), (void*)value);
	}

	inline static int32_t get_offset_of__helpURL_5() { return static_cast<int32_t>(offsetof(Exception_t, ____helpURL_5)); }
	inline String_t* get__helpURL_5() const { return ____helpURL_5; }
	inline String_t** get_address_of__helpURL_5() { return &____helpURL_5; }
	inline void set__helpURL_5(String_t* value)
	{
		____helpURL_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____helpURL_5), (void*)value);
	}

	inline static int32_t get_offset_of__stackTrace_6() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTrace_6)); }
	inline RuntimeObject * get__stackTrace_6() const { return ____stackTrace_6; }
	inline RuntimeObject ** get_address_of__stackTrace_6() { return &____stackTrace_6; }
	inline void set__stackTrace_6(RuntimeObject * value)
	{
		____stackTrace_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____stackTrace_6), (void*)value);
	}

	inline static int32_t get_offset_of__stackTraceString_7() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTraceString_7)); }
	inline String_t* get__stackTraceString_7() const { return ____stackTraceString_7; }
	inline String_t** get_address_of__stackTraceString_7() { return &____stackTraceString_7; }
	inline void set__stackTraceString_7(String_t* value)
	{
		____stackTraceString_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____stackTraceString_7), (void*)value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_8() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_8)); }
	inline String_t* get__remoteStackTraceString_8() const { return ____remoteStackTraceString_8; }
	inline String_t** get_address_of__remoteStackTraceString_8() { return &____remoteStackTraceString_8; }
	inline void set__remoteStackTraceString_8(String_t* value)
	{
		____remoteStackTraceString_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____remoteStackTraceString_8), (void*)value);
	}

	inline static int32_t get_offset_of__remoteStackIndex_9() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackIndex_9)); }
	inline int32_t get__remoteStackIndex_9() const { return ____remoteStackIndex_9; }
	inline int32_t* get_address_of__remoteStackIndex_9() { return &____remoteStackIndex_9; }
	inline void set__remoteStackIndex_9(int32_t value)
	{
		____remoteStackIndex_9 = value;
	}

	inline static int32_t get_offset_of__dynamicMethods_10() { return static_cast<int32_t>(offsetof(Exception_t, ____dynamicMethods_10)); }
	inline RuntimeObject * get__dynamicMethods_10() const { return ____dynamicMethods_10; }
	inline RuntimeObject ** get_address_of__dynamicMethods_10() { return &____dynamicMethods_10; }
	inline void set__dynamicMethods_10(RuntimeObject * value)
	{
		____dynamicMethods_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____dynamicMethods_10), (void*)value);
	}

	inline static int32_t get_offset_of__HResult_11() { return static_cast<int32_t>(offsetof(Exception_t, ____HResult_11)); }
	inline int32_t get__HResult_11() const { return ____HResult_11; }
	inline int32_t* get_address_of__HResult_11() { return &____HResult_11; }
	inline void set__HResult_11(int32_t value)
	{
		____HResult_11 = value;
	}

	inline static int32_t get_offset_of__source_12() { return static_cast<int32_t>(offsetof(Exception_t, ____source_12)); }
	inline String_t* get__source_12() const { return ____source_12; }
	inline String_t** get_address_of__source_12() { return &____source_12; }
	inline void set__source_12(String_t* value)
	{
		____source_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____source_12), (void*)value);
	}

	inline static int32_t get_offset_of__safeSerializationManager_13() { return static_cast<int32_t>(offsetof(Exception_t, ____safeSerializationManager_13)); }
	inline SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * get__safeSerializationManager_13() const { return ____safeSerializationManager_13; }
	inline SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F ** get_address_of__safeSerializationManager_13() { return &____safeSerializationManager_13; }
	inline void set__safeSerializationManager_13(SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * value)
	{
		____safeSerializationManager_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____safeSerializationManager_13), (void*)value);
	}

	inline static int32_t get_offset_of_captured_traces_14() { return static_cast<int32_t>(offsetof(Exception_t, ___captured_traces_14)); }
	inline StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* get_captured_traces_14() const { return ___captured_traces_14; }
	inline StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971** get_address_of_captured_traces_14() { return &___captured_traces_14; }
	inline void set_captured_traces_14(StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* value)
	{
		___captured_traces_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___captured_traces_14), (void*)value);
	}

	inline static int32_t get_offset_of_native_trace_ips_15() { return static_cast<int32_t>(offsetof(Exception_t, ___native_trace_ips_15)); }
	inline IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* get_native_trace_ips_15() const { return ___native_trace_ips_15; }
	inline IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6** get_address_of_native_trace_ips_15() { return &___native_trace_ips_15; }
	inline void set_native_trace_ips_15(IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* value)
	{
		___native_trace_ips_15 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___native_trace_ips_15), (void*)value);
	}
};

struct Exception_t_StaticFields
{
public:
	// System.Object System.Exception::s_EDILock
	RuntimeObject * ___s_EDILock_0;

public:
	inline static int32_t get_offset_of_s_EDILock_0() { return static_cast<int32_t>(offsetof(Exception_t_StaticFields, ___s_EDILock_0)); }
	inline RuntimeObject * get_s_EDILock_0() const { return ___s_EDILock_0; }
	inline RuntimeObject ** get_address_of_s_EDILock_0() { return &___s_EDILock_0; }
	inline void set_s_EDILock_0(RuntimeObject * value)
	{
		___s_EDILock_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_EDILock_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
};

// UnityEngine.HideFlags
struct HideFlags_tDC64149E37544FF83B2B4222D3E9DC8188766A12 
{
public:
	// System.Int32 UnityEngine.HideFlags::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(HideFlags_tDC64149E37544FF83B2B4222D3E9DC8188766A12, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.Object
struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// UnityEngine.Plane
struct Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 
{
public:
	// UnityEngine.Vector3 UnityEngine.Plane::m_Normal
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Normal_0;
	// System.Single UnityEngine.Plane::m_Distance
	float ___m_Distance_1;

public:
	inline static int32_t get_offset_of_m_Normal_0() { return static_cast<int32_t>(offsetof(Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7, ___m_Normal_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Normal_0() const { return ___m_Normal_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Normal_0() { return &___m_Normal_0; }
	inline void set_m_Normal_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Normal_0 = value;
	}

	inline static int32_t get_offset_of_m_Distance_1() { return static_cast<int32_t>(offsetof(Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7, ___m_Distance_1)); }
	inline float get_m_Distance_1() const { return ___m_Distance_1; }
	inline float* get_address_of_m_Distance_1() { return &___m_Distance_1; }
	inline void set_m_Distance_1(float value)
	{
		___m_Distance_1 = value;
	}
};


// UnityEngine.Ray
struct Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 
{
public:
	// UnityEngine.Vector3 UnityEngine.Ray::m_Origin
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Origin_0;
	// UnityEngine.Vector3 UnityEngine.Ray::m_Direction
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Direction_1;

public:
	inline static int32_t get_offset_of_m_Origin_0() { return static_cast<int32_t>(offsetof(Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6, ___m_Origin_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Origin_0() const { return ___m_Origin_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Origin_0() { return &___m_Origin_0; }
	inline void set_m_Origin_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Origin_0 = value;
	}

	inline static int32_t get_offset_of_m_Direction_1() { return static_cast<int32_t>(offsetof(Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6, ___m_Direction_1)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Direction_1() const { return ___m_Direction_1; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Direction_1() { return &___m_Direction_1; }
	inline void set_m_Direction_1(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Direction_1 = value;
	}
};


// Unity.MARS.MARSHandles.RotationInfo
struct RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 
{
public:
	// System.Single Unity.MARS.MARSHandles.RotationInfo::<total>k__BackingField
	float ___U3CtotalU3Ek__BackingField_0;
	// System.Single Unity.MARS.MARSHandles.RotationInfo::<delta>k__BackingField
	float ___U3CdeltaU3Ek__BackingField_1;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotationInfo::<axis>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CaxisU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CtotalU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9, ___U3CtotalU3Ek__BackingField_0)); }
	inline float get_U3CtotalU3Ek__BackingField_0() const { return ___U3CtotalU3Ek__BackingField_0; }
	inline float* get_address_of_U3CtotalU3Ek__BackingField_0() { return &___U3CtotalU3Ek__BackingField_0; }
	inline void set_U3CtotalU3Ek__BackingField_0(float value)
	{
		___U3CtotalU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CdeltaU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9, ___U3CdeltaU3Ek__BackingField_1)); }
	inline float get_U3CdeltaU3Ek__BackingField_1() const { return ___U3CdeltaU3Ek__BackingField_1; }
	inline float* get_address_of_U3CdeltaU3Ek__BackingField_1() { return &___U3CdeltaU3Ek__BackingField_1; }
	inline void set_U3CdeltaU3Ek__BackingField_1(float value)
	{
		___U3CdeltaU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CaxisU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9, ___U3CaxisU3Ek__BackingField_2)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CaxisU3Ek__BackingField_2() const { return ___U3CaxisU3Ek__BackingField_2; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CaxisU3Ek__BackingField_2() { return &___U3CaxisU3Ek__BackingField_2; }
	inline void set_U3CaxisU3Ek__BackingField_2(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CaxisU3Ek__BackingField_2 = value;
	}
};


// Unity.MARS.MARSHandles.ScalingInfo
struct ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED 
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::<initial>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CinitialU3Ek__BackingField_0;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::<delta>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CdeltaU3Ek__BackingField_1;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::<total>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CtotalU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CinitialU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED, ___U3CinitialU3Ek__BackingField_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CinitialU3Ek__BackingField_0() const { return ___U3CinitialU3Ek__BackingField_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CinitialU3Ek__BackingField_0() { return &___U3CinitialU3Ek__BackingField_0; }
	inline void set_U3CinitialU3Ek__BackingField_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CinitialU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CdeltaU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED, ___U3CdeltaU3Ek__BackingField_1)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CdeltaU3Ek__BackingField_1() const { return ___U3CdeltaU3Ek__BackingField_1; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CdeltaU3Ek__BackingField_1() { return &___U3CdeltaU3Ek__BackingField_1; }
	inline void set_U3CdeltaU3Ek__BackingField_1(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CdeltaU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CtotalU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED, ___U3CtotalU3Ek__BackingField_2)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CtotalU3Ek__BackingField_2() const { return ___U3CtotalU3Ek__BackingField_2; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CtotalU3Ek__BackingField_2() { return &___U3CtotalU3Ek__BackingField_2; }
	inline void set_U3CtotalU3Ek__BackingField_2(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CtotalU3Ek__BackingField_2 = value;
	}
};


// Unity.MARS.MARSHandles.TranslationInfo
struct TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB 
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::<initialPosition>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CinitialPositionU3Ek__BackingField_0;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::<delta>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CdeltaU3Ek__BackingField_1;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::<total>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CtotalU3Ek__BackingField_2;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::<direction>k__BackingField
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___U3CdirectionU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CinitialPositionU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB, ___U3CinitialPositionU3Ek__BackingField_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CinitialPositionU3Ek__BackingField_0() const { return ___U3CinitialPositionU3Ek__BackingField_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CinitialPositionU3Ek__BackingField_0() { return &___U3CinitialPositionU3Ek__BackingField_0; }
	inline void set_U3CinitialPositionU3Ek__BackingField_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CinitialPositionU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CdeltaU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB, ___U3CdeltaU3Ek__BackingField_1)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CdeltaU3Ek__BackingField_1() const { return ___U3CdeltaU3Ek__BackingField_1; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CdeltaU3Ek__BackingField_1() { return &___U3CdeltaU3Ek__BackingField_1; }
	inline void set_U3CdeltaU3Ek__BackingField_1(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CdeltaU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CtotalU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB, ___U3CtotalU3Ek__BackingField_2)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CtotalU3Ek__BackingField_2() const { return ___U3CtotalU3Ek__BackingField_2; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CtotalU3Ek__BackingField_2() { return &___U3CtotalU3Ek__BackingField_2; }
	inline void set_U3CtotalU3Ek__BackingField_2(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CtotalU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CdirectionU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB, ___U3CdirectionU3Ek__BackingField_3)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_U3CdirectionU3Ek__BackingField_3() const { return ___U3CdirectionU3Ek__BackingField_3; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_U3CdirectionU3Ek__BackingField_3() { return &___U3CdirectionU3Ek__BackingField_3; }
	inline void set_U3CdirectionU3Ek__BackingField_3(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___U3CdirectionU3Ek__BackingField_3 = value;
	}
};


// Unity.MARS.MARSHandles.EditorHandleStateColors/IdleColor
struct IdleColor_t70F3CBC7977E8FFFF73745388EB4A1981C965CEB 
{
public:
	// System.Int32 Unity.MARS.MARSHandles.EditorHandleStateColors/IdleColor::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(IdleColor_t70F3CBC7977E8FFFF73745388EB4A1981C965CEB, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.MARSHandles.HandleContext/InteractionState/State
struct State_t7F6D7EF24A0CAE93C1B68227F10E763B43786F9C 
{
public:
	// System.Int32 Unity.MARS.MARSHandles.HandleContext/InteractionState/State::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(State_t7F6D7EF24A0CAE93C1B68227F10E763B43786F9C, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.Component
struct Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// Unity.MARS.MARSHandles.DragBeginInfo
struct DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 
{
public:
	// Unity.MARS.MARSHandles.DragTranslation Unity.MARS.MARSHandles.DragBeginInfo::translation
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation_0;

public:
	inline static int32_t get_offset_of_translation_0() { return static_cast<int32_t>(offsetof(DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7, ___translation_0)); }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  get_translation_0() const { return ___translation_0; }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * get_address_of_translation_0() { return &___translation_0; }
	inline void set_translation_0(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  value)
	{
		___translation_0 = value;
	}
};


// Unity.MARS.MARSHandles.DragEndInfo
struct DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D 
{
public:
	// Unity.MARS.MARSHandles.DragTranslation Unity.MARS.MARSHandles.DragEndInfo::translation
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation_0;

public:
	inline static int32_t get_offset_of_translation_0() { return static_cast<int32_t>(offsetof(DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D, ___translation_0)); }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  get_translation_0() const { return ___translation_0; }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * get_address_of_translation_0() { return &___translation_0; }
	inline void set_translation_0(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  value)
	{
		___translation_0 = value;
	}
};


// Unity.MARS.MARSHandles.DragUpdateInfo
struct DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 
{
public:
	// Unity.MARS.MARSHandles.DragTranslation Unity.MARS.MARSHandles.DragUpdateInfo::<translation>k__BackingField
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___U3CtranslationU3Ek__BackingField_0;

public:
	inline static int32_t get_offset_of_U3CtranslationU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8, ___U3CtranslationU3Ek__BackingField_0)); }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  get_U3CtranslationU3Ek__BackingField_0() const { return ___U3CtranslationU3Ek__BackingField_0; }
	inline DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * get_address_of_U3CtranslationU3Ek__BackingField_0() { return &___U3CtranslationU3Ek__BackingField_0; }
	inline void set_U3CtranslationU3Ek__BackingField_0(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  value)
	{
		___U3CtranslationU3Ek__BackingField_0 = value;
	}
};


// UnityEngine.GameObject
struct GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// UnityEngine.Material
struct Material_t8927C00353A72755313F046D0CE85178AE8218EE  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___delegates_11), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_11;
};

// Unity.MARS.MARSHandles.RotationBeginInfo
struct RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 
{
public:
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::<world>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::<local>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78, ___U3CworldU3Ek__BackingField_0)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78, ___U3ClocalU3Ek__BackingField_1)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.RotationEndInfo
struct RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 
{
public:
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::<world>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::<local>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449, ___U3CworldU3Ek__BackingField_0)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449, ___U3ClocalU3Ek__BackingField_1)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.RotationUpdateInfo
struct RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 
{
public:
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::<world>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::<local>k__BackingField
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44, ___U3CworldU3Ek__BackingField_0)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44, ___U3ClocalU3Ek__BackingField_1)); }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.ScalingUpdatedInfo
struct ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 
{
public:
	// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::<world>k__BackingField
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::<local>k__BackingField
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1, ___U3CworldU3Ek__BackingField_0)); }
	inline ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1, ___U3ClocalU3Ek__BackingField_1)); }
	inline ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// UnityEngine.Shader
struct Shader_tB2355DC4F3CAF20B2F1AB5AABBF37C3555FFBC39  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// System.SystemException
struct SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62  : public Exception_t
{
public:

public:
};


// Unity.MARS.MARSHandles.TranslationBeginInfo
struct TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA 
{
public:
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::<world>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::<local>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA, ___U3CworldU3Ek__BackingField_0)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA, ___U3ClocalU3Ek__BackingField_1)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.TranslationEndInfo
struct TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B 
{
public:
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::<world>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::<local>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B, ___U3CworldU3Ek__BackingField_0)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B, ___U3ClocalU3Ek__BackingField_1)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.TranslationUpdateInfo
struct TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 
{
public:
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::<world>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3CworldU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::<local>k__BackingField
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___U3ClocalU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CworldU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628, ___U3CworldU3Ek__BackingField_0)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3CworldU3Ek__BackingField_0() const { return ___U3CworldU3Ek__BackingField_0; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3CworldU3Ek__BackingField_0() { return &___U3CworldU3Ek__BackingField_0; }
	inline void set_U3CworldU3Ek__BackingField_0(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3CworldU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ClocalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628, ___U3ClocalU3Ek__BackingField_1)); }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  get_U3ClocalU3Ek__BackingField_1() const { return ___U3ClocalU3Ek__BackingField_1; }
	inline TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * get_address_of_U3ClocalU3Ek__BackingField_1() { return &___U3ClocalU3Ek__BackingField_1; }
	inline void set_U3ClocalU3Ek__BackingField_1(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  value)
	{
		___U3ClocalU3Ek__BackingField_1 = value;
	}
};


// Unity.MARS.MARSHandles.HandleContext/InteractionState
struct InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2  : public RuntimeObject
{
public:
	// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleContext/InteractionState::m_HoverHandle
	InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___m_HoverHandle_0;
	// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleContext/InteractionState::m_ActiveHandle
	InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___m_ActiveHandle_1;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleContext/InteractionState::m_StartDragPosition
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_StartDragPosition_2;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleContext/InteractionState::m_LastFramePosition
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_LastFramePosition_3;
	// Unity.MARS.MARSHandles.HandleContext/InteractionState/State Unity.MARS.MARSHandles.HandleContext/InteractionState::m_State
	int32_t ___m_State_4;
	// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleContext/InteractionState::m_Context
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___m_Context_5;

public:
	inline static int32_t get_offset_of_m_HoverHandle_0() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_HoverHandle_0)); }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * get_m_HoverHandle_0() const { return ___m_HoverHandle_0; }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F ** get_address_of_m_HoverHandle_0() { return &___m_HoverHandle_0; }
	inline void set_m_HoverHandle_0(InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * value)
	{
		___m_HoverHandle_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_HoverHandle_0), (void*)value);
	}

	inline static int32_t get_offset_of_m_ActiveHandle_1() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_ActiveHandle_1)); }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * get_m_ActiveHandle_1() const { return ___m_ActiveHandle_1; }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F ** get_address_of_m_ActiveHandle_1() { return &___m_ActiveHandle_1; }
	inline void set_m_ActiveHandle_1(InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * value)
	{
		___m_ActiveHandle_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_ActiveHandle_1), (void*)value);
	}

	inline static int32_t get_offset_of_m_StartDragPosition_2() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_StartDragPosition_2)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_StartDragPosition_2() const { return ___m_StartDragPosition_2; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_StartDragPosition_2() { return &___m_StartDragPosition_2; }
	inline void set_m_StartDragPosition_2(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_StartDragPosition_2 = value;
	}

	inline static int32_t get_offset_of_m_LastFramePosition_3() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_LastFramePosition_3)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_LastFramePosition_3() const { return ___m_LastFramePosition_3; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_LastFramePosition_3() { return &___m_LastFramePosition_3; }
	inline void set_m_LastFramePosition_3(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_LastFramePosition_3 = value;
	}

	inline static int32_t get_offset_of_m_State_4() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_State_4)); }
	inline int32_t get_m_State_4() const { return ___m_State_4; }
	inline int32_t* get_address_of_m_State_4() { return &___m_State_4; }
	inline void set_m_State_4(int32_t value)
	{
		___m_State_4 = value;
	}

	inline static int32_t get_offset_of_m_Context_5() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2, ___m_Context_5)); }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * get_m_Context_5() const { return ___m_Context_5; }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B ** get_address_of_m_Context_5() { return &___m_Context_5; }
	inline void set_m_Context_5(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * value)
	{
		___m_Context_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Context_5), (void*)value);
	}
};

struct InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields
{
public:
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext/InteractionState::s_BehavioursSnapshot
	List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___s_BehavioursSnapshot_6;

public:
	inline static int32_t get_offset_of_s_BehavioursSnapshot_6() { return static_cast<int32_t>(offsetof(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields, ___s_BehavioursSnapshot_6)); }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * get_s_BehavioursSnapshot_6() const { return ___s_BehavioursSnapshot_6; }
	inline List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D ** get_address_of_s_BehavioursSnapshot_6() { return &___s_BehavioursSnapshot_6; }
	inline void set_s_BehavioursSnapshot_6(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * value)
	{
		___s_BehavioursSnapshot_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_BehavioursSnapshot_6), (void*)value);
	}
};


// System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>
struct Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>
struct Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>
struct Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.ScalingUpdatedInfo>
struct Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>
struct Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>
struct Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>
struct Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1  : public MulticastDelegate_t
{
public:

public:
};


// System.Action
struct Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6  : public MulticastDelegate_t
{
public:

public:
};


// System.ArgumentException
struct ArgumentException_t505FA8C11E883F2D96C797AD9D396490794DEE00  : public SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62
{
public:
	// System.String System.ArgumentException::m_paramName
	String_t* ___m_paramName_17;

public:
	inline static int32_t get_offset_of_m_paramName_17() { return static_cast<int32_t>(offsetof(ArgumentException_t505FA8C11E883F2D96C797AD9D396490794DEE00, ___m_paramName_17)); }
	inline String_t* get_m_paramName_17() const { return ___m_paramName_17; }
	inline String_t** get_address_of_m_paramName_17() { return &___m_paramName_17; }
	inline void set_m_paramName_17(String_t* value)
	{
		___m_paramName_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_paramName_17), (void*)value);
	}
};


// UnityEngine.Behaviour
struct Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9  : public Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684
{
public:

public:
};


// UnityEngine.Renderer
struct Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C  : public Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684
{
public:

public:
};


// UnityEngine.Transform
struct Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1  : public Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684
{
public:

public:
};


// UnityEngine.Camera/CameraCallback
struct CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D  : public MulticastDelegate_t
{
public:

public:
};


// System.ArgumentNullException
struct ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB  : public ArgumentException_t505FA8C11E883F2D96C797AD9D396490794DEE00
{
public:

public:
};


// UnityEngine.Camera
struct Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C  : public Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9
{
public:

public:
};

struct Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields
{
public:
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPreCull
	CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * ___onPreCull_4;
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPreRender
	CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * ___onPreRender_5;
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPostRender
	CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * ___onPostRender_6;

public:
	inline static int32_t get_offset_of_onPreCull_4() { return static_cast<int32_t>(offsetof(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields, ___onPreCull_4)); }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * get_onPreCull_4() const { return ___onPreCull_4; }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D ** get_address_of_onPreCull_4() { return &___onPreCull_4; }
	inline void set_onPreCull_4(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * value)
	{
		___onPreCull_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___onPreCull_4), (void*)value);
	}

	inline static int32_t get_offset_of_onPreRender_5() { return static_cast<int32_t>(offsetof(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields, ___onPreRender_5)); }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * get_onPreRender_5() const { return ___onPreRender_5; }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D ** get_address_of_onPreRender_5() { return &___onPreRender_5; }
	inline void set_onPreRender_5(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * value)
	{
		___onPreRender_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___onPreRender_5), (void*)value);
	}

	inline static int32_t get_offset_of_onPostRender_6() { return static_cast<int32_t>(offsetof(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields, ___onPostRender_6)); }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * get_onPostRender_6() const { return ___onPostRender_6; }
	inline CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D ** get_address_of_onPostRender_6() { return &___onPostRender_6; }
	inline void set_onPostRender_6(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * value)
	{
		___onPostRender_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___onPostRender_6), (void*)value);
	}
};


// UnityEngine.LineRenderer
struct LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967  : public Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C
{
public:

public:
};


// UnityEngine.MonoBehaviour
struct MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A  : public Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9
{
public:

public:
};


// Unity.MARS.MARSHandles.HandleBehaviour
struct HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleBehaviour::m_Context
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___m_Context_4;
	// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleBehaviour::m_OwnerHandle
	InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___m_OwnerHandle_5;
	// System.Boolean Unity.MARS.MARSHandles.HandleBehaviour::m_Registered
	bool ___m_Registered_6;
	// System.Boolean Unity.MARS.MARSHandles.HandleBehaviour::m_CreatedEventSent
	bool ___m_CreatedEventSent_7;

public:
	inline static int32_t get_offset_of_m_Context_4() { return static_cast<int32_t>(offsetof(HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE, ___m_Context_4)); }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * get_m_Context_4() const { return ___m_Context_4; }
	inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B ** get_address_of_m_Context_4() { return &___m_Context_4; }
	inline void set_m_Context_4(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * value)
	{
		___m_Context_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Context_4), (void*)value);
	}

	inline static int32_t get_offset_of_m_OwnerHandle_5() { return static_cast<int32_t>(offsetof(HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE, ___m_OwnerHandle_5)); }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * get_m_OwnerHandle_5() const { return ___m_OwnerHandle_5; }
	inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F ** get_address_of_m_OwnerHandle_5() { return &___m_OwnerHandle_5; }
	inline void set_m_OwnerHandle_5(InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * value)
	{
		___m_OwnerHandle_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_OwnerHandle_5), (void*)value);
	}

	inline static int32_t get_offset_of_m_Registered_6() { return static_cast<int32_t>(offsetof(HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE, ___m_Registered_6)); }
	inline bool get_m_Registered_6() const { return ___m_Registered_6; }
	inline bool* get_address_of_m_Registered_6() { return &___m_Registered_6; }
	inline void set_m_Registered_6(bool value)
	{
		___m_Registered_6 = value;
	}

	inline static int32_t get_offset_of_m_CreatedEventSent_7() { return static_cast<int32_t>(offsetof(HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE, ___m_CreatedEventSent_7)); }
	inline bool get_m_CreatedEventSent_7() const { return ___m_CreatedEventSent_7; }
	inline bool* get_address_of_m_CreatedEventSent_7() { return &___m_CreatedEventSent_7; }
	inline void set_m_CreatedEventSent_7(bool value)
	{
		___m_CreatedEventSent_7 = value;
	}
};


// Unity.MARS.MARSHandles.LineRendererConstraint
struct LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// UnityEngine.Transform Unity.MARS.MARSHandles.LineRendererConstraint::m_A
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___m_A_4;
	// UnityEngine.Transform Unity.MARS.MARSHandles.LineRendererConstraint::m_B
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___m_B_5;
	// UnityEngine.LineRenderer Unity.MARS.MARSHandles.LineRendererConstraint::m_Line
	LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * ___m_Line_6;

public:
	inline static int32_t get_offset_of_m_A_4() { return static_cast<int32_t>(offsetof(LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1, ___m_A_4)); }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * get_m_A_4() const { return ___m_A_4; }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 ** get_address_of_m_A_4() { return &___m_A_4; }
	inline void set_m_A_4(Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * value)
	{
		___m_A_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_A_4), (void*)value);
	}

	inline static int32_t get_offset_of_m_B_5() { return static_cast<int32_t>(offsetof(LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1, ___m_B_5)); }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * get_m_B_5() const { return ___m_B_5; }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 ** get_address_of_m_B_5() { return &___m_B_5; }
	inline void set_m_B_5(Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * value)
	{
		___m_B_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_B_5), (void*)value);
	}

	inline static int32_t get_offset_of_m_Line_6() { return static_cast<int32_t>(offsetof(LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1, ___m_Line_6)); }
	inline LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * get_m_Line_6() const { return ___m_Line_6; }
	inline LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 ** get_address_of_m_Line_6() { return &___m_Line_6; }
	inline void set_m_Line_6(LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * value)
	{
		___m_Line_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Line_6), (void*)value);
	}
};


// Unity.MARS.MARSHandles.PositionHandle
struct PositionHandle_t507E61E6A8E839708379198222365B39213A4835  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo> Unity.MARS.MARSHandles.PositionHandle::translationBegun
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___translationBegun_4;
	// System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo> Unity.MARS.MARSHandles.PositionHandle::translationUpdated
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___translationUpdated_5;
	// System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo> Unity.MARS.MARSHandles.PositionHandle::translationEnded
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___translationEnded_6;
	// Unity.MARS.MARSHandles.SliderHandleBase[] Unity.MARS.MARSHandles.PositionHandle::m_Sliders
	SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* ___m_Sliders_7;

public:
	inline static int32_t get_offset_of_translationBegun_4() { return static_cast<int32_t>(offsetof(PositionHandle_t507E61E6A8E839708379198222365B39213A4835, ___translationBegun_4)); }
	inline Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * get_translationBegun_4() const { return ___translationBegun_4; }
	inline Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** get_address_of_translationBegun_4() { return &___translationBegun_4; }
	inline void set_translationBegun_4(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * value)
	{
		___translationBegun_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationBegun_4), (void*)value);
	}

	inline static int32_t get_offset_of_translationUpdated_5() { return static_cast<int32_t>(offsetof(PositionHandle_t507E61E6A8E839708379198222365B39213A4835, ___translationUpdated_5)); }
	inline Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * get_translationUpdated_5() const { return ___translationUpdated_5; }
	inline Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** get_address_of_translationUpdated_5() { return &___translationUpdated_5; }
	inline void set_translationUpdated_5(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * value)
	{
		___translationUpdated_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationUpdated_5), (void*)value);
	}

	inline static int32_t get_offset_of_translationEnded_6() { return static_cast<int32_t>(offsetof(PositionHandle_t507E61E6A8E839708379198222365B39213A4835, ___translationEnded_6)); }
	inline Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * get_translationEnded_6() const { return ___translationEnded_6; }
	inline Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** get_address_of_translationEnded_6() { return &___translationEnded_6; }
	inline void set_translationEnded_6(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * value)
	{
		___translationEnded_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationEnded_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Sliders_7() { return static_cast<int32_t>(offsetof(PositionHandle_t507E61E6A8E839708379198222365B39213A4835, ___m_Sliders_7)); }
	inline SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* get_m_Sliders_7() const { return ___m_Sliders_7; }
	inline SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45** get_address_of_m_Sliders_7() { return &___m_Sliders_7; }
	inline void set_m_Sliders_7(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* value)
	{
		___m_Sliders_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Sliders_7), (void*)value);
	}
};


// Unity.MARS.MARSHandles.RotationHandle
struct RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo> Unity.MARS.MARSHandles.RotationHandle::rotationBegun
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___rotationBegun_4;
	// System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo> Unity.MARS.MARSHandles.RotationHandle::rotationUpdated
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___rotationUpdated_5;
	// System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo> Unity.MARS.MARSHandles.RotationHandle::rotationEnded
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___rotationEnded_6;
	// Unity.MARS.MARSHandles.RotatorHandle[] Unity.MARS.MARSHandles.RotationHandle::m_Rotators
	RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* ___m_Rotators_7;

public:
	inline static int32_t get_offset_of_rotationBegun_4() { return static_cast<int32_t>(offsetof(RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78, ___rotationBegun_4)); }
	inline Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * get_rotationBegun_4() const { return ___rotationBegun_4; }
	inline Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** get_address_of_rotationBegun_4() { return &___rotationBegun_4; }
	inline void set_rotationBegun_4(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * value)
	{
		___rotationBegun_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationBegun_4), (void*)value);
	}

	inline static int32_t get_offset_of_rotationUpdated_5() { return static_cast<int32_t>(offsetof(RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78, ___rotationUpdated_5)); }
	inline Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * get_rotationUpdated_5() const { return ___rotationUpdated_5; }
	inline Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** get_address_of_rotationUpdated_5() { return &___rotationUpdated_5; }
	inline void set_rotationUpdated_5(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * value)
	{
		___rotationUpdated_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationUpdated_5), (void*)value);
	}

	inline static int32_t get_offset_of_rotationEnded_6() { return static_cast<int32_t>(offsetof(RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78, ___rotationEnded_6)); }
	inline Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * get_rotationEnded_6() const { return ___rotationEnded_6; }
	inline Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** get_address_of_rotationEnded_6() { return &___rotationEnded_6; }
	inline void set_rotationEnded_6(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * value)
	{
		___rotationEnded_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationEnded_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Rotators_7() { return static_cast<int32_t>(offsetof(RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78, ___m_Rotators_7)); }
	inline RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* get_m_Rotators_7() const { return ___m_Rotators_7; }
	inline RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A** get_address_of_m_Rotators_7() { return &___m_Rotators_7; }
	inline void set_m_Rotators_7(RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* value)
	{
		___m_Rotators_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Rotators_7), (void*)value);
	}
};


// Unity.MARS.MARSHandles.ScaleHandle
struct ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// System.Action Unity.MARS.MARSHandles.ScaleHandle::scalingBegun
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___scalingBegun_4;
	// System.Action`1<Unity.MARS.MARSHandles.ScalingUpdatedInfo> Unity.MARS.MARSHandles.ScaleHandle::scaleUpdated
	Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * ___scaleUpdated_5;
	// System.Action Unity.MARS.MARSHandles.ScaleHandle::scalingEnded
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___scalingEnded_6;
	// Unity.MARS.MARSHandles.SliderHandleBase[] Unity.MARS.MARSHandles.ScaleHandle::m_Sliders
	SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* ___m_Sliders_7;

public:
	inline static int32_t get_offset_of_scalingBegun_4() { return static_cast<int32_t>(offsetof(ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719, ___scalingBegun_4)); }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * get_scalingBegun_4() const { return ___scalingBegun_4; }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 ** get_address_of_scalingBegun_4() { return &___scalingBegun_4; }
	inline void set_scalingBegun_4(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * value)
	{
		___scalingBegun_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___scalingBegun_4), (void*)value);
	}

	inline static int32_t get_offset_of_scaleUpdated_5() { return static_cast<int32_t>(offsetof(ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719, ___scaleUpdated_5)); }
	inline Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * get_scaleUpdated_5() const { return ___scaleUpdated_5; }
	inline Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 ** get_address_of_scaleUpdated_5() { return &___scaleUpdated_5; }
	inline void set_scaleUpdated_5(Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * value)
	{
		___scaleUpdated_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___scaleUpdated_5), (void*)value);
	}

	inline static int32_t get_offset_of_scalingEnded_6() { return static_cast<int32_t>(offsetof(ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719, ___scalingEnded_6)); }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * get_scalingEnded_6() const { return ___scalingEnded_6; }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 ** get_address_of_scalingEnded_6() { return &___scalingEnded_6; }
	inline void set_scalingEnded_6(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * value)
	{
		___scalingEnded_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___scalingEnded_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Sliders_7() { return static_cast<int32_t>(offsetof(ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719, ___m_Sliders_7)); }
	inline SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* get_m_Sliders_7() const { return ___m_Sliders_7; }
	inline SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45** get_address_of_m_Sliders_7() { return &___m_Sliders_7; }
	inline void set_m_Sliders_7(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* value)
	{
		___m_Sliders_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Sliders_7), (void*)value);
	}
};


// Unity.MARS.MARSHandles.HandleStateColors
struct HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85  : public HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE
{
public:
	// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::m_HoverColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___m_HoverColor_8;
	// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::m_DragColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___m_DragColor_9;
	// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::m_DisableColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___m_DisableColor_10;
	// System.Boolean Unity.MARS.MARSHandles.HandleStateColors::m_UseDisableColor
	bool ___m_UseDisableColor_11;
	// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::m_IdleColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___m_IdleColor_12;
	// UnityEngine.Renderer Unity.MARS.MARSHandles.HandleStateColors::m_TargetRenderer
	Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * ___m_TargetRenderer_13;
	// System.Boolean Unity.MARS.MARSHandles.HandleStateColors::m_IsHovered
	bool ___m_IsHovered_14;

public:
	inline static int32_t get_offset_of_m_HoverColor_8() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_HoverColor_8)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_m_HoverColor_8() const { return ___m_HoverColor_8; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_m_HoverColor_8() { return &___m_HoverColor_8; }
	inline void set_m_HoverColor_8(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___m_HoverColor_8 = value;
	}

	inline static int32_t get_offset_of_m_DragColor_9() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_DragColor_9)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_m_DragColor_9() const { return ___m_DragColor_9; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_m_DragColor_9() { return &___m_DragColor_9; }
	inline void set_m_DragColor_9(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___m_DragColor_9 = value;
	}

	inline static int32_t get_offset_of_m_DisableColor_10() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_DisableColor_10)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_m_DisableColor_10() const { return ___m_DisableColor_10; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_m_DisableColor_10() { return &___m_DisableColor_10; }
	inline void set_m_DisableColor_10(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___m_DisableColor_10 = value;
	}

	inline static int32_t get_offset_of_m_UseDisableColor_11() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_UseDisableColor_11)); }
	inline bool get_m_UseDisableColor_11() const { return ___m_UseDisableColor_11; }
	inline bool* get_address_of_m_UseDisableColor_11() { return &___m_UseDisableColor_11; }
	inline void set_m_UseDisableColor_11(bool value)
	{
		___m_UseDisableColor_11 = value;
	}

	inline static int32_t get_offset_of_m_IdleColor_12() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_IdleColor_12)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_m_IdleColor_12() const { return ___m_IdleColor_12; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_m_IdleColor_12() { return &___m_IdleColor_12; }
	inline void set_m_IdleColor_12(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___m_IdleColor_12 = value;
	}

	inline static int32_t get_offset_of_m_TargetRenderer_13() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_TargetRenderer_13)); }
	inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * get_m_TargetRenderer_13() const { return ___m_TargetRenderer_13; }
	inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C ** get_address_of_m_TargetRenderer_13() { return &___m_TargetRenderer_13; }
	inline void set_m_TargetRenderer_13(Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * value)
	{
		___m_TargetRenderer_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_TargetRenderer_13), (void*)value);
	}

	inline static int32_t get_offset_of_m_IsHovered_14() { return static_cast<int32_t>(offsetof(HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85, ___m_IsHovered_14)); }
	inline bool get_m_IsHovered_14() const { return ___m_IsHovered_14; }
	inline bool* get_address_of_m_IsHovered_14() { return &___m_IsHovered_14; }
	inline void set_m_IsHovered_14(bool value)
	{
		___m_IsHovered_14 = value;
	}
};


// Unity.MARS.MARSHandles.InteractiveHandle
struct InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F  : public HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE
{
public:

public:
};


// Unity.MARS.MARSHandles.ScaleWithCameraDistance
struct ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21  : public HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScaleWithCameraDistance::m_InitialScale
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_InitialScale_8;

public:
	inline static int32_t get_offset_of_m_InitialScale_8() { return static_cast<int32_t>(offsetof(ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21, ___m_InitialScale_8)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_InitialScale_8() const { return ___m_InitialScale_8; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_InitialScale_8() { return &___m_InitialScale_8; }
	inline void set_m_InitialScale_8(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_InitialScale_8 = value;
	}
};


// Unity.MARS.MARSHandles.EditorHandleStateColors
struct EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725  : public HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85
{
public:
	// Unity.MARS.MARSHandles.EditorHandleStateColors/IdleColor Unity.MARS.MARSHandles.EditorHandleStateColors::m_IdleColor
	int32_t ___m_IdleColor_18;
	// System.Boolean Unity.MARS.MARSHandles.EditorHandleStateColors::m_WrongContextLogged
	bool ___m_WrongContextLogged_19;

public:
	inline static int32_t get_offset_of_m_IdleColor_18() { return static_cast<int32_t>(offsetof(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725, ___m_IdleColor_18)); }
	inline int32_t get_m_IdleColor_18() const { return ___m_IdleColor_18; }
	inline int32_t* get_address_of_m_IdleColor_18() { return &___m_IdleColor_18; }
	inline void set_m_IdleColor_18(int32_t value)
	{
		___m_IdleColor_18 = value;
	}

	inline static int32_t get_offset_of_m_WrongContextLogged_19() { return static_cast<int32_t>(offsetof(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725, ___m_WrongContextLogged_19)); }
	inline bool get_m_WrongContextLogged_19() const { return ___m_WrongContextLogged_19; }
	inline bool* get_address_of_m_WrongContextLogged_19() { return &___m_WrongContextLogged_19; }
	inline void set_m_WrongContextLogged_19(bool value)
	{
		___m_WrongContextLogged_19 = value;
	}
};

struct EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields
{
public:
	// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::editorDefaultDisableColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___editorDefaultDisableColor_15;
	// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::wrongContextColor
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___wrongContextColor_17;

public:
	inline static int32_t get_offset_of_editorDefaultDisableColor_15() { return static_cast<int32_t>(offsetof(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields, ___editorDefaultDisableColor_15)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_editorDefaultDisableColor_15() const { return ___editorDefaultDisableColor_15; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_editorDefaultDisableColor_15() { return &___editorDefaultDisableColor_15; }
	inline void set_editorDefaultDisableColor_15(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___editorDefaultDisableColor_15 = value;
	}

	inline static int32_t get_offset_of_wrongContextColor_17() { return static_cast<int32_t>(offsetof(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields, ___wrongContextColor_17)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_wrongContextColor_17() const { return ___wrongContextColor_17; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_wrongContextColor_17() { return &___wrongContextColor_17; }
	inline void set_wrongContextColor_17(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___wrongContextColor_17 = value;
	}
};


// Unity.MARS.MARSHandles.RotatorHandle
struct RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB  : public InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F
{
public:
	// System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo> Unity.MARS.MARSHandles.RotatorHandle::rotationBegun
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___rotationBegun_8;
	// System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo> Unity.MARS.MARSHandles.RotatorHandle::rotationUpdated
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___rotationUpdated_9;
	// System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo> Unity.MARS.MARSHandles.RotatorHandle::rotationEnded
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___rotationEnded_10;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotatorHandle::m_LastDirection
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_LastDirection_11;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotatorHandle::m_Normal
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Normal_12;
	// System.Single Unity.MARS.MARSHandles.RotatorHandle::m_TotalAngle
	float ___m_TotalAngle_13;

public:
	inline static int32_t get_offset_of_rotationBegun_8() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___rotationBegun_8)); }
	inline Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * get_rotationBegun_8() const { return ___rotationBegun_8; }
	inline Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** get_address_of_rotationBegun_8() { return &___rotationBegun_8; }
	inline void set_rotationBegun_8(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * value)
	{
		___rotationBegun_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationBegun_8), (void*)value);
	}

	inline static int32_t get_offset_of_rotationUpdated_9() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___rotationUpdated_9)); }
	inline Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * get_rotationUpdated_9() const { return ___rotationUpdated_9; }
	inline Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** get_address_of_rotationUpdated_9() { return &___rotationUpdated_9; }
	inline void set_rotationUpdated_9(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * value)
	{
		___rotationUpdated_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationUpdated_9), (void*)value);
	}

	inline static int32_t get_offset_of_rotationEnded_10() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___rotationEnded_10)); }
	inline Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * get_rotationEnded_10() const { return ___rotationEnded_10; }
	inline Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** get_address_of_rotationEnded_10() { return &___rotationEnded_10; }
	inline void set_rotationEnded_10(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * value)
	{
		___rotationEnded_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___rotationEnded_10), (void*)value);
	}

	inline static int32_t get_offset_of_m_LastDirection_11() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___m_LastDirection_11)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_LastDirection_11() const { return ___m_LastDirection_11; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_LastDirection_11() { return &___m_LastDirection_11; }
	inline void set_m_LastDirection_11(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_LastDirection_11 = value;
	}

	inline static int32_t get_offset_of_m_Normal_12() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___m_Normal_12)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Normal_12() const { return ___m_Normal_12; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Normal_12() { return &___m_Normal_12; }
	inline void set_m_Normal_12(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Normal_12 = value;
	}

	inline static int32_t get_offset_of_m_TotalAngle_13() { return static_cast<int32_t>(offsetof(RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB, ___m_TotalAngle_13)); }
	inline float get_m_TotalAngle_13() const { return ___m_TotalAngle_13; }
	inline float* get_address_of_m_TotalAngle_13() { return &___m_TotalAngle_13; }
	inline void set_m_TotalAngle_13(float value)
	{
		___m_TotalAngle_13 = value;
	}
};


// Unity.MARS.MARSHandles.SliderHandleBase
struct SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A  : public InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F
{
public:
	// System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo> Unity.MARS.MARSHandles.SliderHandleBase::translationBegun
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___translationBegun_8;
	// System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo> Unity.MARS.MARSHandles.SliderHandleBase::translationUpdated
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___translationUpdated_9;
	// System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo> Unity.MARS.MARSHandles.SliderHandleBase::translationEnded
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___translationEnded_10;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.SliderHandleBase::m_InitialPosWorld
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_InitialPosWorld_11;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.SliderHandleBase::m_InitialPosLocal
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_InitialPosLocal_12;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.SliderHandleBase::m_TotalTranslation
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_TotalTranslation_13;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.SliderHandleBase::m_CurrentDirection
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_CurrentDirection_14;

public:
	inline static int32_t get_offset_of_translationBegun_8() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___translationBegun_8)); }
	inline Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * get_translationBegun_8() const { return ___translationBegun_8; }
	inline Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** get_address_of_translationBegun_8() { return &___translationBegun_8; }
	inline void set_translationBegun_8(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * value)
	{
		___translationBegun_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationBegun_8), (void*)value);
	}

	inline static int32_t get_offset_of_translationUpdated_9() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___translationUpdated_9)); }
	inline Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * get_translationUpdated_9() const { return ___translationUpdated_9; }
	inline Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** get_address_of_translationUpdated_9() { return &___translationUpdated_9; }
	inline void set_translationUpdated_9(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * value)
	{
		___translationUpdated_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationUpdated_9), (void*)value);
	}

	inline static int32_t get_offset_of_translationEnded_10() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___translationEnded_10)); }
	inline Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * get_translationEnded_10() const { return ___translationEnded_10; }
	inline Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** get_address_of_translationEnded_10() { return &___translationEnded_10; }
	inline void set_translationEnded_10(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * value)
	{
		___translationEnded_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___translationEnded_10), (void*)value);
	}

	inline static int32_t get_offset_of_m_InitialPosWorld_11() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___m_InitialPosWorld_11)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_InitialPosWorld_11() const { return ___m_InitialPosWorld_11; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_InitialPosWorld_11() { return &___m_InitialPosWorld_11; }
	inline void set_m_InitialPosWorld_11(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_InitialPosWorld_11 = value;
	}

	inline static int32_t get_offset_of_m_InitialPosLocal_12() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___m_InitialPosLocal_12)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_InitialPosLocal_12() const { return ___m_InitialPosLocal_12; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_InitialPosLocal_12() { return &___m_InitialPosLocal_12; }
	inline void set_m_InitialPosLocal_12(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_InitialPosLocal_12 = value;
	}

	inline static int32_t get_offset_of_m_TotalTranslation_13() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___m_TotalTranslation_13)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_TotalTranslation_13() const { return ___m_TotalTranslation_13; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_TotalTranslation_13() { return &___m_TotalTranslation_13; }
	inline void set_m_TotalTranslation_13(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_TotalTranslation_13 = value;
	}

	inline static int32_t get_offset_of_m_CurrentDirection_14() { return static_cast<int32_t>(offsetof(SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A, ___m_CurrentDirection_14)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_CurrentDirection_14() const { return ___m_CurrentDirection_14; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_CurrentDirection_14() { return &___m_CurrentDirection_14; }
	inline void set_m_CurrentDirection_14(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_CurrentDirection_14 = value;
	}
};


// Unity.MARS.MARSHandles.Slider1DHandle
struct Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30  : public SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::m_Direction
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Direction_15;
	// UnityEngine.Ray Unity.MARS.MARSHandles.Slider1DHandle::m_Ray
	Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  ___m_Ray_16;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::m_HandleStartPos
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_HandleStartPos_17;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::m_StartNormalizedOffset
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_StartNormalizedOffset_18;
	// System.Single Unity.MARS.MARSHandles.Slider1DHandle::m_StartCenterPosSize
	float ___m_StartCenterPosSize_19;
	// System.Single Unity.MARS.MARSHandles.Slider1DHandle::m_StartHandlePosSize
	float ___m_StartHandlePosSize_20;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::m_LastFramePos
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_LastFramePos_21;

public:
	inline static int32_t get_offset_of_m_Direction_15() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_Direction_15)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Direction_15() const { return ___m_Direction_15; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Direction_15() { return &___m_Direction_15; }
	inline void set_m_Direction_15(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Direction_15 = value;
	}

	inline static int32_t get_offset_of_m_Ray_16() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_Ray_16)); }
	inline Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  get_m_Ray_16() const { return ___m_Ray_16; }
	inline Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * get_address_of_m_Ray_16() { return &___m_Ray_16; }
	inline void set_m_Ray_16(Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  value)
	{
		___m_Ray_16 = value;
	}

	inline static int32_t get_offset_of_m_HandleStartPos_17() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_HandleStartPos_17)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_HandleStartPos_17() const { return ___m_HandleStartPos_17; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_HandleStartPos_17() { return &___m_HandleStartPos_17; }
	inline void set_m_HandleStartPos_17(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_HandleStartPos_17 = value;
	}

	inline static int32_t get_offset_of_m_StartNormalizedOffset_18() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_StartNormalizedOffset_18)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_StartNormalizedOffset_18() const { return ___m_StartNormalizedOffset_18; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_StartNormalizedOffset_18() { return &___m_StartNormalizedOffset_18; }
	inline void set_m_StartNormalizedOffset_18(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_StartNormalizedOffset_18 = value;
	}

	inline static int32_t get_offset_of_m_StartCenterPosSize_19() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_StartCenterPosSize_19)); }
	inline float get_m_StartCenterPosSize_19() const { return ___m_StartCenterPosSize_19; }
	inline float* get_address_of_m_StartCenterPosSize_19() { return &___m_StartCenterPosSize_19; }
	inline void set_m_StartCenterPosSize_19(float value)
	{
		___m_StartCenterPosSize_19 = value;
	}

	inline static int32_t get_offset_of_m_StartHandlePosSize_20() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_StartHandlePosSize_20)); }
	inline float get_m_StartHandlePosSize_20() const { return ___m_StartHandlePosSize_20; }
	inline float* get_address_of_m_StartHandlePosSize_20() { return &___m_StartHandlePosSize_20; }
	inline void set_m_StartHandlePosSize_20(float value)
	{
		___m_StartHandlePosSize_20 = value;
	}

	inline static int32_t get_offset_of_m_LastFramePos_21() { return static_cast<int32_t>(offsetof(Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30, ___m_LastFramePos_21)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_LastFramePos_21() const { return ___m_LastFramePos_21; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_LastFramePos_21() { return &___m_LastFramePos_21; }
	inline void set_m_LastFramePos_21(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_LastFramePos_21 = value;
	}
};


// Unity.MARS.MARSHandles.Slider2DHandle
struct Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06  : public SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider2DHandle::m_LastHitPos
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_LastHitPos_15;

public:
	inline static int32_t get_offset_of_m_LastHitPos_15() { return static_cast<int32_t>(offsetof(Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06, ___m_LastHitPos_15)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_LastHitPos_15() const { return ___m_LastHitPos_15; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_LastHitPos_15() { return &___m_LastHitPos_15; }
	inline void set_m_LastHitPos_15(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_LastHitPos_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// UnityEngine.Material[]
struct MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Material_t8927C00353A72755313F046D0CE85178AE8218EE * m_Items[1];

public:
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Material_t8927C00353A72755313F046D0CE85178AE8218EE * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Material_t8927C00353A72755313F046D0CE85178AE8218EE ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Material_t8927C00353A72755313F046D0CE85178AE8218EE * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// Unity.MARS.MARSHandles.SliderHandleBase[]
struct SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * m_Items[1];

public:
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// Unity.MARS.MARSHandles.RotatorHandle[]
struct RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * m_Items[1];

public:
	inline RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m2C8EE5C13636D67F6C451C4935049F534AEC658F_gshared (Dictionary_2_tBD1E3221EBD04CEBDA49B84779912E91F56B958D * __this, const RuntimeMethod* method);
// !!0 UnityEngine.Resources::Load<System.Object>(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject * Resources_Load_TisRuntimeObject_m39B6A35CFE684CD1FFF77873E20D7297B36A55E8_gshared (String_t* ___path0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponentInParent<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject * Component_GetComponentInParent_TisRuntimeObject_mADA186D1675BEA6779C469918206294354385EC3_gshared (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.Object>::Remove(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool List_1_Remove_m753F7B4281CC4D02C07AE90726F51EF34B588DF7_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<System.Object>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6  List_1_GetEnumerator_m1739A5E25DF502A6984F9B98CFCAC2D3FABCF233_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1/Enumerator<System.Object>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject * Enumerator_get_Current_m9C4EBBD2108B51885E750F927D7936290C8E20EE_gshared_inline (Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6 * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.Object>::Contains(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool List_1_Contains_m99C700668AC6D272188471D2D6B784A2B5636C8E_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Object>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m2E56233762839CE55C67E00AC8DD3D4D3F6C0DF0_gshared (Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1/Enumerator<System.Object>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_mCFB225D9E5E597A1CC8F958E53BEA1367D8AC7B8_gshared (Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6 * __this, const RuntimeMethod* method);
// !!0 UnityEngine.Object::Instantiate<System.Object>(!!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject * Object_Instantiate_TisRuntimeObject_m4039C8E65629D33E1EC84D2505BF1D5DDC936622_gshared (RuntimeObject * ___original0, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::GetComponents<System.Object>(System.Collections.Generic.List`1<!!0>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GameObject_GetComponents_TisRuntimeObject_m05916636D3EA83EDCD2E5DE7CFF6FC53F182A71D_gshared (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * ___results0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponent<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject * Component_GetComponent_TisRuntimeObject_m69D9C576D6DD024C709E29EEADBC8041299A3AA7_gshared (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_gshared (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_gshared (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_gshared (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_gshared (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * __this, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_gshared (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * __this, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_gshared (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * __this, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C_gshared (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C_gshared (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3_gshared (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_gshared (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * __this, RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_gshared (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * __this, RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_gshared (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * __this, RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449  ___obj0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.ScalingUpdatedInfo>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32_gshared (Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * __this, ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1  ___obj0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Clear_m5FB5A9C59D8625FDFB06876C4D8848F0F07ABFD0_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::AddRange(System.Collections.Generic.IEnumerable`1<!0>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_AddRange_m6465DEF706EB529B4227F2AF79338419D517EDF9_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject* ___collection0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mFEB2301A6F28290A828A979BA9CC847B16B3D538_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, int32_t ___capacity0, const RuntimeMethod* method);

// System.Void System.Collections.Generic.Dictionary`2<System.Type,Unity.MARS.MARSHandles.ComponentCache/IComponentCollection>::.ctor()
inline void Dictionary_2__ctor_mEDA9E9B930FC9C880167E6A35E5F7CAAEC864323 (Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED *, const RuntimeMethod*))Dictionary_2__ctor_m2C8EE5C13636D67F6C451C4935049F534AEC658F_gshared)(__this, method);
}
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___x0, Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___y1, const RuntimeMethod* method);
// !!0 UnityEngine.Resources::Load<UnityEngine.GameObject>(System.String)
inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * Resources_Load_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m2A4C89C1E5F65890D408978197DB125739C6000C (String_t* ___path0, const RuntimeMethod* method)
{
	return ((  GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * (*) (String_t*, const RuntimeMethod*))Resources_Load_TisRuntimeObject_m39B6A35CFE684CD1FFF77873E20D7297B36A55E8_gshared)(___path0, method);
}
// System.Void Unity.MARS.MARSHandles.DragBeginInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragBeginInfo__ctor_mEBDAE2DF9605F605D4AA7CB9E1C5DA12F51675CB (DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragEndInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragEndInfo__ctor_mAE40EC2FD71878AC0C04DCD0473E0A0D5C0C7EE9 (DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_initialPosition()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_initialPosition(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_currentPosition()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_currentPosition(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_delta()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_delta_m7F702B6FCEBE8654F97BC7E48352CBFDDF408098_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_delta(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragTranslation::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPosition0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___currentPosition1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta2, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.DragTranslation Unity.MARS.MARSHandles.DragUpdateInfo::get_translation()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_inline (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragUpdateInfo::set_translation(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF_inline (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.DragUpdateInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragUpdateInfo__ctor_m777BDB1251294C2E1B5F5ECA368047B9F70100EC (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleBehaviour::get_context()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E_inline (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleStateColors::UpdateIdleColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_UpdateIdleColor_m0190886B36599357AAF5B3A697D7EB17C414FF0A (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.EditorHandleStateColors::LogWrongContextWarning()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method);
// UnityEngine.GameObject UnityEngine.Component::get_gameObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * Component_get_gameObject_m55DC35B149AFB9157582755383BA954655FE0C5B (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogWarning(System.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogWarning_mE6AF3EFCF84F2296622CD42FBF9EEAF07244C0A8 (RuntimeObject * ___message0, Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___context1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleStateColors::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors__ctor_m68E53B6EC4376C930641B06D4860A8505092375B (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Color__ctor_m679019E6084BF7A6F82590F66F5F695F6A50ECC5 (Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_magenta()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_magenta_m46B928AB3005B062069E5DF9CB271E1373A29FE0 (const RuntimeMethod* method);
// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1 (Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71 * __this, const RuntimeMethod* method);
// System.Boolean UnityEngine.Behaviour::get_isActiveAndEnabled()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Behaviour_get_isActiveAndEnabled_mDD843C0271D492C1E08E0F8DEE8B6F1CFA951BFA (Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::UnregisterFromContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_UnregisterFromContext_m54C7AAE34C22867C7379BCC8C8D87722AEECDEF7 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::RegisterToContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_RegisterToContext_m1586DB5EDC520EE027082BA1431B0C15388ED178 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::SendOnCreatedByContextIfNotAlreadySent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_SendOnCreatedByContextIfNotAlreadySent_m6E0553D83E9CC781FF695A3BF042BA9F65DE79C2 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleBehaviour::GetParentHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleBehaviour_GetParentHandle_m4C7BEADF4C83C1E9B11DE479076B053F1ADE6050 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleContext::GetContext(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * HandleContext_GetContext_m6F03ED6ADC925F850996A919EDE0218C061E13D2 (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___handle0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::set_context(Unity.MARS.MARSHandles.HandleContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_set_context_m0BB7694139366FD7FD8B5D8D962682276CBCF85F (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::RegisterHandleBehaviour(Unity.MARS.MARSHandles.HandleBehaviour)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_RegisterHandleBehaviour_mE27E7AEA2839AF91DAE92F276EC9E065BAF270AF (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___behaviour0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::UnregisterHandleBehaviour(Unity.MARS.MARSHandles.HandleBehaviour)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_UnregisterHandleBehaviour_mA2B2AA02C79942E470AB681261F8C790CFBDCAEA (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___behaviour0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponentInParent<Unity.MARS.MARSHandles.InteractiveHandle>()
inline InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8 (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method)
{
	return ((  InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * (*) (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 *, const RuntimeMethod*))Component_GetComponentInParent_TisRuntimeObject_mADA186D1675BEA6779C469918206294354385EC3_gshared)(__this, method);
}
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED (MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::.ctor(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext__ctor_mB6B690A6E88588172D614816FF57E530464EB6DE (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor()
inline void List_1__ctor_m859B0EE8491FDDEB1A3F7115D334B863E025BBC8 (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle>::.ctor()
inline void List_1__ctor_m4B08F7BE66CF6C1E0652CD16A2413BE7D75A5B40 (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::.ctor()
inline void List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>::Add(!0)
inline void List_1_Add_mCB6E4FC5A548DA624CF4B18D0E6D83FB8FDE3845 (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * __this, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 *, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B *, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
// System.Boolean System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>::Remove(!0)
inline bool List_1_Remove_m664733BB2DD16FD00F2503C7A6569448FF112AD1 (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * __this, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 *, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B *, const RuntimeMethod*))List_1_Remove_m753F7B4281CC4D02C07AE90726F51EF34B588DF7_gshared)(__this, ___item0, method);
}
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>::GetEnumerator()
inline Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68  List_1_GetEnumerator_m2C6D9F87F1CB97F7FD4AC838538016B718EA19C7 (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68  (*) (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 *, const RuntimeMethod*))List_1_GetEnumerator_m1739A5E25DF502A6984F9B98CFCAC2D3FABCF233_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleContext>::get_Current()
inline HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * Enumerator_get_Current_mFA9DA346C8173FC7CD9C3D5A4FD14FC7FCBAA846_inline (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 * __this, const RuntimeMethod* method)
{
	return ((  HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * (*) (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *, const RuntimeMethod*))Enumerator_get_Current_m9C4EBBD2108B51885E750F927D7936290C8E20EE_gshared_inline)(__this, method);
}
// UnityEngine.Transform UnityEngine.GameObject::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * GameObject_get_transform_m16A80BB92B6C8C5AB696E447014D45EDF1E4DE34 (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, const RuntimeMethod* method);
// UnityEngine.Transform UnityEngine.Transform::get_root()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * Transform_get_root_mDEB1F3B4DB26B32CEED6DFFF734F85C79C4DDA91 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<UnityEngine.GameObject>::Contains(!0)
inline bool List_1_Contains_mE508A129A7CB4DC89530674E7854B7F699BB486F (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 *, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, const RuntimeMethod*))List_1_Contains_m99C700668AC6D272188471D2D6B784A2B5636C8E_gshared)(__this, ___item0, method);
}
// System.Boolean System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleContext>::MoveNext()
inline bool Enumerator_MoveNext_m7090935F4B9051282BB0D6DE72B096073274DD33 (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *, const RuntimeMethod*))Enumerator_MoveNext_m2E56233762839CE55C67E00AC8DD3D4D3F6C0DF0_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleContext>::Dispose()
inline void Enumerator_Dispose_m48E109156D5ADB530A13B9DAB915F91DF854194A (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *, const RuntimeMethod*))Enumerator_Dispose_mCFB225D9E5E597A1CC8F958E53BEA1367D8AC7B8_gshared)(__this, method);
}
// UnityEngine.GameObject Unity.MARS.MARSHandles.DefaultHandles::GetPrefab(Unity.MARS.MARSHandles.DefaultHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * DefaultHandles_GetPrefab_mB90B6AC93F3BCF4CE219307DD35B95D1AE82CCA6 (int32_t ___handle0, const RuntimeMethod* method);
// System.Void System.ArgumentNullException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97 (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * __this, String_t* ___paramName0, const RuntimeMethod* method);
// !!0 UnityEngine.Object::Instantiate<UnityEngine.GameObject>(!!0)
inline GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * Object_Instantiate_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m26431AC51B9B7A43FBABD10B4923B72B0C578F33 (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___original0, const RuntimeMethod* method)
{
	return ((  GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * (*) (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, const RuntimeMethod*))Object_Instantiate_TisRuntimeObject_m4039C8E65629D33E1EC84D2505BF1D5DDC936622_gshared)(___original0, method);
}
// System.Void System.Collections.Generic.List`1<UnityEngine.GameObject>::Add(!0)
inline void List_1_Add_m3DD76DE838FA83DF972E0486A296345EB3A7DDF3 (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 *, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
// System.Void Unity.MARS.MARSHandles.HandleContext::SetupObject(UnityEngine.Transform)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SetupObject_m9F246E72F63D5A83D6F04FFCF08DEFDD17983D75 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___transform0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(!0)
inline bool List_1_Remove_mD36BF07C31C1DF947856EFECE89BAF4D6A24DEB7 (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 *, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, const RuntimeMethod*))List_1_Remove_m753F7B4281CC4D02C07AE90726F51EF34B588DF7_gshared)(__this, ___item0, method);
}
// System.Void UnityEngine.Object::DestroyImmediate(UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_DestroyImmediate_mCCED69F4D4C9A4FA3AC30A142CF3D7F085F7C422 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___obj0, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::GetEnumerator()
inline Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, const RuntimeMethod*))List_1_GetEnumerator_m1739A5E25DF502A6984F9B98CFCAC2D3FABCF233_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleBehaviour>::get_Current()
inline HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 * __this, const RuntimeMethod* method)
{
	return ((  HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * (*) (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *, const RuntimeMethod*))Enumerator_get_Current_m9C4EBBD2108B51885E750F927D7936290C8E20EE_gshared_inline)(__this, method);
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoPreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoPreRender_mCC2663CE2A01CC7CEEA9CDAEC565B69AAFC69E3A (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleBehaviour>::MoveNext()
inline bool Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4 (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *, const RuntimeMethod*))Enumerator_MoveNext_m2E56233762839CE55C67E00AC8DD3D4D3F6C0DF0_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.HandleBehaviour>::Dispose()
inline void Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5 (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *, const RuntimeMethod*))Enumerator_Dispose_mCFB225D9E5E597A1CC8F958E53BEA1367D8AC7B8_gshared)(__this, method);
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoPostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoPostRender_m88DA49CC5CA0171F636CFA6391612FECC3B66C30 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::Add(!0)
inline void List_1_Add_m5CAB84213E397FBA644EA314B6F2C6B304D20BE0 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE *, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___x0, Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___y1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle>::Add(!0)
inline void List_1_Add_m84BF7301FB1FDAB49751F01F230B99C4D240FB9F (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 *, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
// System.Boolean System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::Remove(!0)
inline bool List_1_Remove_m66C2969804F6C58F4E6EF1949409DD9D83783A74 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE *, const RuntimeMethod*))List_1_Remove_m753F7B4281CC4D02C07AE90726F51EF34B588DF7_gshared)(__this, ___item0, method);
}
// System.Boolean System.Collections.Generic.List`1<Unity.MARS.MARSHandles.InteractiveHandle>::Remove(!0)
inline bool List_1_Remove_m4A5249E88B4FF796C1E6409C894BD55AE0A8F3D9 (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 *, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, const RuntimeMethod*))List_1_Remove_m753F7B4281CC4D02C07AE90726F51EF34B588DF7_gshared)(__this, ___item0, method);
}
// System.Void Unity.MARS.MARSHandles.HandleContext::InstantiateMaterials(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_InstantiateMaterials_mF696378CDC97731B53544AB66EE5871845F30738 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___go0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::SetContextOnBehaviours(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SetContextOnBehaviours_m71F8DF762CE623E43B6641F1450B95DE4AC684AD (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___gameObject0, const RuntimeMethod* method);
// System.Int32 UnityEngine.Transform::get_childCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Transform_get_childCount_mCBED4F6D3F6A7386C4D97C2C3FD25C383A0BCD05 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Transform UnityEngine.Transform::GetChild(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * Transform_GetChild_mA7D94BEFF0144F76561D9B8FED61C5C939EC1F1C (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, int32_t ___index0, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::GetComponents<UnityEngine.Renderer>(System.Collections.Generic.List`1<!!0>)
inline void GameObject_GetComponents_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m28FCAD0BE737DA09091250839D36AF8A8D22E0C8 (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * ___results0, const RuntimeMethod* method)
{
	((  void (*) (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE *, const RuntimeMethod*))GameObject_GetComponents_TisRuntimeObject_m05916636D3EA83EDCD2E5DE7CFF6FC53F182A71D_gshared)(__this, ___results0, method);
}
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<UnityEngine.Renderer>::GetEnumerator()
inline Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72  List_1_GetEnumerator_mE260B4092AF4305011540A431D02BC928E2B3997 (List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72  (*) (List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE *, const RuntimeMethod*))List_1_GetEnumerator_m1739A5E25DF502A6984F9B98CFCAC2D3FABCF233_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<UnityEngine.Renderer>::get_Current()
inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * Enumerator_get_Current_m1C905C3F07EA78F157C733364DA3A9D6EDC57904_inline (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 * __this, const RuntimeMethod* method)
{
	return ((  Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * (*) (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *, const RuntimeMethod*))Enumerator_get_Current_m9C4EBBD2108B51885E750F927D7936290C8E20EE_gshared_inline)(__this, method);
}
// UnityEngine.Material[] UnityEngine.Renderer::get_sharedMaterials()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* Renderer_get_sharedMaterials_m9B2D432CA8AD8CEC4348E61789CC1BB0C3A00AFD (Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Material::.ctor(UnityEngine.Material)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Material__ctor_mD0C3D9CFAFE0FB858D864092467387D7FA178245 (Material_t8927C00353A72755313F046D0CE85178AE8218EE * __this, Material_t8927C00353A72755313F046D0CE85178AE8218EE * ___source0, const RuntimeMethod* method);
// System.Void UnityEngine.Object::set_hideFlags(UnityEngine.HideFlags)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_set_hideFlags_m7DE229AF60B92F0C68819F77FEB27D775E66F3AC (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Renderer::set_sharedMaterials(UnityEngine.Material[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Renderer_set_sharedMaterials_m9838EC09412E988925C4670E8E355E5EEFE35A25 (Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * __this, MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* ___value0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<UnityEngine.Renderer>::MoveNext()
inline bool Enumerator_MoveNext_m203CD6DEF51BD4293A08C00A7DD3340EC4163549 (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *, const RuntimeMethod*))Enumerator_MoveNext_m2E56233762839CE55C67E00AC8DD3D4D3F6C0DF0_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<UnityEngine.Renderer>::Dispose()
inline void Enumerator_Dispose_mE21E49F8B1BE64C87CBFACE1B4B0D702C501210F (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *, const RuntimeMethod*))Enumerator_Dispose_mCFB225D9E5E597A1CC8F958E53BEA1367D8AC7B8_gshared)(__this, method);
}
// System.Void UnityEngine.GameObject::GetComponents<Unity.MARS.MARSHandles.HandleBehaviour>(System.Collections.Generic.List`1<!!0>)
inline void GameObject_GetComponents_TisHandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE_m40A1BA6F7AFB140C4B32EADA3F965B1926F9AF9E (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___results0, const RuntimeMethod* method)
{
	((  void (*) (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, const RuntimeMethod*))GameObject_GetComponents_TisRuntimeObject_m05916636D3EA83EDCD2E5DE7CFF6FC53F182A71D_gshared)(__this, ___results0, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleContext>::.ctor()
inline void List_1__ctor_m7774C10070F49CBF0F80ADC0E948659B630DDD48 (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<UnityEngine.Renderer>::.ctor()
inline void List_1__ctor_m4AD4610A14E65261162EDC2D813C7F126F1BDD9F (List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// !!0 UnityEngine.Component::GetComponent<UnityEngine.Renderer>()
inline Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * Component_GetComponent_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m436E5B0F17DDEF3CC61F77DEA82B1A92668AF019 (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method)
{
	return ((  Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * (*) (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m69D9C576D6DD024C709E29EEADBC8041299A3AA7_gshared)(__this, method);
}
// UnityEngine.Material UnityEngine.Renderer::get_sharedMaterial()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Material_t8927C00353A72755313F046D0CE85178AE8218EE * Renderer_get_sharedMaterial_m42DF538F0C6EA249B1FB626485D45D083BA74FCC (Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * __this, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Material::get_color()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Material_get_color_m7926F7BE68B4D000306738C1EAABEB7ADFB97821 (Material_t8927C00353A72755313F046D0CE85178AE8218EE * __this, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_white()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_white_mB21E47D20959C3AEC41AF8BA04F63AC89FAF319E (const RuntimeMethod* method);
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleBehaviour::get_ownerHandle()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleStateColors::SetColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___color0, const RuntimeMethod* method);
// System.Void UnityEngine.Material::set_color(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Material_set_color_mC3C88E2389B7132EBF3EB0D1F040545176B795C0 (Material_t8927C00353A72755313F046D0CE85178AE8218EE * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Color__ctor_m9FEDC8486B9D40C01BF10FDC821F5E76C8705494 (Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * __this, float ___r0, float ___g1, float ___b2, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_yellow()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_yellow_m9FD4BDABA7E40E136BE57EE7872CEA6B1B2FA1D1 (const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_grey()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_grey_mB2E29B47327F20233856F933DC00ACADEBFDBDFA (const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour__ctor_mDCF866C43F77DF2B4D1B6279089CBDA13E3ABACF (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Screen::get_dpi()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Screen_get_dpi_m37167A82DE896C738517BBF75BFD70C616CCCF55 (const RuntimeMethod* method);
// UnityEngine.Camera Unity.MARS.MARSHandles.HandleUtility::GetActiveCamera()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * HandleUtility_GetActiveCamera_m6C409B224FC5C09EA3C26137CE29854B4635C3A6 (const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___exists0, const RuntimeMethod* method);
// UnityEngine.Transform UnityEngine.Component::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Transform::get_position()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Subtraction(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Transform::TransformDirection(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Transform_TransformDirection_m6B5E3F0A7C6323159DEC6D9BC035FB53ADD96E91 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___direction0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::Dot(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lhs0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rhs1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Camera::WorldToScreenPoint(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::get_magnitude()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector3_get_magnitude_mDDD40612220D8104E77E993E18A101A69A944991 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Mathf::Max(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_Max_m4CE510E1F1013B33275F01543731A51A58BA0775 (float ___a0, float ___b1, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.HandleUtility::get_pixelsPerPoint()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float HandleUtility_get_pixelsPerPoint_m3244A1169D3C8E0B875E4553A06E19C64FEBCAA6 (const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.HandleUtility::GetHandleSize(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method);
// UnityEngine.Camera UnityEngine.Camera::get_current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * Camera_get_current_m4E5A6D19F422F8DD2CFF4EE80C65B033F24C45D6 (const RuntimeMethod* method);
// UnityEngine.Camera UnityEngine.Camera::get_main()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * Camera_get_main_mC337C621B91591CEF89504C97EF64D717C12871C (const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_zero()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6 (const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector2::op_Implicit(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___v0, const RuntimeMethod* method);
// UnityEngine.Ray UnityEngine.Camera::ScreenPointToRay(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  Camera_ScreenPointToRay_mD385213935A81030EDC604A39FD64761077CFBAB (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___pos0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Plane::Raycast(UnityEngine.Ray,System.Single&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Plane_Raycast_m8E3B0EF5B22DF336430373D4997155B647E99A24 (Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 * __this, Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  ___ray0, float* ___enter1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Ray::get_origin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Ray_get_origin_m0C1B2BFF99CDF5231AC29AC031C161F55B53C1D0 (Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Ray::get_direction()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Ray_get_direction_m2B31F86F19B64474A901B28D3808011AE7A13EFC (Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Plane::ClosestPointOnPlane(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Plane_ClosestPointOnPlane_mDBB63D79FA643E10949FEE1AE692975940716BCE (Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, const RuntimeMethod* method);
// UnityEngine.Shader UnityEngine.Shader::Find(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Shader_tB2355DC4F3CAF20B2F1AB5AABBF37C3555FFBC39 * Shader_Find_m596EC6EBDCA8C9D5D86E2410A319928C1E8E6B5A (String_t* ___name0, const RuntimeMethod* method);
// System.Void UnityEngine.Material::.ctor(UnityEngine.Shader)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Material__ctor_mD2A3BCD3B4F17F5C6E95F3B34DAF4B497B67127E (Material_t8927C00353A72755313F046D0CE85178AE8218EE * __this, Shader_tB2355DC4F3CAF20B2F1AB5AABBF37C3555FFBC39 * ___shader0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponent<UnityEngine.LineRenderer>()
inline LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * Component_GetComponent_TisLineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967_mD5BC9EADE1AA529A5299A4D8B020FB49663DAC3A (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method)
{
	return ((  LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * (*) (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m69D9C576D6DD024C709E29EEADBC8041299A3AA7_gshared)(__this, method);
}
// System.Void UnityEngine.LineRenderer::set_useWorldSpace(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRenderer_set_useWorldSpace_m53AA0FE659EFB041647DB6A29826D20D52CBE148 (LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Camera/CameraCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55 (Delegate_t * ___a0, Delegate_t * ___b1, const RuntimeMethod* method);
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4 (Delegate_t * ___source0, Delegate_t * ___value1, const RuntimeMethod* method);
// System.Void UnityEngine.LineRenderer::SetPosition(System.Int32,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRenderer_SetPosition_mD37DBE4B3E13A838FFD09289BC77DEDB423D620F (LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * __this, int32_t ___index0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationBegun(System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationBegun_mCC5248C8B156875CCB69C04EF3CC4030928F6D78 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationUpdated(System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationUpdated_m78CAF25B6B9DF6E3D2861E4EC0785C9200E5E1F5 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationEnded(System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationEnded_m0B4F029D79BF0523E8FD27D9CA0F97BB96DA45D5 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>::Invoke(!0)
inline void Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0 (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * __this, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA , const RuntimeMethod*))Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_gshared)(__this, ___obj0, method);
}
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>::Invoke(!0)
inline void Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274 (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * __this, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 , const RuntimeMethod*))Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_gshared)(__this, ___obj0, method);
}
// System.Void System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>::Invoke(!0)
inline void Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * __this, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B , const RuntimeMethod*))Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_gshared)(__this, ___obj0, method);
}
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_world_m3B0D23EED0F777F202BB1D961548BCA82FB97BCA_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_local_m73DF0506958FCE368E13C9FC5B2ADA3768E0278A_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationBeginInfo__ctor_m763FC8690EB794D81651F02D9D8BEABBECF3227B (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_world_m4BAE769589BEA155D286581CAE61E7C1987582AC_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_local_m2D09A17E6786D6253B915364A72E18A723539258_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationEndInfo__ctor_m5A00AD63782AE909506A93672A6AA49FC8DA1CA6 (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationBegun(System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationBegun_m9AE3EE4570B763147AEFA1AE11B753944B44AB71 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationUpdated(System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationUpdated_m93071220938A6117BC352F04B6AE2A6C93039B9A (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3 (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationEnded(System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationEnded_m353170AF287A3EFC4B5F0F57F5A39F54C866B5BB (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___value0, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>::Invoke(!0)
inline void Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4 (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * __this, RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *, RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 , const RuntimeMethod*))Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_gshared)(__this, ___obj0, method);
}
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>::Invoke(!0)
inline void Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * __this, RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *, RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 , const RuntimeMethod*))Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_gshared)(__this, ___obj0, method);
}
// System.Void System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>::Invoke(!0)
inline void Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * __this, RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *, RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 , const RuntimeMethod*))Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_gshared)(__this, ___obj0, method);
}
// System.Single Unity.MARS.MARSHandles.RotationInfo::get_total()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float RotationInfo_get_total_mDBAD43EB96B196E258AE3972228C641CC044ED94_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_total(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.RotationInfo::get_delta()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float RotationInfo_get_delta_m9DFA96854C0C0E823AA72EEAC40FDD3D7C6FCD1B_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_delta(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotationInfo::get_axis()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotationInfo_get_axis_mA25AA9C2B63EFD8C2FE3203FBBA3AE4CF957F1B6_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_axis(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationInfo::.ctor(System.Single,System.Single,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356 (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___total0, float ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___axis2, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_world_mB8A3FF1EA7A95E523E3117E234608A46AF7747B6_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_local_m56BA9177C8453541972DE59ED8650BCA589B37F0_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationUpdateInfo__ctor_mC61AC4A057E8B380E36E88C773BDE974E76012E0 (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotatorHandle::get_planeNormal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotatorHandle_get_planeNormal_m8ABD66B52169A49E3F4A84F1A22967C89947CA33 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Plane::.ctor(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Plane__ctor_m5B830C0E99AA5A47EF0D15767828D6E859867E67 (Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___inNormal0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___inPoint1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Transform::get_forward()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Transform::get_worldToLocalMatrix()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Transform_get_worldToLocalMatrix_mE22FDE24767E1DE402D3E7A1C9803379B2E8399D (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Quaternion UnityEngine.Matrix4x4::get_rotation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  Matrix4x4_get_rotation_m3F80DDCCBDC01EBF36D61F382749AE704603C379 (Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Quaternion::op_Multiply(UnityEngine.Quaternion,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D (Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___rotation0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point1, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::SignedAngle(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector3_SignedAngle_m816C32A674665A4C3C9D850FB0A107E69A4D3E0A (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___to1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___axis2, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Transform::get_localToWorldMatrix()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::Scale(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Matrix4x4_Scale_m62CFAE1F96495BD3F39D6FB21385C04B9ACC50ED (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___vector0, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::op_Multiply(UnityEngine.Matrix4x4,UnityEngine.Matrix4x4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Matrix4x4_op_Multiply_mC2B30D333D4399C1693414F1A73D87FB3450F39F (Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___lhs0, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___rhs1, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::set_matrix(UnityEngine.Matrix4x4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C (Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_blue()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_blue_m6D62D515CA10A6E760848E1BFB997E27B90BD07B (const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::set_color(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F (Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawWireSphere(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawWireSphere_m96C425145BBD85CF0192F9DDB3D1A8C69429B78B (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center0, float ___radius1, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawSphere(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawSphere_m50414CF8E502F4D93FC133091DA5E39543D69E91 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center0, float ___radius1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.InteractiveHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractiveHandle__ctor_m9F68782D20A7C744E8CAE02A5ABF5466E10B77B9 (InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::.ctor(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext__ctor_m5A9F38F75675CFDED71F6E8A9EB9CBFD454A55F9 (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_Dispose_mA9A2C9DF652B593532277B1E72F0E19C4B9EB117 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method);
// UnityEngine.GameObject Unity.MARS.MARSHandles.HandleContext::CreateHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * HandleContext_CreateHandle_m9B4F0364872169F2131EE55027F3F10D88CC2102 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___prefab0, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.HandleContext::DestroyHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool HandleContext_DestroyHandle_m980740978281037E35AAF81AF977A3239F5A7881 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___handle0, const RuntimeMethod* method);
// UnityEngine.Camera Unity.MARS.MARSHandles.HandleContext::get_camera()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * HandleContext_get_camera_m3443C04A9BBECC24BE477653D17C0D4ABDA19DFA_inline (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::SendPreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SendPreRender_m74B76DEE727AEEBD46754C8F56DA84492199732E (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext::SendPostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SendPostRender_m0E6C90A66FE58E91DFB35AEC717A2B54DC675553 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass4_0__ctor_m5FB77025DFA10417073AEFFF5E00CA048C7CB6FD (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * __this, const RuntimeMethod* method);
// System.Void System.Action::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_one()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB (const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_delta()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScaleHandle::GetScaleFromTranslation(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___translation0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_total()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingInfo::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initial0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::.ctor(Unity.MARS.MARSHandles.ScalingInfo,Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingUpdatedInfo__ctor_mB6ECDCB50395DECA81F9A05F2D466EA373F980E3 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___world0, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___local1, const RuntimeMethod* method);
// System.Void System.Action`1<Unity.MARS.MARSHandles.ScalingUpdatedInfo>::Invoke(!0)
inline void Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32 (Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * __this, ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1  ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 *, ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 , const RuntimeMethod*))Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32_gshared)(__this, ___obj0, method);
}
// UnityEngine.Vector3 UnityEngine.Transform::get_localScale()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Transform_get_localScale_mD9DF6CA81108C2A6002B5EA2BE25A6CD2723D046 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleUtility::GetHandleSizeVector(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  HandleUtility_GetHandleSizeVector_m78D4E723C7ED24485E9298275671B51C1321437D (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Scale(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Scale_m8805EE8D2586DE7B6143FA35819B3D5CF1981FB3_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// System.Void UnityEngine.Transform::set_localScale(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transform_set_localScale_mF4D1611E48D1BA7566A1E166DC2DACF3ADD8BA3A (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_initial()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_initial_m45D786434B7DD9ADA18E7D4869989CE44823D606_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_initial(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_delta()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_delta_m72D45D52AEB9EDBF7723B3546D5DBAFAC88B1850_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_delta(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_total()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_total_m89F9E2CDDC74901D68AEAA536B8800F4C81F97CF_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_total(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_world_m6900153CD29B1043352AEE9F53E8EB3C82D06185_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::set_world(Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_local_m1C58BC4935A0B0A238779F5FB6A26C9C00B1C400_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::set_local(Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::get_direction()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider1DHandle_get_direction_m76C1782478897A1F2832BE1A22BF2AA6B5096826 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Ray::.ctor(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Ray__ctor_m75B1F651FF47EE6B887105101B7DA61CBF41F83C (Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___origin0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___direction1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Cross(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lhs0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rhs1, const RuntimeMethod* method);
// System.Void UnityEngine.Plane::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Plane__ctor_m9CFA0680D3935F859B6478E777A34168D4F1D19A (Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___c2, const RuntimeMethod* method);
// UnityEngine.Ray Unity.MARS.MARSHandles.Slider1DHandle::get_directionRay()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  Slider1DHandle_get_directionRay_m65817A4729FA853E76C37463624D681D73A9DBFF (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::ProjectPointOnRay(UnityEngine.Vector3,UnityEngine.Ray)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_ProjectPointOnRay_mFAB92ED2A01405B2A6C62EA3C6EA07A4405531ED (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  ___ray1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Division(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Division_mE5ACBFB168FED529587457A83BA98B7DB32E2A05_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::Translate(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Matrix4x4_Translate_m48688727FA7BBA42DF2108C1A9395FC23431AC9A (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___vector0, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_UnaryNegation(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_UnaryNegation_m362EA356F4CADEDB39F965A0DBDED6EA890925F7_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawLine(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawLine_m91F1AA0205C7D53D2AA8E2F1D7B338E601A30823 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___to1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase__ctor_mC21AA163B37015688C7516E4E931793C2CF776B9 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider2DHandle::get_planeNormal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider2DHandle_get_planeNormal_mB4BC7CFB517757D849A2CB6E153C2E68879F3011 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, const RuntimeMethod* method);
// UnityEngine.Quaternion UnityEngine.Transform::get_rotation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  Transform_get_rotation_m4AA3858C00DF4C9614B80352558C4C37D08D2200 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::TRS(UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Matrix4x4_TRS_m0CBC696D0BDF58DCEC40B99BC32C716FAD024CE5 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___pos0, Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___q1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___s2, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawWireCube(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawWireCube_mC526244E50C6E5793D4066C9C99023D5FF8424BF (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___size1, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawCube(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawCube_mCF599EC2E7ABB92994C186412B6E8F39140F66C4 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___size1, const RuntimeMethod* method);
// UnityEngine.Quaternion UnityEngine.Transform::get_localRotation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  Transform_get_localRotation_mA6472AE7509D762965275D79B645A14A9CCF5BE5 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// UnityEngine.Quaternion UnityEngine.Quaternion::Inverse(UnityEngine.Quaternion)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  Quaternion_Inverse_mE2A449C7AC8A40350AAC3761AE1AFC170062CAC9 (Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___rotation0, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Transform::get_localPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Transform_get_localPosition_m527B8B5B625DA9A61E551E0FBCD3BE8CA4539FC2 (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationInfo::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73 (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPos0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___direction3, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_forward()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_forward_m3082920F8A24AA02E4F542B6771EB0B63A91AC90 (const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationBeginInfo__ctor_mD180C3B256CFE02D9CEB33FAFA75A21ED6A9F5A6 (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_normalized()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_normalized_m2FA6DF38F97BDA4CCBDAE12B9FE913A241DAC8D5 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationUpdateInfo__ctor_m9019C924C8F38EB025A0B46F6FD66DA2496D5489 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationEndInfo__ctor_mDD0DC997464BA990D75B0885B1005F4951FD3A2D (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_world_m339141700BFD547B9776F447A2ED644F49FD1722_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_local_m3E176F6CC06B3E3CC69A71B0EF1C01969160D02C_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::get_world()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_world_mAA199ACA11FDC6250AA16B01419642A6D2DA4CDF_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::get_local()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_local_m7391D5DCCD007E17B45CB2F315F53CF2CF5DA34D_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_initialPosition()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_initialPosition_m14AD77A8DF15FFC178D8E958164D5961B68B0CCA_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_initialPosition(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_delta(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_total(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_direction()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_direction_m91A56BB213E808121F10634E88D14AA37B384E62_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_direction(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method);
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext::GetHandleBehaviours()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method);
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext/InteractionState::TakeSnapshot(System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___original0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverEnd_mCBB1C0614CC6840F6FD6A7B9763A77AE32941D23 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverBegin_m283C92835138AB27B36D0ECA2DB013859069C576 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragBegin_m9B13ACAC9CCCD17B2281F33FE62B13E973B446E0 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragEnd_mD2D7C32C132783BE67BE7B0706410BCB6716DDA7 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleContext/InteractionState::SetHovered(Unity.MARS.MARSHandles.InteractiveHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractionState_SetHovered_m0087F94BDA6AA9A2C2731135DFF82ED23541A8FF (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___handle0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverUpdate_m40D91954ED1D85C5DA2F2BA7481899B4E025A581 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragUpdate_mC7166664E160F0AA3CDE675DAD85B4DDE347F73F (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  ___info1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::Clear()
inline void List_1_Clear_m76B072C05663936EA6BFBCC57761E394E9E66ED0 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, const RuntimeMethod*))List_1_Clear_m5FB5A9C59D8625FDFB06876C4D8848F0F07ABFD0_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::AddRange(System.Collections.Generic.IEnumerable`1<!0>)
inline void List_1_AddRange_m10A04B53537D5AB1DC6243720AF3D18EB6BC7923 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, RuntimeObject* ___collection0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, RuntimeObject*, const RuntimeMethod*))List_1_AddRange_m6465DEF706EB529B4227F2AF79338419D517EDF9_gshared)(__this, ___collection0, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>::.ctor(System.Int32)
inline void List_1__ctor_m2E5CD7DAF88452A4E392FE590162D47B2AE87FBF (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *, int32_t, const RuntimeMethod*))List_1__ctor_mFEB2301A6F28290A828A979BA9CC847B16B3D538_gshared)(__this, ___capacity0, method);
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationBegun(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationBegun_m53CB07A3474CF5E466DD495503C1DB276D4FB484 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationUpdated(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationUpdated_m129FD7D6C157CC54C48E6F9DD1E270E5D3EB31A9 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___info1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationEnded(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationEnded_mE4DAB19D2219EBBF63591899AD9CB2A65F660C7D (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___info1, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.ComponentCache::.ctor(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ComponentCache__ctor_mEDA2016FC86896650079F3B9FBAC274FE3286CB9 (ComponentCache_tA2472D14450BFDA2BCCDB41B3917D5C2142237E1 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___root0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_mEDA9E9B930FC9C880167E6A35E5F7CAAEC864323_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// readonly Dictionary<Type, IComponentCollection> m_Collections = new Dictionary<Type, IComponentCollection>();
		Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED * L_0 = (Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED *)il2cpp_codegen_object_new(Dictionary_2_t3BDE520318D190FEF55990492224252C2942F7ED_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_mEDA9E9B930FC9C880167E6A35E5F7CAAEC864323(L_0, /*hidden argument*/Dictionary_2__ctor_mEDA9E9B930FC9C880167E6A35E5F7CAAEC864323_RuntimeMethod_var);
		__this->set_m_Collections_0(L_0);
		// public ComponentCache(GameObject root)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// m_Root = root;
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1 = ___root0;
		__this->set_m_Root_1(L_1);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.GameObject Unity.MARS.MARSHandles.DefaultHandles::GetPrefab(Unity.MARS.MARSHandles.DefaultHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * DefaultHandles_GetPrefab_mB90B6AC93F3BCF4CE219307DD35B95D1AE82CCA6 (int32_t ___handle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Resources_Load_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m2A4C89C1E5F65890D408978197DB125739C6000C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral88B4B87ACB6CA3515F049E15D662A8C185893386);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___handle0;
		if (L_0)
		{
			goto IL_0025;
		}
	}
	{
		// if (s_PositionPrefab == null)
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1 = ((DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_StaticFields*)il2cpp_codegen_static_fields_for(DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_il2cpp_TypeInfo_var))->get_s_PositionPrefab_0();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_1, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_001f;
		}
	}
	{
		// s_PositionPrefab = Resources.Load<GameObject>("Handles/position-handle");
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_3;
		L_3 = Resources_Load_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m2A4C89C1E5F65890D408978197DB125739C6000C(_stringLiteral88B4B87ACB6CA3515F049E15D662A8C185893386, /*hidden argument*/Resources_Load_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m2A4C89C1E5F65890D408978197DB125739C6000C_RuntimeMethod_var);
		((DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_StaticFields*)il2cpp_codegen_static_fields_for(DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_il2cpp_TypeInfo_var))->set_s_PositionPrefab_0(L_3);
	}

IL_001f:
	{
		// return s_PositionPrefab;
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_4 = ((DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_StaticFields*)il2cpp_codegen_static_fields_for(DefaultHandles_t7676353DF11ABF6A14EEA401E8735FDAC2E7D357_il2cpp_TypeInfo_var))->get_s_PositionPrefab_0();
		return L_4;
	}

IL_0025:
	{
		// return null;
		return (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *)NULL;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.DragBeginInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragBeginInfo__ctor_mEBDAE2DF9605F605D4AA7CB9E1C5DA12F51675CB (DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	{
		// public DragBeginInfo(DragTranslation translation) : this()
		il2cpp_codegen_initobj(__this, sizeof(DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 ));
		// this.translation = translation;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = ___translation0;
		__this->set_translation_0(L_0);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void DragBeginInfo__ctor_mEBDAE2DF9605F605D4AA7CB9E1C5DA12F51675CB_AdjustorThunk (RuntimeObject * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 * _thisAdjusted = reinterpret_cast<DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 *>(__this + _offset);
	DragBeginInfo__ctor_mEBDAE2DF9605F605D4AA7CB9E1C5DA12F51675CB(_thisAdjusted, ___translation0, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.DragEndInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragEndInfo__ctor_mAE40EC2FD71878AC0C04DCD0473E0A0D5C0C7EE9 (DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	{
		// public DragEndInfo(DragTranslation translation) : this()
		il2cpp_codegen_initobj(__this, sizeof(DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D ));
		// this.translation = translation;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = ___translation0;
		__this->set_translation_0(L_0);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void DragEndInfo__ctor_mAE40EC2FD71878AC0C04DCD0473E0A0D5C0C7EE9_AdjustorThunk (RuntimeObject * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D * _thisAdjusted = reinterpret_cast<DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D *>(__this + _offset);
	DragEndInfo__ctor_mAE40EC2FD71878AC0C04DCD0473E0A0D5C0C7EE9(_thisAdjusted, ___translation0, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_initialPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918 (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialPositionU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_initialPosition(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialPositionU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_currentPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 currentPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CcurrentPositionU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_currentPosition(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7 (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 currentPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CcurrentPositionU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.DragTranslation::get_delta()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_delta_m7F702B6FCEBE8654F97BC7E48352CBFDDF408098 (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_delta_m7F702B6FCEBE8654F97BC7E48352CBFDDF408098_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = DragTranslation_get_delta_m7F702B6FCEBE8654F97BC7E48352CBFDDF408098_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.DragTranslation::set_delta(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596 (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.DragTranslation::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPosition0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___currentPosition1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta2, const RuntimeMethod* method)
{
	{
		// public DragTranslation(Vector3 initialPosition, Vector3 currentPosition, Vector3 delta) : this()
		il2cpp_codegen_initobj(__this, sizeof(DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA ));
		// this.initialPosition = initialPosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___initialPosition0;
		DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)__this, L_0, /*hidden argument*/NULL);
		// this.currentPosition = currentPosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___currentPosition1;
		DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)__this, L_1, /*hidden argument*/NULL);
		// this.delta = delta;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___delta2;
		DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)__this, L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPosition0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___currentPosition1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta2, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * _thisAdjusted = reinterpret_cast<DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *>(__this + _offset);
	DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE(_thisAdjusted, ___initialPosition0, ___currentPosition1, ___delta2, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.DragTranslation Unity.MARS.MARSHandles.DragUpdateInfo::get_translation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780 (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, const RuntimeMethod* method)
{
	{
		// public DragTranslation translation { get; private set; }
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = __this->get_U3CtranslationU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * _thisAdjusted = reinterpret_cast<DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *>(__this + _offset);
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  _returnValue;
	_returnValue = DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.DragUpdateInfo::set_translation(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___value0, const RuntimeMethod* method)
{
	{
		// public DragTranslation translation { get; private set; }
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = ___value0;
		__this->set_U3CtranslationU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF_AdjustorThunk (RuntimeObject * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * _thisAdjusted = reinterpret_cast<DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *>(__this + _offset);
	DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.DragUpdateInfo::.ctor(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DragUpdateInfo__ctor_m777BDB1251294C2E1B5F5ECA368047B9F70100EC (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	{
		// public DragUpdateInfo(DragTranslation translation) : this()
		il2cpp_codegen_initobj(__this, sizeof(DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 ));
		// this.translation = translation;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = ___translation0;
		DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF_inline((DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *)__this, L_0, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void DragUpdateInfo__ctor_m777BDB1251294C2E1B5F5ECA368047B9F70100EC_AdjustorThunk (RuntimeObject * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translation0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * _thisAdjusted = reinterpret_cast<DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *>(__this + _offset);
	DragUpdateInfo__ctor_m777BDB1251294C2E1B5F5ECA368047B9F70100EC(_thisAdjusted, ___translation0, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean Unity.MARS.MARSHandles.EditorHandleStateColors::get_inEditorContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool EditorHandleStateColors_get_inEditorContext_m7E6A5478182AB6B66DFF89222AF743D046F01814 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// bool inEditorContext => !(context is RuntimeHandleContext);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_0;
		L_0 = HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E_inline(__this, /*hidden argument*/NULL);
		return (bool)((((int32_t)((!(((RuntimeObject*)(RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 *)((RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 *)IsInstClass((RuntimeObject*)L_0, RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
// Unity.MARS.MARSHandles.EditorHandleStateColors/IdleColor Unity.MARS.MARSHandles.EditorHandleStateColors::get_targetIdleColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EditorHandleStateColors_get_targetIdleColor_mEAEDE5DA108DF4C9FFC3E8F8D6A17522A4676AE3 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	{
		// get => m_IdleColor;
		int32_t L_0 = __this->get_m_IdleColor_18();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.EditorHandleStateColors::set_targetIdleColor(Unity.MARS.MARSHandles.EditorHandleStateColors/IdleColor)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EditorHandleStateColors_set_targetIdleColor_m590CA0B1BE0E089CD1DC1752BCD661494D0A1E06 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// if (m_IdleColor == value)
		int32_t L_0 = __this->get_m_IdleColor_18();
		int32_t L_1 = ___value0;
		if ((!(((uint32_t)L_0) == ((uint32_t)L_1))))
		{
			goto IL_000a;
		}
	}
	{
		// return;
		return;
	}

IL_000a:
	{
		// m_IdleColor = value;
		int32_t L_2 = ___value0;
		__this->set_m_IdleColor_18(L_2);
		// UpdateIdleColor();
		HandleStateColors_UpdateIdleColor_m0190886B36599357AAF5B3A697D7EB17C414FF0A(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::get_idleColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  EditorHandleStateColors_get_idleColor_m0CBBD4AB988B5DA0ECE8BAA43AB75439825FD6B2 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// LogWrongContextWarning();
		EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19(__this, /*hidden argument*/NULL);
		// return wrongContextColor;
		IL2CPP_RUNTIME_CLASS_INIT(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->get_wrongContextColor_17();
		return L_0;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::get_hoverColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  EditorHandleStateColors_get_hoverColor_mD9328C1505D72BD5176DDDE8CA4657447FCA308B (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// LogWrongContextWarning();
		EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19(__this, /*hidden argument*/NULL);
		// return wrongContextColor;
		IL2CPP_RUNTIME_CLASS_INIT(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->get_wrongContextColor_17();
		return L_0;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::get_dragColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  EditorHandleStateColors_get_dragColor_mD32E3FA3ACFFA5493222827D5B0B271D8574DD7C (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// LogWrongContextWarning();
		EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19(__this, /*hidden argument*/NULL);
		// return wrongContextColor;
		IL2CPP_RUNTIME_CLASS_INIT(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->get_wrongContextColor_17();
		return L_0;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.EditorHandleStateColors::get_disableColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  EditorHandleStateColors_get_disableColor_m0E785779B78F5DAD0D829ECFFFA569D080B1F2C3 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// LogWrongContextWarning();
		EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19(__this, /*hidden argument*/NULL);
		// return wrongContextColor;
		IL2CPP_RUNTIME_CLASS_INIT(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->get_wrongContextColor_17();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.EditorHandleStateColors::LogWrongContextWarning()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EditorHandleStateColors_LogWrongContextWarning_mAA1B576E337A3BA979A606E6DEA935861F39EE19 (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2A7CB35E4614F3EDE8928AE07B4A3FB68E4CD11A);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!m_WrongContextLogged)
		bool L_0 = __this->get_m_WrongContextLogged_19();
		if (L_0)
		{
			goto IL_001f;
		}
	}
	{
		// Debug.LogWarning(wrongContextWarning, gameObject);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1;
		L_1 = Component_get_gameObject_m55DC35B149AFB9157582755383BA954655FE0C5B(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		Debug_LogWarning_mE6AF3EFCF84F2296622CD42FBF9EEAF07244C0A8(_stringLiteral2A7CB35E4614F3EDE8928AE07B4A3FB68E4CD11A, L_1, /*hidden argument*/NULL);
		// m_WrongContextLogged = true;
		__this->set_m_WrongContextLogged_19((bool)1);
	}

IL_001f:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.EditorHandleStateColors::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EditorHandleStateColors__ctor_mD088DF9EF9E39F35441962772EAC00CBCE74739E (EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725 * __this, const RuntimeMethod* method)
{
	{
		HandleStateColors__ctor_m68E53B6EC4376C930641B06D4860A8505092375B(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.EditorHandleStateColors::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EditorHandleStateColors__cctor_mF3B3BDB7E49E80C843819E89FFA0E985EBD796C8 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// internal static readonly Color editorDefaultDisableColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m679019E6084BF7A6F82590F66F5F695F6A50ECC5((&L_0), (0.5f), (0.5f), (0.5f), (0.5f), /*hidden argument*/NULL);
		((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->set_editorDefaultDisableColor_15(L_0);
		// internal static readonly Color wrongContextColor = Color.magenta;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_1;
		L_1 = Color_get_magenta_m46B928AB3005B062069E5DF9CB271E1373A29FE0(/*hidden argument*/NULL);
		((EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_StaticFields*)il2cpp_codegen_static_fields_for(EditorHandleStateColors_t5CD6589EA54F8514A5C75A60667F1A21DC0C1725_il2cpp_TypeInfo_var))->set_wrongContextColor_17(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EmbeddedAttribute__ctor_mEC7136090D9937F0C4BCA3C38DF4735A22034B67 (EmbeddedAttribute_t736B90E5A44AFAD4A8C4984092F6F12691FF549C * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleBehaviour::get_ownerHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// public InteractiveHandle ownerHandle => m_OwnerHandle;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = __this->get_m_OwnerHandle_5();
		return L_0;
	}
}
// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleBehaviour::get_context()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// get => m_Context;
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_0 = __this->get_m_Context_4();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::set_context(Unity.MARS.MARSHandles.HandleContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_set_context_m0BB7694139366FD7FD8B5D8D962682276CBCF85F (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___value0, const RuntimeMethod* method)
{
	bool G_B4_0 = false;
	bool G_B3_0 = false;
	{
		// if (m_Context == value)
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_0 = __this->get_m_Context_4();
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_1 = ___value0;
		if ((!(((RuntimeObject*)(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B *)L_0) == ((RuntimeObject*)(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B *)L_1))))
		{
			goto IL_000a;
		}
	}
	{
		// return;
		return;
	}

IL_000a:
	{
		// var activeAndEnabled = isActiveAndEnabled;
		bool L_2;
		L_2 = Behaviour_get_isActiveAndEnabled_mDD843C0271D492C1E08E0F8DEE8B6F1CFA951BFA(__this, /*hidden argument*/NULL);
		// if (activeAndEnabled)
		bool L_3 = L_2;
		G_B3_0 = L_3;
		if (!L_3)
		{
			G_B4_0 = L_3;
			goto IL_0019;
		}
	}
	{
		// UnregisterFromContext();
		HandleBehaviour_UnregisterFromContext_m54C7AAE34C22867C7379BCC8C8D87722AEECDEF7(__this, /*hidden argument*/NULL);
		G_B4_0 = G_B3_0;
	}

IL_0019:
	{
		// m_Context = value;
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_4 = ___value0;
		__this->set_m_Context_4(L_4);
		// if (activeAndEnabled && m_Context != null)
		if (!G_B4_0)
		{
			goto IL_0036;
		}
	}
	{
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_5 = __this->get_m_Context_4();
		if (!L_5)
		{
			goto IL_0036;
		}
	}
	{
		// RegisterToContext();
		HandleBehaviour_RegisterToContext_m1586DB5EDC520EE027082BA1431B0C15388ED178(__this, /*hidden argument*/NULL);
		// SendOnCreatedByContextIfNotAlreadySent();
		HandleBehaviour_SendOnCreatedByContextIfNotAlreadySent_m6E0553D83E9CC781FF695A3BF042BA9F65DE79C2(__this, /*hidden argument*/NULL);
	}

IL_0036:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::OnEnableINTERNAL()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_OnEnableINTERNAL_m9B5393A7EF651EFFCA0A65C8064D0195587DBA50 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// m_OwnerHandle = GetParentHandle();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = HandleBehaviour_GetParentHandle_m4C7BEADF4C83C1E9B11DE479076B053F1ADE6050(__this, /*hidden argument*/NULL);
		__this->set_m_OwnerHandle_5(L_0);
		// if (m_Context != null)
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_1 = __this->get_m_Context_4();
		if (!L_1)
		{
			goto IL_0021;
		}
	}
	{
		// RegisterToContext();
		HandleBehaviour_RegisterToContext_m1586DB5EDC520EE027082BA1431B0C15388ED178(__this, /*hidden argument*/NULL);
		// SendOnCreatedByContextIfNotAlreadySent();
		HandleBehaviour_SendOnCreatedByContextIfNotAlreadySent_m6E0553D83E9CC781FF695A3BF042BA9F65DE79C2(__this, /*hidden argument*/NULL);
		// }
		return;
	}

IL_0021:
	{
		// context = HandleContext.GetContext(gameObject);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_2;
		L_2 = Component_get_gameObject_m55DC35B149AFB9157582755383BA954655FE0C5B(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_3;
		L_3 = HandleContext_GetContext_m6F03ED6ADC925F850996A919EDE0218C061E13D2(L_2, /*hidden argument*/NULL);
		HandleBehaviour_set_context_m0BB7694139366FD7FD8B5D8D962682276CBCF85F(__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::SendOnCreatedByContextIfNotAlreadySent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_SendOnCreatedByContextIfNotAlreadySent_m6E0553D83E9CC781FF695A3BF042BA9F65DE79C2 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// if (!m_CreatedEventSent)
		bool L_0 = __this->get_m_CreatedEventSent_7();
		if (L_0)
		{
			goto IL_0015;
		}
	}
	{
		// m_CreatedEventSent = true;
		__this->set_m_CreatedEventSent_7((bool)1);
		// OnCreatedByContext();
		VirtActionInvoker0::Invoke(5 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::OnCreatedByContext() */, __this);
	}

IL_0015:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::OnDisableINTERNAL()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_OnDisableINTERNAL_m0A9B51423FACBE6FECFCF6E165DA2661CDE806F4 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// UnregisterFromContext();
		HandleBehaviour_UnregisterFromContext_m54C7AAE34C22867C7379BCC8C8D87722AEECDEF7(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::RegisterToContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_RegisterToContext_m1586DB5EDC520EE027082BA1431B0C15388ED178 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * G_B4_0 = NULL;
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * G_B3_0 = NULL;
	{
		// if (m_Registered)
		bool L_0 = __this->get_m_Registered_6();
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// context?.RegisterHandleBehaviour(this);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_1;
		L_1 = HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E_inline(__this, /*hidden argument*/NULL);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_2 = L_1;
		G_B3_0 = L_2;
		if (L_2)
		{
			G_B4_0 = L_2;
			goto IL_0015;
		}
	}
	{
		goto IL_001b;
	}

IL_0015:
	{
		NullCheck(G_B4_0);
		HandleContext_RegisterHandleBehaviour_mE27E7AEA2839AF91DAE92F276EC9E065BAF270AF(G_B4_0, __this, /*hidden argument*/NULL);
	}

IL_001b:
	{
		// m_Registered = true;
		__this->set_m_Registered_6((bool)1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::UnregisterFromContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_UnregisterFromContext_m54C7AAE34C22867C7379BCC8C8D87722AEECDEF7 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * G_B4_0 = NULL;
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * G_B3_0 = NULL;
	{
		// if (!m_Registered)
		bool L_0 = __this->get_m_Registered_6();
		if (L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// context?.UnregisterHandleBehaviour(this);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_1;
		L_1 = HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E_inline(__this, /*hidden argument*/NULL);
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_2 = L_1;
		G_B3_0 = L_2;
		if (L_2)
		{
			G_B4_0 = L_2;
			goto IL_0015;
		}
	}
	{
		goto IL_001b;
	}

IL_0015:
	{
		NullCheck(G_B4_0);
		HandleContext_UnregisterHandleBehaviour_mA2B2AA02C79942E470AB681261F8C790CFBDCAEA(G_B4_0, __this, /*hidden argument*/NULL);
	}

IL_001b:
	{
		// m_Registered = false;
		__this->set_m_Registered_6((bool)0);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::OnTransformParentChanged()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_OnTransformParentChanged_m029EDA581B0B09B408EA8225B72A898E3508D4EE (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// m_OwnerHandle = GetParentHandle();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = HandleBehaviour_GetParentHandle_m4C7BEADF4C83C1E9B11DE479076B053F1ADE6050(__this, /*hidden argument*/NULL);
		__this->set_m_OwnerHandle_5(L_0);
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleBehaviour::GetParentHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleBehaviour_GetParentHandle_m4C7BEADF4C83C1E9B11DE479076B053F1ADE6050 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return GetComponentInParent<InteractiveHandle>();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8(__this, /*hidden argument*/Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8_RuntimeMethod_var);
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragBegin_m9B13ACAC9CCCD17B2281F33FE62B13E973B446E0 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method)
{
	{
		// DragBegin(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  >::Invoke(6 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragUpdate_mC7166664E160F0AA3CDE675DAD85B4DDE347F73F (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  ___info1, const RuntimeMethod* method)
{
	{
		// DragUpdate(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  >::Invoke(7 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoDragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoDragEnd_mD2D7C32C132783BE67BE7B0706410BCB6716DDA7 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method)
{
	{
		// DragEnd(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  >::Invoke(8 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverBegin_m283C92835138AB27B36D0ECA2DB013859069C576 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  ___info1, const RuntimeMethod* method)
{
	{
		// HoverBegin(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  >::Invoke(9 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverBeginInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverUpdate_m40D91954ED1D85C5DA2F2BA7481899B4E025A581 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  ___info1, const RuntimeMethod* method)
{
	{
		// HoverUpdate(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  >::Invoke(10 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverUpdateInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoHoverEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoHoverEnd_mCBB1C0614CC6840F6FD6A7B9763A77AE32941D23 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  ___info1, const RuntimeMethod* method)
{
	{
		// HoverEnd(target, info);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  L_1 = ___info1;
		VirtActionInvoker2< InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *, HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  >::Invoke(11 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverEndInfo) */, __this, L_0, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoPreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoPreRender_mCC2663CE2A01CC7CEEA9CDAEC565B69AAFC69E3A (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	{
		// PreRender(camera);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera0;
		VirtActionInvoker1< Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * >::Invoke(12 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::PreRender(UnityEngine.Camera) */, __this, L_0);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DoPostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DoPostRender_m88DA49CC5CA0171F636CFA6391612FECC3B66C30 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	{
		// PostRender(camera);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera0;
		VirtActionInvoker1< Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * >::Invoke(13 /* System.Void Unity.MARS.MARSHandles.HandleBehaviour::PostRender(UnityEngine.Camera) */, __this, L_0);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::OnCreatedByContext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_OnCreatedByContext_mD484235C9AB031A73CC37A47F77B95BD63E908C0 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// protected virtual void OnCreatedByContext() {}
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DragBegin_mBAAB79DB694F160E29999FF3A7A64C7C77546294 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void DragBegin(InteractiveHandle target, DragBeginInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DragUpdate_m395CA5186803C8D7A8A8C3D202C3E5B9BDED2AEB (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void DragUpdate(InteractiveHandle target, DragUpdateInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::DragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_DragEnd_mDD8AD341558A5CCBCB7C931C1171FDD6956BD861 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void DragEnd(InteractiveHandle target, DragEndInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_HoverBegin_m45C69942C9FF4390B56755FC26A4BAE6B69F5D5A (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void HoverBegin(InteractiveHandle target, HoverBeginInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_HoverUpdate_m01FDD82687E8DF06815C464CCA1D03E58C9F84E2 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void HoverUpdate(InteractiveHandle target, HoverUpdateInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::HoverEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_HoverEnd_m2E694FB34FF3F1BF3FE0FCC793D832C89BCA1C13 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  ___info1, const RuntimeMethod* method)
{
	{
		// protected virtual void HoverEnd(InteractiveHandle target, HoverEndInfo info) { }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::PreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_PreRender_m4574B8644D206E04C7D7B80310FDD060E8686C7F (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	{
		// protected virtual void PreRender(Camera camera) {}
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::PostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour_PostRender_m4ABB302B25174DC5888CAEAE4B4A07DCCAA57855 (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	{
		// protected virtual void PostRender(Camera camera) {}
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleBehaviour__ctor_mDCF866C43F77DF2B4D1B6279089CBDA13E3ABACF (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Camera Unity.MARS.MARSHandles.HandleContext::get_camera()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * HandleContext_get_camera_m3443C04A9BBECC24BE477653D17C0D4ABDA19DFA (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Camera; }
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = __this->get_m_Camera_6();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::set_camera(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_set_camera_m38A628B40342FF44384DF3D3F40500AE1F367E1A (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Camera = value; }
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___value0;
		__this->set_m_Camera_6(L_0);
		// set { m_Camera = value; }
		return;
	}
}
// System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject> Unity.MARS.MARSHandles.HandleContext::get_handles()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* HandleContext_get_handles_mDA4FDCFD0C9607AFF3A4692E417B60B41C655694 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// get { return m_RawHandles; }
		List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * L_0 = __this->get_m_RawHandles_3();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext__ctor_mC891FB4B1E3255713C18A97A26808977686A0D95 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// protected HandleContext() : this(null) {}
		HandleContext__ctor_mB6B690A6E88588172D614816FF57E530464EB6DE(__this, (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C *)NULL, /*hidden argument*/NULL);
		// protected HandleContext() : this(null) {}
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::.ctor(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext__ctor_mB6B690A6E88588172D614816FF57E530464EB6DE (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mCB6E4FC5A548DA624CF4B18D0E6D83FB8FDE3845_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m4B08F7BE66CF6C1E0652CD16A2413BE7D75A5B40_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m859B0EE8491FDDEB1A3F7115D334B863E025BBC8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// readonly List<GameObject> m_RawHandles = new List<GameObject>();
		List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * L_0 = (List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 *)il2cpp_codegen_object_new(List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5_il2cpp_TypeInfo_var);
		List_1__ctor_m859B0EE8491FDDEB1A3F7115D334B863E025BBC8(L_0, /*hidden argument*/List_1__ctor_m859B0EE8491FDDEB1A3F7115D334B863E025BBC8_RuntimeMethod_var);
		__this->set_m_RawHandles_3(L_0);
		// readonly List<InteractiveHandle> m_InteractiveHandles = new List<InteractiveHandle>();
		List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * L_1 = (List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 *)il2cpp_codegen_object_new(List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331_il2cpp_TypeInfo_var);
		List_1__ctor_m4B08F7BE66CF6C1E0652CD16A2413BE7D75A5B40(L_1, /*hidden argument*/List_1__ctor_m4B08F7BE66CF6C1E0652CD16A2413BE7D75A5B40_RuntimeMethod_var);
		__this->set_m_InteractiveHandles_4(L_1);
		// readonly List<HandleBehaviour> m_HandleBehaviours = new List<HandleBehaviour>();
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_2 = (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *)il2cpp_codegen_object_new(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6(L_2, /*hidden argument*/List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6_RuntimeMethod_var);
		__this->set_m_HandleBehaviours_5(L_2);
		// protected HandleContext(Camera camera)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// m_Camera = camera;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = ___camera0;
		__this->set_m_Camera_6(L_3);
		// s_Contexts.Add(this);
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * L_4 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_Contexts_0();
		NullCheck(L_4);
		List_1_Add_mCB6E4FC5A548DA624CF4B18D0E6D83FB8FDE3845(L_4, __this, /*hidden argument*/List_1_Add_mCB6E4FC5A548DA624CF4B18D0E6D83FB8FDE3845_RuntimeMethod_var);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_Dispose_mA9A2C9DF652B593532277B1E72F0E19C4B9EB117 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Remove_m664733BB2DD16FD00F2503C7A6569448FF112AD1_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// s_Contexts.Remove(this);
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * L_0 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_Contexts_0();
		NullCheck(L_0);
		bool L_1;
		L_1 = List_1_Remove_m664733BB2DD16FD00F2503C7A6569448FF112AD1(L_0, __this, /*hidden argument*/List_1_Remove_m664733BB2DD16FD00F2503C7A6569448FF112AD1_RuntimeMethod_var);
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.HandleContext Unity.MARS.MARSHandles.HandleContext::GetContext(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * HandleContext_GetContext_m6F03ED6ADC925F850996A919EDE0218C061E13D2 (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___handle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m48E109156D5ADB530A13B9DAB915F91DF854194A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m7090935F4B9051282BB0D6DE72B096073274DD33_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_mFA9DA346C8173FC7CD9C3D5A4FD14FC7FCBAA846_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Contains_mE508A129A7CB4DC89530674E7854B7F699BB486F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m2C6D9F87F1CB97F7FD4AC838538016B718EA19C7_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68  V_0;
	memset((&V_0), 0, sizeof(V_0));
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * V_1 = NULL;
	HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * V_2 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 2> __leave_targets;
	{
		// foreach (var context in s_Contexts)
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * L_0 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_Contexts_0();
		NullCheck(L_0);
		Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68  L_1;
		L_1 = List_1_GetEnumerator_m2C6D9F87F1CB97F7FD4AC838538016B718EA19C7(L_0, /*hidden argument*/List_1_GetEnumerator_m2C6D9F87F1CB97F7FD4AC838538016B718EA19C7_RuntimeMethod_var);
		V_0 = L_1;
	}

IL_000b:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0039;
		}

IL_000d:
		{
			// foreach (var context in s_Contexts)
			HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_2;
			L_2 = Enumerator_get_Current_mFA9DA346C8173FC7CD9C3D5A4FD14FC7FCBAA846_inline((Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *)(&V_0), /*hidden argument*/Enumerator_get_Current_mFA9DA346C8173FC7CD9C3D5A4FD14FC7FCBAA846_RuntimeMethod_var);
			V_1 = L_2;
			// if (context != null
			//     && context.m_RawHandles.Contains(handle.transform.root.gameObject))
			HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_3 = V_1;
			if (!L_3)
			{
				goto IL_0039;
			}
		}

IL_0018:
		{
			HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_4 = V_1;
			NullCheck(L_4);
			List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * L_5 = L_4->get_m_RawHandles_3();
			GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_6 = ___handle0;
			NullCheck(L_6);
			Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_7;
			L_7 = GameObject_get_transform_m16A80BB92B6C8C5AB696E447014D45EDF1E4DE34(L_6, /*hidden argument*/NULL);
			NullCheck(L_7);
			Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_8;
			L_8 = Transform_get_root_mDEB1F3B4DB26B32CEED6DFFF734F85C79C4DDA91(L_7, /*hidden argument*/NULL);
			NullCheck(L_8);
			GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_9;
			L_9 = Component_get_gameObject_m55DC35B149AFB9157582755383BA954655FE0C5B(L_8, /*hidden argument*/NULL);
			NullCheck(L_5);
			bool L_10;
			L_10 = List_1_Contains_mE508A129A7CB4DC89530674E7854B7F699BB486F(L_5, L_9, /*hidden argument*/List_1_Contains_mE508A129A7CB4DC89530674E7854B7F699BB486F_RuntimeMethod_var);
			if (!L_10)
			{
				goto IL_0039;
			}
		}

IL_0035:
		{
			// return context;
			HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_11 = V_1;
			V_2 = L_11;
			IL2CPP_LEAVE(0x54, FINALLY_0044);
		}

IL_0039:
		{
			// foreach (var context in s_Contexts)
			bool L_12;
			L_12 = Enumerator_MoveNext_m7090935F4B9051282BB0D6DE72B096073274DD33((Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *)(&V_0), /*hidden argument*/Enumerator_MoveNext_m7090935F4B9051282BB0D6DE72B096073274DD33_RuntimeMethod_var);
			if (L_12)
			{
				goto IL_000d;
			}
		}

IL_0042:
		{
			IL2CPP_LEAVE(0x52, FINALLY_0044);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0044;
	}

FINALLY_0044:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m48E109156D5ADB530A13B9DAB915F91DF854194A((Enumerator_t9148563EC65B874BE963ABB569042BAB8ACFBD68 *)(&V_0), /*hidden argument*/Enumerator_Dispose_m48E109156D5ADB530A13B9DAB915F91DF854194A_RuntimeMethod_var);
		IL2CPP_END_FINALLY(68)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(68)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x54, IL_0054)
		IL2CPP_JUMP_TBL(0x52, IL_0052)
	}

IL_0052:
	{
		// return null;
		return (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B *)NULL;
	}

IL_0054:
	{
		// }
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_13 = V_2;
		return L_13;
	}
}
// UnityEngine.GameObject Unity.MARS.MARSHandles.HandleContext::CreateHandle(Unity.MARS.MARSHandles.DefaultHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * HandleContext_CreateHandle_mBA9A0B1439F442D10A8BA598CA560EE2E86D35BC (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, int32_t ___handle0, const RuntimeMethod* method)
{
	{
		// return CreateHandle(DefaultHandles.GetPrefab(handle));
		int32_t L_0 = ___handle0;
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1;
		L_1 = DefaultHandles_GetPrefab_mB90B6AC93F3BCF4CE219307DD35B95D1AE82CCA6(L_0, /*hidden argument*/NULL);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_2;
		L_2 = VirtFuncInvoker1< GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * >::Invoke(9 /* UnityEngine.GameObject Unity.MARS.MARSHandles.HandleContext::CreateHandle(UnityEngine.GameObject) */, __this, L_1);
		return L_2;
	}
}
// UnityEngine.GameObject Unity.MARS.MARSHandles.HandleContext::CreateHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * HandleContext_CreateHandle_m9B4F0364872169F2131EE55027F3F10D88CC2102 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___prefab0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m3DD76DE838FA83DF972E0486A296345EB3A7DDF3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_Instantiate_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m26431AC51B9B7A43FBABD10B4923B72B0C578F33_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * V_0 = NULL;
	{
		// if (prefab == null)
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___prefab0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0014;
		}
	}
	{
		// throw new ArgumentNullException(nameof(prefab));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_2 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral4B247C13053AB16D1668B60F2A407C881E8EEC64)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&HandleContext_CreateHandle_m9B4F0364872169F2131EE55027F3F10D88CC2102_RuntimeMethod_var)));
	}

IL_0014:
	{
		// var obj = Object.Instantiate(prefab);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_3 = ___prefab0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_4;
		L_4 = Object_Instantiate_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m26431AC51B9B7A43FBABD10B4923B72B0C578F33(L_3, /*hidden argument*/Object_Instantiate_TisGameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319_m26431AC51B9B7A43FBABD10B4923B72B0C578F33_RuntimeMethod_var);
		V_0 = L_4;
		// m_RawHandles.Add(obj);
		List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * L_5 = __this->get_m_RawHandles_3();
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_6 = V_0;
		NullCheck(L_5);
		List_1_Add_m3DD76DE838FA83DF972E0486A296345EB3A7DDF3(L_5, L_6, /*hidden argument*/List_1_Add_m3DD76DE838FA83DF972E0486A296345EB3A7DDF3_RuntimeMethod_var);
		// SetupObject(obj.transform);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_7 = V_0;
		NullCheck(L_7);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_8;
		L_8 = GameObject_get_transform_m16A80BB92B6C8C5AB696E447014D45EDF1E4DE34(L_7, /*hidden argument*/NULL);
		HandleContext_SetupObject_m9F246E72F63D5A83D6F04FFCF08DEFDD17983D75(__this, L_8, /*hidden argument*/NULL);
		// return obj;
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_9 = V_0;
		return L_9;
	}
}
// System.Boolean Unity.MARS.MARSHandles.HandleContext::DestroyHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool HandleContext_DestroyHandle_m980740978281037E35AAF81AF977A3239F5A7881 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___handle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Remove_mD36BF07C31C1DF947856EFECE89BAF4D6A24DEB7_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (handle == null)
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___handle0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0014;
		}
	}
	{
		// throw new ArgumentNullException(nameof(handle));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_2 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralFFE3A1B73CD7FC81540FBBE737435B0A887629D5)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&HandleContext_DestroyHandle_m980740978281037E35AAF81AF977A3239F5A7881_RuntimeMethod_var)));
	}

IL_0014:
	{
		// if (m_RawHandles.Remove(handle))
		List_1_t6D0A10F47F3440798295D2FFFC6D016477AF38E5 * L_3 = __this->get_m_RawHandles_3();
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_4 = ___handle0;
		NullCheck(L_3);
		bool L_5;
		L_5 = List_1_Remove_mD36BF07C31C1DF947856EFECE89BAF4D6A24DEB7(L_3, L_4, /*hidden argument*/List_1_Remove_mD36BF07C31C1DF947856EFECE89BAF4D6A24DEB7_RuntimeMethod_var);
		if (!L_5)
		{
			goto IL_002a;
		}
	}
	{
		// Object.DestroyImmediate(handle);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_6 = ___handle0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		Object_DestroyImmediate_mCCED69F4D4C9A4FA3AC30A142CF3D7F085F7C422(L_6, /*hidden argument*/NULL);
		// return true;
		return (bool)1;
	}

IL_002a:
	{
		// return false;
		return (bool)0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::SendPreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SendPreRender_m74B76DEE727AEEBD46754C8F56DA84492199732E (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// foreach (var behaviour in m_HandleBehaviours)
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		NullCheck(L_0);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_1;
		L_1 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_0, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_0 = L_1;
	}

IL_000c:
	try
	{ // begin try (depth: 1)
		{
			goto IL_001b;
		}

IL_000e:
		{
			// foreach (var behaviour in m_HandleBehaviours)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_2;
			L_2 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			// behaviour.DoPreRender(camera);
			Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = ___camera0;
			NullCheck(L_2);
			HandleBehaviour_DoPreRender_mCC2663CE2A01CC7CEEA9CDAEC565B69AAFC69E3A(L_2, L_3, /*hidden argument*/NULL);
		}

IL_001b:
		{
			// foreach (var behaviour in m_HandleBehaviours)
			bool L_4;
			L_4 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_4)
			{
				goto IL_000e;
			}
		}

IL_0024:
		{
			IL2CPP_LEAVE(0x34, FINALLY_0026);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0026;
	}

FINALLY_0026:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(38)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(38)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x34, IL_0034)
	}

IL_0034:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::SendPostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SendPostRender_m0E6C90A66FE58E91DFB35AEC717A2B54DC675553 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// foreach (var behaviour in m_HandleBehaviours)
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		NullCheck(L_0);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_1;
		L_1 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_0, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_0 = L_1;
	}

IL_000c:
	try
	{ // begin try (depth: 1)
		{
			goto IL_001b;
		}

IL_000e:
		{
			// foreach (var behaviour in m_HandleBehaviours)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_2;
			L_2 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			// behaviour.DoPostRender(camera);
			Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = ___camera0;
			NullCheck(L_2);
			HandleBehaviour_DoPostRender_m88DA49CC5CA0171F636CFA6391612FECC3B66C30(L_2, L_3, /*hidden argument*/NULL);
		}

IL_001b:
		{
			// foreach (var behaviour in m_HandleBehaviours)
			bool L_4;
			L_4 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_4)
			{
				goto IL_000e;
			}
		}

IL_0024:
		{
			IL2CPP_LEAVE(0x34, FINALLY_0026);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0026;
	}

FINALLY_0026:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(38)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(38)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x34, IL_0034)
	}

IL_0034:
	{
		// }
		return;
	}
}
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext::GetHandleBehaviours()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// return m_HandleBehaviours;
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::RegisterHandleBehaviour(Unity.MARS.MARSHandles.HandleBehaviour)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_RegisterHandleBehaviour_mE27E7AEA2839AF91DAE92F276EC9E065BAF270AF (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___behaviour0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m5CAB84213E397FBA644EA314B6F2C6B304D20BE0_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m84BF7301FB1FDAB49751F01F230B99C4D240FB9F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * V_0 = NULL;
	{
		// m_HandleBehaviours.Add(behaviour);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_1 = ___behaviour0;
		NullCheck(L_0);
		List_1_Add_m5CAB84213E397FBA644EA314B6F2C6B304D20BE0(L_0, L_1, /*hidden argument*/List_1_Add_m5CAB84213E397FBA644EA314B6F2C6B304D20BE0_RuntimeMethod_var);
		// var interactiveHandle = behaviour as InteractiveHandle;
		HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_2 = ___behaviour0;
		V_0 = ((InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *)IsInstClass((RuntimeObject*)L_2, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_il2cpp_TypeInfo_var));
		// if (interactiveHandle != null)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_3 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_3, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_0028;
		}
	}
	{
		// m_InteractiveHandles.Add(interactiveHandle);
		List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * L_5 = __this->get_m_InteractiveHandles_4();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_6 = V_0;
		NullCheck(L_5);
		List_1_Add_m84BF7301FB1FDAB49751F01F230B99C4D240FB9F(L_5, L_6, /*hidden argument*/List_1_Add_m84BF7301FB1FDAB49751F01F230B99C4D240FB9F_RuntimeMethod_var);
	}

IL_0028:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::UnregisterHandleBehaviour(Unity.MARS.MARSHandles.HandleBehaviour)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_UnregisterHandleBehaviour_mA2B2AA02C79942E470AB681261F8C790CFBDCAEA (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * ___behaviour0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Remove_m4A5249E88B4FF796C1E6409C894BD55AE0A8F3D9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Remove_m66C2969804F6C58F4E6EF1949409DD9D83783A74_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * V_0 = NULL;
	{
		// m_HandleBehaviours.Remove(behaviour);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_1 = ___behaviour0;
		NullCheck(L_0);
		bool L_2;
		L_2 = List_1_Remove_m66C2969804F6C58F4E6EF1949409DD9D83783A74(L_0, L_1, /*hidden argument*/List_1_Remove_m66C2969804F6C58F4E6EF1949409DD9D83783A74_RuntimeMethod_var);
		// var interactiveHandle = behaviour as InteractiveHandle;
		HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_3 = ___behaviour0;
		V_0 = ((InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *)IsInstClass((RuntimeObject*)L_3, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_il2cpp_TypeInfo_var));
		// if (interactiveHandle != null)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_4 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_5;
		L_5 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_4, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_002a;
		}
	}
	{
		// m_InteractiveHandles.Remove(interactiveHandle);
		List_1_t67BDACAD549B70C394DA1E6281432CAC335BD331 * L_6 = __this->get_m_InteractiveHandles_4();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_7 = V_0;
		NullCheck(L_6);
		bool L_8;
		L_8 = List_1_Remove_m4A5249E88B4FF796C1E6409C894BD55AE0A8F3D9(L_6, L_7, /*hidden argument*/List_1_Remove_m4A5249E88B4FF796C1E6409C894BD55AE0A8F3D9_RuntimeMethod_var);
	}

IL_002a:
	{
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleContext::GetHandle(Unity.MARS.MARSHandles.Picking.IPickingTarget)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleContext_GetHandle_m1304BC61417A744CDEAA1CD2FFDEE3EBDA481EF6 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, RuntimeObject* ___pickingTarget0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A * V_0 = NULL;
	{
		// MonoBehaviour behaviour = pickingTarget as MonoBehaviour;
		RuntimeObject* L_0 = ___pickingTarget0;
		V_0 = ((MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A *)IsInstClass((RuntimeObject*)L_0, MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A_il2cpp_TypeInfo_var));
		// if (behaviour == null)
		MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A * L_1 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_1, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		// return null;
		return (InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F *)NULL;
	}

IL_0012:
	{
		// return behaviour.GetComponentInParent<InteractiveHandle>();
		MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A * L_3 = V_0;
		NullCheck(L_3);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_4;
		L_4 = Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8(L_3, /*hidden argument*/Component_GetComponentInParent_TisInteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F_mC80A5C183F17049E31DB6BA312B263FC1BB6F7B8_RuntimeMethod_var);
		return L_4;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::SetupObject(UnityEngine.Transform)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SetupObject_m9F246E72F63D5A83D6F04FFCF08DEFDD17983D75 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___transform0, const RuntimeMethod* method)
{
	GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		// var go = transform.gameObject;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = ___transform0;
		NullCheck(L_0);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1;
		L_1 = Component_get_gameObject_m55DC35B149AFB9157582755383BA954655FE0C5B(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		// InstantiateMaterials(go);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_2 = V_0;
		HandleContext_InstantiateMaterials_mF696378CDC97731B53544AB66EE5871845F30738(__this, L_2, /*hidden argument*/NULL);
		// SetContextOnBehaviours(go);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_3 = V_0;
		HandleContext_SetContextOnBehaviours_m71F8DF762CE623E43B6641F1450B95DE4AC684AD(__this, L_3, /*hidden argument*/NULL);
		// for (int i = 0, count = transform.childCount; i < count; ++i)
		V_1 = 0;
		// for (int i = 0, count = transform.childCount; i < count; ++i)
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_4 = ___transform0;
		NullCheck(L_4);
		int32_t L_5;
		L_5 = Transform_get_childCount_mCBED4F6D3F6A7386C4D97C2C3FD25C383A0BCD05(L_4, /*hidden argument*/NULL);
		V_2 = L_5;
		goto IL_0031;
	}

IL_0020:
	{
		// SetupObject(transform.GetChild(i));
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_6 = ___transform0;
		int32_t L_7 = V_1;
		NullCheck(L_6);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_8;
		L_8 = Transform_GetChild_mA7D94BEFF0144F76561D9B8FED61C5C939EC1F1C(L_6, L_7, /*hidden argument*/NULL);
		HandleContext_SetupObject_m9F246E72F63D5A83D6F04FFCF08DEFDD17983D75(__this, L_8, /*hidden argument*/NULL);
		// for (int i = 0, count = transform.childCount; i < count; ++i)
		int32_t L_9 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1));
	}

IL_0031:
	{
		// for (int i = 0, count = transform.childCount; i < count; ++i)
		int32_t L_10 = V_1;
		int32_t L_11 = V_2;
		if ((((int32_t)L_10) < ((int32_t)L_11)))
		{
			goto IL_0020;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::InstantiateMaterials(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_InstantiateMaterials_mF696378CDC97731B53544AB66EE5871845F30738 (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___go0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mE21E49F8B1BE64C87CBFACE1B4B0D702C501210F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m203CD6DEF51BD4293A08C00A7DD3340EC4163549_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m1C905C3F07EA78F157C733364DA3A9D6EDC57904_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponents_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m28FCAD0BE737DA09091250839D36AF8A8D22E0C8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_mE260B4092AF4305011540A431D02BC928E2B3997_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Material_t8927C00353A72755313F046D0CE85178AE8218EE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * V_1 = NULL;
	MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	Material_t8927C00353A72755313F046D0CE85178AE8218EE * V_5 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// go.GetComponents(s_RendererBuffer);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___go0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * L_1 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_RendererBuffer_1();
		NullCheck(L_0);
		GameObject_GetComponents_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m28FCAD0BE737DA09091250839D36AF8A8D22E0C8(L_0, L_1, /*hidden argument*/GameObject_GetComponents_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m28FCAD0BE737DA09091250839D36AF8A8D22E0C8_RuntimeMethod_var);
		// foreach (var renderer in s_RendererBuffer)
		List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * L_2 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_RendererBuffer_1();
		NullCheck(L_2);
		Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72  L_3;
		L_3 = List_1_GetEnumerator_mE260B4092AF4305011540A431D02BC928E2B3997(L_2, /*hidden argument*/List_1_GetEnumerator_mE260B4092AF4305011540A431D02BC928E2B3997_RuntimeMethod_var);
		V_0 = L_3;
	}

IL_0016:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0061;
		}

IL_0018:
		{
			// foreach (var renderer in s_RendererBuffer)
			Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_4;
			L_4 = Enumerator_get_Current_m1C905C3F07EA78F157C733364DA3A9D6EDC57904_inline((Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *)(&V_0), /*hidden argument*/Enumerator_get_Current_m1C905C3F07EA78F157C733364DA3A9D6EDC57904_RuntimeMethod_var);
			V_1 = L_4;
			// var materials = renderer.sharedMaterials;
			Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_5 = V_1;
			NullCheck(L_5);
			MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* L_6;
			L_6 = Renderer_get_sharedMaterials_m9B2D432CA8AD8CEC4348E61789CC1BB0C3A00AFD(L_5, /*hidden argument*/NULL);
			V_2 = L_6;
			// for (int i = 0, count = materials.Length; i < count; ++i)
			V_3 = 0;
			// for (int i = 0, count = materials.Length; i < count; ++i)
			MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* L_7 = V_2;
			NullCheck(L_7);
			V_4 = ((int32_t)((int32_t)(((RuntimeArray*)L_7)->max_length)));
			goto IL_0055;
		}

IL_0030:
		{
			// var material = materials[i];
			MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* L_8 = V_2;
			int32_t L_9 = V_3;
			NullCheck(L_8);
			int32_t L_10 = L_9;
			Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
			V_5 = L_11;
			// if (material == null)
			Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_12 = V_5;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_13;
			L_13 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_12, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_13)
			{
				goto IL_0051;
			}
		}

IL_003f:
		{
			// materials[i] = new Material(material) { hideFlags = HideFlags.HideAndDontSave };
			MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* L_14 = V_2;
			int32_t L_15 = V_3;
			Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_16 = V_5;
			Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_17 = (Material_t8927C00353A72755313F046D0CE85178AE8218EE *)il2cpp_codegen_object_new(Material_t8927C00353A72755313F046D0CE85178AE8218EE_il2cpp_TypeInfo_var);
			Material__ctor_mD0C3D9CFAFE0FB858D864092467387D7FA178245(L_17, L_16, /*hidden argument*/NULL);
			Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_18 = L_17;
			NullCheck(L_18);
			Object_set_hideFlags_m7DE229AF60B92F0C68819F77FEB27D775E66F3AC(L_18, ((int32_t)61), /*hidden argument*/NULL);
			NullCheck(L_14);
			ArrayElementTypeCheck (L_14, L_18);
			(L_14)->SetAt(static_cast<il2cpp_array_size_t>(L_15), (Material_t8927C00353A72755313F046D0CE85178AE8218EE *)L_18);
		}

IL_0051:
		{
			// for (int i = 0, count = materials.Length; i < count; ++i)
			int32_t L_19 = V_3;
			V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_19, (int32_t)1));
		}

IL_0055:
		{
			// for (int i = 0, count = materials.Length; i < count; ++i)
			int32_t L_20 = V_3;
			int32_t L_21 = V_4;
			if ((((int32_t)L_20) < ((int32_t)L_21)))
			{
				goto IL_0030;
			}
		}

IL_005a:
		{
			// renderer.sharedMaterials = materials;
			Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_22 = V_1;
			MaterialU5BU5D_t3AE4936F3CA08FB9EE182A935E665EA9CDA5E492* L_23 = V_2;
			NullCheck(L_22);
			Renderer_set_sharedMaterials_m9838EC09412E988925C4670E8E355E5EEFE35A25(L_22, L_23, /*hidden argument*/NULL);
		}

IL_0061:
		{
			// foreach (var renderer in s_RendererBuffer)
			bool L_24;
			L_24 = Enumerator_MoveNext_m203CD6DEF51BD4293A08C00A7DD3340EC4163549((Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *)(&V_0), /*hidden argument*/Enumerator_MoveNext_m203CD6DEF51BD4293A08C00A7DD3340EC4163549_RuntimeMethod_var);
			if (L_24)
			{
				goto IL_0018;
			}
		}

IL_006a:
		{
			IL2CPP_LEAVE(0x7A, FINALLY_006c);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_006c;
	}

FINALLY_006c:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_mE21E49F8B1BE64C87CBFACE1B4B0D702C501210F((Enumerator_tCE118F2B842C1E8EE20DD0C1365C163899F59E72 *)(&V_0), /*hidden argument*/Enumerator_Dispose_mE21E49F8B1BE64C87CBFACE1B4B0D702C501210F_RuntimeMethod_var);
		IL2CPP_END_FINALLY(108)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(108)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x7A, IL_007a)
	}

IL_007a:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::SetContextOnBehaviours(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext_SetContextOnBehaviours_m71F8DF762CE623E43B6641F1450B95DE4AC684AD (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___gameObject0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponents_TisHandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE_m40A1BA6F7AFB140C4B32EADA3F965B1926F9AF9E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// gameObject.GetComponents(s_BehaviourQueryBuffer);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___gameObject0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_1 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_BehaviourQueryBuffer_2();
		NullCheck(L_0);
		GameObject_GetComponents_TisHandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE_m40A1BA6F7AFB140C4B32EADA3F965B1926F9AF9E(L_0, L_1, /*hidden argument*/GameObject_GetComponents_TisHandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE_m40A1BA6F7AFB140C4B32EADA3F965B1926F9AF9E_RuntimeMethod_var);
		// foreach (var behaviour in s_BehaviourQueryBuffer)
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_2 = ((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->get_s_BehaviourQueryBuffer_2();
		NullCheck(L_2);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_3;
		L_3 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_2, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_0 = L_3;
	}

IL_0016:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0025;
		}

IL_0018:
		{
			// foreach (var behaviour in s_BehaviourQueryBuffer)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_4;
			L_4 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			// behaviour.context = this;
			NullCheck(L_4);
			HandleBehaviour_set_context_m0BB7694139366FD7FD8B5D8D962682276CBCF85F(L_4, __this, /*hidden argument*/NULL);
		}

IL_0025:
		{
			// foreach (var behaviour in s_BehaviourQueryBuffer)
			bool L_5;
			L_5 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_5)
			{
				goto IL_0018;
			}
		}

IL_002e:
		{
			IL2CPP_LEAVE(0x3E, FINALLY_0030);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0030;
	}

FINALLY_0030:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_0), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(48)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(48)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x3E, IL_003e)
	}

IL_003e:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleContext__cctor_m71FDA1D4C429A96A5E76FA34A6F4294F55B02A4B (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m4AD4610A14E65261162EDC2D813C7F126F1BDD9F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m7774C10070F49CBF0F80ADC0E948659B630DDD48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly List<HandleContext> s_Contexts = new List<HandleContext>();
		List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 * L_0 = (List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021 *)il2cpp_codegen_object_new(List_1_tD3A62AD4FB93060CC61B77852084409C54A0D021_il2cpp_TypeInfo_var);
		List_1__ctor_m7774C10070F49CBF0F80ADC0E948659B630DDD48(L_0, /*hidden argument*/List_1__ctor_m7774C10070F49CBF0F80ADC0E948659B630DDD48_RuntimeMethod_var);
		((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->set_s_Contexts_0(L_0);
		// static readonly List<Renderer> s_RendererBuffer = new List<Renderer>();
		List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE * L_1 = (List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE *)il2cpp_codegen_object_new(List_1_tB73BF10E0869BDB4D391E61BA46B75BECA4DCDBE_il2cpp_TypeInfo_var);
		List_1__ctor_m4AD4610A14E65261162EDC2D813C7F126F1BDD9F(L_1, /*hidden argument*/List_1__ctor_m4AD4610A14E65261162EDC2D813C7F126F1BDD9F_RuntimeMethod_var);
		((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->set_s_RendererBuffer_1(L_1);
		// static readonly List<HandleBehaviour> s_BehaviourQueryBuffer = new List<HandleBehaviour>();
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_2 = (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *)il2cpp_codegen_object_new(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6(L_2, /*hidden argument*/List_1__ctor_m113641A95E998E426FCDE808935BF4367B5BA3D6_RuntimeMethod_var);
		((HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_StaticFields*)il2cpp_codegen_static_fields_for(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var))->set_s_BehaviourQueryBuffer_2(L_2);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Renderer Unity.MARS.MARSHandles.HandleStateColors::get_targetRenderer()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * HandleStateColors_get_targetRenderer_m3BFF1749DC5EECFA933B200162176EB1B767B4B9 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// public Renderer targetRenderer => m_TargetRenderer;
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_0 = __this->get_m_TargetRenderer_13();
		return L_0;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_idleColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  HandleStateColors_get_idleColor_m6D2944CCAA961ACAF88CBD58CF708580B02D5AED (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// get => m_IdleColor;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = __this->get_m_IdleColor_12();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::set_idleColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_set_idleColor_mEA8A50914E613AFE742CCCE7A4C0D0CEA5222307 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method)
{
	{
		// m_IdleColor = value;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ___value0;
		__this->set_m_IdleColor_12(L_0);
		// UpdateIdleColor();
		HandleStateColors_UpdateIdleColor_m0190886B36599357AAF5B3A697D7EB17C414FF0A(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_hoverColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  HandleStateColors_get_hoverColor_m9337E18D829C046FB29BF12DC050F8DE19D6EE15 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// get => m_HoverColor;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = __this->get_m_HoverColor_8();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::set_hoverColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_set_hoverColor_m174E02E981F9ACF14DEEAB451FCF327B8CCFF06E (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method)
{
	{
		// set => m_HoverColor = value;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ___value0;
		__this->set_m_HoverColor_8(L_0);
		return;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_dragColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  HandleStateColors_get_dragColor_mDBB8D96C228F1A4F883FE7F4541F7F0E6A09BA72 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// get => m_DragColor;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = __this->get_m_DragColor_9();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::set_dragColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_set_dragColor_m707D110BFE8E1AF27482B1882F50D2496471F375 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method)
{
	{
		// set => m_DragColor = value;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ___value0;
		__this->set_m_DragColor_9(L_0);
		return;
	}
}
// UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_disableColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  HandleStateColors_get_disableColor_mB3FDFF152DC586C9D29A40B5E2EE02D8B1C24E57 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// get => m_DisableColor;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = __this->get_m_DisableColor_10();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::set_disableColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_set_disableColor_m1D053EBF19CDBCCF4C72F0C827AFC29C74D61715 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method)
{
	{
		// set => m_DisableColor = value;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0 = ___value0;
		__this->set_m_DisableColor_10(L_0);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_Awake_m99CA504C7742B8FA2C9DA1197EB962B9F70F8AE8 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponent_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m436E5B0F17DDEF3CC61F77DEA82B1A92668AF019_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// m_TargetRenderer = GetComponent<Renderer>();
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_0;
		L_0 = Component_GetComponent_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m436E5B0F17DDEF3CC61F77DEA82B1A92668AF019(__this, /*hidden argument*/Component_GetComponent_TisRenderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C_m436E5B0F17DDEF3CC61F77DEA82B1A92668AF019_RuntimeMethod_var);
		__this->set_m_TargetRenderer_13(L_0);
		// if (m_TargetRenderer != null && m_TargetRenderer.sharedMaterial != null)
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_1 = __this->get_m_TargetRenderer_13();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_1, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0044;
		}
	}
	{
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_3 = __this->get_m_TargetRenderer_13();
		NullCheck(L_3);
		Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_4;
		L_4 = Renderer_get_sharedMaterial_m42DF538F0C6EA249B1FB626485D45D083BA74FCC(L_3, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_5;
		L_5 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_4, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_0044;
		}
	}
	{
		// m_IdleColor = m_TargetRenderer.sharedMaterial.color;
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_6 = __this->get_m_TargetRenderer_13();
		NullCheck(L_6);
		Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_7;
		L_7 = Renderer_get_sharedMaterial_m42DF538F0C6EA249B1FB626485D45D083BA74FCC(L_6, /*hidden argument*/NULL);
		NullCheck(L_7);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_8;
		L_8 = Material_get_color_m7926F7BE68B4D000306738C1EAABEB7ADFB97821(L_7, /*hidden argument*/NULL);
		__this->set_m_IdleColor_12(L_8);
		return;
	}

IL_0044:
	{
		// m_IdleColor = Color.white;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_9;
		L_9 = Color_get_white_mB21E47D20959C3AEC41AF8BA04F63AC89FAF319E(/*hidden argument*/NULL);
		__this->set_m_IdleColor_12(L_9);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::HoverBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_HoverBegin_m24B6E9A9C3F45A8C41267CF3FC2021191B5B494D (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (ownerHandle != target)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1 = ___target0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// m_IsHovered = true;
		__this->set_m_IsHovered_14((bool)1);
		// SetColor(hoverColor);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_3;
		L_3 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(16 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_hoverColor() */, __this);
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::HoverEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.HoverEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_HoverEnd_mD58E1C38C67C4978FCD6BB6F7CEBC9BB5D39A94C (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (ownerHandle != target)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1 = ___target0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// m_IsHovered = false;
		__this->set_m_IsHovered_14((bool)0);
		// SetColor(idleColor);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_3;
		L_3 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(14 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_idleColor() */, __this);
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::DragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_DragBegin_mB3D5DE97F0848799980F5AE5C09AF720EBE836E0 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (ownerHandle == target)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0;
		L_0 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1 = ___target0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		// SetColor(dragColor);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_3;
		L_3 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(18 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_dragColor() */, __this);
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}

IL_001b:
	{
		// else if (m_UseDisableColor)
		bool L_4 = __this->get_m_UseDisableColor_11();
		if (!L_4)
		{
			goto IL_002f;
		}
	}
	{
		// SetColor(disableColor);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_5;
		L_5 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(20 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_disableColor() */, __this);
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(__this, L_5, /*hidden argument*/NULL);
	}

IL_002f:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::DragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_DragEnd_mA661B8AFA5E54415F0DADA693F4CA88D87CACE92 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method)
{
	HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * G_B2_0 = NULL;
	HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * G_B1_0 = NULL;
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  G_B3_0;
	memset((&G_B3_0), 0, sizeof(G_B3_0));
	HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * G_B3_1 = NULL;
	{
		// SetColor(m_IsHovered ? hoverColor : idleColor);
		bool L_0 = __this->get_m_IsHovered_14();
		G_B1_0 = __this;
		if (L_0)
		{
			G_B2_0 = __this;
			goto IL_0011;
		}
	}
	{
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_1;
		L_1 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(14 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_idleColor() */, __this);
		G_B3_0 = L_1;
		G_B3_1 = G_B1_0;
		goto IL_0017;
	}

IL_0011:
	{
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_2;
		L_2 = VirtFuncInvoker0< Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  >::Invoke(16 /* UnityEngine.Color Unity.MARS.MARSHandles.HandleStateColors::get_hoverColor() */, __this);
		G_B3_0 = L_2;
		G_B3_1 = G_B2_0;
	}

IL_0017:
	{
		NullCheck(G_B3_1);
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(G_B3_1, G_B3_0, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::UpdateIdleColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_UpdateIdleColor_m0190886B36599357AAF5B3A697D7EB17C414FF0A (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// if (!m_IsHovered)
		bool L_0 = __this->get_m_IsHovered_14();
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		// SetColor(m_IdleColor);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_1 = __this->get_m_IdleColor_12();
		HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53(__this, L_1, /*hidden argument*/NULL);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::SetColor(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors_SetColor_m6D4E055CCA29C20C518120048048537A740F5F53 (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___color0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (m_TargetRenderer != null && m_TargetRenderer.sharedMaterial != null)
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_0 = __this->get_m_TargetRenderer_13();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0032;
		}
	}
	{
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_2 = __this->get_m_TargetRenderer_13();
		NullCheck(L_2);
		Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_3;
		L_3 = Renderer_get_sharedMaterial_m42DF538F0C6EA249B1FB626485D45D083BA74FCC(L_2, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_3, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_0032;
		}
	}
	{
		// m_TargetRenderer.sharedMaterial.color = color;
		Renderer_t58147AB5B00224FE1460FD47542DC0DA7EC9378C * L_5 = __this->get_m_TargetRenderer_13();
		NullCheck(L_5);
		Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_6;
		L_6 = Renderer_get_sharedMaterial_m42DF538F0C6EA249B1FB626485D45D083BA74FCC(L_5, /*hidden argument*/NULL);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_7 = ___color0;
		NullCheck(L_6);
		Material_set_color_mC3C88E2389B7132EBF3EB0D1F040545176B795C0(L_6, L_7, /*hidden argument*/NULL);
	}

IL_0032:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleStateColors::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleStateColors__ctor_m68E53B6EC4376C930641B06D4860A8505092375B (HandleStateColors_tC4A66F9BDC74E78693233F40E1CD68004A232D85 * __this, const RuntimeMethod* method)
{
	{
		// [SerializeField] Color m_HoverColor = new Color(1f, 0.98f, 0.69f);
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m9FEDC8486B9D40C01BF10FDC821F5E76C8705494((&L_0), (1.0f), (0.980000019f), (0.689999998f), /*hidden argument*/NULL);
		__this->set_m_HoverColor_8(L_0);
		// [SerializeField] Color m_DragColor = Color.yellow;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_1;
		L_1 = Color_get_yellow_m9FD4BDABA7E40E136BE57EE7872CEA6B1B2FA1D1(/*hidden argument*/NULL);
		__this->set_m_DragColor_9(L_1);
		// [SerializeField] Color m_DisableColor = Color.grey;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_2;
		L_2 = Color_get_grey_mB2E29B47327F20233856F933DC00ACADEBFDBDFA(/*hidden argument*/NULL);
		__this->set_m_DisableColor_10(L_2);
		// [SerializeField] bool m_UseDisableColor = true;
		__this->set_m_UseDisableColor_11((bool)1);
		HandleBehaviour__ctor_mDCF866C43F77DF2B4D1B6279089CBDA13E3ABACF(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single Unity.MARS.MARSHandles.HandleUtility::get_pixelsPerPoint()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float HandleUtility_get_pixelsPerPoint_m3244A1169D3C8E0B875E4553A06E19C64FEBCAA6 (const RuntimeMethod* method)
{
	{
		// internal static float pixelsPerPoint => Screen.dpi * k_DpiRatio;
		float L_0;
		L_0 = Screen_get_dpi_m37167A82DE896C738517BBF75BFD70C616CCCF55(/*hidden argument*/NULL);
		return ((float)il2cpp_codegen_multiply((float)L_0, (float)(0.010416667f)));
	}
}
// System.Single Unity.MARS.MARSHandles.HandleUtility::GetHandleSize(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * V_0 = NULL;
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * V_1 = NULL;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_4;
	memset((&V_4), 0, sizeof(V_4));
	float V_5 = 0.0f;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_6;
	memset((&V_6), 0, sizeof(V_6));
	{
		// Camera cam = GetActiveCamera();
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0;
		L_0 = HandleUtility_GetActiveCamera_m6C409B224FC5C09EA3C26137CE29854B4635C3A6(/*hidden argument*/NULL);
		V_0 = L_0;
		// if (cam)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_1 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499(L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_00b7;
		}
	}
	{
		// Transform tr = cam.transform;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = V_0;
		NullCheck(L_3);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_4;
		L_4 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(L_3, /*hidden argument*/NULL);
		V_1 = L_4;
		// Vector3 camPos = tr.position;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_5 = V_1;
		NullCheck(L_5);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_5, /*hidden argument*/NULL);
		V_2 = L_6;
		// float distance = Vector3.Dot(position - camPos, tr.TransformDirection(new Vector3(0, 0, 1)));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = ___position0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_7, L_8, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_10 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		memset((&L_11), 0, sizeof(L_11));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_11), (0.0f), (0.0f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_10);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Transform_TransformDirection_m6B5E3F0A7C6323159DEC6D9BC035FB53ADD96E91(L_10, L_11, /*hidden argument*/NULL);
		float L_13;
		L_13 = Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline(L_9, L_12, /*hidden argument*/NULL);
		V_3 = L_13;
		// Vector3 screenPos = cam.WorldToScreenPoint(camPos + tr.TransformDirection(new Vector3(0, 0, distance)));
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_14 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = V_2;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_16 = V_1;
		float L_17 = V_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18;
		memset((&L_18), 0, sizeof(L_18));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_18), (0.0f), (0.0f), L_17, /*hidden argument*/NULL);
		NullCheck(L_16);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_19;
		L_19 = Transform_TransformDirection_m6B5E3F0A7C6323159DEC6D9BC035FB53ADD96E91(L_16, L_18, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20;
		L_20 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_15, L_19, /*hidden argument*/NULL);
		NullCheck(L_14);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_21;
		L_21 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_14, L_20, /*hidden argument*/NULL);
		// Vector3 screenPos2 = cam.WorldToScreenPoint(camPos + tr.TransformDirection(new Vector3(1, 0, distance)));
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_22 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_23 = V_2;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_24 = V_1;
		float L_25 = V_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_26;
		memset((&L_26), 0, sizeof(L_26));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_26), (1.0f), (0.0f), L_25, /*hidden argument*/NULL);
		NullCheck(L_24);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_27;
		L_27 = Transform_TransformDirection_m6B5E3F0A7C6323159DEC6D9BC035FB53ADD96E91(L_24, L_26, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_28;
		L_28 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_23, L_27, /*hidden argument*/NULL);
		NullCheck(L_22);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_29;
		L_29 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_22, L_28, /*hidden argument*/NULL);
		V_4 = L_29;
		// float screenDist = (screenPos - screenPos2).magnitude;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_30 = V_4;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_31;
		L_31 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_21, L_30, /*hidden argument*/NULL);
		V_6 = L_31;
		float L_32;
		L_32 = Vector3_get_magnitude_mDDD40612220D8104E77E993E18A101A69A944991((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&V_6), /*hidden argument*/NULL);
		V_5 = L_32;
		// var result = (k_HandleSize / Mathf.Max(screenDist, 0.0001f));
		float L_33 = V_5;
		float L_34;
		L_34 = Mathf_Max_m4CE510E1F1013B33275F01543731A51A58BA0775(L_33, (9.99999975E-05f), /*hidden argument*/NULL);
		// result *= pixelsPerPoint;
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		float L_35;
		L_35 = HandleUtility_get_pixelsPerPoint_m3244A1169D3C8E0B875E4553A06E19C64FEBCAA6(/*hidden argument*/NULL);
		// return result;
		return ((float)il2cpp_codegen_multiply((float)((float)((float)(80.0f)/(float)L_34)), (float)L_35));
	}

IL_00b7:
	{
		// return 20.0f;
		return (20.0f);
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleUtility::GetHandleSizeVector(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  HandleUtility_GetHandleSizeVector_m78D4E723C7ED24485E9298275671B51C1321437D (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// float size = GetHandleSize(position);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___position0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		float L_1;
		L_1 = HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F(L_0, /*hidden argument*/NULL);
		// return new Vector3(size, size, size);
		float L_2 = L_1;
		float L_3 = L_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_4), L_2, L_3, L_3, /*hidden argument*/NULL);
		return L_4;
	}
}
// UnityEngine.Camera Unity.MARS.MARSHandles.HandleUtility::GetActiveCamera()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * HandleUtility_GetActiveCamera_m6C409B224FC5C09EA3C26137CE29854B4635C3A6 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * V_0 = NULL;
	{
		// var cam = Camera.current;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0;
		L_0 = Camera_get_current_m4E5A6D19F422F8DD2CFF4EE80C65B033F24C45D6(/*hidden argument*/NULL);
		V_0 = L_0;
		// if (cam != null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_1 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_1, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0011;
		}
	}
	{
		// return cam;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = V_0;
		return L_3;
	}

IL_0011:
	{
		// return Camera.main;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_4;
		L_4 = Camera_get_main_mC337C621B91591CEF89504C97EF64D717C12871C(/*hidden argument*/NULL);
		return L_4;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleUtility::ProjectScreenPositionOnHandle(Unity.MARS.MARSHandles.InteractiveHandle,UnityEngine.Vector2,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  HandleUtility_ProjectScreenPositionOnHandle_m0622A74A58CD41292E44F95DB07F51191B0F9451 (InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___handle0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	{
		// if (handle == null || camera == null)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___handle0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_0012;
		}
	}
	{
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0018;
		}
	}

IL_0012:
	{
		// return Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		return L_4;
	}

IL_0018:
	{
		// var plane = handle.GetProjectionPlane(camera.transform.position);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_5 = ___handle0;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_6 = ___camera2;
		NullCheck(L_6);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_7;
		L_7 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(L_6, /*hidden argument*/NULL);
		NullCheck(L_7);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_7, /*hidden argument*/NULL);
		NullCheck(L_5);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_9;
		L_9 = VirtFuncInvoker1< Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 , Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(14 /* UnityEngine.Plane Unity.MARS.MARSHandles.InteractiveHandle::GetProjectionPlane(UnityEngine.Vector3) */, L_5, L_8);
		V_0 = L_9;
		// var ray = camera.ScreenPointToRay(screenPosition);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_10 = ___camera2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11 = ___screenPosition1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_11, /*hidden argument*/NULL);
		NullCheck(L_10);
		Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  L_13;
		L_13 = Camera_ScreenPointToRay_mD385213935A81030EDC604A39FD64761077CFBAB(L_10, L_12, /*hidden argument*/NULL);
		V_1 = L_13;
		// if (!plane.Raycast(ray, out hitDistance))
		Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  L_14 = V_1;
		bool L_15;
		L_15 = Plane_Raycast_m8E3B0EF5B22DF336430373D4997155B647E99A24((Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 *)(&V_0), L_14, (float*)(&V_2), /*hidden argument*/NULL);
		if (L_15)
		{
			goto IL_004f;
		}
	}
	{
		// return handle.transform.position;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_16 = ___handle0;
		NullCheck(L_16);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_17;
		L_17 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(L_16, /*hidden argument*/NULL);
		NullCheck(L_17);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18;
		L_18 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_17, /*hidden argument*/NULL);
		return L_18;
	}

IL_004f:
	{
		// return ray.origin + ray.direction * hitDistance;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_19;
		L_19 = Ray_get_origin_m0C1B2BFF99CDF5231AC29AC031C161F55B53C1D0((Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 *)(&V_1), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20;
		L_20 = Ray_get_direction_m2B31F86F19B64474A901B28D3808011AE7A13EFC((Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 *)(&V_1), /*hidden argument*/NULL);
		float L_21 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_22;
		L_22 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_20, L_21, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_23;
		L_23 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_19, L_22, /*hidden argument*/NULL);
		return L_23;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.HandleUtility::ProjectWorldPositionOnHandle(Unity.MARS.MARSHandles.InteractiveHandle,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  HandleUtility_ProjectWorldPositionOnHandle_m9A583F3E6FE048E97E7C1A44BBF78E24D565616F (InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___handle0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (handle == null)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___handle0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_000f;
		}
	}
	{
		// return Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		return L_2;
	}

IL_000f:
	{
		// return handle.GetProjectionPlane(position).ClosestPointOnPlane(position);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_3 = ___handle0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___position1;
		NullCheck(L_3);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_5;
		L_5 = VirtFuncInvoker1< Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 , Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(14 /* UnityEngine.Plane Unity.MARS.MARSHandles.InteractiveHandle::GetProjectionPlane(UnityEngine.Vector3) */, L_3, L_4);
		V_0 = L_5;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___position1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Plane_ClosestPointOnPlane_mDBB63D79FA643E10949FEE1AE692975940716BCE((Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7 *)(&V_0), L_6, /*hidden argument*/NULL);
		return L_7;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleUtility::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HandleUtility__cctor_m733C2D86B69FAF2CA83EB99118F8A99993D34916 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Material_t8927C00353A72755313F046D0CE85178AE8218EE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6BF3D8705F4F5025D5392E7A9C1879B05AC6DA08);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static readonly Material defaultMaterial = new Material(Shader.Find("Hidden/MARS/Handles/UnlitColor"));
		Shader_tB2355DC4F3CAF20B2F1AB5AABBF37C3555FFBC39 * L_0;
		L_0 = Shader_Find_m596EC6EBDCA8C9D5D86E2410A319928C1E8E6B5A(_stringLiteral6BF3D8705F4F5025D5392E7A9C1879B05AC6DA08, /*hidden argument*/NULL);
		Material_t8927C00353A72755313F046D0CE85178AE8218EE * L_1 = (Material_t8927C00353A72755313F046D0CE85178AE8218EE *)il2cpp_codegen_object_new(Material_t8927C00353A72755313F046D0CE85178AE8218EE_il2cpp_TypeInfo_var);
		Material__ctor_mD2A3BCD3B4F17F5C6E95F3B34DAF4B497B67127E(L_1, L_0, /*hidden argument*/NULL);
		((HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_StaticFields*)il2cpp_codegen_static_fields_for(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var))->set_defaultMaterial_0(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.InteractiveHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractiveHandle__ctor_m9F68782D20A7C744E8CAE02A5ABF5466E10B77B9 (InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * __this, const RuntimeMethod* method)
{
	{
		HandleBehaviour__ctor_mDCF866C43F77DF2B4D1B6279089CBDA13E3ABACF(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IsReadOnlyAttribute__ctor_mA3938A1FCD55253C4CD516526B29787E9E8EF179 (IsReadOnlyAttribute_tBB3A65EFBD4A5C11A2837FA9CF013450EC3A0011 * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.LineRendererConstraint::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRendererConstraint_Awake_mE37AEE142D9FA45340AA02DCDD17CE9422548857 (LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponent_TisLineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967_mD5BC9EADE1AA529A5299A4D8B020FB49663DAC3A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// m_Line = GetComponent<LineRenderer>();
		LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * L_0;
		L_0 = Component_GetComponent_TisLineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967_mD5BC9EADE1AA529A5299A4D8B020FB49663DAC3A(__this, /*hidden argument*/Component_GetComponent_TisLineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967_mD5BC9EADE1AA529A5299A4D8B020FB49663DAC3A_RuntimeMethod_var);
		__this->set_m_Line_6(L_0);
		// m_Line.useWorldSpace = true;
		LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * L_1 = __this->get_m_Line_6();
		NullCheck(L_1);
		LineRenderer_set_useWorldSpace_m53AA0FE659EFB041647DB6A29826D20D52CBE148(L_1, (bool)1, /*hidden argument*/NULL);
		// Camera.onPreRender += PreRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_2 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPreRender_5();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_3 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_3, __this, (intptr_t)((intptr_t)LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPreRender_5(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_4, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.LineRendererConstraint::OnDestroy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRendererConstraint_OnDestroy_m3BCEBCFC26BD0081D22E73881D6274E00AF6DDFF (LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// Camera.onPreRender -= PreRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_0 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPreRender_5();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_1 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_1, __this, (intptr_t)((intptr_t)LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_2;
		L_2 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_0, L_1, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPreRender_5(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_2, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.LineRendererConstraint::PreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRendererConstraint_PreRender_m3C50DA371F5FA819C370D2D5AE26271086A19F85 (LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!m_A || !m_B)
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = __this->get_m_A_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_001a;
		}
	}
	{
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_2 = __this->get_m_B_5();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499(L_2, /*hidden argument*/NULL);
		if (L_3)
		{
			goto IL_001b;
		}
	}

IL_001a:
	{
		// return;
		return;
	}

IL_001b:
	{
		// m_Line.SetPosition(0, m_A.position);
		LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * L_4 = __this->get_m_Line_6();
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_5 = __this->get_m_A_4();
		NullCheck(L_5);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_5, /*hidden argument*/NULL);
		NullCheck(L_4);
		LineRenderer_SetPosition_mD37DBE4B3E13A838FFD09289BC77DEDB423D620F(L_4, 0, L_6, /*hidden argument*/NULL);
		// m_Line.SetPosition(1, m_B.position);
		LineRenderer_t237E878F3E77C127A540DE7AC4681B3706727967 * L_7 = __this->get_m_Line_6();
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_8 = __this->get_m_B_5();
		NullCheck(L_8);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_8, /*hidden argument*/NULL);
		NullCheck(L_7);
		LineRenderer_SetPosition_mD37DBE4B3E13A838FFD09289BC77DEDB423D620F(L_7, 1, L_9, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.LineRendererConstraint::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LineRendererConstraint__ctor_m033A2B762D92AF195DFC110D01EA690F7798988B (LineRendererConstraint_t7A8F728749F69AA5F35B6125B02EC363FEECD1E1 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.PositionHandle::add_translationBegun(System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_add_translationBegun_mA0E98FD61E3DA754E8206C90765C947EA8EC46D8 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_0 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_1 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_2 = NULL;
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_0 = __this->get_translationBegun_4();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_2 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var));
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** L_5 = __this->get_address_of_translationBegun_4();
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_6 = V_2;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_7 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *>((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_9 = V_0;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_9) == ((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::remove_translationBegun(System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_remove_translationBegun_m0B36A52EB050F05413A8F280D7639B8A4C9807A5 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_0 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_1 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_2 = NULL;
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_0 = __this->get_translationBegun_4();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_2 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var));
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** L_5 = __this->get_address_of_translationBegun_4();
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_6 = V_2;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_7 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *>((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_9 = V_0;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_9) == ((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::add_translationUpdated(System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_add_translationUpdated_mF82AC8340AAA1749504DA1CCE54EB451B675D711 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_0 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_1 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_2 = NULL;
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_0 = __this->get_translationUpdated_5();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_2 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var));
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** L_5 = __this->get_address_of_translationUpdated_5();
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_6 = V_2;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_7 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *>((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_9 = V_0;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_9) == ((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::remove_translationUpdated(System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_remove_translationUpdated_m5B9197BE9073CCAF2651C539EAC5835F2AFB61DF (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_0 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_1 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_2 = NULL;
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_0 = __this->get_translationUpdated_5();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_2 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var));
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** L_5 = __this->get_address_of_translationUpdated_5();
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_6 = V_2;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_7 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *>((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_9 = V_0;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_9) == ((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::add_translationEnded(System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_add_translationEnded_mC377079043B93610F90BEE4EA45C4226A952A1F7 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_0 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_1 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_2 = NULL;
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_0 = __this->get_translationEnded_6();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_1 = V_0;
		V_1 = L_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_2 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)CastclassSealed((RuntimeObject*)L_4, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var));
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** L_5 = __this->get_address_of_translationEnded_6();
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_6 = V_2;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_7 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *>((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_9 = V_0;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_9) == ((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::remove_translationEnded(System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_remove_translationEnded_mA5EDA732CB51D8BBAF9DF768F301741A78570664 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_0 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_1 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_2 = NULL;
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_0 = __this->get_translationEnded_6();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_1 = V_0;
		V_1 = L_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_2 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)CastclassSealed((RuntimeObject*)L_4, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var));
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** L_5 = __this->get_address_of_translationEnded_6();
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_6 = V_2;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_7 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *>((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_9 = V_0;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_9) == ((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_Awake_mEBA23F67B82BBEC1D21778651D7087225B12058B (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PositionHandle_OnTranslationBegun_m04ADE23392A6C566E59604ACD9B5B17B466D0CFA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PositionHandle_OnTranslationEnded_m7688135C8CFA37DD8C1781D86F7E249CBE973EEF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PositionHandle_OnTranslationUpdated_m7A815858FA04DBAD217D24549CE70F7F65563265_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* V_0 = NULL;
	int32_t V_1 = 0;
	SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * V_2 = NULL;
	{
		// foreach (var slider in m_Sliders)
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_0 = __this->get_m_Sliders_7();
		V_0 = L_0;
		V_1 = 0;
		goto IL_0052;
	}

IL_000b:
	{
		// foreach (var slider in m_Sliders)
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_1 = V_0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		int32_t L_3 = L_2;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		V_2 = L_4;
		// if (slider == null)
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_5 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_6;
		L_6 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_5, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (L_6)
		{
			goto IL_004e;
		}
	}
	{
		// slider.translationBegun += OnTranslationBegun;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_7 = V_2;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_8 = (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)il2cpp_codegen_object_new(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC(L_8, __this, (intptr_t)((intptr_t)PositionHandle_OnTranslationBegun_m04ADE23392A6C566E59604ACD9B5B17B466D0CFA_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_RuntimeMethod_var);
		NullCheck(L_7);
		SliderHandleBase_add_translationBegun_mCC5248C8B156875CCB69C04EF3CC4030928F6D78(L_7, L_8, /*hidden argument*/NULL);
		// slider.translationUpdated += OnTranslationUpdated;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_9 = V_2;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_10 = (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)il2cpp_codegen_object_new(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE(L_10, __this, (intptr_t)((intptr_t)PositionHandle_OnTranslationUpdated_m7A815858FA04DBAD217D24549CE70F7F65563265_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_RuntimeMethod_var);
		NullCheck(L_9);
		SliderHandleBase_add_translationUpdated_m78CAF25B6B9DF6E3D2861E4EC0785C9200E5E1F5(L_9, L_10, /*hidden argument*/NULL);
		// slider.translationEnded += OnTranslationEnded;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_11 = V_2;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_12 = (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)il2cpp_codegen_object_new(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E(L_12, __this, (intptr_t)((intptr_t)PositionHandle_OnTranslationEnded_m7688135C8CFA37DD8C1781D86F7E249CBE973EEF_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_RuntimeMethod_var);
		NullCheck(L_11);
		SliderHandleBase_add_translationEnded_m0B4F029D79BF0523E8FD27D9CA0F97BB96DA45D5(L_11, L_12, /*hidden argument*/NULL);
	}

IL_004e:
	{
		int32_t L_13 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
	}

IL_0052:
	{
		// foreach (var slider in m_Sliders)
		int32_t L_14 = V_1;
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_15 = V_0;
		NullCheck(L_15);
		if ((((int32_t)L_14) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_15)->max_length))))))
		{
			goto IL_000b;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::OnTranslationBegun(Unity.MARS.MARSHandles.TranslationBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_OnTranslationBegun_m04ADE23392A6C566E59604ACD9B5B17B466D0CFA (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (translationBegun != null) translationBegun.Invoke(info);
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_0 = __this->get_translationBegun_4();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (translationBegun != null) translationBegun.Invoke(info);
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_1 = __this->get_translationBegun_4();
		TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0(L_1, L_2, /*hidden argument*/Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::OnTranslationUpdated(Unity.MARS.MARSHandles.TranslationUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_OnTranslationUpdated_m7A815858FA04DBAD217D24549CE70F7F65563265 (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (translationUpdated != null) translationUpdated.Invoke(info);
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_0 = __this->get_translationUpdated_5();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (translationUpdated != null) translationUpdated.Invoke(info);
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_1 = __this->get_translationUpdated_5();
		TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274(L_1, L_2, /*hidden argument*/Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::OnTranslationEnded(Unity.MARS.MARSHandles.TranslationEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle_OnTranslationEnded_m7688135C8CFA37DD8C1781D86F7E249CBE973EEF (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (translationEnded != null) translationEnded.Invoke(info);
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_0 = __this->get_translationEnded_6();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (translationEnded != null) translationEnded.Invoke(info);
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_1 = __this->get_translationEnded_6();
		TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C(L_1, L_2, /*hidden argument*/Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.PositionHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionHandle__ctor_m42006910A3019B748BDA59B5B2EE2DA16D34B2ED (PositionHandle_t507E61E6A8E839708379198222365B39213A4835 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// [SerializeField] SliderHandleBase[] m_Sliders = new SliderHandleBase[0];
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_0 = (SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45*)(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45*)SZArrayNew(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45_il2cpp_TypeInfo_var, (uint32_t)0);
		__this->set_m_Sliders_7(L_0);
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_world_m3B0D23EED0F777F202BB1D961548BCA82FB97BCA (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_world_m3B0D23EED0F777F202BB1D961548BCA82FB97BCA_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * _thisAdjusted = reinterpret_cast<RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationBeginInfo_get_world_m3B0D23EED0F777F202BB1D961548BCA82FB97BCA_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77 (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * _thisAdjusted = reinterpret_cast<RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *>(__this + _offset);
	RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationBeginInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_local_m73DF0506958FCE368E13C9FC5B2ADA3768E0278A (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_local_m73DF0506958FCE368E13C9FC5B2ADA3768E0278A_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * _thisAdjusted = reinterpret_cast<RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationBeginInfo_get_local_m73DF0506958FCE368E13C9FC5B2ADA3768E0278A_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40 (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * _thisAdjusted = reinterpret_cast<RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *>(__this + _offset);
	RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.RotationBeginInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationBeginInfo__ctor_m763FC8690EB794D81651F02D9D8BEABBECF3227B (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	{
		// public RotationBeginInfo(RotationInfo world, RotationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 ));
		// this.world = world;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___world0;
		RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77_inline((RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_1 = ___local1;
		RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40_inline((RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void RotationBeginInfo__ctor_m763FC8690EB794D81651F02D9D8BEABBECF3227B_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * _thisAdjusted = reinterpret_cast<RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 *>(__this + _offset);
	RotationBeginInfo__ctor_m763FC8690EB794D81651F02D9D8BEABBECF3227B(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_world_m4BAE769589BEA155D286581CAE61E7C1987582AC (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_world_m4BAE769589BEA155D286581CAE61E7C1987582AC_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * _thisAdjusted = reinterpret_cast<RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationEndInfo_get_world_m4BAE769589BEA155D286581CAE61E7C1987582AC_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * _thisAdjusted = reinterpret_cast<RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *>(__this + _offset);
	RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationEndInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_local_m2D09A17E6786D6253B915364A72E18A723539258 (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_local_m2D09A17E6786D6253B915364A72E18A723539258_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * _thisAdjusted = reinterpret_cast<RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationEndInfo_get_local_m2D09A17E6786D6253B915364A72E18A723539258_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * _thisAdjusted = reinterpret_cast<RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *>(__this + _offset);
	RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.RotationEndInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationEndInfo__ctor_m5A00AD63782AE909506A93672A6AA49FC8DA1CA6 (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	{
		// public RotationEndInfo(RotationInfo world, RotationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 ));
		// this.world = world;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___world0;
		RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC_inline((RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_1 = ___local1;
		RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA_inline((RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void RotationEndInfo__ctor_m5A00AD63782AE909506A93672A6AA49FC8DA1CA6_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * _thisAdjusted = reinterpret_cast<RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 *>(__this + _offset);
	RotationEndInfo__ctor_m5A00AD63782AE909506A93672A6AA49FC8DA1CA6(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.RotationHandle::add_rotationBegun(System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_add_rotationBegun_m55E7B2817717C59FB574EFFB0AA7498DCED12D88 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_0 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_1 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_2 = NULL;
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_0 = __this->get_rotationBegun_4();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_1 = V_0;
		V_1 = L_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_2 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)CastclassSealed((RuntimeObject*)L_4, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var));
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** L_5 = __this->get_address_of_rotationBegun_4();
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_6 = V_2;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_7 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *>((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_9 = V_0;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_9) == ((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::remove_rotationBegun(System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_remove_rotationBegun_mB67622210C2CB37B3F00616AC164055872D558A9 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_0 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_1 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_2 = NULL;
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_0 = __this->get_rotationBegun_4();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_1 = V_0;
		V_1 = L_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_2 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)CastclassSealed((RuntimeObject*)L_4, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var));
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** L_5 = __this->get_address_of_rotationBegun_4();
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_6 = V_2;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_7 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *>((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_9 = V_0;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_9) == ((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::add_rotationUpdated(System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_add_rotationUpdated_mFDA35DD67488D50BA47FB589CB142FBC726B4798 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_0 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_1 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_2 = NULL;
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_0 = __this->get_rotationUpdated_5();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_2 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var));
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** L_5 = __this->get_address_of_rotationUpdated_5();
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_6 = V_2;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_7 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *>((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_9 = V_0;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_9) == ((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::remove_rotationUpdated(System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_remove_rotationUpdated_mCE04D9ADA1B0E9047D8979B45F9FBA85805F631E (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_0 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_1 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_2 = NULL;
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_0 = __this->get_rotationUpdated_5();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_2 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var));
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** L_5 = __this->get_address_of_rotationUpdated_5();
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_6 = V_2;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_7 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *>((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_9 = V_0;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_9) == ((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::add_rotationEnded(System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_add_rotationEnded_m17F975D5F9B77E8209B680AE84B82A12FCAE7FE2 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_0 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_1 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_2 = NULL;
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_0 = __this->get_rotationEnded_6();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_2 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var));
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** L_5 = __this->get_address_of_rotationEnded_6();
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_6 = V_2;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_7 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *>((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_9 = V_0;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_9) == ((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::remove_rotationEnded(System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_remove_rotationEnded_m3C92E2E62538DCFFACD1E2E4AE5BD28F01366E1C (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_0 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_1 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_2 = NULL;
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_0 = __this->get_rotationEnded_6();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_2 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var));
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** L_5 = __this->get_address_of_rotationEnded_6();
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_6 = V_2;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_7 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *>((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_9 = V_0;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_9) == ((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_Awake_m42F455C59593C4BC70321F2D9720DE15421DC815 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RotationHandle_OnRotationBegun_m4DA578F6E63C5E92639DD91825F3BE32668F3E2E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RotationHandle_OnRotationEnded_mADA3A5EADD676E2550EAAC134EDBA41DA6687F2E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RotationHandle_OnRotationUpdated_m51718E7169CD232FF57908ECA103AA7BF34E13A2_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* V_0 = NULL;
	int32_t V_1 = 0;
	RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * V_2 = NULL;
	{
		// foreach (var rotator in m_Rotators)
		RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* L_0 = __this->get_m_Rotators_7();
		V_0 = L_0;
		V_1 = 0;
		goto IL_0052;
	}

IL_000b:
	{
		// foreach (var rotator in m_Rotators)
		RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* L_1 = V_0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		int32_t L_3 = L_2;
		RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		V_2 = L_4;
		// if (rotator == null)
		RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * L_5 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_6;
		L_6 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_5, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (L_6)
		{
			goto IL_004e;
		}
	}
	{
		// rotator.rotationBegun += OnRotationBegun;
		RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * L_7 = V_2;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_8 = (Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)il2cpp_codegen_object_new(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C(L_8, __this, (intptr_t)((intptr_t)RotationHandle_OnRotationBegun_m4DA578F6E63C5E92639DD91825F3BE32668F3E2E_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_m188DD38E74E38BAE2D5B51B492117A6569433D6C_RuntimeMethod_var);
		NullCheck(L_7);
		RotatorHandle_add_rotationBegun_m9AE3EE4570B763147AEFA1AE11B753944B44AB71(L_7, L_8, /*hidden argument*/NULL);
		// rotator.rotationUpdated += OnRotationUpdated;
		RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * L_9 = V_2;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_10 = (Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)il2cpp_codegen_object_new(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C(L_10, __this, (intptr_t)((intptr_t)RotationHandle_OnRotationUpdated_m51718E7169CD232FF57908ECA103AA7BF34E13A2_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mEDC28896B2BD14D20859E3C466029FDDFCD0A15C_RuntimeMethod_var);
		NullCheck(L_9);
		RotatorHandle_add_rotationUpdated_m93071220938A6117BC352F04B6AE2A6C93039B9A(L_9, L_10, /*hidden argument*/NULL);
		// rotator.rotationEnded += OnRotationEnded;
		RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * L_11 = V_2;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_12 = (Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)il2cpp_codegen_object_new(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3(L_12, __this, (intptr_t)((intptr_t)RotationHandle_OnRotationEnded_mADA3A5EADD676E2550EAAC134EDBA41DA6687F2E_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mD6EEDE09C0469E945557F351684C6A1C7BCA9AD3_RuntimeMethod_var);
		NullCheck(L_11);
		RotatorHandle_add_rotationEnded_m353170AF287A3EFC4B5F0F57F5A39F54C866B5BB(L_11, L_12, /*hidden argument*/NULL);
	}

IL_004e:
	{
		int32_t L_13 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
	}

IL_0052:
	{
		// foreach (var rotator in m_Rotators)
		int32_t L_14 = V_1;
		RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* L_15 = V_0;
		NullCheck(L_15);
		if ((((int32_t)L_14) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_15)->max_length))))))
		{
			goto IL_000b;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::OnRotationBegun(Unity.MARS.MARSHandles.RotationBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_OnRotationBegun_m4DA578F6E63C5E92639DD91825F3BE32668F3E2E (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (rotationBegun != null) rotationBegun.Invoke(info);
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_0 = __this->get_rotationBegun_4();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (rotationBegun != null) rotationBegun.Invoke(info);
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_1 = __this->get_rotationBegun_4();
		RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4(L_1, L_2, /*hidden argument*/Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::OnRotationUpdated(Unity.MARS.MARSHandles.RotationUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_OnRotationUpdated_m51718E7169CD232FF57908ECA103AA7BF34E13A2 (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (rotationUpdated != null) rotationUpdated.Invoke(info);
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_0 = __this->get_rotationUpdated_5();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (rotationUpdated != null) rotationUpdated.Invoke(info);
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_1 = __this->get_rotationUpdated_5();
		RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E(L_1, L_2, /*hidden argument*/Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::OnRotationEnded(Unity.MARS.MARSHandles.RotationEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle_OnRotationEnded_mADA3A5EADD676E2550EAAC134EDBA41DA6687F2E (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449  ___info0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (rotationEnded != null) rotationEnded.Invoke(info);
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_0 = __this->get_rotationEnded_6();
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// if (rotationEnded != null) rotationEnded.Invoke(info);
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_1 = __this->get_rotationEnded_6();
		RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449  L_2 = ___info0;
		NullCheck(L_1);
		Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A(L_1, L_2, /*hidden argument*/Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_RuntimeMethod_var);
	}

IL_0014:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotationHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationHandle__ctor_mA0D6CEC6E5DFB42FA3860A490FA6CED8210C377C (RotationHandle_t0DECFBC6692EA12A92944E732D32235E88685D78 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// RotatorHandle[] m_Rotators = new RotatorHandle[0];
		RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A* L_0 = (RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A*)(RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A*)SZArrayNew(RotatorHandleU5BU5D_tCDB0A5E0F8881403D1C94F7F5FBEFB03C2A7590A_il2cpp_TypeInfo_var, (uint32_t)0);
		__this->set_m_Rotators_7(L_0);
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single Unity.MARS.MARSHandles.RotationInfo::get_total()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float RotationInfo_get_total_mDBAD43EB96B196E258AE3972228C641CC044ED94 (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public float total { get; private set; }
		float L_0 = __this->get_U3CtotalU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float RotationInfo_get_total_mDBAD43EB96B196E258AE3972228C641CC044ED94_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	float _returnValue;
	_returnValue = RotationInfo_get_total_mDBAD43EB96B196E258AE3972228C641CC044ED94_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_total(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float total { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.MARSHandles.RotationInfo::get_delta()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float RotationInfo_get_delta_m9DFA96854C0C0E823AA72EEAC40FDD3D7C6FCD1B (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public float delta { get; private set; }
		float L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float RotationInfo_get_delta_m9DFA96854C0C0E823AA72EEAC40FDD3D7C6FCD1B_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	float _returnValue;
	_returnValue = RotationInfo_get_delta_m9DFA96854C0C0E823AA72EEAC40FDD3D7C6FCD1B_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_delta(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float delta { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotationInfo::get_axis()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotationInfo_get_axis_mA25AA9C2B63EFD8C2FE3203FBBA3AE4CF957F1B6 (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 axis { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CaxisU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotationInfo_get_axis_mA25AA9C2B63EFD8C2FE3203FBBA3AE4CF957F1B6_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = RotationInfo_get_axis_mA25AA9C2B63EFD8C2FE3203FBBA3AE4CF957F1B6_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationInfo::set_axis(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806 (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 axis { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CaxisU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.RotationInfo::.ctor(System.Single,System.Single,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356 (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___total0, float ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___axis2, const RuntimeMethod* method)
{
	{
		// public RotationInfo(float total, float delta, Vector3 axis) : this()
		il2cpp_codegen_initobj(__this, sizeof(RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 ));
		// this.total = total;
		float L_0 = ___total0;
		RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F_inline((RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *)__this, L_0, /*hidden argument*/NULL);
		// this.delta = delta;
		float L_1 = ___delta1;
		RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA_inline((RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *)__this, L_1, /*hidden argument*/NULL);
		// this.axis = axis;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___axis2;
		RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806_inline((RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *)__this, L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356_AdjustorThunk (RuntimeObject * __this, float ___total0, float ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___axis2, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * _thisAdjusted = reinterpret_cast<RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 *>(__this + _offset);
	RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356(_thisAdjusted, ___total0, ___delta1, ___axis2, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_world_mB8A3FF1EA7A95E523E3117E234608A46AF7747B6 (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_world_mB8A3FF1EA7A95E523E3117E234608A46AF7747B6_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * _thisAdjusted = reinterpret_cast<RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationUpdateInfo_get_world_mB8A3FF1EA7A95E523E3117E234608A46AF7747B6_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::set_world(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843 (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * _thisAdjusted = reinterpret_cast<RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *>(__this + _offset);
	RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.RotationInfo Unity.MARS.MARSHandles.RotationUpdateInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_local_m56BA9177C8453541972DE59ED8650BCA589B37F0 (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_local_m56BA9177C8453541972DE59ED8650BCA589B37F0_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * _thisAdjusted = reinterpret_cast<RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *>(__this + _offset);
	RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  _returnValue;
	_returnValue = RotationUpdateInfo_get_local_m56BA9177C8453541972DE59ED8650BCA589B37F0_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::set_local(Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * _thisAdjusted = reinterpret_cast<RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *>(__this + _offset);
	RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.RotationUpdateInfo::.ctor(Unity.MARS.MARSHandles.RotationInfo,Unity.MARS.MARSHandles.RotationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotationUpdateInfo__ctor_mC61AC4A057E8B380E36E88C773BDE974E76012E0 (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	{
		// public RotationUpdateInfo(RotationInfo world, RotationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 ));
		// this.world = world;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___world0;
		RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843_inline((RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_1 = ___local1;
		RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB_inline((RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void RotationUpdateInfo__ctor_mC61AC4A057E8B380E36E88C773BDE974E76012E0_AdjustorThunk (RuntimeObject * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___world0, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * _thisAdjusted = reinterpret_cast<RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 *>(__this + _offset);
	RotationUpdateInfo__ctor_mC61AC4A057E8B380E36E88C773BDE974E76012E0(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationBegun(System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationBegun_m9AE3EE4570B763147AEFA1AE11B753944B44AB71 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_0 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_1 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_2 = NULL;
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_0 = __this->get_rotationBegun_8();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_1 = V_0;
		V_1 = L_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_2 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)CastclassSealed((RuntimeObject*)L_4, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var));
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** L_5 = __this->get_address_of_rotationBegun_8();
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_6 = V_2;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_7 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *>((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_9 = V_0;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_9) == ((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::remove_rotationBegun(System.Action`1<Unity.MARS.MARSHandles.RotationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_remove_rotationBegun_m8D62D1E62C350DEEF4F9BF2A8C38D716F47E0A87 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_0 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_1 = NULL;
	Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * V_2 = NULL;
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_0 = __this->get_rotationBegun_8();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_1 = V_0;
		V_1 = L_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_2 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)CastclassSealed((RuntimeObject*)L_4, Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F_il2cpp_TypeInfo_var));
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F ** L_5 = __this->get_address_of_rotationBegun_8();
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_6 = V_2;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_7 = V_1;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *>((Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_9 = V_0;
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_9) == ((RuntimeObject*)(Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationUpdated(System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationUpdated_m93071220938A6117BC352F04B6AE2A6C93039B9A (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_0 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_1 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_2 = NULL;
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_0 = __this->get_rotationUpdated_9();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_2 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var));
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** L_5 = __this->get_address_of_rotationUpdated_9();
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_6 = V_2;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_7 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *>((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_9 = V_0;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_9) == ((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::remove_rotationUpdated(System.Action`1<Unity.MARS.MARSHandles.RotationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_remove_rotationUpdated_mC1235E8DC73ECF1E86643E2D5EAF2FFE077BE526 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_0 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_1 = NULL;
	Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * V_2 = NULL;
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_0 = __this->get_rotationUpdated_9();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_2 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824_il2cpp_TypeInfo_var));
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 ** L_5 = __this->get_address_of_rotationUpdated_9();
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_6 = V_2;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_7 = V_1;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *>((Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_9 = V_0;
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_9) == ((RuntimeObject*)(Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::add_rotationEnded(System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_add_rotationEnded_m353170AF287A3EFC4B5F0F57F5A39F54C866B5BB (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_0 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_1 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_2 = NULL;
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_0 = __this->get_rotationEnded_10();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_2 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var));
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** L_5 = __this->get_address_of_rotationEnded_10();
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_6 = V_2;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_7 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *>((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_9 = V_0;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_9) == ((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::remove_rotationEnded(System.Action`1<Unity.MARS.MARSHandles.RotationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_remove_rotationEnded_m1E9DA2CE1419FAC20062F98CDF30DBF81AD48090 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_0 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_1 = NULL;
	Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * V_2 = NULL;
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_0 = __this->get_rotationEnded_10();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_2 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5_il2cpp_TypeInfo_var));
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 ** L_5 = __this->get_address_of_rotationEnded_10();
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_6 = V_2;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_7 = V_1;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *>((Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_9 = V_0;
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_9) == ((RuntimeObject*)(Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// UnityEngine.Plane Unity.MARS.MARSHandles.RotatorHandle::GetProjectionPlane(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  RotatorHandle_GetProjectionPlane_mB6A261E8E4B656F58531ABA2AB7F667427454C16 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___camPosition0, const RuntimeMethod* method)
{
	{
		// return new Plane(planeNormal, transform.position); ;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = RotatorHandle_get_planeNormal_m8ABD66B52169A49E3F4A84F1A22967C89947CA33(__this, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_1, /*hidden argument*/NULL);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_3;
		memset((&L_3), 0, sizeof(L_3));
		Plane__ctor_m5B830C0E99AA5A47EF0D15767828D6E859867E67((&L_3), L_0, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// UnityEngine.Plane Unity.MARS.MARSHandles.RotatorHandle::get_projectionPlane()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  RotatorHandle_get_projectionPlane_m311B07CC8E01574297161112C7D4B8F98EA9346B (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, const RuntimeMethod* method)
{
	{
		// get { return new Plane(planeNormal, transform.position); }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = RotatorHandle_get_planeNormal_m8ABD66B52169A49E3F4A84F1A22967C89947CA33(__this, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_1, /*hidden argument*/NULL);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_3;
		memset((&L_3), 0, sizeof(L_3));
		Plane__ctor_m5B830C0E99AA5A47EF0D15767828D6E859867E67((&L_3), L_0, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.RotatorHandle::get_planeNormal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotatorHandle_get_planeNormal_m8ABD66B52169A49E3F4A84F1A22967C89947CA33 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, const RuntimeMethod* method)
{
	{
		// get { return transform.forward; }
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::DragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_DragBegin_m6DF096B48BD512D1976DE7B502F95B3980808240 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// m_LastDirection = info.translation.initialPosition - transform.position;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * L_3 = (&___info1)->get_address_of_translation_0();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)L_3, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_5;
		L_5 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_5);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_5, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_4, L_6, /*hidden argument*/NULL);
		__this->set_m_LastDirection_11(L_7);
		// m_TotalAngle = 0f;
		__this->set_m_TotalAngle_13((0.0f));
		// m_Normal = planeNormal;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = RotatorHandle_get_planeNormal_m8ABD66B52169A49E3F4A84F1A22967C89947CA33(__this, /*hidden argument*/NULL);
		__this->set_m_Normal_12(L_8);
		// if (rotationBegun != null) rotationBegun.Invoke(new RotationBeginInfo(
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_9 = __this->get_rotationBegun_8();
		if (!L_9)
		{
			goto IL_00a2;
		}
	}
	{
		// if (rotationBegun != null) rotationBegun.Invoke(new RotationBeginInfo(
		//     new RotationInfo( // World
		//         0,
		//         0,
		//         m_Normal),
		// 
		//     new RotationInfo(  // Local
		//         0,
		//         0,
		//         transform.worldToLocalMatrix.rotation * m_Normal)));
		Action_1_t4813265FCAF185E8A69AAA9B07DDFADC759D730F * L_10 = __this->get_rotationBegun_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = __this->get_m_Normal_12();
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_12;
		memset((&L_12), 0, sizeof(L_12));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_12), (0.0f), (0.0f), L_11, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_13;
		L_13 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_13);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_14;
		L_14 = Transform_get_worldToLocalMatrix_mE22FDE24767E1DE402D3E7A1C9803379B2E8399D(L_13, /*hidden argument*/NULL);
		V_0 = L_14;
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_15;
		L_15 = Matrix4x4_get_rotation_m3F80DDCCBDC01EBF36D61F382749AE704603C379((Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 *)(&V_0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16 = __this->get_m_Normal_12();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17;
		L_17 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_15, L_16, /*hidden argument*/NULL);
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_18;
		memset((&L_18), 0, sizeof(L_18));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_18), (0.0f), (0.0f), L_17, /*hidden argument*/NULL);
		RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78  L_19;
		memset((&L_19), 0, sizeof(L_19));
		RotationBeginInfo__ctor_m763FC8690EB794D81651F02D9D8BEABBECF3227B((&L_19), L_12, L_18, /*hidden argument*/NULL);
		NullCheck(L_10);
		Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4(L_10, L_19, /*hidden argument*/Action_1_Invoke_mD2E5E0DF397A856511F6D865A7091FD286A3D0A4_RuntimeMethod_var);
	}

IL_00a2:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::DragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_DragUpdate_m29BDA4B75BD359EFA9DCF6D5D1FAA571E478F045 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	float V_1 = 0.0f;
	DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  V_2;
	memset((&V_2), 0, sizeof(V_2));
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  V_3;
	memset((&V_3), 0, sizeof(V_3));
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// var currentDir = info.translation.currentPosition - transform.position;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_3;
		L_3 = DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_inline((DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *)(&___info1), /*hidden argument*/NULL);
		V_2 = L_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&V_2), /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_5;
		L_5 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_5);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_5, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_4, L_6, /*hidden argument*/NULL);
		V_0 = L_7;
		// var deltaAngle = Vector3.SignedAngle(m_LastDirection, currentDir, m_Normal);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = __this->get_m_LastDirection_11();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = __this->get_m_Normal_12();
		float L_11;
		L_11 = Vector3_SignedAngle_m816C32A674665A4C3C9D850FB0A107E69A4D3E0A(L_8, L_9, L_10, /*hidden argument*/NULL);
		V_1 = L_11;
		// m_TotalAngle += deltaAngle;
		float L_12 = __this->get_m_TotalAngle_13();
		float L_13 = V_1;
		__this->set_m_TotalAngle_13(((float)il2cpp_codegen_add((float)L_12, (float)L_13)));
		// m_LastDirection = currentDir;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14 = V_0;
		__this->set_m_LastDirection_11(L_14);
		// if (rotationUpdated != null) rotationUpdated.Invoke(new RotationUpdateInfo(
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_15 = __this->get_rotationUpdated_9();
		if (!L_15)
		{
			goto IL_00ab;
		}
	}
	{
		// if (rotationUpdated != null) rotationUpdated.Invoke(new RotationUpdateInfo(
		//     new RotationInfo( // World
		//         m_TotalAngle,
		//         deltaAngle,
		//         m_Normal),
		// 
		//     new RotationInfo(  // Local
		//         m_TotalAngle,
		//         deltaAngle,
		//         transform.worldToLocalMatrix.rotation * m_Normal)));
		Action_1_t9C27124DAC69046DEB79A26A0A307FD0FFFD5824 * L_16 = __this->get_rotationUpdated_9();
		float L_17 = __this->get_m_TotalAngle_13();
		float L_18 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_19 = __this->get_m_Normal_12();
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_20;
		memset((&L_20), 0, sizeof(L_20));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_20), L_17, L_18, L_19, /*hidden argument*/NULL);
		float L_21 = __this->get_m_TotalAngle_13();
		float L_22 = V_1;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_23;
		L_23 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_23);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_24;
		L_24 = Transform_get_worldToLocalMatrix_mE22FDE24767E1DE402D3E7A1C9803379B2E8399D(L_23, /*hidden argument*/NULL);
		V_3 = L_24;
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_25;
		L_25 = Matrix4x4_get_rotation_m3F80DDCCBDC01EBF36D61F382749AE704603C379((Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 *)(&V_3), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_26 = __this->get_m_Normal_12();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_27;
		L_27 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_25, L_26, /*hidden argument*/NULL);
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_28;
		memset((&L_28), 0, sizeof(L_28));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_28), L_21, L_22, L_27, /*hidden argument*/NULL);
		RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44  L_29;
		memset((&L_29), 0, sizeof(L_29));
		RotationUpdateInfo__ctor_mC61AC4A057E8B380E36E88C773BDE974E76012E0((&L_29), L_20, L_28, /*hidden argument*/NULL);
		NullCheck(L_16);
		Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E(L_16, L_29, /*hidden argument*/Action_1_Invoke_m85FDBE9A5041378821B64348E85C4A906F9DED8E_RuntimeMethod_var);
	}

IL_00ab:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::DragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_DragEnd_m780253FF2F7F3150BC7F6AB2E838242074BD6761 (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// var worldToLocalRotation = transform.worldToLocalMatrix.rotation;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_3;
		L_3 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_4;
		L_4 = Transform_get_worldToLocalMatrix_mE22FDE24767E1DE402D3E7A1C9803379B2E8399D(L_3, /*hidden argument*/NULL);
		V_1 = L_4;
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_5;
		L_5 = Matrix4x4_get_rotation_m3F80DDCCBDC01EBF36D61F382749AE704603C379((Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 *)(&V_1), /*hidden argument*/NULL);
		V_0 = L_5;
		// if (rotationEnded != null) rotationEnded.Invoke(new RotationEndInfo(
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_6 = __this->get_rotationEnded_10();
		if (!L_6)
		{
			goto IL_006d;
		}
	}
	{
		// if (rotationEnded != null) rotationEnded.Invoke(new RotationEndInfo(
		//     new RotationInfo( // World
		//         m_TotalAngle,
		//         0,
		//         m_Normal),
		// 
		//     new RotationInfo(  // Local
		//         m_TotalAngle,
		//         0,
		//         worldToLocalRotation * m_Normal)));
		Action_1_t474233CFB544C9CB00FC46CD92DDF783972E95F5 * L_7 = __this->get_rotationEnded_10();
		float L_8 = __this->get_m_TotalAngle_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = __this->get_m_Normal_12();
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_10;
		memset((&L_10), 0, sizeof(L_10));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_10), L_8, (0.0f), L_9, /*hidden argument*/NULL);
		float L_11 = __this->get_m_TotalAngle_13();
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_12 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = __this->get_m_Normal_12();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14;
		L_14 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_12, L_13, /*hidden argument*/NULL);
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_15;
		memset((&L_15), 0, sizeof(L_15));
		RotationInfo__ctor_m8E68AA0CB3DA6CF41A762E8A5CBD09DCE4A01356((&L_15), L_11, (0.0f), L_14, /*hidden argument*/NULL);
		RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449  L_16;
		memset((&L_16), 0, sizeof(L_16));
		RotationEndInfo__ctor_m5A00AD63782AE909506A93672A6AA49FC8DA1CA6((&L_16), L_10, L_15, /*hidden argument*/NULL);
		NullCheck(L_7);
		Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A(L_7, L_16, /*hidden argument*/Action_1_Invoke_mC0CCD14A663C89290DE2EDCBA70718D05B209D3A_RuntimeMethod_var);
	}

IL_006d:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle_OnDrawGizmosSelected_m05B45F85867A03A455D320C81E9BD896D298256C (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, const RuntimeMethod* method)
{
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// Gizmos.matrix =  transform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1, 1, 0));
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_1;
		L_1 = Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC(L_0, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		memset((&L_2), 0, sizeof(L_2));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_2), (1.0f), (1.0f), (0.0f), /*hidden argument*/NULL);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_3;
		L_3 = Matrix4x4_Scale_m62CFAE1F96495BD3F39D6FB21385C04B9ACC50ED(L_2, /*hidden argument*/NULL);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_4;
		L_4 = Matrix4x4_op_Multiply_mC2B30D333D4399C1693414F1A73D87FB3450F39F(L_1, L_3, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_4, /*hidden argument*/NULL);
		// var color = Color.blue;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_5;
		L_5 = Color_get_blue_m6D62D515CA10A6E760848E1BFB997E27B90BD07B(/*hidden argument*/NULL);
		V_0 = L_5;
		// Gizmos.color = color;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_6 = V_0;
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_6, /*hidden argument*/NULL);
		// Gizmos.DrawWireSphere(Vector3.zero, 1f);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Gizmos_DrawWireSphere_m96C425145BBD85CF0192F9DDB3D1A8C69429B78B(L_7, (1.0f), /*hidden argument*/NULL);
		// color.a = 0.2f;
		(&V_0)->set_a_3((0.200000003f));
		// Gizmos.color = color;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_8 = V_0;
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_8, /*hidden argument*/NULL);
		// Gizmos.DrawSphere(Vector3.zero, 1f);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Gizmos_DrawSphere_m50414CF8E502F4D93FC133091DA5E39543D69E91(L_9, (1.0f), /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RotatorHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RotatorHandle__ctor_m204846F85E0A6D05C4509C3B489CD47B2AD6C85A (RotatorHandle_t2DBB44BF5A8228B80C15339D0C6127546BB82DEB * __this, const RuntimeMethod* method)
{
	{
		InteractiveHandle__ctor_m9F68782D20A7C744E8CAE02A5ABF5466E10B77B9(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext__ctor_m86FAFF88D43F5C203405C56A1F338F6D6E9942FE (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, const RuntimeMethod* method)
{
	{
		// protected RuntimeHandleContext() : this(null)
		RuntimeHandleContext__ctor_m5A9F38F75675CFDED71F6E8A9EB9CBFD454A55F9(__this, (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C *)NULL, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::.ctor(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext__ctor_m5A9F38F75675CFDED71F6E8A9EB9CBFD454A55F9 (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// protected RuntimeHandleContext(Camera camera) : base(camera)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B_il2cpp_TypeInfo_var);
		HandleContext__ctor_mB6B690A6E88588172D614816FF57E530464EB6DE(__this, L_0, /*hidden argument*/NULL);
		// Camera.onPreRender += OnPreRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_1 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPreRender_5();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_2 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_2, __this, (intptr_t)((intptr_t)RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_3;
		L_3 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_1, L_2, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPreRender_5(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_3, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// Camera.onPostRender += OnPostRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_4 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPostRender_6();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_5 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_5, __this, (intptr_t)((intptr_t)RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_6;
		L_6 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_4, L_5, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPostRender_6(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_6, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext_Dispose_mA7CD8E7F76FF145935769C88B0695CCC9B71800A (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.Dispose();
		HandleContext_Dispose_mA9A2C9DF652B593532277B1E72F0E19C4B9EB117(__this, /*hidden argument*/NULL);
		// Camera.onPreRender -= OnPreRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_0 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPreRender_5();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_1 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_1, __this, (intptr_t)((intptr_t)RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_2;
		L_2 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_0, L_1, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPreRender_5(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_2, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// Camera.onPostRender -= OnPostRender;
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_3 = ((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->get_onPostRender_6();
		CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D * L_4 = (CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)il2cpp_codegen_object_new(CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var);
		CameraCallback__ctor_m6E26A220911F56F3E8936DDD217ED76A15B1915E(L_4, __this, (intptr_t)((intptr_t)RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC_RuntimeMethod_var), /*hidden argument*/NULL);
		Delegate_t * L_5;
		L_5 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_3, L_4, /*hidden argument*/NULL);
		((Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_StaticFields*)il2cpp_codegen_static_fields_for(Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C_il2cpp_TypeInfo_var))->set_onPostRender_6(((CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D *)CastclassSealed((RuntimeObject*)L_5, CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D_il2cpp_TypeInfo_var)));
		// }
		return;
	}
}
// UnityEngine.GameObject Unity.MARS.MARSHandles.RuntimeHandleContext::CreateHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * RuntimeHandleContext_CreateHandle_mFFA476DBB7F3464FA734FD815EF2308964CE0298 (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___prefab0, const RuntimeMethod* method)
{
	{
		// return base.CreateHandle(prefab);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___prefab0;
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_1;
		L_1 = HandleContext_CreateHandle_m9B4F0364872169F2131EE55027F3F10D88CC2102(__this, L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Boolean Unity.MARS.MARSHandles.RuntimeHandleContext::DestroyHandle(UnityEngine.GameObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RuntimeHandleContext_DestroyHandle_mADEF193B5C582F85C4D969898A04202EA43B0D0B (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * ___handle0, const RuntimeMethod* method)
{
	{
		// return base.DestroyHandle(handle);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_0 = ___handle0;
		bool L_1;
		L_1 = HandleContext_DestroyHandle_m980740978281037E35AAF81AF977A3239F5A7881(__this, L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::OnPreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext_OnPreRender_m39665E2865BE32F7BF0428A057F572B935080C6D (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___cam0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (cam == camera)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___cam0;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_1;
		L_1 = HandleContext_get_camera_m3443C04A9BBECC24BE477653D17C0D4ABDA19DFA_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0015;
		}
	}
	{
		// SendPreRender(cam);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = ___cam0;
		HandleContext_SendPreRender_m74B76DEE727AEEBD46754C8F56DA84492199732E(__this, L_3, /*hidden argument*/NULL);
	}

IL_0015:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.RuntimeHandleContext::OnPostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHandleContext_OnPostRender_mAC50BCF61543A47645465EF8F93209143E90E9FC (RuntimeHandleContext_t9BD22159E8CB40E2A220310FAAF628B8C3BE7A37 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___cam0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (cam == camera)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___cam0;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_1;
		L_1 = HandleContext_get_camera_m3443C04A9BBECC24BE477653D17C0D4ABDA19DFA_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0015;
		}
	}
	{
		// SendPostRender(cam);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_3 = ___cam0;
		HandleContext_SendPostRender_m0E6C90A66FE58E91DFB35AEC717A2B54DC675553(__this, L_3, /*hidden argument*/NULL);
	}

IL_0015:
	{
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.ScaleHandle::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_Awake_m02ECE8A823A139662A1BB816A6419481472BE8C9 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__0_mFE947AF56949443180513A6BD887A1C279EBB3E4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__1_mB4404C47AE65E376D9C7C6064DDBC49A70EE2146_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__2_mBFF2C9E8DA52B885E63B152B581635F4FE9B3EAB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* V_0 = NULL;
	int32_t V_1 = 0;
	SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * V_2 = NULL;
	U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * V_3 = NULL;
	{
		// foreach (var s in m_Sliders)
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_0 = __this->get_m_Sliders_7();
		V_0 = L_0;
		V_1 = 0;
		goto IL_006c;
	}

IL_000b:
	{
		// foreach (var s in m_Sliders)
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_1 = V_0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		int32_t L_3 = L_2;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		V_2 = L_4;
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_5 = (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 *)il2cpp_codegen_object_new(U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61_il2cpp_TypeInfo_var);
		U3CU3Ec__DisplayClass4_0__ctor_m5FB77025DFA10417073AEFFF5E00CA048C7CB6FD(L_5, /*hidden argument*/NULL);
		V_3 = L_5;
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_6 = V_3;
		NullCheck(L_6);
		L_6->set_U3CU3E4__this_1(__this);
		// var slider = s;
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_7 = V_3;
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_8 = V_2;
		NullCheck(L_7);
		L_7->set_slider_0(L_8);
		// slider.translationBegun += (info) => TranslationBegun(slider, info);
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_9 = V_3;
		NullCheck(L_9);
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_10 = L_9->get_slider_0();
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_11 = V_3;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_12 = (Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)il2cpp_codegen_object_new(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC(L_12, L_11, (intptr_t)((intptr_t)U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__0_mFE947AF56949443180513A6BD887A1C279EBB3E4_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mF50B7D31F28ECA67DF342DCD07A6F9C2B881B9CC_RuntimeMethod_var);
		NullCheck(L_10);
		SliderHandleBase_add_translationBegun_mCC5248C8B156875CCB69C04EF3CC4030928F6D78(L_10, L_12, /*hidden argument*/NULL);
		// slider.translationUpdated += (info) => TranslationUpdated(slider, info);
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_13 = V_3;
		NullCheck(L_13);
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_14 = L_13->get_slider_0();
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_15 = V_3;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_16 = (Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)il2cpp_codegen_object_new(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE(L_16, L_15, (intptr_t)((intptr_t)U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__1_mB4404C47AE65E376D9C7C6064DDBC49A70EE2146_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_mD8552BD4301EE2875E51AAB9747818AE9FECCFAE_RuntimeMethod_var);
		NullCheck(L_14);
		SliderHandleBase_add_translationUpdated_m78CAF25B6B9DF6E3D2861E4EC0785C9200E5E1F5(L_14, L_16, /*hidden argument*/NULL);
		// slider.translationEnded += (info) => TranslationEnded(slider, info);
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_17 = V_3;
		NullCheck(L_17);
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_18 = L_17->get_slider_0();
		U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * L_19 = V_3;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_20 = (Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)il2cpp_codegen_object_new(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E(L_20, L_19, (intptr_t)((intptr_t)U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__2_mBFF2C9E8DA52B885E63B152B581635F4FE9B3EAB_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_m9C3E0704326A7F18CF5135EE48837BDD360FDB5E_RuntimeMethod_var);
		NullCheck(L_18);
		SliderHandleBase_add_translationEnded_m0B4F029D79BF0523E8FD27D9CA0F97BB96DA45D5(L_18, L_20, /*hidden argument*/NULL);
		int32_t L_21 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_21, (int32_t)1));
	}

IL_006c:
	{
		// foreach (var s in m_Sliders)
		int32_t L_22 = V_1;
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_23 = V_0;
		NullCheck(L_23);
		if ((((int32_t)L_22) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_23)->max_length))))))
		{
			goto IL_000b;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationBegun(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationBegun_m53CB07A3474CF5E466DD495503C1DB276D4FB484 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___info1, const RuntimeMethod* method)
{
	{
		// if (scalingBegun != null) scalingBegun.Invoke();
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = __this->get_scalingBegun_4();
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		// if (scalingBegun != null) scalingBegun.Invoke();
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_1 = __this->get_scalingBegun_4();
		NullCheck(L_1);
		Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E(L_1, /*hidden argument*/NULL);
	}

IL_0013:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationUpdated(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationUpdated_m129FD7D6C157CC54C48E6F9DD1E270E5D3EB31A9 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (scaleUpdated != null) scaleUpdated.Invoke(new ScalingUpdatedInfo
		Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * L_0 = __this->get_scaleUpdated_5();
		if (!L_0)
		{
			goto IL_0080;
		}
	}
	{
		// if (scaleUpdated != null) scaleUpdated.Invoke(new ScalingUpdatedInfo
		// (
		//     new ScalingInfo(  //World
		//         Vector3.one,
		//         GetScaleFromTranslation(info.world.delta),
		//         GetScaleFromTranslation(info.world.total)),
		//     new ScalingInfo(  //Local
		//         Vector3.one,
		//         GetScaleFromTranslation(info.local.delta),
		//         GetScaleFromTranslation(info.local.total))
		// ));
		Action_1_tD8BACF4EE98D2A2B1D81AADD6C31326BE6942144 * L_1 = __this->get_scaleUpdated_5();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB(/*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_3;
		L_3 = TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)(&___info1), /*hidden argument*/NULL);
		V_0 = L_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)(&V_0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0(__this, L_4, /*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_6;
		L_6 = TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)(&___info1), /*hidden argument*/NULL);
		V_0 = L_6;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)(&V_0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0(__this, L_7, /*hidden argument*/NULL);
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_9;
		memset((&L_9), 0, sizeof(L_9));
		ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B((&L_9), L_2, L_5, L_8, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB(/*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_11;
		L_11 = TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)(&___info1), /*hidden argument*/NULL);
		V_0 = L_11;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)(&V_0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		L_13 = ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0(__this, L_12, /*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_14;
		L_14 = TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)(&___info1), /*hidden argument*/NULL);
		V_0 = L_14;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15;
		L_15 = TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)(&V_0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0(__this, L_15, /*hidden argument*/NULL);
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_17;
		memset((&L_17), 0, sizeof(L_17));
		ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B((&L_17), L_10, L_13, L_16, /*hidden argument*/NULL);
		ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1  L_18;
		memset((&L_18), 0, sizeof(L_18));
		ScalingUpdatedInfo__ctor_mB6ECDCB50395DECA81F9A05F2D466EA373F980E3((&L_18), L_9, L_17, /*hidden argument*/NULL);
		NullCheck(L_1);
		Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32(L_1, L_18, /*hidden argument*/Action_1_Invoke_m8B773D096A9151A6A5C2E17B0B8B2E0A86667D32_RuntimeMethod_var);
	}

IL_0080:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle::TranslationEnded(Unity.MARS.MARSHandles.SliderHandleBase,Unity.MARS.MARSHandles.TranslationEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle_TranslationEnded_mE4DAB19D2219EBBF63591899AD9CB2A65F660C7D (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * ___slider0, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___info1, const RuntimeMethod* method)
{
	{
		// if (scalingEnded != null) scalingEnded.Invoke();
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = __this->get_scalingEnded_6();
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		// if (scalingEnded != null) scalingEnded.Invoke();
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_1 = __this->get_scalingEnded_6();
		NullCheck(L_1);
		Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E(L_1, /*hidden argument*/NULL);
	}

IL_0013:
	{
		// }
		return;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScaleHandle::GetScaleFromTranslation(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScaleHandle_GetScaleFromTranslation_mC4B3AC7A9502C31F19DD2B52C04FFC4B166DF3D0 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___translation0, const RuntimeMethod* method)
{
	{
		// return translation;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___translation0;
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleHandle__ctor_m70B911825250ACB53A5768FEC31A08EECE7E0DE3 (ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// [SerializeField] SliderHandleBase[] m_Sliders = new SliderHandleBase[0];
		SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45* L_0 = (SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45*)(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45*)SZArrayNew(SliderHandleBaseU5BU5D_t339B3C7555BB425AF97B5FFD8B2424BF1A6F8A45_il2cpp_TypeInfo_var, (uint32_t)0);
		__this->set_m_Sliders_7(L_0);
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.ScaleWithCameraDistance::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleWithCameraDistance_Awake_mF88D2A16C4232D29B20B35A3ACC21996A51F2171 (ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21 * __this, const RuntimeMethod* method)
{
	{
		// m_InitialScale = transform.localScale;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_localScale_mD9DF6CA81108C2A6002B5EA2BE25A6CD2723D046(L_0, /*hidden argument*/NULL);
		__this->set_m_InitialScale_8(L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleWithCameraDistance::PreRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleWithCameraDistance_PreRender_m0B5EB4260F7BDA9C41BE44C7FB23EB8BFDD8D381 (ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// transform.localScale = Vector3.Scale(m_InitialScale, HandleUtility.GetHandleSizeVector(transform.position));
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = __this->get_m_InitialScale_8();
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_2;
		L_2 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_2);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_2, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = HandleUtility_GetHandleSizeVector_m78D4E723C7ED24485E9298275671B51C1321437D(L_3, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_Scale_m8805EE8D2586DE7B6143FA35819B3D5CF1981FB3_inline(L_1, L_4, /*hidden argument*/NULL);
		NullCheck(L_0);
		Transform_set_localScale_mF4D1611E48D1BA7566A1E166DC2DACF3ADD8BA3A(L_0, L_5, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleWithCameraDistance::PostRender(UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleWithCameraDistance_PostRender_m288B6DF0805ADA487F9F268DC91FB2A657CB8189 (ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21 * __this, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleWithCameraDistance::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScaleWithCameraDistance__ctor_mC62CA4EB835CF1F406AD16A2731E1F9323E49807 (ScaleWithCameraDistance_t58E5E1160A92DCB742F143AF00EC732817996B21 * __this, const RuntimeMethod* method)
{
	{
		HandleBehaviour__ctor_mDCF866C43F77DF2B4D1B6279089CBDA13E3ABACF(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_initial()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_initial_m45D786434B7DD9ADA18E7D4869989CE44823D606 (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initial { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_initial_m45D786434B7DD9ADA18E7D4869989CE44823D606_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = ScalingInfo_get_initial_m45D786434B7DD9ADA18E7D4869989CE44823D606_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_initial(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initial { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_delta()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_delta_m72D45D52AEB9EDBF7723B3546D5DBAFAC88B1850 (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_delta_m72D45D52AEB9EDBF7723B3546D5DBAFAC88B1850_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = ScalingInfo_get_delta_m72D45D52AEB9EDBF7723B3546D5DBAFAC88B1850_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_delta(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267 (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.ScalingInfo::get_total()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_total_m89F9E2CDDC74901D68AEAA536B8800F4C81F97CF (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CtotalU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_total_m89F9E2CDDC74901D68AEAA536B8800F4C81F97CF_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = ScalingInfo_get_total_m89F9E2CDDC74901D68AEAA536B8800F4C81F97CF_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.ScalingInfo::set_total(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3 (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.ScalingInfo::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initial0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, const RuntimeMethod* method)
{
	{
		// public ScalingInfo(Vector3 initial, Vector3 delta, Vector3 total) : this()
		il2cpp_codegen_initobj(__this, sizeof(ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED ));
		// this.initial = initial;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___initial0;
		ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD_inline((ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *)__this, L_0, /*hidden argument*/NULL);
		// this.delta = delta;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___delta1;
		ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267_inline((ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *)__this, L_1, /*hidden argument*/NULL);
		// this.total = total;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___total2;
		ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3_inline((ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *)__this, L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initial0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * _thisAdjusted = reinterpret_cast<ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED *>(__this + _offset);
	ScalingInfo__ctor_m5393EC578399960F38A6F22351E54FFD677D740B(_thisAdjusted, ___initial0, ___delta1, ___total2, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_world_m6900153CD29B1043352AEE9F53E8EB3C82D06185 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method)
{
	{
		// public ScalingInfo world { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_world_m6900153CD29B1043352AEE9F53E8EB3C82D06185_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * _thisAdjusted = reinterpret_cast<ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *>(__this + _offset);
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  _returnValue;
	_returnValue = ScalingUpdatedInfo_get_world_m6900153CD29B1043352AEE9F53E8EB3C82D06185_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::set_world(Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	{
		// public ScalingInfo world { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283_AdjustorThunk (RuntimeObject * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * _thisAdjusted = reinterpret_cast<ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *>(__this + _offset);
	ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.ScalingInfo Unity.MARS.MARSHandles.ScalingUpdatedInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_local_m1C58BC4935A0B0A238779F5FB6A26C9C00B1C400 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method)
{
	{
		// public ScalingInfo local { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_local_m1C58BC4935A0B0A238779F5FB6A26C9C00B1C400_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * _thisAdjusted = reinterpret_cast<ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *>(__this + _offset);
	ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  _returnValue;
	_returnValue = ScalingUpdatedInfo_get_local_m1C58BC4935A0B0A238779F5FB6A26C9C00B1C400_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::set_local(Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	{
		// public ScalingInfo local { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0_AdjustorThunk (RuntimeObject * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * _thisAdjusted = reinterpret_cast<ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *>(__this + _offset);
	ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.ScalingUpdatedInfo::.ctor(Unity.MARS.MARSHandles.ScalingInfo,Unity.MARS.MARSHandles.ScalingInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScalingUpdatedInfo__ctor_mB6ECDCB50395DECA81F9A05F2D466EA373F980E3 (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___world0, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___local1, const RuntimeMethod* method)
{
	{
		// public ScalingUpdatedInfo(ScalingInfo world, ScalingInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 ));
		// this.world = world;
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = ___world0;
		ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283_inline((ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_1 = ___local1;
		ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0_inline((ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void ScalingUpdatedInfo__ctor_mB6ECDCB50395DECA81F9A05F2D466EA373F980E3_AdjustorThunk (RuntimeObject * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___world0, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * _thisAdjusted = reinterpret_cast<ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 *>(__this + _offset);
	ScalingUpdatedInfo__ctor_mB6ECDCB50395DECA81F9A05F2D466EA373F980E3(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::get_direction()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider1DHandle_get_direction_m76C1782478897A1F2832BE1A22BF2AA6B5096826 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method)
{
	{
		// get { return transform.forward; }
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// UnityEngine.Ray Unity.MARS.MARSHandles.Slider1DHandle::get_directionRay()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  Slider1DHandle_get_directionRay_m65817A4729FA853E76C37463624D681D73A9DBFF (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method)
{
	{
		// get { return new Ray(transform.position, direction);}
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_0, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Slider1DHandle_get_direction_m76C1782478897A1F2832BE1A22BF2AA6B5096826(__this, /*hidden argument*/NULL);
		Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  L_3;
		memset((&L_3), 0, sizeof(L_3));
		Ray__ctor_m75B1F651FF47EE6B887105101B7DA61CBF41F83C((&L_3), L_1, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// UnityEngine.Plane Unity.MARS.MARSHandles.Slider1DHandle::GetProjectionPlane(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  Slider1DHandle_GetProjectionPlane_m51CFBD0511F45955A905F7EDD1F680432273FC52 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___camPosition0, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		// Vector3 pos = transform.position;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		// Vector3 forward = transform.forward;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_2;
		L_2 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_2);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053(L_2, /*hidden argument*/NULL);
		V_1 = L_3;
		// Vector3 camDir = camPosition - pos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___camPosition0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_4, L_5, /*hidden argument*/NULL);
		V_2 = L_6;
		// return new Plane(pos, pos + forward, pos + Vector3.Cross(forward, camDir));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_8, L_9, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14;
		L_14 = Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4(L_12, L_13, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15;
		L_15 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_11, L_14, /*hidden argument*/NULL);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_16;
		memset((&L_16), 0, sizeof(L_16));
		Plane__ctor_m9CFA0680D3935F859B6478E777A34168D4F1D19A((&L_16), L_7, L_10, L_15, /*hidden argument*/NULL);
		return L_16;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider1DHandle::OnTranslationBegin(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider1DHandle_OnTranslationBegin_m3911AA639BD97D564C3AFEEFB824617DD2CA3D62 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// Vector3 handlePosition = transform.position;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		// m_LastFramePos = handlePosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = V_0;
		__this->set_m_LastFramePos_21(L_2);
		// m_HandleStartPos = MathUtility.ProjectPointOnRay(translationInfo.currentPosition, directionRay);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&___translationInfo0), /*hidden argument*/NULL);
		Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  L_4;
		L_4 = Slider1DHandle_get_directionRay_m65817A4729FA853E76C37463624D681D73A9DBFF(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = MathUtility_ProjectPointOnRay_mFAB92ED2A01405B2A6C62EA3C6EA07A4405531ED(L_3, L_4, /*hidden argument*/NULL);
		__this->set_m_HandleStartPos_17(L_5);
		// Vector3 offset = m_HandleStartPos - handlePosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = __this->get_m_HandleStartPos_17();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_6, L_7, /*hidden argument*/NULL);
		V_1 = L_8;
		// m_StartNormalizedOffset = offset / HandleUtility.GetHandleSize(handlePosition);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		float L_11;
		L_11 = HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F(L_10, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector3_op_Division_mE5ACBFB168FED529587457A83BA98B7DB32E2A05_inline(L_9, L_11, /*hidden argument*/NULL);
		__this->set_m_StartNormalizedOffset_18(L_12);
		// m_StartCenterPosSize = HandleUtility.GetHandleSize(handlePosition);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_0;
		float L_14;
		L_14 = HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F(L_13, /*hidden argument*/NULL);
		__this->set_m_StartCenterPosSize_19(L_14);
		// m_StartHandlePosSize = HandleUtility.GetHandleSize(m_HandleStartPos);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = __this->get_m_HandleStartPos_17();
		float L_16;
		L_16 = HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F(L_15, /*hidden argument*/NULL);
		__this->set_m_StartHandlePosSize_20(L_16);
		// }
		return;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider1DHandle::GetWorldTranslationDelta(Unity.MARS.MARSHandles.DragTranslation,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider1DHandle_GetWorldTranslationDelta_m716CC6419D3E42B45D66BAF65986265858A732B2 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___sourcePos1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	float V_1 = 0.0f;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_3;
	memset((&V_3), 0, sizeof(V_3));
	{
		// Vector3 projected = MathUtility.ProjectPointOnRay(translationInfo.currentPosition, directionRay);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&___translationInfo0), /*hidden argument*/NULL);
		Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  L_1;
		L_1 = Slider1DHandle_get_directionRay_m65817A4729FA853E76C37463624D681D73A9DBFF(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = MathUtility_ProjectPointOnRay_mFAB92ED2A01405B2A6C62EA3C6EA07A4405531ED(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		// float handleTargetSize = HandleUtility.GetHandleSize(projected); //TODO this isn't true if the target doesn't scale with screen
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(HandleUtility_t8646AF710C782E97014C038CDFB37D843ECD5A47_il2cpp_TypeInfo_var);
		float L_4;
		L_4 = HandleUtility_GetHandleSize_mBD9D9D26659D3FB8767C9C5215B0D20235605C4F(L_3, /*hidden argument*/NULL);
		// float centerTargetSize = handleTargetSize * m_StartCenterPosSize / m_StartHandlePosSize;
		float L_5 = __this->get_m_StartCenterPosSize_19();
		float L_6 = __this->get_m_StartHandlePosSize_20();
		V_1 = ((float)((float)((float)il2cpp_codegen_multiply((float)L_4, (float)L_5))/(float)L_6));
		// Vector3 newOffset = m_StartNormalizedOffset * centerTargetSize;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = __this->get_m_StartNormalizedOffset_18();
		float L_8 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_7, L_8, /*hidden argument*/NULL);
		V_2 = L_9;
		// Vector3 newPos = projected - newOffset;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_10, L_11, /*hidden argument*/NULL);
		V_3 = L_12;
		// var delta = newPos - m_LastFramePos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14 = __this->get_m_LastFramePos_21();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15;
		L_15 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_13, L_14, /*hidden argument*/NULL);
		// m_LastFramePos = newPos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16 = V_3;
		__this->set_m_LastFramePos_21(L_16);
		// m_HandleStartPos = projected;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17 = V_0;
		__this->set_m_HandleStartPos_17(L_17);
		// return delta;
		return L_15;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider1DHandle::OnTranslationEnd(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider1DHandle_OnTranslationEnd_m43CF07805F3829EDBC59C2F3E9C89CB032ED3F32 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider1DHandle::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider1DHandle_OnDrawGizmosSelected_mD975E21E6DE87D4A883FD3167FFA83CA84DBDDA7 (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method)
{
	{
		// Gizmos.matrix = Matrix4x4.Translate(transform.position);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_0, /*hidden argument*/NULL);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_2;
		L_2 = Matrix4x4_Translate_m48688727FA7BBA42DF2108C1A9395FC23431AC9A(L_1, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_2, /*hidden argument*/NULL);
		// Gizmos.color = Color.blue;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_3;
		L_3 = Color_get_blue_m6D62D515CA10A6E760848E1BFB997E27B90BD07B(/*hidden argument*/NULL);
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_3, /*hidden argument*/NULL);
		// Gizmos.DrawLine(direction * 1000, -direction * 1000);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = Slider1DHandle_get_direction_m76C1782478897A1F2832BE1A22BF2AA6B5096826(__this, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_4, (1000.0f), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Slider1DHandle_get_direction_m76C1782478897A1F2832BE1A22BF2AA6B5096826(__this, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Vector3_op_UnaryNegation_m362EA356F4CADEDB39F965A0DBDED6EA890925F7_inline(L_6, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_7, (1000.0f), /*hidden argument*/NULL);
		Gizmos_DrawLine_m91F1AA0205C7D53D2AA8E2F1D7B338E601A30823(L_5, L_8, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider1DHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider1DHandle__ctor_mE34224413FAF39D21FBAFAF73255BFB2088F158F (Slider1DHandle_t1CC5056033C491B49BE0A86F5CB71C721DDA2D30 * __this, const RuntimeMethod* method)
{
	{
		SliderHandleBase__ctor_mC21AA163B37015688C7516E4E931793C2CF776B9(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Plane Unity.MARS.MARSHandles.Slider2DHandle::GetProjectionPlane(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  Slider2DHandle_GetProjectionPlane_mDE5F01F1F0C5ECD0F48F4DA3BCCF4ED985BCBFE9 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___camPosition0, const RuntimeMethod* method)
{
	{
		// return new Plane(planeNormal, transform.position);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = Slider2DHandle_get_planeNormal_mB4BC7CFB517757D849A2CB6E153C2E68879F3011(__this, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_1, /*hidden argument*/NULL);
		Plane_t80844BF2332EAFC1DDEDD616A950242031A115C7  L_3;
		memset((&L_3), 0, sizeof(L_3));
		Plane__ctor_m5B830C0E99AA5A47EF0D15767828D6E859867E67((&L_3), L_0, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider2DHandle::get_planeNormal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider2DHandle_get_planeNormal_mB4BC7CFB517757D849A2CB6E153C2E68879F3011 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 planeNormal { get { return transform.forward;} }
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider2DHandle::OnTranslationBegin(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider2DHandle_OnTranslationBegin_m948ED61A81D313DC1CE091BAE6DE362713C39647 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	{
		// m_LastHitPos = translationInfo.currentPosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&___translationInfo0), /*hidden argument*/NULL);
		__this->set_m_LastHitPos_15(L_0);
		// }
		return;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Slider2DHandle::GetWorldTranslationDelta(Unity.MARS.MARSHandles.DragTranslation,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Slider2DHandle_GetWorldTranslationDelta_m3E79D518951E27BFE278BE21BAAA0B9E00BC4919 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___sourcePos1, const RuntimeMethod* method)
{
	{
		// var delta = translationInfo.currentPosition - m_LastHitPos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&___translationInfo0), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = __this->get_m_LastHitPos_15();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_0, L_1, /*hidden argument*/NULL);
		// m_LastHitPos = translationInfo.currentPosition;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)(&___translationInfo0), /*hidden argument*/NULL);
		__this->set_m_LastHitPos_15(L_3);
		// return delta;
		return L_2;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider2DHandle::OnTranslationEnd(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider2DHandle_OnTranslationEnd_m3931413F6124039A54A3B3BD79A5AF56E900EDD6 (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider2DHandle::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider2DHandle_OnDrawGizmosSelected_mDCA64292531D0233FACC61E51ECF812C8457669D (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, const RuntimeMethod* method)
{
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// var color = Color.blue;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		L_0 = Color_get_blue_m6D62D515CA10A6E760848E1BFB997E27B90BD07B(/*hidden argument*/NULL);
		V_0 = L_0;
		// Gizmos.color = color;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_1 = V_0;
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_1, /*hidden argument*/NULL);
		// Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one * 10);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_2;
		L_2 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_2);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = Transform_get_position_m40A8A9895568D56FFC687B57F30E8D53CB5EA341(L_2, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_4;
		L_4 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_4);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_5;
		L_5 = Transform_get_rotation_m4AA3858C00DF4C9614B80352558C4C37D08D2200(L_4, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_6, (10.0f), /*hidden argument*/NULL);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_8;
		L_8 = Matrix4x4_TRS_m0CBC696D0BDF58DCEC40B99BC32C716FAD024CE5(L_3, L_5, L_7, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_8, /*hidden argument*/NULL);
		// Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 0));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		memset((&L_10), 0, sizeof(L_10));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_10), (1.0f), (1.0f), (0.0f), /*hidden argument*/NULL);
		Gizmos_DrawWireCube_mC526244E50C6E5793D4066C9C99023D5FF8424BF(L_9, L_10, /*hidden argument*/NULL);
		// color.a = 0.1f;
		(&V_0)->set_a_3((0.100000001f));
		// Gizmos.color = color;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_11 = V_0;
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_11, /*hidden argument*/NULL);
		// Gizmos.DrawCube(Vector3.zero, new Vector3(1, 1, 0));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		memset((&L_13), 0, sizeof(L_13));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_13), (1.0f), (1.0f), (0.0f), /*hidden argument*/NULL);
		Gizmos_DrawCube_mCF599EC2E7ABB92994C186412B6E8F39140F66C4(L_12, L_13, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Slider2DHandle::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Slider2DHandle__ctor_mF5BE986AE93106CB882564EDA0285A66010A9C3B (Slider2DHandle_t4A06B13A2E21EF76E8164267E3EF90F896266A06 * __this, const RuntimeMethod* method)
{
	{
		// Vector3 m_LastHitPos = Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		__this->set_m_LastHitPos_15(L_0);
		SliderHandleBase__ctor_mC21AA163B37015688C7516E4E931793C2CF776B9(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationBegun(System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationBegun_mCC5248C8B156875CCB69C04EF3CC4030928F6D78 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_0 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_1 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_2 = NULL;
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_0 = __this->get_translationBegun_8();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_2 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var));
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** L_5 = __this->get_address_of_translationBegun_8();
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_6 = V_2;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_7 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *>((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_9 = V_0;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_9) == ((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::remove_translationBegun(System.Action`1<Unity.MARS.MARSHandles.TranslationBeginInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_remove_translationBegun_mFBA4C62BA26CE1FB500CB7D5E7D63D9FD465D90C (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_0 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_1 = NULL;
	Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * V_2 = NULL;
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_0 = __this->get_translationBegun_8();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_2 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8_il2cpp_TypeInfo_var));
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 ** L_5 = __this->get_address_of_translationBegun_8();
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_6 = V_2;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_7 = V_1;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *>((Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_9 = V_0;
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_9) == ((RuntimeObject*)(Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationUpdated(System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationUpdated_m78CAF25B6B9DF6E3D2861E4EC0785C9200E5E1F5 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_0 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_1 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_2 = NULL;
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_0 = __this->get_translationUpdated_9();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_2 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var));
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** L_5 = __this->get_address_of_translationUpdated_9();
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_6 = V_2;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_7 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *>((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_9 = V_0;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_9) == ((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::remove_translationUpdated(System.Action`1<Unity.MARS.MARSHandles.TranslationUpdateInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_remove_translationUpdated_mCF4564E8E1620AD7C0E665D0AEADCCC55E989877 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_0 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_1 = NULL;
	Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * V_2 = NULL;
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_0 = __this->get_translationUpdated_9();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_1 = V_0;
		V_1 = L_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_2 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)CastclassSealed((RuntimeObject*)L_4, Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1_il2cpp_TypeInfo_var));
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 ** L_5 = __this->get_address_of_translationUpdated_9();
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_6 = V_2;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_7 = V_1;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *>((Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_9 = V_0;
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_9) == ((RuntimeObject*)(Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::add_translationEnded(System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_add_translationEnded_m0B4F029D79BF0523E8FD27D9CA0F97BB96DA45D5 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_0 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_1 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_2 = NULL;
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_0 = __this->get_translationEnded_10();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_1 = V_0;
		V_1 = L_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_2 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)CastclassSealed((RuntimeObject*)L_4, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var));
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** L_5 = __this->get_address_of_translationEnded_10();
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_6 = V_2;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_7 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *>((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_9 = V_0;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_9) == ((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::remove_translationEnded(System.Action`1<Unity.MARS.MARSHandles.TranslationEndInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_remove_translationEnded_m06C1A86CC30DA1985AB4A1792C71173F4E96CB13 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_0 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_1 = NULL;
	Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * V_2 = NULL;
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_0 = __this->get_translationEnded_10();
		V_0 = L_0;
	}

IL_0007:
	{
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_1 = V_0;
		V_1 = L_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_2 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)CastclassSealed((RuntimeObject*)L_4, Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA_il2cpp_TypeInfo_var));
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA ** L_5 = __this->get_address_of_translationEnded_10();
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_6 = V_2;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_7 = V_1;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *>((Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA **)L_5, L_6, L_7);
		V_0 = L_8;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_9 = V_0;
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_9) == ((RuntimeObject*)(Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::OnTranslationBegin(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_OnTranslationBegin_m614389518335B512275191C0EC00A61616B0AFD5 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::OnTranslationEnd(Unity.MARS.MARSHandles.DragTranslation)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_OnTranslationEnd_m7F3902ECEDC80992E091D217B71EDA4B46BEF690 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___translationInfo0, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::DragBegin(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_DragBegin_mA2F12C3BBE825277A83AFF474111981E9A6096CC (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// m_InitialPosWorld = info.translation.initialPosition;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * L_3 = (&___info1)->get_address_of_translation_0();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_inline((DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA *)L_3, /*hidden argument*/NULL);
		__this->set_m_InitialPosWorld_11(L_4);
		// m_InitialPosLocal = Quaternion.Inverse(transform.localRotation) * transform.localPosition;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_5;
		L_5 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_5);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_6;
		L_6 = Transform_get_localRotation_mA6472AE7509D762965275D79B645A14A9CCF5BE5(L_5, /*hidden argument*/NULL);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_7;
		L_7 = Quaternion_Inverse_mE2A449C7AC8A40350AAC3761AE1AFC170062CAC9(L_6, /*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_8;
		L_8 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_8);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Transform_get_localPosition_m527B8B5B625DA9A61E551E0FBCD3BE8CA4539FC2(L_8, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_7, L_9, /*hidden argument*/NULL);
		__this->set_m_InitialPosLocal_12(L_10);
		// m_TotalTranslation = Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		L_11 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		__this->set_m_TotalTranslation_13(L_11);
		// if (translationBegun != null)
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_12 = __this->get_translationBegun_8();
		if (!L_12)
		{
			goto IL_00b4;
		}
	}
	{
		// translationBegun.Invoke(new TranslationBeginInfo(
		//     //World
		//     new TranslationInfo(
		//         m_InitialPosWorld,
		//         Vector3.zero,
		//         Vector3.zero,
		//         transform.forward),
		// 
		//     //Local
		//     new TranslationInfo(
		//         m_InitialPosLocal,
		//         Vector3.zero,
		//         Vector3.zero,
		//         transform.localRotation * Vector3.forward)));
		Action_1_t5697B2C62CA90FECCCDAD7FF29E1BD93D71653F8 * L_13 = __this->get_translationBegun_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14 = __this->get_m_InitialPosWorld_11();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15;
		L_15 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_17;
		L_17 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_17);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18;
		L_18 = Transform_get_forward_mD850B9ECF892009E3485408DC0D375165B7BF053(L_17, /*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_19;
		memset((&L_19), 0, sizeof(L_19));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_19), L_14, L_15, L_16, L_18, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20 = __this->get_m_InitialPosLocal_12();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_21;
		L_21 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_22;
		L_22 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_23;
		L_23 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_23);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_24;
		L_24 = Transform_get_localRotation_mA6472AE7509D762965275D79B645A14A9CCF5BE5(L_23, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_25;
		L_25 = Vector3_get_forward_m3082920F8A24AA02E4F542B6771EB0B63A91AC90(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_26;
		L_26 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_24, L_25, /*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_27;
		memset((&L_27), 0, sizeof(L_27));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_27), L_20, L_21, L_22, L_26, /*hidden argument*/NULL);
		TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  L_28;
		memset((&L_28), 0, sizeof(L_28));
		TranslationBeginInfo__ctor_mD180C3B256CFE02D9CEB33FAFA75A21ED6A9F5A6((&L_28), L_19, L_27, /*hidden argument*/NULL);
		NullCheck(L_13);
		Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0(L_13, L_28, /*hidden argument*/Action_1_Invoke_m5BEFDDF9E3D5BB2AD07C8E8465BDC975BE5FFBE0_RuntimeMethod_var);
	}

IL_00b4:
	{
		// OnTranslationBegin(info.translation);
		DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  L_29 = ___info1;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_30 = L_29.get_translation_0();
		VirtActionInvoker1< DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  >::Invoke(15 /* System.Void Unity.MARS.MARSHandles.SliderHandleBase::OnTranslationBegin(Unity.MARS.MARSHandles.DragTranslation) */, __this, L_30);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::DragUpdate(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_DragUpdate_m139B3CE96996C57F12D535E58041E0F3A38A4FEE (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// var delta = GetWorldTranslationDelta(info.translation, m_InitialPosWorld);
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_3;
		L_3 = DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_inline((DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *)(&___info1), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = __this->get_m_InitialPosWorld_11();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = VirtFuncInvoker2< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA , Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(17 /* UnityEngine.Vector3 Unity.MARS.MARSHandles.SliderHandleBase::GetWorldTranslationDelta(Unity.MARS.MARSHandles.DragTranslation,UnityEngine.Vector3) */, __this, L_3, L_4);
		V_0 = L_5;
		// m_TotalTranslation = m_TotalTranslation + delta;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = __this->get_m_TotalTranslation_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_6, L_7, /*hidden argument*/NULL);
		__this->set_m_TotalTranslation_13(L_8);
		// m_CurrentDirection = delta.normalized;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector3_get_normalized_m2FA6DF38F97BDA4CCBDAE12B9FE913A241DAC8D5((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&V_0), /*hidden argument*/NULL);
		__this->set_m_CurrentDirection_14(L_9);
		// var inverseRotation = Quaternion.Inverse(transform.rotation);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_10;
		L_10 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_10);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_11;
		L_11 = Transform_get_rotation_m4AA3858C00DF4C9614B80352558C4C37D08D2200(L_10, /*hidden argument*/NULL);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_12;
		L_12 = Quaternion_Inverse_mE2A449C7AC8A40350AAC3761AE1AFC170062CAC9(L_11, /*hidden argument*/NULL);
		V_1 = L_12;
		// if (translationUpdated != null)
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_13 = __this->get_translationUpdated_9();
		if (!L_13)
		{
			goto IL_00ad;
		}
	}
	{
		// translationUpdated.Invoke(new TranslationUpdateInfo(
		//     //World
		//     new TranslationInfo(
		//         m_InitialPosWorld,
		//         delta,
		//         m_TotalTranslation,
		//         m_CurrentDirection),
		// 
		//     //Local
		//     new TranslationInfo(
		//         m_InitialPosLocal,
		//         inverseRotation * delta,
		//         inverseRotation * m_TotalTranslation,
		//         inverseRotation * m_CurrentDirection)
		// ));
		Action_1_t98D8D628DACCC900BDBE194B8E87705C4EE8E7E1 * L_14 = __this->get_translationUpdated_9();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = __this->get_m_InitialPosWorld_11();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17 = __this->get_m_TotalTranslation_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18 = __this->get_m_CurrentDirection_14();
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_19;
		memset((&L_19), 0, sizeof(L_19));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_19), L_15, L_16, L_17, L_18, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20 = __this->get_m_InitialPosLocal_12();
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_21 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_22 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_23;
		L_23 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_21, L_22, /*hidden argument*/NULL);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_24 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_25 = __this->get_m_TotalTranslation_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_26;
		L_26 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_24, L_25, /*hidden argument*/NULL);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_27 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_28 = __this->get_m_CurrentDirection_14();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_29;
		L_29 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_27, L_28, /*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_30;
		memset((&L_30), 0, sizeof(L_30));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_30), L_20, L_23, L_26, L_29, /*hidden argument*/NULL);
		TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  L_31;
		memset((&L_31), 0, sizeof(L_31));
		TranslationUpdateInfo__ctor_m9019C924C8F38EB025A0B46F6FD66DA2496D5489((&L_31), L_19, L_30, /*hidden argument*/NULL);
		NullCheck(L_14);
		Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274(L_14, L_31, /*hidden argument*/Action_1_Invoke_m609809ABDD8F3A748083C007009BDBF31ED76274_RuntimeMethod_var);
	}

IL_00ad:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::DragEnd(Unity.MARS.MARSHandles.InteractiveHandle,Unity.MARS.MARSHandles.DragEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase_DragEnd_m323B7BA40EE8B65EF8A9B49DF405185A4C27A307 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___target0, DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  ___info1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (target != ownerHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = ___target0;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1;
		L_1 = HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// if (translationEnded != null)
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_3 = __this->get_translationEnded_10();
		if (!L_3)
		{
			goto IL_0072;
		}
	}
	{
		// translationEnded.Invoke(new TranslationEndInfo(
		//     //World
		//     new TranslationInfo(
		//         m_InitialPosWorld,
		//         Vector3.zero,
		//         m_TotalTranslation,
		//         Vector3.zero),
		// 
		//     //Local
		//     new TranslationInfo(
		//         m_InitialPosLocal,
		//         Vector3.zero,
		//         Quaternion.Inverse(transform.rotation) * m_TotalTranslation,
		//         Vector3.zero)));
		Action_1_t75A2FDCC5D2B30EC457F17FB888147C868BD87FA * L_4 = __this->get_translationEnded_10();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5 = __this->get_m_InitialPosWorld_11();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = __this->get_m_TotalTranslation_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_9;
		memset((&L_9), 0, sizeof(L_9));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_9), L_5, L_6, L_7, L_8, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = __this->get_m_InitialPosLocal_12();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		L_11 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_12;
		L_12 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_12);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_13;
		L_13 = Transform_get_rotation_m4AA3858C00DF4C9614B80352558C4C37D08D2200(L_12, /*hidden argument*/NULL);
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_14;
		L_14 = Quaternion_Inverse_mE2A449C7AC8A40350AAC3761AE1AFC170062CAC9(L_13, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = __this->get_m_TotalTranslation_13();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_14, L_15, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17;
		L_17 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_18;
		memset((&L_18), 0, sizeof(L_18));
		TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73((&L_18), L_10, L_11, L_16, L_17, /*hidden argument*/NULL);
		TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  L_19;
		memset((&L_19), 0, sizeof(L_19));
		TranslationEndInfo__ctor_mDD0DC997464BA990D75B0885B1005F4951FD3A2D((&L_19), L_9, L_18, /*hidden argument*/NULL);
		NullCheck(L_4);
		Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C(L_4, L_19, /*hidden argument*/Action_1_Invoke_mE60917A12906C99E62C53D9A137B82B1AED4C90C_RuntimeMethod_var);
	}

IL_0072:
	{
		// m_CurrentDirection = Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20;
		L_20 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		__this->set_m_CurrentDirection_14(L_20);
		// m_TotalTranslation = Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_21;
		L_21 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		__this->set_m_TotalTranslation_13(L_21);
		// OnTranslationEnd(info.translation);
		DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  L_22 = ___info1;
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_23 = L_22.get_translation_0();
		VirtActionInvoker1< DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  >::Invoke(16 /* System.Void Unity.MARS.MARSHandles.SliderHandleBase::OnTranslationEnd(Unity.MARS.MARSHandles.DragTranslation) */, __this, L_23);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.SliderHandleBase::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SliderHandleBase__ctor_mC21AA163B37015688C7516E4E931793C2CF776B9 (SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * __this, const RuntimeMethod* method)
{
	{
		InteractiveHandle__ctor_m9F68782D20A7C744E8CAE02A5ABF5466E10B77B9(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_world_m339141700BFD547B9776F447A2ED644F49FD1722 (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_world_m339141700BFD547B9776F447A2ED644F49FD1722_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * _thisAdjusted = reinterpret_cast<TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationBeginInfo_get_world_m339141700BFD547B9776F447A2ED644F49FD1722_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232 (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * _thisAdjusted = reinterpret_cast<TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *>(__this + _offset);
	TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationBeginInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_local_m3E176F6CC06B3E3CC69A71B0EF1C01969160D02C (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_local_m3E176F6CC06B3E3CC69A71B0EF1C01969160D02C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * _thisAdjusted = reinterpret_cast<TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationBeginInfo_get_local_m3E176F6CC06B3E3CC69A71B0EF1C01969160D02C_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012 (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * _thisAdjusted = reinterpret_cast<TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *>(__this + _offset);
	TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.TranslationBeginInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationBeginInfo__ctor_mD180C3B256CFE02D9CEB33FAFA75A21ED6A9F5A6 (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	{
		// public TranslationBeginInfo(TranslationInfo world, TranslationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA ));
		// this.world = world;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___world0;
		TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232_inline((TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_1 = ___local1;
		TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012_inline((TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationBeginInfo__ctor_mD180C3B256CFE02D9CEB33FAFA75A21ED6A9F5A6_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * _thisAdjusted = reinterpret_cast<TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA *>(__this + _offset);
	TranslationBeginInfo__ctor_mD180C3B256CFE02D9CEB33FAFA75A21ED6A9F5A6(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_world_mAA199ACA11FDC6250AA16B01419642A6D2DA4CDF (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_world_mAA199ACA11FDC6250AA16B01419642A6D2DA4CDF_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * _thisAdjusted = reinterpret_cast<TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationEndInfo_get_world_mAA199ACA11FDC6250AA16B01419642A6D2DA4CDF_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * _thisAdjusted = reinterpret_cast<TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *>(__this + _offset);
	TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationEndInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_local_m7391D5DCCD007E17B45CB2F315F53CF2CF5DA34D (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_local_m7391D5DCCD007E17B45CB2F315F53CF2CF5DA34D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * _thisAdjusted = reinterpret_cast<TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationEndInfo_get_local_m7391D5DCCD007E17B45CB2F315F53CF2CF5DA34D_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97 (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * _thisAdjusted = reinterpret_cast<TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *>(__this + _offset);
	TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.TranslationEndInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationEndInfo__ctor_mDD0DC997464BA990D75B0885B1005F4951FD3A2D (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	{
		// public TranslationEndInfo(TranslationInfo world, TranslationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B ));
		// this.world = world;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___world0;
		TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC_inline((TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_1 = ___local1;
		TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97_inline((TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationEndInfo__ctor_mDD0DC997464BA990D75B0885B1005F4951FD3A2D_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * _thisAdjusted = reinterpret_cast<TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B *>(__this + _offset);
	TranslationEndInfo__ctor_mDD0DC997464BA990D75B0885B1005F4951FD3A2D(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_initialPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_initialPosition_m14AD77A8DF15FFC178D8E958164D5961B68B0CCA (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialPositionU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_initialPosition_m14AD77A8DF15FFC178D8E958164D5961B68B0CCA_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = TranslationInfo_get_initialPosition_m14AD77A8DF15FFC178D8E958164D5961B68B0CCA_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_initialPosition(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialPositionU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_delta()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828 (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_delta(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_total()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CtotalU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_total(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05 (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.TranslationInfo::get_direction()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_direction_m91A56BB213E808121F10634E88D14AA37B384E62 (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 direction { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdirectionU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_direction_m91A56BB213E808121F10634E88D14AA37B384E62_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = TranslationInfo_get_direction_m91A56BB213E808121F10634E88D14AA37B384E62_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationInfo::set_direction(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 direction { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdirectionU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.TranslationInfo::.ctor(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73 (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPos0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___direction3, const RuntimeMethod* method)
{
	{
		// public TranslationInfo(Vector3 initialPos, Vector3 delta, Vector3 total, Vector3 direction) : this()
		il2cpp_codegen_initobj(__this, sizeof(TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB ));
		// this.initialPosition = initialPos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___initialPos0;
		TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)__this, L_0, /*hidden argument*/NULL);
		// this.delta = delta;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___delta1;
		TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)__this, L_1, /*hidden argument*/NULL);
		// this.total = total;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___total2;
		TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)__this, L_2, /*hidden argument*/NULL);
		// this.direction = direction;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___direction3;
		TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD_inline((TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *)__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___initialPos0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___delta1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___total2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___direction3, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * _thisAdjusted = reinterpret_cast<TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB *>(__this + _offset);
	TranslationInfo__ctor_m13C41BC9DE3BB58BA28DB437992F264AC2013E73(_thisAdjusted, ___initialPos0, ___delta1, ___total2, ___direction3, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::get_world()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * _thisAdjusted = reinterpret_cast<TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::set_world(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * _thisAdjusted = reinterpret_cast<TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *>(__this + _offset);
	TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.TranslationInfo Unity.MARS.MARSHandles.TranslationUpdateInfo::get_local()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * _thisAdjusted = reinterpret_cast<TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *>(__this + _offset);
	TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  _returnValue;
	_returnValue = TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::set_local(Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * _thisAdjusted = reinterpret_cast<TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *>(__this + _offset);
	TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.TranslationUpdateInfo::.ctor(Unity.MARS.MARSHandles.TranslationInfo,Unity.MARS.MARSHandles.TranslationInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TranslationUpdateInfo__ctor_m9019C924C8F38EB025A0B46F6FD66DA2496D5489 (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	{
		// public TranslationUpdateInfo(TranslationInfo world, TranslationInfo local) : this()
		il2cpp_codegen_initobj(__this, sizeof(TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 ));
		// this.world = world;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___world0;
		TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)__this, L_0, /*hidden argument*/NULL);
		// this.local = local;
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_1 = ___local1;
		TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442_inline((TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void TranslationUpdateInfo__ctor_m9019C924C8F38EB025A0B46F6FD66DA2496D5489_AdjustorThunk (RuntimeObject * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___world0, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___local1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * _thisAdjusted = reinterpret_cast<TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 *>(__this + _offset);
	TranslationUpdateInfo__ctor_m9019C924C8F38EB025A0B46F6FD66DA2496D5489(_thisAdjusted, ___world0, ___local1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.HandleContext/InteractionState::.ctor(Unity.MARS.MARSHandles.HandleContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractionState__ctor_m9C9DA3A5BDE2FFE3A3B10850D9A6F189F54184B2 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * ___context0, const RuntimeMethod* method)
{
	{
		// public InteractionState(HandleContext context)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// m_Context = context;
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_0 = ___context0;
		__this->set_m_Context_5(L_0);
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.HandleContext/InteractionState/State Unity.MARS.MARSHandles.HandleContext/InteractionState::get_state()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t InteractionState_get_state_m69BEB9A9A1C8743327C1449FD953FC2D5ADA78C4 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, const RuntimeMethod* method)
{
	{
		// public State state { get { return m_State; } }
		int32_t L_0 = __this->get_m_State_4();
		return L_0;
	}
}
// Unity.MARS.MARSHandles.InteractiveHandle Unity.MARS.MARSHandles.HandleContext/InteractionState::get_activeHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * InteractionState_get_activeHandle_m7D375FD9445CF9910EFEC779D647BCE91182B2E2 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_ActiveHandle; }
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = __this->get_m_ActiveHandle_1();
		return L_0;
	}
}
// System.Boolean Unity.MARS.MARSHandles.HandleContext/InteractionState::get_isDragging()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool InteractionState_get_isDragging_mECCA7EE3817087E583FC30A71E675F1F691B3672 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_State == State.Dragging; }
		int32_t L_0 = __this->get_m_State_4();
		return (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext/InteractionState::SetHovered(Unity.MARS.MARSHandles.InteractiveHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractionState_SetHovered_m0087F94BDA6AA9A2C2731135DFF82ED23541A8FF (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * ___handle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_1;
	memset((&V_1), 0, sizeof(V_1));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_2 = NULL;
	HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  V_3;
	memset((&V_3), 0, sizeof(V_3));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_4 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 2> __leave_targets;
	InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * G_B13_0 = NULL;
	InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * G_B12_0 = NULL;
	int32_t G_B14_0 = 0;
	InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * G_B14_1 = NULL;
	{
		// if (m_ActiveHandle == handle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = __this->get_m_ActiveHandle_1();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_1 = ___handle0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, L_1, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// m_HoverHandle = handle;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_3 = ___handle0;
		__this->set_m_HoverHandle_0(L_3);
		// if (m_State != State.Dragging)
		int32_t L_4 = __this->get_m_State_4();
		if ((((int32_t)L_4) == ((int32_t)2)))
		{
			goto IL_010c;
		}
	}
	{
		// if (m_ActiveHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_5 = __this->get_m_ActiveHandle_1();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_6;
		L_6 = Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499(L_5, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_0086;
		}
	}
	{
		// var eventData = new HoverEndInfo();
		il2cpp_codegen_initobj((&V_0), sizeof(HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8 ));
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_7 = __this->get_m_Context_5();
		NullCheck(L_7);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_8;
		L_8 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_7, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_9;
		L_9 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_8, /*hidden argument*/NULL);
		NullCheck(L_9);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_10;
		L_10 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_9, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_1 = L_10;
	}

IL_004d:
	try
	{ // begin try (depth: 1)
		{
			goto IL_006d;
		}

IL_004f:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_11;
			L_11 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_2 = L_11;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_12 = V_2;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_13;
			L_13 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_12, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_13)
			{
				goto IL_006d;
			}
		}

IL_0060:
		{
			// behaviour.DoHoverEnd(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_14 = V_2;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_15 = __this->get_m_ActiveHandle_1();
			HoverEndInfo_tADCF18066017D9E00E2BD9CF66E1EC97C1D224B8  L_16 = V_0;
			NullCheck(L_14);
			HandleBehaviour_DoHoverEnd_mCBB1C0614CC6840F6FD6A7B9763A77AE32941D23(L_14, L_15, L_16, /*hidden argument*/NULL);
		}

IL_006d:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_17;
			L_17 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_17)
			{
				goto IL_004f;
			}
		}

IL_0076:
		{
			IL2CPP_LEAVE(0x86, FINALLY_0078);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0078;
	}

FINALLY_0078:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(120)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(120)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x86, IL_0086)
	}

IL_0086:
	{
		// m_ActiveHandle = handle; //If we are dragging, we keep the current active engaged as Hovering and Dragging
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_18 = ___handle0;
		__this->set_m_ActiveHandle_1(L_18);
		// m_State = m_ActiveHandle != null ? State.Hovering : State.Idle;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_19 = __this->get_m_ActiveHandle_1();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_20;
		L_20 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_19, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		G_B12_0 = __this;
		if (L_20)
		{
			G_B13_0 = __this;
			goto IL_009f;
		}
	}
	{
		G_B14_0 = 0;
		G_B14_1 = G_B12_0;
		goto IL_00a0;
	}

IL_009f:
	{
		G_B14_0 = 1;
		G_B14_1 = G_B13_0;
	}

IL_00a0:
	{
		NullCheck(G_B14_1);
		G_B14_1->set_m_State_4(G_B14_0);
		// if (m_ActiveHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_21 = __this->get_m_ActiveHandle_1();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_22;
		L_22 = Object_op_Implicit_mC8214E4F028CC2F036CC82BDB81D102A02893499(L_21, /*hidden argument*/NULL);
		if (!L_22)
		{
			goto IL_010c;
		}
	}
	{
		// var eventData = new HoverBeginInfo();
		il2cpp_codegen_initobj((&V_3), sizeof(HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9 ));
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_23 = __this->get_m_Context_5();
		NullCheck(L_23);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_24;
		L_24 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_23, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_25;
		L_25 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_24, /*hidden argument*/NULL);
		NullCheck(L_25);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_26;
		L_26 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_25, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_1 = L_26;
	}

IL_00d0:
	try
	{ // begin try (depth: 1)
		{
			goto IL_00f3;
		}

IL_00d2:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_27;
			L_27 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_4 = L_27;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_28 = V_4;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_29;
			L_29 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_28, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_29)
			{
				goto IL_00f3;
			}
		}

IL_00e5:
		{
			// behaviour.DoHoverBegin(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_30 = V_4;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_31 = __this->get_m_ActiveHandle_1();
			HoverBeginInfo_t6DEC8593280E4117ECB31BAAFBD3A15BC6332DA9  L_32 = V_3;
			NullCheck(L_30);
			HandleBehaviour_DoHoverBegin_m283C92835138AB27B36D0ECA2DB013859069C576(L_30, L_31, L_32, /*hidden argument*/NULL);
		}

IL_00f3:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_33;
			L_33 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_33)
			{
				goto IL_00d2;
			}
		}

IL_00fc:
		{
			IL2CPP_LEAVE(0x10C, FINALLY_00fe);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_00fe;
	}

FINALLY_00fe:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(254)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(254)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x10C, IL_010c)
	}

IL_010c:
	{
		// }
		return;
	}
}
// System.Boolean Unity.MARS.MARSHandles.HandleContext/InteractionState::StartDrag(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool InteractionState_StartDrag_m75A041B5D264280D8A30296A2D4D53FA04A1408C (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___hitPos0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_1;
	memset((&V_1), 0, sizeof(V_1));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_2 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// if (m_State != State.Hovering)
		int32_t L_0 = __this->get_m_State_4();
		if ((((int32_t)L_0) == ((int32_t)1)))
		{
			goto IL_000b;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_000b:
	{
		// m_StartDragPosition = hitPos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___hitPos0;
		__this->set_m_StartDragPosition_2(L_1);
		// m_LastFramePosition = hitPos;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___hitPos0;
		__this->set_m_LastFramePosition_3(L_2);
		// m_State = State.Dragging;
		__this->set_m_State_4(2);
		// var eventData = new DragBeginInfo(new DragTranslation(
		//     m_StartDragPosition,
		//     m_StartDragPosition,
		//     Vector3.zero));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = __this->get_m_StartDragPosition_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = __this->get_m_StartDragPosition_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_6;
		memset((&L_6), 0, sizeof(L_6));
		DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE((&L_6), L_3, L_4, L_5, /*hidden argument*/NULL);
		DragBeginInfo__ctor_mEBDAE2DF9605F605D4AA7CB9E1C5DA12F51675CB((DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7 *)(&V_0), L_6, /*hidden argument*/NULL);
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_7 = __this->get_m_Context_5();
		NullCheck(L_7);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_8;
		L_8 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_7, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_9;
		L_9 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_8, /*hidden argument*/NULL);
		NullCheck(L_9);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_10;
		L_10 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_9, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_1 = L_10;
	}

IL_0053:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0073;
		}

IL_0055:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_11;
			L_11 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_2 = L_11;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_12 = V_2;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_13;
			L_13 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_12, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_13)
			{
				goto IL_0073;
			}
		}

IL_0066:
		{
			// behaviour.DoDragBegin(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_14 = V_2;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_15 = __this->get_m_ActiveHandle_1();
			DragBeginInfo_t389819318883BBE61DA7ED1D4860D5ADEF715AB7  L_16 = V_0;
			NullCheck(L_14);
			HandleBehaviour_DoDragBegin_m9B13ACAC9CCCD17B2281F33FE62B13E973B446E0(L_14, L_15, L_16, /*hidden argument*/NULL);
		}

IL_0073:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_17;
			L_17 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_17)
			{
				goto IL_0055;
			}
		}

IL_007c:
		{
			IL2CPP_LEAVE(0x8C, FINALLY_007e);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_007e;
	}

FINALLY_007e:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(126)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(126)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x8C, IL_008c)
	}

IL_008c:
	{
		// return true;
		return (bool)1;
	}
}
// System.Boolean Unity.MARS.MARSHandles.HandleContext/InteractionState::StopDrag()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool InteractionState_StopDrag_m4719AE96608B3C6F4A130A84A04DB7F38A2F0FD4 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_1;
	memset((&V_1), 0, sizeof(V_1));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_2 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// if (m_State != State.Dragging)
		int32_t L_0 = __this->get_m_State_4();
		if ((((int32_t)L_0) == ((int32_t)2)))
		{
			goto IL_000b;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_000b:
	{
		// var eventData = new DragEndInfo(new DragTranslation(
		//     m_StartDragPosition,
		//     m_LastFramePosition,
		//     Vector3.zero));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = __this->get_m_StartDragPosition_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = __this->get_m_LastFramePosition_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_4;
		memset((&L_4), 0, sizeof(L_4));
		DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE((&L_4), L_1, L_2, L_3, /*hidden argument*/NULL);
		DragEndInfo__ctor_mAE40EC2FD71878AC0C04DCD0473E0A0D5C0C7EE9((DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D *)(&V_0), L_4, /*hidden argument*/NULL);
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_5 = __this->get_m_Context_5();
		NullCheck(L_5);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_6;
		L_6 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_5, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_7;
		L_7 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_6, /*hidden argument*/NULL);
		NullCheck(L_7);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_8;
		L_8 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_7, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_1 = L_8;
	}

IL_003e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_005e;
		}

IL_0040:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_9;
			L_9 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_2 = L_9;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_10 = V_2;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_11;
			L_11 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_10, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_11)
			{
				goto IL_005e;
			}
		}

IL_0051:
		{
			// behaviour.DoDragEnd(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_12 = V_2;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_13 = __this->get_m_ActiveHandle_1();
			DragEndInfo_t677A15397B3DA99F8F787813C49742772794DB4D  L_14 = V_0;
			NullCheck(L_12);
			HandleBehaviour_DoDragEnd_mD2D7C32C132783BE67BE7B0706410BCB6716DDA7(L_12, L_13, L_14, /*hidden argument*/NULL);
		}

IL_005e:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_15;
			L_15 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_15)
			{
				goto IL_0040;
			}
		}

IL_0067:
		{
			IL2CPP_LEAVE(0x77, FINALLY_0069);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0069;
	}

FINALLY_0069:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_1), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(105)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(105)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x77, IL_0077)
	}

IL_0077:
	{
		// m_State = State.Hovering;
		__this->set_m_State_4(1);
		// if (m_HoverHandle != m_ActiveHandle)
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_16 = __this->get_m_HoverHandle_0();
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_17 = __this->get_m_ActiveHandle_1();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_18;
		L_18 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_16, L_17, /*hidden argument*/NULL);
		if (!L_18)
		{
			goto IL_009d;
		}
	}
	{
		// SetHovered(m_HoverHandle);
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_19 = __this->get_m_HoverHandle_0();
		InteractionState_SetHovered_m0087F94BDA6AA9A2C2731135DFF82ED23541A8FF(__this, L_19, /*hidden argument*/NULL);
	}

IL_009d:
	{
		// return true;
		return (bool)1;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext/InteractionState::Update(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractionState_Update_mD3DE8A570A3EDDD9BCA30AF5FEB1FE4F0591C638 (InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___hitPos0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  V_1;
	memset((&V_1), 0, sizeof(V_1));
	Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  V_2;
	memset((&V_2), 0, sizeof(V_2));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_3 = NULL;
	DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  V_4;
	memset((&V_4), 0, sizeof(V_4));
	HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * V_5 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 2> __leave_targets;
	{
		// switch (m_State)
		int32_t L_0 = __this->get_m_State_4();
		V_0 = L_0;
		int32_t L_1 = V_0;
		if ((((int32_t)L_1) == ((int32_t)1)))
		{
			goto IL_0010;
		}
	}
	{
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) == ((int32_t)2)))
		{
			goto IL_006a;
		}
	}
	{
		return;
	}

IL_0010:
	{
		// var eventData = new HoverUpdateInfo();
		il2cpp_codegen_initobj((&V_1), sizeof(HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40 ));
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_3 = __this->get_m_Context_5();
		NullCheck(L_3);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_4;
		L_4 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_3, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_5;
		L_5 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_4, /*hidden argument*/NULL);
		NullCheck(L_5);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_6;
		L_6 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_5, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_2 = L_6;
	}

IL_002e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_004e;
		}

IL_0030:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_7;
			L_7 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_3 = L_7;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_8 = V_3;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_9;
			L_9 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_8, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_9)
			{
				goto IL_004e;
			}
		}

IL_0041:
		{
			// behaviour.DoHoverUpdate(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_10 = V_3;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_11 = __this->get_m_ActiveHandle_1();
			HoverUpdateInfo_tB74D747EACC3ABAEF1C6B20D498F5BD4C8029C40  L_12 = V_1;
			NullCheck(L_10);
			HandleBehaviour_DoHoverUpdate_m40D91954ED1D85C5DA2F2BA7481899B4E025A581(L_10, L_11, L_12, /*hidden argument*/NULL);
		}

IL_004e:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_13;
			L_13 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_13)
			{
				goto IL_0030;
			}
		}

IL_0057:
		{
			IL2CPP_LEAVE(0xDC, FINALLY_005c);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_005c;
	}

FINALLY_005c:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(92)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(92)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0xDC, IL_00dc)
	}

IL_006a:
	{
		// var eventData = new DragUpdateInfo(new DragTranslation(
		//     m_StartDragPosition,
		//     hitPos,
		//     hitPos - m_LastFramePosition));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14 = __this->get_m_StartDragPosition_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = ___hitPos0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16 = ___hitPos0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17 = __this->get_m_LastFramePosition_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18;
		L_18 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_16, L_17, /*hidden argument*/NULL);
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_19;
		memset((&L_19), 0, sizeof(L_19));
		DragTranslation__ctor_m711BE1557D2567E191DCBA850B86A6487CED1DFE((&L_19), L_14, L_15, L_18, /*hidden argument*/NULL);
		DragUpdateInfo__ctor_m777BDB1251294C2E1B5F5ECA368047B9F70100EC((DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 *)(&V_4), L_19, /*hidden argument*/NULL);
		// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_20 = __this->get_m_Context_5();
		NullCheck(L_20);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_21;
		L_21 = HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline(L_20, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_22;
		L_22 = InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742(L_21, /*hidden argument*/NULL);
		NullCheck(L_22);
		Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840  L_23;
		L_23 = List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB(L_22, /*hidden argument*/List_1_GetEnumerator_m78B09D935D75D9AF1E09B130F3045747EC22D5AB_RuntimeMethod_var);
		V_2 = L_23;
	}

IL_009f:
	try
	{ // begin try (depth: 1)
		{
			goto IL_00c3;
		}

IL_00a1:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_24;
			L_24 = Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_inline((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_get_Current_m934D4253858EA81FFCCCF42D9FFE4F3BF5B7BC48_RuntimeMethod_var);
			V_5 = L_24;
			// if (behaviour == null)
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_25 = V_5;
			IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
			bool L_26;
			L_26 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_25, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
			if (L_26)
			{
				goto IL_00c3;
			}
		}

IL_00b4:
		{
			// behaviour.DoDragUpdate(m_ActiveHandle, eventData);
			HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * L_27 = V_5;
			InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_28 = __this->get_m_ActiveHandle_1();
			DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8  L_29 = V_4;
			NullCheck(L_27);
			HandleBehaviour_DoDragUpdate_mC7166664E160F0AA3CDE675DAD85B4DDE347F73F(L_27, L_28, L_29, /*hidden argument*/NULL);
		}

IL_00c3:
		{
			// foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
			bool L_30;
			L_30 = Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_MoveNext_m2700F7ADDC0E6776B09BC7055BE0DF6AB4B1D4B4_RuntimeMethod_var);
			if (L_30)
			{
				goto IL_00a1;
			}
		}

IL_00cc:
		{
			IL2CPP_LEAVE(0xDC, FINALLY_00ce);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_00ce;
	}

FINALLY_00ce:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5((Enumerator_t6D586706BA3FCE6248F279216E6372F1B8256840 *)(&V_2), /*hidden argument*/Enumerator_Dispose_m13A6DD0323966141268B6E58640BB06ED38F63C5_RuntimeMethod_var);
		IL2CPP_END_FINALLY(206)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(206)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0xDC, IL_00dc)
	}

IL_00dc:
	{
		// }
		return;
	}
}
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour> Unity.MARS.MARSHandles.HandleContext/InteractionState::TakeSnapshot(System.Collections.Generic.List`1<Unity.MARS.MARSHandles.HandleBehaviour>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * InteractionState_TakeSnapshot_mF4F8771EE39C7FF864CE2DD41ECBCBBEA745B742 (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * ___original0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_AddRange_m10A04B53537D5AB1DC6243720AF3D18EB6BC7923_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m76B072C05663936EA6BFBCC57761E394E9E66ED0_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// s_BehavioursSnapshot.Clear();
		IL2CPP_RUNTIME_CLASS_INIT(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = ((InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields*)il2cpp_codegen_static_fields_for(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var))->get_s_BehavioursSnapshot_6();
		NullCheck(L_0);
		List_1_Clear_m76B072C05663936EA6BFBCC57761E394E9E66ED0(L_0, /*hidden argument*/List_1_Clear_m76B072C05663936EA6BFBCC57761E394E9E66ED0_RuntimeMethod_var);
		// s_BehavioursSnapshot.AddRange(original);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_1 = ((InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields*)il2cpp_codegen_static_fields_for(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var))->get_s_BehavioursSnapshot_6();
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_2 = ___original0;
		NullCheck(L_1);
		List_1_AddRange_m10A04B53537D5AB1DC6243720AF3D18EB6BC7923(L_1, L_2, /*hidden argument*/List_1_AddRange_m10A04B53537D5AB1DC6243720AF3D18EB6BC7923_RuntimeMethod_var);
		// return s_BehavioursSnapshot;
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_3 = ((InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields*)il2cpp_codegen_static_fields_for(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var))->get_s_BehavioursSnapshot_6();
		return L_3;
	}
}
// System.Void Unity.MARS.MARSHandles.HandleContext/InteractionState::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InteractionState__cctor_m5D0490321AFD00E1317D21C6603EF04F15CC318F (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m2E5CD7DAF88452A4E392FE590162D47B2AE87FBF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly List<HandleBehaviour> s_BehavioursSnapshot = new List<HandleBehaviour>(32);
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = (List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D *)il2cpp_codegen_object_new(List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D_il2cpp_TypeInfo_var);
		List_1__ctor_m2E5CD7DAF88452A4E392FE590162D47B2AE87FBF(L_0, ((int32_t)32), /*hidden argument*/List_1__ctor_m2E5CD7DAF88452A4E392FE590162D47B2AE87FBF_RuntimeMethod_var);
		((InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_StaticFields*)il2cpp_codegen_static_fields_for(InteractionState_tCC898C365DCD5E6C22C8936663953A52E58B4AD2_il2cpp_TypeInfo_var))->set_s_BehavioursSnapshot_6(L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass4_0__ctor_m5FB77025DFA10417073AEFFF5E00CA048C7CB6FD (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::<Awake>b__0(Unity.MARS.MARSHandles.TranslationBeginInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__0_mFE947AF56949443180513A6BD887A1C279EBB3E4 (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * __this, TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  ___info0, const RuntimeMethod* method)
{
	{
		// slider.translationBegun += (info) => TranslationBegun(slider, info);
		ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * L_0 = __this->get_U3CU3E4__this_1();
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_1 = __this->get_slider_0();
		TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA  L_2 = ___info0;
		NullCheck(L_0);
		ScaleHandle_TranslationBegun_m53CB07A3474CF5E466DD495503C1DB276D4FB484(L_0, L_1, L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::<Awake>b__1(Unity.MARS.MARSHandles.TranslationUpdateInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__1_mB4404C47AE65E376D9C7C6064DDBC49A70EE2146 (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * __this, TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  ___info0, const RuntimeMethod* method)
{
	{
		// slider.translationUpdated += (info) => TranslationUpdated(slider, info);
		ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * L_0 = __this->get_U3CU3E4__this_1();
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_1 = __this->get_slider_0();
		TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628  L_2 = ___info0;
		NullCheck(L_0);
		ScaleHandle_TranslationUpdated_m129FD7D6C157CC54C48E6F9DD1E270E5D3EB31A9(L_0, L_1, L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.ScaleHandle/<>c__DisplayClass4_0::<Awake>b__2(Unity.MARS.MARSHandles.TranslationEndInfo)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass4_0_U3CAwakeU3Eb__2_mBFF2C9E8DA52B885E63B152B581635F4FE9B3EAB (U3CU3Ec__DisplayClass4_0_tB7290DEF4550714B218B1E946B0DBA46462E0B61 * __this, TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  ___info0, const RuntimeMethod* method)
{
	{
		// slider.translationEnded += (info) => TranslationEnded(slider, info);
		ScaleHandle_t1661A87B03FCA01724E17818A8DB020F745AF719 * L_0 = __this->get_U3CU3E4__this_1();
		SliderHandleBase_tFD2CB389DC592E12138C023065D6A37C1132220A * L_1 = __this->get_slider_0();
		TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B  L_2 = ___info0;
		NullCheck(L_0);
		ScaleHandle_TranslationEnded_mE4DAB19D2219EBBF63591899AD9CB2A65F660C7D(L_0, L_1, L_2, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_initialPosition_m6B1B10218D0765B1B934D8066379B73CD73BF918_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialPositionU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_initialPosition_mDABA3FBF25C53A6069507EA8EE87E2218607549A_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialPositionU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_currentPosition_mC67597A54B9509AB4A9797D5687302CC316EE41C_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 currentPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CcurrentPositionU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_currentPosition_mA38F88F9783681C71CE1D695E9C41F8243FE49E7_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 currentPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CcurrentPositionU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  DragTranslation_get_delta_m7F702B6FCEBE8654F97BC7E48352CBFDDF408098_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragTranslation_set_delta_mB32862C8AD767CBB24643A1F6E05997F4D2F1596_inline (DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  DragUpdateInfo_get_translation_m4549F7E45527C3D7CE6460D4B340408A92829780_inline (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, const RuntimeMethod* method)
{
	{
		// public DragTranslation translation { get; private set; }
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = __this->get_U3CtranslationU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void DragUpdateInfo_set_translation_m05D43C56D4446163C267BF4ACF70D416F50A88DF_inline (DragUpdateInfo_t7665504DED8AA8C50F857C9B10D492957E129AA8 * __this, DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  ___value0, const RuntimeMethod* method)
{
	{
		// public DragTranslation translation { get; private set; }
		DragTranslation_t7DC3A312DEBEC3C6CBF99208EB86A80F0B271CAA  L_0 = ___value0;
		__this->set_U3CtranslationU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * HandleBehaviour_get_context_mE1B7D13C98337ABED9192BF83B365BFAF172051E_inline (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// get => m_Context;
		HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * L_0 = __this->get_m_Context_4();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * HandleBehaviour_get_ownerHandle_m426C9111E6A5F2FB4EB7C0584FA5A317556A7AC6_inline (HandleBehaviour_tC327DC8C6DD02DE367DB6EDE8E97497B7D9F8ADE * __this, const RuntimeMethod* method)
{
	{
		// public InteractiveHandle ownerHandle => m_OwnerHandle;
		InteractiveHandle_tD8D606CA9CBC952F1F14D9026D18F922202F909F * L_0 = __this->get_m_OwnerHandle_5();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___b1;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___a0;
		float L_5 = L_4.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___b1;
		float L_7 = L_6.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___a0;
		float L_9 = L_8.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = ___b1;
		float L_11 = L_10.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_12), ((float)il2cpp_codegen_subtract((float)L_1, (float)L_3)), ((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)), ((float)il2cpp_codegen_subtract((float)L_9, (float)L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method)
{
	{
		float L_0 = ___x0;
		__this->set_x_2(L_0);
		float L_1 = ___y1;
		__this->set_y_3(L_1);
		float L_2 = ___z2;
		__this->set_z_4(L_2);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lhs0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rhs1, const RuntimeMethod* method)
{
	float V_0 = 0.0f;
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___lhs0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___rhs1;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___lhs0;
		float L_5 = L_4.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___rhs1;
		float L_7 = L_6.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___lhs0;
		float L_9 = L_8.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = ___rhs1;
		float L_11 = L_10.get_z_4();
		V_0 = ((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)L_1, (float)L_3)), (float)((float)il2cpp_codegen_multiply((float)L_5, (float)L_7)))), (float)((float)il2cpp_codegen_multiply((float)L_9, (float)L_11))));
		goto IL_002d;
	}

IL_002d:
	{
		float L_12 = V_0;
		return L_12;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___b1;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___a0;
		float L_5 = L_4.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___b1;
		float L_7 = L_6.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___a0;
		float L_9 = L_8.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = ___b1;
		float L_11 = L_10.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_12), ((float)il2cpp_codegen_add((float)L_1, (float)L_3)), ((float)il2cpp_codegen_add((float)L_5, (float)L_7)), ((float)il2cpp_codegen_add((float)L_9, (float)L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___v0, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___v0;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___v0;
		float L_3 = L_2.get_y_1();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_4), L_1, L_3, (0.0f), /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_001a;
	}

IL_001a:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		float L_2 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___a0;
		float L_4 = L_3.get_y_3();
		float L_5 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___a0;
		float L_7 = L_6.get_z_4();
		float L_8 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_9), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_2)), ((float)il2cpp_codegen_multiply((float)L_4, (float)L_5)), ((float)il2cpp_codegen_multiply((float)L_7, (float)L_8)), /*hidden argument*/NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_world_m3B0D23EED0F777F202BB1D961548BCA82FB97BCA_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationBeginInfo_set_world_mFCC08C88BE253C7661EB55860ABA36A80E6BAD77_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationBeginInfo_get_local_m73DF0506958FCE368E13C9FC5B2ADA3768E0278A_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationBeginInfo_set_local_mCF6F993D575F24327CDFACDDDFE32637F1663B40_inline (RotationBeginInfo_t2CBC5474F36F9DFE863251065A0B4C57D6F97F78 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_world_m4BAE769589BEA155D286581CAE61E7C1987582AC_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationEndInfo_set_world_m7B6C911C6CC9D5DFFB12D6E0DBB10D681CBDF8BC_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationEndInfo_get_local_m2D09A17E6786D6253B915364A72E18A723539258_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationEndInfo_set_local_m7E53D2F2B83F166ED9FE94AC703BDD2548799DDA_inline (RotationEndInfo_t6230E94383C0B253952E7EADC0B9B093DAA66449 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float RotationInfo_get_total_mDBAD43EB96B196E258AE3972228C641CC044ED94_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public float total { get; private set; }
		float L_0 = __this->get_U3CtotalU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_total_m5C6BAE4986408C110E107FBA0A0D296F36FDDD9F_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float total { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float RotationInfo_get_delta_m9DFA96854C0C0E823AA72EEAC40FDD3D7C6FCD1B_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public float delta { get; private set; }
		float L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_delta_m9F8DFB5CE37D67D546122DE6C8501A6DC19394BA_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float delta { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  RotationInfo_get_axis_mA25AA9C2B63EFD8C2FE3203FBBA3AE4CF957F1B6_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 axis { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CaxisU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationInfo_set_axis_m93C5DE53CCE953F1EFEA267EBF589B0C98B3D806_inline (RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 axis { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CaxisU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_world_mB8A3FF1EA7A95E523E3117E234608A46AF7747B6_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_world_m2F2DF5F93EB1132EF26308BC86881AB6F9DFD843_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo world { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  RotationUpdateInfo_get_local_m56BA9177C8453541972DE59ED8650BCA589B37F0_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RotationUpdateInfo_set_local_m302E7AA2458E9BDBA01FF90F25ADF924A89A1FFB_inline (RotationUpdateInfo_tBD9BF688ED198E3FE735D0915F46236F0A19FA44 * __this, RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  ___value0, const RuntimeMethod* method)
{
	{
		// public RotationInfo local { get; private set; }
		RotationInfo_tA5EB25B39658AEF97B7980EA7B3769704F7D05B9  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * HandleContext_get_camera_m3443C04A9BBECC24BE477653D17C0D4ABDA19DFA_inline (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Camera; }
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = __this->get_m_Camera_6();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_world_m69BDDE24675B29715A4891518B4F7E2B79477007_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_delta_m536A52063137534C4AC8FE0BB0AECD285ADB7828_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_total_mD20D45A2D285098C9B7A9B634B8E64DC09F6A04C_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CtotalU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationUpdateInfo_get_local_m737133074A403F0AC17885A2EB0DCCBF0D0984A3_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Scale_m8805EE8D2586DE7B6143FA35819B3D5CF1981FB3_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___b1;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___a0;
		float L_5 = L_4.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___b1;
		float L_7 = L_6.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___a0;
		float L_9 = L_8.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = ___b1;
		float L_11 = L_10.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_12), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_3)), ((float)il2cpp_codegen_multiply((float)L_5, (float)L_7)), ((float)il2cpp_codegen_multiply((float)L_9, (float)L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_initial_m45D786434B7DD9ADA18E7D4869989CE44823D606_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initial { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_initial_m445A211BF010FF036D9291298C019E2AC3C081AD_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initial { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_delta_m72D45D52AEB9EDBF7723B3546D5DBAFAC88B1850_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdeltaU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_delta_m0AC7B093C9A244C274EE8F2C0C678C2644870267_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScalingInfo_get_total_m89F9E2CDDC74901D68AEAA536B8800F4C81F97CF_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CtotalU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingInfo_set_total_mB655F75A514EE2C7A384EA3833967D0788584AF3_inline (ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_world_m6900153CD29B1043352AEE9F53E8EB3C82D06185_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method)
{
	{
		// public ScalingInfo world { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_world_m67BFF0DC94EE465B9329B0AEAE710392A7DE3283_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	{
		// public ScalingInfo world { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ScalingUpdatedInfo_get_local_m1C58BC4935A0B0A238779F5FB6A26C9C00B1C400_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, const RuntimeMethod* method)
{
	{
		// public ScalingInfo local { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ScalingUpdatedInfo_set_local_m80684721252A29D0FB594B75F0B34DA99CF352B0_inline (ScalingUpdatedInfo_tBFAB94797DF67A83E7CA1552D72BC6FF0452F8C1 * __this, ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  ___value0, const RuntimeMethod* method)
{
	{
		// public ScalingInfo local { get; private set; }
		ScalingInfo_t27B1DB2228A555593B0BDBC9BDFE6F81D52BAAED  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Division_mE5ACBFB168FED529587457A83BA98B7DB32E2A05_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		float L_2 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___a0;
		float L_4 = L_3.get_y_3();
		float L_5 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___a0;
		float L_7 = L_6.get_z_4();
		float L_8 = ___d1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_9), ((float)((float)L_1/(float)L_2)), ((float)((float)L_4/(float)L_5)), ((float)((float)L_7/(float)L_8)), /*hidden argument*/NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_UnaryNegation_m362EA356F4CADEDB39F965A0DBDED6EA890925F7_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___a0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___a0;
		float L_3 = L_2.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___a0;
		float L_5 = L_4.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_6), ((-L_1)), ((-L_3)), ((-L_5)), /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_001e;
	}

IL_001e:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_world_m339141700BFD547B9776F447A2ED644F49FD1722_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_world_m226EBCAFE489FB58211C61355877A3D5BC26F232_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationBeginInfo_get_local_m3E176F6CC06B3E3CC69A71B0EF1C01969160D02C_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationBeginInfo_set_local_mBF440E8F93323D3EAF5F71F040C4482931AB4012_inline (TranslationBeginInfo_t60CFACF666A4D3BD5FEDEC3CF885D213F4A445BA * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_world_mAA199ACA11FDC6250AA16B01419642A6D2DA4CDF_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3CworldU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationEndInfo_set_world_m9B8BBE6E6BA4F9A0E195B42EC82992D1034FB6CC_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  TranslationEndInfo_get_local_m7391D5DCCD007E17B45CB2F315F53CF2CF5DA34D_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = __this->get_U3ClocalU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationEndInfo_set_local_mA2CC6049C0D5C37D03F98EC005D0414C98D1AB97_inline (TranslationEndInfo_t4CB0620CAA112120432C15BAB38AFB499FBBBA2B * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_initialPosition_m14AD77A8DF15FFC178D8E958164D5961B68B0CCA_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CinitialPositionU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_initialPosition_m6B653CCD7647D9E86CF25627C2D0CAAF9A97EFDF_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 initialPosition { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CinitialPositionU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_delta_m0F3E6D97DBB3543535B53D49D89EF7E43BD5ACFD_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 delta { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdeltaU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_total_mD5ED471B2F24C73E73845A281BC1016278538B05_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 total { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CtotalU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  TranslationInfo_get_direction_m91A56BB213E808121F10634E88D14AA37B384E62_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, const RuntimeMethod* method)
{
	{
		// public Vector3 direction { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_U3CdirectionU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationInfo_set_direction_m2957CB17275BC08ECA0DD4FF3B95D79669BFC8DD_inline (TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector3 direction { get; private set; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_U3CdirectionU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_world_m51F921FB69E67246141E60E4500B578C6D96B5C1_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo world { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3CworldU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TranslationUpdateInfo_set_local_m30DF8E0C89F1DE5519D6166A2EE43EF38CAE1442_inline (TranslationUpdateInfo_t781F52E9982886E2079E7F3BCF3BAB8DE9C1C628 * __this, TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  ___value0, const RuntimeMethod* method)
{
	{
		// public TranslationInfo local { get; private set; }
		TranslationInfo_t030D3B0DB1566149B087E7E8D87E267535FD65FB  L_0 = ___value0;
		__this->set_U3ClocalU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * HandleContext_GetHandleBehaviours_m89E935711327637701D3BDC5A2E22897F1232B30_inline (HandleContext_tFCA22D7A0A00DC65B3FA1170BE06C84145F5381B * __this, const RuntimeMethod* method)
{
	{
		// return m_HandleBehaviours;
		List_1_tE5148B202F916D7CC996FF55CC165FDA6869374D * L_0 = __this->get_m_HandleBehaviours_5();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject * Enumerator_get_Current_m9C4EBBD2108B51885E750F927D7936290C8E20EE_gshared_inline (Enumerator_tB6009981BD4E3881E3EC83627255A24198F902D6 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = (RuntimeObject *)__this->get_current_3();
		return (RuntimeObject *)L_0;
	}
}

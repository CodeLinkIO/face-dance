#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1, typename T2, typename T3, typename T4>
struct VirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
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
template <typename T1, typename T2, typename T3, typename T4>
struct GenericVirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericVirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1>
struct GenericVirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1>
struct InterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct InterfaceFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct GenericInterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericInterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1>
struct GenericInterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

// System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>>
struct Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A;
// System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>
struct Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF;
// System.Action`1<Unity.MARS.Data.GeographicCoordinate>
struct Action_1_tEDB449EC4FEF52FC869EE47BAEA315FF814E833A;
// System.Action`1<Unity.MARS.Data.IMRFace>
struct Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E;
// System.Action`1<Unity.MARS.Data.MRCameraTrackingState>
struct Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09;
// System.Action`1<Unity.MARS.Data.MRLightEstimation>
struct Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19;
// System.Action`1<Unity.MARS.Data.MRMarker>
struct Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB;
// System.Action`1<Unity.MARS.Data.MRPlane>
struct Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62;
// System.Action`1<UnityEngine.Pose>
struct Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160;
// System.Action`1<System.Single>
struct Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9;
// System.Action`1<UnityEngine.Texture>
struct Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo>
struct Dictionary_2_t5B8303F2C9869A39ED3E03C0FBB09F817E479402;
// System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>
struct Dictionary_2_t1CA5436E26D49F13B441B9C00027C50EE401A31F;
// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo>
struct Dictionary_2_t0015CBF964B0687CBB5ECFDDE06671A8F3DDE4BC;
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399;
// System.EventHandler`1<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>
struct EventHandler_1_t7F26BD2270AD4531F2328FD1382278E975249DF1;
// System.Func`1<System.Boolean>
struct Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F;
// System.Func`1<System.Single>
struct Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740;
// System.Collections.Generic.List`1<System.Int32>
struct List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7;
// System.Collections.Generic.List`1<Unity.MARS.Data.MRMarker>
struct List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2;
// System.Collections.Generic.List`1<Unity.MARS.Data.MRPlane>
struct List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5;
// System.Collections.Generic.List`1<System.Single>
struct List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA;
// System.Collections.Generic.List`1<System.String>
struct List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3;
// System.Collections.Generic.List`1<System.Type>
struct List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7;
// System.Collections.Generic.List`1<UnityEngine.Vector2>
struct List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9;
// System.Collections.Generic.List`1<UnityEngine.Vector3>
struct List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181;
// System.Reflection.Assembly[]
struct AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0;
// System.Byte[]
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
// System.Exception[]
struct ExceptionU5BU5D_t683CE8E24950657A060E640B8956913D867F952D;
// System.Int32[]
struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32;
// System.IntPtr[]
struct IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6;
// Unity.MARS.Data.MRMarker[]
struct MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E;
// Unity.MARS.Data.MRPlane[]
struct MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988;
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;
// System.Single[]
struct SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971;
// System.String[]
struct StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A;
// System.Type[]
struct TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4;
// System.Action
struct Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6;
// System.AppDomain
struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A;
// System.Reflection.Assembly
struct Assembly_t;
// System.AssemblyLoadEventHandler
struct AssemblyLoadEventHandler_tE06B38463937F6FBCCECF4DF6519F83C1683FE0C;
// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA;
// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71;
// System.Reflection.Binder
struct Binder_t2BEE27FD84737D1E79BC47FD67F6D3DD2F2DDA30;
// System.Byte
struct Byte_t0111FAB8B8685667EDDAF77683F0D8F86B659056;
// System.Globalization.Calendar
struct Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A;
// System.Globalization.CompareInfo
struct CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9;
// System.Globalization.CultureData
struct CultureData_t53CDF1C5F789A28897415891667799420D3C5529;
// System.Globalization.CultureInfo
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98;
// System.Globalization.DateTimeFormatInfo
struct DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288;
// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_tCE2EB28A2C6ACAF004AAD9F4EBA0C30215FAA9C0;
// Unity.MARS.Attributes.EventAttribute
struct EventAttribute_tA8847D809F5707CBB7A7609E76F8FD6D69400F71;
// System.EventHandler
struct EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B;
// UnityEngine.HumanPose
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F;
// System.IAsyncResult
struct IAsyncResult_tC9F97BF36FCF122D29D3101D80642278297BF370;
// System.Collections.IDictionary
struct IDictionary_t99871C56B8EC2452AC5C4CF3831695E617B89D3A;
// System.IFormatProvider
struct IFormatProvider_tF2AECC4B14F41D36718920D67F930CED940412DF;
// Unity.MARS.Data.IMRFace
struct IMRFace_tCD896193605E6F21B4727D2BB0209151366CDA9A;
// Unity.MARS.Data.IMRMarkerLibrary
struct IMRMarkerLibrary_t0C5C94CD76C13DC55C413AAD48CD6E08EBCAA7CD;
// Unity.MARS.Providers.IUsesCameraIntrinsics
struct IUsesCameraIntrinsics_t8BEBF1A6E19805B65CDA8E2D5611203E978AB2A5;
// Unity.MARS.Providers.IUsesCameraOffset
struct IUsesCameraOffset_t2C4C185D61C3AEFE5E9998BC15D9A26FDD65D375;
// Unity.MARS.Providers.IUsesCameraPose
struct IUsesCameraPose_tBC1C555DFF479D35D8E080BF3C426B00E0AE6300;
// Unity.MARS.Providers.IUsesCameraProjectionMatrix
struct IUsesCameraProjectionMatrix_t955A9FEE3448E626BC233947A37DF7E80949E06A;
// Unity.MARS.Providers.IUsesCameraTexture
struct IUsesCameraTexture_t64FE3206921979B7BD8B155922FA208F92236AA0;
// Unity.MARS.Simulation.IUsesDeviceSimulationSettings
struct IUsesDeviceSimulationSettings_t696FB16B6A0D88D42BCF8CF0919B9C8C1878E0CB;
// Unity.MARS.Providers.IUsesFaceTracking
struct IUsesFaceTracking_t54FDDC7A22958B0427E53E160107B2D837F83EFF;
// Unity.MARS.Providers.IUsesFacialExpressions
struct IUsesFacialExpressions_tE761E70D79DF8355A2C584DD4B80AC74A278B4BD;
// Unity.MARS.Providers.IUsesLightEstimation
struct IUsesLightEstimation_t68969B579F38836AC6A245E1296EF9A79C8612A3;
// Unity.MARS.Providers.IUsesMarkerTracking
struct IUsesMarkerTracking_t1B3DBBC10DEE94EA12A7C7671BD31FDB60B6FEA7;
// Unity.MARS.Providers.IUsesPlaneFinding
struct IUsesPlaneFinding_tB2B5DEC96C6224F2E1A08676245A117F35F87175;
// Unity.MARS.Providers.IUsesPointCloud
struct IUsesPointCloud_t66E0A4177A7F74B8FEAD213D2252B28EF2D992E1;
// Unity.MARS.Simulation.IUsesSimulationVideoFeed
struct IUsesSimulationVideoFeed_tCB7F0C8EDEBAA04413DC4A500FD802DCB5121B71;
// Unity.MARS.MARSUtils.IUsesSlowTasks
struct IUsesSlowTasks_tC88C8F9937DC8BB8851CDF57D51B97CCF514D91F;
// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_t297546CB86F076B76F3800238C03F3140A56AB77;
// Unity.MARS.Landmarks.LandmarkDefinition
struct LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C;
// Unity.MARS.Data.LoadTextureCallback
struct LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8;
// Unity.MARS.Data.MRFaceLandmarkComparer
struct MRFaceLandmarkComparer_t6C68AE6AAAB8D4757E4FA5F752B0101A5C035B98;
// System.Reflection.MemberFilter
struct MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Globalization.NumberFormatInfo
struct NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D;
// Unity.MARS.Data.ProgressCallback
struct ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3;
// System.Security.Cryptography.RandomNumberGenerator
struct RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50;
// System.ResolveEventHandler
struct ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F;
// Unity.MARS.Data.SerializedTraitRequirement
struct SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87;
// System.String
struct String_t;
// System.Globalization.TextInfo
struct TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C;
// UnityEngine.Texture
struct Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE;
// UnityEngine.Texture2D
struct Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF;
// Unity.MARS.Data.TraitDefinition
struct TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796;
// Unity.MARS.Query.TraitRequirement
struct TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E;
// System.Type
struct Type_t;
// System.UnhandledExceptionEventHandler
struct UnhandledExceptionEventHandler_t1DF125A860ED9B70F24ADFA6CB0781533A23DA64;
// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;
// System.Reflection.Assembly/ResolveEventHolder
struct ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C;
// Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate
struct TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038;

IL2CPP_EXTERN_C RuntimeClass* Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Guid_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t3BD9DCC58EC655DB3F6C555BF83C1894EEE3E29A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t45730178F0F552264B47E3CFF9E936AF1174D55F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t4DAF9E0706F00592372394B9681A54AA94F511D9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t70D1066FA308F4C0CC57F130F5C09C519D9EB834_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesCameraProjectionMatrix_t04A703B6CADBF3D6596AC8FF17940586E590D34E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesCameraTexture_tE5CF5EC05BDBF685D2DADA1571E7934247226A3D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesFacialExpressions_t11779ED594B769B105A6E6AA99517F3B5E3D2989_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesPointCloud_t245C79C027402F0E38DB4C847E2DEABD1F4FED12_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MARSTrackingState_t123CCD8D1D2C4524143EAB2A6333B4EC53EA240B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ReflectionTypeLoadException_tF7B3556875F394EC77B674893C9322FA1DC21F6C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral095BF313E0560B989F26D34ADC221C4C1F9BB76E;
IL2CPP_EXTERN_C String_t* _stringLiteral0AD4547EEDA716D7ABB45F1D2443B6BFD56E52EC;
IL2CPP_EXTERN_C String_t* _stringLiteral0AE2658B6A3CF65B723B59C775DCF2B5DBC36441;
IL2CPP_EXTERN_C String_t* _stringLiteral0C945050B544C3CEF12A4D3D681756769325C196;
IL2CPP_EXTERN_C String_t* _stringLiteral0E80F4D997AC7C308A04E53745671EE1631B8D7D;
IL2CPP_EXTERN_C String_t* _stringLiteral128B98C2573F57B66C37CA835D0BFBA7B7C54AAE;
IL2CPP_EXTERN_C String_t* _stringLiteral42A9A87BB25BE5C8E1B19AD8D192A0E734A5609A;
IL2CPP_EXTERN_C String_t* _stringLiteral494AD09FB78D890531756ECEC4DFF5C8D22B267D;
IL2CPP_EXTERN_C String_t* _stringLiteral61B8D324687C24872968A15276C954F913457113;
IL2CPP_EXTERN_C String_t* _stringLiteral67C959292ACE557A7911726798B51F6178228E0F;
IL2CPP_EXTERN_C String_t* _stringLiteral73449D68E41F8415CE7CFE4B9EF15ADCFD227ED3;
IL2CPP_EXTERN_C String_t* _stringLiteral80F5C93D7D1A75B619CA6EB5616A6123A15789FF;
IL2CPP_EXTERN_C String_t* _stringLiteral8D18D41C3CA40217AB14C2E3DC0654E77A3140CA;
IL2CPP_EXTERN_C String_t* _stringLiteral8D433D59FC83B792827B9C3DD5736374FC805E00;
IL2CPP_EXTERN_C String_t* _stringLiteral960E5E7F211EFF3243DF14EDD1901DC9EF314D62;
IL2CPP_EXTERN_C String_t* _stringLiteral9640A4BB52A367750B30EF6205902E8ED977782B;
IL2CPP_EXTERN_C String_t* _stringLiteralAB3D2BE4F8DB5A38B000A1ADAA7C55276E258718;
IL2CPP_EXTERN_C String_t* _stringLiteralBACF4D71F8EBDA0C65915B206AFF3133754C7577;
IL2CPP_EXTERN_C String_t* _stringLiteralC44DACFC4328E9DD61AE6846C25FED3BA5076B31;
IL2CPP_EXTERN_C String_t* _stringLiteralCD002DD70C7AAC9CFF6D7D4821927E13D2989493;
IL2CPP_EXTERN_C String_t* _stringLiteralD3992DF679A3EF8B96232992FF89A2B1F1DB5534;
IL2CPP_EXTERN_C String_t* _stringLiteralD3BAB32E57D7DF89CA22BE69BA99B62F96CF56CF;
IL2CPP_EXTERN_C String_t* _stringLiteralDEA3F5044E13F19207D83873B64CD5C1E5385A9F;
IL2CPP_EXTERN_C String_t* _stringLiteralE5EDD2A398E7E7ED8B6C2CD07762D81D9ACFA461;
IL2CPP_EXTERN_C String_t* _stringLiteralE81B368AB56379B7A403D362DD0D8AAA9C8F178B;
IL2CPP_EXTERN_C String_t* _stringLiteralEFC86221AAB7628EBCE554785B46AE44BE79305F;
IL2CPP_EXTERN_C String_t* _stringLiteralFBAF124AB08242B7785EC2B6DBC3C6459CB98BC8;
IL2CPP_EXTERN_C String_t* _stringLiteralFDA1C52D0E58360F4E8FD608757CCD98D8772D4F;
IL2CPP_EXTERN_C String_t* _stringLiteralFE99981D4BE3BFBE312C52C21EADDC2EACD9ED3D;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m56E267FE82DC48AD1690E87B576550B72754E89D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TraitRequirement_FromSerialized_mB5CD2401F1B09211157DC21F1033A84FE1944EC5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Type_GetType_m2D692327E10692E11116805CC604CD47F144A9E4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeType* Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* String_t_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_0_0_0_var;
struct CultureData_t53CDF1C5F789A28897415891667799420D3C5529_marshaled_com;
struct CultureData_t53CDF1C5F789A28897415891667799420D3C5529_marshaled_pinvoke;
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_com;
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_pinvoke;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F;;
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com;
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com;;
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke;
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke;;

struct AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0;
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726;
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;
struct TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755;
struct Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t973A7B2B06EBD0E59B7E07266F4ED340ED9E5096 
{
public:

public:
};


// System.Object


// System.Collections.Generic.List`1<System.Int32>
struct List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7, ____items_1)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get__items_1() const { return ____items_1; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_StaticFields, ____emptyArray_5)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get__emptyArray_5() const { return ____emptyArray_5; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<Unity.MARS.Data.MRMarker>
struct List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2, ____items_1)); }
	inline MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* get__items_1() const { return ____items_1; }
	inline MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2_StaticFields, ____emptyArray_5)); }
	inline MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* get__emptyArray_5() const { return ____emptyArray_5; }
	inline MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(MRMarkerU5BU5D_tA15B91CE16DD8B9C6A7B51D38F60A0E06BDFF31E* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<Unity.MARS.Data.MRPlane>
struct List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7, ____items_1)); }
	inline MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* get__items_1() const { return ____items_1; }
	inline MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7_StaticFields, ____emptyArray_5)); }
	inline MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* get__emptyArray_5() const { return ____emptyArray_5; }
	inline MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(MRPlaneU5BU5D_t0D7A88ABFB93C030371636021E793A7683724988* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<System.Single>
struct List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA, ____items_1)); }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* get__items_1() const { return ____items_1; }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA_StaticFields, ____emptyArray_5)); }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* get__emptyArray_5() const { return ____emptyArray_5; }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<System.Type>
struct List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7, ____items_1)); }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* get__items_1() const { return ____items_1; }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7_StaticFields, ____emptyArray_5)); }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* get__emptyArray_5() const { return ____emptyArray_5; }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<UnityEngine.Vector2>
struct List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9, ____items_1)); }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* get__items_1() const { return ____items_1; }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9_StaticFields, ____emptyArray_5)); }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* get__emptyArray_5() const { return ____emptyArray_5; }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<UnityEngine.Vector3>
struct List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181, ____items_1)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get__items_1() const { return ____items_1; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_StaticFields, ____emptyArray_5)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get__emptyArray_5() const { return ____emptyArray_5; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
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


// System.Globalization.CultureInfo
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98  : public RuntimeObject
{
public:
	// System.Boolean System.Globalization.CultureInfo::m_isReadOnly
	bool ___m_isReadOnly_3;
	// System.Int32 System.Globalization.CultureInfo::cultureID
	int32_t ___cultureID_4;
	// System.Int32 System.Globalization.CultureInfo::parent_lcid
	int32_t ___parent_lcid_5;
	// System.Int32 System.Globalization.CultureInfo::datetime_index
	int32_t ___datetime_index_6;
	// System.Int32 System.Globalization.CultureInfo::number_index
	int32_t ___number_index_7;
	// System.Int32 System.Globalization.CultureInfo::default_calendar_type
	int32_t ___default_calendar_type_8;
	// System.Boolean System.Globalization.CultureInfo::m_useUserOverride
	bool ___m_useUserOverride_9;
	// System.Globalization.NumberFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::numInfo
	NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D * ___numInfo_10;
	// System.Globalization.DateTimeFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::dateTimeInfo
	DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 * ___dateTimeInfo_11;
	// System.Globalization.TextInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::textInfo
	TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C * ___textInfo_12;
	// System.String System.Globalization.CultureInfo::m_name
	String_t* ___m_name_13;
	// System.String System.Globalization.CultureInfo::englishname
	String_t* ___englishname_14;
	// System.String System.Globalization.CultureInfo::nativename
	String_t* ___nativename_15;
	// System.String System.Globalization.CultureInfo::iso3lang
	String_t* ___iso3lang_16;
	// System.String System.Globalization.CultureInfo::iso2lang
	String_t* ___iso2lang_17;
	// System.String System.Globalization.CultureInfo::win3lang
	String_t* ___win3lang_18;
	// System.String System.Globalization.CultureInfo::territory
	String_t* ___territory_19;
	// System.String[] System.Globalization.CultureInfo::native_calendar_names
	StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* ___native_calendar_names_20;
	// System.Globalization.CompareInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::compareInfo
	CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 * ___compareInfo_21;
	// System.Void* System.Globalization.CultureInfo::textinfo_data
	void* ___textinfo_data_22;
	// System.Int32 System.Globalization.CultureInfo::m_dataItem
	int32_t ___m_dataItem_23;
	// System.Globalization.Calendar System.Globalization.CultureInfo::calendar
	Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A * ___calendar_24;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::parent_culture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___parent_culture_25;
	// System.Boolean System.Globalization.CultureInfo::constructed
	bool ___constructed_26;
	// System.Byte[] System.Globalization.CultureInfo::cached_serialized_form
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___cached_serialized_form_27;
	// System.Globalization.CultureData System.Globalization.CultureInfo::m_cultureData
	CultureData_t53CDF1C5F789A28897415891667799420D3C5529 * ___m_cultureData_28;
	// System.Boolean System.Globalization.CultureInfo::m_isInherited
	bool ___m_isInherited_29;

public:
	inline static int32_t get_offset_of_m_isReadOnly_3() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_isReadOnly_3)); }
	inline bool get_m_isReadOnly_3() const { return ___m_isReadOnly_3; }
	inline bool* get_address_of_m_isReadOnly_3() { return &___m_isReadOnly_3; }
	inline void set_m_isReadOnly_3(bool value)
	{
		___m_isReadOnly_3 = value;
	}

	inline static int32_t get_offset_of_cultureID_4() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___cultureID_4)); }
	inline int32_t get_cultureID_4() const { return ___cultureID_4; }
	inline int32_t* get_address_of_cultureID_4() { return &___cultureID_4; }
	inline void set_cultureID_4(int32_t value)
	{
		___cultureID_4 = value;
	}

	inline static int32_t get_offset_of_parent_lcid_5() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___parent_lcid_5)); }
	inline int32_t get_parent_lcid_5() const { return ___parent_lcid_5; }
	inline int32_t* get_address_of_parent_lcid_5() { return &___parent_lcid_5; }
	inline void set_parent_lcid_5(int32_t value)
	{
		___parent_lcid_5 = value;
	}

	inline static int32_t get_offset_of_datetime_index_6() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___datetime_index_6)); }
	inline int32_t get_datetime_index_6() const { return ___datetime_index_6; }
	inline int32_t* get_address_of_datetime_index_6() { return &___datetime_index_6; }
	inline void set_datetime_index_6(int32_t value)
	{
		___datetime_index_6 = value;
	}

	inline static int32_t get_offset_of_number_index_7() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___number_index_7)); }
	inline int32_t get_number_index_7() const { return ___number_index_7; }
	inline int32_t* get_address_of_number_index_7() { return &___number_index_7; }
	inline void set_number_index_7(int32_t value)
	{
		___number_index_7 = value;
	}

	inline static int32_t get_offset_of_default_calendar_type_8() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___default_calendar_type_8)); }
	inline int32_t get_default_calendar_type_8() const { return ___default_calendar_type_8; }
	inline int32_t* get_address_of_default_calendar_type_8() { return &___default_calendar_type_8; }
	inline void set_default_calendar_type_8(int32_t value)
	{
		___default_calendar_type_8 = value;
	}

	inline static int32_t get_offset_of_m_useUserOverride_9() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_useUserOverride_9)); }
	inline bool get_m_useUserOverride_9() const { return ___m_useUserOverride_9; }
	inline bool* get_address_of_m_useUserOverride_9() { return &___m_useUserOverride_9; }
	inline void set_m_useUserOverride_9(bool value)
	{
		___m_useUserOverride_9 = value;
	}

	inline static int32_t get_offset_of_numInfo_10() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___numInfo_10)); }
	inline NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D * get_numInfo_10() const { return ___numInfo_10; }
	inline NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D ** get_address_of_numInfo_10() { return &___numInfo_10; }
	inline void set_numInfo_10(NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D * value)
	{
		___numInfo_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___numInfo_10), (void*)value);
	}

	inline static int32_t get_offset_of_dateTimeInfo_11() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___dateTimeInfo_11)); }
	inline DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 * get_dateTimeInfo_11() const { return ___dateTimeInfo_11; }
	inline DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 ** get_address_of_dateTimeInfo_11() { return &___dateTimeInfo_11; }
	inline void set_dateTimeInfo_11(DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 * value)
	{
		___dateTimeInfo_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___dateTimeInfo_11), (void*)value);
	}

	inline static int32_t get_offset_of_textInfo_12() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___textInfo_12)); }
	inline TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C * get_textInfo_12() const { return ___textInfo_12; }
	inline TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C ** get_address_of_textInfo_12() { return &___textInfo_12; }
	inline void set_textInfo_12(TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C * value)
	{
		___textInfo_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___textInfo_12), (void*)value);
	}

	inline static int32_t get_offset_of_m_name_13() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_name_13)); }
	inline String_t* get_m_name_13() const { return ___m_name_13; }
	inline String_t** get_address_of_m_name_13() { return &___m_name_13; }
	inline void set_m_name_13(String_t* value)
	{
		___m_name_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_name_13), (void*)value);
	}

	inline static int32_t get_offset_of_englishname_14() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___englishname_14)); }
	inline String_t* get_englishname_14() const { return ___englishname_14; }
	inline String_t** get_address_of_englishname_14() { return &___englishname_14; }
	inline void set_englishname_14(String_t* value)
	{
		___englishname_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___englishname_14), (void*)value);
	}

	inline static int32_t get_offset_of_nativename_15() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___nativename_15)); }
	inline String_t* get_nativename_15() const { return ___nativename_15; }
	inline String_t** get_address_of_nativename_15() { return &___nativename_15; }
	inline void set_nativename_15(String_t* value)
	{
		___nativename_15 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___nativename_15), (void*)value);
	}

	inline static int32_t get_offset_of_iso3lang_16() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___iso3lang_16)); }
	inline String_t* get_iso3lang_16() const { return ___iso3lang_16; }
	inline String_t** get_address_of_iso3lang_16() { return &___iso3lang_16; }
	inline void set_iso3lang_16(String_t* value)
	{
		___iso3lang_16 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___iso3lang_16), (void*)value);
	}

	inline static int32_t get_offset_of_iso2lang_17() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___iso2lang_17)); }
	inline String_t* get_iso2lang_17() const { return ___iso2lang_17; }
	inline String_t** get_address_of_iso2lang_17() { return &___iso2lang_17; }
	inline void set_iso2lang_17(String_t* value)
	{
		___iso2lang_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___iso2lang_17), (void*)value);
	}

	inline static int32_t get_offset_of_win3lang_18() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___win3lang_18)); }
	inline String_t* get_win3lang_18() const { return ___win3lang_18; }
	inline String_t** get_address_of_win3lang_18() { return &___win3lang_18; }
	inline void set_win3lang_18(String_t* value)
	{
		___win3lang_18 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___win3lang_18), (void*)value);
	}

	inline static int32_t get_offset_of_territory_19() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___territory_19)); }
	inline String_t* get_territory_19() const { return ___territory_19; }
	inline String_t** get_address_of_territory_19() { return &___territory_19; }
	inline void set_territory_19(String_t* value)
	{
		___territory_19 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___territory_19), (void*)value);
	}

	inline static int32_t get_offset_of_native_calendar_names_20() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___native_calendar_names_20)); }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* get_native_calendar_names_20() const { return ___native_calendar_names_20; }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A** get_address_of_native_calendar_names_20() { return &___native_calendar_names_20; }
	inline void set_native_calendar_names_20(StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* value)
	{
		___native_calendar_names_20 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___native_calendar_names_20), (void*)value);
	}

	inline static int32_t get_offset_of_compareInfo_21() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___compareInfo_21)); }
	inline CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 * get_compareInfo_21() const { return ___compareInfo_21; }
	inline CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 ** get_address_of_compareInfo_21() { return &___compareInfo_21; }
	inline void set_compareInfo_21(CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 * value)
	{
		___compareInfo_21 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___compareInfo_21), (void*)value);
	}

	inline static int32_t get_offset_of_textinfo_data_22() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___textinfo_data_22)); }
	inline void* get_textinfo_data_22() const { return ___textinfo_data_22; }
	inline void** get_address_of_textinfo_data_22() { return &___textinfo_data_22; }
	inline void set_textinfo_data_22(void* value)
	{
		___textinfo_data_22 = value;
	}

	inline static int32_t get_offset_of_m_dataItem_23() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_dataItem_23)); }
	inline int32_t get_m_dataItem_23() const { return ___m_dataItem_23; }
	inline int32_t* get_address_of_m_dataItem_23() { return &___m_dataItem_23; }
	inline void set_m_dataItem_23(int32_t value)
	{
		___m_dataItem_23 = value;
	}

	inline static int32_t get_offset_of_calendar_24() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___calendar_24)); }
	inline Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A * get_calendar_24() const { return ___calendar_24; }
	inline Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A ** get_address_of_calendar_24() { return &___calendar_24; }
	inline void set_calendar_24(Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A * value)
	{
		___calendar_24 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___calendar_24), (void*)value);
	}

	inline static int32_t get_offset_of_parent_culture_25() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___parent_culture_25)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_parent_culture_25() const { return ___parent_culture_25; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_parent_culture_25() { return &___parent_culture_25; }
	inline void set_parent_culture_25(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___parent_culture_25 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___parent_culture_25), (void*)value);
	}

	inline static int32_t get_offset_of_constructed_26() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___constructed_26)); }
	inline bool get_constructed_26() const { return ___constructed_26; }
	inline bool* get_address_of_constructed_26() { return &___constructed_26; }
	inline void set_constructed_26(bool value)
	{
		___constructed_26 = value;
	}

	inline static int32_t get_offset_of_cached_serialized_form_27() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___cached_serialized_form_27)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_cached_serialized_form_27() const { return ___cached_serialized_form_27; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_cached_serialized_form_27() { return &___cached_serialized_form_27; }
	inline void set_cached_serialized_form_27(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___cached_serialized_form_27 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___cached_serialized_form_27), (void*)value);
	}

	inline static int32_t get_offset_of_m_cultureData_28() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_cultureData_28)); }
	inline CultureData_t53CDF1C5F789A28897415891667799420D3C5529 * get_m_cultureData_28() const { return ___m_cultureData_28; }
	inline CultureData_t53CDF1C5F789A28897415891667799420D3C5529 ** get_address_of_m_cultureData_28() { return &___m_cultureData_28; }
	inline void set_m_cultureData_28(CultureData_t53CDF1C5F789A28897415891667799420D3C5529 * value)
	{
		___m_cultureData_28 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_cultureData_28), (void*)value);
	}

	inline static int32_t get_offset_of_m_isInherited_29() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98, ___m_isInherited_29)); }
	inline bool get_m_isInherited_29() const { return ___m_isInherited_29; }
	inline bool* get_address_of_m_isInherited_29() { return &___m_isInherited_29; }
	inline void set_m_isInherited_29(bool value)
	{
		___m_isInherited_29 = value;
	}
};

struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields
{
public:
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::invariant_culture_info
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___invariant_culture_info_0;
	// System.Object System.Globalization.CultureInfo::shared_table_lock
	RuntimeObject * ___shared_table_lock_1;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::default_current_culture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___default_current_culture_2;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentUICulture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___s_DefaultThreadCurrentUICulture_33;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentCulture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___s_DefaultThreadCurrentCulture_34;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_number
	Dictionary_2_t5B8303F2C9869A39ED3E03C0FBB09F817E479402 * ___shared_by_number_35;
	// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_name
	Dictionary_2_t0015CBF964B0687CBB5ECFDDE06671A8F3DDE4BC * ___shared_by_name_36;
	// System.Boolean System.Globalization.CultureInfo::IsTaiwanSku
	bool ___IsTaiwanSku_37;

public:
	inline static int32_t get_offset_of_invariant_culture_info_0() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___invariant_culture_info_0)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_invariant_culture_info_0() const { return ___invariant_culture_info_0; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_invariant_culture_info_0() { return &___invariant_culture_info_0; }
	inline void set_invariant_culture_info_0(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___invariant_culture_info_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___invariant_culture_info_0), (void*)value);
	}

	inline static int32_t get_offset_of_shared_table_lock_1() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___shared_table_lock_1)); }
	inline RuntimeObject * get_shared_table_lock_1() const { return ___shared_table_lock_1; }
	inline RuntimeObject ** get_address_of_shared_table_lock_1() { return &___shared_table_lock_1; }
	inline void set_shared_table_lock_1(RuntimeObject * value)
	{
		___shared_table_lock_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___shared_table_lock_1), (void*)value);
	}

	inline static int32_t get_offset_of_default_current_culture_2() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___default_current_culture_2)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_default_current_culture_2() const { return ___default_current_culture_2; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_default_current_culture_2() { return &___default_current_culture_2; }
	inline void set_default_current_culture_2(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___default_current_culture_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___default_current_culture_2), (void*)value);
	}

	inline static int32_t get_offset_of_s_DefaultThreadCurrentUICulture_33() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___s_DefaultThreadCurrentUICulture_33)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_s_DefaultThreadCurrentUICulture_33() const { return ___s_DefaultThreadCurrentUICulture_33; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_s_DefaultThreadCurrentUICulture_33() { return &___s_DefaultThreadCurrentUICulture_33; }
	inline void set_s_DefaultThreadCurrentUICulture_33(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___s_DefaultThreadCurrentUICulture_33 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_DefaultThreadCurrentUICulture_33), (void*)value);
	}

	inline static int32_t get_offset_of_s_DefaultThreadCurrentCulture_34() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___s_DefaultThreadCurrentCulture_34)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_s_DefaultThreadCurrentCulture_34() const { return ___s_DefaultThreadCurrentCulture_34; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_s_DefaultThreadCurrentCulture_34() { return &___s_DefaultThreadCurrentCulture_34; }
	inline void set_s_DefaultThreadCurrentCulture_34(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___s_DefaultThreadCurrentCulture_34 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_DefaultThreadCurrentCulture_34), (void*)value);
	}

	inline static int32_t get_offset_of_shared_by_number_35() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___shared_by_number_35)); }
	inline Dictionary_2_t5B8303F2C9869A39ED3E03C0FBB09F817E479402 * get_shared_by_number_35() const { return ___shared_by_number_35; }
	inline Dictionary_2_t5B8303F2C9869A39ED3E03C0FBB09F817E479402 ** get_address_of_shared_by_number_35() { return &___shared_by_number_35; }
	inline void set_shared_by_number_35(Dictionary_2_t5B8303F2C9869A39ED3E03C0FBB09F817E479402 * value)
	{
		___shared_by_number_35 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___shared_by_number_35), (void*)value);
	}

	inline static int32_t get_offset_of_shared_by_name_36() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___shared_by_name_36)); }
	inline Dictionary_2_t0015CBF964B0687CBB5ECFDDE06671A8F3DDE4BC * get_shared_by_name_36() const { return ___shared_by_name_36; }
	inline Dictionary_2_t0015CBF964B0687CBB5ECFDDE06671A8F3DDE4BC ** get_address_of_shared_by_name_36() { return &___shared_by_name_36; }
	inline void set_shared_by_name_36(Dictionary_2_t0015CBF964B0687CBB5ECFDDE06671A8F3DDE4BC * value)
	{
		___shared_by_name_36 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___shared_by_name_36), (void*)value);
	}

	inline static int32_t get_offset_of_IsTaiwanSku_37() { return static_cast<int32_t>(offsetof(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_StaticFields, ___IsTaiwanSku_37)); }
	inline bool get_IsTaiwanSku_37() const { return ___IsTaiwanSku_37; }
	inline bool* get_address_of_IsTaiwanSku_37() { return &___IsTaiwanSku_37; }
	inline void set_IsTaiwanSku_37(bool value)
	{
		___IsTaiwanSku_37 = value;
	}
};

// Native definition for P/Invoke marshalling of System.Globalization.CultureInfo
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_pinvoke
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D * ___numInfo_10;
	DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 * ___dateTimeInfo_11;
	TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C * ___textInfo_12;
	char* ___m_name_13;
	char* ___englishname_14;
	char* ___nativename_15;
	char* ___iso3lang_16;
	char* ___iso2lang_17;
	char* ___win3lang_18;
	char* ___territory_19;
	char** ___native_calendar_names_20;
	CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 * ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A * ___calendar_24;
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_pinvoke* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray/*NONE*/* ___cached_serialized_form_27;
	CultureData_t53CDF1C5F789A28897415891667799420D3C5529_marshaled_pinvoke* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};
// Native definition for COM marshalling of System.Globalization.CultureInfo
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_com
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t58780B43B6A840C38FD10C50CDFE2128884CAD1D * ___numInfo_10;
	DateTimeFormatInfo_t0B9F6CA631A51CFC98A3C6031CF8069843137C90 * ___dateTimeInfo_11;
	TextInfo_tE823D0684BFE8B203501C9B2B38585E8F06E872C * ___textInfo_12;
	Il2CppChar* ___m_name_13;
	Il2CppChar* ___englishname_14;
	Il2CppChar* ___nativename_15;
	Il2CppChar* ___iso3lang_16;
	Il2CppChar* ___iso2lang_17;
	Il2CppChar* ___win3lang_18;
	Il2CppChar* ___territory_19;
	Il2CppChar** ___native_calendar_names_20;
	CompareInfo_t4AB62EC32E8AF1E469E315620C7E3FB8B0CAE0C9 * ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t3D638AEAB45F029DF47138EDA4CF9A7CBBB1C32A * ___calendar_24;
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_marshaled_com* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray/*NONE*/* ___cached_serialized_form_27;
	CultureData_t53CDF1C5F789A28897415891667799420D3C5529_marshaled_com* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};

// Unity.MARS.Query.IConditionGenericMethods
struct IConditionGenericMethods_t39ED987CD42A43613EB1520AC953E1347BD985FA  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Data.IProvidesTraitsMethods
struct IProvidesTraitsMethods_tF5E3988B58F651A99993CAF89EB97C670D74AC4E  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Query.IRelationGenericMethods
struct IRelationGenericMethods_tD82FB57C14E00A8A8DAF4AF640004066957EEC3C  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Data.IRequiresTraitsMethods
struct IRequiresTraitsMethods_t29A1D1A0492FF0546EFC5593471EA6FCAAC56468  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesCameraIntrinsicsMethods
struct IUsesCameraIntrinsicsMethods_tB321D79324D61A064BF383DBEEE348834DA0AD73  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesCameraOffsetMethods
struct IUsesCameraOffsetMethods_tECC1091AF2D8BBBCFAC448D340F37419C697E7CA  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesCameraPoseMethods
struct IUsesCameraPoseMethods_t10767971556366D978F47D24411F6296B711A414  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesCameraProjectionMatrixMethods
struct IUsesCameraProjectionMatrixMethods_tCF2E72B6C838C88129E674D055B69447BD6028B6  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesCameraTextureMethods
struct IUsesCameraTextureMethods_t2D50832A5B9E0ED761664BD505EF399B8ECB2E67  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods
struct IUsesDeviceSimulationSettingsMethods_t438758555BE506D2F3B738C9BF880CCD25CCBA19  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesFaceTrackingMethods
struct IUsesFaceTrackingMethods_tFE57B751685F76BFA1627413D4AAABDD3969AF9A  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesFacialExpressionsMethods
struct IUsesFacialExpressionsMethods_tB798FFB524DA81C9D86BDD4CFF2345FFF07CC4A4  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesGeoLocationMethods
struct IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E  : public RuntimeObject
{
public:

public:
};

struct IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields
{
public:
	// Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate Unity.MARS.Providers.IUsesGeoLocationMethods::<TryGetGeoLocationAction>k__BackingField
	TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * ___U3CTryGetGeoLocationActionU3Ek__BackingField_0;
	// System.Func`1<System.Boolean> Unity.MARS.Providers.IUsesGeoLocationMethods::<TryStartServiceFunction>k__BackingField
	Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F * ___U3CTryStartServiceFunctionU3Ek__BackingField_1;
	// System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>> Unity.MARS.Providers.IUsesGeoLocationMethods::<SubscribeGeoLocationChangedAction>k__BackingField
	Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * ___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2;
	// System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>> Unity.MARS.Providers.IUsesGeoLocationMethods::<UnsubscribeGeoLocationChangedAction>k__BackingField
	Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * ___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CTryGetGeoLocationActionU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields, ___U3CTryGetGeoLocationActionU3Ek__BackingField_0)); }
	inline TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * get_U3CTryGetGeoLocationActionU3Ek__BackingField_0() const { return ___U3CTryGetGeoLocationActionU3Ek__BackingField_0; }
	inline TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 ** get_address_of_U3CTryGetGeoLocationActionU3Ek__BackingField_0() { return &___U3CTryGetGeoLocationActionU3Ek__BackingField_0; }
	inline void set_U3CTryGetGeoLocationActionU3Ek__BackingField_0(TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * value)
	{
		___U3CTryGetGeoLocationActionU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CTryGetGeoLocationActionU3Ek__BackingField_0), (void*)value);
	}

	inline static int32_t get_offset_of_U3CTryStartServiceFunctionU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields, ___U3CTryStartServiceFunctionU3Ek__BackingField_1)); }
	inline Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F * get_U3CTryStartServiceFunctionU3Ek__BackingField_1() const { return ___U3CTryStartServiceFunctionU3Ek__BackingField_1; }
	inline Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F ** get_address_of_U3CTryStartServiceFunctionU3Ek__BackingField_1() { return &___U3CTryStartServiceFunctionU3Ek__BackingField_1; }
	inline void set_U3CTryStartServiceFunctionU3Ek__BackingField_1(Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F * value)
	{
		___U3CTryStartServiceFunctionU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CTryStartServiceFunctionU3Ek__BackingField_1), (void*)value);
	}

	inline static int32_t get_offset_of_U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields, ___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2)); }
	inline Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * get_U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2() const { return ___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2; }
	inline Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A ** get_address_of_U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2() { return &___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2; }
	inline void set_U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2(Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * value)
	{
		___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2), (void*)value);
	}

	inline static int32_t get_offset_of_U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields, ___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3)); }
	inline Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * get_U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3() const { return ___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3; }
	inline Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A ** get_address_of_U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3() { return &___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3; }
	inline void set_U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3(Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * value)
	{
		___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3), (void*)value);
	}
};


// Unity.MARS.Data.IUsesMARSDataGenericMethods
struct IUsesMARSDataGenericMethods_t1093FA1E01D9A44BC7C22FE009E633B2B65C82AA  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Data.IUsesMARSTrackableDataGenericMethods
struct IUsesMARSTrackableDataGenericMethods_t8CE447237C80D9F0E86D142778705436EF422FE2  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesMarkerTrackingMethods
struct IUsesMarkerTrackingMethods_t565463CBD02E23E9D6D39DD2EDC91D7DC9A56A23  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesPlaneFindingMethods
struct IUsesPlaneFindingMethods_t145BAB7BEAC75A455C7D0003F4A406705016C089  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.IUsesPointCloudMethods
struct IUsesPointCloudMethods_tBB718CB8701AAF97D1F0B6161059DCD2EF627515  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods
struct IUsesSimulationVideoFeedMethods_t126CF0D56EBFFFEBEEC65EBE36DE9D84D958DB1C  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.MARSUtils.IUsesSlowTasksMethods
struct IUsesSlowTasksMethods_t6C7D5DE5DBB8BF9B84E4290847CBF80758EB9726  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Landmarks.LandmarkDefinition
struct LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C  : public RuntimeObject
{
public:
	// System.String Unity.MARS.Landmarks.LandmarkDefinition::name
	String_t* ___name_0;
	// System.Type[] Unity.MARS.Landmarks.LandmarkDefinition::outputTypes
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ___outputTypes_1;
	// System.Type Unity.MARS.Landmarks.LandmarkDefinition::settingsType
	Type_t * ___settingsType_2;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___name_0), (void*)value);
	}

	inline static int32_t get_offset_of_outputTypes_1() { return static_cast<int32_t>(offsetof(LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C, ___outputTypes_1)); }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* get_outputTypes_1() const { return ___outputTypes_1; }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755** get_address_of_outputTypes_1() { return &___outputTypes_1; }
	inline void set_outputTypes_1(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* value)
	{
		___outputTypes_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___outputTypes_1), (void*)value);
	}

	inline static int32_t get_offset_of_settingsType_2() { return static_cast<int32_t>(offsetof(LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C, ___settingsType_2)); }
	inline Type_t * get_settingsType_2() const { return ___settingsType_2; }
	inline Type_t ** get_address_of_settingsType_2() { return &___settingsType_2; }
	inline void set_settingsType_2(Type_t * value)
	{
		___settingsType_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___settingsType_2), (void*)value);
	}
};


// Unity.MARS.Data.MRFaceLandmarkComparer
struct MRFaceLandmarkComparer_t6C68AE6AAAB8D4757E4FA5F752B0101A5C035B98  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Simulation.MarsTime
struct MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B  : public RuntimeObject
{
public:

public:
};

struct MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields
{
public:
	// System.Single Unity.MARS.Simulation.MarsTime::<Time>k__BackingField
	float ___U3CTimeU3Ek__BackingField_0;
	// System.Single Unity.MARS.Simulation.MarsTime::<TimeStep>k__BackingField
	float ___U3CTimeStepU3Ek__BackingField_1;
	// System.Int32 Unity.MARS.Simulation.MarsTime::<FrameCount>k__BackingField
	int32_t ___U3CFrameCountU3Ek__BackingField_2;
	// System.Boolean Unity.MARS.Simulation.MarsTime::<Paused>k__BackingField
	bool ___U3CPausedU3Ek__BackingField_3;
	// System.Action Unity.MARS.Simulation.MarsTime::MarsUpdate
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___MarsUpdate_4;

public:
	inline static int32_t get_offset_of_U3CTimeU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields, ___U3CTimeU3Ek__BackingField_0)); }
	inline float get_U3CTimeU3Ek__BackingField_0() const { return ___U3CTimeU3Ek__BackingField_0; }
	inline float* get_address_of_U3CTimeU3Ek__BackingField_0() { return &___U3CTimeU3Ek__BackingField_0; }
	inline void set_U3CTimeU3Ek__BackingField_0(float value)
	{
		___U3CTimeU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CTimeStepU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields, ___U3CTimeStepU3Ek__BackingField_1)); }
	inline float get_U3CTimeStepU3Ek__BackingField_1() const { return ___U3CTimeStepU3Ek__BackingField_1; }
	inline float* get_address_of_U3CTimeStepU3Ek__BackingField_1() { return &___U3CTimeStepU3Ek__BackingField_1; }
	inline void set_U3CTimeStepU3Ek__BackingField_1(float value)
	{
		___U3CTimeStepU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CFrameCountU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields, ___U3CFrameCountU3Ek__BackingField_2)); }
	inline int32_t get_U3CFrameCountU3Ek__BackingField_2() const { return ___U3CFrameCountU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CFrameCountU3Ek__BackingField_2() { return &___U3CFrameCountU3Ek__BackingField_2; }
	inline void set_U3CFrameCountU3Ek__BackingField_2(int32_t value)
	{
		___U3CFrameCountU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CPausedU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields, ___U3CPausedU3Ek__BackingField_3)); }
	inline bool get_U3CPausedU3Ek__BackingField_3() const { return ___U3CPausedU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CPausedU3Ek__BackingField_3() { return &___U3CPausedU3Ek__BackingField_3; }
	inline void set_U3CPausedU3Ek__BackingField_3(bool value)
	{
		___U3CPausedU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_MarsUpdate_4() { return static_cast<int32_t>(offsetof(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields, ___MarsUpdate_4)); }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * get_MarsUpdate_4() const { return ___MarsUpdate_4; }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 ** get_address_of_MarsUpdate_4() { return &___MarsUpdate_4; }
	inline void set_MarsUpdate_4(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * value)
	{
		___MarsUpdate_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___MarsUpdate_4), (void*)value);
	}
};


// Unity.MARS.Simulation.MarsTimeDelegates
struct MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED  : public RuntimeObject
{
public:

public:
};

struct MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields
{
public:
	// System.Func`1<System.Single> Unity.MARS.Simulation.MarsTimeDelegates::GetTimeScale
	Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * ___GetTimeScale_0;
	// System.Action`1<System.Single> Unity.MARS.Simulation.MarsTimeDelegates::SetTimeScale
	Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___SetTimeScale_1;
	// System.Action Unity.MARS.Simulation.MarsTimeDelegates::Pause
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___Pause_2;
	// System.Action Unity.MARS.Simulation.MarsTimeDelegates::Play
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___Play_3;

public:
	inline static int32_t get_offset_of_GetTimeScale_0() { return static_cast<int32_t>(offsetof(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields, ___GetTimeScale_0)); }
	inline Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * get_GetTimeScale_0() const { return ___GetTimeScale_0; }
	inline Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 ** get_address_of_GetTimeScale_0() { return &___GetTimeScale_0; }
	inline void set_GetTimeScale_0(Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * value)
	{
		___GetTimeScale_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___GetTimeScale_0), (void*)value);
	}

	inline static int32_t get_offset_of_SetTimeScale_1() { return static_cast<int32_t>(offsetof(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields, ___SetTimeScale_1)); }
	inline Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * get_SetTimeScale_1() const { return ___SetTimeScale_1; }
	inline Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 ** get_address_of_SetTimeScale_1() { return &___SetTimeScale_1; }
	inline void set_SetTimeScale_1(Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * value)
	{
		___SetTimeScale_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___SetTimeScale_1), (void*)value);
	}

	inline static int32_t get_offset_of_Pause_2() { return static_cast<int32_t>(offsetof(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields, ___Pause_2)); }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * get_Pause_2() const { return ___Pause_2; }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 ** get_address_of_Pause_2() { return &___Pause_2; }
	inline void set_Pause_2(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * value)
	{
		___Pause_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Pause_2), (void*)value);
	}

	inline static int32_t get_offset_of_Play_3() { return static_cast<int32_t>(offsetof(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields, ___Play_3)); }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * get_Play_3() const { return ___Play_3; }
	inline Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 ** get_address_of_Play_3() { return &___Play_3; }
	inline void set_Play_3(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * value)
	{
		___Play_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Play_3), (void*)value);
	}
};


// System.MarshalByRefObject
struct MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8  : public RuntimeObject
{
public:
	// System.Object System.MarshalByRefObject::_identity
	RuntimeObject * ____identity_0;

public:
	inline static int32_t get_offset_of__identity_0() { return static_cast<int32_t>(offsetof(MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8, ____identity_0)); }
	inline RuntimeObject * get__identity_0() const { return ____identity_0; }
	inline RuntimeObject ** get_address_of__identity_0() { return &____identity_0; }
	inline void set__identity_0(RuntimeObject * value)
	{
		____identity_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____identity_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8_marshaled_pinvoke
{
	Il2CppIUnknown* ____identity_0;
};
// Native definition for COM marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8_marshaled_com
{
	Il2CppIUnknown* ____identity_0;
};

// System.Reflection.MemberInfo
struct MemberInfo_t  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Data.SerializedTraitRequirement
struct SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87  : public RuntimeObject
{
public:
	// System.String Unity.MARS.Data.SerializedTraitRequirement::m_TraitName
	String_t* ___m_TraitName_0;
	// System.String Unity.MARS.Data.SerializedTraitRequirement::m_TypeName
	String_t* ___m_TypeName_1;
	// System.Boolean Unity.MARS.Data.SerializedTraitRequirement::m_Required
	bool ___m_Required_2;

public:
	inline static int32_t get_offset_of_m_TraitName_0() { return static_cast<int32_t>(offsetof(SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87, ___m_TraitName_0)); }
	inline String_t* get_m_TraitName_0() const { return ___m_TraitName_0; }
	inline String_t** get_address_of_m_TraitName_0() { return &___m_TraitName_0; }
	inline void set_m_TraitName_0(String_t* value)
	{
		___m_TraitName_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_TraitName_0), (void*)value);
	}

	inline static int32_t get_offset_of_m_TypeName_1() { return static_cast<int32_t>(offsetof(SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87, ___m_TypeName_1)); }
	inline String_t* get_m_TypeName_1() const { return ___m_TypeName_1; }
	inline String_t** get_address_of_m_TypeName_1() { return &___m_TypeName_1; }
	inline void set_m_TypeName_1(String_t* value)
	{
		___m_TypeName_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_TypeName_1), (void*)value);
	}

	inline static int32_t get_offset_of_m_Required_2() { return static_cast<int32_t>(offsetof(SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87, ___m_Required_2)); }
	inline bool get_m_Required_2() const { return ___m_Required_2; }
	inline bool* get_address_of_m_Required_2() { return &___m_Required_2; }
	inline void set_m_Required_2(bool value)
	{
		___m_Required_2 = value;
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


// Unity.MARS.Data.TraitDefinition
struct TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796  : public RuntimeObject
{
public:
	// System.String Unity.MARS.Data.TraitDefinition::TraitName
	String_t* ___TraitName_0;
	// System.Type Unity.MARS.Data.TraitDefinition::Type
	Type_t * ___Type_1;

public:
	inline static int32_t get_offset_of_TraitName_0() { return static_cast<int32_t>(offsetof(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796, ___TraitName_0)); }
	inline String_t* get_TraitName_0() const { return ___TraitName_0; }
	inline String_t** get_address_of_TraitName_0() { return &___TraitName_0; }
	inline void set_TraitName_0(String_t* value)
	{
		___TraitName_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TraitName_0), (void*)value);
	}

	inline static int32_t get_offset_of_Type_1() { return static_cast<int32_t>(offsetof(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796, ___Type_1)); }
	inline Type_t * get_Type_1() const { return ___Type_1; }
	inline Type_t ** get_address_of_Type_1() { return &___Type_1; }
	inline void set_Type_1(Type_t * value)
	{
		___Type_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Type_1), (void*)value);
	}
};


// Unity.MARS.Query.TraitDefinitions
struct TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE  : public RuntimeObject
{
public:

public:
};

struct TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields
{
public:
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Pose
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Pose_0;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Point
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Point_1;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Bounds2D
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Bounds2D_2;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Alignment
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Alignment_3;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::GeoCoordinate
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___GeoCoordinate_4;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::HeightAboveFloor
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___HeightAboveFloor_5;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Plane
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Plane_6;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Face
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Face_7;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Floor
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Floor_8;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Environment
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Environment_9;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::User
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___User_10;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::InView
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___InView_11;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::DisplayFlat
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___DisplayFlat_12;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::DisplaySpatial
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___DisplaySpatial_13;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Marker
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Marker_14;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::MarkerId
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___MarkerId_15;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::TrackingState
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___TrackingState_16;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitDefinitions::Body
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Body_17;

public:
	inline static int32_t get_offset_of_Pose_0() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Pose_0)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Pose_0() const { return ___Pose_0; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Pose_0() { return &___Pose_0; }
	inline void set_Pose_0(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Pose_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Pose_0), (void*)value);
	}

	inline static int32_t get_offset_of_Point_1() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Point_1)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Point_1() const { return ___Point_1; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Point_1() { return &___Point_1; }
	inline void set_Point_1(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Point_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Point_1), (void*)value);
	}

	inline static int32_t get_offset_of_Bounds2D_2() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Bounds2D_2)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Bounds2D_2() const { return ___Bounds2D_2; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Bounds2D_2() { return &___Bounds2D_2; }
	inline void set_Bounds2D_2(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Bounds2D_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Bounds2D_2), (void*)value);
	}

	inline static int32_t get_offset_of_Alignment_3() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Alignment_3)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Alignment_3() const { return ___Alignment_3; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Alignment_3() { return &___Alignment_3; }
	inline void set_Alignment_3(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Alignment_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Alignment_3), (void*)value);
	}

	inline static int32_t get_offset_of_GeoCoordinate_4() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___GeoCoordinate_4)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_GeoCoordinate_4() const { return ___GeoCoordinate_4; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_GeoCoordinate_4() { return &___GeoCoordinate_4; }
	inline void set_GeoCoordinate_4(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___GeoCoordinate_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___GeoCoordinate_4), (void*)value);
	}

	inline static int32_t get_offset_of_HeightAboveFloor_5() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___HeightAboveFloor_5)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_HeightAboveFloor_5() const { return ___HeightAboveFloor_5; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_HeightAboveFloor_5() { return &___HeightAboveFloor_5; }
	inline void set_HeightAboveFloor_5(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___HeightAboveFloor_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___HeightAboveFloor_5), (void*)value);
	}

	inline static int32_t get_offset_of_Plane_6() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Plane_6)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Plane_6() const { return ___Plane_6; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Plane_6() { return &___Plane_6; }
	inline void set_Plane_6(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Plane_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Plane_6), (void*)value);
	}

	inline static int32_t get_offset_of_Face_7() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Face_7)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Face_7() const { return ___Face_7; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Face_7() { return &___Face_7; }
	inline void set_Face_7(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Face_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Face_7), (void*)value);
	}

	inline static int32_t get_offset_of_Floor_8() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Floor_8)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Floor_8() const { return ___Floor_8; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Floor_8() { return &___Floor_8; }
	inline void set_Floor_8(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Floor_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Floor_8), (void*)value);
	}

	inline static int32_t get_offset_of_Environment_9() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Environment_9)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Environment_9() const { return ___Environment_9; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Environment_9() { return &___Environment_9; }
	inline void set_Environment_9(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Environment_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Environment_9), (void*)value);
	}

	inline static int32_t get_offset_of_User_10() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___User_10)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_User_10() const { return ___User_10; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_User_10() { return &___User_10; }
	inline void set_User_10(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___User_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___User_10), (void*)value);
	}

	inline static int32_t get_offset_of_InView_11() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___InView_11)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_InView_11() const { return ___InView_11; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_InView_11() { return &___InView_11; }
	inline void set_InView_11(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___InView_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___InView_11), (void*)value);
	}

	inline static int32_t get_offset_of_DisplayFlat_12() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___DisplayFlat_12)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_DisplayFlat_12() const { return ___DisplayFlat_12; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_DisplayFlat_12() { return &___DisplayFlat_12; }
	inline void set_DisplayFlat_12(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___DisplayFlat_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DisplayFlat_12), (void*)value);
	}

	inline static int32_t get_offset_of_DisplaySpatial_13() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___DisplaySpatial_13)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_DisplaySpatial_13() const { return ___DisplaySpatial_13; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_DisplaySpatial_13() { return &___DisplaySpatial_13; }
	inline void set_DisplaySpatial_13(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___DisplaySpatial_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DisplaySpatial_13), (void*)value);
	}

	inline static int32_t get_offset_of_Marker_14() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Marker_14)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Marker_14() const { return ___Marker_14; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Marker_14() { return &___Marker_14; }
	inline void set_Marker_14(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Marker_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Marker_14), (void*)value);
	}

	inline static int32_t get_offset_of_MarkerId_15() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___MarkerId_15)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_MarkerId_15() const { return ___MarkerId_15; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_MarkerId_15() { return &___MarkerId_15; }
	inline void set_MarkerId_15(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___MarkerId_15 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___MarkerId_15), (void*)value);
	}

	inline static int32_t get_offset_of_TrackingState_16() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___TrackingState_16)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_TrackingState_16() const { return ___TrackingState_16; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_TrackingState_16() { return &___TrackingState_16; }
	inline void set_TrackingState_16(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___TrackingState_16 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrackingState_16), (void*)value);
	}

	inline static int32_t get_offset_of_Body_17() { return static_cast<int32_t>(offsetof(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields, ___Body_17)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Body_17() const { return ___Body_17; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Body_17() { return &___Body_17; }
	inline void set_Body_17(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Body_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Body_17), (void*)value);
	}
};


// Unity.MARS.Query.TraitRequirement
struct TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E  : public RuntimeObject
{
public:
	// System.Boolean Unity.MARS.Query.TraitRequirement::Required
	bool ___Required_0;
	// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitRequirement::Definition
	TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___Definition_1;

public:
	inline static int32_t get_offset_of_Required_0() { return static_cast<int32_t>(offsetof(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E, ___Required_0)); }
	inline bool get_Required_0() const { return ___Required_0; }
	inline bool* get_address_of_Required_0() { return &___Required_0; }
	inline void set_Required_0(bool value)
	{
		___Required_0 = value;
	}

	inline static int32_t get_offset_of_Definition_1() { return static_cast<int32_t>(offsetof(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E, ___Definition_1)); }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * get_Definition_1() const { return ___Definition_1; }
	inline TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 ** get_address_of_Definition_1() { return &___Definition_1; }
	inline void set_Definition_1(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * value)
	{
		___Definition_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Definition_1), (void*)value);
	}
};


// Unity.MARS.MARSUtils.TypeExtensions
struct TypeExtensions_tE012588423110AD74E9D064899ECB3B461EE3591  : public RuntimeObject
{
public:

public:
};


// Unity.MARS.Providers.UsesLightEstimationMethods
struct UsesLightEstimationMethods_t334B43363FF06912764155B425AEA1B4F841A881  : public RuntimeObject
{
public:

public:
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

// Unity.Collections.NativeSlice`1<System.Single>
struct NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535 
{
public:
	// System.Byte* Unity.Collections.NativeSlice`1::m_Buffer
	uint8_t* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Stride
	int32_t ___m_Stride_1;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Length
	int32_t ___m_Length_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535, ___m_Buffer_0)); }
	inline uint8_t* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline uint8_t** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(uint8_t* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Stride_1() { return static_cast<int32_t>(offsetof(NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535, ___m_Stride_1)); }
	inline int32_t get_m_Stride_1() const { return ___m_Stride_1; }
	inline int32_t* get_address_of_m_Stride_1() { return &___m_Stride_1; }
	inline void set_m_Stride_1(int32_t value)
	{
		___m_Stride_1 = value;
	}

	inline static int32_t get_offset_of_m_Length_2() { return static_cast<int32_t>(offsetof(NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535, ___m_Length_2)); }
	inline int32_t get_m_Length_2() const { return ___m_Length_2; }
	inline int32_t* get_address_of_m_Length_2() { return &___m_Length_2; }
	inline void set_m_Length_2(int32_t value)
	{
		___m_Length_2 = value;
	}
};


// Unity.Collections.NativeSlice`1<System.UInt64>
struct NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E 
{
public:
	// System.Byte* Unity.Collections.NativeSlice`1::m_Buffer
	uint8_t* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Stride
	int32_t ___m_Stride_1;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Length
	int32_t ___m_Length_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E, ___m_Buffer_0)); }
	inline uint8_t* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline uint8_t** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(uint8_t* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Stride_1() { return static_cast<int32_t>(offsetof(NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E, ___m_Stride_1)); }
	inline int32_t get_m_Stride_1() const { return ___m_Stride_1; }
	inline int32_t* get_address_of_m_Stride_1() { return &___m_Stride_1; }
	inline void set_m_Stride_1(int32_t value)
	{
		___m_Stride_1 = value;
	}

	inline static int32_t get_offset_of_m_Length_2() { return static_cast<int32_t>(offsetof(NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E, ___m_Length_2)); }
	inline int32_t get_m_Length_2() const { return ___m_Length_2; }
	inline int32_t* get_address_of_m_Length_2() { return &___m_Length_2; }
	inline void set_m_Length_2(int32_t value)
	{
		___m_Length_2 = value;
	}
};


// Unity.Collections.NativeSlice`1<UnityEngine.Vector3>
struct NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125 
{
public:
	// System.Byte* Unity.Collections.NativeSlice`1::m_Buffer
	uint8_t* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Stride
	int32_t ___m_Stride_1;
	// System.Int32 Unity.Collections.NativeSlice`1::m_Length
	int32_t ___m_Length_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125, ___m_Buffer_0)); }
	inline uint8_t* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline uint8_t** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(uint8_t* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Stride_1() { return static_cast<int32_t>(offsetof(NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125, ___m_Stride_1)); }
	inline int32_t get_m_Stride_1() const { return ___m_Stride_1; }
	inline int32_t* get_address_of_m_Stride_1() { return &___m_Stride_1; }
	inline void set_m_Stride_1(int32_t value)
	{
		___m_Stride_1 = value;
	}

	inline static int32_t get_offset_of_m_Length_2() { return static_cast<int32_t>(offsetof(NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125, ___m_Length_2)); }
	inline int32_t get_m_Length_2() const { return ___m_Length_2; }
	inline int32_t* get_address_of_m_Length_2() { return &___m_Length_2; }
	inline void set_m_Length_2(int32_t value)
	{
		___m_Length_2 = value;
	}
};


// System.Nullable`1<System.Single>
struct Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A 
{
public:
	// T System.Nullable`1::value
	float ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A, ___value_0)); }
	inline float get_value_0() const { return ___value_0; }
	inline float* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(float value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
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


// System.Byte
struct Byte_t0111FAB8B8685667EDDAF77683F0D8F86B659056 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Byte_t0111FAB8B8685667EDDAF77683F0D8F86B659056, ___m_value_0)); }
	inline uint8_t get_m_value_0() const { return ___m_value_0; }
	inline uint8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint8_t value)
	{
		___m_value_0 = value;
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


// System.Double
struct Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181 
{
public:
	// System.Double System.Double::m_value
	double ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181, ___m_value_0)); }
	inline double get_m_value_0() const { return ___m_value_0; }
	inline double* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(double value)
	{
		___m_value_0 = value;
	}
};

struct Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_StaticFields
{
public:
	// System.Double System.Double::NegativeZero
	double ___NegativeZero_7;

public:
	inline static int32_t get_offset_of_NegativeZero_7() { return static_cast<int32_t>(offsetof(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_StaticFields, ___NegativeZero_7)); }
	inline double get_NegativeZero_7() const { return ___NegativeZero_7; }
	inline double* get_address_of_NegativeZero_7() { return &___NegativeZero_7; }
	inline void set_NegativeZero_7(double value)
	{
		___NegativeZero_7 = value;
	}
};


// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_tCE2EB28A2C6ACAF004AAD9F4EBA0C30215FAA9C0  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
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

// Unity.MARS.Attributes.EventAttribute
struct EventAttribute_tA8847D809F5707CBB7A7609E76F8FD6D69400F71  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Type Unity.MARS.Attributes.EventAttribute::type
	Type_t * ___type_0;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(EventAttribute_tA8847D809F5707CBB7A7609E76F8FD6D69400F71, ___type_0)); }
	inline Type_t * get_type_0() const { return ___type_0; }
	inline Type_t ** get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(Type_t * value)
	{
		___type_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___type_0), (void*)value);
	}
};


// Unity.MARS.Data.GeographicCoordinate
struct GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 
{
public:
	// System.Double Unity.MARS.Data.GeographicCoordinate::latitude
	double ___latitude_1;
	// System.Double Unity.MARS.Data.GeographicCoordinate::longitude
	double ___longitude_2;

public:
	inline static int32_t get_offset_of_latitude_1() { return static_cast<int32_t>(offsetof(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1, ___latitude_1)); }
	inline double get_latitude_1() const { return ___latitude_1; }
	inline double* get_address_of_latitude_1() { return &___latitude_1; }
	inline void set_latitude_1(double value)
	{
		___latitude_1 = value;
	}

	inline static int32_t get_offset_of_longitude_2() { return static_cast<int32_t>(offsetof(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1, ___longitude_2)); }
	inline double get_longitude_2() const { return ___longitude_2; }
	inline double* get_address_of_longitude_2() { return &___longitude_2; }
	inline void set_longitude_2(double value)
	{
		___longitude_2 = value;
	}
};

struct GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1_StaticFields
{
public:
	// Unity.MARS.Data.GeographicCoordinate Unity.MARS.Data.GeographicCoordinate::Invalid
	GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  ___Invalid_0;

public:
	inline static int32_t get_offset_of_Invalid_0() { return static_cast<int32_t>(offsetof(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1_StaticFields, ___Invalid_0)); }
	inline GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  get_Invalid_0() const { return ___Invalid_0; }
	inline GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * get_address_of_Invalid_0() { return &___Invalid_0; }
	inline void set_Invalid_0(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  value)
	{
		___Invalid_0 = value;
	}
};


// System.Guid
struct Guid_t 
{
public:
	// System.Int32 System.Guid::_a
	int32_t ____a_1;
	// System.Int16 System.Guid::_b
	int16_t ____b_2;
	// System.Int16 System.Guid::_c
	int16_t ____c_3;
	// System.Byte System.Guid::_d
	uint8_t ____d_4;
	// System.Byte System.Guid::_e
	uint8_t ____e_5;
	// System.Byte System.Guid::_f
	uint8_t ____f_6;
	// System.Byte System.Guid::_g
	uint8_t ____g_7;
	// System.Byte System.Guid::_h
	uint8_t ____h_8;
	// System.Byte System.Guid::_i
	uint8_t ____i_9;
	// System.Byte System.Guid::_j
	uint8_t ____j_10;
	// System.Byte System.Guid::_k
	uint8_t ____k_11;

public:
	inline static int32_t get_offset_of__a_1() { return static_cast<int32_t>(offsetof(Guid_t, ____a_1)); }
	inline int32_t get__a_1() const { return ____a_1; }
	inline int32_t* get_address_of__a_1() { return &____a_1; }
	inline void set__a_1(int32_t value)
	{
		____a_1 = value;
	}

	inline static int32_t get_offset_of__b_2() { return static_cast<int32_t>(offsetof(Guid_t, ____b_2)); }
	inline int16_t get__b_2() const { return ____b_2; }
	inline int16_t* get_address_of__b_2() { return &____b_2; }
	inline void set__b_2(int16_t value)
	{
		____b_2 = value;
	}

	inline static int32_t get_offset_of__c_3() { return static_cast<int32_t>(offsetof(Guid_t, ____c_3)); }
	inline int16_t get__c_3() const { return ____c_3; }
	inline int16_t* get_address_of__c_3() { return &____c_3; }
	inline void set__c_3(int16_t value)
	{
		____c_3 = value;
	}

	inline static int32_t get_offset_of__d_4() { return static_cast<int32_t>(offsetof(Guid_t, ____d_4)); }
	inline uint8_t get__d_4() const { return ____d_4; }
	inline uint8_t* get_address_of__d_4() { return &____d_4; }
	inline void set__d_4(uint8_t value)
	{
		____d_4 = value;
	}

	inline static int32_t get_offset_of__e_5() { return static_cast<int32_t>(offsetof(Guid_t, ____e_5)); }
	inline uint8_t get__e_5() const { return ____e_5; }
	inline uint8_t* get_address_of__e_5() { return &____e_5; }
	inline void set__e_5(uint8_t value)
	{
		____e_5 = value;
	}

	inline static int32_t get_offset_of__f_6() { return static_cast<int32_t>(offsetof(Guid_t, ____f_6)); }
	inline uint8_t get__f_6() const { return ____f_6; }
	inline uint8_t* get_address_of__f_6() { return &____f_6; }
	inline void set__f_6(uint8_t value)
	{
		____f_6 = value;
	}

	inline static int32_t get_offset_of__g_7() { return static_cast<int32_t>(offsetof(Guid_t, ____g_7)); }
	inline uint8_t get__g_7() const { return ____g_7; }
	inline uint8_t* get_address_of__g_7() { return &____g_7; }
	inline void set__g_7(uint8_t value)
	{
		____g_7 = value;
	}

	inline static int32_t get_offset_of__h_8() { return static_cast<int32_t>(offsetof(Guid_t, ____h_8)); }
	inline uint8_t get__h_8() const { return ____h_8; }
	inline uint8_t* get_address_of__h_8() { return &____h_8; }
	inline void set__h_8(uint8_t value)
	{
		____h_8 = value;
	}

	inline static int32_t get_offset_of__i_9() { return static_cast<int32_t>(offsetof(Guid_t, ____i_9)); }
	inline uint8_t get__i_9() const { return ____i_9; }
	inline uint8_t* get_address_of__i_9() { return &____i_9; }
	inline void set__i_9(uint8_t value)
	{
		____i_9 = value;
	}

	inline static int32_t get_offset_of__j_10() { return static_cast<int32_t>(offsetof(Guid_t, ____j_10)); }
	inline uint8_t get__j_10() const { return ____j_10; }
	inline uint8_t* get_address_of__j_10() { return &____j_10; }
	inline void set__j_10(uint8_t value)
	{
		____j_10 = value;
	}

	inline static int32_t get_offset_of__k_11() { return static_cast<int32_t>(offsetof(Guid_t, ____k_11)); }
	inline uint8_t get__k_11() const { return ____k_11; }
	inline uint8_t* get_address_of__k_11() { return &____k_11; }
	inline void set__k_11(uint8_t value)
	{
		____k_11 = value;
	}
};

struct Guid_t_StaticFields
{
public:
	// System.Guid System.Guid::Empty
	Guid_t  ___Empty_0;
	// System.Object System.Guid::_rngAccess
	RuntimeObject * ____rngAccess_12;
	// System.Security.Cryptography.RandomNumberGenerator System.Guid::_rng
	RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * ____rng_13;
	// System.Security.Cryptography.RandomNumberGenerator System.Guid::_fastRng
	RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * ____fastRng_14;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ___Empty_0)); }
	inline Guid_t  get_Empty_0() const { return ___Empty_0; }
	inline Guid_t * get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(Guid_t  value)
	{
		___Empty_0 = value;
	}

	inline static int32_t get_offset_of__rngAccess_12() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____rngAccess_12)); }
	inline RuntimeObject * get__rngAccess_12() const { return ____rngAccess_12; }
	inline RuntimeObject ** get_address_of__rngAccess_12() { return &____rngAccess_12; }
	inline void set__rngAccess_12(RuntimeObject * value)
	{
		____rngAccess_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____rngAccess_12), (void*)value);
	}

	inline static int32_t get_offset_of__rng_13() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____rng_13)); }
	inline RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * get__rng_13() const { return ____rng_13; }
	inline RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 ** get_address_of__rng_13() { return &____rng_13; }
	inline void set__rng_13(RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * value)
	{
		____rng_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____rng_13), (void*)value);
	}

	inline static int32_t get_offset_of__fastRng_14() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____fastRng_14)); }
	inline RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * get__fastRng_14() const { return ____fastRng_14; }
	inline RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 ** get_address_of__fastRng_14() { return &____fastRng_14; }
	inline void set__fastRng_14(RandomNumberGenerator_t2CB5440F189986116A2FA9F907AE52644047AC50 * value)
	{
		____fastRng_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____fastRng_14), (void*)value);
	}
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


// System.Int64
struct Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3 
{
public:
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3, ___m_value_0)); }
	inline int64_t get_m_value_0() const { return ___m_value_0; }
	inline int64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int64_t value)
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
struct IsReadOnlyAttribute_t297546CB86F076B76F3800238C03F3140A56AB77  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// Unity.MARS.Data.MarsTrackableId
struct MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 
{
public:
	// System.UInt64 Unity.MARS.Data.MarsTrackableId::m_SubId1
	uint64_t ___m_SubId1_4;
	// System.UInt64 Unity.MARS.Data.MarsTrackableId::m_SubId2
	uint64_t ___m_SubId2_5;

public:
	inline static int32_t get_offset_of_m_SubId1_4() { return static_cast<int32_t>(offsetof(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60, ___m_SubId1_4)); }
	inline uint64_t get_m_SubId1_4() const { return ___m_SubId1_4; }
	inline uint64_t* get_address_of_m_SubId1_4() { return &___m_SubId1_4; }
	inline void set_m_SubId1_4(uint64_t value)
	{
		___m_SubId1_4 = value;
	}

	inline static int32_t get_offset_of_m_SubId2_5() { return static_cast<int32_t>(offsetof(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60, ___m_SubId2_5)); }
	inline uint64_t get_m_SubId2_5() const { return ___m_SubId2_5; }
	inline uint64_t* get_address_of_m_SubId2_5() { return &___m_SubId2_5; }
	inline void set_m_SubId2_5(uint64_t value)
	{
		___m_SubId2_5 = value;
	}
};

struct MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields
{
public:
	// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsTrackableId::k_InvalidId
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___k_InvalidId_1;
	// System.UInt64 Unity.MARS.Data.MarsTrackableId::k_StringSubIdOne
	uint64_t ___k_StringSubIdOne_2;
	// System.UInt64 Unity.MARS.Data.MarsTrackableId::s_IdTwoCounter
	uint64_t ___s_IdTwoCounter_3;

public:
	inline static int32_t get_offset_of_k_InvalidId_1() { return static_cast<int32_t>(offsetof(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields, ___k_InvalidId_1)); }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  get_k_InvalidId_1() const { return ___k_InvalidId_1; }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * get_address_of_k_InvalidId_1() { return &___k_InvalidId_1; }
	inline void set_k_InvalidId_1(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  value)
	{
		___k_InvalidId_1 = value;
	}

	inline static int32_t get_offset_of_k_StringSubIdOne_2() { return static_cast<int32_t>(offsetof(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields, ___k_StringSubIdOne_2)); }
	inline uint64_t get_k_StringSubIdOne_2() const { return ___k_StringSubIdOne_2; }
	inline uint64_t* get_address_of_k_StringSubIdOne_2() { return &___k_StringSubIdOne_2; }
	inline void set_k_StringSubIdOne_2(uint64_t value)
	{
		___k_StringSubIdOne_2 = value;
	}

	inline static int32_t get_offset_of_s_IdTwoCounter_3() { return static_cast<int32_t>(offsetof(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields, ___s_IdTwoCounter_3)); }
	inline uint64_t get_s_IdTwoCounter_3() const { return ___s_IdTwoCounter_3; }
	inline uint64_t* get_address_of_s_IdTwoCounter_3() { return &___s_IdTwoCounter_3; }
	inline void set_s_IdTwoCounter_3(uint64_t value)
	{
		___s_IdTwoCounter_3 = value;
	}
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


// UnityEngine.Rendering.SphericalHarmonicsL2
struct SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64 
{
public:
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr0
	float ___shr0_0;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr1
	float ___shr1_1;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr2
	float ___shr2_2;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr3
	float ___shr3_3;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr4
	float ___shr4_4;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr5
	float ___shr5_5;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr6
	float ___shr6_6;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr7
	float ___shr7_7;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shr8
	float ___shr8_8;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg0
	float ___shg0_9;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg1
	float ___shg1_10;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg2
	float ___shg2_11;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg3
	float ___shg3_12;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg4
	float ___shg4_13;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg5
	float ___shg5_14;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg6
	float ___shg6_15;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg7
	float ___shg7_16;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shg8
	float ___shg8_17;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb0
	float ___shb0_18;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb1
	float ___shb1_19;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb2
	float ___shb2_20;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb3
	float ___shb3_21;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb4
	float ___shb4_22;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb5
	float ___shb5_23;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb6
	float ___shb6_24;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb7
	float ___shb7_25;
	// System.Single UnityEngine.Rendering.SphericalHarmonicsL2::shb8
	float ___shb8_26;

public:
	inline static int32_t get_offset_of_shr0_0() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr0_0)); }
	inline float get_shr0_0() const { return ___shr0_0; }
	inline float* get_address_of_shr0_0() { return &___shr0_0; }
	inline void set_shr0_0(float value)
	{
		___shr0_0 = value;
	}

	inline static int32_t get_offset_of_shr1_1() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr1_1)); }
	inline float get_shr1_1() const { return ___shr1_1; }
	inline float* get_address_of_shr1_1() { return &___shr1_1; }
	inline void set_shr1_1(float value)
	{
		___shr1_1 = value;
	}

	inline static int32_t get_offset_of_shr2_2() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr2_2)); }
	inline float get_shr2_2() const { return ___shr2_2; }
	inline float* get_address_of_shr2_2() { return &___shr2_2; }
	inline void set_shr2_2(float value)
	{
		___shr2_2 = value;
	}

	inline static int32_t get_offset_of_shr3_3() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr3_3)); }
	inline float get_shr3_3() const { return ___shr3_3; }
	inline float* get_address_of_shr3_3() { return &___shr3_3; }
	inline void set_shr3_3(float value)
	{
		___shr3_3 = value;
	}

	inline static int32_t get_offset_of_shr4_4() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr4_4)); }
	inline float get_shr4_4() const { return ___shr4_4; }
	inline float* get_address_of_shr4_4() { return &___shr4_4; }
	inline void set_shr4_4(float value)
	{
		___shr4_4 = value;
	}

	inline static int32_t get_offset_of_shr5_5() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr5_5)); }
	inline float get_shr5_5() const { return ___shr5_5; }
	inline float* get_address_of_shr5_5() { return &___shr5_5; }
	inline void set_shr5_5(float value)
	{
		___shr5_5 = value;
	}

	inline static int32_t get_offset_of_shr6_6() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr6_6)); }
	inline float get_shr6_6() const { return ___shr6_6; }
	inline float* get_address_of_shr6_6() { return &___shr6_6; }
	inline void set_shr6_6(float value)
	{
		___shr6_6 = value;
	}

	inline static int32_t get_offset_of_shr7_7() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr7_7)); }
	inline float get_shr7_7() const { return ___shr7_7; }
	inline float* get_address_of_shr7_7() { return &___shr7_7; }
	inline void set_shr7_7(float value)
	{
		___shr7_7 = value;
	}

	inline static int32_t get_offset_of_shr8_8() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shr8_8)); }
	inline float get_shr8_8() const { return ___shr8_8; }
	inline float* get_address_of_shr8_8() { return &___shr8_8; }
	inline void set_shr8_8(float value)
	{
		___shr8_8 = value;
	}

	inline static int32_t get_offset_of_shg0_9() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg0_9)); }
	inline float get_shg0_9() const { return ___shg0_9; }
	inline float* get_address_of_shg0_9() { return &___shg0_9; }
	inline void set_shg0_9(float value)
	{
		___shg0_9 = value;
	}

	inline static int32_t get_offset_of_shg1_10() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg1_10)); }
	inline float get_shg1_10() const { return ___shg1_10; }
	inline float* get_address_of_shg1_10() { return &___shg1_10; }
	inline void set_shg1_10(float value)
	{
		___shg1_10 = value;
	}

	inline static int32_t get_offset_of_shg2_11() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg2_11)); }
	inline float get_shg2_11() const { return ___shg2_11; }
	inline float* get_address_of_shg2_11() { return &___shg2_11; }
	inline void set_shg2_11(float value)
	{
		___shg2_11 = value;
	}

	inline static int32_t get_offset_of_shg3_12() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg3_12)); }
	inline float get_shg3_12() const { return ___shg3_12; }
	inline float* get_address_of_shg3_12() { return &___shg3_12; }
	inline void set_shg3_12(float value)
	{
		___shg3_12 = value;
	}

	inline static int32_t get_offset_of_shg4_13() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg4_13)); }
	inline float get_shg4_13() const { return ___shg4_13; }
	inline float* get_address_of_shg4_13() { return &___shg4_13; }
	inline void set_shg4_13(float value)
	{
		___shg4_13 = value;
	}

	inline static int32_t get_offset_of_shg5_14() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg5_14)); }
	inline float get_shg5_14() const { return ___shg5_14; }
	inline float* get_address_of_shg5_14() { return &___shg5_14; }
	inline void set_shg5_14(float value)
	{
		___shg5_14 = value;
	}

	inline static int32_t get_offset_of_shg6_15() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg6_15)); }
	inline float get_shg6_15() const { return ___shg6_15; }
	inline float* get_address_of_shg6_15() { return &___shg6_15; }
	inline void set_shg6_15(float value)
	{
		___shg6_15 = value;
	}

	inline static int32_t get_offset_of_shg7_16() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg7_16)); }
	inline float get_shg7_16() const { return ___shg7_16; }
	inline float* get_address_of_shg7_16() { return &___shg7_16; }
	inline void set_shg7_16(float value)
	{
		___shg7_16 = value;
	}

	inline static int32_t get_offset_of_shg8_17() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shg8_17)); }
	inline float get_shg8_17() const { return ___shg8_17; }
	inline float* get_address_of_shg8_17() { return &___shg8_17; }
	inline void set_shg8_17(float value)
	{
		___shg8_17 = value;
	}

	inline static int32_t get_offset_of_shb0_18() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb0_18)); }
	inline float get_shb0_18() const { return ___shb0_18; }
	inline float* get_address_of_shb0_18() { return &___shb0_18; }
	inline void set_shb0_18(float value)
	{
		___shb0_18 = value;
	}

	inline static int32_t get_offset_of_shb1_19() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb1_19)); }
	inline float get_shb1_19() const { return ___shb1_19; }
	inline float* get_address_of_shb1_19() { return &___shb1_19; }
	inline void set_shb1_19(float value)
	{
		___shb1_19 = value;
	}

	inline static int32_t get_offset_of_shb2_20() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb2_20)); }
	inline float get_shb2_20() const { return ___shb2_20; }
	inline float* get_address_of_shb2_20() { return &___shb2_20; }
	inline void set_shb2_20(float value)
	{
		___shb2_20 = value;
	}

	inline static int32_t get_offset_of_shb3_21() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb3_21)); }
	inline float get_shb3_21() const { return ___shb3_21; }
	inline float* get_address_of_shb3_21() { return &___shb3_21; }
	inline void set_shb3_21(float value)
	{
		___shb3_21 = value;
	}

	inline static int32_t get_offset_of_shb4_22() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb4_22)); }
	inline float get_shb4_22() const { return ___shb4_22; }
	inline float* get_address_of_shb4_22() { return &___shb4_22; }
	inline void set_shb4_22(float value)
	{
		___shb4_22 = value;
	}

	inline static int32_t get_offset_of_shb5_23() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb5_23)); }
	inline float get_shb5_23() const { return ___shb5_23; }
	inline float* get_address_of_shb5_23() { return &___shb5_23; }
	inline void set_shb5_23(float value)
	{
		___shb5_23 = value;
	}

	inline static int32_t get_offset_of_shb6_24() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb6_24)); }
	inline float get_shb6_24() const { return ___shb6_24; }
	inline float* get_address_of_shb6_24() { return &___shb6_24; }
	inline void set_shb6_24(float value)
	{
		___shb6_24 = value;
	}

	inline static int32_t get_offset_of_shb7_25() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb7_25)); }
	inline float get_shb7_25() const { return ___shb7_25; }
	inline float* get_address_of_shb7_25() { return &___shb7_25; }
	inline void set_shb7_25(float value)
	{
		___shb7_25 = value;
	}

	inline static int32_t get_offset_of_shb8_26() { return static_cast<int32_t>(offsetof(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64, ___shb8_26)); }
	inline float get_shb8_26() const { return ___shb8_26; }
	inline float* get_address_of_shb8_26() { return &___shb8_26; }
	inline void set_shb8_26(float value)
	{
		___shb8_26 = value;
	}
};


// System.UInt64
struct UInt64_tEC57511B3E3CA2DBA1BEBD434C6983E31C943281 
{
public:
	// System.UInt64 System.UInt64::m_value
	uint64_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt64_tEC57511B3E3CA2DBA1BEBD434C6983E31C943281, ___m_value_0)); }
	inline uint64_t get_m_value_0() const { return ___m_value_0; }
	inline uint64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint64_t value)
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


// System.Nullable`1<Unity.Collections.NativeSlice`1<System.Single>>
struct Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8 
{
public:
	// T System.Nullable`1::value
	NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8, ___value_0)); }
	inline NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535  get_value_0() const { return ___value_0; }
	inline NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(NativeSlice_1_tB0B8B32C6D8007DD7458D855C2870BAC7174B535  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<Unity.Collections.NativeSlice`1<System.UInt64>>
struct Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81 
{
public:
	// T System.Nullable`1::value
	NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81, ___value_0)); }
	inline NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E  get_value_0() const { return ___value_0; }
	inline NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(NativeSlice_1_tC500C2A688C23DCF5D0484D3D7856BCD82AE469E  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<Unity.Collections.NativeSlice`1<UnityEngine.Vector3>>
struct Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274 
{
public:
	// T System.Nullable`1::value
	NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274, ___value_0)); }
	inline NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125  get_value_0() const { return ___value_0; }
	inline NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(NativeSlice_1_tCD0AC77C2E3CDA052D42479FF29B6F9F6454B125  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<UnityEngine.Color>
struct Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498 
{
public:
	// T System.Nullable`1::value
	Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498, ___value_0)); }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  get_value_0() const { return ___value_0; }
	inline Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<UnityEngine.Matrix4x4>
struct Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E 
{
public:
	// T System.Nullable`1::value
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E, ___value_0)); }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  get_value_0() const { return ___value_0; }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<UnityEngine.Rendering.SphericalHarmonicsL2>
struct Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E 
{
public:
	// T System.Nullable`1::value
	SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E, ___value_0)); }
	inline SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64  get_value_0() const { return ___value_0; }
	inline SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(SphericalHarmonicsL2_tD2EC2ADCA26B9BE05036C3ABCF3CC049EC73EA64  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.Nullable`1<UnityEngine.Vector3>
struct Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258 
{
public:
	// T System.Nullable`1::value
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258, ___value_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_value_0() const { return ___value_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};


// System.AppDomain
struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A  : public MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8
{
public:
	// System.IntPtr System.AppDomain::_mono_app_domain
	intptr_t ____mono_app_domain_1;
	// System.Object System.AppDomain::_evidence
	RuntimeObject * ____evidence_6;
	// System.Object System.AppDomain::_granted
	RuntimeObject * ____granted_7;
	// System.Int32 System.AppDomain::_principalPolicy
	int32_t ____principalPolicy_8;
	// System.AssemblyLoadEventHandler System.AppDomain::AssemblyLoad
	AssemblyLoadEventHandler_tE06B38463937F6FBCCECF4DF6519F83C1683FE0C * ___AssemblyLoad_11;
	// System.ResolveEventHandler System.AppDomain::AssemblyResolve
	ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * ___AssemblyResolve_12;
	// System.EventHandler System.AppDomain::DomainUnload
	EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * ___DomainUnload_13;
	// System.EventHandler System.AppDomain::ProcessExit
	EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * ___ProcessExit_14;
	// System.ResolveEventHandler System.AppDomain::ResourceResolve
	ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * ___ResourceResolve_15;
	// System.ResolveEventHandler System.AppDomain::TypeResolve
	ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * ___TypeResolve_16;
	// System.UnhandledExceptionEventHandler System.AppDomain::UnhandledException
	UnhandledExceptionEventHandler_t1DF125A860ED9B70F24ADFA6CB0781533A23DA64 * ___UnhandledException_17;
	// System.EventHandler`1<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs> System.AppDomain::FirstChanceException
	EventHandler_1_t7F26BD2270AD4531F2328FD1382278E975249DF1 * ___FirstChanceException_18;
	// System.Object System.AppDomain::_domain_manager
	RuntimeObject * ____domain_manager_19;
	// System.ResolveEventHandler System.AppDomain::ReflectionOnlyAssemblyResolve
	ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * ___ReflectionOnlyAssemblyResolve_20;
	// System.Object System.AppDomain::_activation
	RuntimeObject * ____activation_21;
	// System.Object System.AppDomain::_applicationIdentity
	RuntimeObject * ____applicationIdentity_22;
	// System.Collections.Generic.List`1<System.String> System.AppDomain::compatibility_switch
	List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * ___compatibility_switch_23;

public:
	inline static int32_t get_offset_of__mono_app_domain_1() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____mono_app_domain_1)); }
	inline intptr_t get__mono_app_domain_1() const { return ____mono_app_domain_1; }
	inline intptr_t* get_address_of__mono_app_domain_1() { return &____mono_app_domain_1; }
	inline void set__mono_app_domain_1(intptr_t value)
	{
		____mono_app_domain_1 = value;
	}

	inline static int32_t get_offset_of__evidence_6() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____evidence_6)); }
	inline RuntimeObject * get__evidence_6() const { return ____evidence_6; }
	inline RuntimeObject ** get_address_of__evidence_6() { return &____evidence_6; }
	inline void set__evidence_6(RuntimeObject * value)
	{
		____evidence_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____evidence_6), (void*)value);
	}

	inline static int32_t get_offset_of__granted_7() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____granted_7)); }
	inline RuntimeObject * get__granted_7() const { return ____granted_7; }
	inline RuntimeObject ** get_address_of__granted_7() { return &____granted_7; }
	inline void set__granted_7(RuntimeObject * value)
	{
		____granted_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____granted_7), (void*)value);
	}

	inline static int32_t get_offset_of__principalPolicy_8() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____principalPolicy_8)); }
	inline int32_t get__principalPolicy_8() const { return ____principalPolicy_8; }
	inline int32_t* get_address_of__principalPolicy_8() { return &____principalPolicy_8; }
	inline void set__principalPolicy_8(int32_t value)
	{
		____principalPolicy_8 = value;
	}

	inline static int32_t get_offset_of_AssemblyLoad_11() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___AssemblyLoad_11)); }
	inline AssemblyLoadEventHandler_tE06B38463937F6FBCCECF4DF6519F83C1683FE0C * get_AssemblyLoad_11() const { return ___AssemblyLoad_11; }
	inline AssemblyLoadEventHandler_tE06B38463937F6FBCCECF4DF6519F83C1683FE0C ** get_address_of_AssemblyLoad_11() { return &___AssemblyLoad_11; }
	inline void set_AssemblyLoad_11(AssemblyLoadEventHandler_tE06B38463937F6FBCCECF4DF6519F83C1683FE0C * value)
	{
		___AssemblyLoad_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___AssemblyLoad_11), (void*)value);
	}

	inline static int32_t get_offset_of_AssemblyResolve_12() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___AssemblyResolve_12)); }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * get_AssemblyResolve_12() const { return ___AssemblyResolve_12; }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 ** get_address_of_AssemblyResolve_12() { return &___AssemblyResolve_12; }
	inline void set_AssemblyResolve_12(ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * value)
	{
		___AssemblyResolve_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___AssemblyResolve_12), (void*)value);
	}

	inline static int32_t get_offset_of_DomainUnload_13() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___DomainUnload_13)); }
	inline EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * get_DomainUnload_13() const { return ___DomainUnload_13; }
	inline EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B ** get_address_of_DomainUnload_13() { return &___DomainUnload_13; }
	inline void set_DomainUnload_13(EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * value)
	{
		___DomainUnload_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DomainUnload_13), (void*)value);
	}

	inline static int32_t get_offset_of_ProcessExit_14() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___ProcessExit_14)); }
	inline EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * get_ProcessExit_14() const { return ___ProcessExit_14; }
	inline EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B ** get_address_of_ProcessExit_14() { return &___ProcessExit_14; }
	inline void set_ProcessExit_14(EventHandler_t084491E53EC706ACA0A15CA17488C075B4ECA44B * value)
	{
		___ProcessExit_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ProcessExit_14), (void*)value);
	}

	inline static int32_t get_offset_of_ResourceResolve_15() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___ResourceResolve_15)); }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * get_ResourceResolve_15() const { return ___ResourceResolve_15; }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 ** get_address_of_ResourceResolve_15() { return &___ResourceResolve_15; }
	inline void set_ResourceResolve_15(ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * value)
	{
		___ResourceResolve_15 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ResourceResolve_15), (void*)value);
	}

	inline static int32_t get_offset_of_TypeResolve_16() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___TypeResolve_16)); }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * get_TypeResolve_16() const { return ___TypeResolve_16; }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 ** get_address_of_TypeResolve_16() { return &___TypeResolve_16; }
	inline void set_TypeResolve_16(ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * value)
	{
		___TypeResolve_16 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TypeResolve_16), (void*)value);
	}

	inline static int32_t get_offset_of_UnhandledException_17() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___UnhandledException_17)); }
	inline UnhandledExceptionEventHandler_t1DF125A860ED9B70F24ADFA6CB0781533A23DA64 * get_UnhandledException_17() const { return ___UnhandledException_17; }
	inline UnhandledExceptionEventHandler_t1DF125A860ED9B70F24ADFA6CB0781533A23DA64 ** get_address_of_UnhandledException_17() { return &___UnhandledException_17; }
	inline void set_UnhandledException_17(UnhandledExceptionEventHandler_t1DF125A860ED9B70F24ADFA6CB0781533A23DA64 * value)
	{
		___UnhandledException_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___UnhandledException_17), (void*)value);
	}

	inline static int32_t get_offset_of_FirstChanceException_18() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___FirstChanceException_18)); }
	inline EventHandler_1_t7F26BD2270AD4531F2328FD1382278E975249DF1 * get_FirstChanceException_18() const { return ___FirstChanceException_18; }
	inline EventHandler_1_t7F26BD2270AD4531F2328FD1382278E975249DF1 ** get_address_of_FirstChanceException_18() { return &___FirstChanceException_18; }
	inline void set_FirstChanceException_18(EventHandler_1_t7F26BD2270AD4531F2328FD1382278E975249DF1 * value)
	{
		___FirstChanceException_18 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FirstChanceException_18), (void*)value);
	}

	inline static int32_t get_offset_of__domain_manager_19() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____domain_manager_19)); }
	inline RuntimeObject * get__domain_manager_19() const { return ____domain_manager_19; }
	inline RuntimeObject ** get_address_of__domain_manager_19() { return &____domain_manager_19; }
	inline void set__domain_manager_19(RuntimeObject * value)
	{
		____domain_manager_19 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____domain_manager_19), (void*)value);
	}

	inline static int32_t get_offset_of_ReflectionOnlyAssemblyResolve_20() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___ReflectionOnlyAssemblyResolve_20)); }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * get_ReflectionOnlyAssemblyResolve_20() const { return ___ReflectionOnlyAssemblyResolve_20; }
	inline ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 ** get_address_of_ReflectionOnlyAssemblyResolve_20() { return &___ReflectionOnlyAssemblyResolve_20; }
	inline void set_ReflectionOnlyAssemblyResolve_20(ResolveEventHandler_tC6827B550D5B6553B57571630B1EE01AC12A1089 * value)
	{
		___ReflectionOnlyAssemblyResolve_20 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ReflectionOnlyAssemblyResolve_20), (void*)value);
	}

	inline static int32_t get_offset_of__activation_21() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____activation_21)); }
	inline RuntimeObject * get__activation_21() const { return ____activation_21; }
	inline RuntimeObject ** get_address_of__activation_21() { return &____activation_21; }
	inline void set__activation_21(RuntimeObject * value)
	{
		____activation_21 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____activation_21), (void*)value);
	}

	inline static int32_t get_offset_of__applicationIdentity_22() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ____applicationIdentity_22)); }
	inline RuntimeObject * get__applicationIdentity_22() const { return ____applicationIdentity_22; }
	inline RuntimeObject ** get_address_of__applicationIdentity_22() { return &____applicationIdentity_22; }
	inline void set__applicationIdentity_22(RuntimeObject * value)
	{
		____applicationIdentity_22 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____applicationIdentity_22), (void*)value);
	}

	inline static int32_t get_offset_of_compatibility_switch_23() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A, ___compatibility_switch_23)); }
	inline List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * get_compatibility_switch_23() const { return ___compatibility_switch_23; }
	inline List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 ** get_address_of_compatibility_switch_23() { return &___compatibility_switch_23; }
	inline void set_compatibility_switch_23(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * value)
	{
		___compatibility_switch_23 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___compatibility_switch_23), (void*)value);
	}
};

struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_StaticFields
{
public:
	// System.String System.AppDomain::_process_guid
	String_t* ____process_guid_2;
	// System.AppDomain System.AppDomain::default_domain
	AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * ___default_domain_10;

public:
	inline static int32_t get_offset_of__process_guid_2() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_StaticFields, ____process_guid_2)); }
	inline String_t* get__process_guid_2() const { return ____process_guid_2; }
	inline String_t** get_address_of__process_guid_2() { return &____process_guid_2; }
	inline void set__process_guid_2(String_t* value)
	{
		____process_guid_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____process_guid_2), (void*)value);
	}

	inline static int32_t get_offset_of_default_domain_10() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_StaticFields, ___default_domain_10)); }
	inline AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * get_default_domain_10() const { return ___default_domain_10; }
	inline AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A ** get_address_of_default_domain_10() { return &___default_domain_10; }
	inline void set_default_domain_10(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * value)
	{
		___default_domain_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___default_domain_10), (void*)value);
	}
};

struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_ThreadStaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::type_resolve_in_progress
	Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * ___type_resolve_in_progress_3;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::assembly_resolve_in_progress
	Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * ___assembly_resolve_in_progress_4;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::assembly_resolve_in_progress_refonly
	Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * ___assembly_resolve_in_progress_refonly_5;
	// System.Object System.AppDomain::_principal
	RuntimeObject * ____principal_9;

public:
	inline static int32_t get_offset_of_type_resolve_in_progress_3() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_ThreadStaticFields, ___type_resolve_in_progress_3)); }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * get_type_resolve_in_progress_3() const { return ___type_resolve_in_progress_3; }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 ** get_address_of_type_resolve_in_progress_3() { return &___type_resolve_in_progress_3; }
	inline void set_type_resolve_in_progress_3(Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * value)
	{
		___type_resolve_in_progress_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___type_resolve_in_progress_3), (void*)value);
	}

	inline static int32_t get_offset_of_assembly_resolve_in_progress_4() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_ThreadStaticFields, ___assembly_resolve_in_progress_4)); }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * get_assembly_resolve_in_progress_4() const { return ___assembly_resolve_in_progress_4; }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 ** get_address_of_assembly_resolve_in_progress_4() { return &___assembly_resolve_in_progress_4; }
	inline void set_assembly_resolve_in_progress_4(Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * value)
	{
		___assembly_resolve_in_progress_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___assembly_resolve_in_progress_4), (void*)value);
	}

	inline static int32_t get_offset_of_assembly_resolve_in_progress_refonly_5() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_ThreadStaticFields, ___assembly_resolve_in_progress_refonly_5)); }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * get_assembly_resolve_in_progress_refonly_5() const { return ___assembly_resolve_in_progress_refonly_5; }
	inline Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 ** get_address_of_assembly_resolve_in_progress_refonly_5() { return &___assembly_resolve_in_progress_refonly_5; }
	inline void set_assembly_resolve_in_progress_refonly_5(Dictionary_2_t692011309BA94F599C6042A381FC9F8B3CB08399 * value)
	{
		___assembly_resolve_in_progress_refonly_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___assembly_resolve_in_progress_refonly_5), (void*)value);
	}

	inline static int32_t get_offset_of__principal_9() { return static_cast<int32_t>(offsetof(AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_ThreadStaticFields, ____principal_9)); }
	inline RuntimeObject * get__principal_9() const { return ____principal_9; }
	inline RuntimeObject ** get_address_of__principal_9() { return &____principal_9; }
	inline void set__principal_9(RuntimeObject * value)
	{
		____principal_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____principal_9), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.AppDomain
struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_marshaled_pinvoke : public MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8_marshaled_pinvoke
{
	intptr_t ____mono_app_domain_1;
	Il2CppIUnknown* ____evidence_6;
	Il2CppIUnknown* ____granted_7;
	int32_t ____principalPolicy_8;
	Il2CppMethodPointer ___AssemblyLoad_11;
	Il2CppMethodPointer ___AssemblyResolve_12;
	Il2CppMethodPointer ___DomainUnload_13;
	Il2CppMethodPointer ___ProcessExit_14;
	Il2CppMethodPointer ___ResourceResolve_15;
	Il2CppMethodPointer ___TypeResolve_16;
	Il2CppMethodPointer ___UnhandledException_17;
	Il2CppMethodPointer ___FirstChanceException_18;
	Il2CppIUnknown* ____domain_manager_19;
	Il2CppMethodPointer ___ReflectionOnlyAssemblyResolve_20;
	Il2CppIUnknown* ____activation_21;
	Il2CppIUnknown* ____applicationIdentity_22;
	List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * ___compatibility_switch_23;
};
// Native definition for COM marshalling of System.AppDomain
struct AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A_marshaled_com : public MarshalByRefObject_tD4DF91B488B284F899417EC468D8E50E933306A8_marshaled_com
{
	intptr_t ____mono_app_domain_1;
	Il2CppIUnknown* ____evidence_6;
	Il2CppIUnknown* ____granted_7;
	int32_t ____principalPolicy_8;
	Il2CppMethodPointer ___AssemblyLoad_11;
	Il2CppMethodPointer ___AssemblyResolve_12;
	Il2CppMethodPointer ___DomainUnload_13;
	Il2CppMethodPointer ___ProcessExit_14;
	Il2CppMethodPointer ___ResourceResolve_15;
	Il2CppMethodPointer ___TypeResolve_16;
	Il2CppMethodPointer ___UnhandledException_17;
	Il2CppMethodPointer ___FirstChanceException_18;
	Il2CppIUnknown* ____domain_manager_19;
	Il2CppMethodPointer ___ReflectionOnlyAssemblyResolve_20;
	Il2CppIUnknown* ____activation_21;
	Il2CppIUnknown* ____applicationIdentity_22;
	List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * ___compatibility_switch_23;
};

// System.Reflection.Assembly
struct Assembly_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Reflection.Assembly::_mono_assembly
	intptr_t ____mono_assembly_0;
	// System.Reflection.Assembly/ResolveEventHolder System.Reflection.Assembly::resolve_event_holder
	ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C * ___resolve_event_holder_1;
	// System.Object System.Reflection.Assembly::_evidence
	RuntimeObject * ____evidence_2;
	// System.Object System.Reflection.Assembly::_minimum
	RuntimeObject * ____minimum_3;
	// System.Object System.Reflection.Assembly::_optional
	RuntimeObject * ____optional_4;
	// System.Object System.Reflection.Assembly::_refuse
	RuntimeObject * ____refuse_5;
	// System.Object System.Reflection.Assembly::_granted
	RuntimeObject * ____granted_6;
	// System.Object System.Reflection.Assembly::_denied
	RuntimeObject * ____denied_7;
	// System.Boolean System.Reflection.Assembly::fromByteArray
	bool ___fromByteArray_8;
	// System.String System.Reflection.Assembly::assemblyName
	String_t* ___assemblyName_9;

public:
	inline static int32_t get_offset_of__mono_assembly_0() { return static_cast<int32_t>(offsetof(Assembly_t, ____mono_assembly_0)); }
	inline intptr_t get__mono_assembly_0() const { return ____mono_assembly_0; }
	inline intptr_t* get_address_of__mono_assembly_0() { return &____mono_assembly_0; }
	inline void set__mono_assembly_0(intptr_t value)
	{
		____mono_assembly_0 = value;
	}

	inline static int32_t get_offset_of_resolve_event_holder_1() { return static_cast<int32_t>(offsetof(Assembly_t, ___resolve_event_holder_1)); }
	inline ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C * get_resolve_event_holder_1() const { return ___resolve_event_holder_1; }
	inline ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C ** get_address_of_resolve_event_holder_1() { return &___resolve_event_holder_1; }
	inline void set_resolve_event_holder_1(ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C * value)
	{
		___resolve_event_holder_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___resolve_event_holder_1), (void*)value);
	}

	inline static int32_t get_offset_of__evidence_2() { return static_cast<int32_t>(offsetof(Assembly_t, ____evidence_2)); }
	inline RuntimeObject * get__evidence_2() const { return ____evidence_2; }
	inline RuntimeObject ** get_address_of__evidence_2() { return &____evidence_2; }
	inline void set__evidence_2(RuntimeObject * value)
	{
		____evidence_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____evidence_2), (void*)value);
	}

	inline static int32_t get_offset_of__minimum_3() { return static_cast<int32_t>(offsetof(Assembly_t, ____minimum_3)); }
	inline RuntimeObject * get__minimum_3() const { return ____minimum_3; }
	inline RuntimeObject ** get_address_of__minimum_3() { return &____minimum_3; }
	inline void set__minimum_3(RuntimeObject * value)
	{
		____minimum_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____minimum_3), (void*)value);
	}

	inline static int32_t get_offset_of__optional_4() { return static_cast<int32_t>(offsetof(Assembly_t, ____optional_4)); }
	inline RuntimeObject * get__optional_4() const { return ____optional_4; }
	inline RuntimeObject ** get_address_of__optional_4() { return &____optional_4; }
	inline void set__optional_4(RuntimeObject * value)
	{
		____optional_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____optional_4), (void*)value);
	}

	inline static int32_t get_offset_of__refuse_5() { return static_cast<int32_t>(offsetof(Assembly_t, ____refuse_5)); }
	inline RuntimeObject * get__refuse_5() const { return ____refuse_5; }
	inline RuntimeObject ** get_address_of__refuse_5() { return &____refuse_5; }
	inline void set__refuse_5(RuntimeObject * value)
	{
		____refuse_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____refuse_5), (void*)value);
	}

	inline static int32_t get_offset_of__granted_6() { return static_cast<int32_t>(offsetof(Assembly_t, ____granted_6)); }
	inline RuntimeObject * get__granted_6() const { return ____granted_6; }
	inline RuntimeObject ** get_address_of__granted_6() { return &____granted_6; }
	inline void set__granted_6(RuntimeObject * value)
	{
		____granted_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____granted_6), (void*)value);
	}

	inline static int32_t get_offset_of__denied_7() { return static_cast<int32_t>(offsetof(Assembly_t, ____denied_7)); }
	inline RuntimeObject * get__denied_7() const { return ____denied_7; }
	inline RuntimeObject ** get_address_of__denied_7() { return &____denied_7; }
	inline void set__denied_7(RuntimeObject * value)
	{
		____denied_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____denied_7), (void*)value);
	}

	inline static int32_t get_offset_of_fromByteArray_8() { return static_cast<int32_t>(offsetof(Assembly_t, ___fromByteArray_8)); }
	inline bool get_fromByteArray_8() const { return ___fromByteArray_8; }
	inline bool* get_address_of_fromByteArray_8() { return &___fromByteArray_8; }
	inline void set_fromByteArray_8(bool value)
	{
		___fromByteArray_8 = value;
	}

	inline static int32_t get_offset_of_assemblyName_9() { return static_cast<int32_t>(offsetof(Assembly_t, ___assemblyName_9)); }
	inline String_t* get_assemblyName_9() const { return ___assemblyName_9; }
	inline String_t** get_address_of_assemblyName_9() { return &___assemblyName_9; }
	inline void set_assemblyName_9(String_t* value)
	{
		___assemblyName_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___assemblyName_9), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Reflection.Assembly
struct Assembly_t_marshaled_pinvoke
{
	intptr_t ____mono_assembly_0;
	ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C * ___resolve_event_holder_1;
	Il2CppIUnknown* ____evidence_2;
	Il2CppIUnknown* ____minimum_3;
	Il2CppIUnknown* ____optional_4;
	Il2CppIUnknown* ____refuse_5;
	Il2CppIUnknown* ____granted_6;
	Il2CppIUnknown* ____denied_7;
	int32_t ___fromByteArray_8;
	char* ___assemblyName_9;
};
// Native definition for COM marshalling of System.Reflection.Assembly
struct Assembly_t_marshaled_com
{
	intptr_t ____mono_assembly_0;
	ResolveEventHolder_tA37081FAEBE21D83D216225B4489BA8A37B4E13C * ___resolve_event_holder_1;
	Il2CppIUnknown* ____evidence_2;
	Il2CppIUnknown* ____minimum_3;
	Il2CppIUnknown* ____optional_4;
	Il2CppIUnknown* ____refuse_5;
	Il2CppIUnknown* ____granted_6;
	Il2CppIUnknown* ____denied_7;
	int32_t ___fromByteArray_8;
	Il2CppChar* ___assemblyName_9;
};

// System.Reflection.BindingFlags
struct BindingFlags_tAAAB07D9AC588F0D55D844E51D7035E96DF94733 
{
public:
	// System.Int32 System.Reflection.BindingFlags::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(BindingFlags_tAAAB07D9AC588F0D55D844E51D7035E96DF94733, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.Bounds
struct Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37 
{
public:
	// UnityEngine.Vector3 UnityEngine.Bounds::m_Center
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Center_0;
	// UnityEngine.Vector3 UnityEngine.Bounds::m_Extents
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Extents_1;

public:
	inline static int32_t get_offset_of_m_Center_0() { return static_cast<int32_t>(offsetof(Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37, ___m_Center_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Center_0() const { return ___m_Center_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Center_0() { return &___m_Center_0; }
	inline void set_m_Center_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Center_0 = value;
	}

	inline static int32_t get_offset_of_m_Extents_1() { return static_cast<int32_t>(offsetof(Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37, ___m_Extents_1)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Extents_1() const { return ___m_Extents_1; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Extents_1() { return &___m_Extents_1; }
	inline void set_m_Extents_1(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Extents_1 = value;
	}
};


// Unity.MARS.Data.CameraFacingDirection
struct CameraFacingDirection_tDEEBEB42380D63343DC96CA912CB8BA75D4494D3 
{
public:
	// System.Int32 Unity.MARS.Data.CameraFacingDirection::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(CameraFacingDirection_tDEEBEB42380D63343DC96CA912CB8BA75D4494D3, ___value___2)); }
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

// Unity.MARS.Data.GeographicBoundingBox
struct GeographicBoundingBox_t90DAB838D5816584390689F87A72DB06F1C6F32A 
{
public:
	// Unity.MARS.Data.GeographicCoordinate Unity.MARS.Data.GeographicBoundingBox::center
	GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  ___center_0;
	// System.Double Unity.MARS.Data.GeographicBoundingBox::latitudeExtents
	double ___latitudeExtents_1;
	// System.Double Unity.MARS.Data.GeographicBoundingBox::longitudeExtents
	double ___longitudeExtents_2;

public:
	inline static int32_t get_offset_of_center_0() { return static_cast<int32_t>(offsetof(GeographicBoundingBox_t90DAB838D5816584390689F87A72DB06F1C6F32A, ___center_0)); }
	inline GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  get_center_0() const { return ___center_0; }
	inline GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * get_address_of_center_0() { return &___center_0; }
	inline void set_center_0(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  value)
	{
		___center_0 = value;
	}

	inline static int32_t get_offset_of_latitudeExtents_1() { return static_cast<int32_t>(offsetof(GeographicBoundingBox_t90DAB838D5816584390689F87A72DB06F1C6F32A, ___latitudeExtents_1)); }
	inline double get_latitudeExtents_1() const { return ___latitudeExtents_1; }
	inline double* get_address_of_latitudeExtents_1() { return &___latitudeExtents_1; }
	inline void set_latitudeExtents_1(double value)
	{
		___latitudeExtents_1 = value;
	}

	inline static int32_t get_offset_of_longitudeExtents_2() { return static_cast<int32_t>(offsetof(GeographicBoundingBox_t90DAB838D5816584390689F87A72DB06F1C6F32A, ___longitudeExtents_2)); }
	inline double get_longitudeExtents_2() const { return ___longitudeExtents_2; }
	inline double* get_address_of_longitudeExtents_2() { return &___longitudeExtents_2; }
	inline void set_longitudeExtents_2(double value)
	{
		___longitudeExtents_2 = value;
	}
};


// UnityEngine.HumanPose
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F 
{
public:
	// UnityEngine.Vector3 UnityEngine.HumanPose::bodyPosition
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___bodyPosition_0;
	// UnityEngine.Quaternion UnityEngine.HumanPose::bodyRotation
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___bodyRotation_1;
	// System.Single[] UnityEngine.HumanPose::muscles
	SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* ___muscles_2;

public:
	inline static int32_t get_offset_of_bodyPosition_0() { return static_cast<int32_t>(offsetof(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F, ___bodyPosition_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_bodyPosition_0() const { return ___bodyPosition_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_bodyPosition_0() { return &___bodyPosition_0; }
	inline void set_bodyPosition_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___bodyPosition_0 = value;
	}

	inline static int32_t get_offset_of_bodyRotation_1() { return static_cast<int32_t>(offsetof(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F, ___bodyRotation_1)); }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  get_bodyRotation_1() const { return ___bodyRotation_1; }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4 * get_address_of_bodyRotation_1() { return &___bodyRotation_1; }
	inline void set_bodyRotation_1(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  value)
	{
		___bodyRotation_1 = value;
	}

	inline static int32_t get_offset_of_muscles_2() { return static_cast<int32_t>(offsetof(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F, ___muscles_2)); }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* get_muscles_2() const { return ___muscles_2; }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA** get_address_of_muscles_2() { return &___muscles_2; }
	inline void set_muscles_2(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* value)
	{
		___muscles_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___muscles_2), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of UnityEngine.HumanPose
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___bodyPosition_0;
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___bodyRotation_1;
	Il2CppSafeArray/*NONE*/* ___muscles_2;
};
// Native definition for COM marshalling of UnityEngine.HumanPose
struct HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___bodyPosition_0;
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___bodyRotation_1;
	Il2CppSafeArray/*NONE*/* ___muscles_2;
};

// Unity.MARS.Data.MARSTrackingState
struct MARSTrackingState_t123CCD8D1D2C4524143EAB2A6333B4EC53EA240B 
{
public:
	// System.Int32 Unity.MARS.Data.MARSTrackingState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MARSTrackingState_t123CCD8D1D2C4524143EAB2A6333B4EC53EA240B, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MRCameraTrackingState
struct MRCameraTrackingState_tFC8C1634762E2B8264FE590042BBCE76F3D9B637 
{
public:
	// System.Int32 Unity.MARS.Data.MRCameraTrackingState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MRCameraTrackingState_tFC8C1634762E2B8264FE590042BBCE76F3D9B637, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MRFaceExpression
struct MRFaceExpression_t942116AE8F072F09DE772F2985D3FF69596FCD88 
{
public:
	// System.Int32 Unity.MARS.Data.MRFaceExpression::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MRFaceExpression_t942116AE8F072F09DE772F2985D3FF69596FCD88, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MRFaceLandmark
struct MRFaceLandmark_tCAC9D3CEC7E57009E97111DF2BE9459ABE5EBC9F 
{
public:
	// System.Int32 Unity.MARS.Data.MRFaceLandmark::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MRFaceLandmark_tCAC9D3CEC7E57009E97111DF2BE9459ABE5EBC9F, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MRHitTestResultTypes
struct MRHitTestResultTypes_t84E36D572603E9ACD1E966AA0397548DDD3F2AD4 
{
public:
	// System.Int32 Unity.MARS.Data.MRHitTestResultTypes::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MRHitTestResultTypes_t84E36D572603E9ACD1E966AA0397548DDD3F2AD4, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MarsPlaneAlignment
struct MarsPlaneAlignment_tFEAC5FD4D3D7E4BE17CC147E15C9280F76A7C946 
{
public:
	// System.Int32 Unity.MARS.Data.MarsPlaneAlignment::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MarsPlaneAlignment_tFEAC5FD4D3D7E4BE17CC147E15C9280F76A7C946, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Query.MarsSceneEvaluationMode
struct MarsSceneEvaluationMode_t685BE5109975A215B87B1CB3C70284FEDF6FA74C 
{
public:
	// System.Byte Unity.MARS.Query.MarsSceneEvaluationMode::value__
	uint8_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MarsSceneEvaluationMode_t685BE5109975A215B87B1CB3C70284FEDF6FA74C, ___value___2)); }
	inline uint8_t get_value___2() const { return ___value___2; }
	inline uint8_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint8_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Query.MarsSceneEvaluationRequestResponse
struct MarsSceneEvaluationRequestResponse_t0E87AF0DA4F0A945E0826D21CC9C0D3FF6DD8F7C 
{
public:
	// System.Byte Unity.MARS.Query.MarsSceneEvaluationRequestResponse::value__
	uint8_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MarsSceneEvaluationRequestResponse_t0E87AF0DA4F0A945E0826D21CC9C0D3FF6DD8F7C, ___value___2)); }
	inline uint8_t get_value___2() const { return ___value___2; }
	inline uint8_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint8_t value)
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

// UnityEngine.Pose
struct Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A 
{
public:
	// UnityEngine.Vector3 UnityEngine.Pose::position
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position_0;
	// UnityEngine.Quaternion UnityEngine.Pose::rotation
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___rotation_1;

public:
	inline static int32_t get_offset_of_position_0() { return static_cast<int32_t>(offsetof(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A, ___position_0)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_position_0() const { return ___position_0; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_position_0() { return &___position_0; }
	inline void set_position_0(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___position_0 = value;
	}

	inline static int32_t get_offset_of_rotation_1() { return static_cast<int32_t>(offsetof(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A, ___rotation_1)); }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  get_rotation_1() const { return ___rotation_1; }
	inline Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4 * get_address_of_rotation_1() { return &___rotation_1; }
	inline void set_rotation_1(Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  value)
	{
		___rotation_1 = value;
	}
};

struct Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_StaticFields
{
public:
	// UnityEngine.Pose UnityEngine.Pose::k_Identity
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___k_Identity_2;

public:
	inline static int32_t get_offset_of_k_Identity_2() { return static_cast<int32_t>(offsetof(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_StaticFields, ___k_Identity_2)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_k_Identity_2() const { return ___k_Identity_2; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_k_Identity_2() { return &___k_Identity_2; }
	inline void set_k_Identity_2(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___k_Identity_2 = value;
	}
};


// Unity.MARS.Data.ProcessingJobType
struct ProcessingJobType_t7A4F4483252D8C6443121176213FBA8FAF0FA66E 
{
public:
	// System.Int32 Unity.MARS.Data.ProcessingJobType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ProcessingJobType_t7A4F4483252D8C6443121176213FBA8FAF0FA66E, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Query.QueryState
struct QueryState_t0C1F7D2FCAD04A7159D2DBB7AF96C026D53F8988 
{
public:
	// System.Int32 Unity.MARS.Query.QueryState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(QueryState_t0C1F7D2FCAD04A7159D2DBB7AF96C026D53F8988, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.ReservedDataIDs
struct ReservedDataIDs_tB3883211481395749BF4CCD082169528C1348929 
{
public:
	// System.Int32 Unity.MARS.Data.ReservedDataIDs::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ReservedDataIDs_tB3883211481395749BF4CCD082169528C1348929, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.RuntimeTypeHandle
struct RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9 
{
public:
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9, ___value_0)); }
	inline intptr_t get_value_0() const { return ___value_0; }
	inline intptr_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(intptr_t value)
	{
		___value_0 = value;
	}
};


// Unity.MARS.Query.SemanticTagMatchRule
struct SemanticTagMatchRule_t41B5E4D7D3B4E9F5FC66C3B7F7B8D36864FE20CB 
{
public:
	// System.Int32 Unity.MARS.Query.SemanticTagMatchRule::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SemanticTagMatchRule_t41B5E4D7D3B4E9F5FC66C3B7F7B8D36864FE20CB, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Unity.MARS.Data.MRHitTestResult
struct MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 
{
public:
	// UnityEngine.Pose Unity.MARS.Data.MRHitTestResult::<pose>k__BackingField
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___U3CposeU3Ek__BackingField_0;

public:
	inline static int32_t get_offset_of_U3CposeU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3, ___U3CposeU3Ek__BackingField_0)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_U3CposeU3Ek__BackingField_0() const { return ___U3CposeU3Ek__BackingField_0; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_U3CposeU3Ek__BackingField_0() { return &___U3CposeU3Ek__BackingField_0; }
	inline void set_U3CposeU3Ek__BackingField_0(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___U3CposeU3Ek__BackingField_0 = value;
	}
};


// Unity.MARS.Data.MRLightEstimation
struct MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096 
{
public:
	// System.Nullable`1<System.Single> Unity.MARS.Data.MRLightEstimation::m_AmbientBrightness
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientBrightness_0;
	// System.Nullable`1<System.Single> Unity.MARS.Data.MRLightEstimation::m_AmbientColorTemperature
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientColorTemperature_1;
	// System.Nullable`1<System.Single> Unity.MARS.Data.MRLightEstimation::m_AmbientIntensityInLumens
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientIntensityInLumens_2;
	// System.Nullable`1<UnityEngine.Color> Unity.MARS.Data.MRLightEstimation::m_ColorCorrection
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_ColorCorrection_3;
	// System.Nullable`1<System.Single> Unity.MARS.Data.MRLightEstimation::m_MainLightBrightness
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightBrightness_4;
	// System.Nullable`1<UnityEngine.Color> Unity.MARS.Data.MRLightEstimation::m_MainLightColor
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_MainLightColor_5;
	// System.Nullable`1<UnityEngine.Vector3> Unity.MARS.Data.MRLightEstimation::m_MainLightDirection
	Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258  ___m_MainLightDirection_6;
	// System.Nullable`1<System.Single> Unity.MARS.Data.MRLightEstimation::m_MainLightIntensityLumens
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightIntensityLumens_7;
	// System.Nullable`1<UnityEngine.Rendering.SphericalHarmonicsL2> Unity.MARS.Data.MRLightEstimation::m_SphericalHarmonics
	Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E  ___m_SphericalHarmonics_8;

public:
	inline static int32_t get_offset_of_m_AmbientBrightness_0() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_AmbientBrightness_0)); }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  get_m_AmbientBrightness_0() const { return ___m_AmbientBrightness_0; }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A * get_address_of_m_AmbientBrightness_0() { return &___m_AmbientBrightness_0; }
	inline void set_m_AmbientBrightness_0(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  value)
	{
		___m_AmbientBrightness_0 = value;
	}

	inline static int32_t get_offset_of_m_AmbientColorTemperature_1() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_AmbientColorTemperature_1)); }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  get_m_AmbientColorTemperature_1() const { return ___m_AmbientColorTemperature_1; }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A * get_address_of_m_AmbientColorTemperature_1() { return &___m_AmbientColorTemperature_1; }
	inline void set_m_AmbientColorTemperature_1(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  value)
	{
		___m_AmbientColorTemperature_1 = value;
	}

	inline static int32_t get_offset_of_m_AmbientIntensityInLumens_2() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_AmbientIntensityInLumens_2)); }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  get_m_AmbientIntensityInLumens_2() const { return ___m_AmbientIntensityInLumens_2; }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A * get_address_of_m_AmbientIntensityInLumens_2() { return &___m_AmbientIntensityInLumens_2; }
	inline void set_m_AmbientIntensityInLumens_2(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  value)
	{
		___m_AmbientIntensityInLumens_2 = value;
	}

	inline static int32_t get_offset_of_m_ColorCorrection_3() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_ColorCorrection_3)); }
	inline Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  get_m_ColorCorrection_3() const { return ___m_ColorCorrection_3; }
	inline Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498 * get_address_of_m_ColorCorrection_3() { return &___m_ColorCorrection_3; }
	inline void set_m_ColorCorrection_3(Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  value)
	{
		___m_ColorCorrection_3 = value;
	}

	inline static int32_t get_offset_of_m_MainLightBrightness_4() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_MainLightBrightness_4)); }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  get_m_MainLightBrightness_4() const { return ___m_MainLightBrightness_4; }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A * get_address_of_m_MainLightBrightness_4() { return &___m_MainLightBrightness_4; }
	inline void set_m_MainLightBrightness_4(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  value)
	{
		___m_MainLightBrightness_4 = value;
	}

	inline static int32_t get_offset_of_m_MainLightColor_5() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_MainLightColor_5)); }
	inline Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  get_m_MainLightColor_5() const { return ___m_MainLightColor_5; }
	inline Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498 * get_address_of_m_MainLightColor_5() { return &___m_MainLightColor_5; }
	inline void set_m_MainLightColor_5(Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  value)
	{
		___m_MainLightColor_5 = value;
	}

	inline static int32_t get_offset_of_m_MainLightDirection_6() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_MainLightDirection_6)); }
	inline Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258  get_m_MainLightDirection_6() const { return ___m_MainLightDirection_6; }
	inline Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258 * get_address_of_m_MainLightDirection_6() { return &___m_MainLightDirection_6; }
	inline void set_m_MainLightDirection_6(Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258  value)
	{
		___m_MainLightDirection_6 = value;
	}

	inline static int32_t get_offset_of_m_MainLightIntensityLumens_7() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_MainLightIntensityLumens_7)); }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  get_m_MainLightIntensityLumens_7() const { return ___m_MainLightIntensityLumens_7; }
	inline Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A * get_address_of_m_MainLightIntensityLumens_7() { return &___m_MainLightIntensityLumens_7; }
	inline void set_m_MainLightIntensityLumens_7(Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  value)
	{
		___m_MainLightIntensityLumens_7 = value;
	}

	inline static int32_t get_offset_of_m_SphericalHarmonics_8() { return static_cast<int32_t>(offsetof(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096, ___m_SphericalHarmonics_8)); }
	inline Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E  get_m_SphericalHarmonics_8() const { return ___m_SphericalHarmonics_8; }
	inline Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E * get_address_of_m_SphericalHarmonics_8() { return &___m_SphericalHarmonics_8; }
	inline void set_m_SphericalHarmonics_8(Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E  value)
	{
		___m_SphericalHarmonics_8 = value;
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.Data.MRLightEstimation
struct MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_pinvoke
{
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientBrightness_0;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientColorTemperature_1;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientIntensityInLumens_2;
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_ColorCorrection_3;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightBrightness_4;
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_MainLightColor_5;
	Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258  ___m_MainLightDirection_6;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightIntensityLumens_7;
	Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E  ___m_SphericalHarmonics_8;
};
// Native definition for COM marshalling of Unity.MARS.Data.MRLightEstimation
struct MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_com
{
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientBrightness_0;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientColorTemperature_1;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_AmbientIntensityInLumens_2;
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_ColorCorrection_3;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightBrightness_4;
	Nullable_1_tA06400BA484934D9CEBAF66D0E71C822EF09A498  ___m_MainLightColor_5;
	Nullable_1_t1829213F3538788DF79B4659AFC9D6A9C90C3258  ___m_MainLightDirection_6;
	Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  ___m_MainLightIntensityLumens_7;
	Nullable_1_t87378933461FE259D349B667A2D4FE02B800A81E  ___m_SphericalHarmonics_8;
};

// Unity.MARS.Data.MRMarker
struct MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 
{
public:
	// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRMarker::m_TrackableId
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_TrackableId_0;
	// UnityEngine.Pose Unity.MARS.Data.MRMarker::m_Pose
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_1;
	// System.Guid Unity.MARS.Data.MRMarker::m_MarkerId
	Guid_t  ___m_MarkerId_2;
	// UnityEngine.Vector2 Unity.MARS.Data.MRMarker::m_Extents
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_3;
	// Unity.MARS.Data.MARSTrackingState Unity.MARS.Data.MRMarker::m_TrackingState
	int32_t ___m_TrackingState_4;
	// UnityEngine.Texture2D Unity.MARS.Data.MRMarker::m_Texture
	Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___m_Texture_5;

public:
	inline static int32_t get_offset_of_m_TrackableId_0() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_TrackableId_0)); }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  get_m_TrackableId_0() const { return ___m_TrackableId_0; }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * get_address_of_m_TrackableId_0() { return &___m_TrackableId_0; }
	inline void set_m_TrackableId_0(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  value)
	{
		___m_TrackableId_0 = value;
	}

	inline static int32_t get_offset_of_m_Pose_1() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_Pose_1)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_m_Pose_1() const { return ___m_Pose_1; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_m_Pose_1() { return &___m_Pose_1; }
	inline void set_m_Pose_1(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___m_Pose_1 = value;
	}

	inline static int32_t get_offset_of_m_MarkerId_2() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_MarkerId_2)); }
	inline Guid_t  get_m_MarkerId_2() const { return ___m_MarkerId_2; }
	inline Guid_t * get_address_of_m_MarkerId_2() { return &___m_MarkerId_2; }
	inline void set_m_MarkerId_2(Guid_t  value)
	{
		___m_MarkerId_2 = value;
	}

	inline static int32_t get_offset_of_m_Extents_3() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_Extents_3)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_m_Extents_3() const { return ___m_Extents_3; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_m_Extents_3() { return &___m_Extents_3; }
	inline void set_m_Extents_3(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___m_Extents_3 = value;
	}

	inline static int32_t get_offset_of_m_TrackingState_4() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_TrackingState_4)); }
	inline int32_t get_m_TrackingState_4() const { return ___m_TrackingState_4; }
	inline int32_t* get_address_of_m_TrackingState_4() { return &___m_TrackingState_4; }
	inline void set_m_TrackingState_4(int32_t value)
	{
		___m_TrackingState_4 = value;
	}

	inline static int32_t get_offset_of_m_Texture_5() { return static_cast<int32_t>(offsetof(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50, ___m_Texture_5)); }
	inline Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * get_m_Texture_5() const { return ___m_Texture_5; }
	inline Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF ** get_address_of_m_Texture_5() { return &___m_Texture_5; }
	inline void set_m_Texture_5(Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * value)
	{
		___m_Texture_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Texture_5), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.Data.MRMarker
struct MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_pinvoke
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_TrackableId_0;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_1;
	Guid_t  ___m_MarkerId_2;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_3;
	int32_t ___m_TrackingState_4;
	Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___m_Texture_5;
};
// Native definition for COM marshalling of Unity.MARS.Data.MRMarker
struct MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_com
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_TrackableId_0;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_1;
	Guid_t  ___m_MarkerId_2;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_3;
	int32_t ___m_TrackingState_4;
	Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___m_Texture_5;
};

// Unity.MARS.Data.MRPlane
struct MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 
{
public:
	// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRPlane::m_ID
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_ID_1;
	// Unity.MARS.Data.MarsPlaneAlignment Unity.MARS.Data.MRPlane::m_Alignment
	int32_t ___m_Alignment_2;
	// UnityEngine.Pose Unity.MARS.Data.MRPlane::m_Pose
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_3;
	// UnityEngine.Vector3 Unity.MARS.Data.MRPlane::m_Center
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Center_4;
	// UnityEngine.Vector2 Unity.MARS.Data.MRPlane::m_Extents
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_5;
	// System.Collections.Generic.List`1<UnityEngine.Vector3> Unity.MARS.Data.MRPlane::vertices
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___vertices_6;
	// System.Collections.Generic.List`1<UnityEngine.Vector2> Unity.MARS.Data.MRPlane::textureCoordinates
	List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * ___textureCoordinates_7;
	// System.Collections.Generic.List`1<UnityEngine.Vector3> Unity.MARS.Data.MRPlane::normals
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___normals_8;
	// System.Collections.Generic.List`1<System.Int32> Unity.MARS.Data.MRPlane::indices
	List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___indices_9;

public:
	inline static int32_t get_offset_of_m_ID_1() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___m_ID_1)); }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  get_m_ID_1() const { return ___m_ID_1; }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * get_address_of_m_ID_1() { return &___m_ID_1; }
	inline void set_m_ID_1(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  value)
	{
		___m_ID_1 = value;
	}

	inline static int32_t get_offset_of_m_Alignment_2() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___m_Alignment_2)); }
	inline int32_t get_m_Alignment_2() const { return ___m_Alignment_2; }
	inline int32_t* get_address_of_m_Alignment_2() { return &___m_Alignment_2; }
	inline void set_m_Alignment_2(int32_t value)
	{
		___m_Alignment_2 = value;
	}

	inline static int32_t get_offset_of_m_Pose_3() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___m_Pose_3)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_m_Pose_3() const { return ___m_Pose_3; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_m_Pose_3() { return &___m_Pose_3; }
	inline void set_m_Pose_3(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___m_Pose_3 = value;
	}

	inline static int32_t get_offset_of_m_Center_4() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___m_Center_4)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Center_4() const { return ___m_Center_4; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Center_4() { return &___m_Center_4; }
	inline void set_m_Center_4(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Center_4 = value;
	}

	inline static int32_t get_offset_of_m_Extents_5() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___m_Extents_5)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_m_Extents_5() const { return ___m_Extents_5; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_m_Extents_5() { return &___m_Extents_5; }
	inline void set_m_Extents_5(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___m_Extents_5 = value;
	}

	inline static int32_t get_offset_of_vertices_6() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___vertices_6)); }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * get_vertices_6() const { return ___vertices_6; }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 ** get_address_of_vertices_6() { return &___vertices_6; }
	inline void set_vertices_6(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * value)
	{
		___vertices_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___vertices_6), (void*)value);
	}

	inline static int32_t get_offset_of_textureCoordinates_7() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___textureCoordinates_7)); }
	inline List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * get_textureCoordinates_7() const { return ___textureCoordinates_7; }
	inline List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 ** get_address_of_textureCoordinates_7() { return &___textureCoordinates_7; }
	inline void set_textureCoordinates_7(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * value)
	{
		___textureCoordinates_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___textureCoordinates_7), (void*)value);
	}

	inline static int32_t get_offset_of_normals_8() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___normals_8)); }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * get_normals_8() const { return ___normals_8; }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 ** get_address_of_normals_8() { return &___normals_8; }
	inline void set_normals_8(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * value)
	{
		___normals_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___normals_8), (void*)value);
	}

	inline static int32_t get_offset_of_indices_9() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3, ___indices_9)); }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * get_indices_9() const { return ___indices_9; }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 ** get_address_of_indices_9() { return &___indices_9; }
	inline void set_indices_9(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * value)
	{
		___indices_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___indices_9), (void*)value);
	}
};

struct MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_StaticFields
{
public:
	// UnityEngine.Vector3[] Unity.MARS.Data.MRPlane::k_Corners
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___k_Corners_0;

public:
	inline static int32_t get_offset_of_k_Corners_0() { return static_cast<int32_t>(offsetof(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_StaticFields, ___k_Corners_0)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get_k_Corners_0() const { return ___k_Corners_0; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of_k_Corners_0() { return &___k_Corners_0; }
	inline void set_k_Corners_0(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
	{
		___k_Corners_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___k_Corners_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.Data.MRPlane
struct MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_pinvoke
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_ID_1;
	int32_t ___m_Alignment_2;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_3;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Center_4;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_5;
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___vertices_6;
	List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * ___textureCoordinates_7;
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___normals_8;
	List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___indices_9;
};
// Native definition for COM marshalling of Unity.MARS.Data.MRPlane
struct MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_com
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___m_ID_1;
	int32_t ___m_Alignment_2;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___m_Pose_3;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Center_4;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___m_Extents_5;
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___vertices_6;
	List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * ___textureCoordinates_7;
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___normals_8;
	List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___indices_9;
};

// Unity.MARS.Data.MRReferencePoint
struct MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 
{
public:
	// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRReferencePoint::<id>k__BackingField
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___U3CidU3Ek__BackingField_0;
	// UnityEngine.Pose Unity.MARS.Data.MRReferencePoint::<pose>k__BackingField
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___U3CposeU3Ek__BackingField_1;
	// Unity.MARS.Data.MARSTrackingState Unity.MARS.Data.MRReferencePoint::<trackingState>k__BackingField
	int32_t ___U3CtrackingStateU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532, ___U3CidU3Ek__BackingField_0)); }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  get_U3CidU3Ek__BackingField_0() const { return ___U3CidU3Ek__BackingField_0; }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * get_address_of_U3CidU3Ek__BackingField_0() { return &___U3CidU3Ek__BackingField_0; }
	inline void set_U3CidU3Ek__BackingField_0(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  value)
	{
		___U3CidU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CposeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532, ___U3CposeU3Ek__BackingField_1)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_U3CposeU3Ek__BackingField_1() const { return ___U3CposeU3Ek__BackingField_1; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_U3CposeU3Ek__BackingField_1() { return &___U3CposeU3Ek__BackingField_1; }
	inline void set_U3CposeU3Ek__BackingField_1(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___U3CposeU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CtrackingStateU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532, ___U3CtrackingStateU3Ek__BackingField_2)); }
	inline int32_t get_U3CtrackingStateU3Ek__BackingField_2() const { return ___U3CtrackingStateU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CtrackingStateU3Ek__BackingField_2() { return &___U3CtrackingStateU3Ek__BackingField_2; }
	inline void set_U3CtrackingStateU3Ek__BackingField_2(int32_t value)
	{
		___U3CtrackingStateU3Ek__BackingField_2 = value;
	}
};


// Unity.MARS.Data.MarsBody
struct MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 
{
public:
	// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsBody::<id>k__BackingField
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___U3CidU3Ek__BackingField_1;
	// UnityEngine.Pose Unity.MARS.Data.MarsBody::<pose>k__BackingField
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___U3CposeU3Ek__BackingField_2;
	// UnityEngine.HumanPose Unity.MARS.Data.MarsBody::<BodyPose>k__BackingField
	HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  ___U3CBodyPoseU3Ek__BackingField_3;
	// System.Single Unity.MARS.Data.MarsBody::<Height>k__BackingField
	float ___U3CHeightU3Ek__BackingField_4;
	// System.Collections.Generic.List`1<System.Single> Unity.MARS.Data.MarsBody::<BoneLengths>k__BackingField
	List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA * ___U3CBoneLengthsU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5, ___U3CidU3Ek__BackingField_1)); }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  get_U3CidU3Ek__BackingField_1() const { return ___U3CidU3Ek__BackingField_1; }
	inline MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * get_address_of_U3CidU3Ek__BackingField_1() { return &___U3CidU3Ek__BackingField_1; }
	inline void set_U3CidU3Ek__BackingField_1(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  value)
	{
		___U3CidU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CposeU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5, ___U3CposeU3Ek__BackingField_2)); }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  get_U3CposeU3Ek__BackingField_2() const { return ___U3CposeU3Ek__BackingField_2; }
	inline Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A * get_address_of_U3CposeU3Ek__BackingField_2() { return &___U3CposeU3Ek__BackingField_2; }
	inline void set_U3CposeU3Ek__BackingField_2(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  value)
	{
		___U3CposeU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CBodyPoseU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5, ___U3CBodyPoseU3Ek__BackingField_3)); }
	inline HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  get_U3CBodyPoseU3Ek__BackingField_3() const { return ___U3CBodyPoseU3Ek__BackingField_3; }
	inline HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F * get_address_of_U3CBodyPoseU3Ek__BackingField_3() { return &___U3CBodyPoseU3Ek__BackingField_3; }
	inline void set_U3CBodyPoseU3Ek__BackingField_3(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  value)
	{
		___U3CBodyPoseU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier((void**)&(((&___U3CBodyPoseU3Ek__BackingField_3))->___muscles_2), (void*)NULL);
	}

	inline static int32_t get_offset_of_U3CHeightU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5, ___U3CHeightU3Ek__BackingField_4)); }
	inline float get_U3CHeightU3Ek__BackingField_4() const { return ___U3CHeightU3Ek__BackingField_4; }
	inline float* get_address_of_U3CHeightU3Ek__BackingField_4() { return &___U3CHeightU3Ek__BackingField_4; }
	inline void set_U3CHeightU3Ek__BackingField_4(float value)
	{
		___U3CHeightU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CBoneLengthsU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5, ___U3CBoneLengthsU3Ek__BackingField_5)); }
	inline List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA * get_U3CBoneLengthsU3Ek__BackingField_5() const { return ___U3CBoneLengthsU3Ek__BackingField_5; }
	inline List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA ** get_address_of_U3CBoneLengthsU3Ek__BackingField_5() { return &___U3CBoneLengthsU3Ek__BackingField_5; }
	inline void set_U3CBoneLengthsU3Ek__BackingField_5(List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA * value)
	{
		___U3CBoneLengthsU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CBoneLengthsU3Ek__BackingField_5), (void*)value);
	}
};

struct MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_StaticFields
{
public:
	// System.Single Unity.MARS.Data.MarsBody::BodyDefaultHeight
	float ___BodyDefaultHeight_0;

public:
	inline static int32_t get_offset_of_BodyDefaultHeight_0() { return static_cast<int32_t>(offsetof(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_StaticFields, ___BodyDefaultHeight_0)); }
	inline float get_BodyDefaultHeight_0() const { return ___BodyDefaultHeight_0; }
	inline float* get_address_of_BodyDefaultHeight_0() { return &___BodyDefaultHeight_0; }
	inline void set_BodyDefaultHeight_0(float value)
	{
		___BodyDefaultHeight_0 = value;
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.Data.MarsBody
struct MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_pinvoke
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___U3CidU3Ek__BackingField_1;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___U3CposeU3Ek__BackingField_2;
	HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke ___U3CBodyPoseU3Ek__BackingField_3;
	float ___U3CHeightU3Ek__BackingField_4;
	List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA * ___U3CBoneLengthsU3Ek__BackingField_5;
};
// Native definition for COM marshalling of Unity.MARS.Data.MarsBody
struct MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_com
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___U3CidU3Ek__BackingField_1;
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___U3CposeU3Ek__BackingField_2;
	HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com ___U3CBodyPoseU3Ek__BackingField_3;
	float ___U3CHeightU3Ek__BackingField_4;
	List_1_t6726F9309570A0BDC5D42E10777F3E2931C487AA * ___U3CBoneLengthsU3Ek__BackingField_5;
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

// Unity.MARS.Data.PointCloudData
struct PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8 
{
public:
	// System.Nullable`1<Unity.Collections.NativeSlice`1<System.UInt64>> Unity.MARS.Data.PointCloudData::Identifiers
	Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81  ___Identifiers_0;
	// System.Nullable`1<Unity.Collections.NativeSlice`1<UnityEngine.Vector3>> Unity.MARS.Data.PointCloudData::Positions
	Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274  ___Positions_1;
	// System.Nullable`1<Unity.Collections.NativeSlice`1<System.Single>> Unity.MARS.Data.PointCloudData::ConfidenceValues
	Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8  ___ConfidenceValues_2;

public:
	inline static int32_t get_offset_of_Identifiers_0() { return static_cast<int32_t>(offsetof(PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8, ___Identifiers_0)); }
	inline Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81  get_Identifiers_0() const { return ___Identifiers_0; }
	inline Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81 * get_address_of_Identifiers_0() { return &___Identifiers_0; }
	inline void set_Identifiers_0(Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81  value)
	{
		___Identifiers_0 = value;
	}

	inline static int32_t get_offset_of_Positions_1() { return static_cast<int32_t>(offsetof(PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8, ___Positions_1)); }
	inline Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274  get_Positions_1() const { return ___Positions_1; }
	inline Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274 * get_address_of_Positions_1() { return &___Positions_1; }
	inline void set_Positions_1(Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274  value)
	{
		___Positions_1 = value;
	}

	inline static int32_t get_offset_of_ConfidenceValues_2() { return static_cast<int32_t>(offsetof(PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8, ___ConfidenceValues_2)); }
	inline Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8  get_ConfidenceValues_2() const { return ___ConfidenceValues_2; }
	inline Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8 * get_address_of_ConfidenceValues_2() { return &___ConfidenceValues_2; }
	inline void set_ConfidenceValues_2(Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8  value)
	{
		___ConfidenceValues_2 = value;
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.Data.PointCloudData
struct PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_pinvoke
{
	Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81  ___Identifiers_0;
	Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274  ___Positions_1;
	Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8  ___ConfidenceValues_2;
};
// Native definition for COM marshalling of Unity.MARS.Data.PointCloudData
struct PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_com
{
	Nullable_1_t714D8B44F27437E235E6C20BC1B8A7C4480EDB81  ___Identifiers_0;
	Nullable_1_t2BF361C15F9704B243C4C57C2B9F807E5BBAF274  ___Positions_1;
	Nullable_1_t4332FD535BDC6602E089BAB7E9E78092B32136F8  ___ConfidenceValues_2;
};

// System.SystemException
struct SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62  : public Exception_t
{
public:

public:
};


// UnityEngine.Texture
struct Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};

struct Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE_StaticFields
{
public:
	// System.Int32 UnityEngine.Texture::GenerateAllMips
	int32_t ___GenerateAllMips_4;

public:
	inline static int32_t get_offset_of_GenerateAllMips_4() { return static_cast<int32_t>(offsetof(Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE_StaticFields, ___GenerateAllMips_4)); }
	inline int32_t get_GenerateAllMips_4() const { return ___GenerateAllMips_4; }
	inline int32_t* get_address_of_GenerateAllMips_4() { return &___GenerateAllMips_4; }
	inline void set_GenerateAllMips_4(int32_t value)
	{
		___GenerateAllMips_4 = value;
	}
};


// System.Type
struct Type_t  : public MemberInfo_t
{
public:
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  ____impl_9;

public:
	inline static int32_t get_offset_of__impl_9() { return static_cast<int32_t>(offsetof(Type_t, ____impl_9)); }
	inline RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  get__impl_9() const { return ____impl_9; }
	inline RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9 * get_address_of__impl_9() { return &____impl_9; }
	inline void set__impl_9(RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  value)
	{
		____impl_9 = value;
	}
};

struct Type_t_StaticFields
{
public:
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * ___FilterAttribute_0;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * ___FilterName_1;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * ___FilterNameIgnoreCase_2;
	// System.Object System.Type::Missing
	RuntimeObject * ___Missing_3;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_4;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ___EmptyTypes_5;
	// System.Reflection.Binder System.Type::defaultBinder
	Binder_t2BEE27FD84737D1E79BC47FD67F6D3DD2F2DDA30 * ___defaultBinder_6;

public:
	inline static int32_t get_offset_of_FilterAttribute_0() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterAttribute_0)); }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * get_FilterAttribute_0() const { return ___FilterAttribute_0; }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 ** get_address_of_FilterAttribute_0() { return &___FilterAttribute_0; }
	inline void set_FilterAttribute_0(MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * value)
	{
		___FilterAttribute_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterAttribute_0), (void*)value);
	}

	inline static int32_t get_offset_of_FilterName_1() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterName_1)); }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * get_FilterName_1() const { return ___FilterName_1; }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 ** get_address_of_FilterName_1() { return &___FilterName_1; }
	inline void set_FilterName_1(MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * value)
	{
		___FilterName_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterName_1), (void*)value);
	}

	inline static int32_t get_offset_of_FilterNameIgnoreCase_2() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterNameIgnoreCase_2)); }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * get_FilterNameIgnoreCase_2() const { return ___FilterNameIgnoreCase_2; }
	inline MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 ** get_address_of_FilterNameIgnoreCase_2() { return &___FilterNameIgnoreCase_2; }
	inline void set_FilterNameIgnoreCase_2(MemberFilter_t48D0AA10105D186AF42428FA532D4B4332CF8B81 * value)
	{
		___FilterNameIgnoreCase_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterNameIgnoreCase_2), (void*)value);
	}

	inline static int32_t get_offset_of_Missing_3() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Missing_3)); }
	inline RuntimeObject * get_Missing_3() const { return ___Missing_3; }
	inline RuntimeObject ** get_address_of_Missing_3() { return &___Missing_3; }
	inline void set_Missing_3(RuntimeObject * value)
	{
		___Missing_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Missing_3), (void*)value);
	}

	inline static int32_t get_offset_of_Delimiter_4() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Delimiter_4)); }
	inline Il2CppChar get_Delimiter_4() const { return ___Delimiter_4; }
	inline Il2CppChar* get_address_of_Delimiter_4() { return &___Delimiter_4; }
	inline void set_Delimiter_4(Il2CppChar value)
	{
		___Delimiter_4 = value;
	}

	inline static int32_t get_offset_of_EmptyTypes_5() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___EmptyTypes_5)); }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* get_EmptyTypes_5() const { return ___EmptyTypes_5; }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755** get_address_of_EmptyTypes_5() { return &___EmptyTypes_5; }
	inline void set_EmptyTypes_5(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* value)
	{
		___EmptyTypes_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___EmptyTypes_5), (void*)value);
	}

	inline static int32_t get_offset_of_defaultBinder_6() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___defaultBinder_6)); }
	inline Binder_t2BEE27FD84737D1E79BC47FD67F6D3DD2F2DDA30 * get_defaultBinder_6() const { return ___defaultBinder_6; }
	inline Binder_t2BEE27FD84737D1E79BC47FD67F6D3DD2F2DDA30 ** get_address_of_defaultBinder_6() { return &___defaultBinder_6; }
	inline void set_defaultBinder_6(Binder_t2BEE27FD84737D1E79BC47FD67F6D3DD2F2DDA30 * value)
	{
		___defaultBinder_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___defaultBinder_6), (void*)value);
	}
};


// System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>>
struct Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>
struct Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.Data.IMRFace>
struct Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.Data.MRCameraTrackingState>
struct Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.Data.MRLightEstimation>
struct Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.Data.MRMarker>
struct Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<Unity.MARS.Data.MRPlane>
struct Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<UnityEngine.Pose>
struct Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<System.Single>
struct Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9  : public MulticastDelegate_t
{
public:

public:
};


// System.Action`1<UnityEngine.Texture>
struct Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0  : public MulticastDelegate_t
{
public:

public:
};


// System.Func`1<System.Boolean>
struct Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F  : public MulticastDelegate_t
{
public:

public:
};


// System.Func`1<System.Single>
struct Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740  : public MulticastDelegate_t
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


// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA  : public MulticastDelegate_t
{
public:

public:
};


// Unity.MARS.Data.LoadTextureCallback
struct LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8  : public MulticastDelegate_t
{
public:

public:
};


// Unity.MARS.Data.ProgressCallback
struct ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3  : public MulticastDelegate_t
{
public:

public:
};


// System.Reflection.ReflectionTypeLoadException
struct ReflectionTypeLoadException_tF7B3556875F394EC77B674893C9322FA1DC21F6C  : public SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62
{
public:
	// System.Type[] System.Reflection.ReflectionTypeLoadException::_classes
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ____classes_17;
	// System.Exception[] System.Reflection.ReflectionTypeLoadException::_exceptions
	ExceptionU5BU5D_t683CE8E24950657A060E640B8956913D867F952D* ____exceptions_18;

public:
	inline static int32_t get_offset_of__classes_17() { return static_cast<int32_t>(offsetof(ReflectionTypeLoadException_tF7B3556875F394EC77B674893C9322FA1DC21F6C, ____classes_17)); }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* get__classes_17() const { return ____classes_17; }
	inline TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755** get_address_of__classes_17() { return &____classes_17; }
	inline void set__classes_17(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* value)
	{
		____classes_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____classes_17), (void*)value);
	}

	inline static int32_t get_offset_of__exceptions_18() { return static_cast<int32_t>(offsetof(ReflectionTypeLoadException_tF7B3556875F394EC77B674893C9322FA1DC21F6C, ____exceptions_18)); }
	inline ExceptionU5BU5D_t683CE8E24950657A060E640B8956913D867F952D* get__exceptions_18() const { return ____exceptions_18; }
	inline ExceptionU5BU5D_t683CE8E24950657A060E640B8956913D867F952D** get_address_of__exceptions_18() { return &____exceptions_18; }
	inline void set__exceptions_18(ExceptionU5BU5D_t683CE8E24950657A060E640B8956913D867F952D* value)
	{
		____exceptions_18 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____exceptions_18), (void*)value);
	}
};


// UnityEngine.Texture2D
struct Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF  : public Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE
{
public:

public:
};


// Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate
struct TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Type[]
struct TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Type_t * m_Items[1];

public:
	inline Type_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Type_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Type_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Type_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Type_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Type_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Byte[]
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Delegate_t * m_Items[1];

public:
	inline Delegate_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  m_Items[1];

public:
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		m_Items[index] = value;
	}
};
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject * m_Items[1];

public:
	inline RuntimeObject * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Reflection.Assembly[]
struct AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Assembly_t * m_Items[1];

public:
	inline Assembly_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Assembly_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Assembly_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Assembly_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Assembly_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Assembly_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};

IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_pinvoke(const HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F& unmarshaled, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_pinvoke_back(const HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke& marshaled, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F& unmarshaled);
IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_pinvoke_cleanup(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_com(const HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F& unmarshaled, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com& marshaled);
IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_com_back(const HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com& marshaled, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F& unmarshaled);
IL2CPP_EXTERN_C void HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshal_com_cleanup(HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F_marshaled_com& marshaled);

// !0 System.Func`1<System.Single>::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36_gshared (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * __this, const RuntimeMethod* method);
// System.Void System.Action`1<System.Single>::Invoke(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E_gshared (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * __this, float ___obj0, const RuntimeMethod* method);
// System.Void System.Func`1<System.Single>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_gshared (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Action`1<System.Single>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_gshared (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);

// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1 (Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.GeographicCoordinate::.ctor(System.Double,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GeographicCoordinate__ctor_m924ED2E8DDC5B79D21863D94373D77476767D5EE (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * __this, double ___latitude0, double ___longitude1, const RuntimeMethod* method);
// System.String System.String::Format(System.String,System.Object,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_m8D1CB0410C35E052A53AE957C914C841E54BAB66 (String_t* ___format0, RuntimeObject * ___arg01, RuntimeObject * ___arg12, const RuntimeMethod* method);
// System.String Unity.MARS.Data.GeographicCoordinate::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GeographicCoordinate_ToString_mC31F5BDA6B51CB7546C97A3262BE00FF7319F54F (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * __this, float ___x0, float ___y1, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRHitTestResult::set_pose(UnityEngine.Pose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRHitTestResult_set_pose_m8D1F054849B3E056745B3D51905600A0EB03B09F_inline (MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRMarker::get_id()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_id_mA90B2B6E2EA4D9124A06B2FDDFD785B334ACE211_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method);
// UnityEngine.Pose Unity.MARS.Data.MRMarker::get_pose()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRMarker_get_pose_m26B01BBC6BC33C554B37D95E3F547934B31F3724_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_pose(UnityEngine.Pose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_pose_m214334D9B1F67D0788C9CB495CC7A0FAB68A2EDE_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method);
// System.Guid Unity.MARS.Data.MRMarker::get_markerId()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Guid_t  MRMarker_get_markerId_mD511F48B85309DC3647C2523C662BF2F6A7EF0DF_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_markerId(System.Guid)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_markerId_m754B1B5039AEA750907A5FC75F1A97CB62CA1C92_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Guid_t  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector2 Unity.MARS.Data.MRMarker::get_extents()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRMarker_get_extents_m53EE2D20BE320174FF59B0F2A63269BC68F8102E_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_extents(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_extents_m8B9997FA7962B7231D8E3D6B9F97F4B7D7C8E12B_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method);
// Unity.MARS.Data.MARSTrackingState Unity.MARS.Data.MRMarker::get_trackingState()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MRMarker_get_trackingState_m31D5F6EF768A2D155BEFA7A19B37F4FBFB5FF95C_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_trackingState(Unity.MARS.Data.MARSTrackingState)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_trackingState_m6E5022AD0ED0483B1CCB1D828CAFBB6AAA6BD440_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRMarker::set_texture(UnityEngine.Texture2D)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_texture_m3671418D4EA8029AD01065A79661D2218D0F7358_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___value0, const RuntimeMethod* method);
// System.String System.String::Format(System.String,System.Object,System.Object,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_m039737CCD992C5BFC8D16DFD681F5E8786E87FA6 (String_t* ___format0, RuntimeObject * ___arg01, RuntimeObject * ___arg12, RuntimeObject * ___arg23, const RuntimeMethod* method);
// System.String Unity.MARS.Data.MRMarker::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MRMarker_ToString_m2D58F681A47C4D32440789CED74EE89E75A65AE4 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Int32 Unity.MARS.Data.MarsTrackableId::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, const RuntimeMethod* method);
// System.Int32 Unity.MARS.Data.MRMarker::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRMarker_GetHashCode_m7DF1629A7871B5E462B4387FC547755AA8D956DF (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.MarsTrackableId::Equals(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___other0, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.MRMarker::Equals(Unity.MARS.Data.MRMarker)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRMarker_Equals_mFA4D7A0359EE8D763B9FE443DE29C9C0142EA61C (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50  ___other0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRPlane::get_id()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRPlane_get_id_m3C58E67BF29B34E32E8A66A7669D1C5C0AB92B92_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRPlane::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_id_mB85378E0E640B7009C4B8A86C758BC7918770F6C_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsPlaneAlignment Unity.MARS.Data.MRPlane::get_alignment()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MRPlane_get_alignment_m155185C0BE923248835076D5F312EAB8C76D81B8_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRPlane::set_alignment(Unity.MARS.Data.MarsPlaneAlignment)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_alignment_m2F2D8AB55C5DFC3AFEF4082CB31EE103713A8C52_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, int32_t ___value0, const RuntimeMethod* method);
// UnityEngine.Pose Unity.MARS.Data.MRPlane::get_pose()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRPlane_get_pose_mE4641C58EB01F74D8D891840A3E704D8D3CEFAFE_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRPlane::set_pose(UnityEngine.Pose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_pose_mF67BA811CD0D167A8DB12E029AE60A029194C6B3_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.Data.MRPlane::get_center()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MRPlane_get_center_m6E11618D22CBC5698A010738EE249CF07B6DF3CE_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRPlane::set_center(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_center_m85121C2B0A14F5FD5951D004CB954644C3DAF5EC_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector2 Unity.MARS.Data.MRPlane::get_extents()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRPlane_get_extents_m63073D5F8D09129CE9D725E218EFA9E64C698D6D_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRPlane::set_extents(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_extents_m1DDF0F993D964BD0BDC7E0C26DF0347FF7B3C058_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method);
// System.String Unity.MARS.Data.MRPlane::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MRPlane_ToString_mEE867487721748B430A76743B47F76063E50F57C (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Int32 Unity.MARS.Data.MRPlane::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRPlane_GetHashCode_m937B78D26A641E8103F7F9CC5042E946050C5ADC (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.MRPlane::Equals(Unity.MARS.Data.MRPlane)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRPlane_Equals_mC3884EF3958E5630E373262D2EC7F9FBDE26C1B1 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3  ___other0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRReferencePoint::get_id()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRReferencePoint::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method);
// UnityEngine.Pose Unity.MARS.Data.MRReferencePoint::get_pose()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRReferencePoint_get_pose_m7548092EC3F676CDD7FAD085B06FE4978BA326FE_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRReferencePoint::set_pose(UnityEngine.Pose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRReferencePoint::set_trackingState(Unity.MARS.Data.MARSTrackingState)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, int32_t ___value0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsTrackableId::Create()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsTrackableId_Create_m1AB7F8E860A28EC0D0172BDD08990815546CB637 (const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MRReferencePoint::.ctor(UnityEngine.Pose,Unity.MARS.Data.MARSTrackingState)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRReferencePoint__ctor_m9A9913D983FE24B9733BBA1D8080683AC225923E (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___pose0, int32_t ___state1, const RuntimeMethod* method);
// System.Int32 Unity.MARS.Data.MRReferencePoint::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRReferencePoint_GetHashCode_m7B4AAA44F01A3F351ED6C61AF452431BCC9F5127 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.MRReferencePoint::Equals(Unity.MARS.Data.MRReferencePoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRReferencePoint_Equals_m8C6CC41619AA36A2BA0B19912720F4C6C20B4561 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532  ___other0, const RuntimeMethod* method);
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsBody::get_id()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsBody_get_id_m25C153F5E5D66D255DF989B64D7B6192BE9E629D_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MarsBody::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_id_m909CFE33F3D1DC3505310B71A63E64CE8A2FDCAC_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method);
// UnityEngine.Pose Unity.MARS.Data.MarsBody::get_pose()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MarsBody_get_pose_m24FD3A349D2EB7D56C6C596DB17C2706DF655B1E_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MarsBody::set_pose(UnityEngine.Pose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_pose_mF77B965C8146F5CB58A315B4B43525162C2114F4_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method);
// UnityEngine.HumanPose Unity.MARS.Data.MarsBody::get_BodyPose()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  MarsBody_get_BodyPose_m872C60DB6506A83284C2E515AA3136866C7789CA_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MarsBody::set_BodyPose(UnityEngine.HumanPose)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_BodyPose_mBC26E9630954F96ACDD3DEA78C71ABE619F21593_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.Data.MarsBody::get_Height()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float MarsBody_get_Height_m023FF0CA8628FCAB3790366F71753C534075D565_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MarsBody::set_Height(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_Height_mEB8A9CA1F4DF0E81E605605FE0B96BC41C3DB323_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, float ___value0, const RuntimeMethod* method);
// !0 System.Func`1<System.Single>::Invoke()
inline float Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36 (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * __this, const RuntimeMethod* method)
{
	return ((  float (*) (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 *, const RuntimeMethod*))Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36_gshared)(__this, method);
}
// System.Void System.Action`1<System.Single>::Invoke(!0)
inline void Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * __this, float ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *, float, const RuntimeMethod*))Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E_gshared)(__this, ___obj0, method);
}
// System.Single UnityEngine.Time::get_deltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_deltaTime_mCC15F147DA67F38C74CE408FB5D7FF4A87DA2290 (const RuntimeMethod* method);
// System.Single Unity.MARS.Simulation.MarsTime::get_TimeScale()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTime_get_TimeScale_m78430947F9BE9624D3068647C105B50465909CEB (const RuntimeMethod* method);
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55 (Delegate_t * ___a0, Delegate_t * ___b1, const RuntimeMethod* method);
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4 (Delegate_t * ___source0, Delegate_t * ___value1, const RuntimeMethod* method);
// System.Void System.Action::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * __this, const RuntimeMethod* method);
// System.Void System.Func`1<System.Single>::.ctor(System.Object,System.IntPtr)
inline void Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7 (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_gshared)(__this, ___object0, ___method1, method);
}
// System.Void System.Action`1<System.Single>::.ctor(System.Object,System.IntPtr)
inline void Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3 (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_gshared)(__this, ___object0, ___method1, method);
}
// System.Void System.Action::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action__ctor_m07BE5EE8A629FBBA52AE6356D57A0D371BE2574B (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * CultureInfo_get_InvariantCulture_m9FAAFAF8A00091EE1FCB7098AD3F163ECDF02164 (const RuntimeMethod* method);
// System.String System.UInt64::ToString(System.String,System.IFormatProvider)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UInt64_ToString_mD0F3D7511719711F9E78F0EBC578FFE6C05320B5 (uint64_t* __this, String_t* ___format0, RuntimeObject* ___provider1, const RuntimeMethod* method);
// System.String Unity.MARS.Data.MarsTrackableId::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MarsTrackableId_ToString_m0FA72ACB28488E82AB45B3C5FDF32F30BBDBC806 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, const RuntimeMethod* method);
// System.Int32 System.UInt64::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UInt64_GetHashCode_mCDF662897A3F02CED11A9F9E66C5BF4E28C02B33 (uint64_t* __this, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.MarsTrackableId::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_Equals_mC77854B7AE17150C6C41722ABDF39A2DC758644B (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, RuntimeObject * ___obj0, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.MarsTrackableId::.ctor(System.UInt64,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTrackableId__ctor_m3C2FA6CC39FD7DE59BB4527ADC110B24C571E09F (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, uint64_t ___idOne0, uint64_t ___idTwo1, const RuntimeMethod* method);
// System.String Unity.MARS.Query.TraitRequirement::get_TraitName()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* TraitRequirement_get_TraitName_mFDCD39504376698867BFBC05E66DCB08CB5855B2 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method);
// System.Type Unity.MARS.Query.TraitRequirement::get_Type()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t * TraitRequirement_get_Type_m1EFEB92F45AA34D34B8BF34E3706EFDE64571186 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method);
// System.String Unity.MARS.Data.SerializedTraitRequirement::get_TraitName()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method);
// System.Boolean System.String::Equals(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_Equals_mAFC6038D294F341434D9D67D7EADC7F97C556C9B (String_t* ___a0, String_t* ___b1, const RuntimeMethod* method);
// System.String Unity.MARS.Data.SerializedTraitRequirement::get_TypeName()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String,System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m37A5BF26F8F8F1892D60D727303B23FB604FEE78 (String_t* ___str00, String_t* ___str11, String_t* ___str22, String_t* ___str33, const RuntimeMethod* method);
// System.Boolean System.Type::op_Equality(System.Type,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_op_Equality_mA438719A1FDF103C7BBBB08AEF564E7FAEEA0046 (Type_t * ___left0, Type_t * ___right1, const RuntimeMethod* method);
// System.Boolean System.String::op_Equality(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_op_Equality_m2B91EE68355F142F67095973D32EB5828B7B73CB (String_t* ___a0, String_t* ___b1, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m89EAB4C6A96B0E5C3F87300D6BE78D386B9EFC44 (String_t* ___str00, String_t* ___str11, String_t* ___str22, const RuntimeMethod* method);
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t * Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E (RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  ___handle0, const RuntimeMethod* method);
// System.Void Unity.MARS.Data.TraitDefinition::.ctor(System.String,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, String_t* ___traitName0, Type_t * ___type1, const RuntimeMethod* method);
// System.Void Unity.MARS.Query.TraitRequirement::.ctor(Unity.MARS.Data.TraitDefinition,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitRequirement__ctor_mF1A4A6EF09660064D70F0A71E13EAB0B7C1CF19A (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___definition0, bool ___required1, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.SerializedTraitRequirement::get_Required()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogErrorFormat(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogErrorFormat_mDBF43684A22EAAB187285C9B4174C9555DB11E83 (String_t* ___format0, ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ___args1, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogWarningFormat(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogWarningFormat_m405E9C0A631F815816F349D7591DD545932FF774 (String_t* ___format0, ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ___args1, const RuntimeMethod* method);
// System.Void Unity.MARS.Query.TraitRequirement::.ctor(System.String,System.Type,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitRequirement__ctor_mE68E74A8E4A7B8CF1D8D483616C1028C779F4391 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, String_t* ___traitName0, Type_t * ___type1, bool ___required2, const RuntimeMethod* method);
// System.Boolean Unity.MARS.Data.TraitDefinition::Equals(Unity.MARS.Data.TraitDefinition)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TraitDefinition_Equals_mF0D8ADEB9230BC3BCDDDB26A6A33CA13D0B687C1 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___other0, const RuntimeMethod* method);
// System.Int32 System.Boolean::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Boolean_GetHashCode_m03AF8B3CECAE9106C44A00E3B33E51CBFC45C411 (bool* __this, const RuntimeMethod* method);
// System.Boolean System.Type::get_IsInterface()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_get_IsInterface_mB10C34DEE8B22E1597C813211BBED17DD724FC07 (Type_t * __this, const RuntimeMethod* method);
// System.AppDomain System.AppDomain::get_CurrentDomain()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * AppDomain_get_CurrentDomain_mC2FE307811914289CBBDEFEFF6175FCE2E96A55E (const RuntimeMethod* method);
// System.Reflection.Assembly[] System.AppDomain::GetAssemblies()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0* AppDomain_GetAssemblies_m7397BD0461B4D6BA76AE0974DE9FBEDAF70AEBFD (AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * __this, const RuntimeMethod* method);
// System.Boolean System.Type::get_IsAbstract()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_get_IsAbstract_mB16DB56FCABF55740019D32C5286F38E30CAA19F (Type_t * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Type>::Add(!0)
inline void List_1_Add_m56E267FE82DC48AD1690E87B576550B72754E89D (List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7 * __this, Type_t * ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7 *, Type_t *, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
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
// System.Void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EmbeddedAttribute__ctor_m92C1AB83F356632B094A3ABB945BC7E58712C873 (EmbeddedAttribute_tCE2EB28A2C6ACAF004AAD9F4EBA0C30215FAA9C0 * __this, const RuntimeMethod* method)
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
// System.Void Unity.MARS.Attributes.EventAttribute::.ctor(System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EventAttribute__ctor_mF795F2AB6787A0E2995F36B5CF5AC8C25A802A64 (EventAttribute_tA8847D809F5707CBB7A7609E76F8FD6D69400F71 * __this, Type_t * ___type0, const RuntimeMethod* method)
{
	{
		// public EventAttribute(Type type)
		Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1(__this, /*hidden argument*/NULL);
		// this.type = type;
		Type_t * L_0 = ___type0;
		__this->set_type_0(L_0);
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
// System.Void Unity.MARS.Data.GeographicCoordinate::.ctor(System.Double,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GeographicCoordinate__ctor_m924ED2E8DDC5B79D21863D94373D77476767D5EE (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * __this, double ___latitude0, double ___longitude1, const RuntimeMethod* method)
{
	{
		// this.latitude = latitude;
		double L_0 = ___latitude0;
		__this->set_latitude_1(L_0);
		// this.longitude = longitude;
		double L_1 = ___longitude1;
		__this->set_longitude_2(L_1);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void GeographicCoordinate__ctor_m924ED2E8DDC5B79D21863D94373D77476767D5EE_AdjustorThunk (RuntimeObject * __this, double ___latitude0, double ___longitude1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * _thisAdjusted = reinterpret_cast<GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *>(__this + _offset);
	GeographicCoordinate__ctor_m924ED2E8DDC5B79D21863D94373D77476767D5EE(_thisAdjusted, ___latitude0, ___longitude1, method);
}
// System.String Unity.MARS.Data.GeographicCoordinate::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GeographicCoordinate_ToString_mC31F5BDA6B51CB7546C97A3262BE00FF7319F54F (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBACF4D71F8EBDA0C65915B206AFF3133754C7577);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return String.Format("latitude: {0} , longitude: {1}", latitude, longitude);
		double L_0 = __this->get_latitude_1();
		double L_1 = L_0;
		RuntimeObject * L_2 = Box(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var, &L_1);
		double L_3 = __this->get_longitude_2();
		double L_4 = L_3;
		RuntimeObject * L_5 = Box(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var, &L_4);
		String_t* L_6;
		L_6 = String_Format_m8D1CB0410C35E052A53AE957C914C841E54BAB66(_stringLiteralBACF4D71F8EBDA0C65915B206AFF3133754C7577, L_2, L_5, /*hidden argument*/NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C  String_t* GeographicCoordinate_ToString_mC31F5BDA6B51CB7546C97A3262BE00FF7319F54F_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * _thisAdjusted = reinterpret_cast<GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = GeographicCoordinate_ToString_mC31F5BDA6B51CB7546C97A3262BE00FF7319F54F(_thisAdjusted, method);
	return _returnValue;
}
// UnityEngine.Vector2 Unity.MARS.Data.GeographicCoordinate::op_Implicit(Unity.MARS.Data.GeographicCoordinate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  GeographicCoordinate_op_Implicit_mE984DC786686A05AA988A62BF175126BF23CBE89 (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  ___coordinate0, const RuntimeMethod* method)
{
	{
		// return new Vector2((float)coordinate.latitude, (float)coordinate.longitude);
		GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  L_0 = ___coordinate0;
		double L_1 = L_0.get_latitude_1();
		GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  L_2 = ___coordinate0;
		double L_3 = L_2.get_longitude_2();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_4), ((float)((float)L_1)), ((float)((float)L_3)), /*hidden argument*/NULL);
		return L_4;
	}
}
// Unity.MARS.Data.GeographicCoordinate Unity.MARS.Data.GeographicCoordinate::op_Implicit(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  GeographicCoordinate_op_Implicit_mB96FE67041EB1C9196DB0C544B6CAD73435CA1EE (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___vec0, const RuntimeMethod* method)
{
	{
		// return new GeographicCoordinate(vec.x, vec.y);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___vec0;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___vec0;
		float L_3 = L_2.get_y_1();
		GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1  L_4;
		memset((&L_4), 0, sizeof(L_4));
		GeographicCoordinate__ctor_m924ED2E8DDC5B79D21863D94373D77476767D5EE((&L_4), ((double)((double)L_1)), ((double)((double)L_3)), /*hidden argument*/NULL);
		return L_4;
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Nullable`1<System.Single> Unity.MARS.Providers.IUsesCameraIntrinsicsMethods::GetFieldOfView(Unity.MARS.Providers.IUsesCameraIntrinsics)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  IUsesCameraIntrinsicsMethods_GetFieldOfView_m9F956FA98E81A0EC5B3A212F079B2B058409F9A2 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.GetFieldOfView();
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraIntrinsics>::get_provider() */, IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  L_2;
		L_2 = InterfaceFuncInvoker0< Nullable_1_t0C4AC2E457C437FA106160547FD9BA5B50B1888A  >::Invoke(0 /* System.Nullable`1<System.Single> Unity.MARS.Providers.IProvidesCameraIntrinsics::GetFieldOfView() */, IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraIntrinsicsMethods::SubscribeFieldOfViewUpdated(Unity.MARS.Providers.IUsesCameraIntrinsics,System.Action`1<System.Single>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraIntrinsicsMethods_SubscribeFieldOfViewUpdated_m55DF1E4D34134CCB32D0782C6AB18BA123C06B1E (RuntimeObject* ___obj0, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___fieldOfViewUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FieldOfViewUpdated += fieldOfViewUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraIntrinsics>::get_provider() */, IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var, L_0);
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_2 = ___fieldOfViewUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesCameraIntrinsics::add_FieldOfViewUpdated(System.Action`1<System.Single>) */, IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraIntrinsicsMethods::UnsubscribeFieldOfViewUpdated(Unity.MARS.Providers.IUsesCameraIntrinsics,System.Action`1<System.Single>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraIntrinsicsMethods_UnsubscribeFieldOfViewUpdated_m9E108DAD401DB9882308427CF2CDBC37B6FE8815 (RuntimeObject* ___obj0, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___fieldOfViewUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FieldOfViewUpdated -= fieldOfViewUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraIntrinsics>::get_provider() */, IFunctionalitySubscriber_1_tE9A3A089CA6FC3B6CAF6C092899BF8D74528299A_il2cpp_TypeInfo_var, L_0);
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_2 = ___fieldOfViewUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * >::Invoke(2 /* System.Void Unity.MARS.Providers.IProvidesCameraIntrinsics::remove_FieldOfViewUpdated(System.Action`1<System.Single>) */, IProvidesCameraIntrinsics_t76542BCD972029A9AD2766E9497323A1A48B634E_il2cpp_TypeInfo_var, L_1, L_2);
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
// UnityEngine.Vector3 Unity.MARS.Providers.IUsesCameraOffsetMethods::GetCameraPositionOffset(Unity.MARS.Providers.IUsesCameraOffset)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  IUsesCameraOffsetMethods_GetCameraPositionOffset_m94737E3BEF389E6A3382C8B1C526BBFC642BC9FF (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.cameraPositionOffset;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = InterfaceFuncInvoker0< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(0 /* UnityEngine.Vector3 Unity.MARS.Providers.IProvidesCameraOffset::get_cameraPositionOffset() */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Single Unity.MARS.Providers.IUsesCameraOffsetMethods::GetCameraYawOffset(Unity.MARS.Providers.IUsesCameraOffset)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float IUsesCameraOffsetMethods_GetCameraYawOffset_m5C67E4456533509950604092F9B3ACAD2506E67B (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.cameraYawOffset;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		float L_2;
		L_2 = InterfaceFuncInvoker0< float >::Invoke(1 /* System.Single Unity.MARS.Providers.IProvidesCameraOffset::get_cameraYawOffset() */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Single Unity.MARS.Providers.IUsesCameraOffsetMethods::GetCameraScale(Unity.MARS.Providers.IUsesCameraOffset)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float IUsesCameraOffsetMethods_GetCameraScale_m8CA5E55DDC2292806328C372A593F948178192EC (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.cameraScale;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		float L_2;
		L_2 = InterfaceFuncInvoker0< float >::Invoke(2 /* System.Single Unity.MARS.Providers.IProvidesCameraOffset::get_cameraScale() */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraOffsetMethods::SetCameraScale(Unity.MARS.Providers.IUsesCameraOffset,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraOffsetMethods_SetCameraScale_m5278D11B81EEF18FA43E7BFB513D7EDE388F549D (RuntimeObject* ___obj0, float ___scale1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.cameraScale = scale;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		float L_2 = ___scale1;
		NullCheck(L_1);
		InterfaceActionInvoker1< float >::Invoke(3 /* System.Void Unity.MARS.Providers.IProvidesCameraOffset::set_cameraScale(System.Single) */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// UnityEngine.Pose Unity.MARS.Providers.IUsesCameraOffsetMethods::ApplyOffsetToPose(Unity.MARS.Providers.IUsesCameraOffset,UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  IUsesCameraOffsetMethods_ApplyOffsetToPose_mB35FB96F35D57A3557E353F280D6AB7FF214C9A8 (RuntimeObject* ___obj0, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___pose1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.ApplyOffsetToPose(pose);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_2 = ___pose1;
		NullCheck(L_1);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_3;
		L_3 = InterfaceFuncInvoker1< Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A , Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  >::Invoke(5 /* UnityEngine.Pose Unity.MARS.Providers.IProvidesCameraOffset::ApplyOffsetToPose(UnityEngine.Pose) */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
	}
}
// UnityEngine.Pose Unity.MARS.Providers.IUsesCameraOffsetMethods::ApplyInverseOffsetToPose(Unity.MARS.Providers.IUsesCameraOffset,UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  IUsesCameraOffsetMethods_ApplyInverseOffsetToPose_m63FC302465D77EF78E08C1FA2EEDB34FA2956690 (RuntimeObject* ___obj0, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___pose1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.ApplyInverseOffsetToPose(pose);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_2 = ___pose1;
		NullCheck(L_1);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_3;
		L_3 = InterfaceFuncInvoker1< Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A , Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  >::Invoke(6 /* UnityEngine.Pose Unity.MARS.Providers.IProvidesCameraOffset::ApplyInverseOffsetToPose(UnityEngine.Pose) */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
	}
}
// UnityEngine.Vector3 Unity.MARS.Providers.IUsesCameraOffsetMethods::ApplyOffsetToPosition(Unity.MARS.Providers.IUsesCameraOffset,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  IUsesCameraOffsetMethods_ApplyOffsetToPosition_m4309E1A754B592DECF31A22A70B2C63989DC35B4 (RuntimeObject* ___obj0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.ApplyOffsetToPosition(position);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraOffset>::get_provider() */, IFunctionalitySubscriber_1_t59D7D4B814CF0436AD6F95D664B4CD13850BD52B_il2cpp_TypeInfo_var, L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___position1;
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(7 /* UnityEngine.Vector3 Unity.MARS.Providers.IProvidesCameraOffset::ApplyOffsetToPosition(UnityEngine.Vector3) */, IProvidesCameraOffset_t39C0314AA33AE2767A473321879AA11330E2F478_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
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
// UnityEngine.Pose Unity.MARS.Providers.IUsesCameraPoseMethods::GetPose(Unity.MARS.Providers.IUsesCameraPose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  IUsesCameraPoseMethods_GetPose_mC864EC06747F481323E0658C5F9F7667CB9FD148 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.GetCameraPose();
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraPose>::get_provider() */, IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_2;
		L_2 = InterfaceFuncInvoker0< Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  >::Invoke(0 /* UnityEngine.Pose Unity.MARS.Providers.IProvidesCameraPose::GetCameraPose() */, IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraPoseMethods::SubscribePoseUpdated(Unity.MARS.Providers.IUsesCameraPose,System.Action`1<UnityEngine.Pose>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraPoseMethods_SubscribePoseUpdated_m906B40EAA025096EE110DA29982A70667D93A9C4 (RuntimeObject* ___obj0, Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * ___poseUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.poseUpdated += poseUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraPose>::get_provider() */, IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var, L_0);
		Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * L_2 = ___poseUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesCameraPose::add_poseUpdated(System.Action`1<UnityEngine.Pose>) */, IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraPoseMethods::UnsubscribePoseUpdated(Unity.MARS.Providers.IUsesCameraPose,System.Action`1<UnityEngine.Pose>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraPoseMethods_UnsubscribePoseUpdated_m6A27676C950BD9E559A8A45BC0196FAA5982A658 (RuntimeObject* ___obj0, Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * ___poseUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.poseUpdated -= poseUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraPose>::get_provider() */, IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var, L_0);
		Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * L_2 = ___poseUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t72CC58FA412BB338AF2DF2B43892543A91B6A160 * >::Invoke(2 /* System.Void Unity.MARS.Providers.IProvidesCameraPose::remove_poseUpdated(System.Action`1<UnityEngine.Pose>) */, IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraPoseMethods::SubscribeTrackingTypeChanged(Unity.MARS.Providers.IUsesCameraPose,System.Action`1<Unity.MARS.Data.MRCameraTrackingState>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraPoseMethods_SubscribeTrackingTypeChanged_m77D0D33EFEC2A61F39C5FF8098B856BE046498E3 (RuntimeObject* ___obj0, Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * ___trackingTypeChanged1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.trackingStateChanged += trackingTypeChanged;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraPose>::get_provider() */, IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var, L_0);
		Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * L_2 = ___trackingTypeChanged1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * >::Invoke(3 /* System.Void Unity.MARS.Providers.IProvidesCameraPose::add_trackingStateChanged(System.Action`1<Unity.MARS.Data.MRCameraTrackingState>) */, IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesCameraPoseMethods::UnsubscribeTrackingTypeChanged(Unity.MARS.Providers.IUsesCameraPose,System.Action`1<Unity.MARS.Data.MRCameraTrackingState>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesCameraPoseMethods_UnsubscribeTrackingTypeChanged_m8965D81FDB9F0A8D2477AF62E79EAC53D0EB303A (RuntimeObject* ___obj0, Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * ___trackingTypeChanged1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.trackingStateChanged -= trackingTypeChanged;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraPose>::get_provider() */, IFunctionalitySubscriber_1_tC431063C974500A2951C4A358BA69020D8656B9A_il2cpp_TypeInfo_var, L_0);
		Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * L_2 = ___trackingTypeChanged1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tD77EAF9200D6E41CF129D3823E17D82569904D09 * >::Invoke(4 /* System.Void Unity.MARS.Providers.IProvidesCameraPose::remove_trackingStateChanged(System.Action`1<Unity.MARS.Data.MRCameraTrackingState>) */, IProvidesCameraPose_t13B2996FE5A98009B9C295696A326B4BC9164233_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Nullable`1<UnityEngine.Matrix4x4> Unity.MARS.Providers.IUsesCameraProjectionMatrixMethods::GetProjectionMatrix(Unity.MARS.Providers.IUsesCameraProjectionMatrix)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E  IUsesCameraProjectionMatrixMethods_GetProjectionMatrix_m02BE533D6814FC58E4A940D353AFBC56456CF323 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t3BD9DCC58EC655DB3F6C555BF83C1894EEE3E29A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraProjectionMatrix_t04A703B6CADBF3D6596AC8FF17940586E590D34E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.GetProjectionMatrix();
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraProjectionMatrix>::get_provider() */, IFunctionalitySubscriber_1_t3BD9DCC58EC655DB3F6C555BF83C1894EEE3E29A_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E  L_2;
		L_2 = InterfaceFuncInvoker0< Nullable_1_tBC3CF93247D9ED5D94966DBCDFCDE51AF9779E8E  >::Invoke(0 /* System.Nullable`1<UnityEngine.Matrix4x4> Unity.MARS.Providers.IProvidesCameraProjectionMatrix::GetProjectionMatrix() */, IProvidesCameraProjectionMatrix_t04A703B6CADBF3D6596AC8FF17940586E590D34E_il2cpp_TypeInfo_var, L_1);
		return L_2;
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
// Unity.MARS.Data.CameraFacingDirection Unity.MARS.Providers.IUsesCameraTextureMethods::GetCameraFacingDirection(Unity.MARS.Providers.IUsesCameraTexture)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IUsesCameraTextureMethods_GetCameraFacingDirection_m9309BB77DC73FFC79FE05CE4C9F214EB7490600E (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4DAF9E0706F00592372394B9681A54AA94F511D9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesCameraTexture_tE5CF5EC05BDBF685D2DADA1571E7934247226A3D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.CameraFacingDirection;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesCameraTexture>::get_provider() */, IFunctionalitySubscriber_1_t4DAF9E0706F00592372394B9681A54AA94F511D9_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* Unity.MARS.Data.CameraFacingDirection Unity.MARS.Providers.IProvidesCameraTexture::get_CameraFacingDirection() */, IProvidesCameraTexture_tE5CF5EC05BDBF685D2DADA1571E7934247226A3D_il2cpp_TypeInfo_var, L_1);
		return L_2;
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
// UnityEngine.Pose Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods::GetDeviceStartingPose(Unity.MARS.Simulation.IUsesDeviceSimulationSettings)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  IUsesDeviceSimulationSettingsMethods_GetDeviceStartingPose_m5F69BD8F8A6AD8EF54DF3D080348AA2F25C117DC (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.DeviceStartingPose;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesDeviceSimulationSettings>::get_provider() */, IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_2;
		L_2 = InterfaceFuncInvoker0< Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  >::Invoke(0 /* UnityEngine.Pose Unity.MARS.Simulation.IProvidesDeviceSimulationSettings::get_DeviceStartingPose() */, IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// UnityEngine.Bounds Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods::GetEnvironmentBounds(Unity.MARS.Simulation.IUsesDeviceSimulationSettings)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37  IUsesDeviceSimulationSettingsMethods_GetEnvironmentBounds_m75B462F748792FA8E0F0CBB0BEF7D440E6EEFFA1 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.EnvironmentBounds;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesDeviceSimulationSettings>::get_provider() */, IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37  L_2;
		L_2 = InterfaceFuncInvoker0< Bounds_t0F1F36D4F7AF49524B3C2A2259594412A3D3AE37  >::Invoke(1 /* UnityEngine.Bounds Unity.MARS.Simulation.IProvidesDeviceSimulationSettings::get_EnvironmentBounds() */, IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Boolean Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods::GetIsMovementEnabled(Unity.MARS.Simulation.IUsesDeviceSimulationSettings)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesDeviceSimulationSettingsMethods_GetIsMovementEnabled_m9F7883CA90B63991EF69924B5ABF74E1358E151E (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.IsMovementEnabled;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesDeviceSimulationSettings>::get_provider() */, IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		bool L_2;
		L_2 = InterfaceFuncInvoker0< bool >::Invoke(2 /* System.Boolean Unity.MARS.Simulation.IProvidesDeviceSimulationSettings::get_IsMovementEnabled() */, IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods::SubscribeEnvironmentChanged(Unity.MARS.Simulation.IUsesDeviceSimulationSettings,System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesDeviceSimulationSettingsMethods_SubscribeEnvironmentChanged_mD0BDE3E0AE3512FA2635D4DA784D68A506855E8D (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___environmentChanged1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.EnvironmentChanged += environmentChanged;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesDeviceSimulationSettings>::get_provider() */, IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___environmentChanged1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * >::Invoke(3 /* System.Void Unity.MARS.Simulation.IProvidesDeviceSimulationSettings::add_EnvironmentChanged(System.Action) */, IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Simulation.IUsesDeviceSimulationSettingsMethods::UnsubscribeEnvironmentChanged(Unity.MARS.Simulation.IUsesDeviceSimulationSettings,System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesDeviceSimulationSettingsMethods_UnsubscribeEnvironmentChanged_m49726155EF5AB0D36362D51018ED32AEE83A3ABD (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___environmentChanged1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.EnvironmentChanged -= environmentChanged;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesDeviceSimulationSettings>::get_provider() */, IFunctionalitySubscriber_1_t955A4DF0CCF0617F7A66860A2A88AC43FC147AF9_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___environmentChanged1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * >::Invoke(4 /* System.Void Unity.MARS.Simulation.IProvidesDeviceSimulationSettings::remove_EnvironmentChanged(System.Action) */, IProvidesDeviceSimulationSettings_tA942CBD6712D593E43F569779EBB4F9D81DAE311_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::SetRequestedMaximumFaceCount(Unity.MARS.Providers.IUsesFaceTracking,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_SetRequestedMaximumFaceCount_m274B35148AA79A0189EA07682A63CF565BBEB46B (RuntimeObject* ___obj0, int32_t ___requestedFaceCount1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.RequestedMaximumFaceCount = requestedFaceCount;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		int32_t L_2 = ___requestedFaceCount1;
		NullCheck(L_1);
		InterfaceActionInvoker1< int32_t >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::set_RequestedMaximumFaceCount(System.Int32) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Int32 Unity.MARS.Providers.IUsesFaceTrackingMethods::GetCurrentMaximumFaceCount(Unity.MARS.Providers.IUsesFaceTracking)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IUsesFaceTrackingMethods_GetCurrentMaximumFaceCount_mD1A4127DB48B5FB10656F0D9A3F17C2E173E689F (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.CurrentMaximumFaceCount;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(1 /* System.Int32 Unity.MARS.Providers.IProvidesFaceTracking::get_CurrentMaximumFaceCount() */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Int32 Unity.MARS.Providers.IUsesFaceTrackingMethods::GetSupportedFaceCount(Unity.MARS.Providers.IUsesFaceTracking)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IUsesFaceTrackingMethods_GetSupportedFaceCount_m4AC421464A1D351815833C2806DEBA68469E4265 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.SupportedFaceCount;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 Unity.MARS.Providers.IProvidesFaceTracking::get_SupportedFaceCount() */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::SubscribeFaceAdded(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_SubscribeFaceAdded_m1059DD53F90043F1EE0EA98F8B04E1C980D9C525 (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceAdded += faceAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(3 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::add_FaceAdded(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::UnsubscribeFaceAdded(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_UnsubscribeFaceAdded_m29842053EA0D61933589DF4C7AA9AB0B6D0FE2EA (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceAdded -= faceAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(4 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::remove_FaceAdded(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::SubscribeFaceUpdated(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_SubscribeFaceUpdated_m5F53A7260E538094A4E9C5DD3851ABA2C005031C (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceUpdated += faceUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(5 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::add_FaceUpdated(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::UnsubscribeFaceUpdated(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_UnsubscribeFaceUpdated_m0E968E1BB5F0A26FE29BFB8E845C15CCED4DC6C8 (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceUpdated -= faceUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(6 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::remove_FaceUpdated(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::SubscribeFaceRemoved(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_SubscribeFaceRemoved_m175F431FD28BD87606483E243B84D74A6A6B7979 (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceRemoved += faceRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(7 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::add_FaceRemoved(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFaceTrackingMethods::UnsubscribeFaceRemoved(Unity.MARS.Providers.IUsesFaceTracking,System.Action`1<Unity.MARS.Data.IMRFace>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFaceTrackingMethods_UnsubscribeFaceRemoved_m62D947225C0618F9803CFEE48FB7266FB090CED6 (RuntimeObject* ___obj0, Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * ___faceRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.FaceRemoved -= faceRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFaceTracking>::get_provider() */, IFunctionalitySubscriber_1_tE0F97439AE35C35875751EBC921915B04D6F4E08_il2cpp_TypeInfo_var, L_0);
		Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * L_2 = ___faceRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t620A647A5DB5B4E42F4F873177F1A0B94054D55E * >::Invoke(8 /* System.Void Unity.MARS.Providers.IProvidesFaceTracking::remove_FaceRemoved(System.Action`1<Unity.MARS.Data.IMRFace>) */, IProvidesFaceTracking_tE5C95579CC2C802DB6627C1D57FC6F7D51673383_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Void Unity.MARS.Providers.IUsesFacialExpressionsMethods::SubscribeToExpression(Unity.MARS.Providers.IUsesFacialExpressions,Unity.MARS.Data.MRFaceExpression,System.Action`1<System.Single>,System.Action`1<System.Single>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFacialExpressionsMethods_SubscribeToExpression_m241C9554FAD7DA45FF6DA36A2F07D20BC9CCAD92 (RuntimeObject* ___obj0, int32_t ___expression1, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___onEngage2, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___onDisengage3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t70D1066FA308F4C0CC57F130F5C09C519D9EB834_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFacialExpressions_t11779ED594B769B105A6E6AA99517F3B5E3D2989_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.SubscribeToExpression(expression, onEngage, onDisengage);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFacialExpressions>::get_provider() */, IFunctionalitySubscriber_1_t70D1066FA308F4C0CC57F130F5C09C519D9EB834_il2cpp_TypeInfo_var, L_0);
		int32_t L_2 = ___expression1;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_3 = ___onEngage2;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_4 = ___onDisengage3;
		NullCheck(L_1);
		InterfaceActionInvoker3< int32_t, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesFacialExpressions::SubscribeToExpression(Unity.MARS.Data.MRFaceExpression,System.Action`1<System.Single>,System.Action`1<System.Single>) */, IProvidesFacialExpressions_t11779ED594B769B105A6E6AA99517F3B5E3D2989_il2cpp_TypeInfo_var, L_1, L_2, L_3, L_4);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesFacialExpressionsMethods::UnsubscribeToExpression(Unity.MARS.Providers.IUsesFacialExpressions,Unity.MARS.Data.MRFaceExpression,System.Action`1<System.Single>,System.Action`1<System.Single>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFacialExpressionsMethods_UnsubscribeToExpression_m6A9932EFE7E18C4FF597CD42322CE9402A69E2B7 (RuntimeObject* ___obj0, int32_t ___expression1, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___onEngage2, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * ___onDisengage3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t70D1066FA308F4C0CC57F130F5C09C519D9EB834_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFacialExpressions_t11779ED594B769B105A6E6AA99517F3B5E3D2989_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.UnsubscribeToExpression(expression, onEngage, onDisengage);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesFacialExpressions>::get_provider() */, IFunctionalitySubscriber_1_t70D1066FA308F4C0CC57F130F5C09C519D9EB834_il2cpp_TypeInfo_var, L_0);
		int32_t L_2 = ___expression1;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_3 = ___onEngage2;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_4 = ___onDisengage3;
		NullCheck(L_1);
		InterfaceActionInvoker3< int32_t, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *, Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesFacialExpressions::UnsubscribeToExpression(Unity.MARS.Data.MRFaceExpression,System.Action`1<System.Single>,System.Action`1<System.Single>) */, IProvidesFacialExpressions_t11779ED594B769B105A6E6AA99517F3B5E3D2989_il2cpp_TypeInfo_var, L_1, L_2, L_3, L_4);
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
// System.Void Unity.MARS.Providers.IUsesGeoLocationMethods::set_TryGetGeoLocationAction(Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesGeoLocationMethods_set_TryGetGeoLocationAction_m0F3822CE0903CEFBC3BA05DBB0AD268D35BF1849 (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static TryGetGeoLocationDelegate TryGetGeoLocationAction { private get; set; }
		TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * L_0 = ___value0;
		((IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields*)il2cpp_codegen_static_fields_for(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var))->set_U3CTryGetGeoLocationActionU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesGeoLocationMethods::set_TryStartServiceFunction(System.Func`1<System.Boolean>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesGeoLocationMethods_set_TryStartServiceFunction_mA847321E04262ECC1D83FDAB454B7A93F2682843 (Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static Func<bool> TryStartServiceFunction { private get; set; }
		Func_1_t76FCDA5C58178ED310C472967481FDE5F47DCF0F * L_0 = ___value0;
		((IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields*)il2cpp_codegen_static_fields_for(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var))->set_U3CTryStartServiceFunctionU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesGeoLocationMethods::set_SubscribeGeoLocationChangedAction(System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesGeoLocationMethods_set_SubscribeGeoLocationChangedAction_m392CE600313E2D5F4D0B07E31CFC5C1A42B36EB1 (Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static Action<Action<GeographicCoordinate>> SubscribeGeoLocationChangedAction { private get; set; }
		Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * L_0 = ___value0;
		((IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields*)il2cpp_codegen_static_fields_for(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var))->set_U3CSubscribeGeoLocationChangedActionU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesGeoLocationMethods::set_UnsubscribeGeoLocationChangedAction(System.Action`1<System.Action`1<Unity.MARS.Data.GeographicCoordinate>>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesGeoLocationMethods_set_UnsubscribeGeoLocationChangedAction_mF0A1B44AB38BB3D62DA5F1C0D4D3524439DE5924 (Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static Action<Action<GeographicCoordinate>> UnsubscribeGeoLocationChangedAction { private get; set; }
		Action_1_t4EB7B4408A572DBE7F0494EE48DA86CCBC2FB42A * L_0 = ___value0;
		((IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_StaticFields*)il2cpp_codegen_static_fields_for(IUsesGeoLocationMethods_t3F4D74564B8DE5E534263B1D69A617480C44713E_il2cpp_TypeInfo_var))->set_U3CUnsubscribeGeoLocationChangedActionU3Ek__BackingField_3(L_0);
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
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::GetMarkers(Unity.MARS.Providers.IUsesMarkerTracking,System.Collections.Generic.List`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_GetMarkers_mADEBC603965F58D189721D05A87A98380EDC353F (RuntimeObject* ___obj0, List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2 * ___markers1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.GetMarkers(markers);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2 * L_2 = ___markers1;
		NullCheck(L_1);
		InterfaceActionInvoker1< List_1_tB99BC324975CD032FD25D58944C5D19589C15FF2 * >::Invoke(7 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::GetMarkers(System.Collections.Generic.List`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::SubscribeMarkerAdded(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_SubscribeMarkerAdded_m2DFD8C9E44C9F3F073423FC931D980FE4C22B23C (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerAdded += markerAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::add_markerAdded(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::UnsubscribeMarkerAdded(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_UnsubscribeMarkerAdded_m31392581E6C976D63DB611FC73808B85BD524E5A (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerAdded -= markerAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::remove_markerAdded(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::SubscribeMarkerUpdated(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_SubscribeMarkerUpdated_mC1C1FE8A5416DB6551630841C1D5BD8985A16244 (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerUpdated += markerUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(2 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::add_markerUpdated(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::UnsubscribeMarkerUpdated(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_UnsubscribeMarkerUpdated_m76D8B627FDBA88631FA3BE3B30507199B9FA77CF (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerUpdated -= markerUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(3 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::remove_markerUpdated(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::SubscribeMarkerRemoved(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_SubscribeMarkerRemoved_m8F7739B064F9537291FEB3DE1B77764B01E661BF (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerRemoved += markerRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(4 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::add_markerRemoved(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::UnsubscribeMarkerRemoved(Unity.MARS.Providers.IUsesMarkerTracking,System.Action`1<Unity.MARS.Data.MRMarker>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_UnsubscribeMarkerRemoved_m34A7F9D59CD9CCBB9265B8F6CD6A7EC934D8F5ED (RuntimeObject* ___obj0, Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * ___markerRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.markerRemoved -= markerRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * L_2 = ___markerRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t3FEBDD7646E63D34E8060D2032F216F247E861AB * >::Invoke(5 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::remove_markerRemoved(System.Action`1<Unity.MARS.Data.MRMarker>) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::StopTrackingMarkers(Unity.MARS.Providers.IUsesMarkerTracking)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_StopTrackingMarkers_m41C86FBA099C8D0AE3CAD2079DF4EDAC34FBCBBD (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.StopTrackingMarkers();
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		InterfaceActionInvoker0::Invoke(8 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::StopTrackingMarkers() */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesMarkerTrackingMethods::StartTrackingMarkers(Unity.MARS.Providers.IUsesMarkerTracking)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesMarkerTrackingMethods_StartTrackingMarkers_m9E61A54A6D131129AED35DC6D6E39698490C3FA4 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.StartTrackingMarkers();
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		InterfaceActionInvoker0::Invoke(9 /* System.Void Unity.MARS.Providers.IProvidesMarkerTracking::StartTrackingMarkers() */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1);
		// }
		return;
	}
}
// System.Boolean Unity.MARS.Providers.IUsesMarkerTrackingMethods::SetActiveMarkerLibrary(Unity.MARS.Providers.IUsesMarkerTracking,Unity.MARS.Data.IMRMarkerLibrary)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesMarkerTrackingMethods_SetActiveMarkerLibrary_m6FE7825869C37EADE313E2C2B290C1A0B44556B9 (RuntimeObject* ___obj0, RuntimeObject* ___markerLibrary1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.SetActiveMarkerLibrary(markerLibrary);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesMarkerTracking>::get_provider() */, IFunctionalitySubscriber_1_tC89AF201B5E8536366818298524280C38CF0CA3A_il2cpp_TypeInfo_var, L_0);
		RuntimeObject* L_2 = ___markerLibrary1;
		NullCheck(L_1);
		bool L_3;
		L_3 = InterfaceFuncInvoker1< bool, RuntimeObject* >::Invoke(6 /* System.Boolean Unity.MARS.Providers.IProvidesMarkerTracking::SetActiveMarkerLibrary(Unity.MARS.Data.IMRMarkerLibrary) */, IProvidesMarkerTracking_tCB0F69928D2C97F43B7085CB23B373F94FEB8C05_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
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
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::GetPlanes(Unity.MARS.Providers.IUsesPlaneFinding,System.Collections.Generic.List`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_GetPlanes_m2F210F201D8B0BA462296A3E10AFE539503A70F1 (RuntimeObject* ___obj0, List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7 * ___planes1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.GetPlanes(planes);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7 * L_2 = ___planes1;
		NullCheck(L_1);
		InterfaceActionInvoker1< List_1_t12E705C1034DF6B2252B46554BB7680F74899AB7 * >::Invoke(6 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::GetPlanes(System.Collections.Generic.List`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::SubscribePlaneAdded(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_SubscribePlaneAdded_m4F6F302BD0EF3A30C72438724194DE3D08C6740E (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeAdded += planeAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::add_planeAdded(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::UnsubscribePlaneAdded(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_UnsubscribePlaneAdded_m180183F4DDD1BF75FAAFDB228876271A7C5BD3DE (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeAdded1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeAdded -= planeAdded;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeAdded1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::remove_planeAdded(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::SubscribePlaneUpdated(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_SubscribePlaneUpdated_m58F237E76F0323B041D32A329D5CD37C9E129477 (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeUpdated += planeUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(2 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::add_planeUpdated(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::UnsubscribePlaneUpdated(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_UnsubscribePlaneUpdated_mC80AD0951F3B5D9C4165F51439496E7598658B00 (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeUpdated -= planeUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(3 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::remove_planeUpdated(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::SubscribePlaneRemoved(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_SubscribePlaneRemoved_m6AFA361D9229E7D1194357D9C26AC70A54E238CE (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeRemoved += planeRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(4 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::add_planeRemoved(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPlaneFindingMethods::UnsubscribePlaneRemoved(Unity.MARS.Providers.IUsesPlaneFinding,System.Action`1<Unity.MARS.Data.MRPlane>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPlaneFindingMethods_UnsubscribePlaneRemoved_m15A4AD12E9BA79D69CE8D3379CE6088F2DA33F52 (RuntimeObject* ___obj0, Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * ___planeRemoved1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.planeRemoved -= planeRemoved;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPlaneFinding>::get_provider() */, IFunctionalitySubscriber_1_t4212D60E796326FDCFB79388D1A0C0CB2F144B9E_il2cpp_TypeInfo_var, L_0);
		Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * L_2 = ___planeRemoved1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t290C076A0F9B6CF56B10E9C12B8741E71F807C62 * >::Invoke(5 /* System.Void Unity.MARS.Providers.IProvidesPlaneFinding::remove_planeRemoved(System.Action`1<Unity.MARS.Data.MRPlane>) */, IProvidesPlaneFinding_tC9F3DBA1E075D585658F269971F88D090B3BBF1B_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Void Unity.MARS.Providers.IUsesPointCloudMethods::SubscribePointCloudUpdated(Unity.MARS.Providers.IUsesPointCloud,System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPointCloudMethods_SubscribePointCloudUpdated_mA8340D0E696E1210CFADE348CDD8D8F75AC04964 (RuntimeObject* ___obj0, Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * ___pointCloudUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t45730178F0F552264B47E3CFF9E936AF1174D55F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPointCloud_t245C79C027402F0E38DB4C847E2DEABD1F4FED12_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.PointCloudUpdated += pointCloudUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPointCloud>::get_provider() */, IFunctionalitySubscriber_1_t45730178F0F552264B47E3CFF9E936AF1174D55F_il2cpp_TypeInfo_var, L_0);
		Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * L_2 = ___pointCloudUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesPointCloud::add_PointCloudUpdated(System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>) */, IProvidesPointCloud_t245C79C027402F0E38DB4C847E2DEABD1F4FED12_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.IUsesPointCloudMethods::UnsubscribePointCloudUpdated(Unity.MARS.Providers.IUsesPointCloud,System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesPointCloudMethods_UnsubscribePointCloudUpdated_m56D0F644F1DAAB25933BDA0BFFEF2D765FA694DE (RuntimeObject* ___obj0, Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * ___pointCloudUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t45730178F0F552264B47E3CFF9E936AF1174D55F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesPointCloud_t245C79C027402F0E38DB4C847E2DEABD1F4FED12_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.PointCloudUpdated -= pointCloudUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesPointCloud>::get_provider() */, IFunctionalitySubscriber_1_t45730178F0F552264B47E3CFF9E936AF1174D55F_il2cpp_TypeInfo_var, L_0);
		Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * L_2 = ___pointCloudUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tB1866F7E78102814EE820230E5CFF75867696ACF * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesPointCloud::remove_PointCloudUpdated(System.Action`1<System.Collections.Generic.Dictionary`2<Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.PointCloudData>>) */, IProvidesPointCloud_t245C79C027402F0E38DB4C847E2DEABD1F4FED12_il2cpp_TypeInfo_var, L_1, L_2);
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
// UnityEngine.Texture Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods::GetVideoFeedTexture(Unity.MARS.Simulation.IUsesSimulationVideoFeed)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE * IUsesSimulationVideoFeedMethods_GetVideoFeedTexture_m7825EBBB9B5A178EDB76D34B10DDFB180A0ABDC1 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.VideoFeedTexture;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesSimulationVideoFeed>::get_provider() */, IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE * L_2;
		L_2 = InterfaceFuncInvoker0< Texture_t9FE0218A1EEDF266E8C85879FE123265CACC95AE * >::Invoke(0 /* UnityEngine.Texture Unity.MARS.Simulation.IProvidesSimulationVideoFeed::get_VideoFeedTexture() */, IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Single Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods::GetVideoFocalLength(Unity.MARS.Simulation.IUsesSimulationVideoFeed)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float IUsesSimulationVideoFeedMethods_GetVideoFocalLength_m175B2EA253B5FB9E53E076BDA3EC72022D65CB70 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.VideoFocalLength;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesSimulationVideoFeed>::get_provider() */, IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		float L_2;
		L_2 = InterfaceFuncInvoker0< float >::Invoke(1 /* System.Single Unity.MARS.Simulation.IProvidesSimulationVideoFeed::get_VideoFocalLength() */, IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// Unity.MARS.Data.CameraFacingDirection Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods::GetVideoFacingDirection(Unity.MARS.Simulation.IUsesSimulationVideoFeed)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IUsesSimulationVideoFeedMethods_GetVideoFacingDirection_m31AC46EF0B28CEB45709049E203F799F7787A101 (RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.VideoFacingDirection;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesSimulationVideoFeed>::get_provider() */, IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var, L_0);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(2 /* Unity.MARS.Data.CameraFacingDirection Unity.MARS.Simulation.IProvidesSimulationVideoFeed::get_VideoFacingDirection() */, IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var, L_1);
		return L_2;
	}
}
// System.Void Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods::SubscribeVideoFeedTextureCreated(Unity.MARS.Simulation.IUsesSimulationVideoFeed,System.Action`1<UnityEngine.Texture>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesSimulationVideoFeedMethods_SubscribeVideoFeedTextureCreated_m59DC475389B44F3CBCB8F02F14EDD7C4823DBFE6 (RuntimeObject* ___obj0, Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * ___onVideoFeedTextureCreated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.VideoFeedTextureChanged += onVideoFeedTextureCreated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesSimulationVideoFeed>::get_provider() */, IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var, L_0);
		Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * L_2 = ___onVideoFeedTextureCreated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * >::Invoke(3 /* System.Void Unity.MARS.Simulation.IProvidesSimulationVideoFeed::add_VideoFeedTextureChanged(System.Action`1<UnityEngine.Texture>) */, IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Simulation.IUsesSimulationVideoFeedMethods::UnsubscribeVideoFeedTextureCreated(Unity.MARS.Simulation.IUsesSimulationVideoFeed,System.Action`1<UnityEngine.Texture>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesSimulationVideoFeedMethods_UnsubscribeVideoFeedTextureCreated_m155814B049CA17450C4F5B234D5AAB3AF5F35AC1 (RuntimeObject* ___obj0, Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * ___onVideoFeedTextureCreated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.VideoFeedTextureChanged -= onVideoFeedTextureCreated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Simulation.IProvidesSimulationVideoFeed>::get_provider() */, IFunctionalitySubscriber_1_t1A11A5CDEC8B979674694805F2E56F711FE55C9E_il2cpp_TypeInfo_var, L_0);
		Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * L_2 = ___onVideoFeedTextureCreated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_tC25E79D0F80065D02AA664DE3D9F44E6737A53A0 * >::Invoke(4 /* System.Void Unity.MARS.Simulation.IProvidesSimulationVideoFeed::remove_VideoFeedTextureChanged(System.Action`1<UnityEngine.Texture>) */, IProvidesSimulationVideoFeed_t13674889FFC53B7E603DABB69EC44EE47F0DA2C4_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Boolean Unity.MARS.MARSUtils.IUsesSlowTasksMethods::AddSlowTask(Unity.MARS.MARSUtils.IUsesSlowTasks,System.Action,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesSlowTasksMethods_AddSlowTask_m1ADBBF1ECA2893C655508EEE863B24C1123866EA (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___task1, float ___sleepTime2, bool ___replace3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.AddSlowTask(task, sleepTime, replace);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.MARSUtils.IProvidesSlowTasks>::get_provider() */, IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___task1;
		float L_3 = ___sleepTime2;
		bool L_4 = ___replace3;
		NullCheck(L_1);
		bool L_5;
		L_5 = InterfaceFuncInvoker3< bool, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *, float, bool >::Invoke(0 /* System.Boolean Unity.MARS.MARSUtils.IProvidesSlowTasks::AddSlowTask(System.Action,System.Single,System.Boolean) */, IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var, L_1, L_2, L_3, L_4);
		return L_5;
	}
}
// System.Boolean Unity.MARS.MARSUtils.IUsesSlowTasksMethods::RemoveSlowTask(Unity.MARS.MARSUtils.IUsesSlowTasks,System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesSlowTasksMethods_RemoveSlowTask_mB62D2021E473E06BB7AFED5F4E7B5463102B3570 (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___task1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.RemoveSlowTask(task);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.MARSUtils.IProvidesSlowTasks>::get_provider() */, IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___task1;
		NullCheck(L_1);
		bool L_3;
		L_3 = InterfaceFuncInvoker1< bool, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * >::Invoke(1 /* System.Boolean Unity.MARS.MARSUtils.IProvidesSlowTasks::RemoveSlowTask(System.Action) */, IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
	}
}
// System.Boolean Unity.MARS.MARSUtils.IUsesSlowTasksMethods::AddMarsTimeSlowTask(Unity.MARS.MARSUtils.IUsesSlowTasks,System.Action,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesSlowTasksMethods_AddMarsTimeSlowTask_m443BB7C9C32F9598B5BF8A864E9250FA99826DAB (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___task1, float ___sleepTime2, bool ___replace3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.AddMarsTimeSlowTask(task, sleepTime, replace);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.MARSUtils.IProvidesSlowTasks>::get_provider() */, IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___task1;
		float L_3 = ___sleepTime2;
		bool L_4 = ___replace3;
		NullCheck(L_1);
		bool L_5;
		L_5 = InterfaceFuncInvoker3< bool, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *, float, bool >::Invoke(2 /* System.Boolean Unity.MARS.MARSUtils.IProvidesSlowTasks::AddMarsTimeSlowTask(System.Action,System.Single,System.Boolean) */, IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var, L_1, L_2, L_3, L_4);
		return L_5;
	}
}
// System.Boolean Unity.MARS.MARSUtils.IUsesSlowTasksMethods::RemoveMarsTimeSlowTask(Unity.MARS.MARSUtils.IUsesSlowTasks,System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IUsesSlowTasksMethods_RemoveMarsTimeSlowTask_m6DFEC584BF2A61C872FB93336EC673A261FBCC17 (RuntimeObject* ___obj0, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___task1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.RemoveMarsTimeSlowTask(task);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.MARSUtils.IProvidesSlowTasks>::get_provider() */, IFunctionalitySubscriber_1_t59930E8B8C05214B35F6B45E118EC70C530A2909_il2cpp_TypeInfo_var, L_0);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = ___task1;
		NullCheck(L_1);
		bool L_3;
		L_3 = InterfaceFuncInvoker1< bool, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * >::Invoke(3 /* System.Boolean Unity.MARS.MARSUtils.IProvidesSlowTasks::RemoveMarsTimeSlowTask(System.Action) */, IProvidesSlowTasks_t89BE5696B1F13C668F4DE6C700A3C9A240C648A0_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IsReadOnlyAttribute__ctor_mFCFC29800BCA586EB979A183535FBC862770811E (IsReadOnlyAttribute_t297546CB86F076B76F3800238C03F3140A56AB77 * __this, const RuntimeMethod* method)
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
// System.Void Unity.MARS.Landmarks.LandmarkDefinition::.ctor(System.String,System.Type,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LandmarkDefinition__ctor_m7CD17FB42C384E3B8BB819402B3BA6377D5C52BA (LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C * __this, String_t* ___name0, Type_t * ___outputType1, Type_t * ___settingsType2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public LandmarkDefinition(string name, Type outputType, Type settingsType = null)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// this.name = name;
		String_t* L_0 = ___name0;
		__this->set_name_0(L_0);
		// outputTypes = new [] { outputType };
		TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_1 = (TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755*)(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755*)SZArrayNew(TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755_il2cpp_TypeInfo_var, (uint32_t)1);
		TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_2 = L_1;
		Type_t * L_3 = ___outputType1;
		NullCheck(L_2);
		ArrayElementTypeCheck (L_2, L_3);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(0), (Type_t *)L_3);
		__this->set_outputTypes_1(L_2);
		// this.settingsType = settingsType;
		Type_t * L_4 = ___settingsType2;
		__this->set_settingsType_2(L_4);
		// }
		return;
	}
}
// System.Void Unity.MARS.Landmarks.LandmarkDefinition::.ctor(System.String,System.Type[],System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LandmarkDefinition__ctor_m3A98BA993CDAFF748DCE855DCF58FC7F95824B4F (LandmarkDefinition_t878E3C3C56761ED015BB31CEF4A13513A4B6F63C * __this, String_t* ___name0, TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* ___outputTypes1, Type_t * ___settingsType2, const RuntimeMethod* method)
{
	{
		// public LandmarkDefinition(string name, Type[] outputTypes, Type settingsType = null)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// this.name = name;
		String_t* L_0 = ___name0;
		__this->set_name_0(L_0);
		// this.outputTypes = outputTypes;
		TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_1 = ___outputTypes1;
		__this->set_outputTypes_1(L_1);
		// this.settingsType = settingsType;
		Type_t * L_2 = ___settingsType2;
		__this->set_settingsType_2(L_2);
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
// System.Void Unity.MARS.Data.LoadTextureCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LoadTextureCallback__ctor_mC0759E85290DED101059C829CF59C618210CABB5 (LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void Unity.MARS.Data.LoadTextureCallback::Invoke(System.Boolean,System.Int64,UnityEngine.Texture2D,System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LoadTextureCallback_Invoke_mF4922095B6666E1E1ECF5E6D7034B6CF18C8EF63 (LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8 * __this, bool ___success0, int64_t ___responseCode1, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___texture2, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___payload3, const RuntimeMethod* method)
{
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* delegateArrayToInvoke = __this->get_delegates_11();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = delegateArrayToInvoke->max_length;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_2();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 4)
			{
				// open
				typedef void (*FunctionPointerType) (bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___success0, ___responseCode1, ___texture2, ___payload3, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___success0, ___responseCode1, ___texture2, ___payload3, targetMethod);
			}
		}
		else
		{
			// closed
			if (targetThis != NULL && il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_generic_instance(targetMethod))
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						GenericInterfaceActionInvoker4< bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* >::Invoke(targetMethod, targetThis, ___success0, ___responseCode1, ___texture2, ___payload3);
					else
						GenericVirtActionInvoker4< bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* >::Invoke(targetMethod, targetThis, ___success0, ___responseCode1, ___texture2, ___payload3);
				}
				else
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						InterfaceActionInvoker4< bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___success0, ___responseCode1, ___texture2, ___payload3);
					else
						VirtActionInvoker4< bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___success0, ___responseCode1, ___texture2, ___payload3);
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, bool, int64_t, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF *, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___success0, ___responseCode1, ___texture2, ___payload3, targetMethod);
			}
		}
	}
}
// System.IAsyncResult Unity.MARS.Data.LoadTextureCallback::BeginInvoke(System.Boolean,System.Int64,UnityEngine.Texture2D,System.Byte[],System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* LoadTextureCallback_BeginInvoke_mE2510E0EF8C40A0CB48B1A17D1470A065B56028A (LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8 * __this, bool ___success0, int64_t ___responseCode1, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___texture2, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___payload3, AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___callback4, RuntimeObject * ___object5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[5] = {0};
	__d_args[0] = Box(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var, &___success0);
	__d_args[1] = Box(Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var, &___responseCode1);
	__d_args[2] = ___texture2;
	__d_args[3] = ___payload3;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback4, (RuntimeObject*)___object5);;
}
// System.Void Unity.MARS.Data.LoadTextureCallback::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LoadTextureCallback_EndInvoke_mEF1193CAB36B1DDF8415F387A847262C1D9403CF (LoadTextureCallback_t5DB6FABB50B6A686208E09DC712EEC6E2774C5D8 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean Unity.MARS.Data.MRFaceLandmarkComparer::Equals(Unity.MARS.Data.MRFaceLandmark,Unity.MARS.Data.MRFaceLandmark)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRFaceLandmarkComparer_Equals_m513C6AFA5C27C26AFD7D674901EB2CC5346D2622 (MRFaceLandmarkComparer_t6C68AE6AAAB8D4757E4FA5F752B0101A5C035B98 * __this, int32_t ___x0, int32_t ___y1, const RuntimeMethod* method)
{
	{
		// return x == y;
		int32_t L_0 = ___x0;
		int32_t L_1 = ___y1;
		return (bool)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0);
	}
}
// System.Int32 Unity.MARS.Data.MRFaceLandmarkComparer::GetHashCode(Unity.MARS.Data.MRFaceLandmark)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRFaceLandmarkComparer_GetHashCode_m77EFEFDE7F0808974A98CCFD973C36BA6701CC8A (MRFaceLandmarkComparer_t6C68AE6AAAB8D4757E4FA5F752B0101A5C035B98 * __this, int32_t ___obj0, const RuntimeMethod* method)
{
	{
		// return (int)obj;
		int32_t L_0 = ___obj0;
		return L_0;
	}
}
// System.Void Unity.MARS.Data.MRFaceLandmarkComparer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRFaceLandmarkComparer__ctor_m6766B5D66BB654F28EB3E918648C7630010FAF2B (MRFaceLandmarkComparer_t6C68AE6AAAB8D4757E4FA5F752B0101A5C035B98 * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
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
// System.Void Unity.MARS.Data.MRHitTestResult::set_pose(UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRHitTestResult_set_pose_m8D1F054849B3E056745B3D51905600A0EB03B09F (MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRHitTestResult_set_pose_m8D1F054849B3E056745B3D51905600A0EB03B09F_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 * _thisAdjusted = reinterpret_cast<MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 *>(__this + _offset);
	MRHitTestResult_set_pose_m8D1F054849B3E056745B3D51905600A0EB03B09F_inline(_thisAdjusted, ___value0, method);
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
// Conversion methods for marshalling of: Unity.MARS.Data.MRLightEstimation
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_pinvoke(const MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096& unmarshaled, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_AmbientBrightness_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AmbientBrightness' of type 'MRLightEstimation'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AmbientBrightness_0Exception, NULL);
}
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_pinvoke_back(const MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_pinvoke& marshaled, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096& unmarshaled)
{
	Exception_t* ___m_AmbientBrightness_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AmbientBrightness' of type 'MRLightEstimation'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AmbientBrightness_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRLightEstimation
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_pinvoke_cleanup(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.Data.MRLightEstimation
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_com(const MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096& unmarshaled, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_com& marshaled)
{
	Exception_t* ___m_AmbientBrightness_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AmbientBrightness' of type 'MRLightEstimation'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AmbientBrightness_0Exception, NULL);
}
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_com_back(const MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_com& marshaled, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096& unmarshaled)
{
	Exception_t* ___m_AmbientBrightness_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AmbientBrightness' of type 'MRLightEstimation'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AmbientBrightness_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRLightEstimation
IL2CPP_EXTERN_C void MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshal_com_cleanup(MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: Unity.MARS.Data.MRMarker
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_pinvoke(const MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50& unmarshaled, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_Texture_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Texture' of type 'MRMarker': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Texture_5Exception, NULL);
}
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_pinvoke_back(const MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_pinvoke& marshaled, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50& unmarshaled)
{
	Exception_t* ___m_Texture_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Texture' of type 'MRMarker': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Texture_5Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRMarker
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_pinvoke_cleanup(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.Data.MRMarker
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_com(const MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50& unmarshaled, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_com& marshaled)
{
	Exception_t* ___m_Texture_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Texture' of type 'MRMarker': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Texture_5Exception, NULL);
}
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_com_back(const MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_com& marshaled, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50& unmarshaled)
{
	Exception_t* ___m_Texture_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Texture' of type 'MRMarker': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Texture_5Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRMarker
IL2CPP_EXTERN_C void MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshal_com_cleanup(MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50_marshaled_com& marshaled)
{
}
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRMarker::get_id()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_TrackableId; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_m_TrackableId_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  _returnValue;
	_returnValue = MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRMarker::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_id_mA90B2B6E2EA4D9124A06B2FDDFD785B334ACE211 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_TrackableId = value; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_m_TrackableId_0(L_0);
		// set { m_TrackableId = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_id_mA90B2B6E2EA4D9124A06B2FDDFD785B334ACE211_AdjustorThunk (RuntimeObject * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_id_mA90B2B6E2EA4D9124A06B2FDDFD785B334ACE211_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Pose Unity.MARS.Data.MRMarker::get_pose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRMarker_get_pose_m26B01BBC6BC33C554B37D95E3F547934B31F3724 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Pose; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_m_Pose_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRMarker_get_pose_m26B01BBC6BC33C554B37D95E3F547934B31F3724_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  _returnValue;
	_returnValue = MRMarker_get_pose_m26B01BBC6BC33C554B37D95E3F547934B31F3724_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRMarker::set_pose(UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_pose_m214334D9B1F67D0788C9CB495CC7A0FAB68A2EDE (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Pose = value; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_m_Pose_1(L_0);
		// set { m_Pose = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_pose_m214334D9B1F67D0788C9CB495CC7A0FAB68A2EDE_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_pose_m214334D9B1F67D0788C9CB495CC7A0FAB68A2EDE_inline(_thisAdjusted, ___value0, method);
}
// System.Guid Unity.MARS.Data.MRMarker::get_markerId()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Guid_t  MRMarker_get_markerId_mD511F48B85309DC3647C2523C662BF2F6A7EF0DF (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_MarkerId; }
		Guid_t  L_0 = __this->get_m_MarkerId_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Guid_t  MRMarker_get_markerId_mD511F48B85309DC3647C2523C662BF2F6A7EF0DF_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	Guid_t  _returnValue;
	_returnValue = MRMarker_get_markerId_mD511F48B85309DC3647C2523C662BF2F6A7EF0DF_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRMarker::set_markerId(System.Guid)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_markerId_m754B1B5039AEA750907A5FC75F1A97CB62CA1C92 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Guid_t  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_MarkerId = value; }
		Guid_t  L_0 = ___value0;
		__this->set_m_MarkerId_2(L_0);
		// set { m_MarkerId = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_markerId_m754B1B5039AEA750907A5FC75F1A97CB62CA1C92_AdjustorThunk (RuntimeObject * __this, Guid_t  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_markerId_m754B1B5039AEA750907A5FC75F1A97CB62CA1C92_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector2 Unity.MARS.Data.MRMarker::get_extents()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRMarker_get_extents_m53EE2D20BE320174FF59B0F2A63269BC68F8102E (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Extents; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_m_Extents_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRMarker_get_extents_m53EE2D20BE320174FF59B0F2A63269BC68F8102E_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  _returnValue;
	_returnValue = MRMarker_get_extents_m53EE2D20BE320174FF59B0F2A63269BC68F8102E_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRMarker::set_extents(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_extents_m8B9997FA7962B7231D8E3D6B9F97F4B7D7C8E12B (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Extents = value; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_m_Extents_3(L_0);
		// set { m_Extents = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_extents_m8B9997FA7962B7231D8E3D6B9F97F4B7D7C8E12B_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_extents_m8B9997FA7962B7231D8E3D6B9F97F4B7D7C8E12B_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.Data.MARSTrackingState Unity.MARS.Data.MRMarker::get_trackingState()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRMarker_get_trackingState_m31D5F6EF768A2D155BEFA7A19B37F4FBFB5FF95C (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get => m_TrackingState;
		int32_t L_0 = __this->get_m_TrackingState_4();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t MRMarker_get_trackingState_m31D5F6EF768A2D155BEFA7A19B37F4FBFB5FF95C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MRMarker_get_trackingState_m31D5F6EF768A2D155BEFA7A19B37F4FBFB5FF95C_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRMarker::set_trackingState(Unity.MARS.Data.MARSTrackingState)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_trackingState_m6E5022AD0ED0483B1CCB1D828CAFBB6AAA6BD440 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// set => m_TrackingState = value;
		int32_t L_0 = ___value0;
		__this->set_m_TrackingState_4(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_trackingState_m6E5022AD0ED0483B1CCB1D828CAFBB6AAA6BD440_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_trackingState_m6E5022AD0ED0483B1CCB1D828CAFBB6AAA6BD440_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.Data.MRMarker::set_texture(UnityEngine.Texture2D)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRMarker_set_texture_m3671418D4EA8029AD01065A79661D2218D0F7358 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___value0, const RuntimeMethod* method)
{
	{
		// set => m_Texture = value;
		Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * L_0 = ___value0;
		__this->set_m_Texture_5(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRMarker_set_texture_m3671418D4EA8029AD01065A79661D2218D0F7358_AdjustorThunk (RuntimeObject * __this, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	MRMarker_set_texture_m3671418D4EA8029AD01065A79661D2218D0F7358_inline(_thisAdjusted, ___value0, method);
}
// System.String Unity.MARS.Data.MRMarker::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MRMarker_ToString_m2D58F681A47C4D32440789CED74EE89E75A65AE4 (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Guid_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MARSTrackingState_t123CCD8D1D2C4524143EAB2A6333B4EC53EA240B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE5EDD2A398E7E7ED8B6C2CD07762D81D9ACFA461);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return $"marker: {m_MarkerId}\npose: {m_Pose},\ntracking state: {m_TrackingState}";
		Guid_t  L_0 = __this->get_m_MarkerId_2();
		Guid_t  L_1 = L_0;
		RuntimeObject * L_2 = Box(Guid_t_il2cpp_TypeInfo_var, &L_1);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_3 = __this->get_m_Pose_1();
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_4 = L_3;
		RuntimeObject * L_5 = Box(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_il2cpp_TypeInfo_var, &L_4);
		int32_t L_6 = __this->get_m_TrackingState_4();
		int32_t L_7 = L_6;
		RuntimeObject * L_8 = Box(MARSTrackingState_t123CCD8D1D2C4524143EAB2A6333B4EC53EA240B_il2cpp_TypeInfo_var, &L_7);
		String_t* L_9;
		L_9 = String_Format_m039737CCD992C5BFC8D16DFD681F5E8786E87FA6(_stringLiteralE5EDD2A398E7E7ED8B6C2CD07762D81D9ACFA461, L_2, L_5, L_8, /*hidden argument*/NULL);
		return L_9;
	}
}
IL2CPP_EXTERN_C  String_t* MRMarker_ToString_m2D58F681A47C4D32440789CED74EE89E75A65AE4_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = MRMarker_ToString_m2D58F681A47C4D32440789CED74EE89E75A65AE4(_thisAdjusted, method);
	return _returnValue;
}
// System.Int32 Unity.MARS.Data.MRMarker::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRMarker_GetHashCode_m7DF1629A7871B5E462B4387FC547755AA8D956DF (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// public override int GetHashCode() { return id.GetHashCode(); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0;
		L_0 = MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline((MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *)__this, /*hidden argument*/NULL);
		V_0 = L_0;
		int32_t L_1;
		L_1 = MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)(&V_0), /*hidden argument*/NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t MRMarker_GetHashCode_m7DF1629A7871B5E462B4387FC547755AA8D956DF_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MRMarker_GetHashCode_m7DF1629A7871B5E462B4387FC547755AA8D956DF(_thisAdjusted, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MRMarker::Equals(Unity.MARS.Data.MRMarker)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRMarker_Equals_mFA4D7A0359EE8D763B9FE443DE29C9C0142EA61C (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50  ___other0, const RuntimeMethod* method)
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// public bool Equals(MRMarker other) { return id.Equals(other.id); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0;
		L_0 = MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline((MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *)__this, /*hidden argument*/NULL);
		V_0 = L_0;
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_1;
		L_1 = MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline((MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *)(&___other0), /*hidden argument*/NULL);
		bool L_2;
		L_2 = MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)(&V_0), L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  bool MRMarker_Equals_mFA4D7A0359EE8D763B9FE443DE29C9C0142EA61C_AdjustorThunk (RuntimeObject * __this, MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50  ___other0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * _thisAdjusted = reinterpret_cast<MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 *>(__this + _offset);
	bool _returnValue;
	_returnValue = MRMarker_Equals_mFA4D7A0359EE8D763B9FE443DE29C9C0142EA61C(_thisAdjusted, ___other0, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: Unity.MARS.Data.MRPlane
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_pinvoke(const MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3& unmarshaled, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_pinvoke& marshaled)
{
	Exception_t* ___vertices_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'vertices' of type 'MRPlane'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___vertices_6Exception, NULL);
}
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_pinvoke_back(const MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_pinvoke& marshaled, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3& unmarshaled)
{
	Exception_t* ___vertices_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'vertices' of type 'MRPlane'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___vertices_6Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRPlane
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_pinvoke_cleanup(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.Data.MRPlane
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_com(const MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3& unmarshaled, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_com& marshaled)
{
	Exception_t* ___vertices_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'vertices' of type 'MRPlane'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___vertices_6Exception, NULL);
}
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_com_back(const MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_com& marshaled, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3& unmarshaled)
{
	Exception_t* ___vertices_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'vertices' of type 'MRPlane'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___vertices_6Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MRPlane
IL2CPP_EXTERN_C void MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshal_com_cleanup(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_marshaled_com& marshaled)
{
}
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRPlane::get_id()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRPlane_get_id_m3C58E67BF29B34E32E8A66A7669D1C5C0AB92B92 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_ID; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_m_ID_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRPlane_get_id_m3C58E67BF29B34E32E8A66A7669D1C5C0AB92B92_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  _returnValue;
	_returnValue = MRPlane_get_id_m3C58E67BF29B34E32E8A66A7669D1C5C0AB92B92_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane_set_id_mB85378E0E640B7009C4B8A86C758BC7918770F6C (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_ID = value; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_m_ID_1(L_0);
		// set { m_ID = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRPlane_set_id_mB85378E0E640B7009C4B8A86C758BC7918770F6C_AdjustorThunk (RuntimeObject * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MRPlane_set_id_mB85378E0E640B7009C4B8A86C758BC7918770F6C_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.Data.MarsPlaneAlignment Unity.MARS.Data.MRPlane::get_alignment()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRPlane_get_alignment_m155185C0BE923248835076D5F312EAB8C76D81B8 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Alignment; }
		int32_t L_0 = __this->get_m_Alignment_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t MRPlane_get_alignment_m155185C0BE923248835076D5F312EAB8C76D81B8_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MRPlane_get_alignment_m155185C0BE923248835076D5F312EAB8C76D81B8_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::set_alignment(Unity.MARS.Data.MarsPlaneAlignment)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane_set_alignment_m2F2D8AB55C5DFC3AFEF4082CB31EE103713A8C52 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Alignment = value; }
		int32_t L_0 = ___value0;
		__this->set_m_Alignment_2(L_0);
		// set { m_Alignment = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRPlane_set_alignment_m2F2D8AB55C5DFC3AFEF4082CB31EE103713A8C52_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MRPlane_set_alignment_m2F2D8AB55C5DFC3AFEF4082CB31EE103713A8C52_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Pose Unity.MARS.Data.MRPlane::get_pose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRPlane_get_pose_mE4641C58EB01F74D8D891840A3E704D8D3CEFAFE (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Pose; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_m_Pose_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRPlane_get_pose_mE4641C58EB01F74D8D891840A3E704D8D3CEFAFE_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  _returnValue;
	_returnValue = MRPlane_get_pose_mE4641C58EB01F74D8D891840A3E704D8D3CEFAFE_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::set_pose(UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane_set_pose_mF67BA811CD0D167A8DB12E029AE60A029194C6B3 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Pose = value; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_m_Pose_3(L_0);
		// set { m_Pose = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRPlane_set_pose_mF67BA811CD0D167A8DB12E029AE60A029194C6B3_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MRPlane_set_pose_mF67BA811CD0D167A8DB12E029AE60A029194C6B3_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector3 Unity.MARS.Data.MRPlane::get_center()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MRPlane_get_center_m6E11618D22CBC5698A010738EE249CF07B6DF3CE (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Center; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_m_Center_4();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MRPlane_get_center_m6E11618D22CBC5698A010738EE249CF07B6DF3CE_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  _returnValue;
	_returnValue = MRPlane_get_center_m6E11618D22CBC5698A010738EE249CF07B6DF3CE_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::set_center(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane_set_center_m85121C2B0A14F5FD5951D004CB954644C3DAF5EC (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Center = value; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_m_Center_4(L_0);
		// set { m_Center = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRPlane_set_center_m85121C2B0A14F5FD5951D004CB954644C3DAF5EC_AdjustorThunk (RuntimeObject * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MRPlane_set_center_m85121C2B0A14F5FD5951D004CB954644C3DAF5EC_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector2 Unity.MARS.Data.MRPlane::get_extents()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRPlane_get_extents_m63073D5F8D09129CE9D725E218EFA9E64C698D6D (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Extents; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_m_Extents_5();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRPlane_get_extents_m63073D5F8D09129CE9D725E218EFA9E64C698D6D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  _returnValue;
	_returnValue = MRPlane_get_extents_m63073D5F8D09129CE9D725E218EFA9E64C698D6D_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::set_extents(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane_set_extents_m1DDF0F993D964BD0BDC7E0C26DF0347FF7B3C058 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Extents = value; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_m_Extents_5(L_0);
		// set { m_Extents = value; }
		return;
	}
}
IL2CPP_EXTERN_C  void MRPlane_set_extents_m1DDF0F993D964BD0BDC7E0C26DF0347FF7B3C058_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	MRPlane_set_extents_m1DDF0F993D964BD0BDC7E0C26DF0347FF7B3C058_inline(_thisAdjusted, ___value0, method);
}
// System.String Unity.MARS.Data.MRPlane::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MRPlane_ToString_mEE867487721748B430A76743B47F76063E50F57C (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral128B98C2573F57B66C37CA835D0BFBA7B7C54AAE);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return String.Format(str, m_ID, m_Extents, m_Pose);
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_m_ID_1();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_1 = L_0;
		RuntimeObject * L_2 = Box(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var, &L_1);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = __this->get_m_Extents_5();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = L_3;
		RuntimeObject * L_5 = Box(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_il2cpp_TypeInfo_var, &L_4);
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_6 = __this->get_m_Pose_3();
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_7 = L_6;
		RuntimeObject * L_8 = Box(Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_il2cpp_TypeInfo_var, &L_7);
		String_t* L_9;
		L_9 = String_Format_m039737CCD992C5BFC8D16DFD681F5E8786E87FA6(_stringLiteral128B98C2573F57B66C37CA835D0BFBA7B7C54AAE, L_2, L_5, L_8, /*hidden argument*/NULL);
		return L_9;
	}
}
IL2CPP_EXTERN_C  String_t* MRPlane_ToString_mEE867487721748B430A76743B47F76063E50F57C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = MRPlane_ToString_mEE867487721748B430A76743B47F76063E50F57C(_thisAdjusted, method);
	return _returnValue;
}
// System.Int32 Unity.MARS.Data.MRPlane::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRPlane_GetHashCode_m937B78D26A641E8103F7F9CC5042E946050C5ADC (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// public override int GetHashCode() { return m_ID.GetHashCode(); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * L_0 = __this->get_address_of_m_ID_1();
		int32_t L_1;
		L_1 = MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t MRPlane_GetHashCode_m937B78D26A641E8103F7F9CC5042E946050C5ADC_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MRPlane_GetHashCode_m937B78D26A641E8103F7F9CC5042E946050C5ADC(_thisAdjusted, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MRPlane::Equals(Unity.MARS.Data.MRPlane)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRPlane_Equals_mC3884EF3958E5630E373262D2EC7F9FBDE26C1B1 (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3  ___other0, const RuntimeMethod* method)
{
	{
		// public bool Equals(MRPlane other) { return m_ID.Equals(other.m_ID); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * L_0 = __this->get_address_of_m_ID_1();
		MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3  L_1 = ___other0;
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_2 = L_1.get_m_ID_1();
		bool L_3;
		L_3 = MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)L_0, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool MRPlane_Equals_mC3884EF3958E5630E373262D2EC7F9FBDE26C1B1_AdjustorThunk (RuntimeObject * __this, MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3  ___other0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * _thisAdjusted = reinterpret_cast<MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 *>(__this + _offset);
	bool _returnValue;
	_returnValue = MRPlane_Equals_mC3884EF3958E5630E373262D2EC7F9FBDE26C1B1(_thisAdjusted, ___other0, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRPlane::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRPlane__cctor_m2E9F62DCEAC97D0FD342F226FD70D319BDB638F2 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly Vector3[] k_Corners = new Vector3[2];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)2);
		((MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_StaticFields*)il2cpp_codegen_static_fields_for(MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3_il2cpp_TypeInfo_var))->set_k_Corners_0(L_0);
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
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MRReferencePoint::get_id()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_U3CidU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  _returnValue;
	_returnValue = MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRReferencePoint::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09_AdjustorThunk (RuntimeObject * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Pose Unity.MARS.Data.MRReferencePoint::get_pose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRReferencePoint_get_pose_m7548092EC3F676CDD7FAD085B06FE4978BA326FE (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_U3CposeU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRReferencePoint_get_pose_m7548092EC3F676CDD7FAD085B06FE4978BA326FE_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  _returnValue;
	_returnValue = MRReferencePoint_get_pose_m7548092EC3F676CDD7FAD085B06FE4978BA326FE_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MRReferencePoint::set_pose(UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.Data.MRReferencePoint::set_trackingState(Unity.MARS.Data.MARSTrackingState)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public MARSTrackingState trackingState { get; set; }
		int32_t L_0 = ___value0;
		__this->set_U3CtrackingStateU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.Data.MRReferencePoint::.ctor(UnityEngine.Pose,Unity.MARS.Data.MARSTrackingState)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MRReferencePoint__ctor_m9A9913D983FE24B9733BBA1D8080683AC225923E (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___pose0, int32_t ___state1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public MRReferencePoint(Pose pose, MARSTrackingState state = MARSTrackingState.Unknown) : this()
		il2cpp_codegen_initobj(__this, sizeof(MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 ));
		// id = MarsTrackableId.Create();
		IL2CPP_RUNTIME_CLASS_INIT(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0;
		L_0 = MarsTrackableId_Create_m1AB7F8E860A28EC0D0172BDD08990815546CB637(/*hidden argument*/NULL);
		MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)__this, L_0, /*hidden argument*/NULL);
		// trackingState = state;
		int32_t L_1 = ___state1;
		MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)__this, L_1, /*hidden argument*/NULL);
		// this.pose = pose;
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_2 = ___pose0;
		MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)__this, L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void MRReferencePoint__ctor_m9A9913D983FE24B9733BBA1D8080683AC225923E_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___pose0, int32_t ___state1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	MRReferencePoint__ctor_m9A9913D983FE24B9733BBA1D8080683AC225923E(_thisAdjusted, ___pose0, ___state1, method);
}
// System.Int32 Unity.MARS.Data.MRReferencePoint::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MRReferencePoint_GetHashCode_m7B4AAA44F01A3F351ED6C61AF452431BCC9F5127 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method)
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// public override int GetHashCode() { return id.GetHashCode(); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0;
		L_0 = MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)__this, /*hidden argument*/NULL);
		V_0 = L_0;
		int32_t L_1;
		L_1 = MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)(&V_0), /*hidden argument*/NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t MRReferencePoint_GetHashCode_m7B4AAA44F01A3F351ED6C61AF452431BCC9F5127_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MRReferencePoint_GetHashCode_m7B4AAA44F01A3F351ED6C61AF452431BCC9F5127(_thisAdjusted, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MRReferencePoint::Equals(Unity.MARS.Data.MRReferencePoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MRReferencePoint_Equals_m8C6CC41619AA36A2BA0B19912720F4C6C20B4561 (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532  ___other0, const RuntimeMethod* method)
{
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// public bool Equals(MRReferencePoint other) { return id.Equals(other.id); }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0;
		L_0 = MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)__this, /*hidden argument*/NULL);
		V_0 = L_0;
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_1;
		L_1 = MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline((MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *)(&___other0), /*hidden argument*/NULL);
		bool L_2;
		L_2 = MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)(&V_0), L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  bool MRReferencePoint_Equals_m8C6CC41619AA36A2BA0B19912720F4C6C20B4561_AdjustorThunk (RuntimeObject * __this, MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532  ___other0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * _thisAdjusted = reinterpret_cast<MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 *>(__this + _offset);
	bool _returnValue;
	_returnValue = MRReferencePoint_Equals_m8C6CC41619AA36A2BA0B19912720F4C6C20B4561(_thisAdjusted, ___other0, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif


// Conversion methods for marshalling of: Unity.MARS.Data.MarsBody
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_pinvoke(const MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5& unmarshaled, MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_pinvoke& marshaled)
{
	Exception_t* ___U3CBoneLengthsU3Ek__BackingField_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<BoneLengths>k__BackingField' of type 'MarsBody'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CBoneLengthsU3Ek__BackingField_5Exception, NULL);
}
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_pinvoke_back(const MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_pinvoke& marshaled, MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5& unmarshaled)
{
	Exception_t* ___U3CBoneLengthsU3Ek__BackingField_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<BoneLengths>k__BackingField' of type 'MarsBody'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CBoneLengthsU3Ek__BackingField_5Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MarsBody
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_pinvoke_cleanup(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_pinvoke& marshaled)
{
}


// Conversion methods for marshalling of: Unity.MARS.Data.MarsBody
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_com(const MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5& unmarshaled, MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_com& marshaled)
{
	Exception_t* ___U3CBoneLengthsU3Ek__BackingField_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<BoneLengths>k__BackingField' of type 'MarsBody'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CBoneLengthsU3Ek__BackingField_5Exception, NULL);
}
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_com_back(const MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_com& marshaled, MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5& unmarshaled)
{
	Exception_t* ___U3CBoneLengthsU3Ek__BackingField_5Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<BoneLengths>k__BackingField' of type 'MarsBody'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CBoneLengthsU3Ek__BackingField_5Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.MarsBody
IL2CPP_EXTERN_C void MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshal_com_cleanup(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_marshaled_com& marshaled)
{
}
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsBody::get_id()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsBody_get_id_m25C153F5E5D66D255DF989B64D7B6192BE9E629D (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_U3CidU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsBody_get_id_m25C153F5E5D66D255DF989B64D7B6192BE9E629D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  _returnValue;
	_returnValue = MarsBody_get_id_m25C153F5E5D66D255DF989B64D7B6192BE9E629D_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MarsBody::set_id(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsBody_set_id_m909CFE33F3D1DC3505310B71A63E64CE8A2FDCAC (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MarsBody_set_id_m909CFE33F3D1DC3505310B71A63E64CE8A2FDCAC_AdjustorThunk (RuntimeObject * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	MarsBody_set_id_m909CFE33F3D1DC3505310B71A63E64CE8A2FDCAC_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Pose Unity.MARS.Data.MarsBody::get_pose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MarsBody_get_pose_m24FD3A349D2EB7D56C6C596DB17C2706DF655B1E (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_U3CposeU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MarsBody_get_pose_m24FD3A349D2EB7D56C6C596DB17C2706DF655B1E_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  _returnValue;
	_returnValue = MarsBody_get_pose_m24FD3A349D2EB7D56C6C596DB17C2706DF655B1E_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MarsBody::set_pose(UnityEngine.Pose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsBody_set_pose_mF77B965C8146F5CB58A315B4B43525162C2114F4 (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MarsBody_set_pose_mF77B965C8146F5CB58A315B4B43525162C2114F4_AdjustorThunk (RuntimeObject * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	MarsBody_set_pose_mF77B965C8146F5CB58A315B4B43525162C2114F4_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.HumanPose Unity.MARS.Data.MarsBody::get_BodyPose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  MarsBody_get_BodyPose_m872C60DB6506A83284C2E515AA3136866C7789CA (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public HumanPose BodyPose { get; set; }
		HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  L_0 = __this->get_U3CBodyPoseU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  MarsBody_get_BodyPose_m872C60DB6506A83284C2E515AA3136866C7789CA_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  _returnValue;
	_returnValue = MarsBody_get_BodyPose_m872C60DB6506A83284C2E515AA3136866C7789CA_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MarsBody::set_BodyPose(UnityEngine.HumanPose)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsBody_set_BodyPose_mBC26E9630954F96ACDD3DEA78C71ABE619F21593 (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  ___value0, const RuntimeMethod* method)
{
	{
		// public HumanPose BodyPose { get; set; }
		HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  L_0 = ___value0;
		__this->set_U3CBodyPoseU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MarsBody_set_BodyPose_mBC26E9630954F96ACDD3DEA78C71ABE619F21593_AdjustorThunk (RuntimeObject * __this, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	MarsBody_set_BodyPose_mBC26E9630954F96ACDD3DEA78C71ABE619F21593_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.Data.MarsBody::get_Height()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsBody_get_Height_m023FF0CA8628FCAB3790366F71753C534075D565 (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public float Height { get; set; }
		float L_0 = __this->get_U3CHeightU3Ek__BackingField_4();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float MarsBody_get_Height_m023FF0CA8628FCAB3790366F71753C534075D565_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	float _returnValue;
	_returnValue = MarsBody_get_Height_m023FF0CA8628FCAB3790366F71753C534075D565_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.Data.MarsBody::set_Height(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsBody_set_Height_mEB8A9CA1F4DF0E81E605605FE0B96BC41C3DB323 (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float Height { get; set; }
		float L_0 = ___value0;
		__this->set_U3CHeightU3Ek__BackingField_4(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void MarsBody_set_Height_mEB8A9CA1F4DF0E81E605605FE0B96BC41C3DB323_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * _thisAdjusted = reinterpret_cast<MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 *>(__this + _offset);
	MarsBody_set_Height_mEB8A9CA1F4DF0E81E605605FE0B96BC41C3DB323_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.Data.MarsBody::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsBody__cctor_mF08EE647CBA504A65D9BFC06F5AC2B0E89FE3102 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static float BodyDefaultHeight = 1.7216285067479f; // Estimate of the Unity default avatar height that also matches with the ARKit control rig
		((MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_StaticFields*)il2cpp_codegen_static_fields_for(MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5_il2cpp_TypeInfo_var))->set_BodyDefaultHeight_0((1.72162855f));
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
// System.Single Unity.MARS.Simulation.MarsTime::get_Time()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTime_get_Time_m7FE61326BD3C01DE690D9F84260DD40438BD5901 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static float Time { get; internal set; }
		float L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_U3CTimeU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::set_Time(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_set_Time_mCF8AECB37AA629E764466A0BC9858EC145DD2721 (float ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static float Time { get; internal set; }
		float L_0 = ___value0;
		((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->set_U3CTimeU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Single Unity.MARS.Simulation.MarsTime::get_TimeStep()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTime_get_TimeStep_m5A06E075EFBDE148742A1BF398864F0A929034FE (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static float TimeStep { get; internal set; }
		float L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_U3CTimeStepU3Ek__BackingField_1();
		return L_0;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::set_TimeStep(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_set_TimeStep_m244A9D3577A28DC8AC3F02F50880F2E48DC02BD3 (float ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static float TimeStep { get; internal set; }
		float L_0 = ___value0;
		((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->set_U3CTimeStepU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Int32 Unity.MARS.Simulation.MarsTime::get_FrameCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MarsTime_get_FrameCount_m6C0FAB585A0BA7ED0AB113FA204264CF01EC8075 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static int FrameCount { get; internal set; }
		int32_t L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_U3CFrameCountU3Ek__BackingField_2();
		return L_0;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::set_FrameCount(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_set_FrameCount_m42442267F96956EF012BD9121CF3FBA24C3EDAEF (int32_t ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static int FrameCount { get; internal set; }
		int32_t L_0 = ___value0;
		((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->set_U3CFrameCountU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Boolean Unity.MARS.Simulation.MarsTime::get_Paused()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTime_get_Paused_m3B9D7BC3B61DF08966A3058BC5544B9584DC971E (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool Paused { get; internal set; }
		bool L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_U3CPausedU3Ek__BackingField_3();
		return L_0;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::set_Paused(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_set_Paused_m0F0A3AB42501C6CAD6CED258B8C367F6A699F9BB (bool ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool Paused { get; internal set; }
		bool L_0 = ___value0;
		((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->set_U3CPausedU3Ek__BackingField_3(L_0);
		return;
	}
}
// System.Single Unity.MARS.Simulation.MarsTime::get_TimeScale()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTime_get_TimeScale_m78430947F9BE9624D3068647C105B50465909CEB (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// get => MarsTimeDelegates.GetTimeScale();
		IL2CPP_RUNTIME_CLASS_INIT(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * L_0 = ((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->get_GetTimeScale_0();
		NullCheck(L_0);
		float L_1;
		L_1 = Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36(L_0, /*hidden argument*/Func_1_Invoke_m4E9D5F4972EB90B5E743AE7F1E0AFF84FE3A7E36_RuntimeMethod_var);
		return L_1;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::set_TimeScale(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_set_TimeScale_mEA753348D8EC0EF76966D684DF65DD0B60682AA1 (float ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// set => MarsTimeDelegates.SetTimeScale(value);
		IL2CPP_RUNTIME_CLASS_INIT(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_0 = ((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->get_SetTimeScale_1();
		float L_1 = ___value0;
		NullCheck(L_0);
		Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E(L_0, L_1, /*hidden argument*/Action_1_Invoke_mB4E4B9A52AFDB6F7EF89A35E53068E836B1C312E_RuntimeMethod_var);
		return;
	}
}
// System.Single Unity.MARS.Simulation.MarsTime::get_ScaledDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTime_get_ScaledDeltaTime_m12453B972A79F5D518898B40807649780C61858F (const RuntimeMethod* method)
{
	{
		// public static float ScaledDeltaTime => UnityEngine.Time.deltaTime * TimeScale;
		float L_0;
		L_0 = Time_get_deltaTime_mCC15F147DA67F38C74CE408FB5D7FF4A87DA2290(/*hidden argument*/NULL);
		float L_1;
		L_1 = MarsTime_get_TimeScale_m78430947F9BE9624D3068647C105B50465909CEB(/*hidden argument*/NULL);
		return ((float)il2cpp_codegen_multiply((float)L_0, (float)L_1));
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::add_MarsUpdate(System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_add_MarsUpdate_m3A251942194C32A68D98F0B5E2BCEA78CA1D4C36 (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_0 = NULL;
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_1 = NULL;
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_2 = NULL;
	{
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_MarsUpdate_4();
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_1 = V_0;
		V_1 = L_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = V_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)CastclassSealed((RuntimeObject*)L_4, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var));
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_5 = V_2;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_6 = V_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *>((Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 **)(((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_address_of_MarsUpdate_4()), L_5, L_6);
		V_0 = L_7;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_8 = V_0;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)L_8) == ((RuntimeObject*)(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::remove_MarsUpdate(System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_remove_MarsUpdate_mA5610FEC23CDFBF5D55D953F05AC8BA75926524A (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_0 = NULL;
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_1 = NULL;
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * V_2 = NULL;
	{
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_MarsUpdate_4();
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_1 = V_0;
		V_1 = L_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = V_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)CastclassSealed((RuntimeObject*)L_4, Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var));
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_5 = V_2;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_6 = V_1;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *>((Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 **)(((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_address_of_MarsUpdate_4()), L_5, L_6);
		V_0 = L_7;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_8 = V_0;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)L_8) == ((RuntimeObject*)(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::Pause()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_Pause_mB2051B5E05317322185172B64A5D94F31E9BA4CA (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static void Pause() { MarsTimeDelegates.Pause(); }
		IL2CPP_RUNTIME_CLASS_INIT(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = ((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->get_Pause_2();
		NullCheck(L_0);
		Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E(L_0, /*hidden argument*/NULL);
		// public static void Pause() { MarsTimeDelegates.Pause(); }
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::Play()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_Play_mFC6BA734B1D1A9A0AADC526739A8300AAA30880A (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static void Play() { MarsTimeDelegates.Play(); }
		IL2CPP_RUNTIME_CLASS_INIT(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = ((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->get_Play_3();
		NullCheck(L_0);
		Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E(L_0, /*hidden argument*/NULL);
		// public static void Play() { MarsTimeDelegates.Play(); }
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTime::InvokeMarsUpdate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTime_InvokeMarsUpdate_m142A94A394540B84CA722912763D28200AD7ED3A (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * G_B2_0 = NULL;
	Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * G_B1_0 = NULL;
	{
		// internal static void InvokeMarsUpdate() { MarsUpdate?.Invoke(); }
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_0 = ((MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_StaticFields*)il2cpp_codegen_static_fields_for(MarsTime_t1469620C8F3FFF193676B7B6C8FC9BE6558E313B_il2cpp_TypeInfo_var))->get_MarsUpdate_4();
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000a;
		}
	}
	{
		return;
	}

IL_000a:
	{
		NullCheck(G_B2_0);
		Action_Invoke_m3FFA5BE3D64F0FF8E1E1CB6F953913FADB5EB89E(G_B2_0, /*hidden argument*/NULL);
		// internal static void InvokeMarsUpdate() { MarsUpdate?.Invoke(); }
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
// System.Void Unity.MARS.Simulation.MarsTimeDelegates::ResetDelegates()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTimeDelegates_ResetDelegates_m875353040846B4AC06C9AB81A12C1E346318B98F (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// GetTimeScale = GetTimeScaleNoop;
		Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * L_0 = (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 *)il2cpp_codegen_object_new(Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740_il2cpp_TypeInfo_var);
		Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7(L_0, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE_RuntimeMethod_var), /*hidden argument*/Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_RuntimeMethod_var);
		IL2CPP_RUNTIME_CLASS_INIT(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_GetTimeScale_0(L_0);
		// SetTimeScale = SetTimeScaleNoop;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_1 = (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *)il2cpp_codegen_object_new(Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9_il2cpp_TypeInfo_var);
		Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3(L_1, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_RuntimeMethod_var);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_SetTimeScale_1(L_1);
		// Pause = PauseNoop;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)il2cpp_codegen_object_new(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		Action__ctor_m07BE5EE8A629FBBA52AE6356D57A0D371BE2574B(L_2, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E_RuntimeMethod_var), /*hidden argument*/NULL);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_Pause_2(L_2);
		// Play = PlayNoop;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_3 = (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)il2cpp_codegen_object_new(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		Action__ctor_m07BE5EE8A629FBBA52AE6356D57A0D371BE2574B(L_3, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5_RuntimeMethod_var), /*hidden argument*/NULL);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_Play_3(L_3);
		// }
		return;
	}
}
// System.Single Unity.MARS.Simulation.MarsTimeDelegates::GetTimeScaleNoop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE (const RuntimeMethod* method)
{
	{
		// return 1f;
		return (1.0f);
	}
}
// System.Void Unity.MARS.Simulation.MarsTimeDelegates::SetTimeScaleNoop(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81 (float ___timeScale0, const RuntimeMethod* method)
{
	{
		// static void SetTimeScaleNoop(float timeScale) { }
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTimeDelegates::PauseNoop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E (const RuntimeMethod* method)
{
	{
		// static void PauseNoop() { }
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTimeDelegates::PlayNoop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5 (const RuntimeMethod* method)
{
	{
		// static void PlayNoop() { }
		return;
	}
}
// System.Void Unity.MARS.Simulation.MarsTimeDelegates::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTimeDelegates__cctor_mCB9E7AC356FAC8ED74FC08989161C8D69C9AE73E (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static Func<float> GetTimeScale = GetTimeScaleNoop;
		Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 * L_0 = (Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740 *)il2cpp_codegen_object_new(Func_1_tC701B36C6B4955F26580F8E98470FE5E8B3A0740_il2cpp_TypeInfo_var);
		Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7(L_0, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_GetTimeScaleNoop_m77C17677C18524B3C184BD182EA3E1E366CF5ECE_RuntimeMethod_var), /*hidden argument*/Func_1__ctor_m52979AD41B3418EBAD720F71C4CBA9E14DA7AFC7_RuntimeMethod_var);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_GetTimeScale_0(L_0);
		// public static Action<float> SetTimeScale = SetTimeScaleNoop;
		Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 * L_1 = (Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9 *)il2cpp_codegen_object_new(Action_1_t14225BCEFEF7A87B9836BA1CC40C611E313112D9_il2cpp_TypeInfo_var);
		Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3(L_1, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_SetTimeScaleNoop_m8E2CF28170AD64A20A616F3D41855D871CFDDF81_RuntimeMethod_var), /*hidden argument*/Action_1__ctor_m7514CC492FC5E63D7FA62E0FB54CF5E5956D8EC3_RuntimeMethod_var);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_SetTimeScale_1(L_1);
		// public static Action Pause = PauseNoop;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_2 = (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)il2cpp_codegen_object_new(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		Action__ctor_m07BE5EE8A629FBBA52AE6356D57A0D371BE2574B(L_2, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_PauseNoop_m477D2DC2AF52375EB6AE3483B46E6F08E598353E_RuntimeMethod_var), /*hidden argument*/NULL);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_Pause_2(L_2);
		// public static Action Play = PlayNoop;
		Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 * L_3 = (Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6 *)il2cpp_codegen_object_new(Action_tAF41423D285AE0862865348CF6CE51CD085ABBA6_il2cpp_TypeInfo_var);
		Action__ctor_m07BE5EE8A629FBBA52AE6356D57A0D371BE2574B(L_3, NULL, (intptr_t)((intptr_t)MarsTimeDelegates_PlayNoop_m53DCACA83B6DEBABB8DFE7EBAED09A8001B763C5_RuntimeMethod_var), /*hidden argument*/NULL);
		((MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_StaticFields*)il2cpp_codegen_static_fields_for(MarsTimeDelegates_t9171C5F9DDEC33CFC2089815EA957E571D57C3ED_il2cpp_TypeInfo_var))->set_Play_3(L_3);
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
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsTrackableId::get_InvalidId()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsTrackableId_get_InvalidId_m36D56EDE0CD68673ABE62FA32519A7B1C6085E71 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static MarsTrackableId InvalidId => k_InvalidId;
		IL2CPP_RUNTIME_CLASS_INIT(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields*)il2cpp_codegen_static_fields_for(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var))->get_k_InvalidId_1();
		return L_0;
	}
}
// System.String Unity.MARS.Data.MarsTrackableId::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* MarsTrackableId_ToString_m0FA72ACB28488E82AB45B3C5FDF32F30BBDBC806 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFBAF124AB08242B7785EC2B6DBC3C6459CB98BC8);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFDA1C52D0E58360F4E8FD608757CCD98D8772D4F);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return string.Format("{0}-{1}", m_SubId1.ToString("X16", CultureInfo.InvariantCulture),
		//     m_SubId2.ToString("X16", CultureInfo.InvariantCulture));
		uint64_t* L_0 = __this->get_address_of_m_SubId1_4();
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98_il2cpp_TypeInfo_var);
		CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * L_1;
		L_1 = CultureInfo_get_InvariantCulture_m9FAAFAF8A00091EE1FCB7098AD3F163ECDF02164(/*hidden argument*/NULL);
		String_t* L_2;
		L_2 = UInt64_ToString_mD0F3D7511719711F9E78F0EBC578FFE6C05320B5((uint64_t*)L_0, _stringLiteralFDA1C52D0E58360F4E8FD608757CCD98D8772D4F, L_1, /*hidden argument*/NULL);
		uint64_t* L_3 = __this->get_address_of_m_SubId2_5();
		CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * L_4;
		L_4 = CultureInfo_get_InvariantCulture_m9FAAFAF8A00091EE1FCB7098AD3F163ECDF02164(/*hidden argument*/NULL);
		String_t* L_5;
		L_5 = UInt64_ToString_mD0F3D7511719711F9E78F0EBC578FFE6C05320B5((uint64_t*)L_3, _stringLiteralFDA1C52D0E58360F4E8FD608757CCD98D8772D4F, L_4, /*hidden argument*/NULL);
		String_t* L_6;
		L_6 = String_Format_m8D1CB0410C35E052A53AE957C914C841E54BAB66(_stringLiteralFBAF124AB08242B7785EC2B6DBC3C6459CB98BC8, L_2, L_5, /*hidden argument*/NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C  String_t* MarsTrackableId_ToString_m0FA72ACB28488E82AB45B3C5FDF32F30BBDBC806_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * _thisAdjusted = reinterpret_cast<MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = MarsTrackableId_ToString_m0FA72ACB28488E82AB45B3C5FDF32F30BBDBC806(_thisAdjusted, method);
	return _returnValue;
}
// System.Int32 Unity.MARS.Data.MarsTrackableId::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, const RuntimeMethod* method)
{
	{
		// return m_SubId1.GetHashCode() ^ m_SubId2.GetHashCode();
		uint64_t* L_0 = __this->get_address_of_m_SubId1_4();
		int32_t L_1;
		L_1 = UInt64_GetHashCode_mCDF662897A3F02CED11A9F9E66C5BF4E28C02B33((uint64_t*)L_0, /*hidden argument*/NULL);
		uint64_t* L_2 = __this->get_address_of_m_SubId2_5();
		int32_t L_3;
		L_3 = UInt64_GetHashCode_mCDF662897A3F02CED11A9F9E66C5BF4E28C02B33((uint64_t*)L_2, /*hidden argument*/NULL);
		return ((int32_t)((int32_t)L_1^(int32_t)L_3));
	}
}
IL2CPP_EXTERN_C  int32_t MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * _thisAdjusted = reinterpret_cast<MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = MarsTrackableId_GetHashCode_m1872059E9127AB4665A84EE48004DA9DAD6F8F55(_thisAdjusted, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MarsTrackableId::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_Equals_mC77854B7AE17150C6C41722ABDF39A2DC758644B (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj is MarsTrackableId && Equals((MarsTrackableId) obj);
		RuntimeObject * L_0 = ___obj0;
		if (!((RuntimeObject *)IsInstSealed((RuntimeObject*)L_0, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var)))
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject * L_1 = ___obj0;
		bool L_2;
		L_2 = MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)__this, ((*(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *)UnBox(L_1, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
		return L_2;
	}

IL_0015:
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C  bool MarsTrackableId_Equals_mC77854B7AE17150C6C41722ABDF39A2DC758644B_AdjustorThunk (RuntimeObject * __this, RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * _thisAdjusted = reinterpret_cast<MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *>(__this + _offset);
	bool _returnValue;
	_returnValue = MarsTrackableId_Equals_mC77854B7AE17150C6C41722ABDF39A2DC758644B(_thisAdjusted, ___obj0, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MarsTrackableId::Equals(Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___other0, const RuntimeMethod* method)
{
	{
		// return m_SubId1 == other.m_SubId1 && m_SubId2 == other.m_SubId2;
		uint64_t L_0 = __this->get_m_SubId1_4();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_1 = ___other0;
		uint64_t L_2 = L_1.get_m_SubId1_4();
		if ((!(((uint64_t)L_0) == ((uint64_t)L_2))))
		{
			goto IL_001d;
		}
	}
	{
		uint64_t L_3 = __this->get_m_SubId2_5();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_4 = ___other0;
		uint64_t L_5 = L_4.get_m_SubId2_5();
		return (bool)((((int64_t)L_3) == ((int64_t)L_5))? 1 : 0);
	}

IL_001d:
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C  bool MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612_AdjustorThunk (RuntimeObject * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___other0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * _thisAdjusted = reinterpret_cast<MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *>(__this + _offset);
	bool _returnValue;
	_returnValue = MarsTrackableId_Equals_mE632E3571C6FD3B7CF821905B70C8818E4B55612(_thisAdjusted, ___other0, method);
	return _returnValue;
}
// System.Boolean Unity.MARS.Data.MarsTrackableId::op_Equality(Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_op_Equality_m30180FE8C038A27028D1FE203504E523B02C024B (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___id10, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___id21, const RuntimeMethod* method)
{
	{
		// return id1.m_SubId1 == id2.m_SubId1 && id1.m_SubId2 == id2.m_SubId2;
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___id10;
		uint64_t L_1 = L_0.get_m_SubId1_4();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_2 = ___id21;
		uint64_t L_3 = L_2.get_m_SubId1_4();
		if ((!(((uint64_t)L_1) == ((uint64_t)L_3))))
		{
			goto IL_001d;
		}
	}
	{
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_4 = ___id10;
		uint64_t L_5 = L_4.get_m_SubId2_5();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_6 = ___id21;
		uint64_t L_7 = L_6.get_m_SubId2_5();
		return (bool)((((int64_t)L_5) == ((int64_t)L_7))? 1 : 0);
	}

IL_001d:
	{
		return (bool)0;
	}
}
// System.Boolean Unity.MARS.Data.MarsTrackableId::op_Inequality(Unity.MARS.Data.MarsTrackableId,Unity.MARS.Data.MarsTrackableId)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MarsTrackableId_op_Inequality_mDDC0ED2ACB6539BE80FE59439FB3793EB00DCF21 (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___id10, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___id21, const RuntimeMethod* method)
{
	{
		// return id1.m_SubId1 != id2.m_SubId1 || id1.m_SubId2 != id2.m_SubId2;
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___id10;
		uint64_t L_1 = L_0.get_m_SubId1_4();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_2 = ___id21;
		uint64_t L_3 = L_2.get_m_SubId1_4();
		if ((!(((uint64_t)L_1) == ((uint64_t)L_3))))
		{
			goto IL_0020;
		}
	}
	{
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_4 = ___id10;
		uint64_t L_5 = L_4.get_m_SubId2_5();
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_6 = ___id21;
		uint64_t L_7 = L_6.get_m_SubId2_5();
		return (bool)((((int32_t)((((int64_t)L_5) == ((int64_t)L_7))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}

IL_0020:
	{
		return (bool)1;
	}
}
// System.Void Unity.MARS.Data.MarsTrackableId::.ctor(System.UInt64,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTrackableId__ctor_m3C2FA6CC39FD7DE59BB4527ADC110B24C571E09F (MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * __this, uint64_t ___idOne0, uint64_t ___idTwo1, const RuntimeMethod* method)
{
	{
		// m_SubId1 = idOne;
		uint64_t L_0 = ___idOne0;
		__this->set_m_SubId1_4(L_0);
		// m_SubId2 = idTwo;
		uint64_t L_1 = ___idTwo1;
		__this->set_m_SubId2_5(L_1);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void MarsTrackableId__ctor_m3C2FA6CC39FD7DE59BB4527ADC110B24C571E09F_AdjustorThunk (RuntimeObject * __this, uint64_t ___idOne0, uint64_t ___idTwo1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 * _thisAdjusted = reinterpret_cast<MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60 *>(__this + _offset);
	MarsTrackableId__ctor_m3C2FA6CC39FD7DE59BB4527ADC110B24C571E09F(_thisAdjusted, ___idOne0, ___idTwo1, method);
}
// Unity.MARS.Data.MarsTrackableId Unity.MARS.Data.MarsTrackableId::Create()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsTrackableId_Create_m1AB7F8E860A28EC0D0172BDD08990815546CB637 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new MarsTrackableId(k_CreationSubIdOne, s_IdTwoCounter++);
		IL2CPP_RUNTIME_CLASS_INIT(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		uint64_t L_0 = ((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields*)il2cpp_codegen_static_fields_for(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var))->get_s_IdTwoCounter_3();
		uint64_t L_1 = L_0;
		((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields*)il2cpp_codegen_static_fields_for(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var))->set_s_IdTwoCounter_3(((int64_t)il2cpp_codegen_add((int64_t)L_1, (int64_t)((int64_t)((int64_t)1)))));
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_2;
		memset((&L_2), 0, sizeof(L_2));
		MarsTrackableId__ctor_m3C2FA6CC39FD7DE59BB4527ADC110B24C571E09F((&L_2), ((int64_t)((int64_t)(-1))), L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void Unity.MARS.Data.MarsTrackableId::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MarsTrackableId__cctor_m02558318E42B9B04D1EC16423F65E86ED6860A78 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly ulong k_StringSubIdOne = 1ul;
		((MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_StaticFields*)il2cpp_codegen_static_fields_for(MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60_il2cpp_TypeInfo_var))->set_k_StringSubIdOne_2(((int64_t)((int64_t)1)));
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
// Conversion methods for marshalling of: Unity.MARS.Data.PointCloudData
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_pinvoke(const PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8& unmarshaled, PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_pinvoke& marshaled)
{
	Exception_t* ___Identifiers_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'Identifiers' of type 'PointCloudData'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___Identifiers_0Exception, NULL);
}
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_pinvoke_back(const PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_pinvoke& marshaled, PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8& unmarshaled)
{
	Exception_t* ___Identifiers_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'Identifiers' of type 'PointCloudData'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___Identifiers_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.PointCloudData
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_pinvoke_cleanup(PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.Data.PointCloudData
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_com(const PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8& unmarshaled, PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_com& marshaled)
{
	Exception_t* ___Identifiers_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'Identifiers' of type 'PointCloudData'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___Identifiers_0Exception, NULL);
}
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_com_back(const PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_com& marshaled, PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8& unmarshaled)
{
	Exception_t* ___Identifiers_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'Identifiers' of type 'PointCloudData'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___Identifiers_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.Data.PointCloudData
IL2CPP_EXTERN_C void PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshal_com_cleanup(PointCloudData_tE3BB767D021A1300A6071AECD2A71690619B97F8_marshaled_com& marshaled)
{
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
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 (ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 * __this, float ___upload0, float ___download1, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(float, float);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(((RuntimeDelegate*)__this)->method->nativeFunction);

	// Native function invocation
	il2cppPInvokeFunc(___upload0, ___download1);

}
// System.Void Unity.MARS.Data.ProgressCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProgressCallback__ctor_mD4F85A2A4B3B19CD734E635EAADB413A04841995 (ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void Unity.MARS.Data.ProgressCallback::Invoke(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProgressCallback_Invoke_mDDB082EA21492A9346066AE1A8779E61C9EFA5D7 (ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 * __this, float ___upload0, float ___download1, const RuntimeMethod* method)
{
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* delegateArrayToInvoke = __this->get_delegates_11();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = delegateArrayToInvoke->max_length;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_2();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 2)
			{
				// open
				typedef void (*FunctionPointerType) (float, float, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___upload0, ___download1, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, float, float, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___upload0, ___download1, targetMethod);
			}
		}
		else
		{
			// closed
			if (targetThis != NULL && il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_generic_instance(targetMethod))
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						GenericInterfaceActionInvoker2< float, float >::Invoke(targetMethod, targetThis, ___upload0, ___download1);
					else
						GenericVirtActionInvoker2< float, float >::Invoke(targetMethod, targetThis, ___upload0, ___download1);
				}
				else
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						InterfaceActionInvoker2< float, float >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___upload0, ___download1);
					else
						VirtActionInvoker2< float, float >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___upload0, ___download1);
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, float, float, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___upload0, ___download1, targetMethod);
			}
		}
	}
}
// System.IAsyncResult Unity.MARS.Data.ProgressCallback::BeginInvoke(System.Single,System.Single,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ProgressCallback_BeginInvoke_m5E44EDE7EFEEF955DE0DF7802F0106B11ADE7D1D (ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 * __this, float ___upload0, float ___download1, AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___callback2, RuntimeObject * ___object3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[3] = {0};
	__d_args[0] = Box(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var, &___upload0);
	__d_args[1] = Box(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var, &___download1);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);;
}
// System.Void Unity.MARS.Data.ProgressCallback::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProgressCallback_EndInvoke_m6775852C2392D357ACC763EB487F714B53785AD3 (ProgressCallback_t54A00D9488397895B01B43E8AEE7456451E221F3 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
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
// System.String Unity.MARS.Data.SerializedTraitRequirement::get_TraitName()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public string TraitName => m_TraitName;
		String_t* L_0 = __this->get_m_TraitName_0();
		return L_0;
	}
}
// System.Boolean Unity.MARS.Data.SerializedTraitRequirement::get_Required()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public bool Required => m_Required;
		bool L_0 = __this->get_m_Required_2();
		return L_0;
	}
}
// System.String Unity.MARS.Data.SerializedTraitRequirement::get_TypeName()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public string TypeName => m_TypeName;
		String_t* L_0 = __this->get_m_TypeName_1();
		return L_0;
	}
}
// System.Void Unity.MARS.Data.SerializedTraitRequirement::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SerializedTraitRequirement__ctor_mCF73DCACFC042B37AF6DE76AAF0A67AF83BD91E3 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public SerializedTraitRequirement() { }
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// public SerializedTraitRequirement() { }
		return;
	}
}
// System.Void Unity.MARS.Data.SerializedTraitRequirement::.ctor(Unity.MARS.Query.TraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SerializedTraitRequirement__ctor_mA47EFECC27C539F5C6CC214B5BAFD15AA3FE95DB (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * ___requirement0, const RuntimeMethod* method)
{
	{
		// public SerializedTraitRequirement(TraitRequirement requirement)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// m_TraitName = requirement.TraitName;
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_0 = ___requirement0;
		NullCheck(L_0);
		String_t* L_1;
		L_1 = TraitRequirement_get_TraitName_mFDCD39504376698867BFBC05E66DCB08CB5855B2(L_0, /*hidden argument*/NULL);
		__this->set_m_TraitName_0(L_1);
		// m_TypeName = requirement.Type.AssemblyQualifiedName;
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_2 = ___requirement0;
		NullCheck(L_2);
		Type_t * L_3;
		L_3 = TraitRequirement_get_Type_m1EFEB92F45AA34D34B8BF34E3706EFDE64571186(L_2, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4;
		L_4 = VirtFuncInvoker0< String_t* >::Invoke(27 /* System.String System.Type::get_AssemblyQualifiedName() */, L_3);
		__this->set_m_TypeName_1(L_4);
		// m_Required = requirement.Required;
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_5 = ___requirement0;
		NullCheck(L_5);
		bool L_6 = L_5->get_Required_0();
		__this->set_m_Required_2(L_6);
		// }
		return;
	}
}
// System.Boolean Unity.MARS.Data.SerializedTraitRequirement::Equals(Unity.MARS.Data.SerializedTraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool SerializedTraitRequirement_Equals_m76EBFC940C278EA090BEC21AEA80D4B4A10ED900 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * ___other0, const RuntimeMethod* method)
{
	{
		// if (ReferenceEquals(null, other))
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_0 = ___other0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0005:
	{
		// if (ReferenceEquals(this, other))
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_1 = ___other0;
		if ((!(((RuntimeObject*)(SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 *)__this) == ((RuntimeObject*)(SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 *)L_1))))
		{
			goto IL_000b;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_000b:
	{
		// return string.Equals(m_TraitName, other.TraitName) && string.Equals(TypeName, other.TypeName);
		String_t* L_2 = __this->get_m_TraitName_0();
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_3 = ___other0;
		NullCheck(L_3);
		String_t* L_4;
		L_4 = SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline(L_3, /*hidden argument*/NULL);
		bool L_5;
		L_5 = String_Equals_mAFC6038D294F341434D9D67D7EADC7F97C556C9B(L_2, L_4, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_0030;
		}
	}
	{
		String_t* L_6;
		L_6 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(__this, /*hidden argument*/NULL);
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_7 = ___other0;
		NullCheck(L_7);
		String_t* L_8;
		L_8 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(L_7, /*hidden argument*/NULL);
		bool L_9;
		L_9 = String_Equals_mAFC6038D294F341434D9D67D7EADC7F97C556C9B(L_6, L_8, /*hidden argument*/NULL);
		return L_9;
	}

IL_0030:
	{
		return (bool)0;
	}
}
// System.Int32 Unity.MARS.Data.SerializedTraitRequirement::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SerializedTraitRequirement_GetHashCode_mAACDF44C263A37C51FE2953115E53F56654BEBAB (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// return (TraitName.GetHashCode() * 397) ^ TypeName.GetHashCode();
		String_t* L_0;
		L_0 = SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_0);
		String_t* L_2;
		L_2 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(__this, /*hidden argument*/NULL);
		NullCheck(L_2);
		int32_t L_3;
		L_3 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_2);
		return ((int32_t)((int32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_1, (int32_t)((int32_t)397)))^(int32_t)L_3));
	}
}
// System.String Unity.MARS.Data.SerializedTraitRequirement::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_ToString_m58E23A1D4B6C3F2D952217E41E356925C3B9C4D3 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0C945050B544C3CEF12A4D3D681756769325C196);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral42A9A87BB25BE5C8E1B19AD8D192A0E734A5609A);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return $"trait: '{TraitName}', type: {TypeName}";
		String_t* L_0;
		L_0 = SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline(__this, /*hidden argument*/NULL);
		String_t* L_1;
		L_1 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(__this, /*hidden argument*/NULL);
		String_t* L_2;
		L_2 = String_Concat_m37A5BF26F8F8F1892D60D727303B23FB604FEE78(_stringLiteral0C945050B544C3CEF12A4D3D681756769325C196, L_0, _stringLiteral42A9A87BB25BE5C8E1B19AD8D192A0E734A5609A, L_1, /*hidden argument*/NULL);
		return L_2;
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
// System.Void Unity.MARS.Data.TraitDefinition::.ctor(System.String,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, String_t* ___traitName0, Type_t * ___type1, const RuntimeMethod* method)
{
	{
		// public TraitDefinition(string traitName, Type type)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// TraitName = traitName;
		String_t* L_0 = ___traitName0;
		__this->set_TraitName_0(L_0);
		// Type = type;
		Type_t * L_1 = ___type1;
		__this->set_Type_1(L_1);
		// }
		return;
	}
}
// System.Boolean Unity.MARS.Data.TraitDefinition::Equals(Unity.MARS.Data.TraitDefinition)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TraitDefinition_Equals_mF0D8ADEB9230BC3BCDDDB26A6A33CA13D0B687C1 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___other0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (ReferenceEquals(null, other))
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = ___other0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0005:
	{
		// if (ReferenceEquals(this, other))
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_1 = ___other0;
		if ((!(((RuntimeObject*)(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)__this) == ((RuntimeObject*)(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)L_1))))
		{
			goto IL_000b;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_000b:
	{
		// return string.Equals(TraitName, other.TraitName) && Type == other.Type;
		String_t* L_2 = __this->get_TraitName_0();
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_3 = ___other0;
		NullCheck(L_3);
		String_t* L_4 = L_3->get_TraitName_0();
		bool L_5;
		L_5 = String_Equals_mAFC6038D294F341434D9D67D7EADC7F97C556C9B(L_2, L_4, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_0030;
		}
	}
	{
		Type_t * L_6 = __this->get_Type_1();
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_7 = ___other0;
		NullCheck(L_7);
		Type_t * L_8 = L_7->get_Type_1();
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		bool L_9;
		L_9 = Type_op_Equality_mA438719A1FDF103C7BBBB08AEF564E7FAEEA0046(L_6, L_8, /*hidden argument*/NULL);
		return L_9;
	}

IL_0030:
	{
		return (bool)0;
	}
}
// System.Boolean Unity.MARS.Data.TraitDefinition::Equals(Unity.MARS.Query.TraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TraitDefinition_Equals_m198AF253E5C39C3A928967FA1FC578C15F41B7C4 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (obj == null)
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_0 = ___obj0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0005:
	{
		// return obj.TraitName == TraitName && obj.Type == Type;
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_1 = ___obj0;
		NullCheck(L_1);
		String_t* L_2;
		L_2 = TraitRequirement_get_TraitName_mFDCD39504376698867BFBC05E66DCB08CB5855B2(L_1, /*hidden argument*/NULL);
		String_t* L_3 = __this->get_TraitName_0();
		bool L_4;
		L_4 = String_op_Equality_m2B91EE68355F142F67095973D32EB5828B7B73CB(L_2, L_3, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_002a;
		}
	}
	{
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_5 = ___obj0;
		NullCheck(L_5);
		Type_t * L_6;
		L_6 = TraitRequirement_get_Type_m1EFEB92F45AA34D34B8BF34E3706EFDE64571186(L_5, /*hidden argument*/NULL);
		Type_t * L_7 = __this->get_Type_1();
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		bool L_8;
		L_8 = Type_op_Equality_mA438719A1FDF103C7BBBB08AEF564E7FAEEA0046(L_6, L_7, /*hidden argument*/NULL);
		return L_8;
	}

IL_002a:
	{
		return (bool)0;
	}
}
// System.Int32 Unity.MARS.Data.TraitDefinition::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TraitDefinition_GetHashCode_m5346EF97C8ED5B62575F165A5167A405CB738BC6 (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, const RuntimeMethod* method)
{
	{
		// return (TraitName.GetHashCode() * 397) ^ Type.GetHashCode();
		String_t* L_0 = __this->get_TraitName_0();
		NullCheck(L_0);
		int32_t L_1;
		L_1 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_0);
		Type_t * L_2 = __this->get_Type_1();
		NullCheck(L_2);
		int32_t L_3;
		L_3 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_2);
		return ((int32_t)((int32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_1, (int32_t)((int32_t)397)))^(int32_t)L_3));
	}
}
// System.String Unity.MARS.Data.TraitDefinition::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* TraitDefinition_ToString_mF65497542A815A0DF9EB481CB79003ACBB0BFFAD (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral960E5E7F211EFF3243DF14EDD1901DC9EF314D62);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public override string ToString() { return $"{TraitName} - {Type.Name}"; }
		String_t* L_0 = __this->get_TraitName_0();
		Type_t * L_1 = __this->get_Type_1();
		NullCheck(L_1);
		String_t* L_2;
		L_2 = VirtFuncInvoker0< String_t* >::Invoke(7 /* System.String System.Reflection.MemberInfo::get_Name() */, L_1);
		String_t* L_3;
		L_3 = String_Concat_m89EAB4C6A96B0E5C3F87300D6BE78D386B9EFC44(L_0, _stringLiteral960E5E7F211EFF3243DF14EDD1901DC9EF314D62, L_2, /*hidden argument*/NULL);
		return L_3;
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
// System.Void Unity.MARS.Query.TraitDefinitions::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitDefinitions__cctor_m2E4126F852132AFD6E54CD89B2DBC541E25069F2 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0AE2658B6A3CF65B723B59C775DCF2B5DBC36441);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0E80F4D997AC7C308A04E53745671EE1631B8D7D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral494AD09FB78D890531756ECEC4DFF5C8D22B267D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral61B8D324687C24872968A15276C954F913457113);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral67C959292ACE557A7911726798B51F6178228E0F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral73449D68E41F8415CE7CFE4B9EF15ADCFD227ED3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral80F5C93D7D1A75B619CA6EB5616A6123A15789FF);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral8D18D41C3CA40217AB14C2E3DC0654E77A3140CA);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral8D433D59FC83B792827B9C3DD5736374FC805E00);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9640A4BB52A367750B30EF6205902E8ED977782B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralAB3D2BE4F8DB5A38B000A1ADAA7C55276E258718);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCD002DD70C7AAC9CFF6D7D4821927E13D2989493);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD3992DF679A3EF8B96232992FF89A2B1F1DB5534);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD3BAB32E57D7DF89CA22BE69BA99B62F96CF56CF);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDEA3F5044E13F19207D83873B64CD5C1E5385A9F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE81B368AB56379B7A403D362DD0D8AAA9C8F178B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralEFC86221AAB7628EBCE554785B46AE44BE79305F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFE99981D4BE3BFBE312C52C21EADDC2EACD9ED3D);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static readonly TraitDefinition Pose = new TraitDefinition(TraitNames.Pose, typeof(Pose));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_0 = { reinterpret_cast<intptr_t> (Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_1;
		L_1 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_0, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_2 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_2, _stringLiteralEFC86221AAB7628EBCE554785B46AE44BE79305F, L_1, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Pose_0(L_2);
		// public static readonly TraitDefinition Point = new TraitDefinition(TraitNames.Point, typeof(Vector3));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_3 = { reinterpret_cast<intptr_t> (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E_0_0_0_var) };
		Type_t * L_4;
		L_4 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_3, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_5 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_5, _stringLiteral61B8D324687C24872968A15276C954F913457113, L_4, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Point_1(L_5);
		// public static readonly TraitDefinition Bounds2D = new TraitDefinition(TraitNames.Bounds2D, typeof(Vector2));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_6 = { reinterpret_cast<intptr_t> (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_0_0_0_var) };
		Type_t * L_7;
		L_7 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_6, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_8 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_8, _stringLiteral9640A4BB52A367750B30EF6205902E8ED977782B, L_7, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Bounds2D_2(L_8);
		// public static readonly TraitDefinition Alignment = new TraitDefinition(TraitNames.Alignment, typeof(int));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_9 = { reinterpret_cast<intptr_t> (Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_0_0_0_var) };
		Type_t * L_10;
		L_10 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_9, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_11 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_11, _stringLiteral8D18D41C3CA40217AB14C2E3DC0654E77A3140CA, L_10, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Alignment_3(L_11);
		// public static readonly TraitDefinition GeoCoordinate = new TraitDefinition(TraitNames.Geolocation, typeof(Vector2));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_12 = { reinterpret_cast<intptr_t> (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9_0_0_0_var) };
		Type_t * L_13;
		L_13 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_12, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_14 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_14, _stringLiteral73449D68E41F8415CE7CFE4B9EF15ADCFD227ED3, L_13, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_GeoCoordinate_4(L_14);
		// public static readonly TraitDefinition HeightAboveFloor = new TraitDefinition(TraitNames.HeightAboveFloor, typeof(float));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_15 = { reinterpret_cast<intptr_t> (Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_0_0_0_var) };
		Type_t * L_16;
		L_16 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_15, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_17 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_17, _stringLiteral0E80F4D997AC7C308A04E53745671EE1631B8D7D, L_16, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_HeightAboveFloor_5(L_17);
		// public static readonly TraitDefinition Plane = new TraitDefinition(TraitNames.Plane, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_18 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_19;
		L_19 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_18, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_20 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_20, _stringLiteral8D433D59FC83B792827B9C3DD5736374FC805E00, L_19, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Plane_6(L_20);
		// public static readonly TraitDefinition Face = new TraitDefinition(TraitNames.Face, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_21 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_22;
		L_22 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_21, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_23 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_23, _stringLiteralAB3D2BE4F8DB5A38B000A1ADAA7C55276E258718, L_22, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Face_7(L_23);
		// public static readonly TraitDefinition Floor = new TraitDefinition(TraitNames.Floor, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_24 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_25;
		L_25 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_24, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_26 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_26, _stringLiteralDEA3F5044E13F19207D83873B64CD5C1E5385A9F, L_25, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Floor_8(L_26);
		// public static readonly TraitDefinition Environment = new TraitDefinition(TraitNames.Environment, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_27 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_28;
		L_28 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_27, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_29 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_29, _stringLiteral80F5C93D7D1A75B619CA6EB5616A6123A15789FF, L_28, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Environment_9(L_29);
		// public static readonly TraitDefinition User = new TraitDefinition(TraitNames.User, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_30 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_31;
		L_31 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_30, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_32 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_32, _stringLiteralD3992DF679A3EF8B96232992FF89A2B1F1DB5534, L_31, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_User_10(L_32);
		// public static readonly TraitDefinition InView = new TraitDefinition(TraitNames.InView, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_33 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_34;
		L_34 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_33, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_35 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_35, _stringLiteralD3BAB32E57D7DF89CA22BE69BA99B62F96CF56CF, L_34, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_InView_11(L_35);
		// public static readonly TraitDefinition DisplayFlat = new TraitDefinition(TraitNames.DisplayFlat, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_36 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_37;
		L_37 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_36, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_38 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_38, _stringLiteral0AE2658B6A3CF65B723B59C775DCF2B5DBC36441, L_37, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_DisplayFlat_12(L_38);
		// public static readonly TraitDefinition DisplaySpatial = new TraitDefinition(TraitNames.DisplaySpatial, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_39 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_40;
		L_40 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_39, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_41 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_41, _stringLiteral494AD09FB78D890531756ECEC4DFF5C8D22B267D, L_40, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_DisplaySpatial_13(L_41);
		// public static readonly TraitDefinition Marker = new TraitDefinition(TraitNames.Marker, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_42 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_43;
		L_43 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_42, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_44 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_44, _stringLiteral67C959292ACE557A7911726798B51F6178228E0F, L_43, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Marker_14(L_44);
		// public static readonly TraitDefinition MarkerId = new TraitDefinition(TraitNames.MarkerId, typeof(string));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_45 = { reinterpret_cast<intptr_t> (String_t_0_0_0_var) };
		Type_t * L_46;
		L_46 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_45, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_47 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_47, _stringLiteralE81B368AB56379B7A403D362DD0D8AAA9C8F178B, L_46, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_MarkerId_15(L_47);
		// public static readonly TraitDefinition TrackingState = new TraitDefinition(TraitNames.TrackingState, typeof(int));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_48 = { reinterpret_cast<intptr_t> (Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_0_0_0_var) };
		Type_t * L_49;
		L_49 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_48, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_50 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_50, _stringLiteralFE99981D4BE3BFBE312C52C21EADDC2EACD9ED3D, L_49, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_TrackingState_16(L_50);
		// public static readonly TraitDefinition Body = new TraitDefinition(TraitNames.Body, typeof(bool));
		RuntimeTypeHandle_tC33965ADA3E041E0C94AF05E5CB527B56482CEF9  L_51 = { reinterpret_cast<intptr_t> (Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_0_0_0_var) };
		Type_t * L_52;
		L_52 = Type_GetTypeFromHandle_m8BB57524FF7F9DB1803BC561D2B3A4DBACEB385E(L_51, /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_53 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_53, _stringLiteralCD002DD70C7AAC9CFF6D7D4821927E13D2989493, L_52, /*hidden argument*/NULL);
		((TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_StaticFields*)il2cpp_codegen_static_fields_for(TraitDefinitions_t47940EC326961731B1771307DFDB841854CEFAFE_il2cpp_TypeInfo_var))->set_Body_17(L_53);
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
// System.String Unity.MARS.Query.TraitRequirement::get_TraitName()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* TraitRequirement_get_TraitName_mFDCD39504376698867BFBC05E66DCB08CB5855B2 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method)
{
	{
		// public string TraitName => Definition.TraitName;
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = __this->get_Definition_1();
		NullCheck(L_0);
		String_t* L_1 = L_0->get_TraitName_0();
		return L_1;
	}
}
// System.Type Unity.MARS.Query.TraitRequirement::get_Type()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t * TraitRequirement_get_Type_m1EFEB92F45AA34D34B8BF34E3706EFDE64571186 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method)
{
	{
		// public Type Type => Definition.Type;
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = __this->get_Definition_1();
		NullCheck(L_0);
		Type_t * L_1 = L_0->get_Type_1();
		return L_1;
	}
}
// System.Void Unity.MARS.Query.TraitRequirement::.ctor(System.String,System.Type,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitRequirement__ctor_mE68E74A8E4A7B8CF1D8D483616C1028C779F4391 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, String_t* ___traitName0, Type_t * ___type1, bool ___required2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// : this(new TraitDefinition(traitName, type), required) { }
		String_t* L_0 = ___traitName0;
		Type_t * L_1 = ___type1;
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_2 = (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 *)il2cpp_codegen_object_new(TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796_il2cpp_TypeInfo_var);
		TraitDefinition__ctor_m26FFC7C065DB55E11CAE21BB3E493D3D07D118D7(L_2, L_0, L_1, /*hidden argument*/NULL);
		bool L_3 = ___required2;
		TraitRequirement__ctor_mF1A4A6EF09660064D70F0A71E13EAB0B7C1CF19A(__this, L_2, L_3, /*hidden argument*/NULL);
		// : this(new TraitDefinition(traitName, type), required) { }
		return;
	}
}
// System.Void Unity.MARS.Query.TraitRequirement::.ctor(Unity.MARS.Data.TraitDefinition,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TraitRequirement__ctor_mF1A4A6EF09660064D70F0A71E13EAB0B7C1CF19A (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___definition0, bool ___required1, const RuntimeMethod* method)
{
	{
		// public TraitRequirement(TraitDefinition definition, bool required = true)
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		// Definition = definition;
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = ___definition0;
		__this->set_Definition_1(L_0);
		// Required = required;
		bool L_1 = ___required1;
		__this->set_Required_0(L_1);
		// }
		return;
	}
}
// Unity.MARS.Query.TraitRequirement Unity.MARS.Query.TraitRequirement::FromSerialized(Unity.MARS.Data.SerializedTraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * TraitRequirement_FromSerialized_mB5CD2401F1B09211157DC21F1033A84FE1944EC5 (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * ___requirement0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitRequirement_FromSerialized_mB5CD2401F1B09211157DC21F1033A84FE1944EC5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_GetType_m2D692327E10692E11116805CC604CD47F144A9E4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral095BF313E0560B989F26D34ADC221C4C1F9BB76E);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0AD4547EEDA716D7ABB45F1D2443B6BFD56E52EC);
		s_Il2CppMethodInitialized = true;
	}
	Type_t * V_0 = NULL;
	{
		// var type = Type.GetType(requirement.TypeName);
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_0 = ___requirement0;
		NullCheck(L_0);
		String_t* L_1;
		L_1 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(L_0, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_2;
		L_2 = il2cpp_codegen_get_type(Type_GetType_m2D692327E10692E11116805CC604CD47F144A9E4_RuntimeMethod_var, L_1, TraitRequirement_FromSerialized_mB5CD2401F1B09211157DC21F1033A84FE1944EC5_RuntimeMethod_var);
		V_0 = L_2;
		// if (type == null && requirement.Required)
		Type_t * L_3 = V_0;
		bool L_4;
		L_4 = Type_op_Equality_mA438719A1FDF103C7BBBB08AEF564E7FAEEA0046(L_3, (Type_t *)NULL, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_005b;
		}
	}
	{
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_5 = ___requirement0;
		NullCheck(L_5);
		bool L_6;
		L_6 = SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808_inline(L_5, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_005b;
		}
	}
	{
		// if (requirement.Required)
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_7 = ___requirement0;
		NullCheck(L_7);
		bool L_8;
		L_8 = SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808_inline(L_7, /*hidden argument*/NULL);
		if (!L_8)
		{
			goto IL_0040;
		}
	}
	{
		// Debug.LogErrorFormat("Did not find a Type for required type name {0} - " +
		//     "you will get incorrect behavior / errors later!", requirement.TypeName);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_9 = (ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)SZArrayNew(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var, (uint32_t)1);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_10 = L_9;
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_11 = ___requirement0;
		NullCheck(L_11);
		String_t* L_12;
		L_12 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(L_11, /*hidden argument*/NULL);
		NullCheck(L_10);
		ArrayElementTypeCheck (L_10, L_12);
		(L_10)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_12);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		Debug_LogErrorFormat_mDBF43684A22EAAB187285C9B4174C9555DB11E83(_stringLiteral095BF313E0560B989F26D34ADC221C4C1F9BB76E, L_10, /*hidden argument*/NULL);
		// }
		goto IL_0059;
	}

IL_0040:
	{
		// Debug.LogWarningFormat("Did not find a Type for optionally required type name {0} - " +
		//                 "optional Actions that rely on this will not work.", requirement.TypeName);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_13 = (ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)SZArrayNew(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var, (uint32_t)1);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_14 = L_13;
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_15 = ___requirement0;
		NullCheck(L_15);
		String_t* L_16;
		L_16 = SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline(L_15, /*hidden argument*/NULL);
		NullCheck(L_14);
		ArrayElementTypeCheck (L_14, L_16);
		(L_14)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_16);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		Debug_LogWarningFormat_m405E9C0A631F815816F349D7591DD545932FF774(_stringLiteral0AD4547EEDA716D7ABB45F1D2443B6BFD56E52EC, L_14, /*hidden argument*/NULL);
	}

IL_0059:
	{
		// return null;
		return (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E *)NULL;
	}

IL_005b:
	{
		// return new TraitRequirement(requirement.TraitName, type, requirement.Required);
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_17 = ___requirement0;
		NullCheck(L_17);
		String_t* L_18;
		L_18 = SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline(L_17, /*hidden argument*/NULL);
		Type_t * L_19 = V_0;
		SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * L_20 = ___requirement0;
		NullCheck(L_20);
		bool L_21;
		L_21 = SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808_inline(L_20, /*hidden argument*/NULL);
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_22 = (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E *)il2cpp_codegen_object_new(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E_il2cpp_TypeInfo_var);
		TraitRequirement__ctor_mE68E74A8E4A7B8CF1D8D483616C1028C779F4391(L_22, L_18, L_19, L_21, /*hidden argument*/NULL);
		return L_22;
	}
}
// Unity.MARS.Data.TraitDefinition Unity.MARS.Query.TraitRequirement::op_Implicit(Unity.MARS.Query.TraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * TraitRequirement_op_Implicit_m632F8C90DE9BCF304C38685D7F1AF501969411B3 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * ___requirement0, const RuntimeMethod* method)
{
	{
		// public static implicit operator TraitDefinition(TraitRequirement requirement) { return requirement.Definition; }
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_0 = ___requirement0;
		NullCheck(L_0);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_1 = L_0->get_Definition_1();
		return L_1;
	}
}
// Unity.MARS.Query.TraitRequirement Unity.MARS.Query.TraitRequirement::op_Implicit(Unity.MARS.Data.TraitDefinition)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * TraitRequirement_op_Implicit_m9C05407F8D3BB44CE39A231CC746E5A471561F9B (TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___definition0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static implicit operator TraitRequirement(TraitDefinition definition) { return new TraitRequirement(definition); }
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = ___definition0;
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_1 = (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E *)il2cpp_codegen_object_new(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E_il2cpp_TypeInfo_var);
		TraitRequirement__ctor_mF1A4A6EF09660064D70F0A71E13EAB0B7C1CF19A(L_1, L_0, (bool)1, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Boolean Unity.MARS.Query.TraitRequirement::Equals(Unity.MARS.Query.TraitRequirement)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TraitRequirement_Equals_m0B669B0679E0637050FF7522514A553B60FF9905 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * ___other0, const RuntimeMethod* method)
{
	{
		// if (ReferenceEquals(null, other))
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_0 = ___other0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0005:
	{
		// if (ReferenceEquals(this, other))
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_1 = ___other0;
		if ((!(((RuntimeObject*)(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E *)__this) == ((RuntimeObject*)(TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E *)L_1))))
		{
			goto IL_000b;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_000b:
	{
		// return Required == other.Required && Definition.Equals(other.Definition);
		bool L_2 = __this->get_Required_0();
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_3 = ___other0;
		NullCheck(L_3);
		bool L_4 = L_3->get_Required_0();
		if ((!(((uint32_t)L_2) == ((uint32_t)L_4))))
		{
			goto IL_002b;
		}
	}
	{
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_5 = __this->get_Definition_1();
		TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * L_6 = ___other0;
		NullCheck(L_6);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_7 = L_6->get_Definition_1();
		NullCheck(L_5);
		bool L_8;
		L_8 = TraitDefinition_Equals_mF0D8ADEB9230BC3BCDDDB26A6A33CA13D0B687C1(L_5, L_7, /*hidden argument*/NULL);
		return L_8;
	}

IL_002b:
	{
		return (bool)0;
	}
}
// System.Boolean Unity.MARS.Query.TraitRequirement::Equals(Unity.MARS.Data.TraitDefinition)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TraitRequirement_Equals_mF2EE43BBD581C2AB0754B7C2BAAD253FB6530473 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * ___other0, const RuntimeMethod* method)
{
	{
		// if (other == null)
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = ___other0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0005:
	{
		// return other.Equals(Definition);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_1 = ___other0;
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_2 = __this->get_Definition_1();
		NullCheck(L_1);
		bool L_3;
		L_3 = TraitDefinition_Equals_mF0D8ADEB9230BC3BCDDDB26A6A33CA13D0B687C1(L_1, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// System.Int32 Unity.MARS.Query.TraitRequirement::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TraitRequirement_GetHashCode_m1A31E770C9A22EEB8353B592C0F2C295EAD37207 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	int32_t G_B2_0 = 0;
	int32_t G_B1_0 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B3_1 = 0;
	{
		// return (Required.GetHashCode() * 397) ^ (Definition != null ? Definition.GetHashCode() : 0);
		bool L_0 = __this->get_Required_0();
		V_0 = L_0;
		int32_t L_1;
		L_1 = Boolean_GetHashCode_m03AF8B3CECAE9106C44A00E3B33E51CBFC45C411((bool*)(&V_0), /*hidden argument*/NULL);
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_2 = __this->get_Definition_1();
		G_B1_0 = ((int32_t)il2cpp_codegen_multiply((int32_t)L_1, (int32_t)((int32_t)397)));
		if (L_2)
		{
			G_B2_0 = ((int32_t)il2cpp_codegen_multiply((int32_t)L_1, (int32_t)((int32_t)397)));
			goto IL_001f;
		}
	}
	{
		G_B3_0 = 0;
		G_B3_1 = G_B1_0;
		goto IL_002a;
	}

IL_001f:
	{
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_3 = __this->get_Definition_1();
		NullCheck(L_3);
		int32_t L_4;
		L_4 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_3);
		G_B3_0 = L_4;
		G_B3_1 = G_B2_0;
	}

IL_002a:
	{
		return ((int32_t)((int32_t)G_B3_1^(int32_t)G_B3_0));
	}
}
// System.String Unity.MARS.Query.TraitRequirement::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* TraitRequirement_ToString_mBF62097C6C504334FC32C8B45B0A9413828D3B16 (TraitRequirement_tB3653CF6E01BFA25132320ADB6029B20B270624E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC44DACFC4328E9DD61AE6846C25FED3BA5076B31);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public override string ToString() { return $"{Definition}, required: {Required}"; }
		TraitDefinition_tF3BB8A28376B8A5892E5E9112621B6F3F751C796 * L_0 = __this->get_Definition_1();
		bool L_1 = __this->get_Required_0();
		bool L_2 = L_1;
		RuntimeObject * L_3 = Box(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var, &L_2);
		String_t* L_4;
		L_4 = String_Format_m8D1CB0410C35E052A53AE957C914C841E54BAB66(_stringLiteralC44DACFC4328E9DD61AE6846C25FED3BA5076B31, L_0, L_3, /*hidden argument*/NULL);
		return L_4;
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
// System.Void Unity.MARS.MARSUtils.TypeExtensions::GetImplementationsOfInterface(System.Type,System.Collections.Generic.List`1<System.Type>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TypeExtensions_GetImplementationsOfInterface_m65ACCD4ED00ACC43043E1BC5A61994D84608F2EA (Type_t * ___type0, List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7 * ___list1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m56E267FE82DC48AD1690E87B576550B72754E89D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0* V_0 = NULL;
	int32_t V_1 = 0;
	Assembly_t * V_2 = NULL;
	TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* V_3 = NULL;
	int32_t V_4 = 0;
	Type_t * V_5 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	il2cpp::utils::ExceptionSupportStack<int32_t, 2> __leave_targets;
	{
		// if (!type.IsInterface)
		Type_t * L_0 = ___type0;
		NullCheck(L_0);
		bool L_1;
		L_1 = Type_get_IsInterface_mB10C34DEE8B22E1597C813211BBED17DD724FC07(L_0, /*hidden argument*/NULL);
		if (L_1)
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
		// var assemblies = AppDomain.CurrentDomain.GetAssemblies();
		AppDomain_tBEB6322D51DCB12C09A56A49886C2D09BA1C1A8A * L_2;
		L_2 = AppDomain_get_CurrentDomain_mC2FE307811914289CBBDEFEFF6175FCE2E96A55E(/*hidden argument*/NULL);
		NullCheck(L_2);
		AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0* L_3;
		L_3 = AppDomain_GetAssemblies_m7397BD0461B4D6BA76AE0974DE9FBEDAF70AEBFD(L_2, /*hidden argument*/NULL);
		// foreach (var assembly in assemblies)
		V_0 = L_3;
		V_1 = 0;
		goto IL_0068;
	}

IL_0018:
	{
		// foreach (var assembly in assemblies)
		AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0* L_4 = V_0;
		int32_t L_5 = V_1;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		Assembly_t * L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		V_2 = L_7;
	}

IL_001c:
	try
	{ // begin try (depth: 1)
		{
			// var types = assembly.GetTypes();
			Assembly_t * L_8 = V_2;
			NullCheck(L_8);
			TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_9;
			L_9 = VirtFuncInvoker0< TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* >::Invoke(13 /* System.Type[] System.Reflection.Assembly::GetTypes() */, L_8);
			// foreach (var t in types)
			V_3 = L_9;
			V_4 = 0;
			goto IL_0058;
		}

IL_0028:
		{
			// foreach (var t in types)
			TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_10 = V_3;
			int32_t L_11 = V_4;
			NullCheck(L_10);
			int32_t L_12 = L_11;
			Type_t * L_13 = (L_10)->GetAt(static_cast<il2cpp_array_size_t>(L_12));
			V_5 = L_13;
			// if (type.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
			Type_t * L_14 = ___type0;
			Type_t * L_15 = V_5;
			NullCheck(L_14);
			bool L_16;
			L_16 = VirtFuncInvoker1< bool, Type_t * >::Invoke(106 /* System.Boolean System.Type::IsAssignableFrom(System.Type) */, L_14, L_15);
			if (!L_16)
			{
				goto IL_0052;
			}
		}

IL_0038:
		{
			Type_t * L_17 = V_5;
			NullCheck(L_17);
			bool L_18;
			L_18 = Type_get_IsInterface_mB10C34DEE8B22E1597C813211BBED17DD724FC07(L_17, /*hidden argument*/NULL);
			if (L_18)
			{
				goto IL_0052;
			}
		}

IL_0041:
		{
			Type_t * L_19 = V_5;
			NullCheck(L_19);
			bool L_20;
			L_20 = Type_get_IsAbstract_mB16DB56FCABF55740019D32C5286F38E30CAA19F(L_19, /*hidden argument*/NULL);
			if (L_20)
			{
				goto IL_0052;
			}
		}

IL_004a:
		{
			// list.Add(t);
			List_1_t7CFD5FCE8366620F593F2C9DAC3A870E5D6506D7 * L_21 = ___list1;
			Type_t * L_22 = V_5;
			NullCheck(L_21);
			List_1_Add_m56E267FE82DC48AD1690E87B576550B72754E89D(L_21, L_22, /*hidden argument*/List_1_Add_m56E267FE82DC48AD1690E87B576550B72754E89D_RuntimeMethod_var);
		}

IL_0052:
		{
			int32_t L_23 = V_4;
			V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_23, (int32_t)1));
		}

IL_0058:
		{
			// foreach (var t in types)
			int32_t L_24 = V_4;
			TypeU5BU5D_t85B10489E46F06CEC7C4B1CCBD0E01FAB6649755* L_25 = V_3;
			NullCheck(L_25);
			if ((((int32_t)L_24) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_25)->max_length))))))
			{
				goto IL_0028;
			}
		}

IL_005f:
		{
			// }
			goto IL_0064;
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ReflectionTypeLoadException_tF7B3556875F394EC77B674893C9322FA1DC21F6C_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0061;
		}
		throw e;
	}

CATCH_0061:
	{ // begin catch(System.Reflection.ReflectionTypeLoadException)
		// catch (ReflectionTypeLoadException)
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0064;
	} // end catch (depth: 1)

IL_0064:
	{
		int32_t L_26 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_26, (int32_t)1));
	}

IL_0068:
	{
		// foreach (var assembly in assemblies)
		int32_t L_27 = V_1;
		AssemblyU5BU5D_t42061B4CA43487DD8ECD8C3AACCEF783FA081FF0* L_28 = V_0;
		NullCheck(L_28);
		if ((((int32_t)L_27) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_28)->max_length))))))
		{
			goto IL_0018;
		}
	}
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
// System.Boolean Unity.MARS.Providers.UsesLightEstimationMethods::TryGetLightEstimation(Unity.MARS.Providers.IUsesLightEstimation,Unity.MARS.Data.MRLightEstimation&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UsesLightEstimationMethods_TryGetLightEstimation_m8534B7C6F2526816E7A485E705E961AAE457A889 (RuntimeObject* ___obj0, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096 * ___lightEstimation1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return obj.provider.TryGetLightEstimation(out lightEstimation);
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesLightEstimation>::get_provider() */, IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var, L_0);
		MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096 * L_2 = ___lightEstimation1;
		NullCheck(L_1);
		bool L_3;
		L_3 = InterfaceFuncInvoker1< bool, MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096 * >::Invoke(2 /* System.Boolean Unity.MARS.Providers.IProvidesLightEstimation::TryGetLightEstimation(Unity.MARS.Data.MRLightEstimation&) */, IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var, L_1, (MRLightEstimation_t8C687D93FA3B572390AAF76A7F1434840B166096 *)L_2);
		return L_3;
	}
}
// System.Void Unity.MARS.Providers.UsesLightEstimationMethods::SubscribeLightEstimationUpdated(Unity.MARS.Providers.IUsesLightEstimation,System.Action`1<Unity.MARS.Data.MRLightEstimation>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UsesLightEstimationMethods_SubscribeLightEstimationUpdated_m090D07612CB248856E3D4C878C5ADB854261382C (RuntimeObject* ___obj0, Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * ___lightEstimationUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.lightEstimationUpdated += lightEstimationUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesLightEstimation>::get_provider() */, IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var, L_0);
		Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * L_2 = ___lightEstimationUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * >::Invoke(0 /* System.Void Unity.MARS.Providers.IProvidesLightEstimation::add_lightEstimationUpdated(System.Action`1<Unity.MARS.Data.MRLightEstimation>) */, IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var, L_1, L_2);
		// }
		return;
	}
}
// System.Void Unity.MARS.Providers.UsesLightEstimationMethods::UnsubscribeLightEstimationUpdated(Unity.MARS.Providers.IUsesLightEstimation,System.Action`1<Unity.MARS.Data.MRLightEstimation>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UsesLightEstimationMethods_UnsubscribeLightEstimationUpdated_m18B6F1EF1F4DDD3E28664C84B91821A3CD458A2D (RuntimeObject* ___obj0, Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * ___lightEstimationUpdated1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// obj.provider.lightEstimationUpdated -= lightEstimationUpdated;
		RuntimeObject* L_0 = ___obj0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* !0 Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.MARS.Providers.IProvidesLightEstimation>::get_provider() */, IFunctionalitySubscriber_1_t63D1FC6E639F519EEA52FA46ED67B64028AC0C48_il2cpp_TypeInfo_var, L_0);
		Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * L_2 = ___lightEstimationUpdated1;
		NullCheck(L_1);
		InterfaceActionInvoker1< Action_1_t38DF42E05A6F495A2224CA57CD559C26657EDE19 * >::Invoke(1 /* System.Void Unity.MARS.Providers.IProvidesLightEstimation::remove_lightEstimationUpdated(System.Action`1<Unity.MARS.Data.MRLightEstimation>) */, IProvidesLightEstimation_tE4637355C1C91FC2985906F899C8A0D115B6E8FB_il2cpp_TypeInfo_var, L_1, L_2);
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
IL2CPP_EXTERN_C  bool DelegatePInvokeWrapper_TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * __this, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * ___coordinate0, const RuntimeMethod* method)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc)(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(((RuntimeDelegate*)__this)->method->nativeFunction);

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___coordinate0);

	return static_cast<bool>(returnValue);
}
// System.Void Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TryGetGeoLocationDelegate__ctor_m4390B3B081FE1B44261B215140391BC240E32C1B (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Boolean Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate::Invoke(Unity.MARS.Data.GeographicCoordinate&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TryGetGeoLocationDelegate_Invoke_mB02A346DA11F0F9AAFBCAB0428F33C7B10C90B69 (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * __this, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * ___coordinate0, const RuntimeMethod* method)
{
	bool result = false;
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* delegateArrayToInvoke = __this->get_delegates_11();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = delegateArrayToInvoke->max_length;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_2();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 1)
			{
				// open
				typedef bool (*FunctionPointerType) (GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(___coordinate0, targetMethod);
			}
			else
			{
				// closed
				typedef bool (*FunctionPointerType) (void*, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___coordinate0, targetMethod);
			}
		}
		else
		{
			// closed
			if (targetThis != NULL && il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_generic_instance(targetMethod))
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						result = GenericInterfaceFuncInvoker1< bool, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * >::Invoke(targetMethod, targetThis, ___coordinate0);
					else
						result = GenericVirtFuncInvoker1< bool, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * >::Invoke(targetMethod, targetThis, ___coordinate0);
				}
				else
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						result = InterfaceFuncInvoker1< bool, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___coordinate0);
					else
						result = VirtFuncInvoker1< bool, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___coordinate0);
				}
			}
			else
			{
				if (targetThis == NULL)
				{
					typedef bool (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)((RuntimeObject*)(reinterpret_cast<RuntimeObject*>(___coordinate0) - 1), targetMethod);
				}
				else
				{
					typedef bool (*FunctionPointerType) (void*, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 *, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___coordinate0, targetMethod);
				}
			}
		}
	}
	return result;
}
// System.IAsyncResult Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate::BeginInvoke(Unity.MARS.Data.GeographicCoordinate&,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TryGetGeoLocationDelegate_BeginInvoke_mE3641D041BAC310E2B1737511F10F1F3479547D6 (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * __this, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * ___coordinate0, AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___callback1, RuntimeObject * ___object2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[2] = {0};
	__d_args[0] = Box(GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1_il2cpp_TypeInfo_var, &*___coordinate0);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback1, (RuntimeObject*)___object2);;
}
// System.Boolean Unity.MARS.Providers.IUsesGeoLocationMethods/TryGetGeoLocationDelegate::EndInvoke(Unity.MARS.Data.GeographicCoordinate&,System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TryGetGeoLocationDelegate_EndInvoke_m6CFF0F50D87610D59A6ABB6D94DE996A234C3969 (TryGetGeoLocationDelegate_tCF231014403EE58F5F0A28D9EADEE51D9BD04038 * __this, GeographicCoordinate_t74170A54D34AE094B3880276970F7A9A828FB2B1 * ___coordinate0, RuntimeObject* ___result1, const RuntimeMethod* method)
{
	void* ___out_args[] = {
	___coordinate0,
	};
	RuntimeObject *__result = il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result1, ___out_args);
	return *(bool*)UnBox ((RuntimeObject*)__result);;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * __this, float ___x0, float ___y1, const RuntimeMethod* method)
{
	{
		float L_0 = ___x0;
		__this->set_x_0(L_0);
		float L_1 = ___y1;
		__this->set_y_1(L_1);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRHitTestResult_set_pose_m8D1F054849B3E056745B3D51905600A0EB03B09F_inline (MRHitTestResult_tF78A7C4ED49B7B3E280344CA593040A5D83772B3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRMarker_get_id_mCF0A2F08ADCB7AAFF9C01B1C88E6E3F4452315F4_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_TrackableId; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_m_TrackableId_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_id_mA90B2B6E2EA4D9124A06B2FDDFD785B334ACE211_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_TrackableId = value; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_m_TrackableId_0(L_0);
		// set { m_TrackableId = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRMarker_get_pose_m26B01BBC6BC33C554B37D95E3F547934B31F3724_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Pose; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_m_Pose_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_pose_m214334D9B1F67D0788C9CB495CC7A0FAB68A2EDE_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Pose = value; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_m_Pose_1(L_0);
		// set { m_Pose = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Guid_t  MRMarker_get_markerId_mD511F48B85309DC3647C2523C662BF2F6A7EF0DF_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_MarkerId; }
		Guid_t  L_0 = __this->get_m_MarkerId_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_markerId_m754B1B5039AEA750907A5FC75F1A97CB62CA1C92_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Guid_t  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_MarkerId = value; }
		Guid_t  L_0 = ___value0;
		__this->set_m_MarkerId_2(L_0);
		// set { m_MarkerId = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRMarker_get_extents_m53EE2D20BE320174FF59B0F2A63269BC68F8102E_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Extents; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_m_Extents_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_extents_m8B9997FA7962B7231D8E3D6B9F97F4B7D7C8E12B_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Extents = value; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_m_Extents_3(L_0);
		// set { m_Extents = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MRMarker_get_trackingState_m31D5F6EF768A2D155BEFA7A19B37F4FBFB5FF95C_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, const RuntimeMethod* method)
{
	{
		// get => m_TrackingState;
		int32_t L_0 = __this->get_m_TrackingState_4();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_trackingState_m6E5022AD0ED0483B1CCB1D828CAFBB6AAA6BD440_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// set => m_TrackingState = value;
		int32_t L_0 = ___value0;
		__this->set_m_TrackingState_4(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRMarker_set_texture_m3671418D4EA8029AD01065A79661D2218D0F7358_inline (MRMarker_tFD8C3BCDD56BC97B43E2747EA2BAE447D3583D50 * __this, Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * ___value0, const RuntimeMethod* method)
{
	{
		// set => m_Texture = value;
		Texture2D_t9B604D0D8E28032123641A7E7338FA872E2698BF * L_0 = ___value0;
		__this->set_m_Texture_5(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRPlane_get_id_m3C58E67BF29B34E32E8A66A7669D1C5C0AB92B92_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_ID; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_m_ID_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_id_mB85378E0E640B7009C4B8A86C758BC7918770F6C_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_ID = value; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_m_ID_1(L_0);
		// set { m_ID = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MRPlane_get_alignment_m155185C0BE923248835076D5F312EAB8C76D81B8_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Alignment; }
		int32_t L_0 = __this->get_m_Alignment_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_alignment_m2F2D8AB55C5DFC3AFEF4082CB31EE103713A8C52_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Alignment = value; }
		int32_t L_0 = ___value0;
		__this->set_m_Alignment_2(L_0);
		// set { m_Alignment = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRPlane_get_pose_mE4641C58EB01F74D8D891840A3E704D8D3CEFAFE_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Pose; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_m_Pose_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_pose_mF67BA811CD0D167A8DB12E029AE60A029194C6B3_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Pose = value; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_m_Pose_3(L_0);
		// set { m_Pose = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MRPlane_get_center_m6E11618D22CBC5698A010738EE249CF07B6DF3CE_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Center; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_m_Center_4();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_center_m85121C2B0A14F5FD5951D004CB954644C3DAF5EC_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Center = value; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_m_Center_4(L_0);
		// set { m_Center = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  MRPlane_get_extents_m63073D5F8D09129CE9D725E218EFA9E64C698D6D_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Extents; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_m_Extents_5();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRPlane_set_extents_m1DDF0F993D964BD0BDC7E0C26DF0347FF7B3C058_inline (MRPlane_t5B40A6C7F8F69629420DF9910903578C05AAF5D3 * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// set { m_Extents = value; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_m_Extents_5(L_0);
		// set { m_Extents = value; }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MRReferencePoint_get_id_mCFC2194A08CB38B55840BF4986D58AADA7266478_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_U3CidU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_id_mF6461A09043D0AAAF804D7281183699E7E8D6E09_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MRReferencePoint_get_pose_m7548092EC3F676CDD7FAD085B06FE4978BA326FE_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_U3CposeU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_pose_m01E9858EE2A6F12E39BA0486510D2BBB095E7104_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MRReferencePoint_set_trackingState_m5D362A882517706B63082E47D4D6702AB3953DF4_inline (MRReferencePoint_tEE609032BA11A01599561A99E11C44DEC0A86532 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public MARSTrackingState trackingState { get; set; }
		int32_t L_0 = ___value0;
		__this->set_U3CtrackingStateU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  MarsBody_get_id_m25C153F5E5D66D255DF989B64D7B6192BE9E629D_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = __this->get_U3CidU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_id_m909CFE33F3D1DC3505310B71A63E64CE8A2FDCAC_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  ___value0, const RuntimeMethod* method)
{
	{
		// public MarsTrackableId id { get; set; }
		MarsTrackableId_t4CC1C1442F40055D93D2B90F1BA6358606FF2F60  L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  MarsBody_get_pose_m24FD3A349D2EB7D56C6C596DB17C2706DF655B1E_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = __this->get_U3CposeU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_pose_mF77B965C8146F5CB58A315B4B43525162C2114F4_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  ___value0, const RuntimeMethod* method)
{
	{
		// public Pose pose { get; set; }
		Pose_t9F30358E65733E60A1DC8682FDB7104F40C9434A  L_0 = ___value0;
		__this->set_U3CposeU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  MarsBody_get_BodyPose_m872C60DB6506A83284C2E515AA3136866C7789CA_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public HumanPose BodyPose { get; set; }
		HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  L_0 = __this->get_U3CBodyPoseU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_BodyPose_mBC26E9630954F96ACDD3DEA78C71ABE619F21593_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  ___value0, const RuntimeMethod* method)
{
	{
		// public HumanPose BodyPose { get; set; }
		HumanPose_t67DB9EAA659CD40135FE99FE2AC557C6E9FF9D4F  L_0 = ___value0;
		__this->set_U3CBodyPoseU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float MarsBody_get_Height_m023FF0CA8628FCAB3790366F71753C534075D565_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, const RuntimeMethod* method)
{
	{
		// public float Height { get; set; }
		float L_0 = __this->get_U3CHeightU3Ek__BackingField_4();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MarsBody_set_Height_mEB8A9CA1F4DF0E81E605605FE0B96BC41C3DB323_inline (MarsBody_t0A7D914FA5B0FC42B6FB41DFFF87537CF1EB3CA5 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float Height { get; set; }
		float L_0 = ___value0;
		__this->set_U3CHeightU3Ek__BackingField_4(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TraitName_m4751B75751F1B310392A54C0217B2E17E8996634_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public string TraitName => m_TraitName;
		String_t* L_0 = __this->get_m_TraitName_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* SerializedTraitRequirement_get_TypeName_m2AF911CB52F8459E0B780C7744AA11D2DD7D819C_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public string TypeName => m_TypeName;
		String_t* L_0 = __this->get_m_TypeName_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool SerializedTraitRequirement_get_Required_mBDF0F1020C5CC93B77F28FD88FF3D9AFD12FA808_inline (SerializedTraitRequirement_t9BB0CE2A674549271BB1022090AB54605E6B6C87 * __this, const RuntimeMethod* method)
{
	{
		// public bool Required => m_Required;
		bool L_0 = __this->get_m_Required_2();
		return L_0;
	}
}

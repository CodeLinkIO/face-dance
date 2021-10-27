#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


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
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
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

// System.Collections.Generic.ICollection`1<UnityEngine.Vector2>
struct ICollection_1_t00B5CAC82DBD853D6781EA9FA2C2A064B75DEC20;
// System.Collections.Generic.IEnumerable`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>
struct IEnumerable_1_t2ADE575B5605E0896101281622689ED34D87D21A;
// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_t52B1AC8D9E5E1ED28DF6C46A37C9A1B00B394F9D;
// System.Collections.Generic.IList`1<UnityEngine.Vector3>
struct IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0;
// System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>
struct IReadOnlyList_1_t7453370C5361E060CD390551EC47318B25EDE91A;
// System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>
struct IReadOnlyList_1_t0FBD6E83DD1841DFB0D8CE23A45ED0B6E9AF771A;
// System.Collections.Generic.IReadOnlyList`1<System.Int32>
struct IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF;
// System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>
struct IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60;
// System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>
struct IReadOnlyList_1_t8DA862FFC86BFEF2B4384525D73EC4D91635F3D7;
// System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad>
struct IReadOnlyList_1_t7D0A2C175B46FF20C9F2E14C757BF91753001159;
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>
struct List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856;
// System.Collections.Generic.List`1<System.Int32>
struct List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5;
// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>
struct List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124;
// System.Collections.Generic.List`1<UnityEngine.Vector2>
struct List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9;
// System.Collections.Generic.List`1<UnityEngine.Vector3>
struct List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// Unity.MARS.MARSHandles.Picking.IPickingTarget[]
struct IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9;
// System.Int32[]
struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32;
// System.IntPtr[]
struct IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6;
// Unity.MARS.MARSHandles.Picking.PickingHit[]
struct PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341;
// System.Single[]
struct SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4;
// System.ArgumentNullException
struct ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB;
// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71;
// Unity.MARS.MARSHandles.Picking.BoxPickingTarget
struct BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7;
// UnityEngine.Camera
struct Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C;
// UnityEngine.Component
struct Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684;
// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_tD28930C89A154AEB1C4DD587AA8A1389CEAEE344;
// UnityEngine.GameObject
struct GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319;
// System.Collections.IDictionary
struct IDictionary_t99871C56B8EC2452AC5C4CF3831695E617B89D3A;
// Unity.MARS.MARSHandles.Picking.IPickingTarget
struct IPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB;
// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_t4D30CEA2439868B6B60391A1D8183AB799BC9787;
// Unity.MARS.MARSHandles.Picking.LinePickingTarget
struct LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E;
// UnityEngine.Mesh
struct Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6;
// Unity.MARS.MARSHandles.Picking.MeshPickingTarget
struct MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A;
// UnityEngine.Object
struct Object_tF2F3778131EFF286AF62B7B013A170F95A91571A;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F;
// System.String
struct String_t;
// UnityEngine.Transform
struct Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1;
// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;
// UnityEngine.Camera/CameraCallback
struct CameraCallback_tD9E7B69E561CE2EFDEEDB0E7F1406AC52247160D;

IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_t00B5CAC82DBD853D6781EA9FA2C2A064B75DEC20_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyCollection_1_t0F24F6C717B909765BFCCA5E6A79B3C882E07224_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyCollection_1_t243346DE4DC0DF3201B49FF3A837D684C549B76B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyCollection_1_tBC27CAF7F2490DC08F9AA8985A90C3A910C5FE69_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyCollection_1_tEB2B5EE0BB8413A0FF90FB1624044333432ABEA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_t0FBD6E83DD1841DFB0D8CE23A45ED0B6E9AF771A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_t7453370C5361E060CD390551EC47318B25EDE91A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_t7D0A2C175B46FF20C9F2E14C757BF91753001159_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_t8DA862FFC86BFEF2B4384525D73EC4D91635F3D7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F____D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA;
IL2CPP_EXTERN_C String_t* _stringLiteral9AB16B3999460DDC981865934D979087351A14F2;
IL2CPP_EXTERN_C String_t* _stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponentsInChildren_TisIPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_m7BB524C7FE414F16DBEEA4696F0C6415A6116D3D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_AddRange_m9640467223CE5B5ABBCB62A755853AEA413B6C92_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_m8428F99BD4D11C58BEC2ECDE6671CCB859ED680B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mF8F23D572031748AD428623AE16803455997E297_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHoveredAll_mE836AF54ADB43B26F4CDCB6969E5E9B68941B6A4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHoveredAll_mF5A08D13C5DDDC8D7A7461A7CAD0D363ED6B89D3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHovered_m260AA61C97C7B579C025071E0A0505EECAB978B5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46_RuntimeMethod_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32;
struct PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341;
struct SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA;
struct Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA;
struct Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t699F1D49D430196519B3E3C3A57CE5BE421AA32B 
{
public:

public:
};


// System.Object


// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>
struct List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856, ____items_1)); }
	inline IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* get__items_1() const { return ____items_1; }
	inline IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_StaticFields, ____emptyArray_5)); }
	inline IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* get__emptyArray_5() const { return ____emptyArray_5; }
	inline IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(IPickingTargetU5BU5D_tF046A871B67D2B9E0CFBA15093C397C7114B8EE9* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


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


// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>
struct List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124, ____items_1)); }
	inline PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* get__items_1() const { return ____items_1; }
	inline PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124_StaticFields, ____emptyArray_5)); }
	inline PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* get__emptyArray_5() const { return ____emptyArray_5; }
	inline PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* value)
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


// Unity.MARS.MARSHandles.MathUtility
struct MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C  : public RuntimeObject
{
public:

public:
};

struct MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields
{
public:
	// System.Single[] Unity.MARS.MARSHandles.MathUtility::s_QuadDistanceBuffer
	SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* ___s_QuadDistanceBuffer_0;
	// UnityEngine.Vector2[] Unity.MARS.MARSHandles.MathUtility::s_QuadBuffer
	Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ___s_QuadBuffer_1;

public:
	inline static int32_t get_offset_of_s_QuadDistanceBuffer_0() { return static_cast<int32_t>(offsetof(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields, ___s_QuadDistanceBuffer_0)); }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* get_s_QuadDistanceBuffer_0() const { return ___s_QuadDistanceBuffer_0; }
	inline SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA** get_address_of_s_QuadDistanceBuffer_0() { return &___s_QuadDistanceBuffer_0; }
	inline void set_s_QuadDistanceBuffer_0(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* value)
	{
		___s_QuadDistanceBuffer_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_QuadDistanceBuffer_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_QuadBuffer_1() { return static_cast<int32_t>(offsetof(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields, ___s_QuadBuffer_1)); }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* get_s_QuadBuffer_1() const { return ___s_QuadBuffer_1; }
	inline Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA** get_address_of_s_QuadBuffer_1() { return &___s_QuadBuffer_1; }
	inline void set_s_QuadBuffer_1(Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* value)
	{
		___s_QuadBuffer_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_QuadBuffer_1), (void*)value);
	}
};


// Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility
struct ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB  : public RuntimeObject
{
public:

public:
};

struct ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Vector3> Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::s_VertexBuffer
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___s_VertexBuffer_0;
	// System.Collections.Generic.List`1<UnityEngine.Vector2> Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::s_ScreenProjectedVertices
	List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * ___s_ScreenProjectedVertices_1;
	// System.Collections.Generic.List`1<System.Int32> Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::s_IndicesBuffer
	List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___s_IndicesBuffer_2;
	// UnityEngine.Vector3[] Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::s_PointsBuffer
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___s_PointsBuffer_3;

public:
	inline static int32_t get_offset_of_s_VertexBuffer_0() { return static_cast<int32_t>(offsetof(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields, ___s_VertexBuffer_0)); }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * get_s_VertexBuffer_0() const { return ___s_VertexBuffer_0; }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 ** get_address_of_s_VertexBuffer_0() { return &___s_VertexBuffer_0; }
	inline void set_s_VertexBuffer_0(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * value)
	{
		___s_VertexBuffer_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_VertexBuffer_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_ScreenProjectedVertices_1() { return static_cast<int32_t>(offsetof(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields, ___s_ScreenProjectedVertices_1)); }
	inline List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * get_s_ScreenProjectedVertices_1() const { return ___s_ScreenProjectedVertices_1; }
	inline List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 ** get_address_of_s_ScreenProjectedVertices_1() { return &___s_ScreenProjectedVertices_1; }
	inline void set_s_ScreenProjectedVertices_1(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * value)
	{
		___s_ScreenProjectedVertices_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_ScreenProjectedVertices_1), (void*)value);
	}

	inline static int32_t get_offset_of_s_IndicesBuffer_2() { return static_cast<int32_t>(offsetof(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields, ___s_IndicesBuffer_2)); }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * get_s_IndicesBuffer_2() const { return ___s_IndicesBuffer_2; }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 ** get_address_of_s_IndicesBuffer_2() { return &___s_IndicesBuffer_2; }
	inline void set_s_IndicesBuffer_2(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * value)
	{
		___s_IndicesBuffer_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_IndicesBuffer_2), (void*)value);
	}

	inline static int32_t get_offset_of_s_PointsBuffer_3() { return static_cast<int32_t>(offsetof(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields, ___s_PointsBuffer_3)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get_s_PointsBuffer_3() const { return ___s_PointsBuffer_3; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of_s_PointsBuffer_3() { return &___s_PointsBuffer_3; }
	inline void set_s_PointsBuffer_3(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
	{
		___s_PointsBuffer_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_PointsBuffer_3), (void*)value);
	}
};


// Unity.MARS.MARSHandles.Picking.ScreenPickingUtility
struct ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C  : public RuntimeObject
{
public:

public:
};

struct ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields
{
public:
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit> Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::s_HitsBuffer
	List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * ___s_HitsBuffer_0;
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget> Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::s_TargetsBuffer
	List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * ___s_TargetsBuffer_1;
	// System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget> Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::s_ComponentBuffer
	List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * ___s_ComponentBuffer_2;

public:
	inline static int32_t get_offset_of_s_HitsBuffer_0() { return static_cast<int32_t>(offsetof(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields, ___s_HitsBuffer_0)); }
	inline List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * get_s_HitsBuffer_0() const { return ___s_HitsBuffer_0; }
	inline List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 ** get_address_of_s_HitsBuffer_0() { return &___s_HitsBuffer_0; }
	inline void set_s_HitsBuffer_0(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * value)
	{
		___s_HitsBuffer_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_HitsBuffer_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_TargetsBuffer_1() { return static_cast<int32_t>(offsetof(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields, ___s_TargetsBuffer_1)); }
	inline List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * get_s_TargetsBuffer_1() const { return ___s_TargetsBuffer_1; }
	inline List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 ** get_address_of_s_TargetsBuffer_1() { return &___s_TargetsBuffer_1; }
	inline void set_s_TargetsBuffer_1(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * value)
	{
		___s_TargetsBuffer_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_TargetsBuffer_1), (void*)value);
	}

	inline static int32_t get_offset_of_s_ComponentBuffer_2() { return static_cast<int32_t>(offsetof(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields, ___s_ComponentBuffer_2)); }
	inline List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * get_s_ComponentBuffer_2() const { return ___s_ComponentBuffer_2; }
	inline List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 ** get_address_of_s_ComponentBuffer_2() { return &___s_ComponentBuffer_2; }
	inline void set_s_ComponentBuffer_2(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * value)
	{
		___s_ComponentBuffer_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_ComponentBuffer_2), (void*)value);
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
struct EmbeddedAttribute_tD28930C89A154AEB1C4DD587AA8A1389CEAEE344  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
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
struct IsReadOnlyAttribute_t4D30CEA2439868B6B60391A1D8183AB799BC9787  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
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


// Unity.MARS.MARSHandles.Picking.PickingHit
struct PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 
{
public:
	// System.Single Unity.MARS.MARSHandles.Picking.PickingHit::<distance>k__BackingField
	float ___U3CdistanceU3Ek__BackingField_0;
	// Unity.MARS.MARSHandles.Picking.IPickingTarget Unity.MARS.MARSHandles.Picking.PickingHit::<target>k__BackingField
	RuntimeObject* ___U3CtargetU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CdistanceU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83, ___U3CdistanceU3Ek__BackingField_0)); }
	inline float get_U3CdistanceU3Ek__BackingField_0() const { return ___U3CdistanceU3Ek__BackingField_0; }
	inline float* get_address_of_U3CdistanceU3Ek__BackingField_0() { return &___U3CdistanceU3Ek__BackingField_0; }
	inline void set_U3CdistanceU3Ek__BackingField_0(float value)
	{
		___U3CdistanceU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CtargetU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83, ___U3CtargetU3Ek__BackingField_1)); }
	inline RuntimeObject* get_U3CtargetU3Ek__BackingField_1() const { return ___U3CtargetU3Ek__BackingField_1; }
	inline RuntimeObject** get_address_of_U3CtargetU3Ek__BackingField_1() { return &___U3CtargetU3Ek__BackingField_1; }
	inline void set_U3CtargetU3Ek__BackingField_1(RuntimeObject* value)
	{
		___U3CtargetU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CtargetU3Ek__BackingField_1), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.MARSHandles.Picking.PickingHit
struct PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_pinvoke
{
	float ___U3CdistanceU3Ek__BackingField_0;
	RuntimeObject* ___U3CtargetU3Ek__BackingField_1;
};
// Native definition for COM marshalling of Unity.MARS.MARSHandles.Picking.PickingHit
struct PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_com
{
	float ___U3CdistanceU3Ek__BackingField_0;
	RuntimeObject* ___U3CtargetU3Ek__BackingField_1;
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


// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=96
struct __StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C 
{
public:
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C__padding[96];
	};

public:
};


// Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad
struct Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 
{
public:
	// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::<indexA>k__BackingField
	int32_t ___U3CindexAU3Ek__BackingField_0;
	// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::<indexB>k__BackingField
	int32_t ___U3CindexBU3Ek__BackingField_1;
	// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::<indexC>k__BackingField
	int32_t ___U3CindexCU3Ek__BackingField_2;
	// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::<indexD>k__BackingField
	int32_t ___U3CindexDU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CindexAU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85, ___U3CindexAU3Ek__BackingField_0)); }
	inline int32_t get_U3CindexAU3Ek__BackingField_0() const { return ___U3CindexAU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CindexAU3Ek__BackingField_0() { return &___U3CindexAU3Ek__BackingField_0; }
	inline void set_U3CindexAU3Ek__BackingField_0(int32_t value)
	{
		___U3CindexAU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CindexBU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85, ___U3CindexBU3Ek__BackingField_1)); }
	inline int32_t get_U3CindexBU3Ek__BackingField_1() const { return ___U3CindexBU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CindexBU3Ek__BackingField_1() { return &___U3CindexBU3Ek__BackingField_1; }
	inline void set_U3CindexBU3Ek__BackingField_1(int32_t value)
	{
		___U3CindexBU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CindexCU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85, ___U3CindexCU3Ek__BackingField_2)); }
	inline int32_t get_U3CindexCU3Ek__BackingField_2() const { return ___U3CindexCU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CindexCU3Ek__BackingField_2() { return &___U3CindexCU3Ek__BackingField_2; }
	inline void set_U3CindexCU3Ek__BackingField_2(int32_t value)
	{
		___U3CindexCU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CindexDU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85, ___U3CindexDU3Ek__BackingField_3)); }
	inline int32_t get_U3CindexDU3Ek__BackingField_3() const { return ___U3CindexDU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CindexDU3Ek__BackingField_3() { return &___U3CindexDU3Ek__BackingField_3; }
	inline void set_U3CindexDU3Ek__BackingField_3(int32_t value)
	{
		___U3CindexDU3Ek__BackingField_3 = value;
	}
};


// System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>
struct Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::list
	List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * ___list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC, ___list_0)); }
	inline List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * get_list_0() const { return ___list_0; }
	inline List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC, ___current_3)); }
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  get_current_3() const { return ___current_3; }
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((void**)&(((&___current_3))->___U3CtargetU3Ek__BackingField_1), (void*)NULL);
	}
};


// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F  : public RuntimeObject
{
public:

public:
};

struct U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F_StaticFields
{
public:
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=96 <PrivateImplementationDetails>::D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133
	__StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C  ___D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0;

public:
	inline static int32_t get_offset_of_D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0() { return static_cast<int32_t>(offsetof(U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F_StaticFields, ___D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0)); }
	inline __StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C  get_D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0() const { return ___D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0; }
	inline __StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C * get_address_of_D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0() { return &___D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0; }
	inline void set_D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0(__StaticArrayInitTypeSizeU3D96_t175E7D3246C9CCC5C481895D2037E0352493669C  value)
	{
		___D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0 = value;
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

// UnityEngine.MeshTopology
struct MeshTopology_tF37D1A0C174D5906B715580E7318A21B4263C1A6 
{
public:
	// System.Int32 UnityEngine.MeshTopology::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MeshTopology_tF37D1A0C174D5906B715580E7318A21B4263C1A6, ___value___2)); }
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

// Unity.MARS.MARSHandles.Picking.PickingData
struct PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 
{
public:
	// UnityEngine.Matrix4x4 Unity.MARS.MARSHandles.Picking.PickingData::<matrix>k__BackingField
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___U3CmatrixU3Ek__BackingField_1;
	// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.PickingData::<mesh>k__BackingField
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___U3CmeshU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CmatrixU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207, ___U3CmatrixU3Ek__BackingField_1)); }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  get_U3CmatrixU3Ek__BackingField_1() const { return ___U3CmatrixU3Ek__BackingField_1; }
	inline Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * get_address_of_U3CmatrixU3Ek__BackingField_1() { return &___U3CmatrixU3Ek__BackingField_1; }
	inline void set_U3CmatrixU3Ek__BackingField_1(Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  value)
	{
		___U3CmatrixU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CmeshU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207, ___U3CmeshU3Ek__BackingField_2)); }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * get_U3CmeshU3Ek__BackingField_2() const { return ___U3CmeshU3Ek__BackingField_2; }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 ** get_address_of_U3CmeshU3Ek__BackingField_2() { return &___U3CmeshU3Ek__BackingField_2; }
	inline void set_U3CmeshU3Ek__BackingField_2(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * value)
	{
		___U3CmeshU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CmeshU3Ek__BackingField_2), (void*)value);
	}
};

struct PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_StaticFields
{
public:
	// Unity.MARS.MARSHandles.Picking.PickingData Unity.MARS.MARSHandles.Picking.PickingData::invalid
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  ___invalid_0;

public:
	inline static int32_t get_offset_of_invalid_0() { return static_cast<int32_t>(offsetof(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_StaticFields, ___invalid_0)); }
	inline PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  get_invalid_0() const { return ___invalid_0; }
	inline PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * get_address_of_invalid_0() { return &___invalid_0; }
	inline void set_invalid_0(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  value)
	{
		___invalid_0 = value;
		Il2CppCodeGenWriteBarrier((void**)&(((&___invalid_0))->___U3CmeshU3Ek__BackingField_2), (void*)NULL);
	}
};

// Native definition for P/Invoke marshalling of Unity.MARS.MARSHandles.Picking.PickingData
struct PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_pinvoke
{
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___U3CmatrixU3Ek__BackingField_1;
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___U3CmeshU3Ek__BackingField_2;
};
// Native definition for COM marshalling of Unity.MARS.MARSHandles.Picking.PickingData
struct PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_com
{
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___U3CmatrixU3Ek__BackingField_1;
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___U3CmeshU3Ek__BackingField_2;
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


// System.RuntimeFieldHandle
struct RuntimeFieldHandle_t7BE65FC857501059EBAC9772C93B02CD413D9C96 
{
public:
	// System.IntPtr System.RuntimeFieldHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeFieldHandle_t7BE65FC857501059EBAC9772C93B02CD413D9C96, ___value_0)); }
	inline intptr_t get_value_0() const { return ___value_0; }
	inline intptr_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(intptr_t value)
	{
		___value_0 = value;
	}
};


// Unity.MARS.MARSHandles.MathUtility/Bounds2D
struct Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F 
{
public:
	// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::<center>k__BackingField
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___U3CcenterU3Ek__BackingField_0;
	// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::<size>k__BackingField
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___U3CsizeU3Ek__BackingField_1;
	// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::<extents>k__BackingField
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___U3CextentsU3Ek__BackingField_2;
	// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::<xMin>k__BackingField
	float ___U3CxMinU3Ek__BackingField_3;
	// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::<xMax>k__BackingField
	float ___U3CxMaxU3Ek__BackingField_4;
	// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::<yMin>k__BackingField
	float ___U3CyMinU3Ek__BackingField_5;
	// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::<yMax>k__BackingField
	float ___U3CyMaxU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of_U3CcenterU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CcenterU3Ek__BackingField_0)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_U3CcenterU3Ek__BackingField_0() const { return ___U3CcenterU3Ek__BackingField_0; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_U3CcenterU3Ek__BackingField_0() { return &___U3CcenterU3Ek__BackingField_0; }
	inline void set_U3CcenterU3Ek__BackingField_0(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___U3CcenterU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CsizeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CsizeU3Ek__BackingField_1)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_U3CsizeU3Ek__BackingField_1() const { return ___U3CsizeU3Ek__BackingField_1; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_U3CsizeU3Ek__BackingField_1() { return &___U3CsizeU3Ek__BackingField_1; }
	inline void set_U3CsizeU3Ek__BackingField_1(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___U3CsizeU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CextentsU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CextentsU3Ek__BackingField_2)); }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  get_U3CextentsU3Ek__BackingField_2() const { return ___U3CextentsU3Ek__BackingField_2; }
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * get_address_of_U3CextentsU3Ek__BackingField_2() { return &___U3CextentsU3Ek__BackingField_2; }
	inline void set_U3CextentsU3Ek__BackingField_2(Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		___U3CextentsU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CxMinU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CxMinU3Ek__BackingField_3)); }
	inline float get_U3CxMinU3Ek__BackingField_3() const { return ___U3CxMinU3Ek__BackingField_3; }
	inline float* get_address_of_U3CxMinU3Ek__BackingField_3() { return &___U3CxMinU3Ek__BackingField_3; }
	inline void set_U3CxMinU3Ek__BackingField_3(float value)
	{
		___U3CxMinU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CxMaxU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CxMaxU3Ek__BackingField_4)); }
	inline float get_U3CxMaxU3Ek__BackingField_4() const { return ___U3CxMaxU3Ek__BackingField_4; }
	inline float* get_address_of_U3CxMaxU3Ek__BackingField_4() { return &___U3CxMaxU3Ek__BackingField_4; }
	inline void set_U3CxMaxU3Ek__BackingField_4(float value)
	{
		___U3CxMaxU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CyMinU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CyMinU3Ek__BackingField_5)); }
	inline float get_U3CyMinU3Ek__BackingField_5() const { return ___U3CyMinU3Ek__BackingField_5; }
	inline float* get_address_of_U3CyMinU3Ek__BackingField_5() { return &___U3CyMinU3Ek__BackingField_5; }
	inline void set_U3CyMinU3Ek__BackingField_5(float value)
	{
		___U3CyMinU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CyMaxU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F, ___U3CyMaxU3Ek__BackingField_6)); }
	inline float get_U3CyMaxU3Ek__BackingField_6() const { return ___U3CyMaxU3Ek__BackingField_6; }
	inline float* get_address_of_U3CyMaxU3Ek__BackingField_6() { return &___U3CyMaxU3Ek__BackingField_6; }
	inline void set_U3CyMaxU3Ek__BackingField_6(float value)
	{
		___U3CyMaxU3Ek__BackingField_6 = value;
	}
};


// UnityEngine.Component
struct Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// UnityEngine.GameObject
struct GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
{
public:

public:
};


// UnityEngine.Mesh
struct Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6  : public Object_tF2F3778131EFF286AF62B7B013A170F95A91571A
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


// UnityEngine.Transform
struct Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1  : public Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684
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


// UnityEngine.MonoBehaviour
struct MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A  : public Behaviour_t1A3DDDCF73B4627928FBFE02ED52B7251777DBD9
{
public:

public:
};


// Unity.MARS.MARSHandles.Picking.BoxPickingTarget
struct BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.BoxPickingTarget::m_Offset
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Offset_4;
	// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.BoxPickingTarget::m_Size
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___m_Size_5;
	// UnityEngine.Transform Unity.MARS.MARSHandles.Picking.BoxPickingTarget::m_Transform
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___m_Transform_6;
	// UnityEngine.Vector3[] Unity.MARS.MARSHandles.Picking.BoxPickingTarget::m_Vertices
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___m_Vertices_8;
	// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.BoxPickingTarget::m_Mesh
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___m_Mesh_9;

public:
	inline static int32_t get_offset_of_m_Offset_4() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7, ___m_Offset_4)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Offset_4() const { return ___m_Offset_4; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Offset_4() { return &___m_Offset_4; }
	inline void set_m_Offset_4(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Offset_4 = value;
	}

	inline static int32_t get_offset_of_m_Size_5() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7, ___m_Size_5)); }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  get_m_Size_5() const { return ___m_Size_5; }
	inline Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * get_address_of_m_Size_5() { return &___m_Size_5; }
	inline void set_m_Size_5(Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  value)
	{
		___m_Size_5 = value;
	}

	inline static int32_t get_offset_of_m_Transform_6() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7, ___m_Transform_6)); }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * get_m_Transform_6() const { return ___m_Transform_6; }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 ** get_address_of_m_Transform_6() { return &___m_Transform_6; }
	inline void set_m_Transform_6(Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * value)
	{
		___m_Transform_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Transform_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Vertices_8() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7, ___m_Vertices_8)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get_m_Vertices_8() const { return ___m_Vertices_8; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of_m_Vertices_8() { return &___m_Vertices_8; }
	inline void set_m_Vertices_8(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
	{
		___m_Vertices_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Vertices_8), (void*)value);
	}

	inline static int32_t get_offset_of_m_Mesh_9() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7, ___m_Mesh_9)); }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * get_m_Mesh_9() const { return ___m_Mesh_9; }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 ** get_address_of_m_Mesh_9() { return &___m_Mesh_9; }
	inline void set_m_Mesh_9(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * value)
	{
		___m_Mesh_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Mesh_9), (void*)value);
	}
};

struct BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_StaticFields
{
public:
	// System.Int32[] Unity.MARS.MARSHandles.Picking.BoxPickingTarget::s_Indices
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ___s_Indices_7;

public:
	inline static int32_t get_offset_of_s_Indices_7() { return static_cast<int32_t>(offsetof(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_StaticFields, ___s_Indices_7)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get_s_Indices_7() const { return ___s_Indices_7; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of_s_Indices_7() { return &___s_Indices_7; }
	inline void set_s_Indices_7(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		___s_Indices_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_Indices_7), (void*)value);
	}
};


// Unity.MARS.MARSHandles.Picking.LinePickingTarget
struct LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// UnityEngine.Vector3[] Unity.MARS.MARSHandles.Picking.LinePickingTarget::m_Points
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___m_Points_4;
	// System.Collections.Generic.List`1<UnityEngine.Vector3> Unity.MARS.MARSHandles.Picking.LinePickingTarget::m_Vertices
	List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___m_Vertices_5;
	// System.Collections.Generic.List`1<System.Int32> Unity.MARS.MARSHandles.Picking.LinePickingTarget::m_Indices
	List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___m_Indices_6;
	// UnityEngine.Transform Unity.MARS.MARSHandles.Picking.LinePickingTarget::m_Transform
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___m_Transform_7;
	// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.LinePickingTarget::m_Mesh
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___m_Mesh_8;

public:
	inline static int32_t get_offset_of_m_Points_4() { return static_cast<int32_t>(offsetof(LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E, ___m_Points_4)); }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* get_m_Points_4() const { return ___m_Points_4; }
	inline Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4** get_address_of_m_Points_4() { return &___m_Points_4; }
	inline void set_m_Points_4(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* value)
	{
		___m_Points_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Points_4), (void*)value);
	}

	inline static int32_t get_offset_of_m_Vertices_5() { return static_cast<int32_t>(offsetof(LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E, ___m_Vertices_5)); }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * get_m_Vertices_5() const { return ___m_Vertices_5; }
	inline List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 ** get_address_of_m_Vertices_5() { return &___m_Vertices_5; }
	inline void set_m_Vertices_5(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * value)
	{
		___m_Vertices_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Vertices_5), (void*)value);
	}

	inline static int32_t get_offset_of_m_Indices_6() { return static_cast<int32_t>(offsetof(LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E, ___m_Indices_6)); }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * get_m_Indices_6() const { return ___m_Indices_6; }
	inline List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 ** get_address_of_m_Indices_6() { return &___m_Indices_6; }
	inline void set_m_Indices_6(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * value)
	{
		___m_Indices_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Indices_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Transform_7() { return static_cast<int32_t>(offsetof(LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E, ___m_Transform_7)); }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * get_m_Transform_7() const { return ___m_Transform_7; }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 ** get_address_of_m_Transform_7() { return &___m_Transform_7; }
	inline void set_m_Transform_7(Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * value)
	{
		___m_Transform_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Transform_7), (void*)value);
	}

	inline static int32_t get_offset_of_m_Mesh_8() { return static_cast<int32_t>(offsetof(LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E, ___m_Mesh_8)); }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * get_m_Mesh_8() const { return ___m_Mesh_8; }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 ** get_address_of_m_Mesh_8() { return &___m_Mesh_8; }
	inline void set_m_Mesh_8(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * value)
	{
		___m_Mesh_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Mesh_8), (void*)value);
	}
};


// Unity.MARS.MARSHandles.Picking.MeshPickingTarget
struct MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A  : public MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A
{
public:
	// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.MeshPickingTarget::m_CollisionMesh
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___m_CollisionMesh_4;
	// UnityEngine.Transform Unity.MARS.MARSHandles.Picking.MeshPickingTarget::m_Transform
	Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___m_Transform_5;

public:
	inline static int32_t get_offset_of_m_CollisionMesh_4() { return static_cast<int32_t>(offsetof(MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A, ___m_CollisionMesh_4)); }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * get_m_CollisionMesh_4() const { return ___m_CollisionMesh_4; }
	inline Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 ** get_address_of_m_CollisionMesh_4() { return &___m_CollisionMesh_4; }
	inline void set_m_CollisionMesh_4(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * value)
	{
		___m_CollisionMesh_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_CollisionMesh_4), (void*)value);
	}

	inline static int32_t get_offset_of_m_Transform_5() { return static_cast<int32_t>(offsetof(MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A, ___m_Transform_5)); }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * get_m_Transform_5() const { return ___m_Transform_5; }
	inline Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 ** get_address_of_m_Transform_5() { return &___m_Transform_5; }
	inline void set_m_Transform_5(Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * value)
	{
		___m_Transform_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Transform_5), (void*)value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
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
// System.Int32[]
struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) int32_t m_Items[1];

public:
	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  m_Items[1];

public:
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  value)
	{
		m_Items[index] = value;
	}
};
// System.Single[]
struct SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) float m_Items[1];

public:
	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
};
// Unity.MARS.MARSHandles.Picking.PickingHit[]
struct PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  m_Items[1];

public:
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___U3CtargetU3Ek__BackingField_1), (void*)NULL);
	}
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___U3CtargetU3Ek__BackingField_1), (void*)NULL);
	}
};


// System.Int32 System.Collections.Generic.List`1<System.Int32>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_gshared_inline (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Int32>::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A_gshared (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Int32>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F_gshared (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, int32_t ___item0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702_gshared (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59_gshared (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___item0, const RuntimeMethod* method);
// !0[] System.Collections.Generic.List`1<System.Int32>::ToArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F_gshared (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mF8F23D572031748AD428623AE16803455997E297_gshared (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Int32>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD_gshared (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<UnityEngine.Vector2>::get_Item(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_gshared_inline (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * __this, int32_t ___index0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82_gshared (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, int32_t ___capacity0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C_gshared (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * __this, int32_t ___capacity0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Int32>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91_gshared (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, int32_t ___capacity0, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC  List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4_gshared (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_gshared_inline (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24_gshared (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA_gshared (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910_gshared (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85_gshared (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___item0, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_gshared_inline (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method);
// !0[] System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::ToArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B_gshared (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Clear_m5FB5A9C59D8625FDFB06876C4D8848F0F07ABFD0_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::GetComponentsInChildren<System.Object>(System.Boolean,System.Collections.Generic.List`1<!!0>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GameObject_GetComponentsInChildren_TisRuntimeObject_m469A375D3582C80E94A37018DAA2444835E1CFFA_gshared (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, bool ___includeInactive0, List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * ___results1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::AddRange(System.Collections.Generic.IEnumerable`1<!0>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_AddRange_m6465DEF706EB529B4227F2AF79338419D517EDF9_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject* ___collection0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF_gshared (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, int32_t ___capacity0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_mFEB2301A6F28290A828A979BA9CC847B16B3D538_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, int32_t ___capacity0, const RuntimeMethod* method);

// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::UpdatePickingMeshData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method);
// UnityEngine.Transform UnityEngine.Component::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F (Component_t62FBC8D2420DA4BE9037AFE430740F6B3EECA684 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::EnsureMeshExists()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_EnsureMeshExists_mF3CCFEF007BC84970F31FDF86C35730C3F12B618 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Object::DestroyImmediate(UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_DestroyImmediate_mCCED69F4D4C9A4FA3AC30A142CF3D7F085F7C422 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___obj0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::.ctor(UnityEngine.Transform,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593 (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___trs0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method);
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::set_vertices(UnityEngine.Vector3[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_set_vertices_m38F0908D0FDFE484BE19E94BE9D6176667469AAD (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___value0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___x0, Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___y1, const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh__ctor_mA3D8570373462201AD7B8C9586A7F9412E49C2F6 (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_zero()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6 (const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::SetIndices(System.Int32[],UnityEngine.MeshTopology,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_SetIndices_mCD0377083E978A3FF806CFCCD28410C042A77ECD (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ___indices0, int32_t ___topology1, int32_t ___submesh2, const RuntimeMethod* method);
// UnityEngine.Color UnityEngine.Color::get_green()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  Color_get_green_mFF9BD42534D385A0717B1EAD083ADF08712984B9 (const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::set_color(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F (Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  ___value0, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Transform::get_localToWorldMatrix()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC (Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::set_matrix(UnityEngine.Matrix4x4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C (Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawWireCube(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawWireCube_mC526244E50C6E5793D4066C9C99023D5FF8424BF (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___size1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_one()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB (const RuntimeMethod* method);
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED (MonoBehaviour_t37A501200D970A8257124B0EAE00A0FF3DDC354A * __this, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(System.Array,System.RuntimeFieldHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_mE27238308FED781F2D6A719F0903F2E1311B058F (RuntimeArray * ___array0, RuntimeFieldHandle_t7BE65FC857501059EBAC9772C93B02CD413D9C96  ___fldHandle1, const RuntimeMethod* method);
// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1 (Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71 * __this, const RuntimeMethod* method);
// System.Void System.Array::Copy(System.Array,System.Array,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Array_Copy_m40103AA97DC582C557B912CF4BBE86A4D166F803 (RuntimeArray * ___sourceArray0, RuntimeArray * ___destinationArray1, int32_t ___length2, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::UpdatePickingMeshData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_UpdatePickingMeshData_m13BD50449889D504A14C2A67D6A42C88D6EF49DF (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::EnsureMeshExists()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_EnsureMeshExists_m41CE41CBFAF6F99E4DD5CBEBE323EE870A4691B9 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Int32>::get_Count()
inline int32_t List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_inline (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, const RuntimeMethod*))List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_gshared_inline)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.Int32>::Clear()
inline void List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, const RuntimeMethod*))List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.Int32>::Add(!0)
inline void List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, int32_t ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, int32_t, const RuntimeMethod*))List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F_gshared)(__this, ___item0, method);
}
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::Clear()
inline void List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702 (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *, const RuntimeMethod*))List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::Add(!0)
inline void List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59 (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , const RuntimeMethod*))List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59_gshared)(__this, ___item0, method);
}
// System.Void UnityEngine.Mesh::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_Clear_m7500ECE6209E14CC750CB16B48301B8D2A57ACCE (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::SetVertices(System.Collections.Generic.List`1<UnityEngine.Vector3>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_SetVertices_m08C90A1665735C09E15E17DE1A8CD9F196762BCD (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___inVertices0, const RuntimeMethod* method);
// !0[] System.Collections.Generic.List`1<System.Int32>::ToArray()
inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method)
{
	return ((  Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, const RuntimeMethod*))List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F_gshared)(__this, method);
}
// System.Void UnityEngine.Gizmos::DrawLine(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawLine_m91F1AA0205C7D53D2AA8E2F1D7B338E601A30823 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___to1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor()
inline void List_1__ctor_mF8F23D572031748AD428623AE16803455997E297 (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *, const RuntimeMethod*))List_1__ctor_mF8F23D572031748AD428623AE16803455997E297_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.Int32>::.ctor()
inline void List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, const RuntimeMethod*))List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD_gshared)(__this, method);
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::ProjectPointLine(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_ProjectPointLine_mB5B8E5B5620CA6CC6C410F05EC6A79A83D57A015 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineStart1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineEnd2, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Subtraction(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::Magnitude(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Magnitude_mFBD4702FB2F35452191EC918B9B09766A5761854_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___vector0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::get_magnitude()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector3_get_magnitude_mDDD40612220D8104E77E993E18A101A69A944991 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Division(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_op_Division_mE5ACBFB168FED529587457A83BA98B7DB32E2A05_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, float ___d1, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::Dot(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lhs0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rhs1, const RuntimeMethod* method);
// System.Single UnityEngine.Mathf::Clamp(System.Single,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_Clamp_m2416F3B785C8F135863E3D17E5B0CB4174797B87 (float ___value0, float ___min1, float ___max2, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Ray::get_origin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Ray_get_origin_m0C1B2BFF99CDF5231AC29AC031C161F55B53C1D0 (Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Ray::get_direction()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Ray_get_direction_m2B31F86F19B64474A901B28D3808011AE7A13EFC (Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Project(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Project_m57D54B16F36E620C294F4B209CD4C8E46A58D1B6 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___vector0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___onNormal1, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::op_Subtraction(UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b1, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::Perpendicular(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_Perpendicular_mAD7805BEB4D362E2E08DA6C0FF48CA55F8B7EE71_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___inDirection0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector2::Dot(UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lhs0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___rhs1, const RuntimeMethod* method);
// System.Int32 System.Math::Sign(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Math_Sign_m607F7014224C0DD1D1F6D7B44DAB00A2A16CCC8F (float ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToLine(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lineStart1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lineEnd2, const RuntimeMethod* method);
// System.Single UnityEngine.Mathf::Min(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14 (float ___a0, float ___b1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::.ctor(UnityEngine.Vector2[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D__ctor_mC43E45A8EEBCBCCE6A0E0AF20209E7A13EC1A175 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ___points0, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.MathUtility/Bounds2D::Contains(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Bounds2D_Contains_mED66DDD213D76D4DD9CF1C97F1FA6EA149ADB1BD (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, const RuntimeMethod* method);
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_center()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector2::op_Implicit(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___v0, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::GetEdgeCenter(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_GetEdgeCenter_mFA5BBB90ECC03114D6BD5DAA427C015D5EE0EABB (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::op_Implicit(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___v0, const RuntimeMethod* method);
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_size()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::op_Multiply(UnityEngine.Vector2,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Multiply_mC7A7802352867555020A90205EBABA56EE5E36CB_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, float ___d1, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::op_Addition(UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Addition_m5EACC2AEA80FEE29F380397CF1F4B11D04BE71CC_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b1, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.MathUtility::AreSegmentIntersecting(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MathUtility_AreSegmentIntersecting_mB80AB09642DE4B11F11B364159009FEFF246EC90 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a10, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b11, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a22, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b23, const RuntimeMethod* method);
// System.Single UnityEngine.Mathf::Min(System.Single[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_Min_mBFD6E1F7B1716EB3113CDEA310FA42D8968E16AF (SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* ___values0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector2::Distance(UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b1, const RuntimeMethod* method);
// UnityEngine.Vector2 UnityEngine.Vector2::op_Multiply(System.Single,UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Multiply_m841D5292C48DAD9746A2F4EED9CE7A76CDB652EA_inline (float ___d0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, const RuntimeMethod* method);
// System.Void UnityEngine.Gizmos::DrawWireMesh(UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Gizmos_DrawWireMesh_m93445D06F241AB0F2BDEA4A9FC3A8EF338BDCE7A (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh0, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 Unity.MARS.MARSHandles.Picking.PickingData::get_matrix()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::set_matrix(UnityEngine.Matrix4x4)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method);
// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.PickingData::get_mesh()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::set_mesh(UnityEngine.Mesh)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___value0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90 (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___x0, Object_tF2F3778131EFF286AF62B7B013A170F95A91571A * ___y1, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.Picking.PickingData::get_valid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PickingData_get_valid_m9E4DB569FB050062AA9F32683EE54CF90290007D (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::.ctor(UnityEngine.Matrix4x4,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData__ctor_m9AA17C27D68107EA85B0D2E9C9080C28C35E11BA (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.PickingHit::get_distance()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::set_distance(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, float ___value0, const RuntimeMethod* method);
// Unity.MARS.MARSHandles.Picking.IPickingTarget Unity.MARS.MARSHandles.Picking.PickingHit::get_target()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::set_target(Unity.MARS.MARSHandles.Picking.IPickingTarget)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, RuntimeObject* ___value0, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.Picking.PickingHit::get_valid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PickingHit_get_valid_m0309BF370D7469ED618ACDBB3BE97FD0F4D76D2D (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::.ctor(Unity.MARS.MARSHandles.Picking.IPickingTarget,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, RuntimeObject* ___target0, float ___distance1, const RuntimeMethod* method);
// System.Int32 System.Single::CompareTo(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Single_CompareTo_m80B5B5A70A2343C3A8673F35635EBED4458109B4 (float* __this, float ___value0, const RuntimeMethod* method);
// System.Int32 Unity.MARS.MARSHandles.Picking.PickingHit::CompareTo(Unity.MARS.MARSHandles.Picking.PickingHit)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PickingHit_CompareTo_mB57DE7FA031359D8916D9DEB46C8AEE6C3D65B91 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___other0, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_up()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_up_m38AECA68388D446CFADDD022B0B867293044EA50 (const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Cross(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lhs0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___rhs1, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::get_sqrMagnitude()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector3_get_sqrMagnitude_mC567EE6DF411501A8FE1F23A0038862630B88249 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_right()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_right_mF5A51F81961474E0A7A31C2757FD00921FB79C44 (const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ClosestPointToArc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScreenDistanceUtility_ClosestPointToArc_m7B6F700D23DEA1BBBBB40A641F7D86ABD4255DCF (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera6, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::GetDiscSectionPoints(System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenDistanceUtility_GetDiscSectionPoints_mA9979A0C3F41E052338BC97D6A53F09ED33BAB6B (RuntimeObject* ___dest0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, const RuntimeMethod* method);
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ClosestPointToPolyLine(UnityEngine.Vector2,System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScreenDistanceUtility_ClosestPointToPolyLine_mCCEF9F4D4EB2CE0B403285731F916AAE6B3C147C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___vertices1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLine(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLine_mD6B8439755ABE686193114786AC2FE72947BF25C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___p11, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___p22, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera3, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Camera::WorldToScreenPoint(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___position0, const RuntimeMethod* method);
// System.Single UnityEngine.Vector2::get_magnitude()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Vector2_get_magnitude_mD30DB8EB73C4A5CD395745AE1CA1C38DC61D2E85 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Mathf::Clamp01(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_Clamp01_m2296D75F0F1292D5C8181C57007A1CA45F440C4C (float ___value0, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Lerp(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Lerp_m8E095584FFA10CF1D3EABCD04F4C83FB82EC5524_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, float ___t2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToArc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToArc_m77C4A4F3381513F3F34F4F0D28049BD41874FA7F (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera6, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToPolyLine(UnityEngine.Vector2,System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToPolyLine_m344A73E69BBC3041BFAFB9322B5BD2FD5735024C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___points1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToLine(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToLine_m806E9331F04A83733800190FBF5F96F4F487C762 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineStart1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineEnd2, const RuntimeMethod* method);
// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::get_identity()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  Matrix4x4_get_identity_mC91289718DDD3DDBE0A10551BDA59A446414A596 (const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ProjectVerticesOnScreen(UnityEngine.Camera,UnityEngine.Matrix4x4,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>,System.Collections.Generic.ICollection`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenDistanceUtility_ProjectVerticesOnScreen_m6B8A4BB50518A3A2376049ED34B60444C2AA668B (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix1, RuntimeObject* ___vertices2, RuntimeObject* ___results3, const RuntimeMethod* method);
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexA()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<UnityEngine.Vector2>::get_Item(System.Int32)
inline Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_inline (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * __this, int32_t ___index0, const RuntimeMethod* method)
{
	return ((  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  (*) (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 *, int32_t, const RuntimeMethod*))List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_gshared_inline)(__this, ___index0, method);
}
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexB()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method);
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexC()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method);
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexD()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToQuad(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToQuad_m7D07BBFDE23E1FDB204BB87795EA35B507729B54 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b2, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___c3, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___d4, const RuntimeMethod* method);
// UnityEngine.Quaternion UnityEngine.Quaternion::AngleAxis(System.Single,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  Quaternion_AngleAxis_m4644D20F58ADF03E9EA297CB4A845E5BCDA1E398 (float ___angle0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___axis1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::get_normalized()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_get_normalized_m2FA6DF38F97BDA4CCBDAE12B9FE913A241DAC8D5 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E * __this, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Quaternion::op_Multiply(UnityEngine.Quaternion,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D (Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  ___rotation0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Matrix4x4::MultiplyPoint(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Matrix4x4_MultiplyPoint_mE92BEE4DED3B602983C2BBE06C44AD29564EDA83 (Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::GetVertices(System.Collections.Generic.List`1<UnityEngine.Vector3>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_GetVertices_mCC533BC8D4A9F14BA1A54BABB11B01750C153015 (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * ___vertices0, const RuntimeMethod* method);
// System.Void UnityEngine.Mesh::GetIndices(System.Collections.Generic.List`1<System.Int32>,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_GetIndices_m1893F3E4888178EB0F26B7E98A9753C302C750B1 (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * ___indices0, int32_t ___submesh1, const RuntimeMethod* method);
// UnityEngine.MeshTopology UnityEngine.Mesh::GetTopology(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Mesh_GetTopology_m915B9BB8ABA4FF551B8E0F91529DCD5D0D48BD5C (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, int32_t ___submesh0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>,System.Collections.Generic.IReadOnlyList`1<System.Int32>,UnityEngine.MeshTopology)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToMesh_m4F39F587CFAA82AC18581F3DB47F9F7BCA48CE46 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___verticesOnScreen1, RuntimeObject* ___indices2, int32_t ___topology3, const RuntimeMethod* method);
// System.Int32 UnityEngine.Mesh::get_subMeshCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Mesh_get_subMeshCount_m60E2BCBFEEF21260C70D06EAEC3A2A51D80796FF (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * __this, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToTrianglesMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToTrianglesMesh_m14A521CCBF100CCA6E1546743EB70B677B1B477C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___triangles1, RuntimeObject* ___vertices2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToQuadsMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToQuadsMesh_m74E13339C4D18CB8ACDFCE21D3C81923B3318A30 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToPointsMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToPointsMesh_m428FEF3CD7F1E1AF93ECA181DDC5D1D9D35F5DDD (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLinesMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLinesMesh_m339DE7D6BF5DFF7EEE7817A5433F9CEFA18C13BF (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLineStripMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLineStripMesh_mCE8CF0D4EB48872D93E0664EA1ED2E2142DC7CA9 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToTriangle(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToTriangle_mB3ECBAE02FD0ED48F57CCE4137A94D55CC6DDD9B (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b2, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___c3, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(System.Int32)
inline void List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82 (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *, int32_t, const RuntimeMethod*))List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82_gshared)(__this, ___capacity0, method);
}
// System.Void System.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(System.Int32)
inline void List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 *, int32_t, const RuntimeMethod*))List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C_gshared)(__this, ___capacity0, method);
}
// System.Void System.Collections.Generic.List`1<System.Int32>::.ctor(System.Int32)
inline void List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91 (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *, int32_t, const RuntimeMethod*))List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91_gshared)(__this, ___capacity0, method);
}
// System.Void System.ArgumentNullException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97 (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * __this, String_t* ___paramName0, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * ___results4, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::GetEnumerator()
inline Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC  List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4 (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC  (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, const RuntimeMethod*))List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::get_Current()
inline PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_inline (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method)
{
	return ((  PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  (*) (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *, const RuntimeMethod*))Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_gshared_inline)(__this, method);
}
// System.Boolean System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::MoveNext()
inline bool Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24 (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *, const RuntimeMethod*))Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<Unity.MARS.MARSHandles.Picking.PickingHit>::Dispose()
inline void Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *, const RuntimeMethod*))Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA_gshared)(__this, method);
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetPickingTargets(System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>,System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenPickingUtility_GetPickingTargets_m6344750F8A2D21BF243FA512D8ECF2AEB2C6E6FC (RuntimeObject* ___gameObjects0, List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * ___results1, const RuntimeMethod* method);
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHovered(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,Unity.MARS.MARSHandles.Picking.PickingHit&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46 (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * ___hit4, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::Clear()
inline void List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910 (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, const RuntimeMethod*))List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910_gshared)(__this, method);
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToMesh(UnityEngine.Vector2,UnityEngine.Camera,UnityEngine.Matrix4x4,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToMesh_m96784DFBA4B4E7233992C45D5B1206C74DDC4F49 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera1, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix2, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh3, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::Add(!0)
inline void List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85 (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 , const RuntimeMethod*))List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85_gshared)(__this, ___item0, method);
}
// System.Int32 System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::get_Count()
inline int32_t List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_inline (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, const RuntimeMethod*))List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_gshared_inline)(__this, method);
}
// !0[] System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::ToArray()
inline PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method)
{
	return ((  PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, const RuntimeMethod*))List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B_gshared)(__this, method);
}
// Unity.MARS.MARSHandles.Picking.PickingHit[] Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>::Clear()
inline void List_1_Clear_m8428F99BD4D11C58BEC2ECDE6671CCB859ED680B (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *, const RuntimeMethod*))List_1_Clear_m5FB5A9C59D8625FDFB06876C4D8848F0F07ABFD0_gshared)(__this, method);
}
// System.Boolean UnityEngine.GameObject::get_activeInHierarchy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool GameObject_get_activeInHierarchy_mA3990AC5F61BB35283188E925C2BE7F7BF67734B (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::GetComponentsInChildren<Unity.MARS.MARSHandles.Picking.IPickingTarget>(System.Boolean,System.Collections.Generic.List`1<!!0>)
inline void GameObject_GetComponentsInChildren_TisIPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_m7BB524C7FE414F16DBEEA4696F0C6415A6116D3D (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * __this, bool ___includeInactive0, List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * ___results1, const RuntimeMethod* method)
{
	((  void (*) (GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, bool, List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *, const RuntimeMethod*))GameObject_GetComponentsInChildren_TisRuntimeObject_m469A375D3582C80E94A37018DAA2444835E1CFFA_gshared)(__this, ___includeInactive0, ___results1, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>::AddRange(System.Collections.Generic.IEnumerable`1<!0>)
inline void List_1_AddRange_m9640467223CE5B5ABBCB62A755853AEA413B6C92 (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * __this, RuntimeObject* ___collection0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *, RuntimeObject*, const RuntimeMethod*))List_1_AddRange_m6465DEF706EB529B4227F2AF79338419D517EDF9_gshared)(__this, ___collection0, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>::.ctor(System.Int32)
inline void List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *, int32_t, const RuntimeMethod*))List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF_gshared)(__this, ___capacity0, method);
}
// System.Void System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>::.ctor(System.Int32)
inline void List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *, int32_t, const RuntimeMethod*))List_1__ctor_mFEB2301A6F28290A828A979BA9CC847B16B3D538_gshared)(__this, ___capacity0, method);
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_center(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_size(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method);
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_extents()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_extents_m3C6A8F6FAABDC4E2B35D3ED771FE4DDF2E443355_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_extents(UnityEngine.Vector2)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_xMin()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_xMin(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_xMax()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_xMax(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_yMin()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_yMin(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method);
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_yMax()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_yMax(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 * __this, float ___x0, float ___y1, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexA(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexB(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexC(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexD(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::.ctor(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad__ctor_mD1F232F6D0A29C39F845E405F73F9428520139FB (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___a0, int32_t ___b1, int32_t ___c2, int32_t ___d3, const RuntimeMethod* method);
// System.Void System.ThrowHelper::ThrowArgumentOutOfRangeException()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThrowHelper_ThrowArgumentOutOfRangeException_m4841366ABC2B2AFA37C10900551D7E07522C0929 (const RuntimeMethod* method);
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
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.BoxPickingTarget::get_offset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  BoxPickingTarget_get_offset_m539E123E1522405632512F85AE4F59B63608A4F0 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Offset; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_m_Offset_4();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::set_offset(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_set_offset_m0B80093728826367F25F6C1481958A5DFB88D283 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// m_Offset = value;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_m_Offset_4(L_0);
		// UpdatePickingMeshData();
		BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.BoxPickingTarget::get_size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  BoxPickingTarget_get_size_mD256B515FBB7527BDFFB983A2B091AED528A35F9 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// get { return m_Size; }
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_m_Size_5();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::set_size(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_set_size_m20CE66D2CFFFB85D7E7CDD94C490DCB544BEDD13 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___value0, const RuntimeMethod* method)
{
	{
		// m_Size = value;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___value0;
		__this->set_m_Size_5(L_0);
		// UpdatePickingMeshData();
		BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::Set(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_Set_mFC218FEA101AF9317014757036F788079FFE9E66 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___offset0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___size1, const RuntimeMethod* method)
{
	{
		// m_Offset = offset;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___offset0;
		__this->set_m_Offset_4(L_0);
		// m_Size = size;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___size1;
		__this->set_m_Size_5(L_1);
		// UpdatePickingMeshData();
		BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_OnEnable_m685B1AAF0CD0C4C5A5B246B2414939E91456FE37 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// m_Transform = transform;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		__this->set_m_Transform_6(L_0);
		// EnsureMeshExists();
		BoxPickingTarget_EnsureMeshExists_mF3CCFEF007BC84970F31FDF86C35730C3F12B618(__this, /*hidden argument*/NULL);
		// UpdatePickingMeshData();
		BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_OnDisable_m21238531AB4E6E0C77CE55A9F84C86573BEBB7A0 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DestroyImmediate(m_Mesh);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_Mesh_9();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		Object_DestroyImmediate_mCCED69F4D4C9A4FA3AC30A142CF3D7F085F7C422(L_0, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::OnValidate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_OnValidate_m84329BB0FB4D30E642EBFC44130A29B99FF8B24A (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// EnsureMeshExists();
		BoxPickingTarget_EnsureMeshExists_mF3CCFEF007BC84970F31FDF86C35730C3F12B618(__this, /*hidden argument*/NULL);
		// UpdatePickingMeshData();
		BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.Picking.PickingData Unity.MARS.MARSHandles.Picking.BoxPickingTarget::GetPickingData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  BoxPickingTarget_GetPickingData_m8BC25D8B8689FE4C643E26B3CB6BFF62BCDE8D7B (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// return new PickingData(m_Transform, m_Mesh);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = __this->get_m_Transform_6();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_1 = __this->get_m_Mesh_9();
		PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  L_2;
		memset((&L_2), 0, sizeof(L_2));
		PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593((&L_2), L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::UpdatePickingMeshData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_UpdatePickingMeshData_m5A798E46A2B067F13884E2400EEBD39EE789F7A6 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// var extents = m_Size * 0.5f;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = __this->get_m_Size_5();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_0, (0.5f), /*hidden argument*/NULL);
		V_0 = L_1;
		// var offset = m_Offset;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = __this->get_m_Offset_4();
		V_1 = L_2;
		// m_Vertices[0] = (offset + new Vector3(-extents.x, -extents.y, extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_3 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5 = V_0;
		float L_6 = L_5.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_0;
		float L_8 = L_7.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = V_0;
		float L_10 = L_9.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		memset((&L_11), 0, sizeof(L_11));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_11), ((-L_6)), ((-L_8)), L_10, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_4, L_11, /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(0), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_12);
		// m_Vertices[1] = (offset + new Vector3(-extents.x, extents.y, extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_13 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = V_0;
		float L_16 = L_15.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_17 = V_0;
		float L_18 = L_17.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_19 = V_0;
		float L_20 = L_19.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_21;
		memset((&L_21), 0, sizeof(L_21));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_21), ((-L_16)), L_18, L_20, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_22;
		L_22 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_14, L_21, /*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(1), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_22);
		// m_Vertices[2] = (offset + new Vector3(extents.x, extents.y, extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_23 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_24 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_25 = V_0;
		float L_26 = L_25.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_27 = V_0;
		float L_28 = L_27.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_29 = V_0;
		float L_30 = L_29.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_31;
		memset((&L_31), 0, sizeof(L_31));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_31), L_26, L_28, L_30, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_32;
		L_32 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_24, L_31, /*hidden argument*/NULL);
		NullCheck(L_23);
		(L_23)->SetAt(static_cast<il2cpp_array_size_t>(2), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_32);
		// m_Vertices[3] = (offset + new Vector3(extents.x, -extents.y, extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_33 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_34 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_35 = V_0;
		float L_36 = L_35.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_37 = V_0;
		float L_38 = L_37.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_39 = V_0;
		float L_40 = L_39.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_41;
		memset((&L_41), 0, sizeof(L_41));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_41), L_36, ((-L_38)), L_40, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_42;
		L_42 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_34, L_41, /*hidden argument*/NULL);
		NullCheck(L_33);
		(L_33)->SetAt(static_cast<il2cpp_array_size_t>(3), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_42);
		// m_Vertices[4] = (offset + new Vector3(-extents.x, -extents.y, -extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_43 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_44 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_45 = V_0;
		float L_46 = L_45.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_47 = V_0;
		float L_48 = L_47.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_49 = V_0;
		float L_50 = L_49.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_51;
		memset((&L_51), 0, sizeof(L_51));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_51), ((-L_46)), ((-L_48)), ((-L_50)), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_52;
		L_52 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_44, L_51, /*hidden argument*/NULL);
		NullCheck(L_43);
		(L_43)->SetAt(static_cast<il2cpp_array_size_t>(4), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_52);
		// m_Vertices[5] = (offset + new Vector3(-extents.x, extents.y, -extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_53 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_54 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_55 = V_0;
		float L_56 = L_55.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_57 = V_0;
		float L_58 = L_57.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_59 = V_0;
		float L_60 = L_59.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_61;
		memset((&L_61), 0, sizeof(L_61));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_61), ((-L_56)), L_58, ((-L_60)), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_62;
		L_62 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_54, L_61, /*hidden argument*/NULL);
		NullCheck(L_53);
		(L_53)->SetAt(static_cast<il2cpp_array_size_t>(5), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_62);
		// m_Vertices[6] = (offset + new Vector3(extents.x, extents.y, -extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_63 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_64 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_65 = V_0;
		float L_66 = L_65.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_67 = V_0;
		float L_68 = L_67.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_69 = V_0;
		float L_70 = L_69.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_71;
		memset((&L_71), 0, sizeof(L_71));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_71), L_66, L_68, ((-L_70)), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_72;
		L_72 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_64, L_71, /*hidden argument*/NULL);
		NullCheck(L_63);
		(L_63)->SetAt(static_cast<il2cpp_array_size_t>(6), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_72);
		// m_Vertices[7] = (offset + new Vector3(extents.x, -extents.y, -extents.z));
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_73 = __this->get_m_Vertices_8();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_74 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_75 = V_0;
		float L_76 = L_75.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_77 = V_0;
		float L_78 = L_77.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_79 = V_0;
		float L_80 = L_79.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_81;
		memset((&L_81), 0, sizeof(L_81));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_81), L_76, ((-L_78)), ((-L_80)), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_82;
		L_82 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_74, L_81, /*hidden argument*/NULL);
		NullCheck(L_73);
		(L_73)->SetAt(static_cast<il2cpp_array_size_t>(7), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_82);
		// m_Mesh.vertices = m_Vertices;
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_83 = __this->get_m_Mesh_9();
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_84 = __this->get_m_Vertices_8();
		NullCheck(L_83);
		Mesh_set_vertices_m38F0908D0FDFE484BE19E94BE9D6176667469AAD(L_83, L_84, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::EnsureMeshExists()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_EnsureMeshExists_mF3CCFEF007BC84970F31FDF86C35730C3F12B618 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * V_0 = NULL;
	{
		// if (m_Mesh == null)
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_Mesh_9();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_009c;
		}
	}
	{
		// m_Mesh = new Mesh
		// {
		//     vertices = new[]
		//     {
		//         Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero,
		//         Vector3.zero, Vector3.zero
		//     }
		// };
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_2 = (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 *)il2cpp_codegen_object_new(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6_il2cpp_TypeInfo_var);
		Mesh__ctor_mA3D8570373462201AD7B8C9586A7F9412E49C2F6(L_2, /*hidden argument*/NULL);
		V_0 = L_2;
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_3 = V_0;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_4 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)8);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_5 = L_4;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(0), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_6);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_7 = L_5;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_7);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(1), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_8);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_9 = L_7;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(2), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_10);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_11 = L_9;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12;
		L_12 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_11);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(3), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_12);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_13 = L_11;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_14;
		L_14 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(4), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_14);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_15 = L_13;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(5), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_16);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_17 = L_15;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18;
		L_18 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(6), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_18);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_19 = L_17;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20;
		L_20 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(7), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_20);
		NullCheck(L_3);
		Mesh_set_vertices_m38F0908D0FDFE484BE19E94BE9D6176667469AAD(L_3, L_19, /*hidden argument*/NULL);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_21 = V_0;
		__this->set_m_Mesh_9(L_21);
		// m_Mesh.SetIndices(s_Indices, MeshTopology.Quads, 0);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_22 = __this->get_m_Mesh_9();
		IL2CPP_RUNTIME_CLASS_INIT(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var);
		Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* L_23 = ((BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_StaticFields*)il2cpp_codegen_static_fields_for(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var))->get_s_Indices_7();
		NullCheck(L_22);
		Mesh_SetIndices_mCD0377083E978A3FF806CFCCD28410C042A77ECD(L_22, L_23, 2, 0, /*hidden argument*/NULL);
	}

IL_009c:
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget_OnDrawGizmosSelected_m027E8D050B351AEFDD78C2EA0AFA55CE88272D6B (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	{
		// Gizmos.color = Color.green;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		L_0 = Color_get_green_mFF9BD42534D385A0717B1EAD083ADF08712984B9(/*hidden argument*/NULL);
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_0, /*hidden argument*/NULL);
		// Gizmos.matrix = transform.localToWorldMatrix;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_2;
		L_2 = Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC(L_1, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_2, /*hidden argument*/NULL);
		// Gizmos.DrawWireCube(m_Offset, m_Size);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = __this->get_m_Offset_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = __this->get_m_Size_5();
		Gizmos_DrawWireCube_mC526244E50C6E5793D4066C9C99023D5FF8424BF(L_3, L_4, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget__ctor_m2ADF6641353DB9B2363D2DDBE3EC0AF9D1159BE0 (BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// Vector3 m_Offset = Vector3.zero;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		__this->set_m_Offset_4(L_0);
		// Vector3 m_Size = Vector3.one;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB(/*hidden argument*/NULL);
		__this->set_m_Size_5(L_1);
		// readonly Vector3[] m_Vertices = new Vector3[8];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_2 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)8);
		__this->set_m_Vertices_8(L_2);
		MonoBehaviour__ctor_mC0995D847F6A95B1A553652636C38A2AA8B13BED(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.BoxPickingTarget::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BoxPickingTarget__cctor_mC8177DD93B39E277B808ED44306513F09F1E09F7 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F____D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly int[] s_Indices =
		// {
		//     0, 1, 2, 3,
		//     0, 1, 5, 4,
		//     4, 5, 6, 7,
		//     6, 7, 3, 2,
		//     0, 4, 7, 3,
		//     1, 5, 6, 2,
		// };
		Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* L_0 = (Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32*)(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32*)SZArrayNew(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32_il2cpp_TypeInfo_var, (uint32_t)((int32_t)24));
		Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* L_1 = L_0;
		RuntimeFieldHandle_t7BE65FC857501059EBAC9772C93B02CD413D9C96  L_2 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t764A5CCBD23C7B7F34C2496FD7AD1D532F6CF83F____D031CA6BBC60BC4660E86D0CDE3C85E4AC8ADE046CAA5210354008292D681133_0_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_mE27238308FED781F2D6A719F0903F2E1311B058F((RuntimeArray *)(RuntimeArray *)L_1, L_2, /*hidden argument*/NULL);
		((BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_StaticFields*)il2cpp_codegen_static_fields_for(BoxPickingTarget_t4D24CE4B659EB019D244355C265922D99875C7E7_il2cpp_TypeInfo_var))->set_s_Indices_7(L_1);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EmbeddedAttribute__ctor_mF93B06A1182E71A963F7FF2BEBE909111822432A (EmbeddedAttribute_tD28930C89A154AEB1C4DD587AA8A1389CEAEE344 * __this, const RuntimeMethod* method)
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
// System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IsReadOnlyAttribute__ctor_m3450028E7E7A78BE663FF55E1016AD45E2A2CDB0 (IsReadOnlyAttribute_t4D30CEA2439868B6B60391A1D8183AB799BC9787 * __this, const RuntimeMethod* method)
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
// UnityEngine.Vector3[] Unity.MARS.MARSHandles.Picking.LinePickingTarget::get_points()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* LinePickingTarget_get_points_m44E9BA2C965A0AEDC24BE046E80DB8660B16930F (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* V_0 = NULL;
	{
		// Vector3[] p = new Vector3[m_Points.Length];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = __this->get_m_Points_4();
		NullCheck(L_0);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_1 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)((int32_t)((int32_t)(((RuntimeArray*)L_0)->max_length))));
		V_0 = L_1;
		// Array.Copy(m_Points, p, m_Points.Length);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_2 = __this->get_m_Points_4();
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_3 = V_0;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_4 = __this->get_m_Points_4();
		NullCheck(L_4);
		Array_Copy_m40103AA97DC582C557B912CF4BBE86A4D166F803((RuntimeArray *)(RuntimeArray *)L_2, (RuntimeArray *)(RuntimeArray *)L_3, ((int32_t)((int32_t)(((RuntimeArray*)L_4)->max_length))), /*hidden argument*/NULL);
		// return p;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_5 = V_0;
		return L_5;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::set_points(UnityEngine.Vector3[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_set_points_mCC5E744E4BB77EA9D7ACC339229C858C83548DD0 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* ___value0, const RuntimeMethod* method)
{
	{
		// if (value == null)
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = ___value0;
		if (L_0)
		{
			goto IL_0004;
		}
	}
	{
		// return;
		return;
	}

IL_0004:
	{
		// m_Points = value;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_1 = ___value0;
		__this->set_m_Points_4(L_1);
		// UpdatePickingMeshData();
		LinePickingTarget_UpdatePickingMeshData_m13BD50449889D504A14C2A67D6A42C88D6EF49DF(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_OnEnable_mFA3C6FDFB9D907CF8DDC3E3C5E97F4B52AF2E975 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	{
		// EnsureMeshExists();
		LinePickingTarget_EnsureMeshExists_m41CE41CBFAF6F99E4DD5CBEBE323EE870A4691B9(__this, /*hidden argument*/NULL);
		// m_Transform = transform;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		__this->set_m_Transform_7(L_0);
		// UpdatePickingMeshData();
		LinePickingTarget_UpdatePickingMeshData_m13BD50449889D504A14C2A67D6A42C88D6EF49DF(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_OnDisable_m04131FEE1213B8E41B963C0C7C5909E187B0AF9B (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DestroyImmediate(m_Mesh);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_Mesh_8();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		Object_DestroyImmediate_mCCED69F4D4C9A4FA3AC30A142CF3D7F085F7C422(L_0, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::OnValidate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_OnValidate_m24AC99B92570B8E453D9464E98FA94B8F0B22446 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	{
		// EnsureMeshExists();
		LinePickingTarget_EnsureMeshExists_m41CE41CBFAF6F99E4DD5CBEBE323EE870A4691B9(__this, /*hidden argument*/NULL);
		// UpdatePickingMeshData();
		LinePickingTarget_UpdatePickingMeshData_m13BD50449889D504A14C2A67D6A42C88D6EF49DF(__this, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::UpdatePickingMeshData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_UpdatePickingMeshData_m13BD50449889D504A14C2A67D6A42C88D6EF49DF (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* G_B10_0 = NULL;
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * G_B10_1 = NULL;
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* G_B9_0 = NULL;
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * G_B9_1 = NULL;
	int32_t G_B11_0 = 0;
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* G_B11_1 = NULL;
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * G_B11_2 = NULL;
	{
		// int prevIndicesSize = m_Indices.Count;
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_0 = __this->get_m_Indices_6();
		NullCheck(L_0);
		int32_t L_1;
		L_1 = List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_inline(L_0, /*hidden argument*/List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_RuntimeMethod_var);
		V_0 = L_1;
		// m_Indices.Clear();
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_2 = __this->get_m_Indices_6();
		NullCheck(L_2);
		List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A(L_2, /*hidden argument*/List_1_Clear_m508B72E5229FAE7042D99A04555F66F10C597C7A_RuntimeMethod_var);
		// for (int i = 0; i < m_Points.Length; ++i)
		V_1 = 0;
		goto IL_002b;
	}

IL_001b:
	{
		// m_Indices.Add(i);
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_3 = __this->get_m_Indices_6();
		int32_t L_4 = V_1;
		NullCheck(L_3);
		List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F(L_3, L_4, /*hidden argument*/List_1_Add_mEE653047BDB3486ACC2E16DC6C3422A0BA48F01F_RuntimeMethod_var);
		// for (int i = 0; i < m_Points.Length; ++i)
		int32_t L_5 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_5, (int32_t)1));
	}

IL_002b:
	{
		// for (int i = 0; i < m_Points.Length; ++i)
		int32_t L_6 = V_1;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_7 = __this->get_m_Points_4();
		NullCheck(L_7);
		if ((((int32_t)L_6) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_7)->max_length))))))
		{
			goto IL_001b;
		}
	}
	{
		// m_Vertices.Clear();
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_8 = __this->get_m_Vertices_5();
		NullCheck(L_8);
		List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702(L_8, /*hidden argument*/List_1_Clear_mE0F03A2E42E2F7F8A282AE01C12945F7379DC702_RuntimeMethod_var);
		// for (int i = 0; i < m_Points.Length; ++i)
		V_2 = 0;
		goto IL_0060;
	}

IL_0045:
	{
		// m_Vertices.Add(m_Points[i]);
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_9 = __this->get_m_Vertices_5();
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_10 = __this->get_m_Points_4();
		int32_t L_11 = V_2;
		NullCheck(L_10);
		int32_t L_12 = L_11;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = (L_10)->GetAt(static_cast<il2cpp_array_size_t>(L_12));
		NullCheck(L_9);
		List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59(L_9, L_13, /*hidden argument*/List_1_Add_mAE131B53917AD7132F6BA2C05D5D17C38C5A2E59_RuntimeMethod_var);
		// for (int i = 0; i < m_Points.Length; ++i)
		int32_t L_14 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)1));
	}

IL_0060:
	{
		// for (int i = 0; i < m_Points.Length; ++i)
		int32_t L_15 = V_2;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_16 = __this->get_m_Points_4();
		NullCheck(L_16);
		if ((((int32_t)L_15) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_16)->max_length))))))
		{
			goto IL_0045;
		}
	}
	{
		// if (prevIndicesSize != m_Indices.Count)
		int32_t L_17 = V_0;
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_18 = __this->get_m_Indices_6();
		NullCheck(L_18);
		int32_t L_19;
		L_19 = List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_inline(L_18, /*hidden argument*/List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_RuntimeMethod_var);
		if ((((int32_t)L_17) == ((int32_t)L_19)))
		{
			goto IL_0084;
		}
	}
	{
		// m_Mesh.Clear();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_20 = __this->get_m_Mesh_8();
		NullCheck(L_20);
		Mesh_Clear_m7500ECE6209E14CC750CB16B48301B8D2A57ACCE(L_20, /*hidden argument*/NULL);
	}

IL_0084:
	{
		// m_Mesh.SetVertices(m_Vertices);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_21 = __this->get_m_Mesh_8();
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_22 = __this->get_m_Vertices_5();
		NullCheck(L_21);
		Mesh_SetVertices_m08C90A1665735C09E15E17DE1A8CD9F196762BCD(L_21, L_22, /*hidden argument*/NULL);
		// m_Mesh.SetIndices(m_Indices.ToArray(), m_Indices.Count > 1 ? MeshTopology.LineStrip : MeshTopology.Points, 0);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_23 = __this->get_m_Mesh_8();
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_24 = __this->get_m_Indices_6();
		NullCheck(L_24);
		Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* L_25;
		L_25 = List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F(L_24, /*hidden argument*/List_1_ToArray_mDEFFC768D9AAD376D27FC0FC1F7B57EE2E93479F_RuntimeMethod_var);
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_26 = __this->get_m_Indices_6();
		NullCheck(L_26);
		int32_t L_27;
		L_27 = List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_inline(L_26, /*hidden argument*/List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_RuntimeMethod_var);
		G_B9_0 = L_25;
		G_B9_1 = L_23;
		if ((((int32_t)L_27) > ((int32_t)1)))
		{
			G_B10_0 = L_25;
			G_B10_1 = L_23;
			goto IL_00b7;
		}
	}
	{
		G_B11_0 = 5;
		G_B11_1 = G_B9_0;
		G_B11_2 = G_B9_1;
		goto IL_00b8;
	}

IL_00b7:
	{
		G_B11_0 = 4;
		G_B11_1 = G_B10_0;
		G_B11_2 = G_B10_1;
	}

IL_00b8:
	{
		NullCheck(G_B11_2);
		Mesh_SetIndices_mCD0377083E978A3FF806CFCCD28410C042A77ECD(G_B11_2, G_B11_1, G_B11_0, 0, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::EnsureMeshExists()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_EnsureMeshExists_m41CE41CBFAF6F99E4DD5CBEBE323EE870A4691B9 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (m_Mesh == null)
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_Mesh_8();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0019;
		}
	}
	{
		// m_Mesh = new Mesh();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_2 = (Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 *)il2cpp_codegen_object_new(Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6_il2cpp_TypeInfo_var);
		Mesh__ctor_mA3D8570373462201AD7B8C9586A7F9412E49C2F6(L_2, /*hidden argument*/NULL);
		__this->set_m_Mesh_8(L_2);
	}

IL_0019:
	{
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.Picking.PickingData Unity.MARS.MARSHandles.Picking.LinePickingTarget::GetPickingData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  LinePickingTarget_GetPickingData_m8AA748476BA7B166505477514D96693B8E278BAB (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	{
		// return new PickingData(m_Transform, m_Mesh);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = __this->get_m_Transform_7();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_1 = __this->get_m_Mesh_8();
		PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  L_2;
		memset((&L_2), 0, sizeof(L_2));
		PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593((&L_2), L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget_OnDrawGizmosSelected_m923B03B9F9CE43821EA5F7EBA49E761DF207C215 (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// Gizmos.color = Color.green;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		L_0 = Color_get_green_mFF9BD42534D385A0717B1EAD083ADF08712984B9(/*hidden argument*/NULL);
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_0, /*hidden argument*/NULL);
		// Gizmos.matrix = transform.localToWorldMatrix;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_2;
		L_2 = Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC(L_1, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_2, /*hidden argument*/NULL);
		// for (var i = 0; i < m_Points.Length-1; ++i)
		V_0 = 0;
		goto IL_0043;
	}

IL_001e:
	{
		// var a = m_Points[i];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_3 = __this->get_m_Points_4();
		int32_t L_4 = V_0;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		// var b = m_Points[i + 1];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_7 = __this->get_m_Points_4();
		int32_t L_8 = V_0;
		NullCheck(L_7);
		int32_t L_9 = ((int32_t)il2cpp_codegen_add((int32_t)L_8, (int32_t)1));
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_9));
		V_1 = L_10;
		// Gizmos.DrawLine(a, b);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = V_1;
		Gizmos_DrawLine_m91F1AA0205C7D53D2AA8E2F1D7B338E601A30823(L_6, L_11, /*hidden argument*/NULL);
		// for (var i = 0; i < m_Points.Length-1; ++i)
		int32_t L_12 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_12, (int32_t)1));
	}

IL_0043:
	{
		// for (var i = 0; i < m_Points.Length-1; ++i)
		int32_t L_13 = V_0;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_14 = __this->get_m_Points_4();
		NullCheck(L_14);
		if ((((int32_t)L_13) < ((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_14)->max_length))), (int32_t)1)))))
		{
			goto IL_001e;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.LinePickingTarget::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LinePickingTarget__ctor_m2F9F71AA8EDD281D2B8C0274E13CDFA9DDE4DC1A (LinePickingTarget_t056C406CFA1E55D245E2F7C1061C199D47D50B5E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mF8F23D572031748AD428623AE16803455997E297_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// [SerializeField] Vector3[] m_Points = {Vector3.zero, Vector3.one};
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)2);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_1 = L_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_get_zero_m1A8F7993167785F750B6B01762D22C2597C84EF6(/*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_2);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_3 = L_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = Vector3_get_one_m9CDE5C456038B133ED94402673859EC37B1C1CCB(/*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E )L_4);
		__this->set_m_Points_4(L_3);
		// readonly List<Vector3> m_Vertices = new List<Vector3>();
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_5 = (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *)il2cpp_codegen_object_new(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_il2cpp_TypeInfo_var);
		List_1__ctor_mF8F23D572031748AD428623AE16803455997E297(L_5, /*hidden argument*/List_1__ctor_mF8F23D572031748AD428623AE16803455997E297_RuntimeMethod_var);
		__this->set_m_Vertices_5(L_5);
		// readonly List<int> m_Indices = new List<int>();
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_6 = (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *)il2cpp_codegen_object_new(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_il2cpp_TypeInfo_var);
		List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD(L_6, /*hidden argument*/List_1__ctor_m45E78772E9157F6CD684A69AAB07CE4082FE5FFD_RuntimeMethod_var);
		__this->set_m_Indices_6(L_6);
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
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToLine(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToLine_m806E9331F04A83733800190FBF5F96F4F487C762 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineStart1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineEnd2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return Vector3.Magnitude(ProjectPointLine(point, lineStart, lineEnd) - point);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___point0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___lineStart1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___lineEnd2;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = MathUtility_ProjectPointLine_mB5B8E5B5620CA6CC6C410F05EC6A79A83D57A015(L_0, L_1, L_2, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___point0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_3, L_4, /*hidden argument*/NULL);
		float L_6;
		L_6 = Vector3_Magnitude_mFBD4702FB2F35452191EC918B9B09766A5761854_inline(L_5, /*hidden argument*/NULL);
		return L_6;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::ProjectPointLine(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_ProjectPointLine_mB5B8E5B5620CA6CC6C410F05EC6A79A83D57A015 (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineStart1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___lineEnd2, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_3;
	memset((&V_3), 0, sizeof(V_3));
	float V_4 = 0.0f;
	{
		// Vector3 relativePoint = point - lineStart;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___point0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___lineStart1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		// Vector3 lineDirection = lineEnd - lineStart;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___lineEnd2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___lineStart1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_3, L_4, /*hidden argument*/NULL);
		V_1 = L_5;
		// float length = lineDirection.magnitude;
		float L_6;
		L_6 = Vector3_get_magnitude_mDDD40612220D8104E77E993E18A101A69A944991((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&V_1), /*hidden argument*/NULL);
		V_2 = L_6;
		// Vector3 normalizedLineDirection = lineDirection;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7 = V_1;
		V_3 = L_7;
		// if (length > .000001f)
		float L_8 = V_2;
		if ((!(((float)L_8) > ((float)(9.99999997E-07f)))))
		{
			goto IL_002a;
		}
	}
	{
		// normalizedLineDirection /= length;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = V_3;
		float L_10 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		L_11 = Vector3_op_Division_mE5ACBFB168FED529587457A83BA98B7DB32E2A05_inline(L_9, L_10, /*hidden argument*/NULL);
		V_3 = L_11;
	}

IL_002a:
	{
		// float dot = Vector3.Dot(normalizedLineDirection, relativePoint);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12 = V_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = V_0;
		float L_14;
		L_14 = Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline(L_12, L_13, /*hidden argument*/NULL);
		V_4 = L_14;
		// dot = Mathf.Clamp(dot, 0.0F, length);
		float L_15 = V_4;
		float L_16 = V_2;
		float L_17;
		L_17 = Mathf_Clamp_m2416F3B785C8F135863E3D17E5B0CB4174797B87(L_15, (0.0f), L_16, /*hidden argument*/NULL);
		V_4 = L_17;
		// return lineStart + normalizedLineDirection * dot;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18 = ___lineStart1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_19 = V_3;
		float L_20 = V_4;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_21;
		L_21 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_19, L_20, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_22;
		L_22 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_18, L_21, /*hidden argument*/NULL);
		return L_22;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::ProjectPointOnRay(UnityEngine.Vector3,UnityEngine.Ray)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_ProjectPointOnRay_mFAB92ED2A01405B2A6C62EA3C6EA07A4405531ED (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___point0, Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6  ___ray1, const RuntimeMethod* method)
{
	{
		// return ray.origin + Vector3.Project(point - ray.origin, ray.direction);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0;
		L_0 = Ray_get_origin_m0C1B2BFF99CDF5231AC29AC031C161F55B53C1D0((Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 *)(&___ray1), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___point0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Ray_get_origin_m0C1B2BFF99CDF5231AC29AC031C161F55B53C1D0((Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 *)(&___ray1), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3;
		L_3 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_1, L_2, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = Ray_get_direction_m2B31F86F19B64474A901B28D3808011AE7A13EFC((Ray_t2E9E67CC8B03EE6ED2BBF3D2C9C96DDF70E1D5E6 *)(&___ray1), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_Project_m57D54B16F36E620C294F4B209CD4C8E46A58D1B6(L_3, L_4, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_0, L_5, /*hidden argument*/NULL);
		return L_6;
	}
}
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToTriangle(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToTriangle_mB3ECBAE02FD0ED48F57CCE4137A94D55CC6DDD9B (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b2, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___c3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	{
		// var inside = System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(b - a), point - a));
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___b2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_1 = ___a1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2;
		L_2 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_0, L_1, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3;
		L_3 = Vector2_Perpendicular_mAD7805BEB4D362E2E08DA6C0FF48CA55F8B7EE71_inline(L_2, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_5 = ___a1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		L_6 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_4, L_5, /*hidden argument*/NULL);
		float L_7;
		L_7 = Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline(L_3, L_6, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var);
		int32_t L_8;
		L_8 = Math_Sign_m607F7014224C0DD1D1F6D7B44DAB00A2A16CCC8F(L_7, /*hidden argument*/NULL);
		V_0 = L_8;
		// if (inside == System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(c - b), point - b))
		//     && inside == System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(a - c), point - c)))
		int32_t L_9 = V_0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_10 = ___c3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11 = ___b2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12;
		L_12 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_10, L_11, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_13;
		L_13 = Vector2_Perpendicular_mAD7805BEB4D362E2E08DA6C0FF48CA55F8B7EE71_inline(L_12, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_15 = ___b2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_16;
		L_16 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_14, L_15, /*hidden argument*/NULL);
		float L_17;
		L_17 = Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline(L_13, L_16, /*hidden argument*/NULL);
		int32_t L_18;
		L_18 = Math_Sign_m607F7014224C0DD1D1F6D7B44DAB00A2A16CCC8F(L_17, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_9) == ((uint32_t)L_18))))
		{
			goto IL_0064;
		}
	}
	{
		int32_t L_19 = V_0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20 = ___a1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_21 = ___c3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_22;
		L_22 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_20, L_21, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_23;
		L_23 = Vector2_Perpendicular_mAD7805BEB4D362E2E08DA6C0FF48CA55F8B7EE71_inline(L_22, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_24 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_25 = ___c3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_26;
		L_26 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_24, L_25, /*hidden argument*/NULL);
		float L_27;
		L_27 = Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline(L_23, L_26, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var);
		int32_t L_28;
		L_28 = Math_Sign_m607F7014224C0DD1D1F6D7B44DAB00A2A16CCC8F(L_27, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_19) == ((uint32_t)L_28))))
		{
			goto IL_0064;
		}
	}
	{
		// return 0;
		return (0.0f);
	}

IL_0064:
	{
		// var da = DistanceToLine(point, a, b);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_29 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_30 = ___a1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_31 = ___b2;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_32;
		L_32 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_29, L_30, L_31, /*hidden argument*/NULL);
		// var db = DistanceToLine(point, b, c);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_33 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_34 = ___b2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_35 = ___c3;
		float L_36;
		L_36 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_33, L_34, L_35, /*hidden argument*/NULL);
		V_1 = L_36;
		// var dc = DistanceToLine(point, c, a);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_37 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_38 = ___c3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_39 = ___a1;
		float L_40;
		L_40 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_37, L_38, L_39, /*hidden argument*/NULL);
		V_2 = L_40;
		// return Mathf.Min(da, Mathf.Min(db, dc));
		float L_41 = V_1;
		float L_42 = V_2;
		float L_43;
		L_43 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_41, L_42, /*hidden argument*/NULL);
		float L_44;
		L_44 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_32, L_43, /*hidden argument*/NULL);
		return L_44;
	}
}
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToQuad(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToQuad_m7D07BBFDE23E1FDB204BB87795EA35B507729B54 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b2, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___c3, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___d4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_2;
	memset((&V_2), 0, sizeof(V_2));
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_7;
	memset((&V_7), 0, sizeof(V_7));
	{
		// s_QuadBuffer[0] = a;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_0 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_1 = ___a1;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(0), (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 )L_1);
		// s_QuadBuffer[1] = b;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_2 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = ___b2;
		NullCheck(L_2);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(1), (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 )L_3);
		// s_QuadBuffer[2] = c;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_4 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_5 = ___c3;
		NullCheck(L_4);
		(L_4)->SetAt(static_cast<il2cpp_array_size_t>(2), (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 )L_5);
		// s_QuadBuffer[3] = d;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_6 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = ___d4;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(3), (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 )L_7);
		// var bounds = new Bounds2D(s_QuadBuffer);
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_8 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		Bounds2D__ctor_mC43E45A8EEBCBCCE6A0E0AF20209E7A13EC1A175((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), L_8, /*hidden argument*/NULL);
		// if (bounds.Contains(point))
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_9 = ___point0;
		bool L_10;
		L_10 = Bounds2D_Contains_mED66DDD213D76D4DD9CF1C97F1FA6EA149ADB1BD((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), L_9, /*hidden argument*/NULL);
		if (!L_10)
		{
			goto IL_00f7;
		}
	}
	{
		// var firstEdgeDir = bounds.center - (Vector2)GetEdgeCenter(a, b);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___a1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		L_13 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_12, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = ___b2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15;
		L_15 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_14, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = MathUtility_GetEdgeCenter_mFA5BBB90ECC03114D6BD5DAA427C015D5EE0EABB(L_13, L_15, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17;
		L_17 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_16, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_18;
		L_18 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_11, L_17, /*hidden argument*/NULL);
		V_1 = L_18;
		// var rayStart = bounds.center + firstEdgeDir * (bounds.size.y + bounds.size.x + 2f);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_19;
		L_19 = Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20 = V_1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_21;
		L_21 = Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), /*hidden argument*/NULL);
		float L_22 = L_21.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_23;
		L_23 = Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)(&V_0), /*hidden argument*/NULL);
		float L_24 = L_23.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_25;
		L_25 = Vector2_op_Multiply_mC7A7802352867555020A90205EBABA56EE5E36CB_inline(L_20, ((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_add((float)L_22, (float)L_24)), (float)(2.0f))), /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_26;
		L_26 = Vector2_op_Addition_m5EACC2AEA80FEE29F380397CF1F4B11D04BE71CC_inline(L_19, L_25, /*hidden argument*/NULL);
		V_2 = L_26;
		// var collisions = 0;
		V_3 = 0;
		// for (int i = 0, count = s_QuadBuffer.Length-1; i < count; ++i)
		V_4 = 0;
		// for (int i = 0, count = s_QuadBuffer.Length-1; i < count; ++i)
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_27 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		NullCheck(L_27);
		V_5 = ((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_27)->max_length))), (int32_t)1));
		goto IL_00e6;
	}

IL_00b1:
	{
		// var p1 = s_QuadBuffer[i];
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_28 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		int32_t L_29 = V_4;
		NullCheck(L_28);
		int32_t L_30 = L_29;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
		V_6 = L_31;
		// var p2 = s_QuadBuffer[i + 1];
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_32 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadBuffer_1();
		int32_t L_33 = V_4;
		NullCheck(L_32);
		int32_t L_34 = ((int32_t)il2cpp_codegen_add((int32_t)L_33, (int32_t)1));
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_35 = (L_32)->GetAt(static_cast<il2cpp_array_size_t>(L_34));
		V_7 = L_35;
		// if (AreSegmentIntersecting(rayStart, point, p1, p2))
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_36 = V_2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_37 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_38 = V_6;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_39 = V_7;
		bool L_40;
		L_40 = MathUtility_AreSegmentIntersecting_mB80AB09642DE4B11F11B364159009FEFF246EC90(L_36, L_37, L_38, L_39, /*hidden argument*/NULL);
		if (!L_40)
		{
			goto IL_00e0;
		}
	}
	{
		// ++collisions;
		int32_t L_41 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_41, (int32_t)1));
	}

IL_00e0:
	{
		// for (int i = 0, count = s_QuadBuffer.Length-1; i < count; ++i)
		int32_t L_42 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_42, (int32_t)1));
	}

IL_00e6:
	{
		// for (int i = 0, count = s_QuadBuffer.Length-1; i < count; ++i)
		int32_t L_43 = V_4;
		int32_t L_44 = V_5;
		if ((((int32_t)L_43) < ((int32_t)L_44)))
		{
			goto IL_00b1;
		}
	}
	{
		// if (collisions % 2 != 0)
		int32_t L_45 = V_3;
		if (!((int32_t)((int32_t)L_45%(int32_t)2)))
		{
			goto IL_00f7;
		}
	}
	{
		// return 0f;
		return (0.0f);
	}

IL_00f7:
	{
		// s_QuadDistanceBuffer[0] = DistanceToLine(point, a, b);
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_46 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadDistanceBuffer_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_47 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_48 = ___a1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_49 = ___b2;
		float L_50;
		L_50 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_47, L_48, L_49, /*hidden argument*/NULL);
		NullCheck(L_46);
		(L_46)->SetAt(static_cast<il2cpp_array_size_t>(0), (float)L_50);
		// s_QuadDistanceBuffer[1] = DistanceToLine(point, b, c);
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_51 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadDistanceBuffer_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_52 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_53 = ___b2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_54 = ___c3;
		float L_55;
		L_55 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_52, L_53, L_54, /*hidden argument*/NULL);
		NullCheck(L_51);
		(L_51)->SetAt(static_cast<il2cpp_array_size_t>(1), (float)L_55);
		// s_QuadDistanceBuffer[2] = DistanceToLine(point, c, d);
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_56 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadDistanceBuffer_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_57 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_58 = ___c3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_59 = ___d4;
		float L_60;
		L_60 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_57, L_58, L_59, /*hidden argument*/NULL);
		NullCheck(L_56);
		(L_56)->SetAt(static_cast<il2cpp_array_size_t>(2), (float)L_60);
		// s_QuadDistanceBuffer[3] = DistanceToLine(point, d, a);
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_61 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadDistanceBuffer_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_62 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_63 = ___d4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_64 = ___a1;
		float L_65;
		L_65 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_62, L_63, L_64, /*hidden argument*/NULL);
		NullCheck(L_61);
		(L_61)->SetAt(static_cast<il2cpp_array_size_t>(3), (float)L_65);
		// return Mathf.Min(s_QuadDistanceBuffer);
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_66 = ((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->get_s_QuadDistanceBuffer_0();
		float L_67;
		L_67 = Mathf_Min_mBFD6E1F7B1716EB3113CDEA310FA42D8968E16AF(L_66, /*hidden argument*/NULL);
		return L_67;
	}
}
// System.Single Unity.MARS.MARSHandles.MathUtility::DistanceToLine(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lineStart1, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lineEnd2, const RuntimeMethod* method)
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		// float l2 = ((lineStart.x - lineEnd.x) * (lineStart.x - lineEnd.x)) +
		//            ((lineStart.y - lineEnd.y) * (lineStart.y - lineEnd.y));
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___lineStart1;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___lineEnd2;
		float L_3 = L_2.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___lineStart1;
		float L_5 = L_4.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___lineEnd2;
		float L_7 = L_6.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8 = ___lineStart1;
		float L_9 = L_8.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_10 = ___lineEnd2;
		float L_11 = L_10.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___lineStart1;
		float L_13 = L_12.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = ___lineEnd2;
		float L_15 = L_14.get_y_1();
		V_0 = ((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)L_1, (float)L_3)), (float)((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)))), (float)((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)L_9, (float)L_11)), (float)((float)il2cpp_codegen_subtract((float)L_13, (float)L_15))))));
		// if (l2 == 0.0f)
		float L_16 = V_0;
		if ((!(((float)L_16) == ((float)(0.0f)))))
		{
			goto IL_0048;
		}
	}
	{
		// return Vector2.Distance(point, lineStart);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_18 = ___lineStart1;
		float L_19;
		L_19 = Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F(L_17, L_18, /*hidden argument*/NULL);
		return L_19;
	}

IL_0048:
	{
		// float t = Vector2.Dot(point - lineStart, lineEnd - lineStart) / l2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_21 = ___lineStart1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_22;
		L_22 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_20, L_21, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_23 = ___lineEnd2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_24 = ___lineStart1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_25;
		L_25 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_23, L_24, /*hidden argument*/NULL);
		float L_26;
		L_26 = Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline(L_22, L_25, /*hidden argument*/NULL);
		float L_27 = V_0;
		V_1 = ((float)((float)L_26/(float)L_27));
		// if (t < 0.0)
		float L_28 = V_1;
		if ((!(((double)((double)((double)L_28))) < ((double)(0.0)))))
		{
			goto IL_0073;
		}
	}
	{
		// return Vector2.Distance(point, lineStart);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_29 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_30 = ___lineStart1;
		float L_31;
		L_31 = Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F(L_29, L_30, /*hidden argument*/NULL);
		return L_31;
	}

IL_0073:
	{
		// else if (t > 1.0)
		float L_32 = V_1;
		if ((!(((double)((double)((double)L_32))) > ((double)(1.0)))))
		{
			goto IL_0088;
		}
	}
	{
		// return Vector2.Distance(point, lineEnd);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_33 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_34 = ___lineEnd2;
		float L_35;
		L_35 = Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F(L_33, L_34, /*hidden argument*/NULL);
		return L_35;
	}

IL_0088:
	{
		// Vector2 projection = lineStart + t * (lineEnd - lineStart);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_36 = ___lineStart1;
		float L_37 = V_1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_38 = ___lineEnd2;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_39 = ___lineStart1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_40;
		L_40 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_38, L_39, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_41;
		L_41 = Vector2_op_Multiply_m841D5292C48DAD9746A2F4EED9CE7A76CDB652EA_inline(L_37, L_40, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_42;
		L_42 = Vector2_op_Addition_m5EACC2AEA80FEE29F380397CF1F4B11D04BE71CC_inline(L_36, L_41, /*hidden argument*/NULL);
		V_2 = L_42;
		// return Vector2.Distance(point, projection);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_43 = ___point0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_44 = V_2;
		float L_45;
		L_45 = Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F(L_43, L_44, /*hidden argument*/NULL);
		return L_45;
	}
}
// System.Boolean Unity.MARS.MARSHandles.MathUtility::AreSegmentIntersecting(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MathUtility_AreSegmentIntersecting_mB80AB09642DE4B11F11B364159009FEFF246EC90 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a10, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b11, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a22, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b23, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	{
		// s1.x = b1.x - a1.x; s1.y = b1.y - a1.y;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___b11;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___a10;
		float L_3 = L_2.get_x_0();
		(&V_0)->set_x_0(((float)il2cpp_codegen_subtract((float)L_1, (float)L_3)));
		// s1.x = b1.x - a1.x; s1.y = b1.y - a1.y;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___b11;
		float L_5 = L_4.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___a10;
		float L_7 = L_6.get_y_1();
		(&V_0)->set_y_1(((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)));
		// s2.x = b2.x - a2.x; s2.y = b2.y - a2.y;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8 = ___b23;
		float L_9 = L_8.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_10 = ___a22;
		float L_11 = L_10.get_x_0();
		(&V_1)->set_x_0(((float)il2cpp_codegen_subtract((float)L_9, (float)L_11)));
		// s2.x = b2.x - a2.x; s2.y = b2.y - a2.y;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___b23;
		float L_13 = L_12.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = ___a22;
		float L_15 = L_14.get_y_1();
		(&V_1)->set_y_1(((float)il2cpp_codegen_subtract((float)L_13, (float)L_15)));
		// s = (-s1.y * (a1.x - a2.x) + s1.x * (a1.y - a2.y)) / (-s2.x * s1.y + s1.x * s2.y);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_16 = V_0;
		float L_17 = L_16.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_18 = ___a10;
		float L_19 = L_18.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20 = ___a22;
		float L_21 = L_20.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_22 = V_0;
		float L_23 = L_22.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_24 = ___a10;
		float L_25 = L_24.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_26 = ___a22;
		float L_27 = L_26.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_28 = V_1;
		float L_29 = L_28.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_30 = V_0;
		float L_31 = L_30.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_32 = V_0;
		float L_33 = L_32.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_34 = V_1;
		float L_35 = L_34.get_y_1();
		V_2 = ((float)((float)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)((-L_17)), (float)((float)il2cpp_codegen_subtract((float)L_19, (float)L_21)))), (float)((float)il2cpp_codegen_multiply((float)L_23, (float)((float)il2cpp_codegen_subtract((float)L_25, (float)L_27))))))/(float)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)((-L_29)), (float)L_31)), (float)((float)il2cpp_codegen_multiply((float)L_33, (float)L_35))))));
		// t = (s2.x * (a1.y - a2.y) - s2.y * (a1.x - a2.x)) / (-s2.x * s1.y + s1.x * s2.y);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_36 = V_1;
		float L_37 = L_36.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_38 = ___a10;
		float L_39 = L_38.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_40 = ___a22;
		float L_41 = L_40.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_42 = V_1;
		float L_43 = L_42.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_44 = ___a10;
		float L_45 = L_44.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_46 = ___a22;
		float L_47 = L_46.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_48 = V_1;
		float L_49 = L_48.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_50 = V_0;
		float L_51 = L_50.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_52 = V_0;
		float L_53 = L_52.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_54 = V_1;
		float L_55 = L_54.get_y_1();
		V_3 = ((float)((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_37, (float)((float)il2cpp_codegen_subtract((float)L_39, (float)L_41)))), (float)((float)il2cpp_codegen_multiply((float)L_43, (float)((float)il2cpp_codegen_subtract((float)L_45, (float)L_47))))))/(float)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)((-L_49)), (float)L_51)), (float)((float)il2cpp_codegen_multiply((float)L_53, (float)L_55))))));
		// return (s >= 0 && s <= 1 && t >= 0 && t <= 1);
		float L_56 = V_2;
		if ((!(((float)L_56) >= ((float)(0.0f)))))
		{
			goto IL_0103;
		}
	}
	{
		float L_57 = V_2;
		if ((!(((float)L_57) <= ((float)(1.0f)))))
		{
			goto IL_0103;
		}
	}
	{
		float L_58 = V_3;
		if ((!(((float)L_58) >= ((float)(0.0f)))))
		{
			goto IL_0103;
		}
	}
	{
		float L_59 = V_3;
		return (bool)((((int32_t)((!(((float)L_59) <= ((float)(1.0f))))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}

IL_0103:
	{
		return (bool)0;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.MathUtility::GetEdgeCenter(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  MathUtility_GetEdgeCenter_mFA5BBB90ECC03114D6BD5DAA427C015D5EE0EABB (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// var dir = b - a;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___b1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___a0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_op_Subtraction_m2725C96965D5C0B1F9715797E51762B13A5FED58_inline(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		// return a + dir * 0.5f;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___a0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_4, (0.5f), /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_3, L_5, /*hidden argument*/NULL);
		return L_6;
	}
}
// System.Void Unity.MARS.MARSHandles.MathUtility::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MathUtility__cctor_m2EDD9332716F1DA4C5689C9C134D4343076ED501 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly float[] s_QuadDistanceBuffer = new float[4];
		SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA* L_0 = (SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA*)(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA*)SZArrayNew(SingleU5BU5D_t47E8DBF5B597C122478D1FFBD9DD57399A0650FA_il2cpp_TypeInfo_var, (uint32_t)4);
		((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->set_s_QuadDistanceBuffer_0(L_0);
		// static readonly Vector2[] s_QuadBuffer = new Vector2[4];
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_1 = (Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA*)(Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA*)SZArrayNew(Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA_il2cpp_TypeInfo_var, (uint32_t)4);
		((MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_StaticFields*)il2cpp_codegen_static_fields_for(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var))->set_s_QuadBuffer_1(L_1);
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
// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.MeshPickingTarget::get_collisionMesh()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * MeshPickingTarget_get_collisionMesh_m857EC1EDF2AECB466683E48DFC455102563BE0B5 (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, const RuntimeMethod* method)
{
	{
		// get { return m_CollisionMesh; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_CollisionMesh_4();
		return L_0;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.MeshPickingTarget::set_collisionMesh(UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeshPickingTarget_set_collisionMesh_m002A19F39182FDC5A83E57E6B8C9D83DF39A022B (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (m_CollisionMesh == value)
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_m_CollisionMesh_4();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_1 = ___value0;
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
		// m_CollisionMesh = value;
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_3 = ___value0;
		__this->set_m_CollisionMesh_4(L_3);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.MeshPickingTarget::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeshPickingTarget_OnEnable_m3DFA1E6E85FE84BE3418CF132C492E9DC15E17DE (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, const RuntimeMethod* method)
{
	{
		// m_Transform = transform;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0;
		L_0 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		__this->set_m_Transform_5(L_0);
		// }
		return;
	}
}
// Unity.MARS.MARSHandles.Picking.PickingData Unity.MARS.MARSHandles.Picking.MeshPickingTarget::GetPickingData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  MeshPickingTarget_GetPickingData_m20C01EAB986D9D62CD1D70B539F43A5DB78E36E8 (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, const RuntimeMethod* method)
{
	{
		// return new PickingData(m_Transform, m_CollisionMesh);
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = __this->get_m_Transform_5();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_1 = __this->get_m_CollisionMesh_4();
		PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  L_2;
		memset((&L_2), 0, sizeof(L_2));
		PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593((&L_2), L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.MeshPickingTarget::OnDrawGizmosSelected()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeshPickingTarget_OnDrawGizmosSelected_mF63556EDCC964C839A2EA18F063EACC58FA542C8 (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, const RuntimeMethod* method)
{
	{
		// Gizmos.color = Color.green;
		Color_tF40DAF76C04FFECF3FE6024F85A294741C9CC659  L_0;
		L_0 = Color_get_green_mFF9BD42534D385A0717B1EAD083ADF08712984B9(/*hidden argument*/NULL);
		Gizmos_set_color_m937ACC6288C81BAFFC3449FAA03BB4F680F4E74F(L_0, /*hidden argument*/NULL);
		// Gizmos.matrix = transform.localToWorldMatrix;
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_1;
		L_1 = Component_get_transform_mE8496EBC45BEB1BADB5F314960F1DF1C952FA11F(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_2;
		L_2 = Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC(L_1, /*hidden argument*/NULL);
		Gizmos_set_matrix_m635EE6CFFB53AC66FD134F82BEA90D1EAAAD5D5C(L_2, /*hidden argument*/NULL);
		// Gizmos.DrawWireMesh(m_CollisionMesh);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_3 = __this->get_m_CollisionMesh_4();
		Gizmos_DrawWireMesh_m93445D06F241AB0F2BDEA4A9FC3A8EF338BDCE7A(L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.MeshPickingTarget::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeshPickingTarget__ctor_m796779C12FECF4C07C84B34F6B1BF29018AFE461 (MeshPickingTarget_tB4FA7E7F30FA2A7CFD8EB31F4A492207F49FFB3A * __this, const RuntimeMethod* method)
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
// Conversion methods for marshalling of: Unity.MARS.MARSHandles.Picking.PickingData
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_pinvoke(const PickingData_t0262B9D068773D4DFA4052DBA84204378F146207& unmarshaled, PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_pinvoke& marshaled)
{
	Exception_t* ___U3CmeshU3Ek__BackingField_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<mesh>k__BackingField' of type 'PickingData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CmeshU3Ek__BackingField_2Exception, NULL);
}
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_pinvoke_back(const PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_pinvoke& marshaled, PickingData_t0262B9D068773D4DFA4052DBA84204378F146207& unmarshaled)
{
	Exception_t* ___U3CmeshU3Ek__BackingField_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<mesh>k__BackingField' of type 'PickingData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CmeshU3Ek__BackingField_2Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.MARSHandles.Picking.PickingData
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_pinvoke_cleanup(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.MARSHandles.Picking.PickingData
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_com(const PickingData_t0262B9D068773D4DFA4052DBA84204378F146207& unmarshaled, PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_com& marshaled)
{
	Exception_t* ___U3CmeshU3Ek__BackingField_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<mesh>k__BackingField' of type 'PickingData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CmeshU3Ek__BackingField_2Exception, NULL);
}
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_com_back(const PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_com& marshaled, PickingData_t0262B9D068773D4DFA4052DBA84204378F146207& unmarshaled)
{
	Exception_t* ___U3CmeshU3Ek__BackingField_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<mesh>k__BackingField' of type 'PickingData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CmeshU3Ek__BackingField_2Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.MARSHandles.Picking.PickingData
IL2CPP_EXTERN_C void PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshal_com_cleanup(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207_marshaled_com& marshaled)
{
}
// UnityEngine.Matrix4x4 Unity.MARS.MARSHandles.Picking.PickingData::get_matrix()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40 (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method)
{
	{
		// public Matrix4x4 matrix { get; private set; }
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_0 = __this->get_U3CmatrixU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  _returnValue;
	_returnValue = PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::set_matrix(UnityEngine.Matrix4x4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1 (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method)
{
	{
		// public Matrix4x4 matrix { get; private set; }
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_0 = ___value0;
		__this->set_U3CmatrixU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1_AdjustorThunk (RuntimeObject * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Mesh Unity.MARS.MARSHandles.Picking.PickingData::get_mesh()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method)
{
	{
		// public Mesh mesh { get; private set; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_U3CmeshU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * _returnValue;
	_returnValue = PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::set_mesh(UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3 (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___value0, const RuntimeMethod* method)
{
	{
		// public Mesh mesh { get; private set; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = ___value0;
		__this->set_U3CmeshU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3_AdjustorThunk (RuntimeObject * __this, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3_inline(_thisAdjusted, ___value0, method);
}
// System.Boolean Unity.MARS.MARSHandles.Picking.PickingData::get_valid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PickingData_get_valid_m9E4DB569FB050062AA9F32683EE54CF90290007D (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// get { return mesh != null; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0;
		L_0 = PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_inline((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mE1F187520BD83FB7D86A6D850710C4D42B864E90(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  bool PickingData_get_valid_m9E4DB569FB050062AA9F32683EE54CF90290007D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	bool _returnValue;
	_returnValue = PickingData_get_valid_m9E4DB569FB050062AA9F32683EE54CF90290007D(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::.ctor(UnityEngine.Matrix4x4,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData__ctor_m9AA17C27D68107EA85B0D2E9C9080C28C35E11BA (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method)
{
	{
		// public PickingData(Matrix4x4 matrix, Mesh mesh) : this()
		il2cpp_codegen_initobj(__this, sizeof(PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 ));
		// this.matrix = matrix;
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_0 = ___matrix0;
		PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1_inline((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)__this, L_0, /*hidden argument*/NULL);
		// this.mesh = mesh;
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_1 = ___mesh1;
		PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3_inline((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void PickingData__ctor_m9AA17C27D68107EA85B0D2E9C9080C28C35E11BA_AdjustorThunk (RuntimeObject * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	PickingData__ctor_m9AA17C27D68107EA85B0D2E9C9080C28C35E11BA(_thisAdjusted, ___matrix0, ___mesh1, method);
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::.ctor(UnityEngine.Transform,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593 (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___trs0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method)
{
	{
		// public PickingData(Transform trs, Mesh mesh) : this(trs.localToWorldMatrix, mesh)
		Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * L_0 = ___trs0;
		NullCheck(L_0);
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_1;
		L_1 = Transform_get_localToWorldMatrix_m6B810B0F20BA5DE48009461A4D662DD8BFF6A3CC(L_0, /*hidden argument*/NULL);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_2 = ___mesh1;
		PickingData__ctor_m9AA17C27D68107EA85B0D2E9C9080C28C35E11BA((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)__this, L_1, L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593_AdjustorThunk (RuntimeObject * __this, Transform_tA8193BB29D4D2C7EC04918F3ED1816345186C3F1 * ___trs0, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * _thisAdjusted = reinterpret_cast<PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *>(__this + _offset);
	PickingData__ctor_m03E157412194A28927A86C7DC32C105A23DD3593(_thisAdjusted, ___trs0, ___mesh1, method);
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingData::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingData__cctor_m238CFC51B88A9A6F5A5BD0919913387CD79B32ED (const RuntimeMethod* method)
{
	{
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
// Conversion methods for marshalling of: Unity.MARS.MARSHandles.Picking.PickingHit
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_pinvoke(const PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83& unmarshaled, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_pinvoke& marshaled)
{
	Exception_t* ___U3CtargetU3Ek__BackingField_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<target>k__BackingField' of type 'PickingHit': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CtargetU3Ek__BackingField_1Exception, NULL);
}
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_pinvoke_back(const PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_pinvoke& marshaled, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83& unmarshaled)
{
	Exception_t* ___U3CtargetU3Ek__BackingField_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<target>k__BackingField' of type 'PickingHit': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CtargetU3Ek__BackingField_1Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.MARSHandles.Picking.PickingHit
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_pinvoke_cleanup(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Unity.MARS.MARSHandles.Picking.PickingHit
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_com(const PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83& unmarshaled, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_com& marshaled)
{
	Exception_t* ___U3CtargetU3Ek__BackingField_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<target>k__BackingField' of type 'PickingHit': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CtargetU3Ek__BackingField_1Exception, NULL);
}
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_com_back(const PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_com& marshaled, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83& unmarshaled)
{
	Exception_t* ___U3CtargetU3Ek__BackingField_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<target>k__BackingField' of type 'PickingHit': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CtargetU3Ek__BackingField_1Exception, NULL);
}
// Conversion method for clean up from marshalling of: Unity.MARS.MARSHandles.Picking.PickingHit
IL2CPP_EXTERN_C void PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshal_com_cleanup(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83_marshaled_com& marshaled)
{
}
// System.Single Unity.MARS.MARSHandles.Picking.PickingHit::get_distance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method)
{
	{
		// public float distance { get; private set; }
		float L_0 = __this->get_U3CdistanceU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	float _returnValue;
	_returnValue = PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::set_distance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float distance { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CdistanceU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083_inline(_thisAdjusted, ___value0, method);
}
// Unity.MARS.MARSHandles.Picking.IPickingTarget Unity.MARS.MARSHandles.Picking.PickingHit::get_target()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method)
{
	{
		// public IPickingTarget target { get; private set; }
		RuntimeObject* L_0 = __this->get_U3CtargetU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  RuntimeObject* PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::set_target(Unity.MARS.MARSHandles.Picking.IPickingTarget)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, RuntimeObject* ___value0, const RuntimeMethod* method)
{
	{
		// public IPickingTarget target { get; private set; }
		RuntimeObject* L_0 = ___value0;
		__this->set_U3CtargetU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4_AdjustorThunk (RuntimeObject * __this, RuntimeObject* ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4_inline(_thisAdjusted, ___value0, method);
}
// System.Boolean Unity.MARS.MARSHandles.Picking.PickingHit::get_valid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PickingHit_get_valid_m0309BF370D7469ED618ACDBB3BE97FD0F4D76D2D (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method)
{
	{
		// public bool valid { get { return target != null; } }
		RuntimeObject* L_0;
		L_0 = PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)__this, /*hidden argument*/NULL);
		return (bool)((!(((RuntimeObject*)(RuntimeObject*)L_0) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool PickingHit_get_valid_m0309BF370D7469ED618ACDBB3BE97FD0F4D76D2D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	bool _returnValue;
	_returnValue = PickingHit_get_valid_m0309BF370D7469ED618ACDBB3BE97FD0F4D76D2D(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.PickingHit::.ctor(Unity.MARS.MARSHandles.Picking.IPickingTarget,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, RuntimeObject* ___target0, float ___distance1, const RuntimeMethod* method)
{
	{
		// public PickingHit(IPickingTarget target, float distance) : this()
		il2cpp_codegen_initobj(__this, sizeof(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 ));
		// this.target = target;
		RuntimeObject* L_0 = ___target0;
		PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)__this, L_0, /*hidden argument*/NULL);
		// this.distance = distance;
		float L_1 = ___distance1;
		PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)__this, L_1, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC_AdjustorThunk (RuntimeObject * __this, RuntimeObject* ___target0, float ___distance1, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC(_thisAdjusted, ___target0, ___distance1, method);
}
// System.Int32 Unity.MARS.MARSHandles.Picking.PickingHit::CompareTo(Unity.MARS.MARSHandles.Picking.PickingHit)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PickingHit_CompareTo_mB57DE7FA031359D8916D9DEB46C8AEE6C3D65B91 (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___other0, const RuntimeMethod* method)
{
	float V_0 = 0.0f;
	{
		// return distance.CompareTo(other.distance);
		float L_0;
		L_0 = PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)__this, /*hidden argument*/NULL);
		V_0 = L_0;
		float L_1;
		L_1 = PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)(&___other0), /*hidden argument*/NULL);
		int32_t L_2;
		L_2 = Single_CompareTo_m80B5B5A70A2343C3A8673F35635EBED4458109B4((float*)(&V_0), L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  int32_t PickingHit_CompareTo_mB57DE7FA031359D8916D9DEB46C8AEE6C3D65B91_AdjustorThunk (RuntimeObject * __this, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  ___other0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * _thisAdjusted = reinterpret_cast<PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PickingHit_CompareTo_mB57DE7FA031359D8916D9DEB46C8AEE6C3D65B91(_thisAdjusted, ___other0, method);
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
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ClosestPointToDisc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScreenDistanceUtility_ClosestPointToDisc_m00C69C2EB5CBC46C070003AC09AA8FD15BDD3F14 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, float ___radius3, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// Vector3 tangent = Vector3.Cross(normal, Vector3.up);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Vector3_get_up_m38AECA68388D446CFADDD022B0B867293044EA50(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		// if (tangent.sqrMagnitude < .001f)
		float L_3;
		L_3 = Vector3_get_sqrMagnitude_mC567EE6DF411501A8FE1F23A0038862630B88249((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&V_0), /*hidden argument*/NULL);
		if ((!(((float)L_3) < ((float)(0.00100000005f)))))
		{
			goto IL_0026;
		}
	}
	{
		// tangent = Vector3.Cross(normal, Vector3.right);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_get_right_mF5A51F81961474E0A7A31C2757FD00921FB79C44(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4(L_4, L_5, /*hidden argument*/NULL);
		V_0 = L_6;
	}

IL_0026:
	{
		// return ClosestPointToArc(screenPoint, center, normal, tangent, 360, radius, camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = ___screenPoint0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___center1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		float L_11 = ___radius3;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_12 = ___camera4;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		L_13 = ScreenDistanceUtility_ClosestPointToArc_m7B6F700D23DEA1BBBBB40A641F7D86ABD4255DCF(L_7, L_8, L_9, L_10, (360.0f), L_11, L_12, /*hidden argument*/NULL);
		return L_13;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ClosestPointToArc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScreenDistanceUtility_ClosestPointToArc_m7B6F700D23DEA1BBBBB40A641F7D86ABD4255DCF (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera6, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// GetDiscSectionPoints(s_PointsBuffer, center, normal, from, angle, radius);
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_PointsBuffer_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___center1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___from3;
		float L_4 = ___angle4;
		float L_5 = ___radius5;
		ScreenDistanceUtility_GetDiscSectionPoints_mA9979A0C3F41E052338BC97D6A53F09ED33BAB6B((RuntimeObject*)(RuntimeObject*)L_0, L_1, L_2, L_3, L_4, L_5, /*hidden argument*/NULL);
		// return ClosestPointToPolyLine(screenPoint, s_PointsBuffer, camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___screenPoint0;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_7 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_PointsBuffer_3();
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_8 = ___camera6;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = ScreenDistanceUtility_ClosestPointToPolyLine_mCCEF9F4D4EB2CE0B403285731F916AAE6B3C147C(L_6, (RuntimeObject*)(RuntimeObject*)L_7, L_8, /*hidden argument*/NULL);
		return L_9;
	}
}
// UnityEngine.Vector3 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ClosestPointToPolyLine(UnityEngine.Vector2,System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ScreenDistanceUtility_ClosestPointToPolyLine_mCCEF9F4D4EB2CE0B403285731F916AAE6B3C147C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___vertices1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_6;
	memset((&V_6), 0, sizeof(V_6));
	float V_7 = 0.0f;
	float V_8 = 0.0f;
	int32_t V_9 = 0;
	float V_10 = 0.0f;
	{
		// float dist = DistanceToLine(screenPoint, vertices[0], vertices[1], camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___screenPoint0;
		RuntimeObject* L_1 = ___vertices1;
		NullCheck(L_1);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_1, 0);
		RuntimeObject* L_3 = ___vertices1;
		NullCheck(L_3);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_3, 1);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_5 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_6;
		L_6 = ScreenDistanceUtility_DistanceToLine_mD6B8439755ABE686193114786AC2FE72947BF25C(L_0, L_2, L_4, L_5, /*hidden argument*/NULL);
		V_0 = L_6;
		// int nearest = 0;// Which segment we're closest to
		V_1 = 0;
		// for (int i = 2; i < vertices.Count; i++)
		V_9 = 2;
		goto IL_004b;
	}

IL_001d:
	{
		// float d = DistanceToLine(screenPoint, vertices[i - 1], vertices[i], camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = ___screenPoint0;
		RuntimeObject* L_8 = ___vertices1;
		int32_t L_9 = V_9;
		NullCheck(L_8);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_8, ((int32_t)il2cpp_codegen_subtract((int32_t)L_9, (int32_t)1)));
		RuntimeObject* L_11 = ___vertices1;
		int32_t L_12 = V_9;
		NullCheck(L_11);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		L_13 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_11, L_12);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_14 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_15;
		L_15 = ScreenDistanceUtility_DistanceToLine_mD6B8439755ABE686193114786AC2FE72947BF25C(L_7, L_10, L_13, L_14, /*hidden argument*/NULL);
		V_10 = L_15;
		// if (d < dist)
		float L_16 = V_10;
		float L_17 = V_0;
		if ((!(((float)L_16) < ((float)L_17))))
		{
			goto IL_0045;
		}
	}
	{
		// dist = d;
		float L_18 = V_10;
		V_0 = L_18;
		// nearest = i - 1;
		int32_t L_19 = V_9;
		V_1 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_19, (int32_t)1));
	}

IL_0045:
	{
		// for (int i = 2; i < vertices.Count; i++)
		int32_t L_20 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add((int32_t)L_20, (int32_t)1));
	}

IL_004b:
	{
		// for (int i = 2; i < vertices.Count; i++)
		int32_t L_21 = V_9;
		RuntimeObject* L_22 = ___vertices1;
		NullCheck(L_22);
		int32_t L_23;
		L_23 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.ICollection`1<UnityEngine.Vector3>::get_Count() */, ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var, L_22);
		if ((((int32_t)L_21) < ((int32_t)L_23)))
		{
			goto IL_001d;
		}
	}
	{
		// Vector3 lineStart = vertices[nearest];
		RuntimeObject* L_24 = ___vertices1;
		int32_t L_25 = V_1;
		NullCheck(L_24);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_26;
		L_26 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_24, L_25);
		V_2 = L_26;
		// Vector3 lineEnd = vertices[nearest + 1];
		RuntimeObject* L_27 = ___vertices1;
		int32_t L_28 = V_1;
		NullCheck(L_27);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_29;
		L_29 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_27, ((int32_t)il2cpp_codegen_add((int32_t)L_28, (int32_t)1)));
		V_3 = L_29;
		// Vector2 screenLineStart = camera.WorldToScreenPoint(lineStart);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_30 = ___camera2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_31 = V_2;
		NullCheck(L_30);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_32;
		L_32 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_30, L_31, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_33;
		L_33 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_32, /*hidden argument*/NULL);
		V_4 = L_33;
		// Vector2 relativePoint = screenPoint - screenLineStart;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_34 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_35 = V_4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_36;
		L_36 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_34, L_35, /*hidden argument*/NULL);
		V_5 = L_36;
		// Vector2 lineDirection = (Vector2)camera.WorldToScreenPoint(lineEnd) - screenLineStart;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_37 = ___camera2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_38 = V_3;
		NullCheck(L_37);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_39;
		L_39 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_37, L_38, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_40;
		L_40 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_39, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_41 = V_4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_42;
		L_42 = Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline(L_40, L_41, /*hidden argument*/NULL);
		V_6 = L_42;
		// float length = lineDirection.magnitude;
		float L_43;
		L_43 = Vector2_get_magnitude_mD30DB8EB73C4A5CD395745AE1CA1C38DC61D2E85((Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 *)(&V_6), /*hidden argument*/NULL);
		V_7 = L_43;
		// float dot = Vector3.Dot(lineDirection, relativePoint);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_44 = V_6;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_45;
		L_45 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_44, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_46 = V_5;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_47;
		L_47 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_46, /*hidden argument*/NULL);
		float L_48;
		L_48 = Vector3_Dot_mD19905B093915BA12852732EA27AA2DBE030D11F_inline(L_45, L_47, /*hidden argument*/NULL);
		V_8 = L_48;
		// if (length > .000001f)
		float L_49 = V_7;
		if ((!(((float)L_49) > ((float)(9.99999997E-07f)))))
		{
			goto IL_00c5;
		}
	}
	{
		// dot /= length * length;
		float L_50 = V_8;
		float L_51 = V_7;
		float L_52 = V_7;
		V_8 = ((float)((float)L_50/(float)((float)il2cpp_codegen_multiply((float)L_51, (float)L_52))));
	}

IL_00c5:
	{
		// dot = Mathf.Clamp01(dot);
		float L_53 = V_8;
		float L_54;
		L_54 = Mathf_Clamp01_m2296D75F0F1292D5C8181C57007A1CA45F440C4C(L_53, /*hidden argument*/NULL);
		V_8 = L_54;
		// return Vector3.Lerp(lineStart, lineEnd, dot);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_55 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_56 = V_3;
		float L_57 = V_8;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_58;
		L_58 = Vector3_Lerp_m8E095584FFA10CF1D3EABCD04F4C83FB82EC5524_inline(L_55, L_56, L_57, /*hidden argument*/NULL);
		return L_58;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToDisc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToDisc_m97F60756FEF3044114CA0BE278D5148F69892D05 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, float ___radius3, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// Vector3 tangent = Vector3.Cross(normal, Vector3.up);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1;
		L_1 = Vector3_get_up_m38AECA68388D446CFADDD022B0B867293044EA50(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		// if (tangent.sqrMagnitude < .001f)
		float L_3;
		L_3 = Vector3_get_sqrMagnitude_mC567EE6DF411501A8FE1F23A0038862630B88249((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&V_0), /*hidden argument*/NULL);
		if ((!(((float)L_3) < ((float)(0.00100000005f)))))
		{
			goto IL_0026;
		}
	}
	{
		// tangent = Vector3.Cross(normal, Vector3.right);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = Vector3_get_right_mF5A51F81961474E0A7A31C2757FD00921FB79C44(/*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_Cross_m63414F0C545EBB616F339FF8830D37F9230736A4(L_4, L_5, /*hidden argument*/NULL);
		V_0 = L_6;
	}

IL_0026:
	{
		// return DistanceToArc(screenPoint, center, normal, tangent, 360, radius, camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = ___screenPoint0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___center1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = V_0;
		float L_11 = ___radius3;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_12 = ___camera4;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_13;
		L_13 = ScreenDistanceUtility_DistanceToArc_m77C4A4F3381513F3F34F4F0D28049BD41874FA7F(L_7, L_8, L_9, L_10, (360.0f), L_11, L_12, /*hidden argument*/NULL);
		return L_13;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToArc(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToArc_m77C4A4F3381513F3F34F4F0D28049BD41874FA7F (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera6, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// GetDiscSectionPoints(s_PointsBuffer, center, normal, from, angle, radius);
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_0 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_PointsBuffer_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___center1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___normal2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_3 = ___from3;
		float L_4 = ___angle4;
		float L_5 = ___radius5;
		ScreenDistanceUtility_GetDiscSectionPoints_mA9979A0C3F41E052338BC97D6A53F09ED33BAB6B((RuntimeObject*)(RuntimeObject*)L_0, L_1, L_2, L_3, L_4, L_5, /*hidden argument*/NULL);
		// return DistanceToPolyLine(screenPoint, s_PointsBuffer, camera);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___screenPoint0;
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_7 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_PointsBuffer_3();
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_8 = ___camera6;
		float L_9;
		L_9 = ScreenDistanceUtility_DistanceToPolyLine_m344A73E69BBC3041BFAFB9322B5BD2FD5735024C(L_6, (RuntimeObject*)(RuntimeObject*)L_7, L_8, /*hidden argument*/NULL);
		return L_9;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToPolyLine(UnityEngine.Vector2,System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToPolyLine_m344A73E69BBC3041BFAFB9322B5BD2FD5735024C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___points1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		// float dist = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, max = points.Count - 1; i < max; ++i)
		V_1 = 0;
		// for (int i = 0, max = points.Count - 1; i < max; ++i)
		RuntimeObject* L_0 = ___points1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.ICollection`1<UnityEngine.Vector3>::get_Count() */, ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var, L_0);
		V_2 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)1));
		goto IL_0035;
	}

IL_0013:
	{
		// dist = Mathf.Min(dist, DistanceToLine(screenPoint, points[i], points[i+1], camera));
		float L_2 = V_0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = ___screenPoint0;
		RuntimeObject* L_4 = ___points1;
		int32_t L_5 = V_1;
		NullCheck(L_4);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_4, L_5);
		RuntimeObject* L_7 = ___points1;
		int32_t L_8 = V_1;
		NullCheck(L_7);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_7, ((int32_t)il2cpp_codegen_add((int32_t)L_8, (int32_t)1)));
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_10 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_11;
		L_11 = ScreenDistanceUtility_DistanceToLine_mD6B8439755ABE686193114786AC2FE72947BF25C(L_3, L_6, L_9, L_10, /*hidden argument*/NULL);
		float L_12;
		L_12 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_2, L_11, /*hidden argument*/NULL);
		V_0 = L_12;
		// for (int i = 0, max = points.Count - 1; i < max; ++i)
		int32_t L_13 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
	}

IL_0035:
	{
		// for (int i = 0, max = points.Count - 1; i < max; ++i)
		int32_t L_14 = V_1;
		int32_t L_15 = V_2;
		if ((((int32_t)L_14) < ((int32_t)L_15)))
		{
			goto IL_0013;
		}
	}
	{
		// return dist;
		float L_16 = V_0;
		return L_16;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLine(UnityEngine.Vector2,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLine_mD6B8439755ABE686193114786AC2FE72947BF25C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___p11, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___p22, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	{
		// p1 = (Vector2)camera.WorldToScreenPoint(p1);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_1 = ___p11;
		NullCheck(L_0);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2;
		L_2 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_0, L_1, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3;
		L_3 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_2, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4;
		L_4 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_3, /*hidden argument*/NULL);
		___p11 = L_4;
		// p2 = (Vector2)camera.WorldToScreenPoint(p2);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_5 = ___camera3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___p22;
		NullCheck(L_5);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_7;
		L_7 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_5, L_6, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8;
		L_8 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_7, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_8, /*hidden argument*/NULL);
		___p22 = L_9;
		// float result = MathUtility.DistanceToLine((Vector3)screenPoint, p1, p2);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_10 = ___screenPoint0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11;
		L_11 = Vector2_op_Implicit_m4FA146E613DBFE6C1C4B0E9B461D622E6F2FC294_inline(L_10, /*hidden argument*/NULL);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12 = ___p11;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = ___p22;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_14;
		L_14 = MathUtility_DistanceToLine_m806E9331F04A83733800190FBF5F96F4F487C762(L_11, L_12, L_13, /*hidden argument*/NULL);
		V_0 = L_14;
		// if (result < 0)
		float L_15 = V_0;
		if ((!(((float)L_15) < ((float)(0.0f)))))
		{
			goto IL_0042;
		}
	}
	{
		// result = 0.0f;
		V_0 = (0.0f);
	}

IL_0042:
	{
		// return result;
		float L_16 = V_0;
		return L_16;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToQuads(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>,System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad>,UnityEngine.Camera)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToQuads_m9FA4B7B3E3EF94A6026DC8CD223A2D56936AC10A (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___vertices1, RuntimeObject* ___quads2, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0F24F6C717B909765BFCCA5E6A79B3C882E07224_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t7D0A2C175B46FF20C9F2E14C757BF91753001159_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_7;
	memset((&V_7), 0, sizeof(V_7));
	{
		// ProjectVerticesOnScreen(camera, Matrix4x4.identity, vertices, s_ScreenProjectedVertices);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera3;
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_1;
		L_1 = Matrix4x4_get_identity_mC91289718DDD3DDBE0A10551BDA59A446414A596(/*hidden argument*/NULL);
		RuntimeObject* L_2 = ___vertices1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_3 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		ScreenDistanceUtility_ProjectVerticesOnScreen_m6B8A4BB50518A3A2376049ED34B60444C2AA668B(L_0, L_1, L_2, L_3, /*hidden argument*/NULL);
		// float closest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = quads.Count; i < count; ++i)
		V_1 = 0;
		// for (int i = 0, count = quads.Count; i < count; ++i)
		RuntimeObject* L_4 = ___quads2;
		NullCheck(L_4);
		int32_t L_5;
		L_5 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad>::get_Count() */, IReadOnlyCollection_1_t0F24F6C717B909765BFCCA5E6A79B3C882E07224_il2cpp_TypeInfo_var, L_4);
		V_2 = L_5;
		goto IL_008f;
	}

IL_0022:
	{
		// var quad = quads[i];
		RuntimeObject* L_6 = ___quads2;
		int32_t L_7 = V_1;
		NullCheck(L_6);
		Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85  L_8;
		L_8 = InterfaceFuncInvoker1< Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad>::get_Item(System.Int32) */, IReadOnlyList_1_t7D0A2C175B46FF20C9F2E14C757BF91753001159_il2cpp_TypeInfo_var, L_6, L_7);
		V_3 = L_8;
		// var a = s_ScreenProjectedVertices[quad.indexA];
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_9 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		int32_t L_10;
		L_10 = Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)(&V_3), /*hidden argument*/NULL);
		NullCheck(L_9);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_inline(L_9, L_10, /*hidden argument*/List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var);
		V_4 = L_11;
		// var b = s_ScreenProjectedVertices[quad.indexB];
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_12 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		int32_t L_13;
		L_13 = Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)(&V_3), /*hidden argument*/NULL);
		NullCheck(L_12);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14;
		L_14 = List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_inline(L_12, L_13, /*hidden argument*/List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var);
		V_5 = L_14;
		// var c = s_ScreenProjectedVertices[quad.indexC];
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_15 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		int32_t L_16;
		L_16 = Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)(&V_3), /*hidden argument*/NULL);
		NullCheck(L_15);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17;
		L_17 = List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_inline(L_15, L_16, /*hidden argument*/List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var);
		V_6 = L_17;
		// var d = s_ScreenProjectedVertices[quad.indexD];
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_18 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		int32_t L_19;
		L_19 = Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)(&V_3), /*hidden argument*/NULL);
		NullCheck(L_18);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20;
		L_20 = List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_inline(L_18, L_19, /*hidden argument*/List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_RuntimeMethod_var);
		V_7 = L_20;
		// closest = Mathf.Min(closest, MathUtility.DistanceToQuad(screenPoint, a, b, c, d));
		float L_21 = V_0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_22 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_23 = V_4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_24 = V_5;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_25 = V_6;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_26 = V_7;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_27;
		L_27 = MathUtility_DistanceToQuad_m7D07BBFDE23E1FDB204BB87795EA35B507729B54(L_22, L_23, L_24, L_25, L_26, /*hidden argument*/NULL);
		float L_28;
		L_28 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_21, L_27, /*hidden argument*/NULL);
		V_0 = L_28;
		// for (int i = 0, count = quads.Count; i < count; ++i)
		int32_t L_29 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_29, (int32_t)1));
	}

IL_008f:
	{
		// for (int i = 0, count = quads.Count; i < count; ++i)
		int32_t L_30 = V_1;
		int32_t L_31 = V_2;
		if ((((int32_t)L_30) < ((int32_t)L_31)))
		{
			goto IL_0022;
		}
	}
	{
		// return closest;
		float L_32 = V_0;
		return L_32;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::GetDiscSectionPoints(System.Collections.Generic.IList`1<UnityEngine.Vector3>,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenDistanceUtility_GetDiscSectionPoints_mA9979A0C3F41E052338BC97D6A53F09ED33BAB6B (RuntimeObject* ___dest0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___center1, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___normal2, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___from3, float ___angle4, float ___radius5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	int32_t V_3 = 0;
	{
		// int count = dest.Count;
		RuntimeObject* L_0 = ___dest0;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.ICollection`1<UnityEngine.Vector3>::get_Count() */, ICollection_1_t1EFFD31D0AA9459887F8D8ADAF922325265AF4B5_il2cpp_TypeInfo_var, L_0);
		V_0 = L_1;
		// Quaternion r = Quaternion.AngleAxis((angle / (count - 1)) * Mathf.Deg2Rad, normal);
		float L_2 = ___angle4;
		int32_t L_3 = V_0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___normal2;
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_5;
		L_5 = Quaternion_AngleAxis_m4644D20F58ADF03E9EA297CB4A845E5BCDA1E398(((float)il2cpp_codegen_multiply((float)((float)((float)L_2/(float)((float)((float)((int32_t)il2cpp_codegen_subtract((int32_t)L_3, (int32_t)1)))))), (float)(0.0174532924f))), L_4, /*hidden argument*/NULL);
		V_1 = L_5;
		// Vector3 tangent = from.normalized * radius;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6;
		L_6 = Vector3_get_normalized_m2FA6DF38F97BDA4CCBDAE12B9FE913A241DAC8D5((Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E *)(&___from3), /*hidden argument*/NULL);
		float L_7 = ___radius5;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8;
		L_8 = Vector3_op_Multiply_m9EA3D18290418D7B410C7D11C4788C13BFD2C30A_inline(L_6, L_7, /*hidden argument*/NULL);
		V_2 = L_8;
		// for (int i = 0; i < count; ++i)
		V_3 = 0;
		goto IL_0048;
	}

IL_002e:
	{
		// dest[i] = center + tangent;
		RuntimeObject* L_9 = ___dest0;
		int32_t L_10 = V_3;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = ___center1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_12 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13;
		L_13 = Vector3_op_Addition_mEE4F672B923CCB184C39AABCA33443DB218E50E0_inline(L_11, L_12, /*hidden argument*/NULL);
		NullCheck(L_9);
		InterfaceActionInvoker2< int32_t, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  >::Invoke(1 /* System.Void System.Collections.Generic.IList`1<UnityEngine.Vector3>::set_Item(System.Int32,!0) */, IList_1_t8B00F815D77E0AC6983C059BC09DBC979F8E86E0_il2cpp_TypeInfo_var, L_9, L_10, L_13);
		// tangent = r * tangent;
		Quaternion_t6D28618CF65156D4A0AD747370DDFD0C514A31B4  L_14 = V_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_15 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16;
		L_16 = Quaternion_op_Multiply_mDC5F913E6B21FEC72AB2CF737D34CC6C7A69803D(L_14, L_15, /*hidden argument*/NULL);
		V_2 = L_16;
		// for (int i = 0; i < count; ++i)
		int32_t L_17 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_17, (int32_t)1));
	}

IL_0048:
	{
		// for (int i = 0; i < count; ++i)
		int32_t L_18 = V_3;
		int32_t L_19 = V_0;
		if ((((int32_t)L_18) < ((int32_t)L_19)))
		{
			goto IL_002e;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::ProjectVerticesOnScreen(UnityEngine.Camera,UnityEngine.Matrix4x4,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>,System.Collections.Generic.ICollection`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenDistanceUtility_ProjectVerticesOnScreen_m6B8A4BB50518A3A2376049ED34B60444C2AA668B (Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera0, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix1, RuntimeObject* ___vertices2, RuntimeObject* ___results3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t00B5CAC82DBD853D6781EA9FA2C2A064B75DEC20_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_tEB2B5EE0BB8413A0FF90FB1624044333432ABEA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t8DA862FFC86BFEF2B4384525D73EC4D91635F3D7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		// results.Clear();
		RuntimeObject* L_0 = ___results3;
		NullCheck(L_0);
		InterfaceActionInvoker0::Invoke(3 /* System.Void System.Collections.Generic.ICollection`1<UnityEngine.Vector2>::Clear() */, ICollection_1_t00B5CAC82DBD853D6781EA9FA2C2A064B75DEC20_il2cpp_TypeInfo_var, L_0);
		// for (int i = 0, count = vertices.Count; i < count; ++i)
		V_0 = 0;
		// for (int i = 0, count = vertices.Count; i < count; ++i)
		RuntimeObject* L_1 = ___vertices2;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<UnityEngine.Vector3>::get_Count() */, IReadOnlyCollection_1_tEB2B5EE0BB8413A0FF90FB1624044333432ABEA3_il2cpp_TypeInfo_var, L_1);
		V_1 = L_2;
		goto IL_0036;
	}

IL_0011:
	{
		// var vertex = vertices[i];
		RuntimeObject* L_3 = ___vertices2;
		int32_t L_4 = V_0;
		NullCheck(L_3);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_5;
		L_5 = InterfaceFuncInvoker1< Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>::get_Item(System.Int32) */, IReadOnlyList_1_t8DA862FFC86BFEF2B4384525D73EC4D91635F3D7_il2cpp_TypeInfo_var, L_3, L_4);
		V_2 = L_5;
		// results.Add(camera.WorldToScreenPoint(matrix.MultiplyPoint(vertex)));
		RuntimeObject* L_6 = ___results3;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_7 = ___camera0;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = V_2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9;
		L_9 = Matrix4x4_MultiplyPoint_mE92BEE4DED3B602983C2BBE06C44AD29564EDA83((Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461 *)(&___matrix1), L_8, /*hidden argument*/NULL);
		NullCheck(L_7);
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10;
		L_10 = Camera_WorldToScreenPoint_m44710195E7736CE9DE5A9B05E32059A9A950F95C(L_7, L_9, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline(L_10, /*hidden argument*/NULL);
		NullCheck(L_6);
		InterfaceActionInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  >::Invoke(2 /* System.Void System.Collections.Generic.ICollection`1<UnityEngine.Vector2>::Add(!0) */, ICollection_1_t00B5CAC82DBD853D6781EA9FA2C2A064B75DEC20_il2cpp_TypeInfo_var, L_6, L_11);
		// for (int i = 0, count = vertices.Count; i < count; ++i)
		int32_t L_12 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_12, (int32_t)1));
	}

IL_0036:
	{
		// for (int i = 0, count = vertices.Count; i < count; ++i)
		int32_t L_13 = V_0;
		int32_t L_14 = V_1;
		if ((((int32_t)L_13) < ((int32_t)L_14)))
		{
			goto IL_0011;
		}
	}
	{
		// }
		return;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToMesh(UnityEngine.Vector2,UnityEngine.Camera,UnityEngine.Matrix4x4,UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToMesh_m96784DFBA4B4E7233992C45D5B1206C74DDC4F49 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera1, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix2, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___mesh3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	{
		// if (mesh == null)
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = ___mesh3;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_0, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_000f;
		}
	}
	{
		// return float.MaxValue;
		return ((std::numeric_limits<float>::max)());
	}

IL_000f:
	{
		// mesh.GetVertices(s_VertexBuffer);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_2 = ___mesh3;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_3 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_VertexBuffer_0();
		NullCheck(L_2);
		Mesh_GetVertices_mCC533BC8D4A9F14BA1A54BABB11B01750C153015(L_2, L_3, /*hidden argument*/NULL);
		// ProjectVerticesOnScreen(camera, matrix, s_VertexBuffer, s_ScreenProjectedVertices);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_4 = ___camera1;
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_5 = ___matrix2;
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_6 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_VertexBuffer_0();
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_7 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		ScreenDistanceUtility_ProjectVerticesOnScreen_m6B8A4BB50518A3A2376049ED34B60444C2AA668B(L_4, L_5, L_6, L_7, /*hidden argument*/NULL);
		// float distance = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0; i < mesh.subMeshCount; ++i)
		V_1 = 0;
		goto IL_0063;
	}

IL_0035:
	{
		// mesh.GetIndices(s_IndicesBuffer, i);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_8 = ___mesh3;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_9 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_IndicesBuffer_2();
		int32_t L_10 = V_1;
		NullCheck(L_8);
		Mesh_GetIndices_m1893F3E4888178EB0F26B7E98A9753C302C750B1(L_8, L_9, L_10, /*hidden argument*/NULL);
		// distance = Mathf.Min(distance, DistanceToMesh(screenPoint, s_ScreenProjectedVertices, s_IndicesBuffer, mesh.GetTopology(i)));
		float L_11 = V_0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___screenPoint0;
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_13 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_14 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_IndicesBuffer_2();
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_15 = ___mesh3;
		int32_t L_16 = V_1;
		NullCheck(L_15);
		int32_t L_17;
		L_17 = Mesh_GetTopology_m915B9BB8ABA4FF551B8E0F91529DCD5D0D48BD5C(L_15, L_16, /*hidden argument*/NULL);
		float L_18;
		L_18 = ScreenDistanceUtility_DistanceToMesh_m4F39F587CFAA82AC18581F3DB47F9F7BCA48CE46(L_12, L_13, L_14, L_17, /*hidden argument*/NULL);
		float L_19;
		L_19 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_11, L_18, /*hidden argument*/NULL);
		V_0 = L_19;
		// for (int i = 0; i < mesh.subMeshCount; ++i)
		int32_t L_20 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_20, (int32_t)1));
	}

IL_0063:
	{
		// for (int i = 0; i < mesh.subMeshCount; ++i)
		int32_t L_21 = V_1;
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_22 = ___mesh3;
		NullCheck(L_22);
		int32_t L_23;
		L_23 = Mesh_get_subMeshCount_m60E2BCBFEEF21260C70D06EAEC3A2A51D80796FF(L_22, /*hidden argument*/NULL);
		if ((((int32_t)L_21) < ((int32_t)L_23)))
		{
			goto IL_0035;
		}
	}
	{
		// return distance;
		float L_24 = V_0;
		return L_24;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToMesh(UnityEngine.Vector2,UnityEngine.Camera,UnityEngine.Matrix4x4,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector3>,System.Collections.Generic.IReadOnlyList`1<System.Int32>,UnityEngine.MeshTopology)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToMesh_mA88E0B7D0C921584C33910F1F21123DD9711CA5C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera1, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___matrix2, RuntimeObject* ___vertices3, RuntimeObject* ___indices4, int32_t ___topology5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// ProjectVerticesOnScreen(camera, matrix, vertices, s_ScreenProjectedVertices);
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_0 = ___camera1;
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_1 = ___matrix2;
		RuntimeObject* L_2 = ___vertices3;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_3 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		ScreenDistanceUtility_ProjectVerticesOnScreen_m6B8A4BB50518A3A2376049ED34B60444C2AA668B(L_0, L_1, L_2, L_3, /*hidden argument*/NULL);
		// return DistanceToMesh(screenPoint, s_ScreenProjectedVertices, indices, topology);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___screenPoint0;
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_5 = ((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->get_s_ScreenProjectedVertices_1();
		RuntimeObject* L_6 = ___indices4;
		int32_t L_7 = ___topology5;
		float L_8;
		L_8 = ScreenDistanceUtility_DistanceToMesh_m4F39F587CFAA82AC18581F3DB47F9F7BCA48CE46(L_4, L_5, L_6, L_7, /*hidden argument*/NULL);
		return L_8;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>,System.Collections.Generic.IReadOnlyList`1<System.Int32>,UnityEngine.MeshTopology)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToMesh_m4F39F587CFAA82AC18581F3DB47F9F7BCA48CE46 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___verticesOnScreen1, RuntimeObject* ___indices2, int32_t ___topology3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___topology3;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0020;
			}
			case 1:
			{
				goto IL_004d;
			}
			case 2:
			{
				goto IL_0029;
			}
			case 3:
			{
				goto IL_003b;
			}
			case 4:
			{
				goto IL_0044;
			}
			case 5:
			{
				goto IL_0032;
			}
		}
	}
	{
		goto IL_004d;
	}

IL_0020:
	{
		// return DistanceToTrianglesMesh(screenPoint, indices, verticesOnScreen);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_1 = ___screenPoint0;
		RuntimeObject* L_2 = ___indices2;
		RuntimeObject* L_3 = ___verticesOnScreen1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_4;
		L_4 = ScreenDistanceUtility_DistanceToTrianglesMesh_m14A521CCBF100CCA6E1546743EB70B677B1B477C(L_1, L_2, L_3, /*hidden argument*/NULL);
		return L_4;
	}

IL_0029:
	{
		// return DistanceToQuadsMesh(screenPoint, indices, verticesOnScreen);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_5 = ___screenPoint0;
		RuntimeObject* L_6 = ___indices2;
		RuntimeObject* L_7 = ___verticesOnScreen1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_8;
		L_8 = ScreenDistanceUtility_DistanceToQuadsMesh_m74E13339C4D18CB8ACDFCE21D3C81923B3318A30(L_5, L_6, L_7, /*hidden argument*/NULL);
		return L_8;
	}

IL_0032:
	{
		// return DistanceToPointsMesh(screenPoint, indices, verticesOnScreen);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_9 = ___screenPoint0;
		RuntimeObject* L_10 = ___indices2;
		RuntimeObject* L_11 = ___verticesOnScreen1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_12;
		L_12 = ScreenDistanceUtility_DistanceToPointsMesh_m428FEF3CD7F1E1AF93ECA181DDC5D1D9D35F5DDD(L_9, L_10, L_11, /*hidden argument*/NULL);
		return L_12;
	}

IL_003b:
	{
		// return DistanceToLinesMesh(screenPoint, indices, verticesOnScreen);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_13 = ___screenPoint0;
		RuntimeObject* L_14 = ___indices2;
		RuntimeObject* L_15 = ___verticesOnScreen1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_16;
		L_16 = ScreenDistanceUtility_DistanceToLinesMesh_m339DE7D6BF5DFF7EEE7817A5433F9CEFA18C13BF(L_13, L_14, L_15, /*hidden argument*/NULL);
		return L_16;
	}

IL_0044:
	{
		// return DistanceToLineStripMesh(screenPoint, indices, verticesOnScreen);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17 = ___screenPoint0;
		RuntimeObject* L_18 = ___indices2;
		RuntimeObject* L_19 = ___verticesOnScreen1;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_20;
		L_20 = ScreenDistanceUtility_DistanceToLineStripMesh_mCE8CF0D4EB48872D93E0664EA1ED2E2142DC7CA9(L_17, L_18, L_19, /*hidden argument*/NULL);
		return L_20;
	}

IL_004d:
	{
		// return float.MaxValue;
		return ((std::numeric_limits<float>::max)());
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToTrianglesMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToTrianglesMesh_m14A521CCBF100CCA6E1546743EB70B677B1B477C (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___triangles1, RuntimeObject* ___vertices2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_5;
	memset((&V_5), 0, sizeof(V_5));
	{
		// float nearest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = triangles.Count; i < count; i += 3)
		V_1 = 0;
		// for (int i = 0, count = triangles.Count; i < count; i += 3)
		RuntimeObject* L_0 = ___triangles1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<System.Int32>::get_Count() */, IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var, L_0);
		V_2 = L_1;
		goto IL_0057;
	}

IL_0011:
	{
		// var a = vertices[triangles[i]];
		RuntimeObject* L_2 = ___vertices2;
		RuntimeObject* L_3 = ___triangles1;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5;
		L_5 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_3, L_4);
		NullCheck(L_2);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		L_6 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_2, L_5);
		V_3 = L_6;
		// var b = vertices[triangles[i + 1]];
		RuntimeObject* L_7 = ___vertices2;
		RuntimeObject* L_8 = ___triangles1;
		int32_t L_9 = V_1;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_8, ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1)));
		NullCheck(L_7);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_7, L_10);
		V_4 = L_11;
		// var c = vertices[triangles[i + 2]];
		RuntimeObject* L_12 = ___vertices2;
		RuntimeObject* L_13 = ___triangles1;
		int32_t L_14 = V_1;
		NullCheck(L_13);
		int32_t L_15;
		L_15 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_13, ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)2)));
		NullCheck(L_12);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_16;
		L_16 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_12, L_15);
		V_5 = L_16;
		// nearest = Mathf.Min(MathUtility.DistanceToTriangle(screenPoint, a, b, c), nearest);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_18 = V_3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_19 = V_4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_20 = V_5;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_21;
		L_21 = MathUtility_DistanceToTriangle_mB3ECBAE02FD0ED48F57CCE4137A94D55CC6DDD9B(L_17, L_18, L_19, L_20, /*hidden argument*/NULL);
		float L_22 = V_0;
		float L_23;
		L_23 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_21, L_22, /*hidden argument*/NULL);
		V_0 = L_23;
		// for (int i = 0, count = triangles.Count; i < count; i += 3)
		int32_t L_24 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_24, (int32_t)3));
	}

IL_0057:
	{
		// for (int i = 0, count = triangles.Count; i < count; i += 3)
		int32_t L_25 = V_1;
		int32_t L_26 = V_2;
		if ((((int32_t)L_25) < ((int32_t)L_26)))
		{
			goto IL_0011;
		}
	}
	{
		// return nearest;
		float L_27 = V_0;
		return L_27;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToPointsMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToPointsMesh_m428FEF3CD7F1E1AF93ECA181DDC5D1D9D35F5DDD (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		// float nearest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = indices.Count; i < count; ++i)
		V_1 = 0;
		// for (int i = 0, count = indices.Count; i < count; ++i)
		RuntimeObject* L_0 = ___indices1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<System.Int32>::get_Count() */, IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var, L_0);
		V_2 = L_1;
		goto IL_002f;
	}

IL_0011:
	{
		// nearest = Mathf.Min(Vector2.Distance(screenPoint, vertices[indices[i]]), nearest);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___screenPoint0;
		RuntimeObject* L_3 = ___vertices2;
		RuntimeObject* L_4 = ___indices1;
		int32_t L_5 = V_1;
		NullCheck(L_4);
		int32_t L_6;
		L_6 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_4, L_5);
		NullCheck(L_3);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7;
		L_7 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_3, L_6);
		float L_8;
		L_8 = Vector2_Distance_m7DFAD110E57AF0E903DDC47BDBD99D1CC62EA03F(L_2, L_7, /*hidden argument*/NULL);
		float L_9 = V_0;
		float L_10;
		L_10 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_8, L_9, /*hidden argument*/NULL);
		V_0 = L_10;
		// for (int i = 0, count = indices.Count; i < count; ++i)
		int32_t L_11 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_11, (int32_t)1));
	}

IL_002f:
	{
		// for (int i = 0, count = indices.Count; i < count; ++i)
		int32_t L_12 = V_1;
		int32_t L_13 = V_2;
		if ((((int32_t)L_12) < ((int32_t)L_13)))
		{
			goto IL_0011;
		}
	}
	{
		// return nearest;
		float L_14 = V_0;
		return L_14;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToQuadsMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToQuadsMesh_m74E13339C4D18CB8ACDFCE21D3C81923B3318A30 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_6;
	memset((&V_6), 0, sizeof(V_6));
	{
		// float nearest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = indices.Count; i < count; i += 4)
		V_1 = 0;
		// for (int i = 0, count = indices.Count; i < count; i += 4)
		RuntimeObject* L_0 = ___indices1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<System.Int32>::get_Count() */, IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var, L_0);
		V_2 = L_1;
		goto IL_006a;
	}

IL_0011:
	{
		// Vector2 a = vertices[indices[i]];
		RuntimeObject* L_2 = ___vertices2;
		RuntimeObject* L_3 = ___indices1;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5;
		L_5 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_3, L_4);
		NullCheck(L_2);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		L_6 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_2, L_5);
		V_3 = L_6;
		// Vector2 b = vertices[indices[i + 1]];
		RuntimeObject* L_7 = ___vertices2;
		RuntimeObject* L_8 = ___indices1;
		int32_t L_9 = V_1;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_8, ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1)));
		NullCheck(L_7);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_7, L_10);
		V_4 = L_11;
		// Vector2 c = vertices[indices[i + 2]];
		RuntimeObject* L_12 = ___vertices2;
		RuntimeObject* L_13 = ___indices1;
		int32_t L_14 = V_1;
		NullCheck(L_13);
		int32_t L_15;
		L_15 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_13, ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)2)));
		NullCheck(L_12);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_16;
		L_16 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_12, L_15);
		V_5 = L_16;
		// Vector2 d = vertices[indices[i + 3]];
		RuntimeObject* L_17 = ___vertices2;
		RuntimeObject* L_18 = ___indices1;
		int32_t L_19 = V_1;
		NullCheck(L_18);
		int32_t L_20;
		L_20 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_18, ((int32_t)il2cpp_codegen_add((int32_t)L_19, (int32_t)3)));
		NullCheck(L_17);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_21;
		L_21 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_17, L_20);
		V_6 = L_21;
		// nearest = Mathf.Min(MathUtility.DistanceToQuad(screenPoint, a, b, c, d), nearest);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_22 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_23 = V_3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_24 = V_4;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_25 = V_5;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_26 = V_6;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_27;
		L_27 = MathUtility_DistanceToQuad_m7D07BBFDE23E1FDB204BB87795EA35B507729B54(L_22, L_23, L_24, L_25, L_26, /*hidden argument*/NULL);
		float L_28 = V_0;
		float L_29;
		L_29 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_27, L_28, /*hidden argument*/NULL);
		V_0 = L_29;
		// for (int i = 0, count = indices.Count; i < count; i += 4)
		int32_t L_30 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_30, (int32_t)4));
	}

IL_006a:
	{
		// for (int i = 0, count = indices.Count; i < count; i += 4)
		int32_t L_31 = V_1;
		int32_t L_32 = V_2;
		if ((((int32_t)L_31) < ((int32_t)L_32)))
		{
			goto IL_0011;
		}
	}
	{
		// return nearest;
		float L_33 = V_0;
		return L_33;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLineStripMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLineStripMesh_mCE8CF0D4EB48872D93E0664EA1ED2E2142DC7CA9 (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	{
		// float nearest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = indices.Count - 1; i < count; ++i)
		V_1 = 0;
		// for (int i = 0, count = indices.Count - 1; i < count; ++i)
		RuntimeObject* L_0 = ___indices1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<System.Int32>::get_Count() */, IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var, L_0);
		V_2 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)1));
		goto IL_0046;
	}

IL_0013:
	{
		// Vector2 a = vertices[indices[i]];
		RuntimeObject* L_2 = ___vertices2;
		RuntimeObject* L_3 = ___indices1;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5;
		L_5 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_3, L_4);
		NullCheck(L_2);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		L_6 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_2, L_5);
		V_3 = L_6;
		// Vector2 b = vertices[indices[i + 1]];
		RuntimeObject* L_7 = ___vertices2;
		RuntimeObject* L_8 = ___indices1;
		int32_t L_9 = V_1;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_8, ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1)));
		NullCheck(L_7);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_7, L_10);
		V_4 = L_11;
		// nearest = Mathf.Min(MathUtility.DistanceToLine(screenPoint, a, b), nearest);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_13 = V_3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = V_4;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_15;
		L_15 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_12, L_13, L_14, /*hidden argument*/NULL);
		float L_16 = V_0;
		float L_17;
		L_17 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_15, L_16, /*hidden argument*/NULL);
		V_0 = L_17;
		// for (int i = 0, count = indices.Count - 1; i < count; ++i)
		int32_t L_18 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_18, (int32_t)1));
	}

IL_0046:
	{
		// for (int i = 0, count = indices.Count - 1; i < count; ++i)
		int32_t L_19 = V_1;
		int32_t L_20 = V_2;
		if ((((int32_t)L_19) < ((int32_t)L_20)))
		{
			goto IL_0013;
		}
	}
	{
		// return nearest;
		float L_21 = V_0;
		return L_21;
	}
}
// System.Single Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::DistanceToLinesMesh(UnityEngine.Vector2,System.Collections.Generic.IReadOnlyList`1<System.Int32>,System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float ScreenDistanceUtility_DistanceToLinesMesh_m339DE7D6BF5DFF7EEE7817A5433F9CEFA18C13BF (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPoint0, RuntimeObject* ___indices1, RuntimeObject* ___vertices2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_4;
	memset((&V_4), 0, sizeof(V_4));
	{
		// float nearest = float.MaxValue;
		V_0 = ((std::numeric_limits<float>::max)());
		// for (int i = 0, count = indices.Count; i < count; i += 2)
		V_1 = 0;
		// for (int i = 0, count = indices.Count; i < count; i += 2)
		RuntimeObject* L_0 = ___indices1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<System.Int32>::get_Count() */, IReadOnlyCollection_1_t0D95864C2E83E646D47E3F985CE9697CCCA3DFCF_il2cpp_TypeInfo_var, L_0);
		V_2 = L_1;
		goto IL_0044;
	}

IL_0011:
	{
		// Vector2 a = vertices[indices[i]];
		RuntimeObject* L_2 = ___vertices2;
		RuntimeObject* L_3 = ___indices1;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5;
		L_5 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_3, L_4);
		NullCheck(L_2);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		L_6 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_2, L_5);
		V_3 = L_6;
		// Vector2 b = vertices[indices[i + 1]];
		RuntimeObject* L_7 = ___vertices2;
		RuntimeObject* L_8 = ___indices1;
		int32_t L_9 = V_1;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = InterfaceFuncInvoker1< int32_t, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<System.Int32>::get_Item(System.Int32) */, IReadOnlyList_1_tB3AB3F1D85AC1022B190374EE5B88DD1010714CF_il2cpp_TypeInfo_var, L_8, ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1)));
		NullCheck(L_7);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_11;
		L_11 = InterfaceFuncInvoker1< Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 , int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.Vector2>::get_Item(System.Int32) */, IReadOnlyList_1_t96E48FD61F2DF35D415FC64A60494E4FB6EB6D60_il2cpp_TypeInfo_var, L_7, L_10);
		V_4 = L_11;
		// nearest = Mathf.Min(MathUtility.DistanceToLine(screenPoint, a, b), nearest);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_12 = ___screenPoint0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_13 = V_3;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_14 = V_4;
		IL2CPP_RUNTIME_CLASS_INIT(MathUtility_t19B785374EC68EA054260D19F8753BACE4BA6B2C_il2cpp_TypeInfo_var);
		float L_15;
		L_15 = MathUtility_DistanceToLine_mF2548F0883EEB9125C8A0C131DA0360DE6FE3E94(L_12, L_13, L_14, /*hidden argument*/NULL);
		float L_16 = V_0;
		float L_17;
		L_17 = Mathf_Min_mD28BD5C9012619B74E475F204F96603193E99B14(L_15, L_16, /*hidden argument*/NULL);
		V_0 = L_17;
		// for (int i = 0, count = indices.Count; i < count; i += 2)
		int32_t L_18 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_18, (int32_t)2));
	}

IL_0044:
	{
		// for (int i = 0, count = indices.Count; i < count; i += 2)
		int32_t L_19 = V_1;
		int32_t L_20 = V_2;
		if ((((int32_t)L_19) < ((int32_t)L_20)))
		{
			goto IL_0011;
		}
	}
	{
		// return nearest;
		float L_21 = V_0;
		return L_21;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenDistanceUtility__cctor_m121EFAF8426F706EE68E6CF51E4EA07BB99B85D7 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly List<Vector3> s_VertexBuffer = new List<Vector3>(256);
		List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 * L_0 = (List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181 *)il2cpp_codegen_object_new(List_1_t577D28CFF6DFE3F6A8D4409F7A21CBF513C04181_il2cpp_TypeInfo_var);
		List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82(L_0, ((int32_t)256), /*hidden argument*/List_1__ctor_mAB5C8082843D5BE306E3B6185D7031436251DB82_RuntimeMethod_var);
		((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->set_s_VertexBuffer_0(L_0);
		// static readonly List<Vector2> s_ScreenProjectedVertices = new List<Vector2>(256);
		List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * L_1 = (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 *)il2cpp_codegen_object_new(List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9_il2cpp_TypeInfo_var);
		List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C(L_1, ((int32_t)256), /*hidden argument*/List_1__ctor_mDC4D7DF8F916E24A027C06B4401638A5E5E9A28C_RuntimeMethod_var);
		((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->set_s_ScreenProjectedVertices_1(L_1);
		// static readonly List<int> s_IndicesBuffer = new List<int>(256);
		List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * L_2 = (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 *)il2cpp_codegen_object_new(List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7_il2cpp_TypeInfo_var);
		List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91(L_2, ((int32_t)256), /*hidden argument*/List_1__ctor_m2E6FAF166391779F0D33F6E8282BA71222DA1A91_RuntimeMethod_var);
		((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->set_s_IndicesBuffer_2(L_2);
		// static readonly Vector3[] s_PointsBuffer = new Vector3[60];
		Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4* L_3 = (Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4*)SZArrayNew(Vector3U5BU5D_t5FB88EAA33E46838BDC2ABDAEA3E8727491CB9E4_il2cpp_TypeInfo_var, (uint32_t)((int32_t)60));
		((ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_StaticFields*)il2cpp_codegen_static_fields_for(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var))->set_s_PointsBuffer_3(L_3);
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
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHovered(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,Unity.MARS.MARSHandles.Picking.PickingHit&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46 (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * ___hit4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  V_0;
	memset((&V_0), 0, sizeof(V_0));
	Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC  V_1;
	memset((&V_1), 0, sizeof(V_1));
	PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  V_2;
	memset((&V_2), 0, sizeof(V_2));
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46_RuntimeMethod_var)));
	}

IL_0022:
	{
		// if (!GetHoveredAll(targets, screenPosition, camera, maxDistance, s_HitsBuffer))
		RuntimeObject* L_5 = ___targets0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_7 = ___camera2;
		float L_8 = ___maxDistance3;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_9 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_HitsBuffer_0();
		bool L_10;
		L_10 = ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A(L_5, L_6, L_7, L_8, L_9, /*hidden argument*/NULL);
		if (L_10)
		{
			goto IL_0046;
		}
	}
	{
		// hit = new PickingHit(null, float.MaxValue);
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * L_11 = ___hit4;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_12;
		memset((&L_12), 0, sizeof(L_12));
		PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC((&L_12), (RuntimeObject*)NULL, ((std::numeric_limits<float>::max)()), /*hidden argument*/NULL);
		*(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_11 = L_12;
		Il2CppCodeGenWriteBarrier((void**)&(((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_11)->___U3CtargetU3Ek__BackingField_1), (void*)NULL);
		// return false;
		return (bool)0;
	}

IL_0046:
	{
		// PickingHit closest = new PickingHit(null, float.MaxValue);
		PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)(&V_0), (RuntimeObject*)NULL, ((std::numeric_limits<float>::max)()), /*hidden argument*/NULL);
		// foreach (var h in s_HitsBuffer)
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_13 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_HitsBuffer_0();
		NullCheck(L_13);
		Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC  L_14;
		L_14 = List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4(L_13, /*hidden argument*/List_1_GetEnumerator_m7911E3A94F160C89DC6D2ADDCB5A84422CAC50F4_RuntimeMethod_var);
		V_1 = L_14;
	}

IL_005e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_007a;
		}

IL_0060:
		{
			// foreach (var h in s_HitsBuffer)
			PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_15;
			L_15 = Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_inline((Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *)(&V_1), /*hidden argument*/Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_RuntimeMethod_var);
			V_2 = L_15;
			// if (h.distance < closest.distance)
			float L_16;
			L_16 = PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)(&V_2), /*hidden argument*/NULL);
			float L_17;
			L_17 = PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)(&V_0), /*hidden argument*/NULL);
			if ((!(((float)L_16) < ((float)L_17))))
			{
				goto IL_007a;
			}
		}

IL_0078:
		{
			// closest = h;
			PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_18 = V_2;
			V_0 = L_18;
		}

IL_007a:
		{
			// foreach (var h in s_HitsBuffer)
			bool L_19;
			L_19 = Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24((Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *)(&V_1), /*hidden argument*/Enumerator_MoveNext_mB3CD742E585DEA3D70D289F103D4D103FD5F1E24_RuntimeMethod_var);
			if (L_19)
			{
				goto IL_0060;
			}
		}

IL_0083:
		{
			IL2CPP_LEAVE(0x93, FINALLY_0085);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0085;
	}

FINALLY_0085:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA((Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC *)(&V_1), /*hidden argument*/Enumerator_Dispose_m6AC56307F4973D58AB41A73EBEA155F25888B2AA_RuntimeMethod_var);
		IL2CPP_END_FINALLY(133)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(133)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x93, IL_0093)
	}

IL_0093:
	{
		// hit = closest;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * L_20 = ___hit4;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_21 = V_0;
		*(PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_20 = L_21;
		Il2CppCodeGenWriteBarrier((void**)&(((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_20)->___U3CtargetU3Ek__BackingField_1), (void*)NULL);
		// return hit.valid;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * L_22 = ___hit4;
		bool L_23;
		L_23 = PickingHit_get_valid_m0309BF370D7469ED618ACDBB3BE97FD0F4D76D2D((PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_22, /*hidden argument*/NULL);
		return L_23;
	}
}
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHovered(System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,Unity.MARS.MARSHandles.Picking.PickingHit&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHovered_m260AA61C97C7B579C025071E0A0505EECAB978B5 (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * ___hit4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHovered_m260AA61C97C7B579C025071E0A0505EECAB978B5_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHovered_m260AA61C97C7B579C025071E0A0505EECAB978B5_RuntimeMethod_var)));
	}

IL_0022:
	{
		// GetPickingTargets(targets, s_TargetsBuffer);
		RuntimeObject* L_5 = ___targets0;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_6 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		ScreenPickingUtility_GetPickingTargets_m6344750F8A2D21BF243FA512D8ECF2AEB2C6E6FC(L_5, L_6, /*hidden argument*/NULL);
		// return GetHovered(s_TargetsBuffer, screenPosition, camera, maxDistance, out hit);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_7 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_9 = ___camera2;
		float L_10 = ___maxDistance3;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * L_11 = ___hit4;
		bool L_12;
		L_12 = ScreenPickingUtility_GetHovered_mB82A2D4C872084481031F96A1600CEB889BA2D46(L_7, L_8, L_9, L_10, (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 *)L_11, /*hidden argument*/NULL);
		return L_12;
	}
}
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * ___results4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_t243346DE4DC0DF3201B49FF3A837D684C549B76B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t0FBD6E83DD1841DFB0D8CE23A45ED0B6E9AF771A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	RuntimeObject* V_2 = NULL;
	PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  V_3;
	memset((&V_3), 0, sizeof(V_3));
	float V_4 = 0.0f;
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A_RuntimeMethod_var)));
	}

IL_0022:
	{
		// if (results == null)
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_5 = ___results4;
		if (L_5)
		{
			goto IL_0031;
		}
	}
	{
		// throw new ArgumentNullException(nameof(results));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_6 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9AB16B3999460DDC981865934D979087351A14F2)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A_RuntimeMethod_var)));
	}

IL_0031:
	{
		// results.Clear();
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_7 = ___results4;
		NullCheck(L_7);
		List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910(L_7, /*hidden argument*/List_1_Clear_m466BC4A5D3640099685E7273E20D627E26643910_RuntimeMethod_var);
		// for (int i = 0, count = targets.Count; i < count; ++i)
		V_0 = 0;
		// for (int i = 0, count = targets.Count; i < count; ++i)
		RuntimeObject* L_8 = ___targets0;
		NullCheck(L_8);
		int32_t L_9;
		L_9 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>::get_Count() */, IReadOnlyCollection_1_t243346DE4DC0DF3201B49FF3A837D684C549B76B_il2cpp_TypeInfo_var, L_8);
		V_1 = L_9;
		goto IL_008d;
	}

IL_0043:
	{
		// var target = targets[i];
		RuntimeObject* L_10 = ___targets0;
		int32_t L_11 = V_0;
		NullCheck(L_10);
		RuntimeObject* L_12;
		L_12 = InterfaceFuncInvoker1< RuntimeObject*, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>::get_Item(System.Int32) */, IReadOnlyList_1_t0FBD6E83DD1841DFB0D8CE23A45ED0B6E9AF771A_il2cpp_TypeInfo_var, L_10, L_11);
		V_2 = L_12;
		// if (target == null)
		RuntimeObject* L_13 = V_2;
		if (!L_13)
		{
			goto IL_0089;
		}
	}
	{
		// var pickingData = target.GetPickingData();
		RuntimeObject* L_14 = V_2;
		NullCheck(L_14);
		PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  L_15;
		L_15 = InterfaceFuncInvoker0< PickingData_t0262B9D068773D4DFA4052DBA84204378F146207  >::Invoke(0 /* Unity.MARS.MARSHandles.Picking.PickingData Unity.MARS.MARSHandles.Picking.IPickingTarget::GetPickingData() */, IPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_il2cpp_TypeInfo_var, L_14);
		V_3 = L_15;
		// if (!pickingData.valid)
		bool L_16;
		L_16 = PickingData_get_valid_m9E4DB569FB050062AA9F32683EE54CF90290007D((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)(&V_3), /*hidden argument*/NULL);
		if (!L_16)
		{
			goto IL_0089;
		}
	}
	{
		// var distance = ScreenDistanceUtility.DistanceToMesh(
		//     screenPosition,
		//     camera,
		//     pickingData.matrix,
		//     pickingData.mesh);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_17 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_18 = ___camera2;
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_19;
		L_19 = PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40_inline((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)(&V_3), /*hidden argument*/NULL);
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_20;
		L_20 = PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_inline((PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 *)(&V_3), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(ScreenDistanceUtility_t6E0C4B7788A9CF32BEC597130FC0750D1AAB4EAB_il2cpp_TypeInfo_var);
		float L_21;
		L_21 = ScreenDistanceUtility_DistanceToMesh_m96784DFBA4B4E7233992C45D5B1206C74DDC4F49(L_17, L_18, L_19, L_20, /*hidden argument*/NULL);
		V_4 = L_21;
		// if (distance <= maxDistance)
		float L_22 = V_4;
		float L_23 = ___maxDistance3;
		if ((!(((float)L_22) <= ((float)L_23))))
		{
			goto IL_0089;
		}
	}
	{
		// results.Add(new PickingHit(target, distance));
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_24 = ___results4;
		RuntimeObject* L_25 = V_2;
		float L_26 = V_4;
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_27;
		memset((&L_27), 0, sizeof(L_27));
		PickingHit__ctor_mDDB1566B1639ABE8E9383F4B8E1A8FADF2F501CC((&L_27), L_25, L_26, /*hidden argument*/NULL);
		NullCheck(L_24);
		List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85(L_24, L_27, /*hidden argument*/List_1_Add_m58CF56B86B9FEF6F9B42210607AFDCDA7D555F85_RuntimeMethod_var);
	}

IL_0089:
	{
		// for (int i = 0, count = targets.Count; i < count; ++i)
		int32_t L_28 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_28, (int32_t)1));
	}

IL_008d:
	{
		// for (int i = 0, count = targets.Count; i < count; ++i)
		int32_t L_29 = V_0;
		int32_t L_30 = V_1;
		if ((((int32_t)L_29) < ((int32_t)L_30)))
		{
			goto IL_0043;
		}
	}
	{
		// return results.Count > 0;
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_31 = ___results4;
		NullCheck(L_31);
		int32_t L_32;
		L_32 = List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_inline(L_31, /*hidden argument*/List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_RuntimeMethod_var);
		return (bool)((((int32_t)L_32) > ((int32_t)0))? 1 : 0);
	}
}
// System.Boolean Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>,UnityEngine.Vector2,UnityEngine.Camera,System.Single,System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.PickingHit>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ScreenPickingUtility_GetHoveredAll_mE836AF54ADB43B26F4CDCB6969E5E9B68941B6A4 (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * ___results4, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mE836AF54ADB43B26F4CDCB6969E5E9B68941B6A4_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mE836AF54ADB43B26F4CDCB6969E5E9B68941B6A4_RuntimeMethod_var)));
	}

IL_0022:
	{
		// if (results == null)
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_5 = ___results4;
		if (L_5)
		{
			goto IL_0031;
		}
	}
	{
		// throw new ArgumentNullException(nameof(results));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_6 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9AB16B3999460DDC981865934D979087351A14F2)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mE836AF54ADB43B26F4CDCB6969E5E9B68941B6A4_RuntimeMethod_var)));
	}

IL_0031:
	{
		// GetPickingTargets(targets, s_TargetsBuffer);
		RuntimeObject* L_7 = ___targets0;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_8 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		ScreenPickingUtility_GetPickingTargets_m6344750F8A2D21BF243FA512D8ECF2AEB2C6E6FC(L_7, L_8, /*hidden argument*/NULL);
		// return GetHoveredAll(s_TargetsBuffer, screenPosition, camera, maxDistance, results);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_9 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_10 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_11 = ___camera2;
		float L_12 = ___maxDistance3;
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_13 = ___results4;
		bool L_14;
		L_14 = ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A(L_9, L_10, L_11, L_12, L_13, /*hidden argument*/NULL);
		return L_14;
	}
}
// Unity.MARS.MARSHandles.Picking.PickingHit[] Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>,UnityEngine.Vector2,UnityEngine.Camera,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F_RuntimeMethod_var)));
	}

IL_0022:
	{
		// GetHoveredAll(targets, screenPosition, camera, maxDistance, s_HitsBuffer);
		RuntimeObject* L_5 = ___targets0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_7 = ___camera2;
		float L_8 = ___maxDistance3;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_9 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_HitsBuffer_0();
		bool L_10;
		L_10 = ScreenPickingUtility_GetHoveredAll_m604EE9620FE167DFF18DF7555F51543168A9190A(L_5, L_6, L_7, L_8, L_9, /*hidden argument*/NULL);
		// return s_HitsBuffer.ToArray();
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_11 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_HitsBuffer_0();
		NullCheck(L_11);
		PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* L_12;
		L_12 = List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B(L_11, /*hidden argument*/List_1_ToArray_mBB4AFF8AECD9CEB3D17D274615C25F2FD0FA260B_RuntimeMethod_var);
		return L_12;
	}
}
// Unity.MARS.MARSHandles.Picking.PickingHit[] Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetHoveredAll(System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>,UnityEngine.Vector2,UnityEngine.Camera,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* ScreenPickingUtility_GetHoveredAll_mF5A08D13C5DDDC8D7A7461A7CAD0D363ED6B89D3 (RuntimeObject* ___targets0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___screenPosition1, Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * ___camera2, float ___maxDistance3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (targets == null)
		RuntimeObject* L_0 = ___targets0;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException(nameof(targets));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_1 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral563E1460168EA54A80919DA3A2C91EDC081445AA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mF5A08D13C5DDDC8D7A7461A7CAD0D363ED6B89D3_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (camera == null)
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_2 = ___camera2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_2, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ArgumentNullException(nameof(camera));
		ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB * L_4 = (ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_tFB5C4621957BC53A7D1B4FDD5C38B4D6E15DB8FB_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m81AB157B93BFE2FBFDB08B88F84B444293042F97(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA7F00519435FC33A7E48F0FCF6CB6D9B257C0DAA)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ScreenPickingUtility_GetHoveredAll_mF5A08D13C5DDDC8D7A7461A7CAD0D363ED6B89D3_RuntimeMethod_var)));
	}

IL_0022:
	{
		// GetPickingTargets(targets, s_TargetsBuffer);
		RuntimeObject* L_5 = ___targets0;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_6 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		ScreenPickingUtility_GetPickingTargets_m6344750F8A2D21BF243FA512D8ECF2AEB2C6E6FC(L_5, L_6, /*hidden argument*/NULL);
		// return GetHoveredAll(s_TargetsBuffer, screenPosition, camera, maxDistance);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_7 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_TargetsBuffer_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8 = ___screenPosition1;
		Camera_tC44E094BAB53AFC8A014C6F9CFCE11F4FC38006C * L_9 = ___camera2;
		float L_10 = ___maxDistance3;
		PickingHitU5BU5D_t700FCD9E42F7E7EB58A61960170C40F5BEB2E341* L_11;
		L_11 = ScreenPickingUtility_GetHoveredAll_mB647CA20AE8C58D9FB19FF45C158019499C4094F(L_7, L_8, L_9, L_10, /*hidden argument*/NULL);
		return L_11;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::GetPickingTargets(System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>,System.Collections.Generic.List`1<Unity.MARS.MARSHandles.Picking.IPickingTarget>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenPickingUtility_GetPickingTargets_m6344750F8A2D21BF243FA512D8ECF2AEB2C6E6FC (RuntimeObject* ___gameObjects0, List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * ___results1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponentsInChildren_TisIPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_m7BB524C7FE414F16DBEEA4696F0C6415A6116D3D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyCollection_1_tBC27CAF7F2490DC08F9AA8985A90C3A910C5FE69_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IReadOnlyList_1_t7453370C5361E060CD390551EC47318B25EDE91A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_AddRange_m9640467223CE5B5ABBCB62A755853AEA413B6C92_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m8428F99BD4D11C58BEC2ECDE6671CCB859ED680B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * V_2 = NULL;
	{
		// results.Clear();
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_0 = ___results1;
		NullCheck(L_0);
		List_1_Clear_m8428F99BD4D11C58BEC2ECDE6671CCB859ED680B(L_0, /*hidden argument*/List_1_Clear_m8428F99BD4D11C58BEC2ECDE6671CCB859ED680B_RuntimeMethod_var);
		// for (int i = 0, count = gameObjects.Count; i < count; ++i)
		V_0 = 0;
		// for (int i = 0, count = gameObjects.Count; i < count; ++i)
		RuntimeObject* L_1 = ___gameObjects0;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.IReadOnlyCollection`1<UnityEngine.GameObject>::get_Count() */, IReadOnlyCollection_1_tBC27CAF7F2490DC08F9AA8985A90C3A910C5FE69_il2cpp_TypeInfo_var, L_1);
		V_1 = L_2;
		goto IL_0045;
	}

IL_0011:
	{
		// var gameObject = gameObjects[i];
		RuntimeObject* L_3 = ___gameObjects0;
		int32_t L_4 = V_0;
		NullCheck(L_3);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_5;
		L_5 = InterfaceFuncInvoker1< GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 *, int32_t >::Invoke(0 /* !0 System.Collections.Generic.IReadOnlyList`1<UnityEngine.GameObject>::get_Item(System.Int32) */, IReadOnlyList_1_t7453370C5361E060CD390551EC47318B25EDE91A_il2cpp_TypeInfo_var, L_3, L_4);
		V_2 = L_5;
		// if (gameObject == null || !gameObject.activeInHierarchy)
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_6 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tF2F3778131EFF286AF62B7B013A170F95A91571A_il2cpp_TypeInfo_var);
		bool L_7;
		L_7 = Object_op_Equality_mEE9EC7EB5C7DC3E95B94AB904E1986FC4D566D54(L_6, (Object_tF2F3778131EFF286AF62B7B013A170F95A91571A *)NULL, /*hidden argument*/NULL);
		if (L_7)
		{
			goto IL_0041;
		}
	}
	{
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_8 = V_2;
		NullCheck(L_8);
		bool L_9;
		L_9 = GameObject_get_activeInHierarchy_mA3990AC5F61BB35283188E925C2BE7F7BF67734B(L_8, /*hidden argument*/NULL);
		if (!L_9)
		{
			goto IL_0041;
		}
	}
	{
		// gameObject.GetComponentsInChildren(false, s_ComponentBuffer);
		GameObject_tC000A2E1A7CF1E10FD7BA08863287C072207C319 * L_10 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_11 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_ComponentBuffer_2();
		NullCheck(L_10);
		GameObject_GetComponentsInChildren_TisIPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_m7BB524C7FE414F16DBEEA4696F0C6415A6116D3D(L_10, (bool)0, L_11, /*hidden argument*/GameObject_GetComponentsInChildren_TisIPickingTarget_tD6638CE03EB69631198E235696883DDE8FB77ABB_m7BB524C7FE414F16DBEEA4696F0C6415A6116D3D_RuntimeMethod_var);
		// results.AddRange(s_ComponentBuffer);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_12 = ___results1;
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_13 = ((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->get_s_ComponentBuffer_2();
		NullCheck(L_12);
		List_1_AddRange_m9640467223CE5B5ABBCB62A755853AEA413B6C92(L_12, L_13, /*hidden argument*/List_1_AddRange_m9640467223CE5B5ABBCB62A755853AEA413B6C92_RuntimeMethod_var);
	}

IL_0041:
	{
		// for (int i = 0, count = gameObjects.Count; i < count; ++i)
		int32_t L_14 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)1));
	}

IL_0045:
	{
		// for (int i = 0, count = gameObjects.Count; i < count; ++i)
		int32_t L_15 = V_0;
		int32_t L_16 = V_1;
		if ((((int32_t)L_15) < ((int32_t)L_16)))
		{
			goto IL_0011;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenPickingUtility::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenPickingUtility__cctor_m18AA01F6561E84F75FCC8B1AFAF8E49B509EFA31 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly List<PickingHit> s_HitsBuffer = new List<PickingHit>(64);
		List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * L_0 = (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 *)il2cpp_codegen_object_new(List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124_il2cpp_TypeInfo_var);
		List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF(L_0, ((int32_t)64), /*hidden argument*/List_1__ctor_mEE92ECEA32FE053C44B0C986C979A86F7EF7FDEF_RuntimeMethod_var);
		((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->set_s_HitsBuffer_0(L_0);
		// static readonly List<IPickingTarget> s_TargetsBuffer = new List<IPickingTarget>(64);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_1 = (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *)il2cpp_codegen_object_new(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_il2cpp_TypeInfo_var);
		List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B(L_1, ((int32_t)64), /*hidden argument*/List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B_RuntimeMethod_var);
		((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->set_s_TargetsBuffer_1(L_1);
		// static readonly List<IPickingTarget> s_ComponentBuffer = new List<IPickingTarget>(64);
		List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 * L_2 = (List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856 *)il2cpp_codegen_object_new(List_1_t07E271FAB036F69C1EE3084AEEBBB6CEA069C856_il2cpp_TypeInfo_var);
		List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B(L_2, ((int32_t)64), /*hidden argument*/List_1__ctor_mD26442BF340E4E922F0B739886FAE7FF71B91A0B_RuntimeMethod_var);
		((ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_StaticFields*)il2cpp_codegen_static_fields_for(ScreenPickingUtility_t55072984E22B3DD743358EFE4B7B01E60F39311C_il2cpp_TypeInfo_var))->set_s_ComponentBuffer_2(L_2);
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
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_center()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 center { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CcenterU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  _returnValue;
	_returnValue = Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_center(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 center { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CcenterU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 size { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CsizeU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  _returnValue;
	_returnValue = Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_size(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 size { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CsizeU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A_inline(_thisAdjusted, ___value0, method);
}
// UnityEngine.Vector2 Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_extents()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_extents_m3C6A8F6FAABDC4E2B35D3ED771FE4DDF2E443355 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 extents { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CextentsU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_extents_m3C6A8F6FAABDC4E2B35D3ED771FE4DDF2E443355_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  _returnValue;
	_returnValue = Bounds2D_get_extents_m3C6A8F6FAABDC4E2B35D3ED771FE4DDF2E443355_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_extents(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 extents { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CextentsU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_xMin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float xMin { get; private set; }
		float L_0 = __this->get_U3CxMinU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	float _returnValue;
	_returnValue = Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_xMin(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float xMin { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CxMinU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_xMax()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float xMax { get; private set; }
		float L_0 = __this->get_U3CxMaxU3Ek__BackingField_4();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	float _returnValue;
	_returnValue = Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_xMax(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float xMax { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CxMaxU3Ek__BackingField_4(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_yMin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float yMin { get; private set; }
		float L_0 = __this->get_U3CyMinU3Ek__BackingField_5();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	float _returnValue;
	_returnValue = Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_yMin(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float yMin { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CyMinU3Ek__BackingField_5(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline(_thisAdjusted, ___value0, method);
}
// System.Single Unity.MARS.MARSHandles.MathUtility/Bounds2D::get_yMax()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float yMax { get; private set; }
		float L_0 = __this->get_U3CyMaxU3Ek__BackingField_6();
		return L_0;
	}
}
IL2CPP_EXTERN_C  float Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	float _returnValue;
	_returnValue = Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::set_yMax(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float yMax { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CyMaxU3Ek__BackingField_6(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_AdjustorThunk (RuntimeObject * __this, float ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.MathUtility/Bounds2D::.ctor(UnityEngine.Vector2[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Bounds2D__ctor_mC43E45A8EEBCBCCE6A0E0AF20209E7A13EC1A175 (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ___points0, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	int32_t V_4 = 0;
	float V_5 = 0.0f;
	float V_6 = 0.0f;
	{
		// public Bounds2D(Vector2[] points) : this()
		il2cpp_codegen_initobj(__this, sizeof(Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F ));
		// int count = points.Length;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_0 = ___points0;
		NullCheck(L_0);
		V_0 = ((int32_t)((int32_t)(((RuntimeArray*)L_0)->max_length)));
		// if (count == 0)
		int32_t L_1 = V_0;
		if (L_1)
		{
			goto IL_0039;
		}
	}
	{
		// xMin = xMax = yMin = yMax = 0f;
		float L_2 = (0.0f);
		V_3 = L_2;
		Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_2, /*hidden argument*/NULL);
		float L_3 = V_3;
		float L_4 = L_3;
		V_2 = L_4;
		Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_4, /*hidden argument*/NULL);
		float L_5 = V_2;
		float L_6 = L_5;
		V_1 = L_6;
		Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_6, /*hidden argument*/NULL);
		float L_7 = V_1;
		Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_7, /*hidden argument*/NULL);
		// }
		goto IL_00e5;
	}

IL_0039:
	{
		// xMin = xMax = points[0].x;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_8 = ___points0;
		NullCheck(L_8);
		float L_9 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(0)))->get_x_0();
		float L_10 = L_9;
		V_1 = L_10;
		Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_10, /*hidden argument*/NULL);
		float L_11 = V_1;
		Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_11, /*hidden argument*/NULL);
		// yMin = yMax = points[0].y;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_12 = ___points0;
		NullCheck(L_12);
		float L_13 = ((L_12)->GetAddressAt(static_cast<il2cpp_array_size_t>(0)))->get_y_1();
		float L_14 = L_13;
		V_1 = L_14;
		Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_14, /*hidden argument*/NULL);
		float L_15 = V_1;
		Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_15, /*hidden argument*/NULL);
		// for (int i = 1; i < count; ++i)
		V_4 = 1;
		goto IL_00e0;
	}

IL_0074:
	{
		// float x = points[i].x;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_16 = ___points0;
		int32_t L_17 = V_4;
		NullCheck(L_16);
		float L_18 = ((L_16)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_17)))->get_x_0();
		V_5 = L_18;
		// float y = points[i].y;
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_19 = ___points0;
		int32_t L_20 = V_4;
		NullCheck(L_19);
		float L_21 = ((L_19)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_20)))->get_y_1();
		V_6 = L_21;
		// if (x < xMin) xMin = x;
		float L_22 = V_5;
		float L_23;
		L_23 = Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_22) < ((float)L_23))))
		{
			goto IL_00a4;
		}
	}
	{
		// if (x < xMin) xMin = x;
		float L_24 = V_5;
		Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_24, /*hidden argument*/NULL);
	}

IL_00a4:
	{
		// if (x > xMax) xMax = x;
		float L_25 = V_5;
		float L_26;
		L_26 = Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_25) > ((float)L_26))))
		{
			goto IL_00b6;
		}
	}
	{
		// if (x > xMax) xMax = x;
		float L_27 = V_5;
		Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_27, /*hidden argument*/NULL);
	}

IL_00b6:
	{
		// if (y < yMin) yMin = y;
		float L_28 = V_6;
		float L_29;
		L_29 = Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_28) < ((float)L_29))))
		{
			goto IL_00c8;
		}
	}
	{
		// if (y < yMin) yMin = y;
		float L_30 = V_6;
		Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_30, /*hidden argument*/NULL);
	}

IL_00c8:
	{
		// if (y > yMax) yMax = y;
		float L_31 = V_6;
		float L_32;
		L_32 = Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_31) > ((float)L_32))))
		{
			goto IL_00da;
		}
	}
	{
		// if (y > yMax) yMax = y;
		float L_33 = V_6;
		Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_33, /*hidden argument*/NULL);
	}

IL_00da:
	{
		// for (int i = 1; i < count; ++i)
		int32_t L_34 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_34, (int32_t)1));
	}

IL_00e0:
	{
		// for (int i = 1; i < count; ++i)
		int32_t L_35 = V_4;
		int32_t L_36 = V_0;
		if ((((int32_t)L_35) < ((int32_t)L_36)))
		{
			goto IL_0074;
		}
	}

IL_00e5:
	{
		// center = new Vector2((xMin + xMax) * 0.5f, (yMin + yMax) * 0.5f);
		float L_37;
		L_37 = Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_38;
		L_38 = Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_39;
		L_39 = Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_40;
		L_40 = Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_41;
		memset((&L_41), 0, sizeof(L_41));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_41), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_add((float)L_37, (float)L_38)), (float)(0.5f))), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_add((float)L_39, (float)L_40)), (float)(0.5f))), /*hidden argument*/NULL);
		Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_41, /*hidden argument*/NULL);
		// size = new Vector2(xMax - xMin, yMax - yMin);
		float L_42;
		L_42 = Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_43;
		L_43 = Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_44;
		L_44 = Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_45;
		L_45 = Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_46;
		memset((&L_46), 0, sizeof(L_46));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_46), ((float)il2cpp_codegen_subtract((float)L_42, (float)L_43)), ((float)il2cpp_codegen_subtract((float)L_44, (float)L_45)), /*hidden argument*/NULL);
		Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_46, /*hidden argument*/NULL);
		// extents = new Vector2(size.x * 0.5f, size.y * 0.5f);
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_47;
		L_47 = Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_48 = L_47.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_49;
		L_49 = Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		float L_50 = L_49.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_51;
		memset((&L_51), 0, sizeof(L_51));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_51), ((float)il2cpp_codegen_multiply((float)L_48, (float)(0.5f))), ((float)il2cpp_codegen_multiply((float)L_50, (float)(0.5f))), /*hidden argument*/NULL);
		Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, L_51, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void Bounds2D__ctor_mC43E45A8EEBCBCCE6A0E0AF20209E7A13EC1A175_AdjustorThunk (RuntimeObject * __this, Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* ___points0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	Bounds2D__ctor_mC43E45A8EEBCBCCE6A0E0AF20209E7A13EC1A175(_thisAdjusted, ___points0, method);
}
// System.Boolean Unity.MARS.MARSHandles.MathUtility/Bounds2D::Contains(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Bounds2D_Contains_mED66DDD213D76D4DD9CF1C97F1FA6EA149ADB1BD (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, const RuntimeMethod* method)
{
	{
		// return point.x > xMin
		//     && point.x < xMax
		//     && point.y > yMin
		//     && point.y < yMax;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___point0;
		float L_1 = L_0.get_x_0();
		float L_2;
		L_2 = Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_1) > ((float)L_2))))
		{
			goto IL_0039;
		}
	}
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = ___point0;
		float L_4 = L_3.get_x_0();
		float L_5;
		L_5 = Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_4) < ((float)L_5))))
		{
			goto IL_0039;
		}
	}
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___point0;
		float L_7 = L_6.get_y_1();
		float L_8;
		L_8 = Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		if ((!(((float)L_7) > ((float)L_8))))
		{
			goto IL_0039;
		}
	}
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_9 = ___point0;
		float L_10 = L_9.get_y_1();
		float L_11;
		L_11 = Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline((Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *)__this, /*hidden argument*/NULL);
		return (bool)((((float)L_10) < ((float)L_11))? 1 : 0);
	}

IL_0039:
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C  bool Bounds2D_Contains_mED66DDD213D76D4DD9CF1C97F1FA6EA149ADB1BD_AdjustorThunk (RuntimeObject * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___point0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * _thisAdjusted = reinterpret_cast<Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F *>(__this + _offset);
	bool _returnValue;
	_returnValue = Bounds2D_Contains_mED66DDD213D76D4DD9CF1C97F1FA6EA149ADB1BD(_thisAdjusted, ___point0, method);
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
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexA()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexA { get; private set; }
		int32_t L_0 = __this->get_U3CindexAU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexA(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexA { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexAU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488_inline(_thisAdjusted, ___value0, method);
}
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexB()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexB { get; private set; }
		int32_t L_0 = __this->get_U3CindexBU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexB(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexB { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexBU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50_inline(_thisAdjusted, ___value0, method);
}
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexC()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexC { get; private set; }
		int32_t L_0 = __this->get_U3CindexCU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexC(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexC { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexCU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836_inline(_thisAdjusted, ___value0, method);
}
// System.Int32 Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::get_indexD()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexD { get; private set; }
		int32_t L_0 = __this->get_U3CindexDU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::set_indexD(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156 (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexD { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexDU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_EXTERN_C  void Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156_AdjustorThunk (RuntimeObject * __this, int32_t ___value0, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156_inline(_thisAdjusted, ___value0, method);
}
// System.Void Unity.MARS.MARSHandles.Picking.ScreenDistanceUtility/Quad::.ctor(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Quad__ctor_mD1F232F6D0A29C39F845E405F73F9428520139FB (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___a0, int32_t ___b1, int32_t ___c2, int32_t ___d3, const RuntimeMethod* method)
{
	{
		// public Quad(int a, int b, int c, int d) : this()
		il2cpp_codegen_initobj(__this, sizeof(Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 ));
		// this.indexA = a;
		int32_t L_0 = ___a0;
		Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)__this, L_0, /*hidden argument*/NULL);
		// this.indexB = b;
		int32_t L_1 = ___b1;
		Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)__this, L_1, /*hidden argument*/NULL);
		// this.indexC = c;
		int32_t L_2 = ___c2;
		Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)__this, L_2, /*hidden argument*/NULL);
		// this.indexD = d;
		int32_t L_3 = ___d3;
		Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156_inline((Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *)__this, L_3, /*hidden argument*/NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void Quad__ctor_mD1F232F6D0A29C39F845E405F73F9428520139FB_AdjustorThunk (RuntimeObject * __this, int32_t ___a0, int32_t ___b1, int32_t ___c2, int32_t ___d3, const RuntimeMethod* method)
{
	int32_t _offset = 1;
	Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * _thisAdjusted = reinterpret_cast<Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 *>(__this + _offset);
	Quad__ctor_mD1F232F6D0A29C39F845E405F73F9428520139FB(_thisAdjusted, ___a0, ___b1, ___c2, ___d3, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
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
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Magnitude_mFBD4702FB2F35452191EC918B9B09766A5761854_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___vector0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___vector0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___vector0;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___vector0;
		float L_5 = L_4.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___vector0;
		float L_7 = L_6.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_8 = ___vector0;
		float L_9 = L_8.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_10 = ___vector0;
		float L_11 = L_10.get_z_4();
		IL2CPP_RUNTIME_CLASS_INIT(Math_tA269614262430118C9FC5C4D9EF4F61C812568F0_il2cpp_TypeInfo_var);
		double L_12;
		L_12 = sqrt(((double)((double)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)L_1, (float)L_3)), (float)((float)il2cpp_codegen_multiply((float)L_5, (float)L_7)))), (float)((float)il2cpp_codegen_multiply((float)L_9, (float)L_11)))))));
		V_0 = ((float)((float)L_12));
		goto IL_0034;
	}

IL_0034:
	{
		float L_13 = V_0;
		return L_13;
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
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Subtraction_m6E536A8C72FEAA37FF8D5E26E11D6E71EB59599A_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b1, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___a0;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___b1;
		float L_3 = L_2.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___a0;
		float L_5 = L_4.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___b1;
		float L_7 = L_6.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8;
		memset((&L_8), 0, sizeof(L_8));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_8), ((float)il2cpp_codegen_subtract((float)L_1, (float)L_3)), ((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)), /*hidden argument*/NULL);
		V_0 = L_8;
		goto IL_0023;
	}

IL_0023:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_9 = V_0;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_Perpendicular_mAD7805BEB4D362E2E08DA6C0FF48CA55F8B7EE71_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___inDirection0, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___inDirection0;
		float L_1 = L_0.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___inDirection0;
		float L_3 = L_2.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_4), ((-L_1)), L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_0016;
	}

IL_0016:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector2_Dot_mB2DFFDDA2881BA755F0B75CB530A39E8EBE70B48_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___lhs0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___rhs1, const RuntimeMethod* method)
{
	float V_0 = 0.0f;
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___lhs0;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___rhs1;
		float L_3 = L_2.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___lhs0;
		float L_5 = L_4.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___rhs1;
		float L_7 = L_6.get_y_1();
		V_0 = ((float)il2cpp_codegen_add((float)((float)il2cpp_codegen_multiply((float)L_1, (float)L_3)), (float)((float)il2cpp_codegen_multiply((float)L_5, (float)L_7))));
		goto IL_001f;
	}

IL_001f:
	{
		float L_8 = V_0;
		return L_8;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_center_mE9E1B65B8B70800DE9A6B712CBF30FE83FEB7069_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 center { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CcenterU3Ek__BackingField_0();
		return L_0;
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
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Implicit_mE407CAF7446E342E059B00AA9EDB301AEC5B7B1A_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___v0, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_0 = ___v0;
		float L_1 = L_0.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___v0;
		float L_3 = L_2.get_y_3();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_4), L_1, L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_0015;
	}

IL_0015:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_size_m68C1466676EEC34FA8C713A77F5F5F6D7C3E3C53_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 size { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CsizeU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Multiply_mC7A7802352867555020A90205EBABA56EE5E36CB_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, float ___d1, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___a0;
		float L_1 = L_0.get_x_0();
		float L_2 = ___d1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = ___a0;
		float L_4 = L_3.get_y_1();
		float L_5 = ___d1;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_6), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_2)), ((float)il2cpp_codegen_multiply((float)L_4, (float)L_5)), /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_0019;
	}

IL_0019:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Addition_m5EACC2AEA80FEE29F380397CF1F4B11D04BE71CC_inline (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___b1, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___a0;
		float L_1 = L_0.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_2 = ___b1;
		float L_3 = L_2.get_x_0();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4 = ___a0;
		float L_5 = L_4.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6 = ___b1;
		float L_7 = L_6.get_y_1();
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_8;
		memset((&L_8), 0, sizeof(L_8));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_8), ((float)il2cpp_codegen_add((float)L_1, (float)L_3)), ((float)il2cpp_codegen_add((float)L_5, (float)L_7)), /*hidden argument*/NULL);
		V_0 = L_8;
		goto IL_0023;
	}

IL_0023:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_9 = V_0;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Vector2_op_Multiply_m841D5292C48DAD9746A2F4EED9CE7A76CDB652EA_inline (float ___d0, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___a1, const RuntimeMethod* method)
{
	Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___a1;
		float L_1 = L_0.get_x_0();
		float L_2 = ___d0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_3 = ___a1;
		float L_4 = L_3.get_y_1();
		float L_5 = ___d0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector2__ctor_m9F1F2D5EB5D1FF7091BB527AC8A72CBB309D115E_inline((&L_6), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_2)), ((float)il2cpp_codegen_multiply((float)L_4, (float)L_5)), /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_0019;
	}

IL_0019:
	{
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  PickingData_get_matrix_mC04156A2AB47FC8C8164FE4918BEC0B4CCABBD40_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method)
{
	{
		// public Matrix4x4 matrix { get; private set; }
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_0 = __this->get_U3CmatrixU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingData_set_matrix_mCCA85981A8C62A77CF055A8110CC8894647867C1_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  ___value0, const RuntimeMethod* method)
{
	{
		// public Matrix4x4 matrix { get; private set; }
		Matrix4x4_tDE7FF4F2E2EA284F6EFE00D627789D0E5B8B4461  L_0 = ___value0;
		__this->set_U3CmatrixU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * PickingData_get_mesh_m239BC27A18B049B0777868E5F11DD88F346D2CEF_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, const RuntimeMethod* method)
{
	{
		// public Mesh mesh { get; private set; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = __this->get_U3CmeshU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingData_set_mesh_mDF256C164F276409DD29E0718F3736D1041E87B3_inline (PickingData_t0262B9D068773D4DFA4052DBA84204378F146207 * __this, Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * ___value0, const RuntimeMethod* method)
{
	{
		// public Mesh mesh { get; private set; }
		Mesh_t2F5992DBA650D5862B43D3823ACD997132A57DA6 * L_0 = ___value0;
		__this->set_U3CmeshU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PickingHit_get_distance_mCB2C02CFB36B64E5FB6F4A1B9A00CF48FBCCA049_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method)
{
	{
		// public float distance { get; private set; }
		float L_0 = __this->get_U3CdistanceU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingHit_set_distance_mF13CF359165154E2DC4DF6D9EEE34C2756E4F083_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float distance { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CdistanceU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PickingHit_get_target_mA6F72B0678E807989F3F2E2E0B8F1F33BADFADD3_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, const RuntimeMethod* method)
{
	{
		// public IPickingTarget target { get; private set; }
		RuntimeObject* L_0 = __this->get_U3CtargetU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PickingHit_set_target_m13A35464DD81F6E7D4BF0D2A46167A54412125B4_inline (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 * __this, RuntimeObject* ___value0, const RuntimeMethod* method)
{
	{
		// public IPickingTarget target { get; private set; }
		RuntimeObject* L_0 = ___value0;
		__this->set_U3CtargetU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  Vector3_Lerp_m8E095584FFA10CF1D3EABCD04F4C83FB82EC5524_inline (Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___a0, Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  ___b1, float ___t2, const RuntimeMethod* method)
{
	Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___t2;
		float L_1;
		L_1 = Mathf_Clamp01_m2296D75F0F1292D5C8181C57007A1CA45F440C4C(L_0, /*hidden argument*/NULL);
		___t2 = L_1;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_2 = ___a0;
		float L_3 = L_2.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_4 = ___b1;
		float L_5 = L_4.get_x_2();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_6 = ___a0;
		float L_7 = L_6.get_x_2();
		float L_8 = ___t2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_9 = ___a0;
		float L_10 = L_9.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_11 = ___b1;
		float L_12 = L_11.get_y_3();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_13 = ___a0;
		float L_14 = L_13.get_y_3();
		float L_15 = ___t2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_16 = ___a0;
		float L_17 = L_16.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_18 = ___b1;
		float L_19 = L_18.get_z_4();
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_20 = ___a0;
		float L_21 = L_20.get_z_4();
		float L_22 = ___t2;
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_23;
		memset((&L_23), 0, sizeof(L_23));
		Vector3__ctor_m57495F692C6CE1CEF278CAD9A98221165D37E636_inline((&L_23), ((float)il2cpp_codegen_add((float)L_3, (float)((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)), (float)L_8)))), ((float)il2cpp_codegen_add((float)L_10, (float)((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)L_12, (float)L_14)), (float)L_15)))), ((float)il2cpp_codegen_add((float)L_17, (float)((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)L_19, (float)L_21)), (float)L_22)))), /*hidden argument*/NULL);
		V_0 = L_23;
		goto IL_0053;
	}

IL_0053:
	{
		Vector3_t65B972D6A585A0A5B63153CF1177A90D3C90D65E  L_24 = V_0;
		return L_24;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexA_m56DC47996710190D6AF8E0555A4768522C2A2E3E_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexA { get; private set; }
		int32_t L_0 = __this->get_U3CindexAU3Ek__BackingField_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexB_m4CC2911C9AF234D42FC1999E8A654B7F2F556AB6_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexB { get; private set; }
		int32_t L_0 = __this->get_U3CindexBU3Ek__BackingField_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexC_m8163235257CFAB47EBF2343BED5D3A031C03E034_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexC { get; private set; }
		int32_t L_0 = __this->get_U3CindexCU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Quad_get_indexD_mEFBF775E7460130B60214AC3F2701BD57EB7981C_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, const RuntimeMethod* method)
{
	{
		// public int indexD { get; private set; }
		int32_t L_0 = __this->get_U3CindexDU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_center_m84121DEA9BB93898B7B0694DA44CC9823497C5C3_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 center { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CcenterU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_size_m1BC6B5033B3F8A37EE2C844403D4F5CF2D38D45A_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 size { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CsizeU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  Bounds2D_get_extents_m3C6A8F6FAABDC4E2B35D3ED771FE4DDF2E443355_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public Vector2 extents { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = __this->get_U3CextentsU3Ek__BackingField_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_extents_m16404E3654B9129893F3030D870898A905050535_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  ___value0, const RuntimeMethod* method)
{
	{
		// public Vector2 extents { get; private set; }
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_0 = ___value0;
		__this->set_U3CextentsU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_xMin_mE3069B7BD4DAFC6C48717F1580F3C2AE7030BEF8_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float xMin { get; private set; }
		float L_0 = __this->get_U3CxMinU3Ek__BackingField_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_xMin_m3FFB082D576B7E57CD4158C4D07F511D6339D3E3_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float xMin { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CxMinU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_xMax_m593BC35A8E6DEFBA8C612EFCEC8DCC98266D4531_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float xMax { get; private set; }
		float L_0 = __this->get_U3CxMaxU3Ek__BackingField_4();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_xMax_m99B57455288A18EE19AD77BEEDEBE82FB169839A_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float xMax { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CxMaxU3Ek__BackingField_4(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_yMin_m083E45A199F970631D628FC396D64002896F19E7_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float yMin { get; private set; }
		float L_0 = __this->get_U3CyMinU3Ek__BackingField_5();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_yMin_mFB5733A6B0D45DAB208E7657DB855E5135CCA820_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float yMin { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CyMinU3Ek__BackingField_5(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Bounds2D_get_yMax_mB9AD9E88EEDE6EA9F3D2068273D78265AD034061_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, const RuntimeMethod* method)
{
	{
		// public float yMax { get; private set; }
		float L_0 = __this->get_U3CyMaxU3Ek__BackingField_6();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds2D_set_yMax_m467054E9167F386FE0229E4EC212CB72057B2F82_inline (Bounds2D_t5E0FF01EDD82418481E513F41D5FDBA37B917F5F * __this, float ___value0, const RuntimeMethod* method)
{
	{
		// public float yMax { get; private set; }
		float L_0 = ___value0;
		__this->set_U3CyMaxU3Ek__BackingField_6(L_0);
		return;
	}
}
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
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexA_mC82EA8B1E9B0581C1B6397A42840C1ED4C4DA488_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexA { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexAU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexB_mCBC164EAAF5F07A5264FC30E1DBAD594AC239A50_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexB { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexBU3Ek__BackingField_1(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexC_mCB87E7CED37C815A3191B04C68C89D93D73B9836_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexC { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexCU3Ek__BackingField_2(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quad_set_indexD_mE8795C8752902A62FA65C30E99EDA0378C966156_inline (Quad_t118BEC4122F5B19AF047470EE18C00E1FF451B85 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int indexD { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CindexDU3Ek__BackingField_3(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m7FA90926D9267868473EF90941F6BF794EC87FF2_gshared_inline (List_1_t260B41F956D673396C33A4CF94E8D6C4389EACB7 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = (int32_t)__this->get__size_2();
		return (int32_t)L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  List_1_get_Item_m3E1AEDD64868D9F6901AFBF0FA6B0A7A0001BA1E_gshared_inline (List_1_t400048180333F4A09A4A727C9A666AA5D2BB27A9 * __this, int32_t ___index0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___index0;
		int32_t L_1 = (int32_t)__this->get__size_2();
		if ((!(((uint32_t)L_0) >= ((uint32_t)L_1))))
		{
			goto IL_000e;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_m4841366ABC2B2AFA37C10900551D7E07522C0929(/*hidden argument*/NULL);
	}

IL_000e:
	{
		Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA* L_2 = (Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA*)__this->get__items_1();
		int32_t L_3 = ___index0;
		Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9  L_4;
		L_4 = IL2CPP_ARRAY_UNSAFE_LOAD((Vector2U5BU5D_tE0F58A2D6D8592B5EC37D9CDEF09103A02E5D7FA*)L_2, (int32_t)L_3);
		return (Vector2_tBB32F2736AEC229A7BFBCE18197EC0F6AC7EC2D9 )L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  Enumerator_get_Current_m21D61D4160B775CD57D15AB0E96556D8367F8D66_gshared_inline (Enumerator_t7D560C7ADABCFE5B133F76870A644436409D9DFC * __this, const RuntimeMethod* method)
{
	{
		PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83  L_0 = (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 )__this->get_current_3();
		return (PickingHit_tF98C75497561FB3C80A552E879A52BB800CC5D83 )L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mD22403A25205C1178CC2A0A7BB002025FDA8C07C_gshared_inline (List_1_tC77C318BEF1D067F8CAE3CB2E9F59BF240218124 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = (int32_t)__this->get__size_2();
		return (int32_t)L_0;
	}
}

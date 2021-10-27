#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


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

// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// Unity.XRTools.ModuleLoader.IFunctionalityProvider[]
struct IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77;
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;
// UnityEngine.RuntimePlatform[]
struct RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52;
// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71;
// Unity.XRTools.ModuleLoader.IUsesFunctionalityInjection
struct IUsesFunctionalityInjection_t737E9EB109E3988E8DD884FA6CDF685DB43D7A7A;
// Unity.XRTools.ModuleLoader.ImmortalModuleAttribute
struct ImmortalModuleAttribute_tC75E2349133BAE63E1442C0BBE506721B3596645;
// Unity.XRTools.ModuleLoader.ModuleBehaviorCallbackOrderAttribute
struct ModuleBehaviorCallbackOrderAttribute_t034A4607DE6A644528D3D8415E83830C89BE4322;
// Unity.XRTools.ModuleLoader.ModuleOrderAttribute
struct ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8;
// Unity.XRTools.ModuleLoader.ModuleUnloadOrderAttribute
struct ModuleUnloadOrderAttribute_t554B0B2E82BD85C2A5F8078B9D2FDF95FF4D5D9E;
// Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute
struct ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF;
// System.String
struct String_t;

IL2CPP_EXTERN_C RuntimeClass* IFunctionalitySubscriber_1_tEC23AA7F57AE59A02DA4AC883A61B8F90A43CDA7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IProvidesFunctionalityInjection_tF1338A16AB544539FA8E43DEA1D2018BD1C0AE7B_il2cpp_TypeInfo_var;

struct RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tBE1C61C2066A49B8E0B0687997F4E36B9EED18EC 
{
public:

public:
};


// System.Object


// System.Collections.Generic.List`1<Unity.XRTools.ModuleLoader.IFunctionalityProvider>
struct List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA, ____items_1)); }
	inline IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* get__items_1() const { return ____items_1; }
	inline IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA_StaticFields, ____emptyArray_5)); }
	inline IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* get__emptyArray_5() const { return ____emptyArray_5; }
	inline IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(IFunctionalityProviderU5BU5D_t1F4C48E2080B3042E58F94E9A4D651A337329F77* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____items_1)); }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* get__items_1() const { return ____items_1; }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_StaticFields, ____emptyArray_5)); }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* get__emptyArray_5() const { return ____emptyArray_5; }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* value)
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


// Unity.XRTools.ModuleLoader.FunctionalityProviderMethods
struct FunctionalityProviderMethods_t0976F7610402F211596C6162C3240E97E35DEC98  : public RuntimeObject
{
public:

public:
};


// Unity.XRTools.ModuleLoader.FunctionalitySubscriberMethods
struct FunctionalitySubscriberMethods_tCD6813D6188DCB78241194E7DEAF5BA311F03F5A  : public RuntimeObject
{
public:

public:
};


// Unity.XRTools.ModuleLoader.IUsesFunctionalityInjectionMethods
struct IUsesFunctionalityInjectionMethods_tEDF8BBA476DB540F6DAAF65084C2B76721A59B22  : public RuntimeObject
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

// Unity.XRTools.ModuleLoader.ImmortalModuleAttribute
struct ImmortalModuleAttribute_tC75E2349133BAE63E1442C0BBE506721B3596645  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

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


// Unity.XRTools.ModuleLoader.ModuleOrderAttribute
struct ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Int32 Unity.XRTools.ModuleLoader.ModuleOrderAttribute::<order>k__BackingField
	int32_t ___U3CorderU3Ek__BackingField_0;

public:
	inline static int32_t get_offset_of_U3CorderU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8, ___U3CorderU3Ek__BackingField_0)); }
	inline int32_t get_U3CorderU3Ek__BackingField_0() const { return ___U3CorderU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CorderU3Ek__BackingField_0() { return &___U3CorderU3Ek__BackingField_0; }
	inline void set_U3CorderU3Ek__BackingField_0(int32_t value)
	{
		___U3CorderU3Ek__BackingField_0 = value;
	}
};


// Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute
struct ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Int32 Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::<Priority>k__BackingField
	int32_t ___U3CPriorityU3Ek__BackingField_0;
	// UnityEngine.RuntimePlatform[] Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::<ExcludedPlatforms>k__BackingField
	RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ___U3CExcludedPlatformsU3Ek__BackingField_1;
	// System.Boolean Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::<DisallowAutoCreation>k__BackingField
	bool ___U3CDisallowAutoCreationU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CPriorityU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF, ___U3CPriorityU3Ek__BackingField_0)); }
	inline int32_t get_U3CPriorityU3Ek__BackingField_0() const { return ___U3CPriorityU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CPriorityU3Ek__BackingField_0() { return &___U3CPriorityU3Ek__BackingField_0; }
	inline void set_U3CPriorityU3Ek__BackingField_0(int32_t value)
	{
		___U3CPriorityU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CExcludedPlatformsU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF, ___U3CExcludedPlatformsU3Ek__BackingField_1)); }
	inline RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* get_U3CExcludedPlatformsU3Ek__BackingField_1() const { return ___U3CExcludedPlatformsU3Ek__BackingField_1; }
	inline RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52** get_address_of_U3CExcludedPlatformsU3Ek__BackingField_1() { return &___U3CExcludedPlatformsU3Ek__BackingField_1; }
	inline void set_U3CExcludedPlatformsU3Ek__BackingField_1(RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* value)
	{
		___U3CExcludedPlatformsU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CExcludedPlatformsU3Ek__BackingField_1), (void*)value);
	}

	inline static int32_t get_offset_of_U3CDisallowAutoCreationU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF, ___U3CDisallowAutoCreationU3Ek__BackingField_2)); }
	inline bool get_U3CDisallowAutoCreationU3Ek__BackingField_2() const { return ___U3CDisallowAutoCreationU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CDisallowAutoCreationU3Ek__BackingField_2() { return &___U3CDisallowAutoCreationU3Ek__BackingField_2; }
	inline void set_U3CDisallowAutoCreationU3Ek__BackingField_2(bool value)
	{
		___U3CDisallowAutoCreationU3Ek__BackingField_2 = value;
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


// Unity.XRTools.ModuleLoader.ModuleAssetCallbackOrderAttribute
struct ModuleAssetCallbackOrderAttribute_t5F0D24AB6547A0442E7AF231666DC0D393C11B81  : public ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8
{
public:

public:
};


// Unity.XRTools.ModuleLoader.ModuleBehaviorCallbackOrderAttribute
struct ModuleBehaviorCallbackOrderAttribute_t034A4607DE6A644528D3D8415E83830C89BE4322  : public ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8
{
public:

public:
};


// Unity.XRTools.ModuleLoader.ModuleBuildCallbackOrderAttribute
struct ModuleBuildCallbackOrderAttribute_tB9866B428CC6EA75D3AAB6E0CBE461F7B853A997  : public ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8
{
public:

public:
};


// Unity.XRTools.ModuleLoader.ModuleSceneCallbackOrderAttribute
struct ModuleSceneCallbackOrderAttribute_t16EA69BF62AA6510336DA590F51F11E00565EDC1  : public ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8
{
public:

public:
};


// Unity.XRTools.ModuleLoader.ModuleUnloadOrderAttribute
struct ModuleUnloadOrderAttribute_t554B0B2E82BD85C2A5F8078B9D2FDF95FF4D5D9E  : public ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8
{
public:

public:
};


// UnityEngine.RuntimePlatform
struct RuntimePlatform_tB8798C800FD9810C0FE2B7D2F2A0A3979D239065 
{
public:
	// System.Int32 UnityEngine.RuntimePlatform::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(RuntimePlatform_tB8798C800FD9810C0FE2B7D2F2A0A3979D239065, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// UnityEngine.RuntimePlatform[]
struct RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52  : public RuntimeArray
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



// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1 (Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71 * __this, const RuntimeMethod* method);
// System.Void Unity.XRTools.ModuleLoader.ModuleOrderAttribute::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleOrderAttribute__ctor_m03CC328347165CC41A14B21F83676A09B6232E1F (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, int32_t ___order0, const RuntimeMethod* method);
// System.Void Unity.XRTools.ModuleLoader.ModuleOrderAttribute::set_order(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ModuleOrderAttribute_set_order_m26085535DECA9419EBAC600D0DCC6869370F7F20_inline (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::set_Priority(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_Priority_mF3C1D4606799BAE64CB16F933E2903DD810AD865_inline (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::set_ExcludedPlatforms(UnityEngine.RuntimePlatform[])
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_ExcludedPlatforms_mC42E974458A5EF41EB16BE167D3C0D314A72AD2F_inline (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ___value0, const RuntimeMethod* method);
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
// System.Void Unity.XRTools.ModuleLoader.IUsesFunctionalityInjectionMethods::InjectFunctionality(Unity.XRTools.ModuleLoader.IUsesFunctionalityInjection,System.Collections.Generic.List`1<System.Object>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFunctionalityInjectionMethods_InjectFunctionality_mCEB347BBE01960AA91221189460F3D50A69ED2CD (RuntimeObject* ___user0, List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * ___objects1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tEC23AA7F57AE59A02DA4AC883A61B8F90A43CDA7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFunctionalityInjection_tF1338A16AB544539FA8E43DEA1D2018BD1C0AE7B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// user.provider.InjectFunctionality(objects);
		RuntimeObject* L_0 = ___user0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* TProvider Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.XRTools.ModuleLoader.IProvidesFunctionalityInjection>::get_provider() */, IFunctionalitySubscriber_1_tEC23AA7F57AE59A02DA4AC883A61B8F90A43CDA7_il2cpp_TypeInfo_var, L_0);
		List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * L_2 = ___objects1;
		NullCheck(L_1);
		InterfaceActionInvoker2< List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 *, List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA * >::Invoke(0 /* System.Void Unity.XRTools.ModuleLoader.IProvidesFunctionalityInjection::InjectFunctionality(System.Collections.Generic.List`1<System.Object>,System.Collections.Generic.List`1<Unity.XRTools.ModuleLoader.IFunctionalityProvider>) */, IProvidesFunctionalityInjection_tF1338A16AB544539FA8E43DEA1D2018BD1C0AE7B_il2cpp_TypeInfo_var, L_1, L_2, (List_1_tD2D5A916FFA8D6378793FE3EC0D0AB5E056B13DA *)NULL);
		// }
		return;
	}
}
// System.Void Unity.XRTools.ModuleLoader.IUsesFunctionalityInjectionMethods::InjectFunctionalitySingle(Unity.XRTools.ModuleLoader.IUsesFunctionalityInjection,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IUsesFunctionalityInjectionMethods_InjectFunctionalitySingle_m0A661903F5FEB533AFC812E99FDDE6969BEA528E (RuntimeObject* ___user0, RuntimeObject * ___obj1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFunctionalitySubscriber_1_tEC23AA7F57AE59A02DA4AC883A61B8F90A43CDA7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IProvidesFunctionalityInjection_tF1338A16AB544539FA8E43DEA1D2018BD1C0AE7B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// user.provider.InjectFunctionalitySingle(obj);
		RuntimeObject* L_0 = ___user0;
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* TProvider Unity.XRTools.ModuleLoader.IFunctionalitySubscriber`1<Unity.XRTools.ModuleLoader.IProvidesFunctionalityInjection>::get_provider() */, IFunctionalitySubscriber_1_tEC23AA7F57AE59A02DA4AC883A61B8F90A43CDA7_il2cpp_TypeInfo_var, L_0);
		RuntimeObject * L_2 = ___obj1;
		NullCheck(L_1);
		InterfaceActionInvoker1< RuntimeObject * >::Invoke(1 /* System.Void Unity.XRTools.ModuleLoader.IProvidesFunctionalityInjection::InjectFunctionalitySingle(System.Object) */, IProvidesFunctionalityInjection_tF1338A16AB544539FA8E43DEA1D2018BD1C0AE7B_il2cpp_TypeInfo_var, L_1, L_2);
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
// System.Void Unity.XRTools.ModuleLoader.ImmortalModuleAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ImmortalModuleAttribute__ctor_mD8AE293B6DBF12311C46FE28668814002D53C442 (ImmortalModuleAttribute_tC75E2349133BAE63E1442C0BBE506721B3596645 * __this, const RuntimeMethod* method)
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.XRTools.ModuleLoader.ModuleBehaviorCallbackOrderAttribute::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleBehaviorCallbackOrderAttribute__ctor_mAEF7A365868294A77CB72F8459B9179533039E8F (ModuleBehaviorCallbackOrderAttribute_t034A4607DE6A644528D3D8415E83830C89BE4322 * __this, int32_t ___order0, const RuntimeMethod* method)
{
	{
		// public ModuleBehaviorCallbackOrderAttribute(int order) : base(order) { }
		int32_t L_0 = ___order0;
		ModuleOrderAttribute__ctor_m03CC328347165CC41A14B21F83676A09B6232E1F(__this, L_0, /*hidden argument*/NULL);
		// public ModuleBehaviorCallbackOrderAttribute(int order) : base(order) { }
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
// System.Int32 Unity.XRTools.ModuleLoader.ModuleOrderAttribute::get_order()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t ModuleOrderAttribute_get_order_mAE948BD2A3A52B09520F1DD7E63743B507022685 (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, const RuntimeMethod* method)
{
	{
		// public int order { get; private set; }
		int32_t L_0 = __this->get_U3CorderU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Unity.XRTools.ModuleLoader.ModuleOrderAttribute::set_order(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleOrderAttribute_set_order_m26085535DECA9419EBAC600D0DCC6869370F7F20 (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int order { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CorderU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Unity.XRTools.ModuleLoader.ModuleOrderAttribute::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleOrderAttribute__ctor_m03CC328347165CC41A14B21F83676A09B6232E1F (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, int32_t ___order0, const RuntimeMethod* method)
{
	{
		// public ModuleOrderAttribute(int order)
		Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1(__this, /*hidden argument*/NULL);
		// this.order = order;
		int32_t L_0 = ___order0;
		ModuleOrderAttribute_set_order_m26085535DECA9419EBAC600D0DCC6869370F7F20_inline(__this, L_0, /*hidden argument*/NULL);
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
// System.Void Unity.XRTools.ModuleLoader.ModuleUnloadOrderAttribute::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleUnloadOrderAttribute__ctor_mAB15D12CF2309997921DD20649B4FE44EDD49978 (ModuleUnloadOrderAttribute_t554B0B2E82BD85C2A5F8078B9D2FDF95FF4D5D9E * __this, int32_t ___order0, const RuntimeMethod* method)
{
	{
		// public ModuleUnloadOrderAttribute(int order) : base (order) { }
		int32_t L_0 = ___order0;
		ModuleOrderAttribute__ctor_m03CC328347165CC41A14B21F83676A09B6232E1F(__this, L_0, /*hidden argument*/NULL);
		// public ModuleUnloadOrderAttribute(int order) : base (order) { }
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
// System.Int32 Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::get_Priority()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t ProviderSelectionOptionsAttribute_get_Priority_m974EA5E91953B0E0B81C3AE17849AFA586A88B4B (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, const RuntimeMethod* method)
{
	{
		// public int Priority { get; private set; }
		int32_t L_0 = __this->get_U3CPriorityU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::set_Priority(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_Priority_mF3C1D4606799BAE64CB16F933E2903DD810AD865 (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int Priority { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CPriorityU3Ek__BackingField_0(L_0);
		return;
	}
}
// UnityEngine.RuntimePlatform[] Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::get_ExcludedPlatforms()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ProviderSelectionOptionsAttribute_get_ExcludedPlatforms_mE352408AAA19655928EAE36A4D887CEFA3AD1BD9 (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, const RuntimeMethod* method)
{
	{
		// public RuntimePlatform[] ExcludedPlatforms { get; private set; }
		RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* L_0 = __this->get_U3CExcludedPlatformsU3Ek__BackingField_1();
		return L_0;
	}
}
// System.Void Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::set_ExcludedPlatforms(UnityEngine.RuntimePlatform[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_ExcludedPlatforms_mC42E974458A5EF41EB16BE167D3C0D314A72AD2F (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ___value0, const RuntimeMethod* method)
{
	{
		// public RuntimePlatform[] ExcludedPlatforms { get; private set; }
		RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* L_0 = ___value0;
		__this->set_U3CExcludedPlatformsU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Boolean Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::get_DisallowAutoCreation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ProviderSelectionOptionsAttribute_get_DisallowAutoCreation_mF0640A04B40924FAFD36D7E40CD2868A58B099F9 (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, const RuntimeMethod* method)
{
	{
		// public bool DisallowAutoCreation { get; }
		bool L_0 = __this->get_U3CDisallowAutoCreationU3Ek__BackingField_2();
		return L_0;
	}
}
// System.Void Unity.XRTools.ModuleLoader.ProviderSelectionOptionsAttribute::.ctor(System.Int32,UnityEngine.RuntimePlatform[],System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute__ctor_m5373E0F20BE835D19DD21793924D73FC303336BB (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, int32_t ___priority0, RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ___excludedPlatforms1, bool ___disallowAutoCreation2, const RuntimeMethod* method)
{
	{
		// public ProviderSelectionOptionsAttribute(int priority = 0, RuntimePlatform[] excludedPlatforms = null, bool disallowAutoCreation = false)
		Attribute__ctor_m5C1862A7DFC2C25A4797A8C5F681FBB5CB53ECE1(__this, /*hidden argument*/NULL);
		// Priority = priority;
		int32_t L_0 = ___priority0;
		ProviderSelectionOptionsAttribute_set_Priority_mF3C1D4606799BAE64CB16F933E2903DD810AD865_inline(__this, L_0, /*hidden argument*/NULL);
		// ExcludedPlatforms = excludedPlatforms;
		RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* L_1 = ___excludedPlatforms1;
		ProviderSelectionOptionsAttribute_set_ExcludedPlatforms_mC42E974458A5EF41EB16BE167D3C0D314A72AD2F_inline(__this, L_1, /*hidden argument*/NULL);
		// DisallowAutoCreation = disallowAutoCreation;
		bool L_2 = ___disallowAutoCreation2;
		__this->set_U3CDisallowAutoCreationU3Ek__BackingField_2(L_2);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ModuleOrderAttribute_set_order_m26085535DECA9419EBAC600D0DCC6869370F7F20_inline (ModuleOrderAttribute_tF4E7C41F4956EFE042B68A08E76B27BBC893CFA8 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int order { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CorderU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_Priority_mF3C1D4606799BAE64CB16F933E2903DD810AD865_inline (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		// public int Priority { get; private set; }
		int32_t L_0 = ___value0;
		__this->set_U3CPriorityU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProviderSelectionOptionsAttribute_set_ExcludedPlatforms_mC42E974458A5EF41EB16BE167D3C0D314A72AD2F_inline (ProviderSelectionOptionsAttribute_t46E7DAD40CB0187DB61C8F07F2B44CA826C3BABF * __this, RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* ___value0, const RuntimeMethod* method)
{
	{
		// public RuntimePlatform[] ExcludedPlatforms { get; private set; }
		RuntimePlatformU5BU5D_tA221FE8D5CE756108CBC39E15F0CB99A0787AD52* L_0 = ___value0;
		__this->set_U3CExcludedPlatformsU3Ek__BackingField_1(L_0);
		return;
	}
}

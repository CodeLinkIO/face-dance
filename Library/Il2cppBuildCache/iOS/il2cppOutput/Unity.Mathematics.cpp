#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>






IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tA96012C582F6417CD28F1C5F72BB7CDE7A2C96C8 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


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

// Unity.Mathematics.math
struct math_tFA6CF4319F9BE692A3A01857946865C31AEDED0E  : public RuntimeObject
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
// System.Int32 Unity.Mathematics.math::max(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t math_max_mC8F55A73FE7E0CE042886B3BAC18422AAEA6991C (int32_t ___x0, int32_t ___y1, const RuntimeMethod* method)
{
	{
		// public static int max(int x, int y) { return x > y ? x : y; }
		int32_t L_0 = ___x0;
		int32_t L_1 = ___y1;
		if ((((int32_t)L_0) > ((int32_t)L_1)))
		{
			goto IL_0006;
		}
	}
	{
		int32_t L_2 = ___y1;
		return L_2;
	}

IL_0006:
	{
		int32_t L_3 = ___x0;
		return L_3;
	}
}
// System.Int32 Unity.Mathematics.math::ceilpow2(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t math_ceilpow2_mB618D9D7FD4AB0D0341E1E01F56178FD988FA009 (int32_t ___x0, const RuntimeMethod* method)
{
	{
		// x -= 1;
		int32_t L_0 = ___x0;
		___x0 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_0, (int32_t)1));
		// x |= x >> 1;
		int32_t L_1 = ___x0;
		int32_t L_2 = ___x0;
		___x0 = ((int32_t)((int32_t)L_1|(int32_t)((int32_t)((int32_t)L_2>>(int32_t)1))));
		// x |= x >> 2;
		int32_t L_3 = ___x0;
		int32_t L_4 = ___x0;
		___x0 = ((int32_t)((int32_t)L_3|(int32_t)((int32_t)((int32_t)L_4>>(int32_t)2))));
		// x |= x >> 4;
		int32_t L_5 = ___x0;
		int32_t L_6 = ___x0;
		___x0 = ((int32_t)((int32_t)L_5|(int32_t)((int32_t)((int32_t)L_6>>(int32_t)4))));
		// x |= x >> 8;
		int32_t L_7 = ___x0;
		int32_t L_8 = ___x0;
		___x0 = ((int32_t)((int32_t)L_7|(int32_t)((int32_t)((int32_t)L_8>>(int32_t)8))));
		// x |= x >> 16;
		int32_t L_9 = ___x0;
		int32_t L_10 = ___x0;
		___x0 = ((int32_t)((int32_t)L_9|(int32_t)((int32_t)((int32_t)L_10>>(int32_t)((int32_t)16)))));
		// return x + 1;
		int32_t L_11 = ___x0;
		return ((int32_t)il2cpp_codegen_add((int32_t)L_11, (int32_t)1));
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif

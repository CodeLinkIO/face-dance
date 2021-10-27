#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Int32 Unity.Mathematics.math::max(System.Int32,System.Int32)
extern void math_max_mC8F55A73FE7E0CE042886B3BAC18422AAEA6991C (void);
// 0x00000002 System.Int32 Unity.Mathematics.math::ceilpow2(System.Int32)
extern void math_ceilpow2_mB618D9D7FD4AB0D0341E1E01F56178FD988FA009 (void);
static Il2CppMethodPointer s_methodPointers[2] = 
{
	math_max_mC8F55A73FE7E0CE042886B3BAC18422AAEA6991C,
	math_ceilpow2_mB618D9D7FD4AB0D0341E1E01F56178FD988FA009,
};
static const int32_t s_InvokerIndices[2] = 
{
	5807,
	6420,
};
extern const CustomAttributesCacheGenerator g_Unity_Mathematics_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_Unity_Mathematics_CodeGenModule;
const Il2CppCodeGenModule g_Unity_Mathematics_CodeGenModule = 
{
	"Unity.Mathematics.dll",
	2,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	g_Unity_Mathematics_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};

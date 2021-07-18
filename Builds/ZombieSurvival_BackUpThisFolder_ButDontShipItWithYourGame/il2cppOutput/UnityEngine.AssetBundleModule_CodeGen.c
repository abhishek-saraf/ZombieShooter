#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Void UnityEngine.AssetBundle::.ctor()
extern void AssetBundle__ctor_mCE6DB7758AAD0EDDB044FC67C5BC7EC987BF3F71 (void);
// 0x00000002 T UnityEngine.AssetBundle::LoadAsset(System.String)
// 0x00000003 UnityEngine.Object UnityEngine.AssetBundle::LoadAsset(System.String,System.Type)
extern void AssetBundle_LoadAsset_m9139320F8B6D3E43B7D29AA7A60030306AE0A2C6 (void);
// 0x00000004 UnityEngine.Object UnityEngine.AssetBundle::LoadAsset_Internal(System.String,System.Type)
extern void AssetBundle_LoadAsset_Internal_mFB165539087545C4B5763BA8B590D84318C6FE1B (void);
// 0x00000005 System.Void UnityEngine.AssetBundle::Unload(System.Boolean)
extern void AssetBundle_Unload_m0DEBACB284F6CECA8DF21486D1BBE1189F6A5D66 (void);
static Il2CppMethodPointer s_methodPointers[5] = 
{
	AssetBundle__ctor_mCE6DB7758AAD0EDDB044FC67C5BC7EC987BF3F71,
	NULL,
	AssetBundle_LoadAsset_m9139320F8B6D3E43B7D29AA7A60030306AE0A2C6,
	AssetBundle_LoadAsset_Internal_mFB165539087545C4B5763BA8B590D84318C6FE1B,
	AssetBundle_Unload_m0DEBACB284F6CECA8DF21486D1BBE1189F6A5D66,
};
static const int32_t s_InvokerIndices[5] = 
{
	2055,
	-1,
	637,
	637,
	1685,
};
static const Il2CppTokenRangePair s_rgctxIndices[1] = 
{
	{ 0x06000002, { 0, 2 } },
};
extern const uint32_t g_rgctx_T_tD4723332F30AC99134853A81BEDB3D4705D8E246;
extern const uint32_t g_rgctx_T_tD4723332F30AC99134853A81BEDB3D4705D8E246;
static const Il2CppRGCTXDefinition s_rgctxValues[2] = 
{
	{ (Il2CppRGCTXDataType)1, (const Il2CppRGCTXDefinitionData *)&g_rgctx_T_tD4723332F30AC99134853A81BEDB3D4705D8E246 },
	{ (Il2CppRGCTXDataType)2, (const Il2CppRGCTXDefinitionData *)&g_rgctx_T_tD4723332F30AC99134853A81BEDB3D4705D8E246 },
};
extern const CustomAttributesCacheGenerator g_UnityEngine_AssetBundleModule_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_AssetBundleModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_AssetBundleModule_CodeGenModule = 
{
	"UnityEngine.AssetBundleModule.dll",
	5,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	1,
	s_rgctxIndices,
	2,
	s_rgctxValues,
	NULL,
	g_UnityEngine_AssetBundleModule_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};

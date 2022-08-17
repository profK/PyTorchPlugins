// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class PyTorchLib : ModuleRules
{
	private void CopyDLLToBinaries(string dllpath)
	{
		string dllname = Path.GetFileName(dllpath);
		string Destination = Path.Combine("$(BinaryOutputDir)",dllname);
		RuntimeDependencies.Add(Destination, dllpath);
	}
	public PyTorchLib(ReadOnlyTargetRules Target) : base(Target)
	{
	    bUseRTTI = true;
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicRuntimeLibraryPaths.Add(
			Path.Combine(ModuleDirectory, "../ThirdParty/lib"));
		
		//PublicAdditionalLibraries.AddRange(new string[]
		//{
		//	Path.Combine(ModuleDirectory,  "../ThirdParty/lib/torch.lib")
		//});
// Add PytorchLibraries
		DirectoryInfo piTorchLibDir = 
			new DirectoryInfo(Path.Combine(ModuleDirectory, "../ThirdParty/lib"));
		foreach (FileInfo fInfo in piTorchLibDir.GetFiles("*.lib")){
			PublicAdditionalLibraries.Add(fInfo.FullName);
		}
		
		foreach (FileInfo fInfo in piTorchLibDir.GetFiles("*.dll")){
			CopyDLLToBinaries(fInfo.FullName);
		}
		
		PublicIncludePaths.AddRange(
			new string[] {
				Path.Combine(ModuleDirectory, "Public/Include/torch/csrc/api/include"),
				Path.Combine(ModuleDirectory, "Public/Include/")
			}
		);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core", 
				"Projects"
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);
		
	}
}

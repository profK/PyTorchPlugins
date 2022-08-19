// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class PyTorchDLL : ModuleRules
{
	public PyTorchDLL(ReadOnlyTargetRules Target) : base(Target)
	{
		bUseRTTI = true;
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				Path.Combine(ModuleDirectory, 
					"Public/torch/csrc/api/include")
			}
		);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
		
		//For linking at build
		DirectoryInfo piTorchLibDir = 
			new DirectoryInfo(Path.Combine(ModuleDirectory,
				"../../Binaries/ThirdParty/PyTorchDLLLibrary/win64"));
		foreach (FileInfo fInfo in piTorchLibDir.GetFiles("*.lib")){
			PublicAdditionalLibraries.Add(fInfo.FullName);
		}
		
		foreach (FileInfo fInfo in piTorchLibDir.GetFiles("*.dll")){
			RuntimeDependencies.Add("$(BinaryOutputDir)/"+fInfo.Name,
				fInfo.FullName);
		}
		
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

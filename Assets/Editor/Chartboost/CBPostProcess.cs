﻿using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditorChartboost;

namespace ChartboostSDK {
	public class ChartboostPostProcess : MonoBehaviour {
		
		[PostProcessBuild(5000)]
		public static void OnPostProcessBuild(BuildTarget target, string path) {
			if(target == BuildTarget.iPhone && !EditorUserBuildSettings.appendProject) {
				PostProcessBuild_iOS(path);
			}
		}
		
		private static void PostProcessBuild_iOS(string path) {
			ProcessXCodeProject(path);
		}
		

		private static void ProcessXCodeProject(string path) {
			UnityEditor.XCodeEditorChartboost.XCProject project = new UnityEditor.XCodeEditorChartboost.XCProject(path);

			// Find and run through all projmods files to patch the project
			string projModPath = System.IO.Path.Combine(Application.dataPath, "Editor/Chartboost");
			var files = System.IO.Directory.GetFiles(projModPath, "*.projmods", System.IO.SearchOption.AllDirectories);
			foreach(var file in files) {
				project.ApplyMod(file);
			}
			project.Save();
		}
	}
}

﻿using Common.Dto;
using System.IO;

namespace Common.Helpers
{
	public static class WorkoutHelper
	{
		public static string GetTitle(Workout workout)
		{
			var rideTitle = workout.Ride?.Title ?? workout.Id;
			var instructorName = workout.Ride?.Instructor?.Name;

			if (instructorName is object)
				instructorName = $" with {instructorName}";

			return $"{rideTitle}{instructorName}"
				.Replace(" ", "_")
				.Replace("/", "-")
				.Replace(":", "-");
		}

		public static string GetUniqueTitle(Workout workout)
		{
			return $"{workout.Id}_{GetTitle(workout)}";
		}

		public static string GetWorkoutIdFromFileName(string filePath)
		{
			var fileName = Path.GetFileNameWithoutExtension(filePath);
			var parts = fileName.Split("_");
			return parts[0];
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_4._1___Model_Loading
{
	public struct Vertex
	{
		public Vector3 Position;
		public Vector3 Normal;
		public Vector3 Tangent;
		public Vector2 TexCoords;
		public Vector3 Bitangent;

		public const int MAX_BONE_INFLUENCE = 4;
		public int[] BoneIds;
		public float[] Weights;
	}
}

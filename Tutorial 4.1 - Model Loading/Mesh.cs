﻿using Silk.NET.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_4._1___Model_Loading
{
	public class Mesh : IDisposable
	{
		public Mesh(GL gl, float[] vertices, uint[] indices, List<Texture> textures)
		{
			GL = gl;
			Vertices = vertices;
			Indices = indices;
			Textures = textures;
			SetupMesh();
		}

		public float[] Vertices { get; private set; }
		public uint[] Indices { get; private set; }
		public IReadOnlyList<Texture> Textures { get; private set; }
		public VertexArrayObject<float, uint> VAO { get; set; }
		public BufferObject<float> VBO { get; set; }
		public BufferObject<uint> EBO { get; set; }
		public GL GL { get; }

		public unsafe void SetupMesh()
		{
			EBO = new BufferObject<uint>(GL, Indices, BufferTargetARB.ElementArrayBuffer);
			VBO = new BufferObject<float>(GL, Vertices, BufferTargetARB.ArrayBuffer);
			VAO = new VertexArrayObject<float, uint>(GL, VBO, EBO);
			VAO.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
			VAO.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);
		}

		public void Bind()
		{
			VAO.Bind();
		}

		public void Dispose()
		{
			Textures = null;
			VAO.Dispose();
			VBO.Dispose();
			EBO.Dispose();
		}
	}
}

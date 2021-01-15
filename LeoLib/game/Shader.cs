using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using LeoLib.script;
using LeoLib.game.model.objects;

namespace LeoLib
{
    // A simple class meant to help create shaders.
    public class Shader
    {
        public readonly int handle;

        private readonly Dictionary<string, int> uniformLocations;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Shader(string vertPath, string fragPath)
        {
            var vertexShader = CompileShader(vertPath, ShaderType.VertexShader);

            var fragmentShader = CompileShader(fragPath, ShaderType.FragmentShader);

            handle = LinkProgram(vertexShader, fragmentShader);

            GL.DetachShader(handle, vertexShader);
            GL.DetachShader(handle, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

            GL.GetProgram(handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            uniformLocations = new Dictionary<string, int>();

            // Loop over all the uniforms,
            for (var i = 0; i < numberOfUniforms; i++)
            {
                // get the name of this uniform,
                var key = GL.GetActiveUniform(handle, i, out _, out _);

                // get the location,
                var location = GL.GetUniformLocation(handle, key);

                // and then add it to the dictionary.
                uniformLocations.Add(key, location);
            }

            //GL.UseProgram(handle);
        }

        public void Use()
        {
            GL.UseProgram(handle);
        }

        public void Use(Camera camera)
        {
            GL.UseProgram(handle);

            SetUniform("view", camera.GetViewMatrix());
            SetUniform("projection", camera.GetProjectionMatrix());
        }

        public void Use(Sprite sprite)
        {
            sprite.BindVao();

            SetUniform("texture0", 0);  
            //SetUniform("texture1", 1);

            SetUniform("model", sprite.GetModel());
        }

        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(handle, attribName);
        }

        /*************************/
        /*** Uniform Functions ***/
        /*************************/

        public void SetUniform(string name, int data)
        {
            GL.Uniform1(uniformLocations[name], data);
        }

        public void SetUniform(string name, float data)
        {
            GL.Uniform1(uniformLocations[name], data);
        }

        public void SetUniform(string name, Matrix4 data)
        {
            GL.UniformMatrix4(uniformLocations[name], true, ref data);
        }

        public void SetUniform(string name, Vector3 data)
        {
            GL.Uniform3(uniformLocations[name], data);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private int CompileShader(string path, ShaderType type)
        {
            string source = LoadSource(path);
            var shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);

            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }

            return (shader);
        }

        private int LinkProgram(int vertexShader, int fragmentShader)
        {
            var handle = GL.CreateProgram();

            // Attach both shaders...
            GL.AttachShader(handle, vertexShader);
            GL.AttachShader(handle, fragmentShader);

            // We link the program
            GL.LinkProgram(handle);

            // Check for linking errors
            GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                // We can use `GL.GetProgramInfoLog(program)` to get information about the error.
                throw new Exception($"Error occurred whilst linking Program({handle})");
            }

            return (handle);
        }

        private string LoadSource(string path)
        {
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
    }
}